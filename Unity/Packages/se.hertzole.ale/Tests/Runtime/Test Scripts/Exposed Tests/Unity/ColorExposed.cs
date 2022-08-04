using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class ColorExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Color value;
	}
	
	[ExposedType]
	public partial class ColorExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Color? value;
	}
	
}