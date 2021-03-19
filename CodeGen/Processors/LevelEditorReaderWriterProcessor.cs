//using Mono.Cecil;
//using Mono.Cecil.Cil;
//using Mono.Cecil.Rocks;
//using Mono.Collections.Generic;
//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEngine;

//namespace Hertzole.ALE.Editor
//{
//    public class LevelEditorReaderWriterProcessor : BaseProcessor
//    {
//        public static TypeDefinition generatedClass;

//        private const string INITIALIZE_METHOD_NAME = "ALE__GENERATED__InitializeWritersReaders";

//        public override bool IsValidClass(TypeDefinition type)
//        {
//            if (type.HasMethods)
//            {
//                for (int i = 0; i < type.Methods.Count; i++)
//                {
//                    if (IsValidWriterMethod(type.Methods[i]))
//                    {
//                        return true;
//                    }

//                    if (IsValidReaderMethod(type.Methods[i]))
//                    {
//                        return true;
//                    }
//                }
//            }

//            return false;
//        }

//        private bool IsValidWriterMethod(MethodDefinition method, TypeReference neededType = null)
//        {
//            if (!method.HasAttribute<ExtensionAttribute>())
//            {
//                return false;
//            }

//            if (method.Parameters.Count != 3)
//            {
//                return false;
//            }

//            if (!method.Parameters[0].ParameterType.Is<LevelEditorWriter>())
//            {
//                return false;
//            }

//            if (!method.Parameters[2].ParameterType.Is<string>())
//            {
//                return false;
//            }

//            if (method.ReturnType.FullName != typeof(void).FullName)
//            {
//                return false;
//            }

//            if (neededType != null && method.Parameters[1].ParameterType.FullName != neededType.FullName)
//            {
//                return false;
//            }

//            return true;
//        }

//        private bool IsValidReaderMethod(MethodDefinition method, TypeReference neededType = null)
//        {
//            if (!method.HasAttribute<ExtensionAttribute>())
//            {
//                return false;
//            }

//            if (method.Parameters.Count != 2)
//            {
//                return false;
//            }

//            if (!method.Parameters[0].ParameterType.Is<LevelEditorReader>())
//            {
//                return false;
//            }

//            if (!method.Parameters[1].ParameterType.Is<bool>())
//            {
//                return false;
//            }

//            if (neededType != null && method.ReturnType.FullName != neededType.FullName)
//            {
//                return false;
//            }

//            return true;
//        }

//        public override (bool success, bool dirty) ProcessClass(ModuleDefinition module, TypeDefinition type)
//        {
//            bool dirty = false;

//            TypeDefinition converter = null;
//            MethodDefinition initMethod = null;
//            FieldDefinition converterInstance = null;
//            ILProcessor il = null;

//            List<MethodDefinition> processedMethods = new List<MethodDefinition>();

//            Collection<MethodDefinition> methods = new Collection<MethodDefinition>(type.Methods);

//            foreach (MethodDefinition method in methods)
//            {
//                bool isWriter = IsValidWriterMethod(method);

//                if (!isWriter && !IsValidReaderMethod(method))
//                {
//                    continue;
//                }

//                MethodDefinition writerMethod = isWriter ? method : null;
//                MethodDefinition readerMethod = !isWriter ? method : null;
//                TypeReference methodType = module.ImportReference(isWriter ? method.Parameters[1].ParameterType : method.ReturnType);

//                for (int i = 0; i < type.Methods.Count; i++)
//                {
//                    if (isWriter && IsValidReaderMethod(type.Methods[i], methodType))
//                    {
//                        readerMethod = type.Methods[i];
//                        break;
//                    }
//                    else if (!isWriter && IsValidWriterMethod(type.Methods[i], methodType))
//                    {
//                        writerMethod = type.Methods[i];
//                        break;
//                    }
//                }

//                if (isWriter && readerMethod == null)
//                {
//                    Debug.LogError($"Couldn't not find a reader method for the type {methodType.FullName}.");
//                    return (false, dirty);
//                }

//                if (!isWriter && writerMethod == null)
//                {
//                    Debug.LogError($"Couldn't find a writer method for tyep type {methodType.FullName}.");
//                    return (false, dirty);
//                }

//                if (processedMethods.Contains(writerMethod) || processedMethods.Contains(readerMethod))
//                {
//                    continue;
//                }

//                if (initMethod == null)
//                {
//                    initMethod = GenerateInitMethodIfNeeded(type);
//                    dirty = true;
//                }

//                if (converter == null)
//                {
//                    converter = WeaverHelpers.LoadOrCreateConverterType(type, out converterInstance);
//                    dirty = true;
//                }

//                if (il == null)
//                {
//                    il = initMethod.Body.GetILProcessor();
//                }

//                TypeReference writerAction = module.ImportReference(typeof(Action<,,>));
//                GenericInstanceType genericWriterAction = writerAction.MakeGenericInstanceType(
//                    module.ImportReference(typeof(LevelEditorWriter)),
//                    module.ImportReference(typeof(object)),
//                    module.ImportReference(typeof(string)));

//                TypeReference readerFunc = module.ImportReference(typeof(Func<,,>));
//                GenericInstanceType genericReaderFunc = writerAction.MakeGenericInstanceType(
//                    module.ImportReference(typeof(LevelEditorReader)),
//                    module.ImportReference(typeof(bool)),
//                    module.ImportReference(typeof(object)));

