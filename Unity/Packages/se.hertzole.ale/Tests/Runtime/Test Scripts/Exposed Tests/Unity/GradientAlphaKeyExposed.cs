using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class GradientAlphaKeyExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public GradientAlphaKey value;
	}
	
	[ExposedType]
	public partial class GradientAlphaKeyExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public GradientAlphaKey? value;
	}
	
}