using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorSaveData
    {
        public string name;
        public List<LevelEditorObjectData> objects;
        internal Dictionary<string, LevelEditorCustomData> customData;

        public LevelEditorSaveData(string name)
        {
            this.name = name;

            objects = new List<LevelEditorObjectData>();
            customData = new Dictionary<string, LevelEditorCustomData>();
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

        public override string ToString()
        {
            return $"ALE Save Data ({name}, {objects.Count} objects, {customData.Count} custom data)";
        }
    }
}
