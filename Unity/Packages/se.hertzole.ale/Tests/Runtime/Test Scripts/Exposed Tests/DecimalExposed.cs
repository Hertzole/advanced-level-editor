using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class DecimalExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public decimal value;
	}
	
	[ExposedType]
	public partial class DecimalExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public decimal? value;
	}
}