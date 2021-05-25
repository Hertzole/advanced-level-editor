namespace Hertzole.ALE.Tests
{
    public class BinarySerialization : SerializationTest
    {
        protected override void OnSetUp()
        {
            saveManager.LevelFormat = LevelEditorSaveManager.FormatType.Binary;
        }
    }
}
