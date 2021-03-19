using Mono.Cecil;
using System;
using System.Collections.Generic;
using Unity.CompilationPipeline.Common.Diagnostics;

namespace Hertzole.ALE.CodeGen
{
    public class Weaver
    {
        private readonly List<DiagnosticMessage> diagnostics;

        private readonly BaseProcessor[] processors = new BaseProcessor[]
        {
            new ExposedClassProcessor(),
            //new FormatterProcessor()
        };

        public Weaver(List<DiagnosticMessage> diagnostics)
        {
            this.diagnostics = diagnostics;
        }

        public void ProcessAssembly(ModuleDefinition module)
        {
            RegisterTypeProcessor.StartEditing(module.Assembly);

            IEnumerable<TypeDefinition> types = module.GetTypes();
            foreach (TypeDefinition type in types)
            {
                if (type.HasAttribute<ALEProcessedAttribute>())
                {
                    continue;
                }

                for (int i = 0; i < processors.Length; i++)
                {
                    if (!processors[i].IsValidClass(type))
                    {
                        continue;
                    }

                    processors[i].ProcessClass(module, type);
                    type.CustomAttributes.Add(new CustomAttribute(module.ImportReference(typeof(ALEProcessedAttribute).GetConstructor(Type.EmptyTypes))));
                }
            }

            RegisterTypeProcessor.EndEditing();
        }
    }
}
