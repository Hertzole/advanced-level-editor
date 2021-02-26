namespace Hertzole.ALE.Tests
{
    public class BinaryTypes : TypesTest
    {
        public override T SerializeAndDeserialize<T>(T value)
        {
            byte[] bytes = LevelEditorBinarySerializer.Serialize(value);

            return LevelEditorBinarySerializer.Deserialize<T>(bytes);
        }
    }
}
