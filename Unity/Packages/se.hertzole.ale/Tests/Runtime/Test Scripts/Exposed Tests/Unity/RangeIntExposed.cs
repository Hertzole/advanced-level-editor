using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class RangeIntExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public RangeInt value;
	}
	
	[ExposedType]
	public partial class RangeIntExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public RangeInt? value;
	}
	
}