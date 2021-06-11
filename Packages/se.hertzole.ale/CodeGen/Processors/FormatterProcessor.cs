using System;
using System.Collections.Generic;
using Hertzole.ALE.CodeGen.Helpers;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Mono.Collections.Generic;
using UnityEngine;

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
				module.ImportReference(typeof(Color32)).Resolve()
			};
		}

		public void AddTypeToGenerate(TypeDefinition type)
		{
			if (standardTypes.Contains(type) || typesToGenerate.Contains(type) || type.IsCollection() || type.IsComponent())
			{
				return;
			}

			if (type.IsClass && !type.IsValueType && !type.IsComponent())
			{
				weaver.Error($"{type.FullName} is a normal class and can not be serialized yet. Only structs can be automatically serialized.");
			}

			typesToGenerate.Add(type);
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

			formatter.Interfaces.Add(new InterfaceImplementation(module.GetTypeReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(type)));
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
				
					MethodDefinition nameSpan = FormatterHelper.CreateSpanMethod(module, type.Fields[i].Name, formatter);
					fields.Add((type.Fields[i], nameSpan));
				}
			}

			void CreateSerializeMethod()
			{
				MethodDefinition m = new MethodDefinition("Serialize", MethodAttributes.Public | MethodAttributes.Final |
				                                                       MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.Void());

				formatter.Methods.Add(m);

				m.AddParameter(module.GetTypeReference(typeof(MessagePackWriter).MakeByRefType()), "writer");
				m.AddParameter(module.ImportReference(type), "value");
				m.AddParameter(module.GetTypeReference<MessagePackSerializerOptions>(), "options");

				ILProcessor il = m.Body.GetILProcessor();

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

				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Ldc_I4, fields.Count);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackWriter), "WriteMapHeader", typeof(int)));

				for (int i = 0; i < fields.Count; i++)
				{
#if ALE_DEBUG
					VariableDefinition spanV = m.AddLocalVariable(module.GetTypeReference(typeof(ReadOnlySpan<byte>)));
					il.Emit(OpCodes.Call, fields[i].Item2);
					il.EmitStloc(spanV);
					il.Emit(OpCodes.Ldstr, $"{formatter.Name} writing {fields[i].Item1.Name} | Key: {{0}} | Bytes: {{1}}");
					il.EmitLdloc(spanV, true);
					il.Emit(OpCodes.Call, module.GetMethod(typeof(AutomataKeyGen), "GetKey", typeof(ReadOnlySpan<byte>).MakeByRefType()));
					il.Emit(OpCodes.Box, module.GetTypeReference<ulong>());
					il.EmitLdloc(spanV);

					MethodReference debugString = null;
					Collection<MethodDefinition> methods = module.GetTypeReference(typeof(LevelEditorExtensions)).Resolve().Methods;
					for (int j = 0; j < methods.Count; j++)
					{
						if (methods[j].Name == "ToDebugString" && methods[j].Parameters[0].ParameterType.Resolve().Is(typeof(ReadOnlySpan<>)))
						{
							debugString = module.ImportReference(methods[j].MakeGenericMethod(module.GetTypeReference<byte>()));
							break;
						}
					}

					il.Emit(OpCodes.Call, debugString);
					il.Emit(OpCodes.Call, module.GetMethod<string>("Format", typeof(string), typeof(object), typeof(object)));
					il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

					il.Emit(OpCodes.Ldarg_1);
					il.Emit(OpCodes.Call, fields[i].Item2);
					il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackWriter), "WriteRaw", typeof(ReadOnlySpan<byte>)));
					il.Append(FormatterHelper.GetWriteValue(fields[i].Item1.FieldType, fields[i].Item1, IsLastField(i)));
				}

				il.Emit(OpCodes.Ret);

				m.Body.Optimize();

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
				MethodDefinition m = new MethodDefinition("Deserialize",
					MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					type);

				formatter.Methods.Add(m);

				ParameterDefinition readerPara = m.AddParameter(module.ImportReference(typeof(MessagePackReader).MakeByRefType()), "reader");
				ParameterDefinition optionsPara = m.AddParameter<MessagePackSerializerOptions>("options");

				ILProcessor il = m.Body.GetILProcessor();

				m.Body.InitLocals = true;

				VariableDefinition resolverVar = m.AddLocalVariable<IFormatterResolver>();
				VariableDefinition length = m.AddLocalVariable<int>();
				VariableDefinition iVar = m.AddLocalVariable<int>();

				il.Emit(OpCodes.Ldarg_1);
				Instruction readNil = Instruction.Create(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "TryReadNil"));
				il.Append(readNil);

				il.Emit(OpCodes.Ldstr, "typecode is null, struct not supported");
				il.Emit(OpCodes.Newobj, module.GetConstructor<InvalidOperationException>(typeof(string)));
				il.Emit(OpCodes.Throw);

				Instruction start = il.EmitLdarg(optionsPara);
				il.InsertAfter(readNil, Instruction.Create(OpCodes.Brfalse, start));
				il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Security"));
				il.EmitLdarg(readerPara);
				il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSecurity>("DepthStep"));
				il.EmitLdarg(optionsPara);
				il.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Resolver"));
				il.EmitStloc(resolverVar);
				il.EmitLdarg(readerPara);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "ReadMapHeader"));
				il.EmitStloc(length);

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

				il.EmitInt(0);
				Instruction beforeLoop = il.EmitStloc(iVar);

				VariableDefinition stringKey = m.AddLocalVariable(module.GetTypeReference(typeof(ReadOnlySpan<byte>)));
				VariableDefinition key = m.AddLocalVariable<ulong>();
				VariableDefinition keyLength = m.AddLocalVariable<int>();

				// ReadOnlySpan<byte> stringKey = CodeGenHelpers.ReadStringSpan(ref reader);
				Instruction loopStart = il.EmitLdarg(readerPara);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(CodeGenHelpers), "ReadStringSpan", typeof(MessagePackReader).MakeByRefType()));
				il.EmitStloc(stringKey);

