using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests
{
	public class CustomDataByte : BaseCustomDataTestScript
	{
		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", (byte) 42);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out byte value));

			Assert.AreEqual((byte) 42, value);
		}
	}
}