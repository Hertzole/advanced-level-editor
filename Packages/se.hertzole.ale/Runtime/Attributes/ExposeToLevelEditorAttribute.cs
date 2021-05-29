using System;

namespace Hertzole.ALE
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class ExposeToLevelEditorAttribute : Attribute
	{
		public string customName;
		public int order;
		public bool visible;

		public ExposeToLevelEditorAttribute(int id) { }
	}
}