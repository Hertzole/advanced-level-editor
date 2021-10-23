using System;

namespace Hertzole.ALE
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field, AllowMultiple = true)]
	public class FormerlyHashedAsAttribute : Attribute
	{
		public FormerlyHashedAsAttribute(string oldName) { }
	}
}