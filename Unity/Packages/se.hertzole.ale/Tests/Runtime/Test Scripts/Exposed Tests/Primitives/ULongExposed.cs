using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class ULongExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public ulong value;
	}
	
	[ExposedType]
	public partial class ULongExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public ulong? value;
	}
}