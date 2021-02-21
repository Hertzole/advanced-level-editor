using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;
using System.Linq;
using Unity.CompilationPipeline.Common.ILPostProcessing;

namespace Hertzole.ALE.CodeGen
{
    public class ALEPostProcessor : ILPostProcessor
    {
        private const string ALE_ASSEMBLY = "Hertzole.ALE";

        public override ILPostProcessor GetInstance()
        {
            return this;
        }

        public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
        {
            if (!WillProcess(compiledAssembly))
            {
                return null;
            }

            WeaverLogger logger = new WeaverLogger();
            Weaver weaver = new Weaver(logger);

            AssemblyDefinition assembly = weaver.Weave(compiledAssembly);

            MemoryStream assemblyStream = new MemoryStream();
            MemoryStream symbolsStream = new MemoryStream();

            WriterParameters writerParameters = new WriterParameters
            {
                SymbolWriterProvider = new PortablePdbWriterProvider(),
                SymbolStream = symbolsStream,
                WriteSymbols = true
            };

            assembly?.Write(assemblyStream, writerParameters);

            return new ILPostProcessResult(new InMemoryAssembly(assemblyStream.ToArray(), symbolsStream.ToArray()));
        }

        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            // Only process if the assembly references ALE.
            return compiledAssembly.References.Any(x => Path.GetFileNameWithoutExtension(x) == ALE_ASSEMBLY);
        }
    }
}
