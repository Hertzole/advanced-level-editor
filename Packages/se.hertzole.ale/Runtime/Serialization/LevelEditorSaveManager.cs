﻿using System;
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
        private string fileExtension = ".json";
#if ALE_JSON
        [SerializeField]
        private bool saveAsJson = true;
        [SerializeField]
        private bool prettyPrint = false;
#endif

        private string loadLocation;

        private ILevelEditorObjectManager realObjectManager;

        public event EventHandler<LevelSavingLoadingArgs> OnLevelSaving;
        public event EventHandler<LevelSavingLoadingArgs> OnLevelLoading;

        public event EventHandler<LevelEventArgs> OnLevelSaved;
        public event EventHandler<LevelEventArgs> OnLevelLoaded;

        public struct Temp
        {
            public Vector3 value;
        }

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

            if (!File.Exists(path))
            {
                Debug.LogError($"There's no file with path '{path}'.");
                return null;
            }

#if ALE_JSON
            if (saveAsJson)
            {
                data = LevelEditorJsonSerializer.DeserializeJson(File.ReadAllText(path));
            }
            else
#endif
            {
                Debug.Log("Binary serialization is not yet supported. Please use JSON for now.");
                return null;
                //data = LevelEditorSerializer.DeserializeBinary(File.ReadAllBytes(path));
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
                return new LevelEditorSaveData(null);
            }

            realObjectManager.DeleteAllObjects();
            realObjectManager.CreateObjectsFromSaveData(data);

            OnLevelLoaded?.Invoke(this, new LevelEventArgs(data));

            return data;
        }

        public virtual void SaveLevel(string levelName)
        {
            LevelEditorSaveData data = GetLevelData(levelName);

            SaveLevel(data);
        }

        public virtual void SaveLevel(LevelEditorSaveData saveData)
        {
            string saveFolder = BuildSaveLocation(baseSaveLocation, saveSuffix);
            string saveLocation = saveFolder + saveData.name + ToFileExtension(fileExtension);

            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }

            LevelSavingLoadingArgs args = new LevelSavingLoadingArgs(saveData, saveLocation);
            OnLevelSaving?.Invoke(this, args);
            if (args.Cancel)
            {
                LevelEditorLogger.Log("LevelEditorSaveManager saving was canceled.");
                return;
            }

#if ALE_JSON
            if (saveAsJson)
            {
                //string json = LevelEditorSerializer.SerializeJson(saveData, prettyPrint);
                string json = LevelEditorJsonSerializer.SerializeJson(saveData, prettyPrint);
                File.WriteAllText(saveLocation, json);
            }
            else
#endif
            {
                Debug.LogError("Serialize binary is not yet supported. Please use JSON serialization.");
                //byte[] data = LevelEditorSerializer.SerializeBinary(saveData);
                //File.WriteAllBytes(saveLocation, data);
            }

            OnLevelSaved?.Invoke(this, new LevelEventArgs(saveData));

            try
            {

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