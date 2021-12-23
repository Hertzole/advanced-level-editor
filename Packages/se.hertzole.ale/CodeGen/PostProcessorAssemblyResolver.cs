using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Mono.Cecil;
using Unity.CompilationPipeline.Common.ILPostProcessing;

namespace Hertzole.ALE.CodeGen
{
	public sealed class PostProcessorAssemblyResolver : IAssemblyResolver
	{
		private readonly string[] assemblyReferences;
		private readonly string[] assemblyReferencesFileName;
		private readonly string[] assemblyReferencesParents;

		private readonly Dictionary<string, AssemblyDefinition> assemblyCache = new Dictionary<string, AssemblyDefinition>();
		private readonly ICompiledAssembly compiledAssembly;
		private AssemblyDefinition selfAssembly;

		public PostProcessorAssemblyResolver(ICompiledAssembly compiledAssembly)
		{
			this.compiledAssembly = compiledAssembly;
			assemblyReferences = compiledAssembly.References;

			assemblyReferencesFileName = new string[assemblyReferences.Length];
			for (int i = 0; i < assemblyReferences.Length; i++)
			{
				assemblyReferencesFileName[i] = Path.GetFileName(assemblyReferences[i]);
			}

			assemblyReferencesParents = new string[assemblyReferences.Length];
			for (int i = 0; i < assemblyReferences.Length; i++)
			{
				assemblyReferencesParents[i] = Path.GetDirectoryName(assemblyReferences[i]);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

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
				string cacheKey = fileName + lastWriteTime;

				if (assemblyCache.TryGetValue(cacheKey, out AssemblyDefinition result))
				{
					return result;
				}

				parameters.AssemblyResolver = this;

				MemoryStream ms = MemoryStreamFor(fileName);

				string pdb = fileName + ".pdb";
				if (File.Exists(pdb))
				{
					parameters.SymbolStream = MemoryStreamFor(pdb);
				}

				AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(ms, parameters);
				assemblyCache.Add(cacheKey, assemblyDefinition);
				return assemblyDefinition;
			}
		}

		private string FindFile(IMetadataScope name)
		{
			string dllName = name.Name + ".dll";
			string exeName = name.Name + ".exe";
			for (int i = 0; i < assemblyReferencesFileName.Length; i++)
			{
				string fileName = assemblyReferencesFileName[i];
				if (fileName == dllName || fileName == exeName)
				{
					return assemblyReferences[i];
				}
			}

			for (int i = 0; i < assemblyReferencesParents.Length; i++)
			{
				string candidate = Path.Combine(assemblyReferencesParents[i], name.Name + ".dll");
				if (File.Exists(candidate))
				{
					return candidate;
				}
			}

			return null;
		}

		private static MemoryStream MemoryStreamFor(string fileName)
		{
			return Retry(10, TimeSpan.FromSeconds(1), () =>
			{
				byte[] byteArray;
				using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					byteArray = new byte[fs.Length];
					int readLength = fs.Read(byteArray, 0, (int) fs.Length);
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