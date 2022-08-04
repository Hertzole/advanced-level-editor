using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class BoolExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public bool value;
	}
	
	[ExposedType]
	public partial class BoolExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public bool? value;
	}
	
}