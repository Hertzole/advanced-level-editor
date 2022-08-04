using System;

namespace Hertzole.ALE
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class ExposedVarAttribute : Attribute
	{
		public int ID { get; }

		public ExposedVarAttribute(int id)
		{
			ID = id;
		}
	}
}