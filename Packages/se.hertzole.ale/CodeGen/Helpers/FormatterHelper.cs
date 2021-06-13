using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using FieldAttributes = Mono.Cecil.FieldAttributes;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using TypeAttributes = Mono.Cecil.TypeAttributes;

namespace Hertzole.ALE.CodeGen.Helpers
{
	public static class FormatterHelper
	{
		private static readonly Encoding utf8 = new UTF8Encoding(false);

		private static readonly Dictionary<TypeDefinition, Dictionary<int, TypeDefinition>> spanCustomTypes = new Dictionary<TypeDefinition, Dictionary<int, TypeDefinition>>();

		// https://github.com/neuecc/MessagePack-CSharp/blob/master/src/MessagePack.GeneratorCore/Generator/StringKey/EmbedStringHelper.cs#L77
		private static byte[] GetEncodedStringBytes(string value)
		{
			int byteCount = utf8.GetByteCount(value);
			int headerLength = GetHeaderLength(byteCount);
			byte[] bytes = new byte[headerLength + byteCount];
			EmbedHeader(byteCount, bytes);
			utf8.GetBytes(value, 0, value.Length, bytes, headerLength);
			return bytes;
		}

		public static ulong GetKeyName(string name)
		{
			byte[] binary = utf8.GetBytes(name);
			ReadOnlySpan<byte> span = binary;
			int keyLength = binary.Length >> 3;
			keyLength += keyLength << 3 == binary.Length ? 0 : 1;
			ulong[] k = new ulong[keyLength];
			for (int j = 0; j < k.Length; j++)
			{
				k[j] = AutomataKeyGen.GetKey(ref span);
			}

			return k[0];
		}

		private static int GetHeaderLength(int byteCount)
		{
			if (byteCount <= 31)
			{
				return 1;
			}

			if (byteCount <= byte.MaxValue)
			{
				return 2;
			}

			return byteCount <= ushort.MaxValue ? 3 : 5;
		}

		private static void EmbedHeader(int byteCount, Span<byte> destination)
		{
			if (byteCount <= 31)
			{
				destination[0] = (byte) (0xa0 | byteCount);
				return;
			}

			if (byteCount <= byte.MaxValue)
			{
				destination[0] = 0xd9;
				destination[1] = unchecked((byte) byteCount);
				return;
			}

			if (byteCount <= ushort.MaxValue)
			{
				destination[0] = 0xda;
				destination[1] = unchecked((byte) (byteCount >> 8));
				destination[2] = unchecked((byte) byteCount);
				return;
			}

			destination[0] = 0xdb;
			destination[1] = unchecked((byte) (byteCount >> 24));
			destination[2] = unchecked((byte) (byteCount >> 16));
			destination[3] = unchecked((byte) (byteCount >> 8));
			destination[4] = unchecked((byte) byteCount);
		}

		public static MethodDefinition CreateSpanMethod(ModuleDefinition module, string name, TypeDefinition type)
		{
			TypeReference span = module.ImportReference(typeof(ReadOnlySpan<byte>));

			MethodDefinition m = new MethodDefinition($"GetSpan_{name}__Generated", MethodAttributes.Private | MethodAttributes.Static, span);

			ILProcessor il = m.Body.GetILProcessor();

			FieldDefinition spanField = new FieldDefinition($"Span__{name}__Generated__{type.Name}",
				FieldAttributes.Assembly | FieldAttributes.Static | FieldAttributes.InitOnly | FieldAttributes.HasFieldRVA,
				GetSpanType(name.Length + 1))
			{
				InitialValue = GetEncodedStringBytes(name)
			};

			type.Fields.Add(spanField);

			il.Emit(OpCodes.Ldsflda, spanField);
			il.EmitInt(name.Length + 1);
			il.Emit(OpCodes.Newobj, module.ImportReference(typeof(ReadOnlySpan<byte>).GetConstructor(new[] { typeof(void*), typeof(int) })));
			il.Emit(OpCodes.Ret);

			m.Body.Optimize();

			type.Methods.Add(m);

			TypeReference GetSpanType(int nameLength)
			{
				switch (nameLength)
				{
					case 2:
						return module.GetTypeReference<short>();
					case 4:
						return module.GetTypeReference<int>();
					case 8:
						return module.GetTypeReference<long>();
					default:
						if (spanCustomTypes.TryGetValue(type, out Dictionary<int, TypeDefinition> d) && d.TryGetValue(nameLength, out TypeDefinition customSpanType))
						{
							return module.ImportReference(customSpanType);
						}

						customSpanType = new TypeDefinition("", $"ALE__Generated__StaticArrayInitTypeSize={nameLength}",
							TypeAttributes.NestedPrivate | TypeAttributes.AnsiClass | TypeAttributes.ExplicitLayout | TypeAttributes.Sealed,
							module.GetTypeReference<ValueType>());

						customSpanType.PackingSize = 1;
						customSpanType.ClassSize = nameLength;
						if (!spanCustomTypes.ContainsKey(type))
						{
							spanCustomTypes.Add(type, new Dictionary<int, TypeDefinition>());
						}

						if (!spanCustomTypes[type].ContainsKey(nameLength))
						{
							spanCustomTypes[type].Add(nameLength, customSpanType);
						}

						type.NestedTypes.Add(customSpanType);
						return module.ImportReference(customSpanType);
				}
			}

			return m;
		}

