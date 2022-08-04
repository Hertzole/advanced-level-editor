using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class DoubleExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public double value;
	}
	
	[ExposedType]
	public partial class DoubleExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public double? value;
	}
}