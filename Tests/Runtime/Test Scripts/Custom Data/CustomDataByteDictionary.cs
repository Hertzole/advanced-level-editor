using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class CustomDataByteDictionary : BaseCustomDataTestScript
	{
		private readonly Dictionary<int, byte> template = new Dictionary<int, byte>()
		{
			{ 42, 69 },
			{ 43, 70 },
			{ 44, 71 },
			{ 45, 72 },
		};

		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", template);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out Dictionary<int, byte> value));
			Assert.IsNotNull(value);
			Assert.IsTrue(template.IsSameAs(value));
		}
	}
}