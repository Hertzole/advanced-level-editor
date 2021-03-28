using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Hertzole.ALE.CodeGen
{
    public abstract class BaseProcessor
    {
        public Weaver Weaver { get; set; }
        public ModuleDefinition Module { get; set; }
        public TypeDefinition Type { get; set; }
        public RegisterTypeProcessor TypeRegister { get; set; }

        public abstract bool IsValidClass(TypeDefinition type);

        public abstract void ProcessClass(TypeDefinition type);

        protected void Error(string message)
        {
            Weaver.diagnostics.AddError(message);
        }

        protected void Error(MethodDefinition methodDefinition, string message)
        {
            Weaver.diagnostics.AddError(methodDefinition, message);
        }

        protected void Error(SequencePoint sequencePoint, string message)
        {
            Weaver.diagnostics.AddError(sequencePoint, message);
        }

        public static OpCode GetBoolOpCode(bool value)
        {
            return value == true ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0;
        }

        public static Instruction GetStloc(int index, VariableDefinition variable)
        {
            switch (index)
            {
                case 0:
                    return Instruction.Create(OpCodes.Stloc_0);
                case 1:
                    return Instruction.Create(OpCodes.Stloc_1);
                case 2:
                    return Instruction.Create(OpCodes.Stloc_2);
                case 3:
                    return Instruction.Create(OpCodes.Stloc_3);
                default:
                    return Instruction.Create(OpCodes.Stloc_S, variable);
            }
        }

        public static Instruction GetLdloc(int index, VariableDefinition variable, bool ldloc_a = false)
        {
            if (ldloc_a)
            {
                return Instruction.Create(OpCodes.Ldloca_S, variable);
            }

            switch (index)
            {
                case 0:
                    return Instruction.Create(OpCodes.Ldloc_0);
                case 1:
                    return Instruction.Create(OpCodes.Ldloc_1);
                case 2:
                    return Instruction.Create(OpCodes.Ldloc_2);
                case 3:
                    return Instruction.Create(OpCodes.Ldloc_3);
                default:
                    return Instruction.Create(OpCodes.Ldloc_S, variable);
            }
        }

        public static Instruction GetIntInstruction(int value)
        {
            if (value == 0)
            {
                return Instruction.Create(OpCodes.Ldc_I4_0);
            }
            else if (value == 1)
            {
                return Instruction.Create(OpCodes.Ldc_I4_1);
            }
            else if (value == 2)
            {
                return Instruction.Create(OpCodes.Ldc_I4_2);
            }
            else if (value == 3)
            {
                return Instruction.Create(OpCodes.Ldc_I4_3);
            }
            else if (value == 4)
            {
                return Instruction.Create(OpCodes.Ldc_I4_4);
            }
            else if (value == 5)
            {
                return Instruction.Create(OpCodes.Ldc_I4_5);
            }
            else if (value == 6)
            {
                return Instruction.Create(OpCodes.Ldc_I4_6);
            }
            else if (value == 7)
            {
                return Instruction.Create(OpCodes.Ldc_I4_7);
            }
            else if (value == 8)
            {
                return Instruction.Create(OpCodes.Ldc_I4_8);
            }
            else if (value > 8 && value < 127)
            {
                return Instruction.Create(OpCodes.Ldc_I4_S, (sbyte)value);
            }
            else
            {
                return Instruction.Create(OpCodes.Ldc_I4, value);
            }
        }

        public static Instruction[] GetDefaultInstructions(TypeReference type)
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
