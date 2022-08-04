using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class Vector3IntExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector3Int value;
	}
	
	[ExposedType]
	public partial class Vector3IntExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector3Int? value;
	}
	
}