using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Hertzole.ALE.Tests
{
	public abstract class SerializationTest : LevelEditorTest
	{
		private string filePath;

		public const int VALUE_0_ID = 0;
		public const int VALUE_5_ID = 5;
		public const int VALUE_10_ID = 10;
		public const int VALUE_100_ID = 100;

		protected override void OnSceneSetup(List<GameObject> objects)
		{
			filePath = $"{Application.dataPath}/generated__test__save__file.temp";
			objectManager.PoolObjects = false;
			OnSetUp();
		}

		protected abstract void OnSetUp();

		protected override void OnTearDownScene()
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}

	

		// [UnityTest]
		// public IEnumerator SaveTransform()
		// {
		// 	ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
		// 	ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
		//
		// 	uint newCubeId = newCube.InstanceID;
		// 	uint newSphereId = newSphere.InstanceID;
		//
		// 	yield return null;
		//
		// 	TransformWrapper wrapper = newCube.MyGameObject.GetComponent<TransformWrapper>();
		// 	Assert.IsNotNull(wrapper);
		//
		// 	newCube.MyGameObject.transform.position = new Vector3(10, 20, 30);
		// 	newCube.MyGameObject.transform.eulerAngles = new Vector3(40, 50, 60);
		// 	newCube.MyGameObject.transform.localScale = new Vector3(1, 2, 3);
		//
		// 	newCube.Parent = newSphere;
		// 	newSphere.AddChild(newCube);
		// 	newCube.MyGameObject.transform.SetParent(newSphere.MyGameObject.transform);
		//
		// 	Save();
		//
		// 	yield return null;
		//
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(newCubeId);
		// 	newSphere = objectManager.GetObject(newSphereId);
		//
		// 	Assert.IsNotNull(newCube.MyGameObject);
		// 	Assert.IsNotNull(newSphere.MyGameObject);
		//
		// 	AreApproximatelyEqual(new Vector3(10, 20, 30), newCube.MyGameObject.transform.position);
		// 	AreApproximatelyEqual(new Vector3(40, 50, 60), newCube.MyGameObject.transform.eulerAngles);
		// 	AreApproximatelyEqual(new Vector3(1, 2, 3), newCube.MyGameObject.transform.localScale);
		// 	Assert.AreEqual(newSphere.MyGameObject.transform, newCube.MyGameObject.transform.parent);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveRigidbody()
		// {
		// 	cube.AddComponent<Rigidbody>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
		//
		// 	uint newCubeId = newCube.InstanceID;
		//
		// 	yield return null;
		//
		// 	Rigidbody rb = newCube.MyGameObject.GetComponent<Rigidbody>();
		// 	RigidbodyWrapper wrapper = newCube.MyGameObject.GetComponent<RigidbodyWrapper>();
		// 	Assert.IsNotNull(rb);
		// 	Assert.IsNotNull(wrapper);
		//
		// 	rb.mass = 10;
		// 	rb.drag = 20;
		// 	rb.angularDrag = 30;
		// 	rb.useGravity = false;
		// 	rb.isKinematic = true;
		//
		// 	Save();
		//
		// 	yield return null;
		//
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(newCubeId);
		// 	rb = newCube.MyGameObject.GetComponent<Rigidbody>();
		//
		// 	Assert.IsNotNull(rb);
		//
		// 	Assert.AreApproximatelyEqual(10, rb.mass);
		// 	Assert.AreApproximatelyEqual(20, rb.drag);
		// 	Assert.AreApproximatelyEqual(30, rb.angularDrag);
		// 	Assert.AreEqual(false, rb.useGravity);
		// 	Assert.AreEqual(true, rb.isKinematic);
		// }

		// [UnityTest]
		// public IEnumerator SaveByte()
		// {
		// 	cube.AddComponent<ByteTest1>();
		// 	cube.AddComponent<ByteTest2>();
		// 	cube.AddComponent<ByteTest3>();
		// 	cube.AddComponent<ByteTest4>();
		// 	cube.AddComponent<ByteTest5>();
		// 	cube.AddComponent<ByteTest6>();
		// 	cube.AddComponent<ByteTest7>();
		// 	cube.AddComponent<ByteTest8>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	ByteTest1 byte1 = newCube.MyGameObject.GetComponent<ByteTest1>();
		// 	byte1.value = 5;
		// 	ByteTest2 byte2 = newCube.MyGameObject.GetComponent<ByteTest2>();
		// 	byte2.value = 6;
		// 	ByteTest3 byte3 = newCube.MyGameObject.GetComponent<ByteTest3>();
		// 	byte3.value1 = 3;
		// 	byte3.value2 = 4;
		// 	ByteTest4 byte4 = newCube.MyGameObject.GetComponent<ByteTest4>();
		// 	byte4.value1 = 10;
		// 	byte4.value2 = 20;
		// 	ByteTest5 byte5 = newCube.MyGameObject.GetComponent<ByteTest5>();
		// 	byte5.Value = 5;
		// 	ByteTest6 byte6 = newCube.MyGameObject.GetComponent<ByteTest6>();
		// 	byte6.Value = 6;
		// 	ByteTest7 byte7 = newCube.MyGameObject.GetComponent<ByteTest7>();
		// 	byte7.Value1 = 3;
		// 	byte7.Value2 = 4;
		// 	ByteTest8 byte8 = newCube.MyGameObject.GetComponent<ByteTest8>();
		// 	byte8.Value1 = 10;
		// 	byte8.Value2 = 20;
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	byte1 = newCube.MyGameObject.GetComponent<ByteTest1>();
		// 	Assert.AreEqual<byte>(5, byte1.value, "Byte 1 field value failed.");
		// 	byte2 = newCube.MyGameObject.GetComponent<ByteTest2>();
		// 	Assert.AreEqual<byte>(6, byte2.value, "Byte 2 field value failed.");
		// 	byte3 = newCube.MyGameObject.GetComponent<ByteTest3>();
		// 	Assert.AreEqual<byte>(3, byte3.value1, "Byte 3 field value 1 failed.");
		// 	Assert.AreEqual<byte>(4, byte3.value2, "Byte 3 field value 2 failed.");
		// 	byte4 = newCube.MyGameObject.GetComponent<ByteTest4>();
		// 	Assert.AreEqual<byte>(10, byte4.value1, "Byte 4 field value 1 failed.");
		// 	Assert.AreEqual<byte>(20, byte4.value2, "Byte 4 field value 2 failed.");
		//
		// 	byte5 = newCube.MyGameObject.GetComponent<ByteTest5>();
		// 	Assert.AreEqual<byte>(5, byte5.Value, "Byte 5 property value failed.");
		// 	byte6 = newCube.MyGameObject.GetComponent<ByteTest6>();
		// 	Assert.AreEqual<byte>(6, byte6.Value, "Byte 6 property value failed.");
		// 	byte7 = newCube.MyGameObject.GetComponent<ByteTest7>();
		// 	Assert.AreEqual<byte>(3, byte7.Value1, "Byte 7 property value 1 failed.");
		// 	Assert.AreEqual<byte>(4, byte7.Value2, "Byte 7 property value 2 failed.");
		// 	byte8 = newCube.MyGameObject.GetComponent<ByteTest8>();
		// 	Assert.AreEqual<byte>(10, byte8.Value1, "Byte 8 property value 1 failed.");
		// 	Assert.AreEqual<byte>(20, byte8.Value2, "Byte 8 property value 2 failed.");
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveByteList()
		// {
		// 	cube.AddComponent<ByteListTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	ByteListTest bytes = newCube.MyGameObject.GetComponent<ByteListTest>();
		// 	bytes.value = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	bytes = newCube.MyGameObject.GetComponent<ByteListTest>();
		// 	Assert.IsTrue(bytes.value.IsSameAs(new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
		// }

		// [UnityTest]
		// public IEnumerator SaveTransformReference()
		// {
		// 	cube.AddComponent<TransformReferenceScript>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
		// 	ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
		// 	ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));
		//
		// 	uint newCubeId = newCube.InstanceID;
		// 	uint newSphereId = newSphere.InstanceID;
		// 	uint newCapsuleId = newCapsule.InstanceID;
		//
		// 	TransformReferenceScript trsRef = newCube.MyGameObject.GetComponent<TransformReferenceScript>();
		// 	trsRef.value = newSphere.MyGameObject.transform;
		// 	trsRef.Value = newCapsule.MyGameObject.transform;
		//
		// 	yield return null;
		//
		// 	Save();
		//
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(newCubeId);
		// 	newSphere = objectManager.GetObject(newSphereId);
		// 	newCapsule = objectManager.GetObject(newCapsuleId);
		//
		// 	trsRef = newCube.MyGameObject.GetComponent<TransformReferenceScript>();
		// 	Assert.AreEqual(newSphere.MyGameObject.transform, trsRef.value);
		// 	Assert.AreEqual(newCapsule.MyGameObject.transform, trsRef.Value);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveTransformReferenceArray()
		// {
		// 	cube.AddComponent<TransformReferenceArrayScript>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
		// 	ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
		// 	ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));
		//
		// 	uint newCubeId = newCube.InstanceID;
		// 	uint newSphereId = newSphere.InstanceID;
		// 	uint newCapsuleId = newCapsule.InstanceID;
		//
		// 	TransformReferenceArrayScript trsRefArray = newCube.MyGameObject.GetComponent<TransformReferenceArrayScript>();
		// 	trsRefArray.value = new[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform };
		// 	trsRefArray.Value = new[] { newCapsule.MyGameObject.transform, newSphere.MyGameObject.transform };
		//
		// 	yield return null;
		//
		// 	Save();
		//
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(newCubeId);
		// 	newSphere = objectManager.GetObject(newSphereId);
		// 	newCapsule = objectManager.GetObject(newCapsuleId);
		//
		// 	trsRefArray = newCube.MyGameObject.GetComponent<TransformReferenceArrayScript>();
		// 	Assert.IsTrue(trsRefArray.value.IsSameAs(new[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform }));
		// 	Assert.IsTrue(trsRefArray.Value.IsSameAs(new[] { newCapsule.MyGameObject.transform, newSphere.MyGameObject.transform }));
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveTransformReferenceList()
		// {
		// 	cube.AddComponent<TransformReferenceListScript>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject(resources.GetResource("cube"));
		// 	ILevelEditorObject newSphere = objectManager.CreateObject(resources.GetResource("sphere"));
		// 	ILevelEditorObject newCapsule = objectManager.CreateObject(resources.GetResource("capsule"));
		//
		// 	uint newCubeId = newCube.InstanceID;
		// 	uint newSphereId = newSphere.InstanceID;
		// 	uint newCapsuleId = newCapsule.InstanceID;
		//
		// 	TransformReferenceListScript trsRefList = newCube.MyGameObject.GetComponent<TransformReferenceListScript>();
		// 	trsRefList.value.Add(newSphere.MyGameObject.transform);
		// 	trsRefList.value.Add(newCapsule.MyGameObject.transform);
		// 	trsRefList.Value.Add(newCapsule.MyGameObject.transform);
		// 	trsRefList.Value.Add(newCube.MyGameObject.transform);
		//
		// 	yield return null;
		//
		// 	Save();
		//
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(newCubeId);
		// 	newSphere = objectManager.GetObject(newSphereId);
		// 	newCapsule = objectManager.GetObject(newCapsuleId);
		//
		// 	trsRefList = newCube.MyGameObject.GetComponent<TransformReferenceListScript>();
		// 	Assert.IsTrue(trsRefList.value.IsSameAs(new List<Transform>
		// 		{ newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform }));
		//
		// 	Assert.IsTrue(trsRefList.Value.IsSameAs(new List<Transform>
		// 		{ newCapsule.MyGameObject.transform, newCube.MyGameObject.transform }));
		// }

		// [UnityTest]
		// public IEnumerator SaveInheritanceParent()
		// {
		// 	cube.AddComponent<InheritParent>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	InheritParent parent = newCube.MyGameObject.GetComponent<InheritParent>();
		// 	parent.parentValue = 420;
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	parent = newCube.MyGameObject.GetComponent<InheritParent>();
		// 	Assert.AreEqual(420, parent.parentValue);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveInheritanceChild()
		// {
		// 	cube.AddComponent<InheritChild>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	InheritChild child = newCube.MyGameObject.GetComponent<InheritChild>();
		// 	child.childValue = 420;
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	child = newCube.MyGameObject.GetComponent<InheritChild>();
		// 	Assert.AreEqual(420, child.childValue);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveInheritanceChildAndParent()
		// {
		// 	cube.AddComponent<InheritChild>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	InheritChild child = newCube.MyGameObject.GetComponent<InheritChild>();
		// 	child.parentValue = 69;
		// 	child.childValue = 420;
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	child = newCube.MyGameObject.GetComponent<InheritChild>();
		// 	Assert.AreEqual(69, child.parentValue);
		// 	Assert.AreEqual(420, child.childValue);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveCustomStruct()
		// {
		// 	cube.AddComponent<CustomStructTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	CustomStructTest structTest = newCube.MyGameObject.GetComponent<CustomStructTest>();
		// 	structTest.value = new MyStruct
		// 		{ test1 = 42, test2 = "Hello world" };
		//
		// 	structTest.Value = new MyStruct
		// 		{ test1 = 69, test2 = "Look ma!" };
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	structTest = newCube.MyGameObject.GetComponent<CustomStructTest>();
		// 	Assert.AreEqual(structTest.value.test1, 42);
		// 	Assert.AreEqual(structTest.value.test2, "Hello world");
		// 	Assert.AreEqual(structTest.Value.test1, 69);
		// 	Assert.AreEqual(structTest.Value.test2, "Look ma!");
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveNestedStruct()
		// {
		// 	cube.AddComponent<NestedStructTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	NestedStructTest structTest = newCube.MyGameObject.GetComponent<NestedStructTest>();
		// 	structTest.value = new NestedStruct
		// 	{
		// 		nestedValue = new ChildStruct
		// 			{ value1 = 42, value2 = false },
		// 		value = 69
		// 	};
		//
		// 	structTest.Value = new NestedStruct
		// 	{
		// 		nestedValue = new ChildStruct
		// 			{ value1 = 420, value2 = true },
		// 		value = 690
		// 	};
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	structTest = newCube.MyGameObject.GetComponent<NestedStructTest>();
		// 	Assert.AreEqual(structTest.value.nestedValue.value1, 42);
		// 	Assert.AreEqual(structTest.value.nestedValue.value2, false);
		// 	Assert.AreEqual(structTest.value.value, 69);
		// 	Assert.AreEqual(structTest.Value.nestedValue.value1, 420);
		// 	Assert.AreEqual(structTest.Value.nestedValue.value2, true);
		// 	Assert.AreEqual(structTest.Value.value, 690);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveIgnoresNonSerialized()
		// {
		// 	cube.AddComponent<NonSerializedValueTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	NonSerializedValueTest structTest = newCube.MyGameObject.GetComponent<NonSerializedValueTest>();
		// 	structTest.value = new StructWithNonSerialized() { value1 = 42, value2 = true };
		// 	structTest.Value = new StructWithNonSerialized() { value1 = 69, value2 = true };
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	structTest = newCube.MyGameObject.GetComponent<NonSerializedValueTest>();
		// 	Assert.AreEqual(structTest.value.value1, 42);
		// 	Assert.AreEqual(structTest.value.value2, false);
		// 	Assert.AreEqual(structTest.Value.value1, 69);
		// 	Assert.AreEqual(structTest.Value.value2, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveNonSerializableStruct()
		// {
		// 	cube.AddComponent<NonSerializedStructTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	NonSerializedStructTest structTest = newCube.MyGameObject.GetComponent<NonSerializedStructTest>();
		// 	structTest.value = new NonSerializedStruct() { value1 = 42, value2 = true };
		// 	structTest.Value = new NonSerializedStruct() { value1 = 69, value2 = true };
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	structTest = newCube.MyGameObject.GetComponent<NonSerializedStructTest>();
		// 	Assert.AreEqual(structTest.value.value1, 0);
		// 	Assert.AreEqual(structTest.value.value2, false);
		// 	Assert.AreEqual(structTest.Value.value1, 0);
		// 	Assert.AreEqual(structTest.Value.value2, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveEnumNormal()
		// {
		// 	cube.AddComponent<EnumTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	EnumTest enumTest = newCube.MyGameObject.GetComponent<EnumTest>();
		// 	enumTest.value = NormalEnum.Value2;
		// 	enumTest.Value = NormalEnum.Value4;
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	enumTest = newCube.MyGameObject.GetComponent<EnumTest>();
		// 	Assert.AreEqual(enumTest.value, NormalEnum.Value2);
		// 	Assert.AreEqual(enumTest.Value, NormalEnum.Value4);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveEnumByte()
		// {
		// 	cube.AddComponent<ByteEnumTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	ByteEnumTest enumTest = newCube.MyGameObject.GetComponent<ByteEnumTest>();
		// 	enumTest.value = ByteEnum.Value2;
		// 	enumTest.Value = ByteEnum.Value4;
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	enumTest = newCube.MyGameObject.GetComponent<ByteEnumTest>();
		// 	Assert.AreEqual(enumTest.value, ByteEnum.Value2);
		// 	Assert.AreEqual(enumTest.Value, ByteEnum.Value4);
		// }

		// [UnityTest]
		// protected IEnumerator SaveEnumByteFlag()
		// {
		// 	cube.AddComponent<ByteFlagsEnumTest>();
		//
		// 	ILevelEditorObject newCube = objectManager.CreateObject("cube");
		// 	uint cubeId = newCube.InstanceID;
		//
		// 	ByteFlagsEnumTest enumTest = newCube.MyGameObject.GetComponent<ByteFlagsEnumTest>();
		// 	enumTest.value = ByteFlagsEnum.Value1 | ByteFlagsEnum.Value3;
		// 	enumTest.Value = ByteFlagsEnum.Value2 | ByteFlagsEnum.Value4;
		//
		// 	yield return null;
		//
		// 	Save();
		// 	objectManager.DeleteAllObjects();
		//
		// 	yield return null;
		//
		// 	Load();
		//
		// 	yield return null;
		//
		// 	newCube = objectManager.GetObject(cubeId);
		// 	Assert.IsNotNull(newCube);
		//
		// 	enumTest = newCube.MyGameObject.GetComponent<ByteFlagsEnumTest>();
		// 	Assert.AreEqual(enumTest.value, ByteFlagsEnum.Value1 | ByteFlagsEnum.Value3);
		// 	Assert.AreEqual(enumTest.Value, ByteFlagsEnum.Value2 | ByteFlagsEnum.Value4);
		// }

		protected IEnumerator RunTest<TType, TValue>(TValue newValue) where TType : Component, IValue<TValue>
		{
			cube.AddComponent<TType>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;

			TType type = newCube.MyGameObject.GetComponent<TType>();

			type.Value = newValue;
			
			Assert.AreEqual(newValue, type.Value, "Value was not set.");

			Save();
			
			objectManager.DeleteAllObjects();
			
			Load();
			
			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			type = newCube.MyGameObject.GetComponent<TType>();

			if (newValue is ICollection newValueCollection && type.Value is ICollection valueCollection)
			{
				Assert.IsTrue(newValueCollection.IsSameAs(valueCollection), $"Collection was not the same.");
			}
			else
			{
				Assert.AreEqual(newValue, type.Value, "Value was not properly saved.");
			}

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
		}

		protected IEnumerator RunTest<TType, TValue>(TValue newValue1, TValue newValue2) where TType : Component, IValues<TValue>
		{
			cube.AddComponent<TType>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;

			TType type = newCube.MyGameObject.GetComponent<TType>();

			type.Value1 = newValue1;
			type.Value2 = newValue2;

			Assert.AreEqual(newValue1, type.Value1, "Value 1 was not set.");
			Assert.AreEqual(newValue2, type.Value2, "Value 2 was not set.");

			Save();

			objectManager.DeleteAllObjects();
			
			Load();
			
			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			type = newCube.MyGameObject.GetComponent<TType>();
			
			if (newValue1 is ICollection newValue1Collection && type.Value1 is ICollection value1Collection)
			{
				Assert.IsTrue(newValue1Collection.IsSameAs(value1Collection), $"Collection 1 was not the same.");
			}
			else
			{
				Assert.AreEqual(newValue1, type.Value1, "Value 1 was not properly saved.");
			}
			
			if (newValue2 is ICollection newValue2Collection && type.Value2 is ICollection value2Collection)
			{
				Assert.IsTrue(newValue2Collection.IsSameAs(value2Collection), $"Collection 2 was not the same.");
			}
			else
			{
				Assert.AreEqual(newValue2, type.Value2, "Value 2 was not properly saved.");
			}

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
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