using Mono.Cecil;
using System.Linq;
using System.Reflection;

namespace Hertzole.ALE.CodeGen
{
    internal class PostProcessorReflectionImporter : DefaultReflectionImporter
    {
        private const string SYSTEM_PRIVATE_CORE_LIB = "System.Private.CoreLib";
        private readonly AssemblyNameReference correctCorlib;

        public PostProcessorReflectionImporter(ModuleDefinition module) : base(module)
        {
            correctCorlib = module.AssemblyReferences.FirstOrDefault(a => a.Name == "mscorlib" || a.Name == "netstandard" || a.Name == SYSTEM_PRIVATE_CORE_LIB);
        }

        public override AssemblyNameReference ImportReference(AssemblyName name)
        {
            return correctCorlib != null && name.Name == SYSTEM_PRIVATE_CORE_LIB ? correctCorlib : base.ImportReference(name);
        }
    }
}
