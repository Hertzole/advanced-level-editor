using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class Vector2IntExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector2Int value;
	}
	
	[ExposedType]
	public partial class Vector2IntExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Vector2Int? value;
	}
	
}