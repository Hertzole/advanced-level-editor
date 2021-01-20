using System.Collections.Generic;

namespace Hertzole.ALE
{
    public struct LevelEditorSaveData
    {
        public string name;
        public List<LevelEditorObjectData> objects;
        public Dictionary<string, LevelEditorCustomData> customData;

        public LevelEditorSaveData(string name)
        {
            this.name = name;

            objects = new List<LevelEditorObjectData>();
            customData = new Dictionary<string, LevelEditorCustomData>();
        }

        public void AddCustomData(string key, object value)
        {
            customData.Add(key, new LevelEditorCustomData(value.GetType().FullName, value));
        }

        public override string ToString()
        {
            return $"ALE Save Data ({name}, {objects.Count} objects, {customData.Count} custom data)";
        }
    }
}
