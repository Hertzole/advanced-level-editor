using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class CustomDataCustomStructList : BaseCustomDataTestScript
	{
		private readonly List<CustomDataStruct1> template = new List<CustomDataStruct1>()
		{
			new CustomDataStruct1(1, 4, 100),
			new CustomDataStruct1(0, 278, 420)
		};

		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", template);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out List<CustomDataStruct1> list));
			Assert.IsTrue(list.IsSameAs(template));
		}
	}
}