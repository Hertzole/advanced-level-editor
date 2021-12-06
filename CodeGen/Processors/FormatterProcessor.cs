using System;
using System.Collections.Generic;
using Hertzole.ALE.CodeGen.Data;
using Hertzole.ALE.CodeGen.Helpers;
using MessagePack;
using MessagePack.Formatters;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using UnityEngine;
#if ALE_COMPATIBILITY_0
using MessagePack.Internal;
#endif

namespace Hertzole.ALE.CodeGen
{
	public class FormatterProcessor
	{
		private readonly ModuleDefinition module;
		private readonly ResolverProcessor resolver;
		private readonly List<TypeDefinition> standardTypes;

		private readonly List<TypeDefinition> typesToGenerate;
		private readonly Weaver weaver;

		public FormatterProcessor(Weaver weaver, ModuleDefinition moduleDefinition, ResolverProcessor resolverProcessor)
		{
			this.weaver = weaver;
			module = moduleDefinition;
			resolver = resolverProcessor;

			typesToGenerate = new List<TypeDefinition>();
			standardTypes = new List<TypeDefinition>
			{
				module.ImportReference(typeof(byte)).Resolve(),
				module.ImportReference(typeof(sbyte)).Resolve(),
				module.ImportReference(typeof(short)).Resolve(),
				module.ImportReference(typeof(ushort)).Resolve(),
				module.ImportReference(typeof(int)).Resolve(),
				module.ImportReference(typeof(uint)).Resolve(),
				module.ImportReference(typeof(long)).Resolve(),
				module.ImportReference(typeof(ulong)).Resolve(),
				module.ImportReference(typeof(char)).Resolve(),
				module.ImportReference(typeof(string)).Resolve(),
				module.ImportReference(typeof(float)).Resolve(),
				module.ImportReference(typeof(double)).Resolve(),
				module.ImportReference(typeof(decimal)).Resolve(),
				module.ImportReference(typeof(bool)).Resolve(),
				module.ImportReference(typeof(Vector2)).Resolve(),
				module.ImportReference(typeof(Vector2Int)).Resolve(),
				module.ImportReference(typeof(Vector3)).Resolve(),
				module.ImportReference(typeof(Vector3Int)).Resolve(),
				module.ImportReference(typeof(Vector4)).Resolve(),
				module.ImportReference(typeof(Quaternion)).Resolve(),
				module.ImportReference(typeof(Bounds)).Resolve(),
				module.ImportReference(typeof(Rect)).Resolve(),
				module.ImportReference(typeof(Color)).Resolve(),
				module.ImportReference(typeof(Color32)).Resolve(),
				module.ImportReference(typeof(LevelEditorIdentifier)).Resolve()
			};
		}

		public void AddTypeToGenerate(TypeReference type)
		{
			if (type.IsGenericInstance && type is GenericInstanceType genericInstance)
			{
				for (int i = 0; i < genericInstance.GenericArguments.Count; i++)
				{
					AddTypeToGenerate(genericInstance.GenericArguments[i].GetElementType());
				}
			}
			
			var resolved = type.Resolve();
			if (resolved == null)
			{
				return;
			}

			AddTypeFields(resolved);
			
			if (standardTypes.Contains(resolved) || typesToGenerate.Contains(resolved) || resolved.IsCollection() || resolved.IsComponent())
			{
				return;
			}

			if (resolved.IsClass && !resolved.IsValueType && !resolved.IsComponent())
			{
				weaver.Error($"{resolved.FullName} is a normal class and can not be serialized yet. Only structs can be automatically serialized.");
				return;
			}

			typesToGenerate.Add(resolved);
		}

		private void AddTypeFields(TypeDefinition type)
		{
			if (!type.HasFields)
			{
				return;
			}

			for (int i = 0; i < type.Fields.Count; i++)
			{
				if (type.Fields[i].FieldType.IsGenericInstance && type.Fields[i].FieldType is GenericInstanceType genericInstance)
				{
					for (int j = 0; j < genericInstance.GenericArguments.Count; j++)
					{
						TypeReference genericType =genericInstance.GenericArguments[j].GetCollectionType();
						if (genericType != null)
						{
							AddTypeToGenerate(genericType);
						}
					}
				}
			}
		}

