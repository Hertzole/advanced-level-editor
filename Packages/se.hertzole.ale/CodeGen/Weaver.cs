using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Unity.CompilationPipeline.Common.Diagnostics;

namespace Hertzole.ALE.CodeGen
{
    public class Weaver
    {
        private readonly List<DiagnosticMessage> diagnostics;

        private readonly BaseProcessor[] processors = new BaseProcessor[]
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

        public void ProcessAssembly(ModuleDefinition module, string[] defines)
        {
            RegisterTypeProcessor typeRegister = new RegisterTypeProcessor(module);
            ResolverProcessor resolver = new ResolverProcessor(module);
            FormatterProcessor formatter = new FormatterProcessor(this, module, resolver);
            CustomDataProcessor customData = new CustomDataProcessor(this, module, typeRegister, resolver, formatter);

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
                processors[i].TypeRegister = typeRegister;
                processors[i].Resolver = resolver;
                processors[i].Formatters = formatter;
                processors[i].IsBuildingPlayer = isBuildingPlayer;
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

            customData.EndEditing();
            typeRegister.EndEditing();
            formatter.EndEditing(); // Important to be before resolver!
            resolver.EndEditing(isBuildingPlayer);
        }
    }
}
