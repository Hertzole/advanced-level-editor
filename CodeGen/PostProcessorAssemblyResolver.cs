using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Unity.CompilationPipeline.Common.ILPostProcessing;

namespace Hertzole.ALE.CodeGen
{
    public sealed class PostProcessorAssemblyResolver : IAssemblyResolver
    {
        private readonly string[] assemblyReferences;
        private readonly Dictionary<string, AssemblyDefinition> assemblyCache = new Dictionary<string, AssemblyDefinition>();
        private readonly ICompiledAssembly compiledAssembly;
        private AssemblyDefinition selfAssembly;

        public PostProcessorAssemblyResolver(ICompiledAssembly compiledAssembly)
        {
            this.compiledAssembly = compiledAssembly;
            assemblyReferences = compiledAssembly.References;
        }

        public void Dispose() { }

        public AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            return Resolve(name, new ReaderParameters(ReadingMode.Deferred));
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
        {
            lock (assemblyCache)
            {
                if (name.Name == compiledAssembly.Name)
                {
                    return selfAssembly;
                }

                string fileName = FindFile(name);
                if (fileName == null)
                {
                    return null;
                }

                DateTime lastWriteTime = File.GetLastWriteTime(fileName);
                string cacheKey = $"{fileName}{lastWriteTime}";
                if (assemblyCache.TryGetValue(cacheKey, out AssemblyDefinition result))
                {
                    return result;
                }

                parameters.AssemblyResolver = this;

                MemoryStream ms = MemoryStreamFor(fileName);
                string pdb = $"{fileName}.pdb";
                if (File.Exists(pdb))
                {
                    parameters.SymbolStream = MemoryStreamFor(pdb);
                }

                AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(ms, parameters);
                assemblyCache.Add(cacheKey, assemblyDefinition);

                return assemblyDefinition;
            }
        }

        private string FindFile(AssemblyNameReference name)
        {
            string fileName = assemblyReferences.FirstOrDefault(r => Path.GetFileName(r) == $"{name.Name}.dll");
            if (fileName != null)
            {
                return fileName;
            }

            // perhaps the type comes from an exe instead
            fileName = assemblyReferences.FirstOrDefault(r => Path.GetFileName(r) == $"{name.Name}.exe");
            if (fileName != null)
            {
                return fileName;
            }

            //Unfortunately the current ICompiledAssembly API only provides direct references.
            //It is very much possible that a postprocessor ends up investigating a type in a directly
            //referenced assembly, that contains a field that is not in a directly referenced assembly.
            //if we don't do anything special for that situation, it will fail to resolve.  We should fix this
            //in the ILPostProcessing API. As a workaround, we rely on the fact here that the indirect references
            //are always located next to direct references, so we search in all directories of direct references we
            //got passed, and if we find the file in there, we resolve to it.
            return assemblyReferences
                .Select(Path.GetDirectoryName)
                .Distinct()
                .Select(parentDir => Path.Combine(parentDir, $"{name.Name}.dll"))
                .FirstOrDefault(File.Exists);
        }

        private static MemoryStream MemoryStreamFor(string fileName)
        {
            return Retry(10, TimeSpan.FromSeconds(1), () =>
            {
                byte[] byteArray;
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byteArray = new byte[fs.Length];
                    int readLength = fs.Read(byteArray, 0, (int)fs.Length);
                    if (readLength != fs.Length)
                    {
                        throw new InvalidOperationException("File read length is not full length of file.");
                    }
                }

                return new MemoryStream(byteArray);
            });
        }

        private static MemoryStream Retry(int retryCount, TimeSpan waitTime, Func<MemoryStream> func)
        {
            try
            {
                return func();
            }
            catch (IOException)
            {
                if (retryCount == 0)
                {
                    throw;
                }

                Console.WriteLine($"Caught IO Exception, trying {retryCount} more times");
                Thread.Sleep(waitTime);

                return Retry(retryCount - 1, waitTime, func);
            }
        }

        public void AddAssemblyDefinitionBeingOperatedOn(AssemblyDefinition assemblyDefinition)
        {
            selfAssembly = assemblyDefinition;
        }
    }
}