#if ALE_DEBUG
				// LevelEditorLogger.Log($"Reading loop {i} {stringKey.Slice(1).ToDebugString()}");
				il.Emit(OpCodes.Ldstr, "Reading loop {0} | String key: {1}");
				il.EmitLdloc(iVar);
				il.Emit(OpCodes.Box, module.ImportReference(iVar.VariableType));
				il.EmitLdloc(stringKey);

				MethodReference debugString = null;
				Collection<MethodDefinition> methods = module.GetTypeReference(typeof(LevelEditorExtensions)).Resolve().Methods;
				for (int j = 0; j < methods.Count; j++)
				{
					if (methods[j].Name == "ToDebugString" && methods[j].Parameters[0].ParameterType.Resolve().Is(typeof(ReadOnlySpan<>)))
					{
						debugString = module.ImportReference(methods[j].MakeGenericMethod(module.GetTypeReference<byte>()));
						break;
					}
				}

				il.Emit(OpCodes.Call, debugString);
				il.Emit(OpCodes.Call, module.GetMethod<string>("Format", typeof(string), typeof(object), typeof(object)));
				il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

				// int keyLength = stringKey.Length;
				il.EmitLdloc(stringKey, true);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(ReadOnlySpan<byte>), "get_Length"));
				il.EmitStloc(keyLength);

				// ulong key = 0uL;
				il.EmitInt(0);
				il.Emit(OpCodes.Conv_I8);
				il.EmitStloc(key);

				// if (keyLength <= 8)
				il.EmitLdloc(keyLength);
				Instruction lengthCheck = il.EmitInt(8); // 8 because if names are longer than 8, it will use the SequenceEquals.

				// ulong key = AutomataKeyGen.GetKey(ref stringKey);
				il.EmitLdloc(stringKey, true);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(AutomataKeyGen), "GetKey", typeof(ReadOnlySpan<byte>).MakeByRefType()));
				il.EmitStloc(key);

				List<Instruction> previous = new List<Instruction>();
				List<Instruction> ifBreaks = new List<Instruction>();

				bool wasAdvanced = false;

				for (int i = 0; i < fields.Count; i++)
				{
					Instruction[] keyCheck = FormatterHelper.GetKeyCheck(m, key, stringKey, keyLength, fields[i].Item1,
						fields[i].Item2, out Instruction lengthLast, out Instruction checkLast, out bool isAdvanced);

					if (previous.Count > 0)
					{
						if (previous.Count == 2)
						{
							il.InsertAfter(previous[0], Instruction.Create(OpCodes.Bne_Un, keyCheck[0])); // Length check
							il.InsertAfter(previous[1], Instruction.Create(wasAdvanced ? OpCodes.Brfalse : OpCodes.Bne_Un, keyCheck[0])); // Key check
						}
						else
						{
							throw new NotSupportedException($"Unknown amount of previous ({previous.Count})");
						}
					}

					wasAdvanced = isAdvanced;

					il.Append(keyCheck);

					if (i == 0)
					{
						il.InsertAfter(lengthCheck, Instruction.Create(OpCodes.Bgt, keyCheck[0]));
					}

					previous.Clear();

					previous.Add(lengthLast);
					previous.Add(checkLast);

#if ALE_DEBUG
					il.Emit(OpCodes.Ldstr, $"Reading value {fields[i].Item1.Name}");
					il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

					Instruction[] readMethod = FormatterHelper.GetReadValue(fields[i].Item1.FieldType, resolverVariable: resolverVar);
					il.Append(readMethod);
					Instruction finish = il.EmitStloc(localFields[i]);
					ifBreaks.Add(finish);
				}

