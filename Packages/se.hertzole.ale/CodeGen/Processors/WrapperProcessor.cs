using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hertzole.ALE.CodeGen.Helpers;
using MessagePack;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Hertzole.ALE.CodeGen
{
	public static class WrapperProcessor
	{
		public static TypeDefinition CreateWrapper(TypeDefinition baseType, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties)
		{
			TypeDefinition wrapper = baseType.AddNestedType($"ALE__GENERATED__{baseType.Name}ComponentWrapper",
				TypeAttributes.NestedPublic | TypeAttributes.SequentialLayout | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit,
				module.GetTypeReference<ValueType>());

			wrapper.AddInterface<IExposedWrapper>();

			PropertyDefinition valuesProperty = CreateProperty<Dictionary<int, object>>(wrapper, module, "Values");
			CreateProperty<Dictionary<int, bool>>(wrapper, module, "Dirty");
			
			CreateSerializeMethod(wrapper, module, valuesProperty, properties);
			CreateDeserializeMethod(wrapper, module, properties);

			return wrapper;
		}

		private static PropertyDefinition CreateProperty<T>(TypeDefinition wrapper, ModuleDefinition module, string name)
		{
			FieldDefinition field = wrapper.AddField<T>($"<{name}>k__BackingField", FieldAttributes.Private);
			field.CustomAttributes.Add(new CustomAttribute(module.GetConstructor<CompilerGeneratedAttribute>()));

			var get = wrapper.AddMethod<T>($"get_{name}", 
				MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			get.AddAttribute<CompilerGeneratedAttribute>();
			get.AddAttribute<IsReadOnlyAttribute>();

			ILProcessor il = get.BeginEdit();

			il.EmitLdarg();
			il.Emit(OpCodes.Ldfld, field);
			il.Emit(OpCodes.Ret);
			
			get.EndEdit();

			var set = wrapper.AddMethod($"set_{name}", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName);
			var paraValue = set.AddParameter<T>("value");
			set.AddAttribute<CompilerGeneratedAttribute>();

			il = set.BeginEdit();

			il.EmitLdarg();
			il.EmitLdarg(paraValue);
			il.Emit(OpCodes.Stfld, field);
			il.Emit(OpCodes.Ret);
			
			set.EndEdit();

			PropertyDefinition property = new PropertyDefinition(name, PropertyAttributes.None, module.GetTypeReference<T>())
			{
				GetMethod = get,
				SetMethod = set
			};

			wrapper.Properties.Add(property);

			return property;
		}

		private static void CreateSerializeMethod(TypeDefinition wrapper, ModuleDefinition module, PropertyDefinition valuesField, IReadOnlyList<IExposedProperty> properties)
		{
			MethodDefinition m = wrapper.AddMethod("Serialize",
				MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			ParameterDefinition paraId = m.AddParameter<int>("id");
			ParameterDefinition paraWriter = m.AddParameter(module.GetTypeReference(typeof(MessagePackWriter).MakeByRefType()), "writer");
			ParameterDefinition paraOptions = m.AddParameter<MessagePackSerializerOptions>("options");

			ILProcessor il = m.BeginEdit();

			il.EmitIfElse(properties, (property, index, next, body, fill) =>
			{
				// if (id == <id>)
				fill.Add(ILHelper.Ldarg(il, paraId));
				if (property.Id == 0)
				{
					fill.Add(Instruction.Create(OpCodes.Brtrue, next));
				}
				else
				{
					fill.Add(ILHelper.Int(property.Id));
					fill.Add(Instruction.Create(OpCodes.Bne_Un, next));
				}
			}, (property, index, next, fill) =>
			{
				// writer.Write((Type) values[id])
				// options.Resolver.GetFormatterWithVerify<Type>().Serialize(ref writer, (Type) values[id], options)
				fill.AddRange(FormatterHelper.GetWriteValue(property.FieldTypeComponentAware, module, il, paraWriter, paraOptions, list =>
				{
					list.Add(Instruction.Create(OpCodes.Call, valuesField.GetMethod));
					list.Add(ILHelper.Int(property.Id));
					list.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod<Dictionary<int, object>>("get_Item")));
					if (property.IsValueType)
					{
						list.Add(Instruction.Create(OpCodes.Unbox_Any, property.FieldTypeComponentAware));
					}
				}));

				if (index <= properties.Count - 1)
				{
					fill.Add(Instruction.Create(OpCodes.Ret));
				}
			}, fill => { fill.Add(Instruction.Create(OpCodes.Ret)); });

			m.EndEdit();
		}

		private static void CreateDeserializeMethod(TypeDefinition wrapper, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties)
		{
			MethodDefinition m = wrapper.AddMethod<object>("Deserialize",
				MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			ParameterDefinition paraId = m.AddParameter<int>("id");
			ParameterDefinition paraReader = m.AddParameter(module.GetTypeReference(typeof(MessagePackReader).MakeByRefType()), "reader");
			ParameterDefinition paraOptions = m.AddParameter<MessagePackSerializerOptions>("options");

			ILProcessor il = m.BeginEdit();

			il.EmitIfElse(properties, (property, index, next, body, fill) =>
			{
				// if (id == <id>)
				fill.Add(ILHelper.Ldarg(il, paraId));
				if (property.Id == 0)
				{
					fill.Add(Instruction.Create(OpCodes.Brtrue, next));
				}
				else
				{
					fill.Add(ILHelper.Int(property.Id));
					fill.Add(Instruction.Create(OpCodes.Bne_Un, next));
				}
			}, (property, index, next, fill) =>
			{
				// return reader.Read()
				// return options.Resolver.GetFormatterWithVerify<Type>().Deserialize(ref reader, options)

				fill.AddRange(FormatterHelper.GetReadValue(property.FieldTypeComponentAware, module, il, paraReader, paraOptions));
				if (property.IsValueType)
				{
					fill.Add(Instruction.Create(OpCodes.Box, property.FieldTypeComponentAware));
				}

				fill.Add(Instruction.Create(OpCodes.Ret));
			}, fill =>
			{
				// return null
				fill.Add(Instruction.Create(OpCodes.Ldnull));
				fill.Add(Instruction.Create(OpCodes.Ret));
			});

			m.EndEdit();
		}
	}
}