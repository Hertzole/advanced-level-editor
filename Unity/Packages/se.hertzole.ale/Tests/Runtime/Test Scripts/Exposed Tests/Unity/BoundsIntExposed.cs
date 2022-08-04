using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class BoundsIntExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public BoundsInt value;
	}
	
	[ExposedType]
	public partial class BoundsIntExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public BoundsInt? value;
	}
	
}