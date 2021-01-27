using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public class LevelEditorReaderWriterProcessor : BaseProcessor
    {
        public static TypeDefinition generatedClass;

        private MethodDefinition initMethod;

        private const string INITIALIZE_METHOD_NAME = "InitializeWritersReaders";

        public override bool IsValidClass(TypeDefinition type)
        {
            if (type.HasMethods)
            {
                for (int i = 0; i < type.Methods.Count; i++)
                {
                    if (IsValidMethod(type.Methods[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsValidMethod(MethodDefinition method)
        {
            if (method.Parameters.Count != 2)
            {
                return false;
            }

            if (!method.Parameters[0].ParameterType.Is<LevelEditorWriter>())
            {
                return false;
            }

            if (method.ReturnType.FullName != typeof(void).FullName)
            {
                return false;
            }

            return true;
        }

        public override (bool success, bool dirty) ProcessClass(ModuleDefinition module, TypeDefinition type)
        {
            bool dirty = false;

            ILProcessor il = null;

            foreach (MethodDefinition method in type.Methods)
            {
                if (!IsValidMethod(method))
                {
                    continue;
                }

                TypeReference methodType = module.ImportReference(method.Parameters[1].ParameterType);

                TypeReference actionType = module.ImportReference(typeof(Action<,>));
                GenericInstanceType genericAction = actionType.MakeGenericInstanceType(module.ImportReference(typeof(LevelEditorWriter)), methodType);
                MethodReference actionConstructor = module.ImportReference(typeof(Action<,>).GetConstructor(new Type[] { typeof(object), typeof(IntPtr) }));

                TypeReference genericWriter = module.ImportReference(typeof(LevelEditorWriter<>));
                System.Reflection.PropertyInfo writerProperty = typeof(LevelEditorWriter<>).GetProperty(nameof(LevelEditorWriter<int>.Write));
                MethodReference writeSetMethod = module.ImportReference(writerProperty.GetSetMethod());

                GenerateInitMethodIfNeeded(module.ImportReference(generatedClass).Resolve());
                dirty = true;

                if (il == null)
                {
                    il = initMethod.Body.GetILProcessor();
                }

                il.Emit(OpCodes.Ldnull);
                il.Emit(OpCodes.Ldftn, method);
                il.Emit(OpCodes.Newobj, actionConstructor.MakeHostInstanceGeneric(genericAction));

                GenericInstanceType genericWriterWithType = genericWriter.MakeGenericInstanceType(methodType);
                il.Emit(OpCodes.Call, writeSetMethod.MakeHostInstanceGeneric(genericWriterWithType));
            }

            if (dirty && il != null)
            {
                il.Emit(OpCodes.Ret);
            }

            return (true, dirty);
        }

        private void GenerateInitMethodIfNeeded(TypeDefinition type)
        {
            if (type.HasMethod(INITIALIZE_METHOD_NAME))
            {
                return;
            }

            MethodDefinition method = new MethodDefinition(INITIALIZE_METHOD_NAME, MethodAttributes.Public | MethodAttributes.Static, type.Module.ImportReference(typeof(void)));
            MethodReference initAttributeCtor = type.Module.ImportReference(typeof(RuntimeInitializeOnLoadMethodAttribute).GetConstructor(new Type[] { typeof(RuntimeInitializeLoadType) }));
            CustomAttribute attribute = new CustomAttribute(initAttributeCtor);
            attribute.ConstructorArguments.Add(new CustomAttributeArgument(type.Module.ImportReference(typeof(RuntimeInitializeLoadType)), 1));
            method.CustomAttributes.Add(attribute);
            type.Methods.Add(method);

            initMethod = method;
        }
    }
}