		public static bool IsStandardWriteType(TypeReference type)
		{
			return type.Is<byte>() | type.Is<sbyte>() | type.Is<short>() | type.Is<ushort>() | type.Is<int>() | type.Is<uint>() | type.Is<long>() | type.Is<ulong>();
		}

		public static Instruction[] GetKeyCheck(MethodDefinition method,
			VariableDefinition key,
			VariableDefinition stringKey,
			VariableDefinition keyLength,
			FieldDefinition field,
			MethodDefinition fieldSpan,
			out Instruction lengthLast,
			out Instruction checkLast,
			out bool isAdvanced)
		{
			Span<byte> binary = utf8.GetBytes(field.Name).AsSpan();
			switch (binary.Length)
			{
				case 1:
					//TODO: Handle single
					isAdvanced = false;
					lengthLast = null;
					checkLast = null;
					return Array.Empty<Instruction>();
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
					isAdvanced = false;
					return ByteKeyNameCheck(out lengthLast, out checkLast);
				default:
					isAdvanced = true;
					return SequenceEqualsCheck(binary.Length, out lengthLast, out checkLast);
			}

			Instruction[] ByteKeyNameCheck(out Instruction length, out Instruction check)
			{
				ulong id = GetKeyName(field.Name);

				List<Instruction> i = new List<Instruction>
				{
					ILHelper.Ldloc(keyLength)
				};

				length = ILHelper.Int(field.Name.Length);
				i.Add(length);

				i.Add(ILHelper.Ldloc(key));
				i.Add(ILHelper.ULong(id));

				if (id < int.MaxValue)
				{
					i.Add(Instruction.Create(OpCodes.Conv_I8));
				}

				check = i[i.Count - 1];

				return i.ToArray();
			}

			Instruction[] SequenceEqualsCheck(int binaryLength, out Instruction length, out Instruction last)
			{
				VariableDefinition v = method.AddLocalVariable(method.Module.ImportReference(typeof(ReadOnlySpan<byte>)));

				MethodReference seqEqual = null;

				MethodInfo[] methods = typeof(MemoryExtensions).GetMethods();
				for (int j = 0; j < methods.Length; j++)
				{
					if (methods[j].Name == "SequenceEqual")
					{
						ParameterInfo[] para = methods[j].GetParameters();
						if (para.Length == 2 && IsSameType(para[0].ParameterType, typeof(ReadOnlySpan<>)) && IsSameType(para[1].ParameterType, typeof(ReadOnlySpan<>)))
						{
							Console.WriteLine($"FOUND RIGHT METHOD {methods[j]} {para[0].ParameterType.Namespace}.{para[0].ParameterType.Name} == {typeof(Span<>).FullName} = {para[0].ParameterType.FullName == typeof(Span<>).FullName}!");
							seqEqual = method.Module.ImportReference(methods[j]).MakeGenericMethod(method.Module.GetTypeReference<byte>());
							break;
						}
					}
				}

				if (seqEqual == null)
				{
					throw new NullReferenceException("Couldn't find the sequence equals method.");
				}

				List<Instruction> i = new List<Instruction>
				{
					ILHelper.Ldloc(keyLength)
				};

				length = ILHelper.Int(field.Name.Length);
				i.Add(length);

				i.Add(ILHelper.Ldloc(stringKey));
				i.Add(Instruction.Create(OpCodes.Call, fieldSpan));
				i.Add(ILHelper.Stloc(v));
				i.Add(ILHelper.Ldloc(v, true));
				i.Add(ILHelper.Int(GetHeaderLength(binaryLength)));
				i.Add(Instruction.Create(OpCodes.Call, method.Module.ImportReference(typeof(ReadOnlySpan<byte>).GetMethod("Slice", new[] { typeof(int) }))));
				i.Add(Instruction.Create(OpCodes.Call, seqEqual));

				last = i[i.Count - 1];

				return i.ToArray();

				bool IsSameType(Type typeA, Type typeB)
				{
					return $"{typeA.Namespace}.{typeA.Name}" == typeB.FullName;
				}
			}
		}

