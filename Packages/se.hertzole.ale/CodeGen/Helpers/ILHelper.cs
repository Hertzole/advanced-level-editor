using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Hertzole.ALE.CodeGen.Helpers
{
	public static class ILHelper
	{
		public static Instruction Stloc(VariableDefinition variable)
		{
			Instruction result;
			
			switch (variable.Index)
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

			return result;
		}
		
		public static Instruction Ldloc(VariableDefinition variable, bool ldloc_a = false)
		{
			Instruction result;
			
			if (ldloc_a)
			{
				result = Instruction.Create(variable.Index < 256 ?  OpCodes.Ldloca_S : OpCodes.Ldloca, variable);
				return result;
			}

			switch (variable.Index)
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
					result = Instruction.Create(OpCodes.Ldloc_S, variable);
					break;
			}

			return result;
		}

		public static Instruction Ldarg(ILProcessor il, ParameterDefinition parameter = null, bool ldarg_a = false)
		{
			Instruction result;
			int index = 0;
			if (parameter != null)
			{
				index = parameter.Index;

				if (ldarg_a)
				{
					result = Instruction.Create(index < 256 ? OpCodes.Ldarga_S : OpCodes.Ldarga, parameter);
					return result;
				}

				if (il != null)
				{
					if (index == -1 && parameter == il.Body.ThisParameter)
					{
						index = 0;
					}
					else if (il.Body.Method.HasThis)
					{
						index++;
					}
				}
			}

			switch (index)
			{
				case 0:
					result = Instruction.Create(OpCodes.Ldarg_0);
					return result;
				case 1:
					result = Instruction.Create(OpCodes.Ldarg_1);
					return result;
				case 2:
					result = Instruction.Create(OpCodes.Ldarg_2);
					return result;
				case 3:
					result = Instruction.Create(OpCodes.Ldarg_3);
					return result;
				default:
					result = Instruction.Create(index < 256 ? OpCodes.Ldarg_S : OpCodes.Ldarg, parameter);
					return result;
			}
		}

		public static Instruction Int(int value)
		{
			Instruction result;
			
			switch (value)
			{
				case -1:
					result = Instruction.Create(OpCodes.Ldc_I4_M1);
					break;
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
					if (value >= sbyte.MinValue && value < 128)
					{
						result = Instruction.Create(OpCodes.Ldc_I4_S, (sbyte) value);
					}
					else
					{
						result = Instruction.Create(OpCodes.Ldc_I4, value);
					}

					break;
			}

			return result;
		}

		public static Instruction ULong(ulong value)
		{
			if (value > int.MaxValue)
			{
				return Instruction.Create(OpCodes.Ldc_I8, (long)value);
			}
			else
			{
				return Int((int) value);
			}
		}
		
		public static Instruction Long(long value)
		{
			if (value > int.MaxValue)
			{
				return Instruction.Create(OpCodes.Ldc_I8, value);
			}
			else
			{
				return Int((int) value);
			}
		}

		public static Instruction Bool(bool value)
		{
			return Instruction.Create(value ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
		}
	}
}