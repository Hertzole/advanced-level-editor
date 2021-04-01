#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
#endif
using UnityEngine;

namespace Hertzole.ALE
{
    public class RuntimeProjectSettings<T> : ScriptableObject where T : ScriptableObject
    {
#if UNITY_EDITOR
        static RuntimeProjectSettings()
        {
            ProjectSettingsBuildProcessor.OnBuild += OnProjectSettingsBuild;
        }

        private static void OnProjectSettingsBuild(List<ScriptableObject> list, List<string> names)
        {
            T tempInstance = CreateInstance<T>();
            if (tempInstance is RuntimeProjectSettings<T> settings)
            {
                list.Add(Get());
                names.Add(settings.SettingName);
            }
        }
#endif

        private static T settingsInstance;

        public string SettingsPath
        {
            get
            {
#if UNITY_EDITOR
                return $"{ProjectSettingsConsts.ROOT_FOLDER}/{SettingName}.asset";
#else
                return $"{ProjectSettingsConsts.PACKAGE_NAME}/{SettingName}";
#endif
            }
        }

        public virtual string SettingName { get { return typeof(T).FullName; } }

        public static T Get()
        {
            if (settingsInstance != null)
            {
                return settingsInstance;
            }

            T tempInstance = CreateInstance<T>();
            if (tempInstance is RuntimeProjectSettings<T> settings)
            {
#if UNITY_EDITOR
                string path = settings.SettingsPath;

                if (!File.Exists(path))
                {
                    settingsInstance = CreateInstance<T>();
                    ProjectSettingsHelper.Save(settingsInstance, path);
                }
                else
                {
                    settingsInstance = ProjectSettingsHelper.Load<T>(path);
                }

                settingsInstance.hideFlags = HideFlags.HideAndDontSave;
                return settingsInstance;
#else
                settingsInstance = Resources.Load<T>(settings.SettingsPath);
                return settingsInstance;
#endif
            }
            else
            {
                Debug.LogError($"{typeof(T)} does not inherit from RuntimeProjectSettings!");
                return null;
            }
        }

#if UNITY_EDITOR
        public void EditorSave()
        {
            ProjectSettingsHelper.Save(settingsInstance, SettingsPath);
        }
#endif
    }
}
