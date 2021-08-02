#if UNITY_EDITOR
using System.IO;
#endif
using UnityEngine;

namespace Hertzole.ALE
{
    public class RuntimeProjectSettings<T> : ScriptableObject where T : ScriptableObject
    {
        private static T settingsInstance;

#if UNITY_EDITOR
        private string SettingsPath
        {
            get
            {
                return $"{ProjectSettingsConsts.ROOT_FOLDER}/{SettingName}.asset";
            }
        }
#endif

        public virtual string SettingName { get { return typeof(T).FullName; } }

        public static T Get()
        {
#if UNITY_EDITOR
            if (settingsInstance != null)
            {
                return settingsInstance;
            }

            T tempInstance = CreateInstance<T>();
            if (tempInstance is RuntimeProjectSettings<T> settings)
            {
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
            }

            Debug.LogError($"{typeof(T)} does not inherit from RuntimeProjectSettings!");
            return null;
#else
            return settingsInstance;
#endif
        }

#if !UNITY_EDITOR
        private void OnEnable()
        {
            settingsInstance = this as T;
        }
#endif

#if UNITY_EDITOR
        public void EditorSave()
        {
            ProjectSettingsHelper.Save(settingsInstance, SettingsPath);
        }
#endif
    }
}
