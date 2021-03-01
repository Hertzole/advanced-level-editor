namespace Hertzole.ALE.Tests
{
    public class JsonSerialization : SerializationTest
    {
        protected override T SerializeAndDeserialize<T>(T data)
        {
            string json = LevelEditorSerializer.SerializeJson(data);
            return LevelEditorSerializer.DeserializeJson<T>(json);
        }
    }
}
