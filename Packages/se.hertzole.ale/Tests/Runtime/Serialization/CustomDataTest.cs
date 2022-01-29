using System.Collections;
using System.Collections.Generic;
using System.IO;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
	public abstract class CustomDataTest : LevelEditorTest
	{
		private string filePath;

		protected override void OnSceneSetup(List<GameObject> objects)
		{
			filePath = $"{Application.dataPath}/generated__test__save__file.temp";
			saveManager.LevelFormat = GetFormatType();
			objectManager.PoolObjects = false;
		}

		protected override void OnTearDownScene()
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}

		protected abstract LevelEditorSaveManager.FormatType GetFormatType();

		[UnityTest]
		public IEnumerator SaveByte()
		{
			yield return RunTest<CustomDataByte>();
		}
		
		[UnityTest]
		public IEnumerator SaveCustomStructList()
		{
			yield return RunTest<CustomDataCustomStructList>();
		}
		
		[UnityTest]
		public IEnumerator SaveCustomStructDictionary()
		{
			yield return RunTest<CustomDataCustomStructDictionary>();
		}
		
		[UnityTest]
		public IEnumerator SaveCustomStructDictionaryWithList()
		{
			yield return RunTest<CustomDataDictionaryWithList>();
		}

		private IEnumerator RunTest<T>() where T : BaseCustomDataTestScript
		{
			cube.AddComponent<T>();
			cube.gameObject.SetActive(false);

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			newCube.MyGameObject.SetActive(true);

			yield return null;

			saveManager.SaveLevel("temp", filePath);

			objectManager.DeleteAllObjects(false);

			yield return null;

			saveManager.LoadLevel(filePath);

			yield return null;
		}
	}
}