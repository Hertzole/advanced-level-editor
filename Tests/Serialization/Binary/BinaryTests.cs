using NUnit.Framework;

namespace Hertzole.ALE.Tests
{
    public class BinaryTests
    {
        [Test]
        public void SaveAndLoadLevel()
        {
            LevelEditorSaveData data = BuildSaveData();
            byte[] bytes = LevelEditorBinarySerializer.Serialize(data);
        }

        private LevelEditorSaveData BuildSaveData()
        {
            LevelEditorSaveData data = new LevelEditorSaveData("Test Level");

            return data;
        }
    }
}
