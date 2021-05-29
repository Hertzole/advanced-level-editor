using MessagePack.Resolvers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Hertzole.ALE.CodeGen
{
    public class RegisterTypeProcessor
    {
        private readonly ModuleDefinition module;
        private readonly List<TypeReference> types;

        public RegisterTypeProcessor(ModuleDefinition module)
        {
            this.module = module;
            types = new List<TypeReference>();
        }

        public void AddType(TypeReference type)
        {
            if (!ContainsType(type))
            {
                types.Add(type);
            }
        }

        private TypeReference ResolveType(TypeReference type)
        {
            bool isArray = type.IsArray;
            bool isList = type.Is(typeof(List<>));
            TypeDefinition resolved = isList ? ((GenericInstanceType)type).GenericArguments[0].Resolve() : type.Resolve();
            if (resolved != null)
            {
                if (resolved.IsSubclassOf<Component>() || resolved.Is<GameObject>())
                {
                    if (isList)
                    {
                        type = module.ImportReference(typeof(List<ComponentDataWrapper>));
                    }
                    else if (isArray)
                    {
                        type = module.ImportReference(typeof(ComponentDataWrapper[]));
                    }
                    else
                    {
                        type = module.ImportReference(typeof(ComponentDataWrapper));
                    }
                }
            }

            return type;
        }

        private bool ContainsType(TypeReference type)
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

        public void EndEditing()
        {
            if (types == null || types.Count == 0)
            {
                return;
            }

            TypeDefinition generatedClass = CreateClass();
            generatedClass.Methods.Add(CreateRegisterMethod());

            module.Types.Add(generatedClass);
        }

        private TypeDefinition CreateClass()
        {
            TypeDefinition type = new TypeDefinition("Hertzole.ALE.Generated", $"{module.Name.Substring(0, module.Name.Length - 4).Replace('-', '_').Replace('.', '_')}__ALE__Generated__RegisterTypes",
                TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.Abstract |
                TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit, module.ImportReference(typeof(object)));

            return type;
        }

        private MethodDefinition CreateRegisterMethod()
        {
            MethodDefinition method = new MethodDefinition("Generated__RegisterExposedTypes",
                MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static, module.ImportReference(typeof(void)));

            MethodReference initAttributeCtor = module.ImportReference(
                typeof(RuntimeInitializeOnLoadMethodAttribute).GetConstructor(new Type[] { typeof(RuntimeInitializeLoadType) }));
            CustomAttribute attribute = new CustomAttribute(initAttributeCtor);
            attribute.ConstructorArguments.Add(new CustomAttributeArgument(module.ImportReference(
                typeof(RuntimeInitializeLoadType)), RuntimeInitializeLoadType.BeforeSceneLoad));
            method.CustomAttributes.Add(attribute);

            MethodReference registerType = module.GetMethod(typeof(LevelEditorSerializer), "RegisterType", typeof(int));
            
            ILProcessor il = method.Body.GetILProcessor();
            for (int i = 0; i < types.Count; i++)
            {
                GenericInstanceMethod m = new GenericInstanceMethod(registerType);
                m.GenericArguments.Add(types[i]);
                il.EmitInt(types[i].FullName.GetStableHashCode());
                il.Emit(OpCodes.Call, m);
            }

            il.Emit(OpCodes.Ret);

            return method;
        }
    }
}
