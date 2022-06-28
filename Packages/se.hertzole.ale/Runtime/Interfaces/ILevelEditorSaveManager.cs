using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public class LevelEventArgs : EventArgs
    {
        public LevelEditorSaveData Data { get; private set; }

        private Dictionary<string, LevelEditorCustomData> customData;

        public LevelEventArgs(LevelEditorSaveData data)
        {
            Data = data;
            customData = data.customData;
        }

        public void AddCustomData(string key, object value)
        {
            Type valueType = value.GetType();
            customData.Add(key, new LevelEditorCustomData(valueType, value));
        }

        public bool TryGetCustomData<T>(string key, out T value)
        {
            if (customData.TryGetValue(key, out LevelEditorCustomData data))
            {
                value = (T)data.value;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public Dictionary<string, LevelEditorCustomData> GetAllCustomData()
        {
            return customData;
        }
    }

    public class LevelSavingLoadingArgs : LevelEventArgs
    {
        public string Location { get; private set; }

        public bool Cancel { get; set; }

        public LevelSavingLoadingArgs(LevelEditorSaveData data, string location) : base(data)
        {
            Location = location;
        }
    }

    public interface ILevelEditorSaveManager
    {
        event EventHandler<LevelSavingLoadingArgs> OnLevelSaving;
        event EventHandler<LevelSavingLoadingArgs> OnLevelLoading;

        event EventHandler<LevelEventArgs> OnLevelSaved;
        event EventHandler<LevelEventArgs> OnLevelLoaded;
        
        string LevelsPath { get; }

        void SaveLevel(string levelName);

        void SaveLevel(LevelEditorSaveData saveData);

        LevelEditorSaveData LoadLevel(string path);

        LevelEditorSaveData LoadLevel(LevelEditorSaveData data);

        LevelEditorSaveData GetLevelData(string levelName);

        string[] GetLevels();
    }
}
