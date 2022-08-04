using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class Color32Exposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Color32 value;
	}
	
	[ExposedType]
	public partial class Color32ExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Color32? value;
	}
	
}