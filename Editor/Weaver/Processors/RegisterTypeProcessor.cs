using MessagePack.Resolvers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Hertzole.ALE.Editor
{
    public static class RegisterTypeProcessor
    {
        private static AssemblyDefinition assembly;

        private static List<TypeReference> types;

        public static void StartEditing(AssemblyDefinition assembly)
        {
            if (types == null)
            {
                types = new List<TypeReference>();
            }
            else
            {
                types.Clear();
            }

            RegisterTypeProcessor.assembly = assembly;
        }

        public static void AddType(TypeReference type)
        {
            type = ResolveType(type);

            if (!ContainsType(type))
            {
                types.Add(type);
            }
        }

        private static TypeReference ResolveType(TypeReference type)
        {
            bool isArray = type.IsArray;
            bool isList = type.Is(typeof(List<>));
            TypeDefinition resolved = isList ? ((GenericInstanceType)type).GenericArguments[0].Resolve() : type.Resolve();
            if (resolved != null)
            {
                if (resolved.IsSubclassOf<Component>())
                {
                    if (isList)
                    {
                        type = assembly.MainModule.ImportReference(typeof(List<Component>));
                    }
                    else if (isArray)
                    {
                        type = assembly.MainModule.ImportReference(typeof(Component[]));
                    }
                    else
                    {
                        type = assembly.MainModule.ImportReference(typeof(Component));
                    }
                }
            }

            return type;
        }

        private static bool ContainsType(TypeReference type)
        {
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].FullName == type.FullName)
                {
                    return true;
                }
            }

            return false;
        }

        public static void EndEditing()
        {
            if (types == null || types.Count == 0)
            {
                return;
            }

            TypeDefinition generatedClass = CreateClass();
            generatedClass.Methods.Add(CreateRegisterMethod());
            generatedClass.Methods.Add(CreateAOTPreserveMethod());

            assembly.MainModule.Types.Add(generatedClass);
        }

        private static TypeDefinition CreateClass()
        {
            TypeDefinition type = new TypeDefinition("Hertzole.ALE.Generated", "ALE__Generated__RegisterTypes",
                TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.Abstract |
                TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit, assembly.MainModule.ImportReference(typeof(object)));

            return type;
        }

        private static MethodDefinition CreateRegisterMethod()
        {
            MethodDefinition method = new MethodDefinition("Generated__RegisterExposedTypes",
                MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static, assembly.MainModule.ImportReference(typeof(void)));

            MethodReference initAttributeCtor = assembly.MainModule.ImportReference(
                typeof(RuntimeInitializeOnLoadMethodAttribute).GetConstructor(new Type[] { typeof(RuntimeInitializeLoadType) }));
            CustomAttribute attribute = new CustomAttribute(initAttributeCtor);
            attribute.ConstructorArguments.Add(new CustomAttributeArgument(assembly.MainModule.ImportReference(
                typeof(RuntimeInitializeLoadType)), RuntimeInitializeLoadType.BeforeSceneLoad));
            method.CustomAttributes.Add(attribute);

            MethodReference registerType = assembly.MainModule.ImportReference(typeof(LevelEditorSerializer).GetMethod("RegisterType"));

            ILProcessor il = method.Body.GetILProcessor();
            for (int i = 0; i < types.Count; i++)
            {
                GenericInstanceMethod m = new GenericInstanceMethod(registerType);
                m.GenericArguments.Add(types[i]);
                il.Emit(OpCodes.Call, m);
            }

            il.Emit(OpCodes.Ret);

            return method;
        }

        private static MethodDefinition CreateAOTPreserveMethod()
        {
            MethodDefinition method = new MethodDefinition("AOT__Preserve__Generated",
                MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static,
                assembly.MainModule.ImportReference(typeof(void)));

            CustomAttribute attribute = new CustomAttribute(assembly.MainModule.ImportReference(typeof(PreserveAttribute).GetConstructor(Type.EmptyTypes)));
            method.CustomAttributes.Add(attribute);

            ILProcessor il = method.Body.GetILProcessor();
            FieldReference instance = assembly.MainModule.ImportReference(typeof(StaticCompositeResolver).GetField("Instance"));
            MethodReference getFormatter = assembly.MainModule.ImportReference(typeof(StaticCompositeResolver).GetMethod("GetFormatter"));

            for (int i = 0; i < types.Count; i++)
            {
                il.Emit(OpCodes.Ldsfld, instance);
                GenericInstanceMethod m = new GenericInstanceMethod(getFormatter);
                m.GenericArguments.Add(types[i]);
                il.Emit(OpCodes.Callvirt, m);
                il.Emit(OpCodes.Pop);
            }

            il.Emit(OpCodes.Ret);

            return method;
        }
    }
}
