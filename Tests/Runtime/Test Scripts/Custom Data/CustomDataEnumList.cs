using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class CustomDataEnumList : BaseCustomDataTestScript
	{
		public enum MyEnum
		{
			One,
			Two,
			Three,
			Four
		}

		private readonly List<MyEnum> template = new List<MyEnum>()
		{
			MyEnum.One,
			MyEnum.Two,
			MyEnum.Four,
			MyEnum.Three
		};

		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", template);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out List<MyEnum> value));
			Assert.IsNotNull(value);
			Assert.IsTrue(template.IsSameAs(value));
		}
	}
}