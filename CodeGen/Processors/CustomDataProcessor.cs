using System.Collections.Generic;
using Hertzole.ALE.CodeGen.Helpers;
using MessagePack.Formatters;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Hertzole.ALE.CodeGen
{
	public class CustomDataProcessor
	{
		private readonly MethodDefinition addDataMethod;
		private readonly FormatterProcessor formatterProcessor;
		private readonly ModuleDefinition module;
		private readonly ResolverProcessor resolverProcessor;
		private readonly Weaver weaver;

		public CustomDataProcessor(Weaver weaver, ModuleDefinition module, ResolverProcessor resolverProcessor, FormatterProcessor formatterProcessor)
		{
			this.weaver = weaver;
			this.module = module;
			this.resolverProcessor = resolverProcessor;
			this.formatterProcessor = formatterProcessor;

			addDataMethod = module.GetMethod<LevelEventArgs>("AddCustomData", typeof(string), typeof(object)).Resolve();
		}

		public void EndEditing()
		{
			CodePass.ForEachInstruction(module, ProcessInstruction);
		}

		private Instruction ProcessInstruction(MethodDefinition method, Instruction instruction, SequencePoint sequencePoint)
		{
			if ((instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Callvirt) && instruction.Operand is MethodReference methodRef)
			{
				MethodDefinition resolved = methodRef.Resolve();
				if (resolved == addDataMethod)
				{
					TypeReference dataType = null;
					Instruction back = instruction.Previous;

					while (true)
					{
						if (back == null || back.OpCode == OpCodes.Call || back.OpCode == OpCodes.Callvirt)
						{
							weaver.Error(sequencePoint, $"Can't determine type of {methodRef}.");
							return instruction;
						}

						if (back.OpCode == OpCodes.Newarr)
						{
							weaver.Error(sequencePoint, "You can't use arrays in custom data.");
							return instruction;
						}

						if (back.OpCode == OpCodes.Newobj || back.OpCode == OpCodes.Box || back.OpCode == OpCodes.Initobj)
						{
							if (back.Operand is TypeReference type)
							{
								dataType = type;
								break;
							}

							if (back.Operand is MethodReference ctor && ctor.Name == ".ctor")
							{
								dataType = ctor.DeclaringType;
								break;
							}
						}

						if (back.OpCode == OpCodes.Ldfld && back.Operand is FieldDefinition field)
						{
							dataType = field.FieldType;
							break;
						}

						back = back.Previous;
					}

					if (dataType == null)
					{
						weaver.Error(sequencePoint, $"Couldn't find type for {methodRef}.");
						return instruction;
					}

					dataType = module.ImportReference(dataType);

					resolverProcessor.AddCustomDataType(dataType);
					formatterProcessor.AddTypeToGenerate(dataType);
					resolverProcessor.AddTypeFormatter(
						module.GetTypeReference(typeof(DictionaryFormatter<,>)).MakeGenericInstanceType(module.GetTypeReference<string>(), dataType),
						module.GetTypeReference(typeof(Dictionary<,>)).MakeGenericInstanceType(module.GetTypeReference<string>(), dataType));
				}
			}

			return instruction;
		}
	}
}