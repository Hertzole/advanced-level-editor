using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorSaveManager : MonoBehaviour, ILevelEditorSaveManager
    {
        public enum SaveLocation { ApplicationData = 0, ApplicationPersistentData = 1, Desktop = 2, Documents = 3 };

        [SerializeField]
        [RequireType(typeof(ILevelEditorObjectManager))]
        private GameObject objectManager = null;
        [SerializeField]
        private SaveLocation baseSaveLocation = SaveLocation.ApplicationPersistentData;
        [SerializeField]
        private string saveSuffix = "Saved Levels";
        [SerializeField]
        private string fileExtension = ".bin";

        private ILevelEditorObjectManager realObjectManager;

        private void Awake()
        {
            realObjectManager = objectManager.NeedComponent<ILevelEditorObjectManager>();
        }

        public virtual LevelEditorSaveData GetLevelData(string levelName)
        {
            LevelEditorSaveData data = new LevelEditorSaveData(levelName);

            List<ILevelEditorObject> objects = realObjectManager.GetAllObjects();
            objects.Sort((x, y) => x.MyGameObject.transform.GetSiblingIndex().CompareTo(y.MyGameObject.transform.GetSiblingIndex()));
            for (int i = 0; i < objects.Count; i++)
            {
                data.objects.Add(new LevelEditorObjectData(objects[i]));
            }

            return data;
        }

        public string[] GetLevels()
        {
            string location = BuildSaveLocation(baseSaveLocation, saveSuffix);
            if (!Directory.Exists(location))
            {
                return Array.Empty<string>();
            }

            return Directory.GetFiles(location, "*" + ToFileExtension(fileExtension));
        }

        public virtual LevelEditorSaveData LoadLevel(string path)
        {
            LevelEditorSaveData data = LevelEditorBinarySerializer.Deserialize(path);
            return LoadLevel(data);
        }

        public virtual LevelEditorSaveData LoadLevel(LevelEditorSaveData data)
        {
            realObjectManager.DeleteAllObjects();
            realObjectManager.CreateObjectsFromSaveData(data);

            return data;
        }

        public virtual void SaveLevel(string levelName)
        {
            LevelEditorSaveData data = GetLevelData(levelName);

            SaveLevel(data);
        }

        public virtual void SaveLevel(LevelEditorSaveData saveData)
        {
            string saveLocation = BuildSaveLocation(baseSaveLocation, saveSuffix) + saveData.name + ToFileExtension(fileExtension);
            try
            {
                LevelEditorBinarySerializer.Serialize(saveData, saveLocation);
            }
            catch (Exception ex)
            {
                //TODO: Show some notification.
                throw ex;
            }
        }

        //TODO: Cache save location string somehow.
        protected virtual string BuildSaveLocation(SaveLocation baseLocation, string suffix)
        {
            switch (baseLocation)
            {
                case SaveLocation.ApplicationData:
                    return Application.dataPath + "/" + suffix + "/";
                case SaveLocation.ApplicationPersistentData:
                    return Application.persistentDataPath + "/" + suffix + "/";
                case SaveLocation.Desktop:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + suffix + "/";
                case SaveLocation.Documents:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/" + suffix + "/";
                default:
                    throw new NotImplementedException(baseLocation + " is not supported.");
            }
        }

        public static string ToFileExtension(string value)
        {
            if (!value.StartsWith("."))
            {
                value = value.Insert(0, ".");
            }

            return value.ToLower().Trim();
        }
    }
}
