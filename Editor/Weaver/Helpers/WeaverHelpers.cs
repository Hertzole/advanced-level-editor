using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Runtime.CompilerServices;

namespace Hertzole.ALE.Editor
{
    public static class WeaverHelpers
    {
        private static int converterIndex = 0;

        public static TypeDefinition LoadOrCreateConverterType(TypeDefinition type, out FieldDefinition instanceField)
        {
            for (int i = 0; i < type.NestedTypes.Count; i++)
            {
                if (type.NestedTypes[i].Name == "<>c")
                {
                    instanceField = null;

                    for (int j = 0; j < type.NestedTypes[i].Methods.Count; j++)
                    {
                        if (type.NestedTypes[i].Methods[j].Name == ".cctor")
                        {
                            instanceField = (FieldDefinition)type.NestedTypes[i].Methods[j].Body.Instructions[1].Operand;
                        }
                    }

                    return type.NestedTypes[i];
                }
            }

            TypeDefinition converter = new TypeDefinition("", "<>c", TypeAttributes.NestedPrivate | TypeAttributes.AutoClass | TypeAttributes.AnsiClass |
                 TypeAttributes.Sealed | TypeAttributes.Serializable | TypeAttributes.BeforeFieldInit, type.Module.ImportReference(typeof(object)));
            converter.CustomAttributes.Add(new CustomAttribute(type.Module.ImportReference(typeof(CompilerGeneratedAttribute).GetConstructor(Type.EmptyTypes))));

            instanceField = new FieldDefinition("instance", FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.InitOnly, converter);
            converter.Fields.Add(instanceField);

            MethodDefinition constructor = new MethodDefinition(".cctor", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName
                | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Static, type.Module.ImportReference(typeof(void)));

            MethodDefinition converterConstructor = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName
                | MethodAttributes.RTSpecialName, type.Module.ImportReference(typeof(void)));

            ILProcessor il = constructor.Body.GetILProcessor();
            il.Emit(OpCodes.Newobj, converterConstructor);
            il.Emit(OpCodes.Stsfld, instanceField);
            il.Emit(OpCodes.Ret);

            il = converterConstructor.Body.GetILProcessor();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, type.Module.ImportReference(typeof(object).GetConstructor(Type.EmptyTypes)));
            il.Emit(OpCodes.Ret);

            converter.Methods.Add(constructor);
            converter.Methods.Add(converterConstructor);

            type.NestedTypes.Add(converter);

            return converter;
        }

        public static void CreateConverterField(bool addToBase, Type type, TypeReference[] genericParameters, TypeDefinition baseType, TypeDefinition converterType, TypeReference fieldType, string name, string methodName,
                                                 out FieldDefinition converterField, out MethodDefinition converterMethod, Action<ILProcessor> generateBody, TypeReference returnType, params TypeReference[] bodyParameters)
        {
            TypeReference convType = baseType.Module.ImportReference(type);
            GenericInstanceType genericConvType = convType.MakeGenericInstanceType(genericParameters);

            converterField = new FieldDefinition($"<>_{name}__{converterIndex}", FieldAttributes.Public | FieldAttributes.Static, genericConvType);
            FieldDefinition baseField = new FieldDefinition($"<>_{name}__{converterIndex}", FieldAttributes.Public | FieldAttributes.Static, genericConvType);

            if (addToBase)
            {
                baseType.Fields.Add(baseField);
            }

            converterType.Fields.Add(converterField);

            converterMethod = new MethodDefinition($"<{methodName}>_converter__{converterIndex}", MethodAttributes.Assembly | MethodAttributes.HideBySig,
                                                    baseType.Module.ImportReference(returnType));

            for (int i = 0; i < bodyParameters.Length; i++)
            {
                converterMethod.Parameters.Add(new ParameterDefinition("para" + i, ParameterAttributes.None, baseType.Module.ImportReference(bodyParameters[i])));
            }

            ILProcessor il = converterMethod.Body.GetILProcessor();
            generateBody.Invoke(il);

            MethodDefinition baseMethod = converterMethod.Duplicate();

            if (addToBase)
            {
                baseType.Methods.Add(baseMethod);
            }

            converterType.Methods.Add(converterMethod);

            converterIndex++;
        }
    }
}