		public void EndEditing()
		{
			for (int i = 0; i < typesToGenerate.Count; i++)
			{
				if (typesToGenerate[i].IsEnum())
				{
					resolver.AddEnum(typesToGenerate[i]);
					continue;
				}

				TypeDefinition formatter = CreateFormatterForType(typesToGenerate[i]);
				resolver.AddTypeFormatter(formatter, typesToGenerate[i]);
			}
		}

		private TypeDefinition CreateFormatterForType(TypeDefinition type)
		{
			string name = $"{type.Namespace.Replace('.', '_')}_{type.Name}_Formatter";
			if (name.StartsWith("_"))
			{
				name = name.Substring(1);
			}

			TypeDefinition formatter = new TypeDefinition("Hertzole.ALE.Generated.Formatters", name,
				TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit, module.GetTypeReference<object>());

			formatter.Interfaces.Add(new InterfaceImplementation(module.GetTypeReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(module.ImportReference(type))));
			formatter.Interfaces.Add(new InterfaceImplementation(module.GetTypeReference(typeof(IMessagePackFormatter))));

			module.Types.Add(formatter);

			List<ValueTuple<FieldDefinition, MethodDefinition>> fields = new List<(FieldDefinition, MethodDefinition)>();

			CollectFields();
			formatter.CreateConstructor();
			CreateSerializeMethod();
			CreateDeserializeMethod();

			return formatter;

			void CollectFields()
			{
				for (int i = 0; i < type.Fields.Count; i++)
				{
					// Don't serialize fields with NonSerialized attribute.
					if (type.Fields[i].IsNotSerialized)
					{
						continue;
					}
				
#if ALE_COMPATIBILITY_0
					MethodDefinition nameSpan = FormatterHelper.CreateSpanMethod(module, type.Fields[i].Name, formatter);
					fields.Add((type.Fields[i], nameSpan));
#else
					fields.Add((type.Fields[i], null));
#endif
					if (type.Fields[i].FieldType.IsArray())
					{
						resolver.AddTypeFormatter(module.GetTypeReference(typeof(ArrayFormatter<>)).MakeGenericInstanceType(type.Fields[i].FieldType.GetCollectionType()), type.Fields[i].FieldType);
					}
					else if (type.Fields[i].FieldType.IsList())
					{
						resolver.AddTypeFormatter(module.GetTypeReference(typeof(ListFormatter<>)).MakeGenericInstanceType(type.Fields[i].FieldType.GetCollectionType()), type.Fields[i].FieldType);
					}
					else if (type.Fields[i].FieldType.IsDictionary() && type.Fields[i].FieldType is GenericInstanceType genDic)
					{
						resolver.AddTypeFormatter(module.GetTypeReference(typeof(DictionaryFormatter<,>)).MakeGenericInstanceType(genDic.GenericArguments[0], genDic.GenericArguments[1]), type.Fields[i].FieldType);
					}
				}
			}

			void CreateSerializeMethod()
			{
				MethodDefinition m = new MethodDefinition("Serialize", MethodAttributes.Public | MethodAttributes.Final |
				                                                       MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.Void());

				formatter.Methods.Add(m);

				ParameterDefinition writer = m.AddParameter(module.GetTypeReference(typeof(MessagePackWriter).MakeByRefType()), "writer");
				ParameterDefinition value = m.AddParameter(module.ImportReference(type), "value");
				ParameterDefinition options = m.AddParameter(module.GetTypeReference<MessagePackSerializerOptions>(), "options");

				ILProcessor il = m.BeginEdit();

				m.Body.InitLocals = true;

				bool hasNonStandardType = false;
				for (int i = 0; i < fields.Count; i++)
				{
					if (!FormatterHelper.IsStandardWriteType(fields[i].Item1.FieldType))
					{
						hasNonStandardType = true;
						break;
					}
				}

				if (hasNonStandardType)
				{
					il.Emit(OpCodes.Ldarg_3);
					il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Resolver"));
				}

				il.EmitLdarg(writer);
				il.EmitInt(fields.Count);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackWriter), "WriteArrayHeader", typeof(int)));

