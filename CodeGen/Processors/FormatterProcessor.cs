using System;
using System.Collections.Generic;
using System.Data;
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
		private readonly HashSet<TypeReference> standardTypeReferences;

		private readonly HashSet<TypeReference> typesToGenerate;
		private readonly Weaver weaver;

		public FormatterProcessor(Weaver weaver, ModuleDefinition moduleDefinition, ResolverProcessor resolverProcessor)
		{
			this.weaver = weaver;
			module = moduleDefinition;
			resolver = resolverProcessor;

			typesToGenerate = new HashSet<TypeReference>(new TypeReferencerComparer());
			standardTypeReferences = new HashSet<TypeReference>(new TypeReferencerComparer())
			{
				// C# primitives
				module.ImportReference(typeof(byte)),
				module.ImportReference(typeof(sbyte)),
				module.ImportReference(typeof(short)),
				module.ImportReference(typeof(ushort)),
				module.ImportReference(typeof(int)),
				module.ImportReference(typeof(uint)),
				module.ImportReference(typeof(long)),
				module.ImportReference(typeof(ulong)),
				module.ImportReference(typeof(char)),
				module.ImportReference(typeof(string)),
				module.ImportReference(typeof(float)),
				module.ImportReference(typeof(double)),
				module.ImportReference(typeof(decimal)),
				module.ImportReference(typeof(bool)),
				
				// C# primitives + array
				module.ImportReference(typeof(byte[])),
				module.ImportReference(typeof(sbyte[])),
				module.ImportReference(typeof(short[])),
				module.ImportReference(typeof(ushort[])),
				module.ImportReference(typeof(int[])),
				module.ImportReference(typeof(uint[])),
				module.ImportReference(typeof(long[])),
				module.ImportReference(typeof(ulong[])),
				module.ImportReference(typeof(char[])),
				module.ImportReference(typeof(string[])),
				module.ImportReference(typeof(float[])),
				module.ImportReference(typeof(double[])),
				module.ImportReference(typeof(decimal[])),
				module.ImportReference(typeof(bool[])),
				
				// C# primitives + list
				module.ImportReference(typeof(List<byte>)),
				module.ImportReference(typeof(List<sbyte>)),
				module.ImportReference(typeof(List<short>)),
				module.ImportReference(typeof(List<ushort>)),
				module.ImportReference(typeof(List<int>)),
				module.ImportReference(typeof(List<uint>)),
				module.ImportReference(typeof(List<long>)),
				module.ImportReference(typeof(List<ulong>)),
				module.ImportReference(typeof(List<char>)),
				module.ImportReference(typeof(List<string>)),
				module.ImportReference(typeof(List<float>)),
				module.ImportReference(typeof(List<double>)),
				module.ImportReference(typeof(List<decimal>)),
				module.ImportReference(typeof(List<bool>)),
				
				// C# primitives + nullable
				module.ImportReference(typeof(byte?)),
				module.ImportReference(typeof(sbyte?)),
				module.ImportReference(typeof(short?)),
				module.ImportReference(typeof(ushort?)),
				module.ImportReference(typeof(int?)),
				module.ImportReference(typeof(uint?)),
				module.ImportReference(typeof(long?)),
				module.ImportReference(typeof(ulong?)),
				module.ImportReference(typeof(char?)),
				module.ImportReference(typeof(float?)),
				module.ImportReference(typeof(double?)),
				module.ImportReference(typeof(decimal?)),
				module.ImportReference(typeof(bool?)),
				
				// C# primitives + array + nullable
				module.ImportReference(typeof(byte?[])),
				module.ImportReference(typeof(sbyte?[])),
				module.ImportReference(typeof(short?[])),
				module.ImportReference(typeof(ushort?[])),
				module.ImportReference(typeof(int?[])),
				module.ImportReference(typeof(uint?[])),
				module.ImportReference(typeof(long?[])),
				module.ImportReference(typeof(ulong?[])),
				module.ImportReference(typeof(char?[])),
				module.ImportReference(typeof(float?[])),
				module.ImportReference(typeof(double?[])),
				module.ImportReference(typeof(decimal?[])),
				module.ImportReference(typeof(bool?[])),
				
				// C# primitives + list + nullable
				module.ImportReference(typeof(List<byte?>)),
				module.ImportReference(typeof(List<sbyte?>)),
				module.ImportReference(typeof(List<short?>)),
				module.ImportReference(typeof(List<ushort?>)),
				module.ImportReference(typeof(List<int?>)),
				module.ImportReference(typeof(List<uint?>)),
				module.ImportReference(typeof(List<long?>)),
				module.ImportReference(typeof(List<ulong?>)),
				module.ImportReference(typeof(List<char?>)),
				module.ImportReference(typeof(List<string?>)),
				module.ImportReference(typeof(List<float?>)),
				module.ImportReference(typeof(List<double?>)),
				module.ImportReference(typeof(List<decimal?>)),
				module.ImportReference(typeof(List<bool?>)),

				// Unity primitives
				module.ImportReference(typeof(AnimationCurve)),
				module.ImportReference(typeof(Bounds)),
				module.ImportReference(typeof(BoundsInt)),
				module.ImportReference(typeof(Color32)),
				module.ImportReference(typeof(Color)),
				module.ImportReference(typeof(GradientAlphaKey)),
				module.ImportReference(typeof(GradientColorKey)),
				module.ImportReference(typeof(Gradient)),
				module.ImportReference(typeof(Keyframe)),
				module.ImportReference(typeof(LayerMask)),
				module.ImportReference(typeof(Matrix4x4)),
				module.ImportReference(typeof(Quaternion)),
				module.ImportReference(typeof(Rect)),
				module.ImportReference(typeof(RectInt)),
				module.ImportReference(typeof(RectOffset)),
				module.ImportReference(typeof(Vector2)),
				module.ImportReference(typeof(Vector2Int)),
				module.ImportReference(typeof(Vector3)),
				module.ImportReference(typeof(Vector3Int)),
				module.ImportReference(typeof(Vector4)),
				module.ImportReference(typeof(WrapMode)),

				// Unity primitives + array
				module.ImportReference(typeof(AnimationCurve[])),
				module.ImportReference(typeof(Bounds[])),
				module.ImportReference(typeof(BoundsInt[])),
				module.ImportReference(typeof(Color32[])),
				module.ImportReference(typeof(Color[])),
				module.ImportReference(typeof(GradientAlphaKey[])),
				module.ImportReference(typeof(GradientColorKey[])),
				module.ImportReference(typeof(Gradient[])),
				module.ImportReference(typeof(Keyframe[])),
				module.ImportReference(typeof(LayerMask[])),
				module.ImportReference(typeof(Matrix4x4[])),
				module.ImportReference(typeof(Quaternion[])),
				module.ImportReference(typeof(Rect[])),
				module.ImportReference(typeof(RectInt[])),
				module.ImportReference(typeof(RectOffset[])),
				module.ImportReference(typeof(Vector2[])),
				module.ImportReference(typeof(Vector2Int[])),
				module.ImportReference(typeof(Vector3[])),
				module.ImportReference(typeof(Vector3Int[])),
				module.ImportReference(typeof(Vector4[])),
				module.ImportReference(typeof(WrapMode[])),

				// Unity primitives + list
				module.ImportReference(typeof(List<AnimationCurve>)),
				module.ImportReference(typeof(List<Bounds>)),
				module.ImportReference(typeof(List<BoundsInt>)),
				module.ImportReference(typeof(List<Color32>)),
				module.ImportReference(typeof(List<Color>)),
				module.ImportReference(typeof(List<GradientAlphaKey>)),
				module.ImportReference(typeof(List<GradientColorKey>)),
				module.ImportReference(typeof(List<Gradient>)),
				module.ImportReference(typeof(List<Keyframe>)),
				module.ImportReference(typeof(List<LayerMask>)),
				module.ImportReference(typeof(List<Matrix4x4>)),
				module.ImportReference(typeof(List<Quaternion>)),
				module.ImportReference(typeof(List<Rect>)),
				module.ImportReference(typeof(List<RectInt>)),
				module.ImportReference(typeof(List<RectOffset>)),
				module.ImportReference(typeof(List<Vector2>)),
				module.ImportReference(typeof(List<Vector2Int>)),
				module.ImportReference(typeof(List<Vector3>)),
				module.ImportReference(typeof(List<Vector3Int>)),
				module.ImportReference(typeof(List<Vector4>)),
				module.ImportReference(typeof(List<WrapMode>)),

				// Unity primitives + nullable
				module.ImportReference(typeof(Bounds?)),
				module.ImportReference(typeof(BoundsInt?)),
				module.ImportReference(typeof(Color32?)),
				module.ImportReference(typeof(Color?)),
				module.ImportReference(typeof(GradientAlphaKey?)),
				module.ImportReference(typeof(GradientColorKey?)),
				module.ImportReference(typeof(Keyframe?)),
				module.ImportReference(typeof(LayerMask?)),
				module.ImportReference(typeof(Matrix4x4?)),
				module.ImportReference(typeof(Quaternion?)),
				module.ImportReference(typeof(Rect?)),
				module.ImportReference(typeof(RectInt?)),
				module.ImportReference(typeof(Vector2?)),
				module.ImportReference(typeof(Vector2Int?)),
				module.ImportReference(typeof(Vector3?)),
				module.ImportReference(typeof(Vector3Int?)),
				module.ImportReference(typeof(Vector4?)),
				module.ImportReference(typeof(WrapMode?)),

				// Unity primitives + array + nullable
				module.ImportReference(typeof(Bounds?[])),
				module.ImportReference(typeof(BoundsInt?[])),
				module.ImportReference(typeof(Color32?[])),
				module.ImportReference(typeof(Color?[])),
				module.ImportReference(typeof(GradientAlphaKey?[])),
				module.ImportReference(typeof(GradientColorKey?[])),
				module.ImportReference(typeof(Keyframe?[])),
				module.ImportReference(typeof(LayerMask?[])),
				module.ImportReference(typeof(Matrix4x4?[])),
				module.ImportReference(typeof(Quaternion?[])),
				module.ImportReference(typeof(Rect?[])),
				module.ImportReference(typeof(RectInt?[])),
				module.ImportReference(typeof(Vector2?[])),
				module.ImportReference(typeof(Vector2Int?[])),
				module.ImportReference(typeof(Vector3?[])),
				module.ImportReference(typeof(Vector3Int?[])),
				module.ImportReference(typeof(Vector4?[])),
				module.ImportReference(typeof(WrapMode?[])),

				// Unity primitives + list + nullable
				module.ImportReference(typeof(List<Bounds?>)),
				module.ImportReference(typeof(List<BoundsInt?>)),
				module.ImportReference(typeof(List<Color32?>)),
				module.ImportReference(typeof(List<Color?>)),
				module.ImportReference(typeof(List<GradientAlphaKey?>)),
				module.ImportReference(typeof(List<GradientColorKey?>)),
				module.ImportReference(typeof(List<Keyframe?>)),
				module.ImportReference(typeof(List<LayerMask?>)),
				module.ImportReference(typeof(List<Matrix4x4?>)),
				module.ImportReference(typeof(List<Quaternion?>)),
				module.ImportReference(typeof(List<Rect?>)),
				module.ImportReference(typeof(List<RectInt?>)),
				module.ImportReference(typeof(List<Vector2?>)),
				module.ImportReference(typeof(List<Vector2Int?>)),
				module.ImportReference(typeof(List<Vector3?>)),
				module.ImportReference(typeof(List<Vector3Int?>)),
				module.ImportReference(typeof(List<Vector4?>)),
				module.ImportReference(typeof(List<WrapMode?>)),
				
				// ALE types
				module.ImportReference(typeof(LevelEditorIdentifier)),
				
				// ALE types + nullable
				module.ImportReference(typeof(LevelEditorIdentifier?)),
			};
		}

		public void AddTypeToGenerate(TypeReference type)
		{
			if (standardTypeReferences.Contains(type) || type.IsComponent())
			{
				return;
			}

			if (type is GenericInstanceType genericType)
			{
				for (int i = 0; i < genericType.GenericArguments.Count; i++)
				{
					AddTypeToGenerate(genericType.GenericArguments[i].GetCollectionType());
				}

				if (type.IsList())
				{
					typesToGenerate.Add(type);
				}

				return;
			}

			if (type.IsArray())
			{
				typesToGenerate.Add(type);
				AddTypeToGenerate(type.GetCollectionType());
				return;
			}

			TypeDefinition resolved = type.Resolve();
			if (resolved == null || typesToGenerate.Contains(resolved) || resolved.IsCollection() || resolved.IsComponent())
			{
				return;
			}

			if (resolved.IsEnum())
			{
				typesToGenerate.Add(resolved);
				return;
			}
			
			if (resolved.IsClass && !resolved.IsValueType && !resolved.IsComponent())
			{
				weaver.Error($"{resolved.FullName} is a normal class and can not be serialized yet. Only structs can be automatically serialized.");
				return;
			}

			AddTypeFields(resolved);

			typesToGenerate.Add(type);
		}

		private void AddTypeFields(TypeDefinition type)
		{
			if (!type.HasFields)
			{
				return;
			}

			for (int i = 0; i < type.Fields.Count; i++)
			{
				if (type.Fields[i].FieldType is GenericInstanceType genericInstance)
				{
					for (int j = 0; j < genericInstance.GenericArguments.Count; j++)
					{
						TypeReference genericType = genericInstance.GenericArguments[j].GetElementType();
						if (genericType != null)
						{
							AddTypeToGenerate(genericType);
						}
					}
				}
				else
				{
					AddTypeToGenerate(type.Fields[i].FieldType);
				}
			}
		}

		public void EndEditing()
		{
			foreach (TypeReference type in typesToGenerate)
			{
				TypeDefinition resolved = type.Resolve();

				if (resolved != null && resolved.IsEnum())
				{
					resolver.AddEnum(resolved);
					continue;
				}
				
				if (type.IsArray() || type.IsList() || type.IsNullable(out _))
				{
					resolver.AddTypeWithoutFormatter(type);
				}
				else
				{
					if (resolved == null)
					{
						throw new NoNullAllowedException($"Type {type} could not be resolved. This should be checked beforehand!");
					}
					
					TypeDefinition formatter = CreateFormatterForType(resolved);
					if (formatter != null)
					{
						resolver.AddTypeFormatter(formatter, type);
					}
				}
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

					// Ignore private and protected fields.
					if (!type.Fields[i].IsPublic)
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
				il.EmitInt(fields.Count * 2);
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

				VariableDefinition result = m.AddLocalVariable(type);
				
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
			
				Instruction createResult = ILHelper.Ldloc(result, true);
				List<VariableDefinition> localFields = new List<VariableDefinition>();

				if (fields.Count > 0)
				{
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
				}
				else
				{
					// reader.ReadArrayHeader()
					il.EmitLdarg(readerPara);
					il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadArrayHeader)));
					il.Emit(OpCodes.Pop);
				}

				VariableDefinition depth = m.AddLocalVariable<int>();

				il.Append(createResult);
 				il.Emit(OpCodes.Initobj, module.ImportReference(type));
                if (fields.Count > 0)
                {
	                for (int i = 0; i < fields.Count; i++)
	                {
		                il.EmitLdloc(result, true);
		                il.EmitLdloc(localFields[i]);
		                il.Emit(OpCodes.Stfld, module.ImportReference(fields[i].Item1));
	                }
                }
                else
                {
	                il.EmitLdloc(result);
                }

                il.EmitLdarg(readerPara);
 				il.Emit(OpCodes.Dup);
 				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "get_Depth"));
 				il.EmitStloc(depth);
 				il.EmitLdloc(depth);
 				il.EmitInt(1);
 				il.Emit(OpCodes.Sub);
 				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "set_Depth"));

                if (fields.Count > 0)
                {
					il.EmitLdloc(result);
                }
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

			il.EmitIfElse(fields, (field, index, last, body, fill) => // If check
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

			il.EmitIfElse(fields, (field, i, last, body, fill) => // If check
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
			il.EmitInt(2);
			il.Emit(OpCodes.Div);
			il.Emit(OpCodes.Blt, loopStart);

			il.Emit(OpCodes.Ret);
			
			m.EndEdit();
			
			return m;
		}

		public void CreateExposedFormatter(TypeDefinition baseType, IReadOnlyList<IExposedProperty> properties, TypeDefinition wrapper)
		{
			string name = $"{baseType.Namespace.Replace('.', '_')}_{baseType.Name}_Formatter";
			if (name.StartsWith("_"))
			{
				name = name.Substring(1);
			}

			TypeDefinition formatter = new TypeDefinition("Hertzole.ALE.Generated.Formatters", name,
				TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit, baseType.Module.GetTypeReference<object>());

			formatter.Interfaces.Add(new InterfaceImplementation(baseType.Module.GetTypeReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(wrapper)));
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

			CreateWrapperSerializeMethod(formatter, baseType.Module, properties, wrapper);
			CreateWrapperDeserializeMethod(formatter, module, properties, wrapper);

			resolver.AddWrapperFormatter(formatter, wrapper, baseType);
		}

		private static void CreateWrapperSerializeMethod(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, TypeDefinition wrapper)
		{
			var m = type.AddMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

			var paraWriter = m.AddParameter(typeof(MessagePackWriter).MakeByRefType(), "writer");
			var paraValue = m.AddParameter(wrapper, "wrapper");
			var paraOptions = m.AddParameter<MessagePackSerializerOptions>("options");

			var il = m.BeginEdit();

			// writer.WriteArrayHeader(propertyCount)
			il.EmitLdarg(paraWriter);
			il.EmitInt(properties.Count * 2);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackWriter), nameof(MessagePackWriter.WriteArrayHeader), typeof(int)));

			var writeInt = module.GetMethod(typeof(MessagePackWriter), nameof(MessagePackWriter.WriteInt32), typeof(int));
			var serialize = wrapper.GetMethod("Serialize");
			
			for (int i = 0; i < properties.Count; i++)
			{
				// writer.WriteInt32(id)
				il.EmitLdarg(paraWriter);
				il.EmitInt(properties[i].Id);
				il.Emit(OpCodes.Call, writeInt);
				
				// value.Serialize(id, ref writer, options)
				il.EmitLdarg(paraValue, true);
				il.EmitInt(properties[i].Id);
				il.EmitLdarg(paraWriter);
				il.EmitLdarg(paraOptions);
				il.Emit(OpCodes.Call, serialize);
			}

			il.Emit(OpCodes.Ret);
			
			m.EndEdit();
		}

		private static void CreateWrapperDeserializeMethod(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, TypeDefinition wrapper)
		{
			var m = type.AddMethod("Deserialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual, wrapper);

			var paraReader = m.AddParameter(typeof(MessagePackReader).MakeByRefType(), "reader");
			var paraOptions = m.AddParameter<MessagePackSerializerOptions>("options");

			var varLength = m.AddLocalVariable<int>("length");
			var varResult = m.AddLocalVariable(wrapper, "wrapper");
			var varWrapper = m.AddLocalVariable(wrapper);
			var varIndex = m.AddLocalVariable<int>("i");
			var varId = m.AddLocalVariable<int>("id");
			var varDepth = m.AddLocalVariable<int>("depth");

			var il = m.BeginEdit();
			
			il.EmitIfElse((next, fill) =>
			{
				// if (reader.TryReadNil())
				fill.Add(ILHelper.Ldarg(il, paraReader));
				fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.TryReadNil))));
				fill.Add(Instruction.Create(OpCodes.Brfalse, next));
			}, (next, fill) =>
			{
				// throw new InvalidOperationException("typecode is null, struct not supported.")
				fill.Add(Instruction.Create(OpCodes.Ldstr, "typecode is null, struct not supported."));
				fill.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<InvalidOperationException>()));
				fill.Add(Instruction.Create(OpCodes.Throw));
			}, fill =>
			{
				// options.Security.DepthStep(ref reader)
				fill.Add(ILHelper.Ldarg(il, paraOptions));
				fill.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Security")));
				fill.Add(ILHelper.Ldarg(il, paraReader));
				fill.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod<MessagePackSecurity>(nameof(MessagePackSecurity.DepthStep))));
			});

			// int length = reader.ReadArrayHeader()
			il.EmitLdarg(paraReader);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadArrayHeader)));
			il.EmitStloc(varLength);
			
			// Wrapper wrapper = default(Wrapper)
			il.EmitLdloc(varWrapper, true);
			il.Emit(OpCodes.Initobj, wrapper);
			
			// wrapper.Values = new Dictionary<int, object>(count)
			il.EmitLdloc(varWrapper, true);
			il.EmitInt(properties.Count);
			il.Emit(OpCodes.Newobj, module.GetConstructor<Dictionary<int, object>>(typeof(int)));
			il.Emit(OpCodes.Call, wrapper.GetMethod("set_Values"));
			
			// wrapper.Dirty = new Dictionary<int, bool>(count)
			il.EmitLdloc(varWrapper, true);
			il.EmitInt(properties.Count);
			il.Emit(OpCodes.Newobj, module.GetConstructor<Dictionary<int, bool>>(typeof(int)));
			il.Emit(OpCodes.Call, wrapper.GetMethod("set_Dirty"));
			
			// Wrapper result = wrapper
			il.EmitLdloc(varWrapper);
			il.EmitStloc(varResult);
			
			// for(int i = 0; i < length; i++)
			Instruction loopEndier = ILHelper.Ldloc(varIndex);
			il.EmitInt(0);
			il.EmitStloc(varIndex);
			il.Emit(OpCodes.Br, loopEndier);
	
			// Loop start
			Instruction loopStart = il.EmitLdarg(paraReader);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadInt32)));
			il.EmitStloc(varId);

			var getValues = wrapper.GetMethod("get_Values");
			var getDirty = wrapper.GetMethod("get_Dirty");
			var deserialize = wrapper.GetMethod("Deserialize");
			var setValueItem = module.GetMethod<Dictionary<int, object>>("set_Item");
			var setDirtyItem = module.GetMethod<Dictionary<int, bool>>("set_Item");

			Instruction loopEnd = ILHelper.Ldloc(varIndex);

			il.EmitIfElse(properties, (item, index, next, body, fill) =>
			{
				// if (id == <item id>)
				fill.Add(ILHelper.Ldloc(varId));
				
				if (item.Id == 0)
				{
					fill.Add(Instruction.Create(OpCodes.Brtrue, index == properties.Count - 1 ? loopEnd : next));
				}
				else
				{
					fill.Add(ILHelper.Int(item.Id));
					fill.Add(Instruction.Create(OpCodes.Bne_Un, index == properties.Count - 1 ? loopEnd : next));
				}
			}, (item, index, next, fill) =>
			{
				// result.Values[id] = result.Deserialize(id, ref reader, options)
				fill.Add(ILHelper.Ldloc(varResult, true));
				fill.Add(Instruction.Create(OpCodes.Call, getValues));
				fill.Add(ILHelper.Int(item.Id));
				fill.Add(ILHelper.Ldloc(varResult, true));
				fill.Add(ILHelper.Int(item.Id));
				fill.Add(ILHelper.Ldarg(il, paraReader));
				fill.Add(ILHelper.Ldarg(il, paraOptions));
				fill.Add(Instruction.Create(OpCodes.Call, deserialize));
				fill.Add(Instruction.Create(OpCodes.Callvirt, setValueItem));
				
				// result.Dirty[id] = true
				fill.Add(ILHelper.Ldloc(varResult, true));
				fill.Add(Instruction.Create(OpCodes.Call, getDirty));
				fill.Add(ILHelper.Int(item.Id));
				fill.Add(ILHelper.Bool(true));
				fill.Add(Instruction.Create(OpCodes.Callvirt, setDirtyItem));
				
				// continue
				if (index < properties.Count - 1)
				{
					fill.Add(Instruction.Create(OpCodes.Br, loopEnd));
				}
			}, fill =>
			{
				// i++
				fill.Add(loopEnd);
				fill.Add(ILHelper.Int(1));
				fill.Add(Instruction.Create(OpCodes.Add));
				fill.Add(ILHelper.Stloc(varIndex));
				
				// i < length
				fill.Add(loopEndier);
				fill.Add(ILHelper.Ldloc(varLength));
				fill.Add(ILHelper.Int(2));
				fill.Add(Instruction.Create(OpCodes.Div));
				fill.Add(Instruction.Create(OpCodes.Blt, loopStart));
			});

			// reader.Depth--
			il.EmitLdarg(paraReader);
			il.Emit(OpCodes.Dup);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "get_Depth"));
			il.EmitStloc(varDepth);
			il.EmitLdloc(varDepth);
			il.EmitInt(1);
			il.Emit(OpCodes.Sub);
			il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "set_Depth"));
			
			// return result
			il.EmitLdloc(varResult);
			il.Emit(OpCodes.Ret);

			m.EndEdit();
		}
	}
}