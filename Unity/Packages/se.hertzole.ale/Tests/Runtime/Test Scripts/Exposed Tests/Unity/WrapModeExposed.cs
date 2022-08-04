using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class WrapModeExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public WrapMode value;
	}
	
	[ExposedType]
	public partial class WrapModeExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public WrapMode? value;
	}
	
}