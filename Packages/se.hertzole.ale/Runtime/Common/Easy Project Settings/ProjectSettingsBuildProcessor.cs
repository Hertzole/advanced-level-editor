#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hertzole.ALE
{
    internal class ProjectSettingsBuildProcessor : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        int IOrderedCallback.callbackOrder { get { return -10000; } }

        private bool createdResources = false;
        private bool createdPackageFolder = false;

        List<ScriptableObject> objects;
        List<string> names;

        public static event Action<List<ScriptableObject>, List<string>> OnBuild;

        void IPreprocessBuildWithReport.OnPreprocessBuild(BuildReport report)
        {
            objects = new List<ScriptableObject>();
            names = new List<string>();

            OnBuild?.Invoke(objects, names);

            createdResources = false;
            createdPackageFolder = false;

            bool[] createdAssets = new bool[objects.Count];

            while (!AreAllTrue(createdAssets))
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    if (File.Exists($"{ProjectSettingsConsts.ROOT_FOLDER}/{names[i]}.asset"))
                    {
                        ScriptableObject setting = objects[i];

                        if (!Directory.Exists($"{Application.dataPath}/Resources"))
                        {
                            createdResources = true;
                            Directory.CreateDirectory($"{Application.dataPath}/Resources");
                        }

                        if (!Directory.Exists($"{Application.dataPath}/Resources/{ProjectSettingsConsts.PACKAGE_NAME}"))
                        {
                            createdPackageFolder = true;
                            Directory.CreateDirectory($"{Application.dataPath}/Resources/{ProjectSettingsConsts.PACKAGE_NAME}");
                        }

                        string assetPath = $"Assets/Resources/{ProjectSettingsConsts.PACKAGE_NAME}/{names[i]}.asset";
                        
                        setting.hideFlags = HideFlags.None;
                        AssetDatabase.CreateAsset(setting, assetPath);
                        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

                        Object newAsset = AssetDatabase.LoadAssetAtPath(assetPath, setting.GetType());
                        createdAssets[i] = newAsset != null;
                    }
                }
            }
        }

        void IPostprocessBuildWithReport.OnPostprocessBuild(BuildReport report)
        {
            string resourcesPath = $"{Application.dataPath}/Resources";
            string packagePath = $"{resourcesPath}/{ProjectSettingsConsts.PACKAGE_NAME}";

            bool cleanedUp = false;
            while (!cleanedUp)
            {
                if (createdResources && createdPackageFolder && Directory.Exists(packagePath))
                {
                    Directory.Delete(resourcesPath, true);
                    if (File.Exists($"{resourcesPath}.meta"))
                    {
                        File.Delete($"{resourcesPath}.meta");
                    }
                }

                if (!createdResources && createdPackageFolder)
                {
                    Directory.Delete(packagePath, true);
                    if (File.Exists($"{packagePath}.meta"))
                    {
                        File.Delete($"{packagePath}.meta");
                    }
                }

                if (!createdResources && !createdPackageFolder)
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        string path = $"{packagePath}/{names[i]}.asset";
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            string meta = $"{packagePath}/{names[i]}.asset.meta";
                            if (File.Exists(meta))
                            {
                                File.Delete(meta);
                            }
                        }
                    }
                }

                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

                if (createdResources && createdPackageFolder)
                {
                    cleanedUp = !AssetDatabase.IsValidFolder("Assets/Resources/");
                }
                else if (!createdResources && createdPackageFolder)
                {
                    cleanedUp = !AssetDatabase.IsValidFolder($"Assets/Resources/{ProjectSettingsConsts.PACKAGE_NAME}/");
                }
                else if (!createdResources && !createdPackageFolder)
                {
                    bool cleanedAll = true;
                    
                    for (int i = 0; i < names.Count; i++)
                    {
                        string path = $"Assets/Resources/{ProjectSettingsConsts.PACKAGE_NAME}/{names[i]}.asset";
                        Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(ScriptableObject));
                        if (obj != null)
                        {
                            cleanedAll = false;
                            break;
                        }
                    }

                    if (cleanedAll)
                    {
                        cleanedUp = true;
                    }
                }
            }

            objects = null;
            names = null;
        }
        
        private static bool AreAllTrue(IReadOnlyList<bool> bools)
        {
            for (int i = 0; i < bools.Count; i++)
            {
                if (!bools[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
#endif
