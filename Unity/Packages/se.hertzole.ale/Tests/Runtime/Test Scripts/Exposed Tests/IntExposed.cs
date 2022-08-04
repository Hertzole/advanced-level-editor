using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class IntExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public int value;
	}
	
	[ExposedType]
	public partial class IntExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public int? value;
	}
}