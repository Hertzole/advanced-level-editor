using System;
using System.Collections.Generic;
using Mono.Cecil;
using Unity.CompilationPipeline.Common.Diagnostics;

namespace Hertzole.ALE.CodeGen
{
    public class Weaver
    {
        public readonly List<DiagnosticMessage> diagnostics;

        private readonly BaseProcessor[] processors = new BaseProcessor[]
        {
            new ExposedClassProcessor()
        };

        public Weaver(List<DiagnosticMessage> diagnostics)
        {
            this.diagnostics = diagnostics;
        }

        public void ProcessAssembly(ModuleDefinition module)
        {
            RegisterTypeProcessor typeRegister = new RegisterTypeProcessor(module);
            ResolverProcessor resolver = new ResolverProcessor(module);
            FormatterProcessor formatter = new FormatterProcessor(this, module, resolver);
            
            for (int i = 0; i < processors.Length; i++)
            {
                processors[i].Weaver = this;
                processors[i].Module = module;
                processors[i].TypeRegister = typeRegister;
                processors[i].Resolver = resolver;
                processors[i].Formatters = formatter;
            }

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

                    processors[i].Type = type;

                    processors[i].ProcessClass(type);
                    type.CustomAttributes.Add(new CustomAttribute(module.ImportReference(typeof(ALEProcessedAttribute).GetConstructor(Type.EmptyTypes))));
                }
            }

            typeRegister.EndEditing();
            formatter.EndEditing(); // Important to be before resolver!
            resolver.EndEditing();
        }
    }
}
