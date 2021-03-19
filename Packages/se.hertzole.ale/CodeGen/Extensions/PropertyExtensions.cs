using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Hertzole.ALE.Editor
{
    public static partial class WeaverExtensions
    {
        public static bool TryGetReturnField(this PropertyDefinition property, out FieldDefinition field)
        {
            if (property.GetMethod == null)
            {
                field = null;
                return false;
            }

            for (int i = 0; i < property.GetMethod.Body.Instructions.Count; i++)
            {
                Instruction instruction = property.GetMethod.Body.Instructions[i];

                if (instruction.OpCode == OpCodes.Ret)
                {
                    Instruction previousInstruction = property.GetMethod.Body.Instructions[i - 1];
                    if (previousInstruction.OpCode == OpCodes.Ldfld || previousInstruction.OpCode == OpCodes.Ldflda)
                    {
                        field = (FieldDefinition)property.GetMethod.Body.Instructions[i - 1].Operand;
                        return true;
                    }
                }
            }

            field = null;
            return false;
        }
    }
}
