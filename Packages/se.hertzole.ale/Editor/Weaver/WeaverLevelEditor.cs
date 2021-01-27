using Mono.Cecil;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Editor
{
    public static partial class Weaver
    {
        private static readonly BaseProcessor[] processors = new BaseProcessor[]
        {
            new LevelEditorReaderWriterProcessor(),
            new ExposedClassProcessor(),
        };

        public static (bool success, bool dirty) ProcessAssembly(AssemblyDefinition assembly)
        {
            bool dirty = false;

            TypeDefinition readerWritersType = null;

            foreach (ModuleDefinition module in assembly.Modules)
            {
                IEnumerable<TypeDefinition> types = module.GetTypes();
                foreach (TypeDefinition type in types)
                {
                    if (type.HasAttribute<ALEProcessedAttribute>())
                    {
                        continue;
                    }

                    bool typeModified = false;

                    if (type.Name != "<Module>")
                    {
                        for (int i = 0; i < processors.Length; i++)
                        {
                            if (!processors[i].IsValidClass(type))
                            {
                                continue;
                            }

                            if (i == 0 && readerWritersType == null) // Writer/Reader processor
                            {
                                readerWritersType = new TypeDefinition("Hertzole.ALE", "GeneratedLevelEditorCode", TypeAttributes.AutoClass |
                                    TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit | TypeAttributes.Public);

                                module.Types.Add(readerWritersType);
                                LevelEditorReaderWriterProcessor.generatedClass = readerWritersType;
                            }

                            (bool success, bool dirtyClass) = processors[i].ProcessClass(module, type);
                            if (dirtyClass)
                            {
                                dirty = true;
                                typeModified = true;
                            }

                            if (!success)
                            {
                                return (false, false);
                            }
                        }
                    }

                    if (typeModified)
                    {
                        type.CustomAttributes.Add(new CustomAttribute(type.Module.ImportReference(typeof(ALEProcessedAttribute).GetConstructor(Type.EmptyTypes))));
                    }
                }
            }

            return (true, dirty);
        }
    }
}
