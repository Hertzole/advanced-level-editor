using System;
using System.Collections.Generic;
using System.Linq;
using Hertzole.ALE.CodeGen.Helpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace Hertzole.ALE.CodeGen
{
	public static partial class WeaverExtensions
	{
		public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				collection.Add(item);
			}
		}

		public static void InsertAfter(this ILProcessor il, Instruction target, IEnumerable<Instruction> instructions)
		{
			Instruction previous = target;

			foreach (Instruction i in instructions)
			{
				il.InsertAfter(previous, i);
				previous = i;
			}
		}

		public static void InsertBefore(this ILProcessor il, Instruction target, IEnumerable<Instruction> instructions)
		{
			Instruction previous = target;

			Instruction[] a = instructions.ToArray();

			for (int i = a.Length - 1; i >= 0; i--)
			{
				il.InsertBefore(previous, a[i]);
				previous = a[i];
			}
		}

		public static void Append(this ILProcessor il, IEnumerable<Instruction> instructions)
		{
			foreach (Instruction i in instructions)
			{
				il.Append(i);
			}
		}

		public static Instruction EmitBool(this ILProcessor il, bool value)
		{
			Instruction i = ILHelper.Bool(value);
			il.Append(i);
			return i;
		}

		public static void EmitBool(this ILProcessor il, bool value, VariableDefinition variable)
		{
			il.EmitBool(value);
			il.EmitStloc(variable);
		}

		public static Instruction EmitStloc(this ILProcessor il, VariableDefinition variable)
		{
			Instruction result = ILHelper.Stloc(variable);
			il.Append(result);
			return result;
		}

		public static Instruction EmitLdloc(this ILProcessor il, VariableDefinition variable, bool ldloc_a = false)
		{
			Instruction result = ILHelper.Ldloc(variable, ldloc_a);
			il.Append(result);
			return result;
		}

		public static Instruction EmitLdarg(this ILProcessor il, ParameterDefinition parameter = null, bool ldarg_a = false)
		{
			Instruction result = ILHelper.Ldarg(il, parameter, ldarg_a);
			il.Append(result);
			return result;
		}

		public static Instruction EmitInt(this ILProcessor il, int value)
		{
			Instruction result = ILHelper.Int(value);
			il.Append(result);
			return result;
		}

		public static void EmitDefaultValue(this ILProcessor il, TypeReference type)
		{
			if (type.Is<bool>() || type.Is<int>() || type.Is<uint>() || type.Is<short>() || type.Is<ushort>() || type.Is<byte>() || type.Is<sbyte>() || type.Is<char>() || type.Resolve() != null && type.Resolve().IsEnum)
			{
				il.Emit(OpCodes.Ldc_I4_0);
			}
			else if (type.Is<long>() || type.Is<ulong>())
			{
				il.Emit(OpCodes.Ldc_I4_0);
				il.Emit(OpCodes.Conv_I8);
			}
			else if (type.Is<float>())
			{
				il.Emit(OpCodes.Ldc_R4, 0.0f);
			}
			else if (type.Is<double>())
			{
				il.Emit(OpCodes.Ldc_R8, 0d);
			}
			else if (type.IsValueType)
			{
				il.Emit(OpCodes.Initobj, type);
			}
			else
			{
				il.Emit(OpCodes.Ldnull);
			}
		}

		public static void EmitSwitch<T>(this ILProcessor il, IList<T> items, Action<T, ILProcessor> buildCase, Action<ILProcessor> buildDefault)
		{
			int startIndex = il.Body.Instructions.Count - 1;

			Instruction[] switchTargets = new Instruction[items.Count];

			for (int i = 0; i < items.Count; i++)
			{
				int startAmount = il.Body.Instructions.Count;
				buildCase(items[i], il);

				switchTargets[i] = il.Body.Instructions[startAmount];
			}

			int defaultIndex = il.Body.Instructions.Count + 1;
			buildDefault(il);

			il.InsertAfter(il.Body.Instructions[startIndex], Instruction.Create(OpCodes.Switch, switchTargets));
			il.InsertAfter(il.Body.Instructions[startIndex + 1], Instruction.Create(OpCodes.Br, il.Body.Instructions[defaultIndex]));
		}
	}
}