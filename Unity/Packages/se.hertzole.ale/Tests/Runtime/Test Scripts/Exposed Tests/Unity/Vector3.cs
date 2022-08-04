using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class Vector3Exposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector3 value;
	}
	
	[ExposedType]
	public partial class Vector3ExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector3? value;
	}
	
}