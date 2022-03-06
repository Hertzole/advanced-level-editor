#if UNITY_2021_2_OR_NEWER
using System;
using System.Linq;
using Mono.Cecil;

namespace Hertzole.ALE.CodeGen.Helpers
{
	public static class TypeHelpers
	{
		static AssemblyNameReference _systemRuntimeRef;

		static TypeHelpers()
		{
			var systemRuntime = AppDomain.CurrentDomain.GetAssemblies().Single(mr => mr.GetName().Name == "netstandard");

			// in most platforms, referencing System.Object and other types ends up adding a reference to System.Private.CoreLib (not that in these platforms, System.Runtime has type forwarders for these types).
			// To avoid this reference to System.Private.CoreLib we update these types to pretend they come from System.Runtime instead.
			_systemRuntimeRef = new AssemblyNameReference(systemRuntime.GetName().Name, systemRuntime.GetName().Version)
			{
				// PublicKeyToken = new byte[] { 0xb0, 0x3f, 0x5f, 0x7f, 0x11, 0xd5, 0x0a, 0x3a }
				PublicKeyToken = new byte[]{0xcc, 0x7b, 0x13, 0xff, 0xcd, 0x2d, 0xdd, 0x51}
			};
		}

		/// <summary>Changes types referencing mscorlib so they appear to be defined in System.Runtime.dll</summary>
		/// <param name="self">type to be checked</param>
		/// <param name="mainModule">module which assembly references will be added to/removed from</param>
		/// <returns>the same type reference passed as the parameter. This allows the method to be used in chains of calls.</returns>
		public static TypeReference Fix(TypeReference self, ModuleDefinition mainModule)
		{
			if (self.DeclaringType != null)
			{
				Fix(self.DeclaringType, mainModule);
			}
			else
			{
				if (self.Scope.Name == "System.Private.CoreLib")
				{
					if (!mainModule.AssemblyReferences.Any(a => a.Name == _systemRuntimeRef.Name))
					{
						mainModule.AssemblyReferences.Add(_systemRuntimeRef);
						mainModule.AssemblyReferences.Remove((AssemblyNameReference) self.Scope);
					}

					self.Scope = _systemRuntimeRef;
				}
			}

			return self;
		}
		
		public static MethodReference Fix(MethodReference self, ModuleDefinition mainModule)
		{
			if (self.DeclaringType != null)
			{
				Fix(self.DeclaringType, mainModule);
			}
			else
			{
				if (self.DeclaringType.Scope.Name == "System.Private.CoreLib")
				{
					if (!mainModule.AssemblyReferences.Any(a => a.Name == _systemRuntimeRef.Name))
					{
						mainModule.AssemblyReferences.Add(_systemRuntimeRef);
						mainModule.AssemblyReferences.Remove((AssemblyNameReference) self.DeclaringType.Scope);
					}

					self.DeclaringType.Scope = _systemRuntimeRef;
				}
			}

			return self;
		}
	}
}
#endif