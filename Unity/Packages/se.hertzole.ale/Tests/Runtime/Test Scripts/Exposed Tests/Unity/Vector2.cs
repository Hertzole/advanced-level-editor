using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class Vector2Exposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector2 value;
	}
	
	[ExposedType]
	public partial class Vector2ExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector2? value;
	}
	
}