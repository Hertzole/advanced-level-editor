using UnityEngine;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests
{
	public partial class ExposedTests : BaseTest
	{
		private void TestSetGetValue<TComponent, TValue>(int id, TValue value) where TComponent : Component
		{
			TComponent go = CreateObject<TComponent>();

			IExposedType exposedTarget = go.GetComponent<IExposedType>();

			Assert.IsNotNull(exposedTarget);

			exposedTarget.InitializeExposedVars();

			exposedTarget.SetValue(id, value);

			Assert.AreEqual(value, exposedTarget.GetValue<TValue>(id));
		}
	}
}