using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Hertzole.ALE.Tests
{
	public partial class BaseTest
	{
		private readonly List<GameObject> testObjects = new List<GameObject>();

		[UnitySetUp]
		public IEnumerator SetUp()
		{
			Assert.AreEqual(0, testObjects.Count);

			yield return null;
		}

		[UnityTearDown]
		public IEnumerator TearDown()
		{
			for (int i = 0; i < testObjects.Count; i++)
			{
				if (testObjects[i] != null)
				{
					Object.Destroy(testObjects[i]);
				}
			}

			testObjects.Clear();

			yield return null;
		}

		public GameObject CreateGameObject(string name = "")
		{
			GameObject obj = new GameObject(name);
			testObjects.Add(obj);
			return obj;
		}

		public T CreateObject<T>(string name = "") where T : Component
		{
			GameObject obj = CreateGameObject(name);
			return obj.AddComponent<T>();
		}

		public void DestroyObject(GameObject obj)
		{
			testObjects.Remove(obj);
			Object.Destroy(obj);
		}
	}
}