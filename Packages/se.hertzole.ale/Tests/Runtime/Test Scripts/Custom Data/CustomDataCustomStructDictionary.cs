using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests
{
	public class CustomDataCustomStructDictionary : BaseCustomDataTestScript
	{
		private readonly Dictionary<int, CustomDataStruct2> template = new Dictionary<int, CustomDataStruct2>
		{
			{ 2, new CustomDataStruct2(1, 2, 3) },
			{ 4, new CustomDataStruct2(34, 69, 420) }
		};

		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", template);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out Dictionary<int, CustomDataStruct2> dictionary));
			Assert.IsTrue(dictionary.IsSameAs(template));
		}
	}
}