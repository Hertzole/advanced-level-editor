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
#if ALE_JSON
        [SerializeField]
        private bool saveAsJson = false;
        [SerializeField]
        private bool prettyPrint = false;
#endif

        private string loadLocation;

        private ILevelEditorObjectManager realObjectManager;

        public event EventHandler<LevelSavingLoadingArgs> OnLevelSaving;
        public event EventHandler<LevelSavingLoadingArgs> OnLevelLoading;

        public event EventHandler<LevelEventArgs> OnLevelSaved;
        public event EventHandler<LevelEventArgs> OnLevelLoaded;

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
            loadLocation = path;
            LevelEditorSaveData data;

#if ALE_JSON
            if (saveAsJson)
            {
                data = LevelEditorSerializer.DeserializeJson(File.ReadAllText(path));
            }
            else
#endif
            {
                data = LevelEditorSerializer.DeserializeBinary(File.ReadAllBytes(path));
            }

            return LoadLevel(data);
        }

        public virtual LevelEditorSaveData LoadLevel(LevelEditorSaveData data)
        {
            LevelSavingLoadingArgs args = new LevelSavingLoadingArgs(data, loadLocation);
            loadLocation = null;
            OnLevelLoading?.Invoke(this, args);
            if (args.Cancel)
            {
                LevelEditorLogger.Log("LevelEditorSaveManager loading was canceled.");
                return new LevelEditorSaveData();
            }

            realObjectManager.DeleteAllObjects();
            realObjectManager.CreateObjectsFromSaveData(data);

            OnLevelLoaded?.Invoke(this, new LevelEventArgs());

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

            LevelSavingLoadingArgs args = new LevelSavingLoadingArgs(saveData, saveLocation);
            OnLevelSaving?.Invoke(this, args);
            if (args.Cancel)
            {
                LevelEditorLogger.Log("LevelEditorSaveManager saving was canceled.");
                return;
            }

            try
            {
#if ALE_JSON
                if (saveAsJson)
                {
                    string json = LevelEditorSerializer.SerializeJson(saveData, prettyPrint);
                    File.WriteAllText(saveLocation, json);
                }
                else
#endif
                {
                    byte[] data = LevelEditorSerializer.SerializeBinary(saveData);
                    File.WriteAllBytes(saveLocation, data);
                }

                OnLevelSaved?.Invoke(this, new LevelEventArgs());
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
