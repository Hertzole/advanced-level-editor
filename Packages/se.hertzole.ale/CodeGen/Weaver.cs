using System.Collections.Generic;
using System.Diagnostics;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Unity.CompilationPipeline.Common.Diagnostics;

namespace Hertzole.ALE.CodeGen
{
	public class Weaver
	{
		private readonly List<DiagnosticMessage> diagnostics;

		private readonly BaseProcessor[] processors =
		{
			new ExposedPropertyProcessor()
		};

		public Weaver(List<DiagnosticMessage> diagnostics)
		{
			this.diagnostics = diagnostics;
		}

		public void Error(string message)
		{
			diagnostics.AddError(message);
		}

		public void Error(MethodDefinition methodDefinition, string message)
		{
			diagnostics.AddError(methodDefinition, message);
		}

		public void Error(SequencePoint sequencePoint, string message)
		{
			diagnostics.AddError(sequencePoint, message);
		}

		public void Warning(string message)
		{
			diagnostics.AddWarning(message);
		}

		public void Warning(MethodDefinition methodDefinition, string message)
		{
			diagnostics.AddWarning(methodDefinition, message);
		}

		public void Warning(SequencePoint sequencePoint, string message)
		{
			diagnostics.AddWarning(sequencePoint, message);
		}

		public void ProcessAssembly(ModuleDefinition module, string[] defines)
		{
			ResolverProcessor resolver = new ResolverProcessor(module);
			FormatterProcessor formatter = new FormatterProcessor(this, module, resolver);
			CustomDataProcessor customData = new CustomDataProcessor(this, module, resolver, formatter);

#if ALE_DEBUG
			Stopwatch resolverWatch = new Stopwatch();
			Stopwatch formatterWatch = new Stopwatch();
			Stopwatch customDataWatch = new Stopwatch();
#endif

			bool isBuildingPlayer = true;
			for (int i = 0; i < defines.Length; i++)
			{
				if (defines[i] == "UNITY_EDITOR")
				{
					isBuildingPlayer = false;
					break;
				}
			}

			for (int i = 0; i < processors.Length; i++)
			{
				processors[i].Weaver = this;
				processors[i].Module = module;
				processors[i].Resolver = resolver;
				processors[i].Formatters = formatter;
				processors[i].IsBuildingPlayer = isBuildingPlayer;
			}

			CustomAttribute processedAttribute = new CustomAttribute(module.GetConstructor<ALEProcessedAttribute>());

#if ALE_DEBUG
			Stopwatch[] processorWatches = new Stopwatch[processors.Length];
			for (int i = 0; i < processorWatches.Length; i++)
			{
				processorWatches[i] = new Stopwatch();
			}
#endif

			IEnumerable<TypeDefinition> types = module.GetTypes();
			foreach (TypeDefinition type in types)
			{
				if (type.HasAttribute<ALEProcessedAttribute>())
				{
					continue;
				}

				bool dirty = false;

				for (int i = 0; i < processors.Length; i++)
				{
#if ALE_DEBUG
					processorWatches[i].Start();
#endif

					if (!processors[i].IsValidClass(type))
					{
#if ALE_DEBUG
						processorWatches[i].Stop();
#endif
						continue;
					}

					processors[i].Type = type;

					processors[i].ProcessClass(type);
					dirty = true;
#if ALE_DEBUG
					processorWatches[i].Stop();
#endif
				}

				if (dirty)
				{
					type.CustomAttributes.Add(processedAttribute);
				}
			}

			for (int i = 0; i < processors.Length; i++)
			{
				processors[i].EndEdit();
			}

#if ALE_DEBUG
			customDataWatch.Start();
#endif
			customData.EndEditing();
#if ALE_DEBUG
			customDataWatch.Stop();
#endif

#if ALE_DEBUG
			formatterWatch.Start();
#endif
			formatter.EndEditing(); // Important to be before resolver!
#if ALE_DEBUG
			formatterWatch.Stop();
#endif

#if ALE_DEBUG
			resolverWatch.Start();
#endif
			resolver.EndEditing(isBuildingPlayer);
#if ALE_DEBUG
			resolverWatch.Stop();

			string processorTimings = string.Empty;
			for (int i = 0; i < processorWatches.Length; i++)
			{
				processorTimings += $"{processors[i].GetType()}: {processorWatches[i].ElapsedMilliseconds}ms | ";
			}
			
			Warning("Weaver timings: " +
			        $"Custom data: {customDataWatch.ElapsedMilliseconds}ms | " +
			        $"Formatter: {formatterWatch.ElapsedMilliseconds}ms | " +
			        $"Resolver: {resolverWatch.ElapsedMilliseconds}ms | " +
			        $"{processorTimings}");
#endif
		}
	}
}