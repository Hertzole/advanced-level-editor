using System;
using System.Collections.Generic;
using UnityEngine;

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
            string type = valueType.IsArray ? valueType.GetElementType().FullName : valueType.FullName;
            customData.Add(key, new LevelEditorCustomData(type, valueType.IsArray, value));
        }

        public bool TryGetCustomData<T>(string key, out T value)
        {
            if (customData.TryGetValue(key, out LevelEditorCustomData data))
            {
                if (data.isArray)
                {
                    Debug.LogError("This function is only used for single values.");
                    value = default;
                    return false;
                }
                else
                {
                    value = (T)data.value;
                    return true;
                }
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool TryGetCustomData<T>(string key, out T[] value)
        {
            if (customData.TryGetValue(key, out LevelEditorCustomData data))
            {
                if (data.isArray)
                {
                    value = Array.ConvertAll((object[])data.value, item => (T)item);
                }
                else
                {
                    Debug.LogError("This function is only used for getting arrays.");
                    value = null;
                    return false;
                }

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

        void SaveLevel(string levelName);

        void SaveLevel(LevelEditorSaveData saveData);

        LevelEditorSaveData LoadLevel(string path);

        LevelEditorSaveData LoadLevel(LevelEditorSaveData data);

        LevelEditorSaveData GetLevelData(string levelName);

        string[] GetLevels();
    }
}