		public static Instruction[] GetWriteValue(TypeReference type, FieldDefinition field, bool isLastField, MethodReference getResolver = null, bool isComponentFormatter = false)
		{
			ModuleDefinition module = type.Module;

			List<Instruction> ins = new List<Instruction>();

			bool isStandard = IsStandardWriteType(type);

			if (!isStandard)
			{
				if (getResolver != null)
				{
					ins.Add(Instruction.Create(OpCodes.Ldarg_3));
					ins.Add(Instruction.Create(OpCodes.Callvirt, getResolver));
					ins.Add(Instruction.Create(OpCodes.Call, module.ImportReference(typeof(FormatterResolverExtensions).GetMethod("GetFormatterWithVerify")).MakeGenericMethod(type)));
				}
				else
				{
					if (!isLastField)
					{
						ins.Add(Instruction.Create(OpCodes.Dup));
					}

					ins.Add(Instruction.Create(OpCodes.Call, module.ImportReference(typeof(FormatterResolverExtensions).GetMethod("GetFormatterWithVerify")).MakeGenericMethod(type)));
				}
			}

			ins.Add(Instruction.Create(OpCodes.Ldarg_1));
			ins.Add(Instruction.Create(OpCodes.Ldarg_2));
			ins.Add(Instruction.Create(OpCodes.Ldfld, field));
			if (isComponentFormatter)
			{
				FieldReference item2 = module.ImportReference(typeof(ValueTuple<,>).GetField("Item2"));
				item2.DeclaringType = module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(module.GetTypeReference<int>(), type);
				ins.Add(Instruction.Create(OpCodes.Ldfld, item2));
			}

			MethodReference writeMethod;

			if (type.Is<byte>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt8", typeof(byte));
			}
			else if (type.Is<sbyte>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt8", typeof(sbyte));
			}
			else if (type.Is<short>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt16", typeof(short));
			}
			else if (type.Is<ushort>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt16", typeof(ushort));
			}
			else if (type.Is<int>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt32", typeof(int));
			}
			else if (type.Is<uint>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt32", typeof(uint));
			}
			else if (type.Is<long>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt64", typeof(long));
			}
			else if (type.Is<ulong>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt64", typeof(ulong));
			}
			else
			{
				if (type.Is<float>())
				{
					ins.Add(Instruction.Create(OpCodes.Conv_R4));
				}
				else if (type.Is<double>())
				{
					ins.Add(Instruction.Create(OpCodes.Conv_R8));
				}

				ins.Add(Instruction.Create(OpCodes.Ldarg_3));
				writeMethod = module.ImportReference(typeof(IMessagePackFormatter<>).GetMethod("Serialize")).MakeHostInstanceGeneric(module.ImportReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(type));
			}

			ins.Add(Instruction.Create(isStandard ? OpCodes.Call : OpCodes.Callvirt, writeMethod));

			return ins.ToArray();
		}

		public static Instruction GetWriteStandardValue(TypeReference type, ModuleDefinition module)
		{
			MethodReference writeMethod;

			if (type.Is<byte>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt8", typeof(byte));
			}
			else if (type.Is<sbyte>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt8", typeof(sbyte));
			}
			else if (type.Is<short>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt16", typeof(short));
			}
			else if (type.Is<ushort>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt16", typeof(ushort));
			}
			else if (type.Is<int>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt32", typeof(int));
			}
			else if (type.Is<uint>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt32", typeof(uint));
			}
			else if (type.Is<long>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteInt64", typeof(long));
			}
			else if (type.Is<ulong>())
			{
				writeMethod = module.GetMethod(typeof(MessagePackWriter), "WriteUInt64", typeof(ulong));
			}
			else
			{
				throw new NotSupportedException($"{type.FullName} is not a standard type.");
			}

			return Instruction.Create(OpCodes.Call, writeMethod);
		}

