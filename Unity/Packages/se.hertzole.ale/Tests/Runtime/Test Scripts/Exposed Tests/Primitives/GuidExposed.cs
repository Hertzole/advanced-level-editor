using System;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class GuidExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Guid value;
	}
	
	[ExposedType]
	public partial class GuidExposedNullable : MonoBehaviour
	{
		[ExposedVar(0)]
		public Guid? value;
	}
}