				for (int i = 0; i < fields.Count; i++)
				{
					il.EmitLdarg(writer);
					il.EmitInt(fields[i].Item1.Name.GetStableHashCode());
					il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackWriter), "WriteInt32", typeof(int)));
					il.Append(FormatterHelper.GetWriteValue(module, fields[i].Item1.FieldType, fields[i].Item1, IsLastField(i)));
				}

				il.Emit(OpCodes.Ret);

				m.EndEdit();

				bool IsLastField(int index)
				{
					if (index == fields.Count - 1)
					{
						return true;
					}

					for (int i = index + 1; i < fields.Count; i++)
					{
						if (!FormatterHelper.IsStandardWriteType(fields[i].Item1.FieldType))
						{
							return false;
						}
					}

					return true;
				}
			}

			void CreateDeserializeMethod()
			{
				MethodDefinition m = formatter.AddMethod("Deserialize",
					MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.ImportReference(type));

				ParameterDefinition readerPara = m.AddParameter(module.ImportReference(typeof(MessagePackReader).MakeByRefType()), "reader");
				ParameterDefinition optionsPara = m.AddParameter<MessagePackSerializerOptions>("options");

				ILProcessor il = m.BeginEdit();

				m.Body.InitLocals = true;

				il.EmitLdarg(readerPara);
				Instruction readNil = Instruction.Create(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "TryReadNil"));
				il.Append(readNil);

				il.Emit(OpCodes.Ldstr, "typecode is null, struct not supported");
				il.Emit(OpCodes.Newobj, module.GetConstructor<InvalidOperationException>(typeof(string)));
				il.Emit(OpCodes.Throw);

				// options.Security.DepthStep(ref reader)
				Instruction start = il.EmitLdarg(optionsPara);
				il.InsertAfter(readNil, Instruction.Create(OpCodes.Brfalse, start));
				il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Security"));
				il.EmitLdarg(readerPara);
				il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSecurity>("DepthStep"));

				List<VariableDefinition> localFields = new List<VariableDefinition>();

				for (int i = 0; i < fields.Count; i++)
				{
					VariableDefinition v = m.AddLocalVariable(fields[i].Item1.FieldType);
					localFields.Add(v);

					TypeReference fieldType = fields[i].Item1.FieldType;

					if (fieldType.IsValueType && !fieldType.IsPrimitive && !fieldType.IsEnum())
					{
						il.EmitLdloc(v, true);
					}

					il.EmitDefaultValue(fieldType);

					if (!fieldType.IsValueType || fieldType.IsPrimitive || fieldType.IsEnum())
					{
						il.EmitStloc(v);
					}
				}

				Instruction deserializeFormat1 = Instruction.Create(OpCodes.Ldarg_1);
				VariableDefinition result = m.AddLocalVariable(type);
				Instruction createResult = ILHelper.Ldloc(result, true);
				
#if ALE_COMPATIBILITY_0
				VariableDefinition levelEditorOptions = m.AddLocalVariable<LevelEditorSerializerOptions>();
				
				// LevelEditorSerializerOptions levelEditorSerializerOptions = options as LevelEditorSerializerOptions
				il.EmitLdarg(optionsPara);
				il.Emit(OpCodes.Isinst, module.GetTypeReference<LevelEditorSerializerOptions>());
				il.EmitStloc(levelEditorOptions);

				
				// if (levelEditorSerializerOptions != null && levelEditorSerializerOptions.SaveVersion == 0)
				il.EmitLdloc(levelEditorOptions);
				il.Emit(OpCodes.Brfalse, deserializeFormat1);

				il.EmitLdloc(levelEditorOptions);
				il.Emit(OpCodes.Callvirt, module.GetMethod<LevelEditorSerializerOptions>("get_SaveVersion"));
				il.Emit(OpCodes.Brtrue, deserializeFormat1);

				// Create the compatibility method for format 0.
				MethodDefinition deserializeMethod0 = CreateDeserializeMethod0(formatter, fields);
				
				// DeserializeFormat0(ref reader, options, <other parameters>)
				il.EmitLdarg(readerPara);
				il.EmitLdarg(optionsPara);
				for (int i = 0; i < localFields.Count; i++)
				{
					il.EmitLdloc(localFields[i], true);
				}
				
				il.Emit(OpCodes.Call, deserializeMethod0);
				il.Emit(OpCodes.Br, createResult);
