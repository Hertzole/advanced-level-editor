using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class Matrix4x4Exposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Matrix4x4 value;
	}
	
	[ExposedType]
	public partial class Matrix4x4ExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Matrix4x4? value;
	}
	
}