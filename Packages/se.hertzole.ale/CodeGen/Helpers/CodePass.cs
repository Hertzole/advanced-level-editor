using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace Hertzole.ALE.CodeGen.Helpers
{
	public static class CodePass
	{
		public delegate Instruction InstructionProcessor(MethodDefinition method, Instruction instruction, SequencePoint sequencePoint);

		public static void ForEachInstruction(ModuleDefinition module, Predicate<MethodDefinition> selector, InstructionProcessor processor)
		{
			Collection<TypeDefinition> types = module.Types;

			for (int i = 0; i < types.Count; i++)
			{
				InstructionPass(types[i], selector, processor);
			}
		}

		public static void ForEachInstruction(ModuleDefinition module, InstructionProcessor processor)
		{
			ForEachInstruction(module, method => true, processor);
		}

		private static void InstructionPass(TypeDefinition type, Predicate<MethodDefinition> selector, InstructionProcessor processor)
		{
			Collection<MethodDefinition> methods = type.Methods;
			Collection<TypeDefinition> nestedTypes = type.NestedTypes;

			for (int i = 0; i < methods.Count; i++)
			{
				InstructionPass(methods[i], selector, processor);
			}

			for (int i = 0; i < nestedTypes.Count; i++)
			{
				InstructionPass(nestedTypes[i], selector, processor);
			}
		}

		private static void InstructionPass(MethodDefinition method, Predicate<MethodDefinition> selector, InstructionProcessor processor)
		{
			if (method.IsAbstract || method.Body == null || method.Body.Instructions == null || method.Body.Instructions.Count == 0)
			{
				return;
			}

			if (method.Body.CodeSize > 0 && selector(method))
			{
				Collection<SequencePoint> sequencePoints = method.DebugInformation.SequencePoints;

				int pointIndex = 0;
				Instruction i = method.Body.Instructions[0];

				while (i != null)
				{
					SequencePoint point;
					(point, pointIndex) = GetSequencePoint(sequencePoints, pointIndex, i);
					i = processor(method, i, point);
					i = i.Next;
				}
			}
		}

		private static (SequencePoint sequencePoint, int sequencePointIndex) GetSequencePoint(Collection<SequencePoint> sequencePoints, int index, Instruction instruction)
		{
			if (sequencePoints == null || sequencePoints.Count == 0)
			{
				return (null, 0);
			}

			SequencePoint point = sequencePoints[index];

			if (index + 1 >= sequencePoints.Count)
			{
				return (point, index);
			}

			SequencePoint next = sequencePoints[index + 1];

			if (next.Offset > instruction.Offset)
			{
				return (point, index);
			}

			return (next, index + 1);
		}
	}
}