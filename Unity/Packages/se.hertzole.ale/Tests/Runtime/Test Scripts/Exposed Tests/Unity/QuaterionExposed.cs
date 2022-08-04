using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class QuaternionExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Quaternion value;
	}
	
	[ExposedType]
	public partial class QuaternionExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Quaternion? value;
	}
	
}