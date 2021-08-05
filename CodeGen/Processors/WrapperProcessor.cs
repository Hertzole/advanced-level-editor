using System;
using System.Collections.Generic;
using System.Linq;
using Hertzole.ALE.CodeGen.Data;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Hertzole.ALE.CodeGen
{
	public static class WrapperProcessor
	{
		private const string WRAPPER_NAME = "ALE__GeneratedComponentWrapper";

		public static WrapperData CreateWrapper(TypeDefinition baseType, IReadOnlyList<IExposedProperty> properties)
		{
			if (baseType.HasNestedTypes)
			{
				for (int i = 0; i < baseType.NestedTypes.Count; i++)
				{
					if (baseType.NestedTypes[i].Name == WRAPPER_NAME)
					{
						throw new NotSupportedException($"{baseType.FullName} already has a nested class called '{WRAPPER_NAME}'.");
					}
				}
			}

			TypeDefinition wrapper = new TypeDefinition(baseType.Namespace, WRAPPER_NAME,
				TypeAttributes.NestedPublic | TypeAttributes.SequentialLayout | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit,
				baseType.Module.GetTypeReference<ValueType>());

			baseType.NestedTypes.Add(wrapper);

			wrapper.Interfaces.Add(new InterfaceImplementation(baseType.Module.GetTypeReference<IExposedWrapper>()));
			TypeDefinition dirtyMaskType = CreateDirtyMask();
			wrapper.NestedTypes.Add(dirtyMaskType);
			FieldDefinition dirtyMaskField = new FieldDefinition("ALE__Generated__dirtyMaskField", FieldAttributes.Public, dirtyMaskType);
			wrapper.Fields.Add(dirtyMaskField);

			MethodDefinition ctor = wrapper.AddMethod(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			
			ILProcessor il = ctor.BeginEdit();

			ParameterDefinition dirtyMaskParameter = ctor.AddParameter(dirtyMaskType);

			il.EmitLdarg();
			il.EmitLdarg(dirtyMaskParameter);
			il.Emit(OpCodes.Stfld, dirtyMaskField);

			for (int i = 0; i < properties.Count; i++)
			{
				FieldDefinition field = CreateField(properties[i]);
				wrapper.Fields.Add(field);

				ParameterDefinition p = ctor.AddParameter(properties[i].FieldTypeComponentAware);
#if ALE_DEBUG
				p.Name = properties[i].Name;
#else
#endif

#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, $"{baseType.FullName} wrapper setting value for field {properties[i].Id} ({properties[i].Name})");
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

				il.EmitLdarg();
				il.EmitInt(properties[i].Id);
				il.EmitLdarg(p);

				MethodReference fieldCtor = baseType.Module.ImportReference(typeof(ValueTuple<,>)
				                                                            .GetConstructors()
				                                                            .Single(c => c.GetParameters().Length == 2))
				                                    .MakeHostInstanceGeneric(baseType.Module.ImportReference(typeof(ValueTuple<,>))
				                                                                     .MakeGenericInstanceType(baseType.Module.GetTypeReference<int>(), baseType.Module.ImportReference(properties[i].FieldTypeComponentAware)));

				il.Emit(OpCodes.Newobj, fieldCtor);
				il.Emit(OpCodes.Stfld, field);
			}

			il.Emit(OpCodes.Ret);

			ctor.EndEdit();

			return new WrapperData(wrapper, ctor, dirtyMaskType, dirtyMaskField);

			TypeDefinition CreateDirtyMask()
			{
				TypeDefinition mask = new TypeDefinition(string.Empty, "ALE__GENERATED__dirtyMask", TypeAttributes.NestedPublic | TypeAttributes.AnsiClass | TypeAttributes.Sealed, baseType.Module.GetTypeReference<Enum>());

				mask.Fields.Add(new FieldDefinition("value__", FieldAttributes.Public | FieldAttributes.SpecialName | FieldAttributes.RTSpecialName, baseType.Module.GetTypeReference<long>()));
				FieldDefinition noneField = new FieldDefinition("None", FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal, mask)
				{
					Constant = 0L
				};

				mask.Fields.Add(noneField);

				for (int i = 0; i < properties.Count; i++)
				{
					FieldDefinition field = new FieldDefinition(properties[i].Name, FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal, mask)
					{
						Constant = 1L << i
					};

					mask.Fields.Add(field);
				}

				return mask;
			}

			FieldDefinition CreateField(IExposedProperty property)
			{
				TypeReference tuple = baseType.Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(baseType.Module.GetTypeReference<int>(), property.FieldTypeComponentAware);

				FieldDefinition f = new FieldDefinition(property.Name, FieldAttributes.Public, tuple);
				return f;
			}
		}
	}
}