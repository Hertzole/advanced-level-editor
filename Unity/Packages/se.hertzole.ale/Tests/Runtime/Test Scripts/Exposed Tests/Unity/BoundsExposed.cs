using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class BoundsExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Bounds value;
	}
	
	[ExposedType]
	public partial class BoundsExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Bounds? value;
	}
	
}