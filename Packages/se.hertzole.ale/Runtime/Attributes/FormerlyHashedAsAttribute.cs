using System;

namespace Hertzole.ALE
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class FormerlyHashedAsAttribute : Attribute
	{
		public FormerlyHashedAsAttribute(string oldName) { }
	}
}