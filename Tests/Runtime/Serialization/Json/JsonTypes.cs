namespace Hertzole.ALE.Tests
{
    public class JsonTypes : TypesTest
    {
        public override T SerializeAndDeserialize<T>(T value)
        {
            string json = LevelEditorSerializer.SerializeJson(value);
            return LevelEditorSerializer.DeserializeJson<T>(json);
        }
    }
}