#endif

				MethodDefinition deserializeMethod1 = CreateDeserializeMethod1(formatter, fields);
				
				// DeserializeFormat1(ref reader, options, <other parameters>)
				il.Append(deserializeFormat1);
				il.EmitLdarg(optionsPara);
				for (int i = 0; i < localFields.Count; i++)
				{
					il.EmitLdloc(localFields[i], true);
				}
				
				il.Emit(OpCodes.Call, deserializeMethod1);

				VariableDefinition depth = m.AddLocalVariable<int>();
     
                il.Append(createResult);
 				il.Emit(OpCodes.Initobj, module.ImportReference(type));
 				for (int i = 0; i < fields.Count; i++)
 				{
	                il.EmitLdloc(result, true);
	                il.EmitLdloc(localFields[i]);
 					il.Emit(OpCodes.Stfld, module.ImportReference(fields[i].Item1));
                }
     
 				il.EmitLdarg(readerPara);
 				il.Emit(OpCodes.Dup);
 				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "get_Depth"));
 				il.EmitStloc(depth);
 				il.EmitLdloc(depth);
 				il.EmitInt(1);
 				il.Emit(OpCodes.Sub);
 				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "set_Depth"));

                il.EmitLdloc(result);
 				il.Emit(OpCodes.Ret);

                m.EndEdit();
			}
		}

		#if ALE_COMPATIBILITY_0
		private MethodDefinition CreateDeserializeMethod0(TypeDefinition baseType, IReadOnlyList<(FieldDefinition, MethodDefinition)> fields)
		{
			MethodDefinition m = baseType.AddMethod("DeserializeFormat0", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static);
			
			ParameterDefinition reader = m.AddParameter(module.GetTypeReference(typeof(MessagePackReader).MakeByRefType()));
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>();
			
			List<ParameterDefinition> parameters = new List<ParameterDefinition>(fields.Count);
			
			for (int i = 0; i < fields.Count; i++)
			{
				parameters.Add(m.AddParameter(module.ImportReference(fields[i].Item1.FieldType.MakeByReferenceType()), fields[i].Item1.Name));
			}

			VariableDefinition lengthVar = m.AddLocalVariable<int>("length");
			VariableDefinition indexVar = m.AddLocalVariable<int>("i");
			VariableDefinition resolverVar = m.AddLocalVariable<IFormatterResolver>("resolver");
			
			VariableDefinition stringKey = m.AddLocalVariable(module.GetTypeReference(typeof(ReadOnlySpan<byte>)));
			VariableDefinition key = m.AddLocalVariable<ulong>();
			VariableDefinition keyLength = m.AddLocalVariable<int>();

			ILProcessor il = m.BeginEdit();

			// int length = reader.ReadMapHeader()
			il.EmitLdarg(reader);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "ReadMapHeader"));
			il.EmitStloc(lengthVar);
			
			// int i = 0
			il.EmitInt(0);
			il.EmitStloc(indexVar);
			
			// IFormatterResolver resolver = options.Resolver
			il.EmitLdarg(options);
			il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Resolver"));
			il.EmitStloc(resolverVar);
			// il.Emit(OpCodes.Pop);

			// Loop start
			Instruction whileStart = ILHelper.Ldloc(indexVar);
			il.Emit(OpCodes.Br, whileStart);
			
			// ReadOnlySpan<byte> stringKey = CodeGenHelpers.ReadStringSpan(ref reader)
			Instruction loopStart = il.EmitLdarg(reader);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(CodeGenHelpers), "ReadStringSpan", typeof(MessagePackReader).MakeByRefType()));
			il.EmitStloc(stringKey);
			
			// int keyLength = stringKey.Length
			il.EmitLdloc(stringKey, true);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(ReadOnlySpan<byte>), "get_Length"));
			il.EmitStloc(keyLength);

			// ulong key = 0uL
			il.EmitInt(0);
			il.Emit(OpCodes.Conv_I8);
			il.EmitStloc(key);

			// if (keyLength <= 8)
			il.EmitLdloc(keyLength);
			Instruction lengthCheck = il.EmitInt(8); // 8 because if names are longer than 8, it will use the SequenceEquals.
			
			// ulong key = AutomataKeyGen.GetKey(ref stringKey)
			il.EmitLdloc(stringKey, true);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(AutomataKeyGen), "GetKey", typeof(ReadOnlySpan<byte>).MakeByRefType()));
			il.EmitStloc(key);

			Instruction loopEnd = ILHelper.Ldloc(indexVar);

			il.EmitIfElse(fields, (field, index, last, fill) => // If check
			{
				Instruction[] keyCheck = FormatterHelper.GetKeyCheck(m, key, stringKey, keyLength, field.Item1,
					field.Item2, out Instruction lengthLast, out Instruction checkLast, out bool isAdvanced);
			
				fill.AddRange(keyCheck);
				fill.Insert(fill.IndexOf(lengthLast) + 1, Instruction.Create(OpCodes.Bne_Un, last));
				fill.Insert(fill.IndexOf(checkLast) + 1, Instruction.Create(OpCodes.Bne_Un, last));
				
				if (index == 0)
				{
					il.InsertAfter(lengthCheck, Instruction.Create(OpCodes.Bgt, keyCheck[0]));
				}
			}, (field, index, last, fill) => // Body
			{
				fill.AddRange(FormatterHelper.GetReadValue(module, field.Item1.FieldType, il, reader, options, parameters[index], resolverVar));
				fill.Add(Instruction.Create(OpCodes.Br, loopEnd));
			}, fill => // Last
			{
				fill.Add(ILHelper.Ldarg(il, reader));
				fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "Skip")));
			});

			il.Append(loopEnd);
 			il.EmitInt(1);
 			il.Emit(OpCodes.Add);
 			il.EmitStloc(indexVar);

 			il.Append(whileStart);
 			il.EmitLdloc(lengthVar);
 			il.Emit(OpCodes.Blt, loopStart);

            il.Emit(OpCodes.Ret);
			
			m.EndEdit();

			return m;
		}
		#endif

		private MethodDefinition CreateDeserializeMethod1(TypeDefinition baseType, IReadOnlyList<(FieldDefinition, MethodDefinition)> fields)
		{
			MethodDefinition m = baseType.AddMethod("DeserializeFormat1", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static);
			
			ParameterDefinition reader = m.AddParameter(module.GetTypeReference(typeof(MessagePackReader).MakeByRefType()));
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>();
			
			List<ParameterDefinition> parameters = new List<ParameterDefinition>(fields.Count);
			
			for (int i = 0; i < fields.Count; i++)
			{
				parameters.Add(m.AddParameter(fields[i].Item1.FieldType.MakeByReferenceType(), fields[i].Item1.Name));
			}

			VariableDefinition resolverVar = m.AddLocalVariable<IFormatterResolver>("resolver");
			VariableDefinition lengthVar = m.AddLocalVariable<int>("length");
			VariableDefinition indexVar = m.AddLocalVariable<int>("i");
			VariableDefinition hashVar = m.AddLocalVariable<int>("hash");

			ILProcessor il = m.BeginEdit();

			// IFormatterResolver resolver = options.Resolver
			il.EmitLdarg(options);
			il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Resolver"));
			il.EmitStloc(resolverVar);
			
			// int length = reader.ReadArrayHeader()
			il.EmitLdarg(reader);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "ReadArrayHeader"));
			il.EmitStloc(lengthVar);
			
			// int i = 0
			il.EmitInt(0);
			il.EmitStloc(indexVar);

			Instruction whileStart = ILHelper.Ldloc(indexVar);
			il.Emit(OpCodes.Br, whileStart);
			
			// int hash = reader.ReadInt32()
			Instruction loopStart = il.EmitLdarg(reader);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "ReadInt32"));
			il.EmitStloc(hashVar);
			
			Instruction loopEnd = ILHelper.Ldloc(indexVar);

			Instruction[] bodyStarts = new Instruction[fields.Count];

			il.EmitIfElse(fields, (field, i, last, fill) => // If check
			{
				fill.Add(ILHelper.Ldloc(hashVar));
				fill.Add(ILHelper.Int(field.Item1.Name.GetStableHashCode()));
				
				if (field.Item1.TryGetAttributes<FormerlyHashedAsAttribute>(out CustomAttribute[] hashedAttributes))
				{
					fill.Add(Instruction.Create(OpCodes.Beq, bodyStarts[i]));
					
					for (int j = 0; j < hashedAttributes.Length; j++)
					{
						fill.Add(ILHelper.Ldloc(hashVar));
						fill.Add(ILHelper.Int(hashedAttributes[j].GetConstructorArgument(0, string.Empty).GetStableHashCode()));

						if (j == hashedAttributes.Length - 1)
						{
							fill.Add(Instruction.Create(OpCodes.Bne_Un, last));
						}
						else
						{
							fill.Add(Instruction.Create(OpCodes.Beq, bodyStarts[i]));
						}
					}
				}
				else
				{
					fill.Add(Instruction.Create(OpCodes.Bne_Un, last));
				}
			}, (field, i, last, fill) => // Body
			{
				Instruction[] read = FormatterHelper.GetReadValue(module, field.Item1.FieldType, il, reader, options, parameters[i], resolverVar);
				fill.AddRange(read);
				fill.Add(Instruction.Create(OpCodes.Br, loopEnd));

				bodyStarts[i] = read[0];

			}, fill => // Last
			{
				fill.Add(ILHelper.Ldarg(il, reader));
				fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "Skip")));
			});
			
			il.Append(loopEnd);
			il.EmitInt(1);
			il.Emit(OpCodes.Add);
			il.EmitStloc(indexVar);

			il.Append(whileStart);
			il.EmitLdloc(lengthVar);
			il.Emit(OpCodes.Blt, loopStart);

			il.Emit(OpCodes.Ret);
			
			m.EndEdit();
			
			return m;
		}

		public void CreateExposedFormatter(TypeDefinition baseType, IReadOnlyList<IExposedProperty> properties, WrapperData wrapperData)
		{
			string name = $"{baseType.Namespace.Replace('.', '_')}_{baseType.Name}_Formatter";
			if (name.StartsWith("_"))
			{
				name = name.Substring(1);
			}

			TypeDefinition formatter = new TypeDefinition("Hertzole.ALE.Generated.Formatters", name,
				TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit, baseType.Module.GetTypeReference<object>());

			formatter.Interfaces.Add(new InterfaceImplementation(baseType.Module.GetTypeReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(wrapperData.wrapper)));
			formatter.Interfaces.Add(new InterfaceImplementation(baseType.Module.GetTypeReference(typeof(IMessagePackFormatter))));

			baseType.Module.Types.Add(formatter);

			MethodDefinition ctor = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig |
			                                                      MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
				baseType.Module.GetTypeReference(typeof(void)));

			ILProcessor ctorIl = ctor.Body.GetILProcessor();
			ctorIl.Emit(OpCodes.Ldarg_0);
			ctorIl.Emit(OpCodes.Call, baseType.Module.GetConstructor<object>());
			ctorIl.Emit(OpCodes.Ret);

			formatter.Methods.Add(ctor);

			CreateSerializeMethod();
			CreateDeserializeMethod();

			void CreateSerializeMethod()
			{
				var m = formatter.AddMethod("Serialize",
					MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

				ParameterDefinition writer = m.AddParameter(baseType.Module.GetTypeReference(typeof(MessagePackWriter).MakeByRefType()), "writer");
				ParameterDefinition value = m.AddParameter(wrapperData.wrapper, "value");
				ParameterDefinition options = m.AddParameter(baseType.Module.GetTypeReference<MessagePackSerializerOptions>(), "options");

				ILProcessor il = m.BeginEdit();

				m.Body.InitLocals = true;

#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, $"Serializing component {baseType.FullName}");
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

				il.EmitLdarg(writer);
				il.Emit(OpCodes.Ldc_I4, properties.Count * 2);
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(MessagePackWriter), "WriteArrayHeader", typeof(int)));

				MethodReference getResolver = baseType.Module.GetMethod<MessagePackSerializerOptions>("get_Resolver");

				for (int i = 0; i < properties.Count; i++)
				{
					il.EmitLdarg(writer);
					il.EmitLdarg(value);
					il.Emit(OpCodes.Ldfld, wrapperData.wrapper.GetField(properties[i].Name));
					FieldReference item1 = baseType.Module.ImportReference(typeof(ValueTuple<,>).GetField("Item1"));
					item1.DeclaringType = baseType.Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(baseType.Module.GetTypeReference<int>(), properties[i].FieldTypeComponentAware);
					il.Emit(OpCodes.Ldfld, baseType.Module.ImportReference(item1));
					il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(MessagePackWriter), "WriteInt32", typeof(int)));
					
