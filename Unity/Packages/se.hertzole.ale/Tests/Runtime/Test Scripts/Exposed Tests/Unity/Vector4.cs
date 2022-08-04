using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class Vector4Exposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector4 value;
	}
	
	[ExposedType]
	public partial class Vector4ExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector4? value;
	}
	
}