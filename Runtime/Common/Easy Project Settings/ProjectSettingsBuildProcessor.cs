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

		private readonly List<ScriptableObject> objects = new List<ScriptableObject>();
		private readonly List<Object> preloadedAssets = new List<Object>();
		private readonly List<string> names = new List<string>();

		void IPreprocessBuildWithReport.OnPreprocessBuild(BuildReport report)
		{
			objects.Clear();
			names.Clear();
			preloadedAssets.Clear();

			objects.Add(ALESettings.Get());
			names.Add(ALESettings.Get().SettingName);

			preloadedAssets.AddRange(PlayerSettings.GetPreloadedAssets());

			for (int i = 0; i < objects.Count; i++)
			{
				if (File.Exists($"{ProjectSettingsConsts.ROOT_FOLDER}/{names[i]}.asset"))
				{
					ScriptableObject setting = objects[i];

					string assetPath = $"Assets/{ProjectSettingsConsts.PACKAGE_NAME}_{names[i]}.asset";

					setting.hideFlags = HideFlags.None;
					AssetDatabase.CreateAsset(setting, assetPath);
					AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

					Object newAsset = AssetDatabase.LoadAssetAtPath(assetPath, setting.GetType());

					preloadedAssets.Add(newAsset);
				}
			}

			PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
		}

		void IPostprocessBuildWithReport.OnPostprocessBuild(BuildReport report)
		{
			AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
			
			preloadedAssets.Clear();
			preloadedAssets.AddRange(PlayerSettings.GetPreloadedAssets());

			for (int i = preloadedAssets.Count - 1; i >= 0; i--)
			{
				for (int j = 0; j < objects.Count; j++)
				{
					if (preloadedAssets[i] == objects[j])
					{
						preloadedAssets.RemoveAt(i);
						string path = AssetDatabase.GetAssetPath(objects[j]);
						objects.RemoveAt(j);
						AssetDatabase.DeleteAsset(path);
					}
				}
			}

			// Must delay the call for it to work.
			EditorApplication.delayCall += () => { PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray()); AssetDatabase.SaveAssets(); };

			objects.Clear();
			names.Clear();
		}
	}
}
#endif