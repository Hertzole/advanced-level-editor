namespace Hertzole.ALE.Tests
{
    public class BinarySerialization : SerializationTest
    {
        protected override T SerializeAndDeserialize<T>(T data)
        {
            byte[] bytes = LevelEditorSerializer.SerializeBinary(data);

            return LevelEditorSerializer.DeserializeBinary<T>(bytes);
        }
    }
}
