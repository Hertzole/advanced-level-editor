using System;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class TimeSpanExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public TimeSpan value;
	}
	
	[ExposedType]
	public partial class TimeSpanExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public TimeSpan? value;
	}
}