//                MethodReference writerActionConstructor = module.ImportReference(genericWriterAction.Resolve().GetConstructor(new TypeReference[]
//                {
//                    module.ImportReference(typeof(object)),
//                    module.ImportReference(typeof(IntPtr))
//                })).MakeHostInstanceGeneric(genericWriterAction);

//                MethodReference readerFuncConstructor = module.ImportReference(genericReaderFunc.Resolve().GetConstructor(new TypeReference[]
//               {
//                    module.ImportReference(typeof(object)),
//                    module.ImportReference(typeof(IntPtr))
//               })).MakeHostInstanceGeneric(genericWriterAction);

//                WeaverHelpers.CreateConverterField(false, typeof(Action<,,>), new TypeReference[]
//                {
//                    genericWriterAction.GenericArguments[0],
//                    genericWriterAction.GenericArguments[1],
//                    genericWriterAction.GenericArguments[2],
//                }, type, converter, module.ImportReference(genericWriterAction), method.Name + "__WRITE", INITIALIZE_METHOD_NAME,
//                out FieldDefinition writerConverterField, out MethodDefinition writerConverterMethod, (cil) =>
//                {
//                    cil.Emit(OpCodes.Ldarg_1);
//                    cil.Emit(OpCodes.Ldarg_2);
//                    cil.Emit(methodType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, module.ImportReference(methodType));
//                    cil.Emit(OpCodes.Ldarg_3);
//                    cil.Emit(OpCodes.Call, module.ImportReference(writerMethod));
//                    cil.Emit(OpCodes.Ret);
//                }, module.ImportReference(typeof(void)),
//                module.ImportReference(typeof(LevelEditorWriter)), module.ImportReference(typeof(object)), module.ImportReference(typeof(string)));

//                WeaverHelpers.CreateConverterField(false, typeof(Func<,,>), new TypeReference[]
//                {
//                    module.ImportReference(typeof(LevelEditorReader)),
//                    module.ImportReference(typeof(bool)),
//                    module.ImportReference(typeof(object))
//                }, type, converter, module.ImportReference(genericReaderFunc), method.Name + "__READ", INITIALIZE_METHOD_NAME,
//                out FieldDefinition readerConverterField, out MethodDefinition readerConverterMethod, (cil) =>
//                {
//                    cil.Emit(OpCodes.Ldarg_1);
//                    cil.Emit(OpCodes.Ldarg_2);
//                    cil.Emit(OpCodes.Call, readerMethod);
//                    cil.Emit(OpCodes.Box, methodType);
//                    cil.Emit(OpCodes.Ret);
//                }, module.ImportReference(typeof(object)),
//                module.ImportReference(typeof(LevelEditorReader)), module.ImportReference(typeof(bool)));

//                MethodReference setMethod = module.ImportReference(typeof(LevelEditorSerializer).GetMethod("SetWriterReader"));
//                GenericInstanceMethod genericSetMethod = new GenericInstanceMethod(setMethod);
//                genericSetMethod.GenericArguments.Add(methodType);

//                Instruction loadReader = Instruction.Create(OpCodes.Ldsfld, readerConverterField);
//                Instruction callSet = Instruction.Create(OpCodes.Call, genericSetMethod);

//                il.Emit(OpCodes.Ldsfld, module.ImportReference(writerConverterField));
//                il.Emit(OpCodes.Dup);
//                il.Emit(OpCodes.Brtrue_S, loadReader);
//                il.Emit(OpCodes.Pop);
//                il.Emit(OpCodes.Ldsfld, converterInstance);
//                il.Emit(OpCodes.Ldftn, writerConverterMethod);
//                il.Emit(OpCodes.Newobj, writerActionConstructor);
//                il.Emit(OpCodes.Dup);
//                il.Emit(OpCodes.Stsfld, writerConverterField);

//                il.Append(loadReader);
//                il.Emit(OpCodes.Dup);
//                il.Emit(OpCodes.Brtrue_S, callSet);
//                il.Emit(OpCodes.Pop);
//                il.Emit(OpCodes.Ldsfld, converterInstance);
//                il.Emit(OpCodes.Ldftn, readerConverterMethod);
//                il.Emit(OpCodes.Newobj, readerFuncConstructor);
//                il.Emit(OpCodes.Dup);
//                il.Emit(OpCodes.Stsfld, readerConverterField);

//                il.Append(callSet);

//                processedMethods.Add(writerMethod);
//                processedMethods.Add(readerMethod);
//            }

//            if (initMethod != null && il != null)
//            {
//                il.Emit(OpCodes.Ret);
//            }

//            return (true, dirty);
//        }

//        private MethodDefinition GenerateInitMethodIfNeeded(TypeDefinition type)
//        {
//            MethodDefinition method = new MethodDefinition(INITIALIZE_METHOD_NAME, MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig, type.Module.ImportReference(typeof(void)));
//            MethodReference initAttributeCtor = type.Module.ImportReference(typeof(RuntimeInitializeOnLoadMethodAttribute).GetConstructor(new Type[] { typeof(RuntimeInitializeLoadType) }));
//            CustomAttribute attribute = new CustomAttribute(initAttributeCtor);
//            attribute.ConstructorArguments.Add(new CustomAttributeArgument(type.Module.ImportReference(typeof(RuntimeInitializeLoadType)), 1));
//            method.CustomAttributes.Add(attribute);
//            type.Methods.Add(method);

//            return method;
//        }
//    }
//}
