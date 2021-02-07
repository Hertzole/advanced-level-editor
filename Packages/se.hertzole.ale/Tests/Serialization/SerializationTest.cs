using System.IO;

namespace Hertzole.ALE.Tests
{
    public class SerializationTest : ALETest
    {
        public string FilePath { get; private set; }

        protected override void OnSceneSetup()
        {
            FilePath = Path.GetTempFileName();
        }

        protected override void OnTearDownScene()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
    }
}
