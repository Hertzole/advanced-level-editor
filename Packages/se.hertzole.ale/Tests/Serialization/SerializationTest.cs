using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using UnityEngine.Windows;

namespace Hertzole.ALE.Tests
{
	public abstract class SerializationTest
	{
		private readonly List<GameObject> sceneObjects = new List<GameObject>();
		private LevelEditorResourceList resources;
		private LevelEditorObjectManager objectManager;
		protected LevelEditorSaveManager saveManager;

		private GameObject cube;
		private GameObject sphere;
		private GameObject capsule;
		private GameObject cylinder;

		private string filePath;

		[UnitySetUp]
		public IEnumerator SetUp()
		{
			filePath = $"{Application.dataPath}/generated__test__save__file.temp";
			
			CreateResources();
			CreateManagers();
			
			OnSetUp();

			yield return null;
		}

		protected virtual void OnSetUp() { }

		private void CreateResources()
		{
			resources = ScriptableObject.CreateInstance<LevelEditorResourceList>();

			cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

			sceneObjects.Add(cube);
			sceneObjects.Add(sphere);
			sceneObjects.Add(capsule);
			sceneObjects.Add(cylinder);

			LevelEditorResource cubeResource = new LevelEditorResource
			{
				Name = "Cube",
				Asset = cube,
				ID = "cube"
			};

			LevelEditorResource sphereResource = new LevelEditorResource
			{
				Name = "Sphere",
				Asset = sphere,
				ID = "sphere"
			};
			
			LevelEditorResource capsuleResource = new LevelEditorResource
			{
				Name = "Capsule",
				Asset = capsule,
				ID = "capsule"
			};
			
			LevelEditorResource cylinderResource = new LevelEditorResource
			{
				Name = "Cylinder",
				Asset = cylinder,
				ID = "cylinder"
			};

			resources.AddResource(cubeResource);
			resources.AddResource(sphereResource);
			resources.AddResource(capsuleResource);
			resources.AddResource(cylinderResource);
		}

		private void CreateManagers()
		{
			GameObject objectManagerGo = new GameObject("Object Manager");
			objectManager = objectManagerGo.AddComponent<LevelEditorObjectManager>();
			objectManager.Resources = resources;
			objectManager.PoolObjects = false;

			sceneObjects.Add(objectManagerGo);

			GameObject saveManagerGo = new GameObject("Save Manager");
			saveManager = saveManagerGo.AddComponent<LevelEditorSaveManager>();
			saveManager.ObjectManager = objectManager;
			
			sceneObjects.Add(saveManagerGo);
		}

		[UnityTearDown]
		public IEnumerator TearDown()
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}

			objectManager.DeleteAllObjects(false);
			
			Object.DestroyImmediate(resources);

			for (int i = 0; i < sceneObjects.Count; i++)
			{
				Object.DestroyImmediate(sceneObjects[i]);
			}

			sceneObjects.Clear();

