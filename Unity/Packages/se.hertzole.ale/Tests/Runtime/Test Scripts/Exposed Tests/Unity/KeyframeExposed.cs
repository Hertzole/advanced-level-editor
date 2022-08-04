using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class KeyframeExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Keyframe value;
	}
	
	[ExposedType]
	public partial class KeyframeExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Keyframe? value;
	}
	
}