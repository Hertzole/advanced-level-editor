using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests
{
	public class CustomDataDictionaryWithList : BaseCustomDataTestScript
	{
		private readonly Dictionary<int, List<CustomDataStruct3>> template = new Dictionary<int, List<CustomDataStruct3>>
		{
			{
				2, new List<CustomDataStruct3>
				{
					new CustomDataStruct3(18, 82, 18),
					new CustomDataStruct3(11, 239, 939)
				}
			},
			{
				4, new List<CustomDataStruct3>
				{
					new CustomDataStruct3(18, 94, 832)
				}
			}
		};

		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", template);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out Dictionary<int, List<CustomDataStruct3>> dictionary));
			Assert.AreEqual(template.Count, dictionary.Count);
			foreach (KeyValuePair<int, List<CustomDataStruct3>> pair in template)
			{
				Assert.IsTrue(dictionary.TryGetValue(pair.Key, out List<CustomDataStruct3> list));
				Assert.IsTrue(list.IsSameAs(pair.Value));
			}
		}
	}
}