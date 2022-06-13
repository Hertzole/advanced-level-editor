using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class CustomDataEnum : BaseCustomDataTestScript
	{
		public enum MyEnum
		{
			Value1 = 0,
			Value2 = 2,
			Value3 = 4,
			Value4 = 6,
			Value5 = 8,
			Value6 = 10,
		}
		
		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", MyEnum.Value3);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out MyEnum value));
			Assert.AreEqual(MyEnum.Value3, value);
		}
	}
}