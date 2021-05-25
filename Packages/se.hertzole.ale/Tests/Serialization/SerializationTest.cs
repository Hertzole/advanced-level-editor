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

		// [Test]
		// public void SaveDataSerialization()
		// {
		//     LevelEditorSaveData data = BuildSaveData();
		//
		//     LevelEditorSaveData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void CustomDataSerialization()
		// {
		//     LevelEditorCustomData data = BuildCustomData();
		//
		//     LevelEditorCustomData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void CustomDataArraySerialization()
		// {
		//     LevelEditorCustomData data = BuildCustomData();
		//     data.type = typeof(string[]);
		//     data.typeName = typeof(string[]).FullName;
		//     data.value = new string[] { "Hello", "World" };
		//
		//     LevelEditorSerializer.RegisterType<string[]>();
		//
		//     LevelEditorCustomData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void ObjectDataSerialization()
		// {
		//     LevelEditorObjectData data = BuildObjectData();
		//
		//     LevelEditorObjectData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void ComponentDataSerialization()
		// {
		//     LevelEditorComponentData data = BuildComponentData();
		//
		//     LevelEditorComponentData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataSerialization()
		// {
		//     LevelEditorPropertyData data = BuildPropertyData();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataStringSerialization()
		// {
		//     LevelEditorPropertyData data = BuildPropertyData();
		//     data.typeName = typeof(string).FullName;
		//     data.type = typeof(string);
		//     data.value = "Hello world";
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataIntSerialization()
		// {
		//     LevelEditorPropertyData data = BuildPropertyData();
		//     data.typeName = typeof(int).FullName;
		//     data.type = typeof(int);
		//     data.value = 65;
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }

		// [Test]
		// public void PropertyDataComponentSerialization()
		// {
		//     LevelEditorPropertyData data = BuildPropertyData();
		//     data.typeName = typeof(Component).FullName;
		//     data.type = typeof(Component);
		//     data.value = null;
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }

		// [Test]
		// public void PropertyDataArraySerialization()
		// {
		//     ExposedArray array = new ExposedArray(0, typeof(string[]), "test", null, true, typeof(string));
		//     LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
		//     {
		//         value = new string[] { "Hello", "World" }
		//     };
		//
		//     LevelEditorSerializer.RegisterType<string[]>();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataListSerialization()
		// {
		//     ExposedArray array = new ExposedArray(0, typeof(List<string>), "test", null, true, typeof(string));
		//     LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
		//     {
		//         value = new List<string>() { "Hello", "World" }
		//     };
		//
		//     LevelEditorSerializer.RegisterType<List<string>>();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }

		// [Test]
		// public void PropertyDataComponentArraySerialization()
		// {
		//     ExposedArray array = new ExposedArray(0, typeof(Component[]), "test", null, true, typeof(Component));
		//     LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
		//     {
		//         value = new ComponentDataWrapper[0]
		//     };
		//
		//     LevelEditorSerializer.RegisterType<ComponentDataWrapper[]>();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataComponentListSerialization()
		// {
		//     ExposedArray array = new ExposedArray(0, typeof(List<Component>), "test", null, true, typeof(List<Component>));
		//     LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
		//     {
		//         value = new List<ComponentDataWrapper>()
		//     };
		//
		//     LevelEditorSerializer.RegisterType<List<ComponentDataWrapper>>();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataTransformArraySerialization()
		// {
		//     ExposedArray array = new ExposedArray(0, typeof(Transform[]), "test", null, true, typeof(Transform));
		//     LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
		//     {
		//         value = new ComponentDataWrapper[1]
		//     };
		//
		//     LevelEditorSerializer.RegisterType<ComponentDataWrapper[]>();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataGameObjectArraySerialization()
		// {
		//     ExposedArray array = new ExposedArray(0, typeof(GameObject[]), "test", null, true, typeof(GameObject));
		//     LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
		//     {
		//         value = new ComponentDataWrapper[1]
		//     };
		//
		//     LevelEditorSerializer.RegisterType<ComponentDataWrapper[]>();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }
		//
		// [Test]
		// public void PropertyDataGameObjectListSerialization()
		// {
		//     ExposedArray array = new ExposedArray(0, typeof(List<GameObject>), "test", null, true, typeof(GameObject));
		//     LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
		//     {
		//         value = new List<ComponentDataWrapper>()
		//     };
		//
		//     LevelEditorSerializer.RegisterType<List<ComponentDataWrapper>>();
		//
		//     LevelEditorPropertyData newData = SerializeAndDeserialize(data);
		//     Assert.AreEqual(data, newData);
		// }

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