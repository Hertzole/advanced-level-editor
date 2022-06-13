using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class CustomDataEnumDictionary : BaseCustomDataTestScript
	{
		public enum MyEnum
		{
			One,
			Two,
			Three
		}

		private readonly Dictionary<MyEnum, MyEnum> template = new Dictionary<MyEnum, MyEnum>()
		{
			{ MyEnum.One, MyEnum.Two },
			{ MyEnum.Two, MyEnum.Three },
			{ MyEnum.Three, MyEnum.One }
		};

		protected override void AddCustomData(LevelSavingLoadingArgs e)
		{
			e.AddCustomData("data", template);
		}

		protected override void ValidateCustomData(LevelEventArgs e)
		{
			Assert.IsTrue(e.TryGetCustomData("data", out Dictionary<MyEnum, MyEnum> value));
			Assert.IsTrue(template.IsSameAs(value));
		}
	}
}