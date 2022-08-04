using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class LongExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public long value;
	}
	
	[ExposedType]
	public partial class LongExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public long? value;
	}
}