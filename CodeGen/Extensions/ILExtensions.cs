using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using System.Collections.Generic;
using System.Linq;

namespace Hertzole.ALE.Editor
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

        public static Instruction EmitBoolean(this ILProcessor il, bool value)
        {
            Instruction i = Instruction.Create(value ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
            il.Append(i);

            return i;
        }

        public static Instruction[] EmitBoolean(this ILProcessor il, bool value, VariableDefinition variable, int variableIndex)
        {
            Instruction b = EmitBoolean(il, value);
            Instruction stloc = EmitStloc(il, variableIndex, variable);

            return new Instruction[] { b, stloc };
        }

        public static Instruction EmitStloc(this ILProcessor il, int index, VariableDefinition variable)
        {
            Instruction result;

            switch (index)
            {
                case 0:
                    result = Instruction.Create(OpCodes.Stloc_0);
                    break;
                case 1:
                    result = Instruction.Create(OpCodes.Stloc_1);
                    break;
                case 2:
                    result = Instruction.Create(OpCodes.Stloc_2);
                    break;
                case 3:
                    result = Instruction.Create(OpCodes.Stloc_3);
                    break;
                default:
                    result = Instruction.Create(OpCodes.Stloc_S, variable);
                    break;
            }

            il.Append(result);
            return result;
        }

        public static Instruction EmitLdloc(this ILProcessor il, int index, VariableDefinition variable, bool ldloc_a = false)
        {
            Instruction result;

            switch (index)
            {
                case 0:
                    result = Instruction.Create(OpCodes.Ldloc_0);
                    break;
                case 1:
                    result = Instruction.Create(OpCodes.Ldloc_1);
                    break;
                case 2:
                    result = Instruction.Create(OpCodes.Ldloc_2);
                    break;
                case 3:
                    result = Instruction.Create(OpCodes.Ldloc_3);
                    break;
                default:
                    result = Instruction.Create(ldloc_a ? OpCodes.Ldloca_S : OpCodes.Ldloc_S, variable);
                    break;
            }

            il.Append(result);
            return result;
        }

        public static Instruction EmitIntInstruction(this ILProcessor il, int value)
        {
            Instruction result;

            switch (value)
            {
                case 0:
                    result = Instruction.Create(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    result = Instruction.Create(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    result = Instruction.Create(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    result = Instruction.Create(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    result = Instruction.Create(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    result = Instruction.Create(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    result = Instruction.Create(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    result = Instruction.Create(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    result = Instruction.Create(OpCodes.Ldc_I4_8);
                    break;
                default:
                    result = value > 8 && value < 127 ? Instruction.Create(OpCodes.Ldc_I4_S, (sbyte)value) : Instruction.Create(OpCodes.Ldc_I4, value);
                    break;
            }

            il.Append(result);
            return result;
        }

        public static Instruction[] EmitDefaultInstructions(TypeReference type)
        {
            if (type.Is<bool>() || type.Is<int>() || type.Is<uint>() || type.Is<short>() || type.Is<ushort>() || type.Is<byte>() || type.Is<sbyte>())
            {
                return new Instruction[] { Instruction.Create(OpCodes.Ldc_I4_0) };
            }
            else if (type.Is<long>() || type.Is<ulong>())
            {
                return new Instruction[] { Instruction.Create(OpCodes.Conv_I8), Instruction.Create(OpCodes.Ldc_I4_0) };
            }
            else if (type.Is<float>())
            {
                return new Instruction[] { Instruction.Create(OpCodes.Ldc_R4, (float)0.0f) };
            }
            else if (type.Is<double>())
            {
                return new Instruction[] { Instruction.Create(OpCodes.Ldc_R8, (double)0.0d) };
            }
            else if (type.IsValueType)
            {
                return new Instruction[] { Instruction.Create(OpCodes.Initobj, type) };
            }
            else
            {
                return new Instruction[] { Instruction.Create(OpCodes.Ldnull) };
            }
        }
    }
}
