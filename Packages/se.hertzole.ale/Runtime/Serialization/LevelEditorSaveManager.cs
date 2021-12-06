﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorSaveManager : MonoBehaviour, ILevelEditorSaveManager
    {
        public enum FormatType { JSON, Binary }
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
        [SerializeField]
        private FormatType levelFormat = FormatType.JSON;
        [SerializeField] 
        private bool compress = true;

        private string loadLocation;

        private ILevelEditorObjectManager realObjectManager;
        
        public FormatType LevelFormat { get { return levelFormat; } set { levelFormat = value; } }

        public ILevelEditorObjectManager ObjectManager { get { return realObjectManager; } set { realObjectManager = value; } }

        public event EventHandler<LevelSavingLoadingArgs> OnLevelSaving;
        public event EventHandler<LevelSavingLoadingArgs> OnLevelLoading;

        public event EventHandler<LevelEventArgs> OnLevelSaved;
        public event EventHandler<LevelEventArgs> OnLevelLoaded;

        private void Start()
        {
            if (realObjectManager == null)
            {
                realObjectManager = objectManager.NeedComponent<ILevelEditorObjectManager>();
            }
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

        public virtual string[] GetLevels()
        {
            string location = BuildSaveLocation(baseSaveLocation, saveSuffix);
            if (!Directory.Exists(location))
            {
                return Array.Empty<string>();
            }

            return Directory.GetFiles(location, "*" + ToFileExtension(fileExtension));
        }

        public virtual LevelEditorSaveData LoadLevelFromBytes(byte[] levelBytes)
        {
            LevelEditorSaveData data = LevelEditorSerializer.DeserializeBinary<LevelEditorSaveData>(levelBytes, compress);

            return LoadLevel(data);
        }

        public virtual LevelEditorSaveData LoadLevelFromJson(string json)
        {
            LevelEditorSaveData data = LevelEditorSerializer.DeserializeJson<LevelEditorSaveData>(json);

            return LoadLevel(data);
        }

        public virtual LevelEditorSaveData LoadLevel(string path)
        {
            loadLocation = path;
            LevelEditorSaveData data;

            if (!File.Exists(path))
            {
                Debug.LogError($"There's no file with path '{path}'.");
                return new LevelEditorSaveData();
            }

            switch (levelFormat)
            {
                case FormatType.JSON:
                    data = LevelEditorSerializer.DeserializeJson<LevelEditorSaveData>(File.ReadAllText(path));
                    break;
                case FormatType.Binary:
                    data = LevelEditorSerializer.DeserializeBinary<LevelEditorSaveData>(File.ReadAllBytes(path), compress);
                    break;
                default:
                    data = new LevelEditorSaveData();
                    break;
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

            SaveLevel(data, BuildSavePath(baseSaveLocation, saveSuffix, levelName, fileExtension));
        }

        public virtual void SaveLevel(string levelName, string path)
        {
            SaveLevel(GetLevelData(levelName), path);
        }

        public virtual void SaveLevel(LevelEditorSaveData saveData)
        {
            SaveLevel(saveData, BuildSavePath(baseSaveLocation, saveSuffix, saveData.name, fileExtension));
        }

        public virtual void SaveLevel(LevelEditorSaveData saveData, string path)
        {
            string saveFolder = Path.GetDirectoryName(path);
            
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
            
            LevelSavingLoadingArgs args = new LevelSavingLoadingArgs(saveData, path);
            OnLevelSaving?.Invoke(this, args);
            if (args.Cancel)
            {
                LevelEditorLogger.Log("LevelEditorSaveManager saving was canceled.");
                return;
            }
            
            saveData.customData = args.GetAllCustomData();
            
            switch (levelFormat)
            {
                case FormatType.JSON:
                    string json = LevelEditorSerializer.SerializeJson(saveData);
                    File.WriteAllText(path, json);
                    break;
                case FormatType.Binary:
                    byte[] bytes = LevelEditorSerializer.SerializeBinary(saveData, compress);
                    File.WriteAllBytes(path, bytes);
                    break;
            }
            
            OnLevelSaved?.Invoke(this, new LevelEventArgs(saveData));
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

        protected virtual string BuildSavePath(SaveLocation baseLocation, string suffix, string levelName, string fileExtension)
        {
            return $"{BuildSaveLocation(baseLocation, suffix)}/{levelName}{ToFileExtension(fileExtension)}";
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
