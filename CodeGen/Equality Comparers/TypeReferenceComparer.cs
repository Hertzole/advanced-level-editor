using System.Collections.Generic;
using Mono.Cecil;

namespace Hertzole.ALE.CodeGen
{
	public class TypeReferencerComparer : IEqualityComparer<TypeReference>
	{
		public bool Equals(TypeReference x, TypeReference y)
		{
			if (x == null || y == null)
			{
				return false;
			}
				
			return x.IsValueType == y.IsValueType && x.IsArray == y.IsArray && x.FullName == y.FullName;
		}

		public int GetHashCode(TypeReference obj)
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