#if ALE_DEBUG
				Instruction skipStart = Instruction.Create(OpCodes.Ldstr, "Skipping :: Span length: {0} Key: {1}");
				il.Append(skipStart);
				il.EmitLdloc(stringKey, true);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(ReadOnlySpan<byte>), "get_Length"));
				il.Emit(OpCodes.Box, module.GetTypeReference<int>());
				il.EmitLdloc(key);
				il.Emit(OpCodes.Box, module.GetTypeReference<ulong>());
				il.Emit(OpCodes.Call, module.GetMethod<string>("Format", typeof(string), typeof(object), typeof(object)));
				il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
				il.EmitLdarg(readerPara);
#else
				Instruction skipStart = il.EmitLdarg(readerPara);
#endif
				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "Skip"));
				if (previous.Count == 2)
				{
					il.InsertAfter(previous[0], Instruction.Create(OpCodes.Bne_Un, skipStart)); // Length check
					il.InsertAfter(previous[1], Instruction.Create(wasAdvanced ? OpCodes.Brfalse : OpCodes.Bne_Un, skipStart)); // Key check
				}
				else
				{
					throw new NotSupportedException($"Unknown amount of previous when going to skip. ({previous.Count})");
				}

				Instruction loopEnd = il.EmitLdloc(iVar);
				il.EmitInt(1);
				il.Emit(OpCodes.Add);
				il.EmitStloc(iVar);

				Instruction loopFinish = il.EmitLdloc(iVar);
				il.EmitLdloc(length);
				il.Emit(OpCodes.Blt, loopStart);

				il.InsertAfter(beforeLoop, Instruction.Create(OpCodes.Br, loopFinish));
				for (int i = 0; i < ifBreaks.Count; i++)
				{
					il.InsertAfter(ifBreaks[i], Instruction.Create(OpCodes.Br, loopEnd));
				}

				VariableDefinition result = m.AddLocalVariable(type);
				VariableDefinition depth = m.AddLocalVariable<int>();

				il.EmitLdloc(result, true);
				il.Emit(OpCodes.Initobj, type);
				il.EmitLdloc(result, true);
				for (int i = 0; i < fields.Count; i++)
				{
					il.EmitLdloc(localFields[i]);
					il.Emit(OpCodes.Stfld, fields[i].Item1);
					il.EmitLdloc(result, i < fields.Count - 1);
				}

				il.EmitLdarg(readerPara);
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "get_Depth"));
				il.EmitStloc(depth);
				il.EmitLdloc(depth);
				il.EmitInt(1);
				il.Emit(OpCodes.Sub);
				il.Emit(OpCodes.Call, module.GetMethod(typeof(MessagePackReader), "set_Depth"));

				il.Emit(OpCodes.Ret);

				m.SetVariableName(resolverVar, "resolver");
				m.SetVariableName(length, "length");
				m.SetVariableName(iVar, "i");
				m.SetVariableName(stringKey, "stringKey");
				m.SetVariableName(key, "key");
				m.SetVariableName(result, "result");
				m.SetVariableName(depth, "depth");

				for (int i = 0; i < localFields.Count; i++)
				{
					m.SetVariableName(localFields[i], $"__{fields[i].Item1.Name}__");
				}

				m.Body.Optimize();
			}
		}
	}
}