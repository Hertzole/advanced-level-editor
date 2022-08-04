using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class StringExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public string value;
	}
}