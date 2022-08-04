using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests
{
	public partial class SerializerTest : BaseTest
	{
		private readonly ILevelEditorSerializer serializer = new LevelEditorSerializer();
		
		private void SerializeTest<T>(T value, bool compressed)
		{
			T newValue = value;
			
			Assert.AreEqual(value, newValue);
			
			byte[] bytes = serializer.Serialize(value, compressed);

			newValue = default;

			Assert.AreEqual(default, newValue);

			newValue = serializer.Deserialize<T>(bytes);
			
			Assert.AreEqual(value, newValue);
		}
	}
}