using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class FloatExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public float value;
	}
	
	[ExposedType]
	public partial class FloatExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public float? value;
	}
}