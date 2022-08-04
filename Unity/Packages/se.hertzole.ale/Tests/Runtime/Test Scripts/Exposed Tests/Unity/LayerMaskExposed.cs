using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class LayerMaskExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public LayerMask value;
	}
	
	[ExposedType]
	public partial class LayerMaskExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public LayerMask? value;
	}
	
}