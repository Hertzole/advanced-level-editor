using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class CustomDataByteList : BaseCustomDataTestScript
	{
		private readonly List<byte> template = new List<byte>()
		{
			42,
			69,
			77,
			255
		};

		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", template);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out List<byte> value));
			Assert.IsNotNull(value);
			Assert.IsTrue(template.IsSameAs(value));
		}
	}
}