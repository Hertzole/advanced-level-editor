using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class RectExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Rect value;
	}
	
	[ExposedType]
	public partial class RectExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Rect? value;
	}
	
}