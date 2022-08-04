using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class UShortExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public ushort value;
	}
	
	[ExposedType]
	public partial class UShortExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public ushort? value;
	}
}