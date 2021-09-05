namespace Hertzole.ALE.Tests
{
    public class BinaryTypes : TypesTest
    {
        public override T SerializeAndDeserialize<T>(T value)
        {
            byte[] bytes = LevelEditorSerializer.SerializeBinary(value);

            return LevelEditorSerializer.DeserializeBinary<T>(bytes);
        }
    }
}