#if ALE_DEBUG
					// LevelEditorLogger.Log
					il.Emit(OpCodes.Ldstr, "Writing value | ID: {0} | Value: {1}");
					il.EmitLdarg(value);
					il.Emit(OpCodes.Ldfld, wrapperData.wrapper.GetField(properties[i].Name));
					il.Emit(OpCodes.Ldfld, item1);
					il.Emit(OpCodes.Box, baseType.Module.GetTypeReference<int>());
					il.EmitLdarg(value);
					FieldReference item2 = baseType.Module.ImportReference(typeof(ValueTuple<,>).GetField("Item2"));
					item2.DeclaringType = baseType.Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(baseType.Module.GetTypeReference<int>(), properties[i].FieldTypeComponentAware);
					il.Emit(OpCodes.Ldfld, wrapperData.wrapper.GetField(properties[i].Name));
					il.Emit(OpCodes.Ldfld, item2);
					if (properties[i].FieldTypeComponentAware.IsValueType)
					{
						il.Emit(OpCodes.Box, properties[i].FieldTypeComponentAware);
					}
					il.Emit(OpCodes.Call, baseType.Module.GetMethod<string>("Format", typeof(string), typeof(object), typeof(object)));
					il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
					
					il.Append(FormatterHelper.GetWriteValue(module, properties[i].FieldTypeComponentAware, wrapperData.wrapper.GetField(properties[i].Name), false, getResolver, true));
				}

