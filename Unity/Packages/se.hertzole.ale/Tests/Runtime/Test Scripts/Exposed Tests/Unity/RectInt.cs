using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class RectIntExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public RectInt value;
	}
	
	[ExposedType]
	public partial class RectIntExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public RectInt? value;
	}
	
}