		public static bool IsStandardReadType(TypeReference type)
		{
			return type.Is<byte>() | type.Is<sbyte>() | type.Is<short>() | type.Is<ushort>() | type.Is<int>() | type.Is<uint>() | type.Is<long>() | type.Is<ulong>() |
			       type.Is<string>() | type.Is<char>() | type.Is<bool>() | type.Is<float>() | type.Is<double>();
		}

		public static Instruction[] GetReadValue(TypeReference type, MethodReference getResolver = null, VariableDefinition resolverVariable = null)
		{
			ModuleDefinition module = type.Module;

			List<Instruction> ins = new List<Instruction>();

			bool isStandard = IsStandardReadType(type);

			if (!isStandard)
			{
				if (getResolver != null)
				{
					ins.Add(Instruction.Create(OpCodes.Ldarg_2));
					ins.Add(Instruction.Create(OpCodes.Callvirt, getResolver));
					ins.Add(Instruction.Create(OpCodes.Call, module.ImportReference(typeof(FormatterResolverExtensions).GetMethod("GetFormatterWithVerify")).MakeGenericMethod(type)));
				}
				else
				{
					if (resolverVariable == null)
					{
						throw new ArgumentNullException(nameof(resolverVariable), "If you don't provide a getResolver call, you'll need to provide a resolver variable.");
					}

					ins.Add(ILHelper.Ldloc(resolverVariable));
					ins.Add(Instruction.Create(OpCodes.Call, module.ImportReference(typeof(FormatterResolverExtensions).GetMethod("GetFormatterWithVerify")).MakeGenericMethod(type)));
				}
			}
			else
			{
				ins.Add(Instruction.Create(OpCodes.Ldarg_1));
			}

			MethodReference readMethod;

			if (type.Is<byte>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadByte));
			}
			else if (type.Is<sbyte>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadSByte));
			}
			else if (type.Is<short>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadInt16));
			}
			else if (type.Is<ushort>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadUInt16));
			}
			else if (type.Is<int>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadInt32));
			}
			else if (type.Is<uint>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadUInt32));
			}
			else if (type.Is<long>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadInt64));
			}
			else if (type.Is<ulong>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadUInt64));
			}
			else if (type.Is<string>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadString));
			}
			else if (type.Is<char>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadChar));
			}
			else if (type.Is<bool>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadBoolean));
			}
			else if (type.Is<float>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadSingle));
			}
			else if (type.Is<double>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadDouble));
			}
			else
			{
				ins.Add(Instruction.Create(OpCodes.Ldarg_1));
				ins.Add(Instruction.Create(OpCodes.Ldarg_2));
				readMethod = module.ImportReference(typeof(IMessagePackFormatter<>).GetMethod("Deserialize")).MakeHostInstanceGeneric(module.ImportReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(type));
			}

			ins.Add(Instruction.Create(isStandard ? OpCodes.Call : OpCodes.Callvirt, readMethod));

			return ins.ToArray();
		}

		public static Instruction GetReadStandardValue(TypeReference type, ModuleDefinition module)
		{
			MethodReference readMethod;

			if (type.Is<byte>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadByte));
			}
			else if (type.Is<sbyte>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadSByte));
			}
			else if (type.Is<short>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadInt16));
			}
			else if (type.Is<ushort>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadUInt16));
			}
			else if (type.Is<int>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadInt32));
			}
			else if (type.Is<uint>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadUInt32));
			}
			else if (type.Is<long>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadInt64));
			}
			else if (type.Is<ulong>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadUInt64));
			}
			else if (type.Is<string>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadString));
			}
			else if (type.Is<char>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadChar));
			}
			else if (type.Is<bool>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadBoolean));
			}
			else if (type.Is<float>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadSingle));
			}
			else if (type.Is<double>())
			{
				readMethod = module.GetMethod(typeof(MessagePackReader), nameof(MessagePackReader.ReadDouble));
			}
			else
			{
				throw new NotSupportedException($"{type.FullName} is not a standard type.");
			}

			return Instruction.Create(OpCodes.Call, readMethod);
		}
	}
}