using System;
using System.Reflection;
using Mono.Cecil;
using Mono.Collections.Generic;

namespace Hertzole.ALE.CodeGen
{
	public sealed class PostProcessorReflectionImporter : DefaultReflectionImporter
	{
		private readonly AssemblyNameReference correctCorelib;
		private const string SYSTEM_PRIVATE_CORELIB = "System.Private.CoreLib";

		public PostProcessorReflectionImporter(ModuleDefinition module) : base(module)
		{
			Collection<AssemblyNameReference> references = module.AssemblyReferences;
			for (int i = 0; i < references.Count; i++)
			{
				string name = references[i].Name;
				if (name == "mscorlib" || name == "netstandard" || name == SYSTEM_PRIVATE_CORELIB)
				{
					correctCorelib = references[i];
					break;
				}
			}
			
			for (int i = references.Count - 1; i >= 0; i--)
			{
				if (references[i].Name == SYSTEM_PRIVATE_CORELIB || references[i].Name == "System.Private.Uri")
				{
					references.RemoveAt(i);
				}
			}
		}

		public override AssemblyNameReference ImportReference(AssemblyName name)
		{
			if (correctCorelib != null && (name.Name == SYSTEM_PRIVATE_CORELIB || name.Name == "System.Private.Uri"))
			{
				return correctCorelib;
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