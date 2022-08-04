using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class CharExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public char value;
	}

	[ExposedType]
	public partial class CharExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public char? value;
	}
}