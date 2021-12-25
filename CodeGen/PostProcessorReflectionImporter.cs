using System.Reflection;
using Mono.Cecil;
using Mono.Collections.Generic;

namespace Hertzole.ALE.CodeGen
{
	public sealed class PostProcessorReflectionImporter : DefaultReflectionImporter
	{
		private readonly AssemblyNameReference correctCorlib;
		private const string SYSTEM_PRIVATE_CORELIB = "System.Private.CoreLib";

		public PostProcessorReflectionImporter(ModuleDefinition module) : base(module)
		{
			Collection<AssemblyNameReference> references = module.AssemblyReferences;
			for (int i = 0; i < references.Count; i++)
			{
				string name = references[i].Name;
				if (name == "netstandard" || name == "mscorlib" || name == SYSTEM_PRIVATE_CORELIB)
				{
					correctCorlib = references[i];
				}
			}
		}

		public override AssemblyNameReference ImportReference(AssemblyName name)
		{
			if (correctCorlib != null && name.Name == SYSTEM_PRIVATE_CORELIB)
			{
				return correctCorlib;
			}

			if (TryImportFast(name, out AssemblyNameReference reference))
			{
				return reference;
			}

			return base.ImportReference(name);
		}

		private bool TryImportFast(AssemblyName name, out AssemblyNameReference assemblyReference)
		{
			string fullName = name.FullName;

			Collection<AssemblyNameReference> references = module.AssemblyReferences;
			for (int i = 0; i < references.Count; i++)
			{
				AssemblyNameReference reference = references[i];
				if (fullName == reference.FullName)
				{
					assemblyReference = reference;
					return true;
				}
			}

			assemblyReference = null;
			return false;
		}
	}
}