			yield return null;
		}

		[UnityTest]
		public IEnumerator SaveByte()
		{
			cube.AddComponent<ByteTest1>();
			cube.AddComponent<ByteTest2>();
			cube.AddComponent<ByteTest3>();
			cube.AddComponent<ByteTest4>();
			cube.AddComponent<ByteTest5>();
			cube.AddComponent<ByteTest6>();
			cube.AddComponent<ByteTest7>();
			cube.AddComponent<ByteTest8>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			uint cubeId = newCube.InstanceID;
			
			ByteTest1 byte1 = newCube.MyGameObject.AddComponent<ByteTest1>();
			byte1.value = 5;
			ByteTest2 byte2 = newCube.MyGameObject.AddComponent<ByteTest2>();
			byte2.value = 6;
			ByteTest3 byte3 = newCube.MyGameObject.AddComponent<ByteTest3>();
			byte3.value1 = 3;
			byte3.value2 = 4;
			ByteTest4 byte4 = newCube.MyGameObject.AddComponent<ByteTest4>();
			byte4.value1 = 10;
			byte4.value2 = 20;
			ByteTest5 byte5 = newCube.MyGameObject.AddComponent<ByteTest5>();
			byte5.Value = 5;
			ByteTest6 byte6 = newCube.MyGameObject.AddComponent<ByteTest6>();
			byte6.Value = 6;
			ByteTest7 byte7 = newCube.MyGameObject.AddComponent<ByteTest7>();
			byte7.Value1 = 3;
			byte7.Value2 = 4;
			ByteTest8 byte8 = newCube.MyGameObject.AddComponent<ByteTest8>();
			byte8.Value1 = 10;
			byte8.Value2 = 20;

			yield return null;
			
			Save();
			objectManager.DeleteAllObjects();
			
			yield return null;
			
			Load();

			yield return null;

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube);

			byte1 = newCube.MyGameObject.GetComponent<ByteTest1>();
			Assert.AreEqual<byte>(5, byte1.value, "Byte 1 field value failed.");
			byte2 = newCube.MyGameObject.GetComponent<ByteTest2>();
			Assert.AreEqual<byte>(6, byte2.value, "Byte 2 field value failed.");
			byte3 = newCube.MyGameObject.GetComponent<ByteTest3>();
			Assert.AreEqual<byte>(3, byte3.value1, "Byte 3 field value 1 failed.");
			Assert.AreEqual<byte>(4, byte3.value2, "Byte 3 field value 2 failed.");
			byte4 = newCube.MyGameObject.GetComponent<ByteTest4>();
			Assert.AreEqual<byte>(10, byte4.value1, "Byte 4 field value 1 failed.");
			Assert.AreEqual<byte>(20, byte4.value2, "Byte 4 field value 2 failed.");
			
			byte5 = newCube.MyGameObject.GetComponent<ByteTest5>();
			Assert.AreEqual<byte>(5, byte5.Value, "Byte 5 property value failed.");
			byte6 = newCube.MyGameObject.GetComponent<ByteTest6>();
			Assert.AreEqual<byte>(6, byte6.Value, "Byte 6 property value failed.");
			byte7 = newCube.MyGameObject.GetComponent<ByteTest7>();
			Assert.AreEqual<byte>(3, byte7.Value1, "Byte 7 property value 1 failed.");
			Assert.AreEqual<byte>(4, byte7.Value2, "Byte 7 property value 2 failed.");
			byte8 = newCube.MyGameObject.GetComponent<ByteTest8>();
			Assert.AreEqual<byte>(10, byte8.Value1, "Byte 8 property value 1 failed.");
			Assert.AreEqual<byte>(20, byte8.Value2, "Byte 8 property value 2 failed.");
		}
		
		[UnityTest]
		public IEnumerator SaveVector3()
		{
			cube.AddComponent<Vector3Test1>();
			cube.AddComponent<Vector3Test2>();
			cube.AddComponent<Vector3Test3>();
			cube.AddComponent<Vector3Test4>();
			cube.AddComponent<Vector3Test5>();
			cube.AddComponent<Vector3Test6>();
			cube.AddComponent<Vector3Test7>();
			cube.AddComponent<Vector3Test8>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			uint cubeId = newCube.InstanceID;
			
			Vector3Test1 vector1 = newCube.MyGameObject.AddComponent<Vector3Test1>();
			vector1.value = Vector3.one;
			Vector3Test2 vector2 = newCube.MyGameObject.AddComponent<Vector3Test2>();
			vector2.value = Vector3.one;
			Vector3Test3 vector3 = newCube.MyGameObject.AddComponent<Vector3Test3>();
			vector3.value1 = Vector3.one;
			vector3.value2 = Vector3.one;
			Vector3Test4 vector4 = newCube.MyGameObject.AddComponent<Vector3Test4>();
			vector4.value1 = Vector3.one;
			vector4.value2 = Vector3.one;
			Vector3Test5 vector5 = newCube.MyGameObject.AddComponent<Vector3Test5>();
			vector5.Value = Vector3.one;
			Vector3Test6 vector6 = newCube.MyGameObject.AddComponent<Vector3Test6>();
			vector6.Value = Vector3.one;
			Vector3Test7 vector7 = newCube.MyGameObject.AddComponent<Vector3Test7>();
			vector7.Value1 = Vector3.one;
			vector7.Value2 = Vector3.one;
			Vector3Test8 vector8 = newCube.MyGameObject.AddComponent<Vector3Test8>();
			vector8.Value1 = Vector3.one;
			vector8.Value2 = Vector3.one;

			yield return null;
			
			Save();
			objectManager.DeleteAllObjects();
			
			yield return null;
			
			Load();

			yield return null;

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube);

			vector1 = newCube.MyGameObject.GetComponent<Vector3Test1>();
			Assert.AreEqual<Vector3>(Vector3.one, vector1.value, "Vector3 1 field value failed.");
			vector2 = newCube.MyGameObject.GetComponent<Vector3Test2>();
			Assert.AreEqual<Vector3>(Vector3.one, vector2.value, "Vector3 2 field value failed.");
			vector3 = newCube.MyGameObject.GetComponent<Vector3Test3>();
			Assert.AreEqual<Vector3>(Vector3.one, vector3.value1, "Vector3 3 field value 1 failed.");
			Assert.AreEqual<Vector3>(Vector3.one, vector3.value2, "Vector3 3 field value 2 failed.");
			vector4 = newCube.MyGameObject.GetComponent<Vector3Test4>();
			Assert.AreEqual<Vector3>(Vector3.one, vector4.value1, "Vector3 4 field value 1 failed.");
			Assert.AreEqual<Vector3>(Vector3.one, vector4.value2, "Vector3 4 field value 2 failed.");
			
			vector5 = newCube.MyGameObject.GetComponent<Vector3Test5>();
			Assert.AreEqual<Vector3>(Vector3.one, vector5.Value, "Vector3 5 property value failed.");
			vector6 = newCube.MyGameObject.GetComponent<Vector3Test6>();
			Assert.AreEqual<Vector3>(Vector3.one, vector6.Value, "Vector3 6 property value failed.");
			vector7 = newCube.MyGameObject.GetComponent<Vector3Test7>();
			Assert.AreEqual<Vector3>(Vector3.one, vector7.Value1, "Vector3 7 property value 1 failed.");
			Assert.AreEqual<Vector3>(Vector3.one, vector7.Value2, "Vector3 7 property value 2 failed.");
			vector8 = newCube.MyGameObject.GetComponent<Vector3Test8>();
			Assert.AreEqual<Vector3>(Vector3.one, vector8.Value1, "Vector3 8 property value 1 failed.");
			Assert.AreEqual<Vector3>(Vector3.one, vector8.Value2, "Vector3 8 property value 2 failed.");
		}

		private void Save()
		{
			saveManager.SaveLevel("Test Level", filePath);
		}

		private void Load()
		{
			saveManager.LoadLevel(filePath);
		}
	}
}