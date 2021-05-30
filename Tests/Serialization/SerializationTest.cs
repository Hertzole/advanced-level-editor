using System.Collections;
using System.Collections.Generic;
using System.IO;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
	public abstract class SerializationTest
	{
		private readonly List<GameObject> sceneObjects = new List<GameObject>();
		private GameObject capsule;

		private GameObject cube;
		private GameObject cylinder;

		private string filePath;
		private LevelEditorObjectManager objectManager;
		private LevelEditorResourceList resources;
		protected LevelEditorSaveManager saveManager;
		private GameObject sphere;

		[UnitySetUp]
		public IEnumerator SetUp()
		{
			filePath = $"{Application.dataPath}/generated__test__save__file.temp";

			CreateResources();
			CreateManagers();
			SetUpWrappers();

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

		private void SetUpWrappers()
		{
			if (!LevelEditorComponentWrapper.HasWrapper<Transform>())
			{
				LevelEditorComponentWrapper.RegisterWrapper<Transform, TransformWrapper>();
			}

			if (!LevelEditorComponentWrapper.HasWrapper<Rigidbody>())
			{
				LevelEditorComponentWrapper.RegisterWrapper<Rigidbody, RigidbodyWrapper>();
			}
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
		public IEnumerator SaveTransform()
		{
			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;

			yield return null;

			TransformWrapper wrapper = newCube.MyGameObject.GetComponent<TransformWrapper>();
			Assert.IsNotNull(wrapper);

			newCube.MyGameObject.transform.position = new Vector3(10, 20, 30);
			newCube.MyGameObject.transform.eulerAngles = new Vector3(40, 50, 60);
			newCube.MyGameObject.transform.localScale = new Vector3(1, 2, 3);

			newCube.Parent = newSphere;
			newSphere.AddChild(newCube);
			newCube.MyGameObject.transform.SetParent(newSphere.MyGameObject.transform);

			Save();

			yield return null;

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);

			Assert.IsNotNull(newCube.MyGameObject);
			Assert.IsNotNull(newSphere.MyGameObject);

			AreApproximatelyEqual(new Vector3(10, 20, 30), newCube.MyGameObject.transform.position);
			AreApproximatelyEqual(new Vector3(40, 50, 60), newCube.MyGameObject.transform.eulerAngles);
			AreApproximatelyEqual(new Vector3(1, 2, 3), newCube.MyGameObject.transform.localScale);
			Assert.AreEqual(newSphere.MyGameObject.transform, newCube.MyGameObject.transform.parent);
		}

		[UnityTest]
		public IEnumerator SaveRigidbody()
		{
			cube.AddComponent<Rigidbody>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));

			uint newCubeId = newCube.InstanceID;

			yield return null;

			Rigidbody rb = newCube.MyGameObject.GetComponent<Rigidbody>();
			RigidbodyWrapper wrapper = newCube.MyGameObject.GetComponent<RigidbodyWrapper>();
			Assert.IsNotNull(rb);
			Assert.IsNotNull(wrapper);

			rb.mass = 10;
			rb.drag = 20;
			rb.angularDrag = 30;
			rb.useGravity = false;
			rb.isKinematic = true;

			Save();

			yield return null;

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			rb = newCube.MyGameObject.GetComponent<Rigidbody>();

			Assert.IsNotNull(rb);

			Assert.AreApproximatelyEqual(10, rb.mass);
			Assert.AreApproximatelyEqual(20, rb.drag);
			Assert.AreApproximatelyEqual(30, rb.angularDrag);
			Assert.AreEqual(false, rb.useGravity);
			Assert.AreEqual(true, rb.isKinematic);
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

			ByteTest1 byte1 = newCube.MyGameObject.GetComponent<ByteTest1>();
			byte1.value = 5;
			ByteTest2 byte2 = newCube.MyGameObject.GetComponent<ByteTest2>();
			byte2.value = 6;
			ByteTest3 byte3 = newCube.MyGameObject.GetComponent<ByteTest3>();
			byte3.value1 = 3;
			byte3.value2 = 4;
			ByteTest4 byte4 = newCube.MyGameObject.GetComponent<ByteTest4>();
			byte4.value1 = 10;
			byte4.value2 = 20;
			ByteTest5 byte5 = newCube.MyGameObject.GetComponent<ByteTest5>();
			byte5.Value = 5;
			ByteTest6 byte6 = newCube.MyGameObject.GetComponent<ByteTest6>();
			byte6.Value = 6;
			ByteTest7 byte7 = newCube.MyGameObject.GetComponent<ByteTest7>();
			byte7.Value1 = 3;
			byte7.Value2 = 4;
			ByteTest8 byte8 = newCube.MyGameObject.GetComponent<ByteTest8>();
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

			Vector3Test1 vector1 = newCube.MyGameObject.GetComponent<Vector3Test1>();
			vector1.value = Vector3.one;
			Vector3Test2 vector2 = newCube.MyGameObject.GetComponent<Vector3Test2>();
			vector2.value = Vector3.one;
			Vector3Test3 vector3 = newCube.MyGameObject.GetComponent<Vector3Test3>();
			vector3.value1 = Vector3.one;
			vector3.value2 = Vector3.one;
			Vector3Test4 vector4 = newCube.MyGameObject.GetComponent<Vector3Test4>();
			vector4.value1 = Vector3.one;
			vector4.value2 = Vector3.one;
			Vector3Test5 vector5 = newCube.MyGameObject.GetComponent<Vector3Test5>();
			vector5.Value = Vector3.one;
			Vector3Test6 vector6 = newCube.MyGameObject.GetComponent<Vector3Test6>();
			vector6.Value = Vector3.one;
			Vector3Test7 vector7 = newCube.MyGameObject.GetComponent<Vector3Test7>();
			vector7.Value1 = Vector3.one;
			vector7.Value2 = Vector3.one;
			Vector3Test8 vector8 = newCube.MyGameObject.GetComponent<Vector3Test8>();
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
			Assert.AreEqual(Vector3.one, vector1.value, "Vector3 1 field value failed.");
			vector2 = newCube.MyGameObject.GetComponent<Vector3Test2>();
			Assert.AreEqual(Vector3.one, vector2.value, "Vector3 2 field value failed.");
			vector3 = newCube.MyGameObject.GetComponent<Vector3Test3>();
			Assert.AreEqual(Vector3.one, vector3.value1, "Vector3 3 field value 1 failed.");
			Assert.AreEqual(Vector3.one, vector3.value2, "Vector3 3 field value 2 failed.");
			vector4 = newCube.MyGameObject.GetComponent<Vector3Test4>();
			Assert.AreEqual(Vector3.one, vector4.value1, "Vector3 4 field value 1 failed.");
			Assert.AreEqual(Vector3.one, vector4.value2, "Vector3 4 field value 2 failed.");

			vector5 = newCube.MyGameObject.GetComponent<Vector3Test5>();
			Assert.AreEqual(Vector3.one, vector5.Value, "Vector3 5 property value failed.");
			vector6 = newCube.MyGameObject.GetComponent<Vector3Test6>();
			Assert.AreEqual(Vector3.one, vector6.Value, "Vector3 6 property value failed.");
			vector7 = newCube.MyGameObject.GetComponent<Vector3Test7>();
			Assert.AreEqual(Vector3.one, vector7.Value1, "Vector3 7 property value 1 failed.");
			Assert.AreEqual(Vector3.one, vector7.Value2, "Vector3 7 property value 2 failed.");
			vector8 = newCube.MyGameObject.GetComponent<Vector3Test8>();
			Assert.AreEqual(Vector3.one, vector8.Value1, "Vector3 8 property value 1 failed.");
			Assert.AreEqual(Vector3.one, vector8.Value2, "Vector3 8 property value 2 failed.");
		}

		[UnityTest]
		public IEnumerator SaveTransformReference()
		{
			cube.AddComponent<TransformReferenceScript>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			TransformReferenceScript trsRef = newCube.MyGameObject.GetComponent<TransformReferenceScript>();
			trsRef.value = newSphere.MyGameObject.transform;
			trsRef.Value = newCapsule.MyGameObject.transform;

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRef = newCube.MyGameObject.GetComponent<TransformReferenceScript>();
			Assert.AreEqual(newSphere.MyGameObject.transform, trsRef.value);
			Assert.AreEqual(newCapsule.MyGameObject.transform, trsRef.Value);
		}

		[UnityTest]
		public IEnumerator SaveTransformReferenceArray()
		{
			cube.AddComponent<TransformReferenceArrayScript>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			TransformReferenceArrayScript trsRefArray = newCube.MyGameObject.GetComponent<TransformReferenceArrayScript>();
			trsRefArray.value = new[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform };
			trsRefArray.Value = new[] { newCapsule.MyGameObject.transform, newSphere.MyGameObject.transform };

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRefArray = newCube.MyGameObject.GetComponent<TransformReferenceArrayScript>();
			Assert.IsTrue(trsRefArray.value.IsSameAs(new[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform }));
			Assert.IsTrue(trsRefArray.Value.IsSameAs(new[] { newCapsule.MyGameObject.transform, newSphere.MyGameObject.transform }));
		}

		[UnityTest]
		public IEnumerator SaveTransformReferenceList()
		{
			cube.AddComponent<TransformReferenceListScript>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			TransformReferenceListScript trsRefList = newCube.MyGameObject.GetComponent<TransformReferenceListScript>();
			trsRefList.value.Add(newSphere.MyGameObject.transform);
			trsRefList.value.Add(newCapsule.MyGameObject.transform);
			trsRefList.Value.Add(newCapsule.MyGameObject.transform);
			trsRefList.Value.Add(newCube.MyGameObject.transform);

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRefList = newCube.MyGameObject.GetComponent<TransformReferenceListScript>();
			Assert.IsTrue(trsRefList.value.IsSameAs(new List<Transform>
				{ newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform }));

			Assert.IsTrue(trsRefList.Value.IsSameAs(new List<Transform>
				{ newCapsule.MyGameObject.transform, newCube.MyGameObject.transform }));
		}

		[UnityTest]
		public IEnumerator SaveGameObjectReference()
		{
			cube.AddComponent<GameObjectReferenceScript>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			GameObjectReferenceScript trsRef = newCube.MyGameObject.GetComponent<GameObjectReferenceScript>();
			trsRef.value = newSphere.MyGameObject;
			trsRef.Value = newCapsule.MyGameObject;

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRef = newCube.MyGameObject.GetComponent<GameObjectReferenceScript>();
			Assert.AreEqual(newSphere.MyGameObject, trsRef.value);
			Assert.AreEqual(newCapsule.MyGameObject, trsRef.Value);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectReferenceArray()
		{
			cube.AddComponent<GameObjectReferenceArrayScript>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			GameObjectReferenceArrayScript trsRefArray = newCube.MyGameObject.GetComponent<GameObjectReferenceArrayScript>();
			trsRefArray.value = new[] { newSphere.MyGameObject, newCapsule.MyGameObject };
			trsRefArray.Value = new[] { newCapsule.MyGameObject, newSphere.MyGameObject };

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRefArray = newCube.MyGameObject.GetComponent<GameObjectReferenceArrayScript>();
			Assert.IsTrue(trsRefArray.value.IsSameAs(new[] { newSphere.MyGameObject, newCapsule.MyGameObject }));
			Assert.IsTrue(trsRefArray.Value.IsSameAs(new[] { newCapsule.MyGameObject, newSphere.MyGameObject }));
		}

		[UnityTest]
		public IEnumerator SaveGameObjectReferenceList()
		{
			cube.AddComponent<GameObjectReferenceListScript>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			GameObjectReferenceListScript trsRefList = newCube.MyGameObject.GetComponent<GameObjectReferenceListScript>();
			trsRefList.value.Add(newSphere.MyGameObject);
			trsRefList.value.Add(newCapsule.MyGameObject);
			trsRefList.Value.Add(newCapsule.MyGameObject);
			trsRefList.Value.Add(newCube.MyGameObject);

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRefList = newCube.MyGameObject.GetComponent<GameObjectReferenceListScript>();
			Assert.IsTrue(trsRefList.value.IsSameAs(new List<GameObject>
				{ newSphere.MyGameObject, newCapsule.MyGameObject }));

			Assert.IsTrue(trsRefList.Value.IsSameAs(new List<GameObject>
				{ newCapsule.MyGameObject, newCube.MyGameObject }));
		}

		[UnityTest]
		public IEnumerator SaveScriptReference()
		{
			cube.AddComponent<TempTestScriptReferenceScript>();
			sphere.AddComponent<TempTestScript>();
			capsule.AddComponent<TempTestScript>();
			cylinder.AddComponent<TempTestScript>();

			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			TempTestScriptReferenceScript trsRef = newCube.MyGameObject.GetComponent<TempTestScriptReferenceScript>();
			trsRef.value = newSphere.MyGameObject.GetComponent<TempTestScript>();
			trsRef.Value = newCapsule.MyGameObject.GetComponent<TempTestScript>();

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRef = newCube.MyGameObject.GetComponent<TempTestScriptReferenceScript>();
			Assert.AreEqual(newSphere.MyGameObject.GetComponent<TempTestScript>(), trsRef.value);
			Assert.AreEqual(newCapsule.MyGameObject.GetComponent<TempTestScript>(), trsRef.Value);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArray()
		{
			cube.AddComponent<TempTestScriptReferenceArrayScript>();
			sphere.AddComponent<TempTestScript>();
			capsule.AddComponent<TempTestScript>();
			cylinder.AddComponent<TempTestScript>();
			
			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;

			TempTestScriptReferenceArrayScript trsRefArray = newCube.MyGameObject.GetComponent<TempTestScriptReferenceArrayScript>();
			trsRefArray.value = new[] { newSphere.MyGameObject.GetComponent<TempTestScript>(), newCapsule.MyGameObject.GetComponent<TempTestScript>() };
			trsRefArray.Value = new[] { newCapsule.MyGameObject.GetComponent<TempTestScript>(), newSphere.MyGameObject.GetComponent<TempTestScript>() };

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);

			trsRefArray = newCube.MyGameObject.GetComponent<TempTestScriptReferenceArrayScript>();
			Assert.IsTrue(trsRefArray.value.IsSameAs(new[] { newSphere.MyGameObject.GetComponent<TempTestScript>(), newCapsule.MyGameObject.GetComponent<TempTestScript>() }));
			Assert.IsTrue(trsRefArray.Value.IsSameAs(new[] { newCapsule.MyGameObject.GetComponent<TempTestScript>(), newSphere.MyGameObject.GetComponent<TempTestScript>() }));
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceList()
		{
			cube.AddComponent<TempTestScriptReferenceListScript>();
			sphere.AddComponent<TempTestScript>();
			capsule.AddComponent<TempTestScript>();
			cylinder.AddComponent<TempTestScript>();
			
			ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
			ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
			ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));
			ILevelEditorObject newCylinder = objectManager.CreateObject(resources.GetResource("cylinder"));

			uint newCubeId = newCube.InstanceID;
			uint newSphereId = newSphere.InstanceID;
			uint newCapsuleId = newCapsule.InstanceID;
			uint newCylinderId = newCylinder.InstanceID;

			TempTestScriptReferenceListScript trsRefList = newCube.MyGameObject.GetComponent<TempTestScriptReferenceListScript>();
			trsRefList.value.Add(newSphere.MyGameObject.GetComponent<TempTestScript>());
			trsRefList.value.Add(newCapsule.MyGameObject.GetComponent<TempTestScript>());
			trsRefList.Value.Add(newCapsule.MyGameObject.GetComponent<TempTestScript>());
			trsRefList.Value.Add(newCylinder.MyGameObject.GetComponent<TempTestScript>());

			yield return null;

			Save();

			objectManager.DeleteAllObjects();

			yield return null;

			Load();

			yield return null;

			newCube = objectManager.GetObject(newCubeId);
			newSphere = objectManager.GetObject(newSphereId);
			newCapsule = objectManager.GetObject(newCapsuleId);
			newCylinder = objectManager.GetObject(newCylinderId);

			trsRefList = newCube.MyGameObject.GetComponent<TempTestScriptReferenceListScript>();
			Assert.IsTrue(trsRefList.value.IsSameAs(new List<TempTestScript>
				{ newSphere.MyGameObject.GetComponent<TempTestScript>(), newCapsule.MyGameObject.GetComponent<TempTestScript>() }));

			Assert.IsTrue(trsRefList.Value.IsSameAs(new List<TempTestScript>
				{ newCapsule.MyGameObject.GetComponent<TempTestScript>(), newCylinder.MyGameObject.GetComponent<TempTestScript>() }));
		}

		private void Save()
		{
			saveManager.SaveLevel("Test Level", filePath);
		}

		private void Load()
		{
			saveManager.LoadLevel(filePath);
		}

		private void AreApproximatelyEqual(Vector3 expected, Vector3 actual)
		{
			Assert.AreApproximatelyEqual(expected.x, actual.x);
			Assert.AreApproximatelyEqual(expected.y, actual.y);
			Assert.AreApproximatelyEqual(expected.z, actual.z);
		}

		private void AreApproximatelyEqual(Vector3 expected, Vector3 actual, float tolerance)
		{
			Assert.AreApproximatelyEqual(expected.x, actual.x, tolerance);
			Assert.AreApproximatelyEqual(expected.y, actual.y, tolerance);
			Assert.AreApproximatelyEqual(expected.z, actual.z, tolerance);
		}
	}
}