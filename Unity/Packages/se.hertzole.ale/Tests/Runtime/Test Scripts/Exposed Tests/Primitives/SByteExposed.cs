using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class SByteExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public sbyte value;
	}
	
	[ExposedType]
	public partial class SByteExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public sbyte? value;
	}
}