using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class ShortExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public short value;
	}
	
	[ExposedType]
	public partial class ShortExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public short? value;
	}
}