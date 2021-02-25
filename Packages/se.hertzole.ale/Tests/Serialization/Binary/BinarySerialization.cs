using NUnit.Framework;

namespace Hertzole.ALE.Tests
{
    public class BinarySerialization : SerializationTest
    {
        protected override void SerializeTest<T>(T data)
        {
            byte[] bytes = LevelEditorBinarySerializer.Serialize(data);

            T newData = LevelEditorBinarySerializer.Deserialize<T>(bytes);
            Assert.AreEqual(data, newData);
        }
    }
}
