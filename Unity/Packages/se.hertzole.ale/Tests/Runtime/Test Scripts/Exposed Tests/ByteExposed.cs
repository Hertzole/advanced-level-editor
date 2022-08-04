using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class ByteExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public byte value;
	}

	[ExposedType]
	public partial class ByteExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public byte? value;
	}
}