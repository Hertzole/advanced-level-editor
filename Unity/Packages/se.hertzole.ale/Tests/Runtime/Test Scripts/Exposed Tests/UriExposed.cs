using System;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	[ExposedType]
	public partial class UriExposed : MonoBehaviour
	{
		[ExposedVar(0)]
		public Uri value;
	}
}