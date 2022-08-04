using System;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class DateTimeExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public DateTime value;
	}
	
	[ExposedType]
	public partial class DateTimeExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public DateTime? value;
	}
}