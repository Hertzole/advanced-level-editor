using Mono.Cecil;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public static partial class Weaver
    {
        private static readonly BaseProcessor[] processors = new BaseProcessor[]
        {
            new ExposedClassProcessor()
        };

        public static (bool success, bool dirty) ProcessAssembly(AssemblyDefinition assembly)
        {
            bool dirty = false;

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
                        if (type.IsSubclassOf<MonoBehaviour>())
                        {
                            for (int i = 0; i < processors.Length; i++)
                            {
                                if (!processors[i].IsValidClass(type))
                                {
                                    continue;
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