#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, $"Finished serializing component {baseType.FullName}");
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

				il.Emit(OpCodes.Ret);

				resolver.AddWrapperFormatter(formatter, wrapperData.wrapper, baseType);

				m.EndEdit();
			}

			void CreateDeserializeMethod()
			{
				var m = formatter.AddMethod("Deserialize",
					MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					wrapperData.wrapper);

				ParameterDefinition reader = m.AddParameter(baseType.Module.GetTypeReference(typeof(MessagePackReader).MakeByRefType()), "reader");
				m.AddParameter(baseType.Module.GetTypeReference<MessagePackSerializerOptions>(), "options");

				MethodReference getResolver = baseType.Module.GetMethod<MessagePackSerializerOptions>("get_Resolver");


				ILProcessor il = m.BeginEdit();
				Instruction dummy = Instruction.Create(OpCodes.Ret);
			
				VariableDefinition lengthVar = m.AddLocalVariable<int>("length");

				m.Body.InitLocals = true;

				il.Emit(OpCodes.Ldarg_2);
				il.Emit(OpCodes.Callvirt, baseType.Module.GetMethod<MessagePackSerializerOptions>("get_Security"));
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Callvirt, baseType.Module.GetMethod<MessagePackSecurity>("DepthStep", typeof(MessagePackReader).MakeByRefType()));
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(MessagePackReader), "ReadArrayHeader"));
				il.EmitStloc(lengthVar);

				VariableDefinition maskVar = m.AddLocalVariable(wrapperData.dirtyMaskType, "dirtyMask");
				il.EmitInt(0);
				il.Emit(OpCodes.Conv_I8);
				il.EmitStloc(maskVar);

				List<VariableDefinition> localFields = new List<VariableDefinition>();

				for (int i = 0; i < properties.Count; i++)
				{
					VariableDefinition v = m.AddLocalVariable(properties[i].FieldTypeComponentAware, properties[i].Name);
					localFields.Add(v);

					if (properties[i].IsValueType && !properties[i].IsPrimitive && !properties[i].IsEnum)
					{
						il.EmitLdloc(v, true);
					}

					il.EmitDefaultValue(properties[i].FieldTypeComponentAware);

					if (!properties[i].IsValueType || properties[i].IsPrimitive || properties[i].IsEnum)
					{
						il.EmitStloc(v);
					}
				}

				VariableDefinition loopIndex = m.AddLocalVariable<int>("loopIndex");
				VariableDefinition idVar = m.AddLocalVariable<int>("id");

				il.EmitInt(0);
				Instruction beforeLoop = il.EmitStloc(loopIndex);

				List<Instruction> readFinishes = new List<Instruction>();

				Instruction loopStart = il.EmitLdloc(loopIndex);
				il.EmitInt(2);
				Instruction remainder = Instruction.Create(OpCodes.Rem);
				il.Append(remainder);

				Instruction previous;
				Instruction[] idRead = FormatterHelper.GetReadValue(module, idVar.VariableType, getResolver);

				il.Append(idRead);

				if (properties.Count > 1)
				{
					il.EmitStloc(idVar);
					if (properties[0].Id == 0)
					{
						previous = il.EmitLdloc(idVar);
					}
					else
					{
						il.EmitLdloc(idVar);
						previous = il.EmitInt(properties[0].Id);
					}
				}
				else
				{
					if (properties[0].Id == 0)
					{
						previous = idRead[idRead.Length - 1];
					}
					else
					{
						previous = il.EmitInt(properties[0].Id);
					}
				}

				if (properties.Count == 1)
				{
					il.Append(FormatterHelper.GetReadValue(module, properties[0].FieldTypeComponentAware, getResolver));
					il.EmitStloc(localFields[0]);
					
					// dirtyMask |= Wrapper.DirtyMask.Value;
					il.EmitLdloc(maskVar);
					il.EmitInt(1 << 0);
					il.Emit(OpCodes.Conv_I8);
					il.Emit(OpCodes.Or);
					Instruction finish = il.EmitStloc(maskVar);
					readFinishes.Add(finish);
				}
				else
				{
					for (int i = 0; i < properties.Count; i++)
					{
						if (i != 0)
						{
							Instruction ifStart = il.EmitLdloc(idVar);
							il.InsertAfter(previous, Instruction.Create(properties[i - 1].Id == 0 ? OpCodes.Brtrue : OpCodes.Bne_Un, ifStart));

							previous = properties[i].Id != 0 ? il.EmitInt(properties[i].Id) : ifStart;
						}

						il.Append(FormatterHelper.GetReadValue(module, properties[i].FieldTypeComponentAware, getResolver));
						il.EmitStloc(localFields[i]);
						
						// dirtyMask |= Wrapper.DirtyMask.Value;
						il.EmitLdloc(maskVar);
						il.EmitInt(1 << i);
						il.Emit(OpCodes.Conv_I8);
						il.Emit(OpCodes.Or);
						Instruction finish = il.EmitStloc(maskVar);
						
						readFinishes.Add(finish);
					}
				}

				Instruction skipStart = il.EmitLdarg(reader);
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(MessagePackReader), "Skip"));

				// Insert jump to skip on last if check.
				il.InsertAfter(previous, Instruction.Create(properties[properties.Count - 1].Id == 0 ? OpCodes.Brtrue : OpCodes.Bne_Un, skipStart));

				Instruction loopFinish = il.EmitLdloc(loopIndex);
				il.EmitInt(1);
				il.Emit(OpCodes.Add);
				il.EmitStloc(loopIndex);

				Instruction loopEnd = il.EmitLdloc(loopIndex);
				il.EmitLdloc(lengthVar);
				il.Emit(OpCodes.Blt, loopStart);

				il.InsertAfter(beforeLoop, Instruction.Create(OpCodes.Br, loopEnd));
				il.InsertAfter(remainder, Instruction.Create(OpCodes.Brtrue, loopFinish));

				for (int i = 0; i < readFinishes.Count; i++)
				{
					il.InsertAfter(readFinishes[i], Instruction.Create(OpCodes.Br, loopFinish));
				}

				VariableDefinition depthVar = m.AddLocalVariable<int>("depth");

				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(MessagePackReader), "get_Depth"));
				il.EmitStloc(depthVar);
				il.EmitLdloc(depthVar);
				il.EmitInt(1);
				il.Emit(OpCodes.Sub);
				il.Emit(OpCodes.Call, baseType.Module.GetMethod(typeof(MessagePackReader), "set_Depth", typeof(int)));
				il.EmitLdloc(maskVar);
				for (int i = 0; i < properties.Count; i++)
				{
					il.EmitLdloc(localFields[i]);
				}

				il.Emit(OpCodes.Newobj, wrapperData.wrapperConstructor);

				il.Emit(OpCodes.Ret);

				m.EndEdit();
			}
		}
	}
}