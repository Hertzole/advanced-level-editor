using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class UIntExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public uint value;
	}
	
	[ExposedType]
	public partial class UIntExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public uint? value;
	}
}