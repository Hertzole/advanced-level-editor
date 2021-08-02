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
		private readonly List<Object> originalPreloadedAssets = new List<Object>();
		private readonly List<string> names = new List<string>();

		void IPreprocessBuildWithReport.OnPreprocessBuild(BuildReport report)
		{
			objects.Clear();
			names.Clear();
			originalPreloadedAssets.Clear();

			objects.Add(ALESettings.Get());
			names.Add(ALESettings.Get().SettingName);

			originalPreloadedAssets.AddRange(PlayerSettings.GetPreloadedAssets());
			List<Object> preloadedAssets = new List<Object>(originalPreloadedAssets);

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
			for (int i = 0; i < objects.Count; i++)
			{
				string assetPath = $"Assets/{ProjectSettingsConsts.PACKAGE_NAME}_{names[i]}.asset";
				AssetDatabase.DeleteAsset(assetPath);
				AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
			}

			// Must delay the call for it to work.
			EditorApplication.delayCall += () => { PlayerSettings.SetPreloadedAssets(originalPreloadedAssets.ToArray()); };

			objects.Clear();
			names.Clear();
		}
	}
}
#endif