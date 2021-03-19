using Mono.Cecil;
using System.Linq;
using System.Reflection;

namespace Hertzole.ALE.CodeGen
{
    public sealed class PostProcessorReflectionImporter : DefaultReflectionImporter
    {
        private const string SYSTEM_PRIVATE_CORELIB = "System.Private.CoreLib";
        private readonly AssemblyNameReference correctCorlib;

        public PostProcessorReflectionImporter(ModuleDefinition module) : base(module)
        {
            correctCorlib = module.AssemblyReferences.FirstOrDefault(a => a.Name == "mscorlib" || a.Name == "netstandard" || a.Name == SYSTEM_PRIVATE_CORELIB);
        }

        public override AssemblyNameReference ImportReference(AssemblyName reference)
        {
            return correctCorlib != null && reference.Name == SYSTEM_PRIVATE_CORELIB ? correctCorlib : base.ImportReference(reference);
        }
    }
}
