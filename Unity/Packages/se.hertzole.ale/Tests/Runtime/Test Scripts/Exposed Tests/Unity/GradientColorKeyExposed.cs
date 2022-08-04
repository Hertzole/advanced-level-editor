using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class GradientColorKeyExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public GradientColorKey value;
	}
	
	[ExposedType]
	public partial class GradientColorKeyExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public GradientColorKey? value;
	}
	
}