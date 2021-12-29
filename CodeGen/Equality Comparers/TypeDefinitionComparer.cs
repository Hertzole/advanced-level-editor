using System.Collections.Generic;
using Mono.Cecil;

namespace Hertzole.ALE.CodeGen
{
	public class TypeDefinitionComparer : IEqualityComparer<TypeDefinition>
	{
		public bool Equals(TypeDefinition x, TypeDefinition y)
		{
			if (x == null || y == null)
			{
				return false;
			}
				
			return x.IsValueType == y.IsValueType && x.IsArray == y.IsArray && x.Fields.Count == y.Fields.Count && x.Properties.Count == y.Properties.Count && x.FullName == y.FullName;
		}

		public int GetHashCode(TypeDefinition obj)
		{
			unchecked
			{
				int hashCode = obj.IsValueType.GetHashCode();
				hashCode = (hashCode * 397) ^ obj.IsArray.GetHashCode();
				hashCode = (hashCode * 397) ^ (obj.FullName != null ? obj.FullName.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}