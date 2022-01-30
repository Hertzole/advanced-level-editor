using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Hertzole.ALE.Tests
{
	public abstract partial class UnityPrimitives : SerializationTest
	{
		//
		// #region GameObject
		// [UnityTest]
		// public IEnumerator SaveGameObjectField()
		// {
		// 	yield return RunReferenceTest<GameObjectField1, GameObject>(false);
		// 	yield return RunReferenceTest<GameObjectField2, GameObject>(false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectFields()
		// {
		// 	yield return RunReferenceTest<GameObjectFields1, GameObject>(false, false);
		// 	yield return RunReferenceTest<GameObjectFields2, GameObject>(false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectProperty()
		// {
		// 	yield return RunReferenceTest<GameObjectProperty1, GameObject>(false);
		// 	yield return RunReferenceTest<GameObjectProperty2, GameObject>(false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectProperties()
		// {
		// 	yield return RunReferenceTest<GameObjectProperties1, GameObject>(false, false);
		// 	yield return RunReferenceTest<GameObjectProperties2, GameObject>(false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectNullableField()
		// {
		// 	yield return RunReferenceTest<GameObjectField1, GameObject>(false);
		// 	yield return RunReferenceTest<GameObjectField2, GameObject>(false);
		// 	yield return RunReferenceTest<GameObjectField1, GameObject>(true);
		// 	yield return RunReferenceTest<GameObjectField2, GameObject>(true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectNullableFields()
		// {
		// 	yield return RunReferenceTest<GameObjectFields1, GameObject>(false, false);
		// 	yield return RunReferenceTest<GameObjectFields2, GameObject>(false, false);
		// 	yield return RunReferenceTest<GameObjectFields1, GameObject>(true, false);
		// 	yield return RunReferenceTest<GameObjectFields2, GameObject>(false, true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectNullableProperty()
		// {
		// 	yield return RunReferenceTest<GameObjectProperty1, GameObject>(false);
		// 	yield return RunReferenceTest<GameObjectProperty2, GameObject>(false);
		// 	yield return RunReferenceTest<GameObjectProperty1, GameObject>(true);
		// 	yield return RunReferenceTest<GameObjectProperty2, GameObject>(true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectNullableProperties()
		// {
		// 	yield return RunReferenceTest<GameObjectProperties1, GameObject>(false, false);
		// 	yield return RunReferenceTest<GameObjectProperties2, GameObject>(false, false);
		// 	yield return RunReferenceTest<GameObjectProperties1, GameObject>(true, false);
		// 	yield return RunReferenceTest<GameObjectProperties2, GameObject>(false, true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayField()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayField1, GameObject[]>(false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayField2, GameObject[]>(false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayFields()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayFields1, GameObject[]>(false, false, false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayFields2, GameObject[]>(false, false, false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayProperty()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperty1, GameObject[]>(false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperty2, GameObject[]>(false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayProperties()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperties1, GameObject[]>(false, false, false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperties2, GameObject[]>(false, false, false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayNullableField()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayField1, GameObject[]>(true, false);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayField2, GameObject[]>(false, true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayNullableFields()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayFields1, GameObject[]>(true, false, false, true);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayFields2, GameObject[]>(false, true, true, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayNullableProperty()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperty1, GameObject[]>(true, false);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperty2, GameObject[]>(false, true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectArrayNullableProperties()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperties1, GameObject[]>(false, true, true, false);
		// 	yield return RunReferenceCollectionTest<GameObjectArrayProperties2, GameObject[]>(true, false, false, true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListField()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListField1, List<GameObject>>(false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectListField2, List<GameObject>>(false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListFields()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListFields1, List<GameObject>>(false, false, false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectListFields2, List<GameObject>>(false, false, false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListProperty()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListProperty1, List<GameObject>>(false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectListProperty2, List<GameObject>>(false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListProperties()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListProperties1, List<GameObject>>(false, false, false, false);
		// 	yield return RunReferenceCollectionTest<GameObjectListProperties2, List<GameObject>>(false, false, false, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListNullableField()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListField1, List<GameObject>>(true, false);
		// 	yield return RunReferenceCollectionTest<GameObjectListField2, List<GameObject>>(false, true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListNullableFields()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListFields1, List<GameObject>>(true, false, false, true);
		// 	yield return RunReferenceCollectionTest<GameObjectListFields2, List<GameObject>>(false, true, true, false);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListNullableProperty()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListProperty1, List<GameObject>>(true, false);
		// 	yield return RunReferenceCollectionTest<GameObjectListProperty2, List<GameObject>>(false, true);
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveGameObjectListNullableProperties()
		// {
		// 	yield return RunReferenceCollectionTest<GameObjectListProperties1, List<GameObject>>(false, true, true, false);
		// 	yield return RunReferenceCollectionTest<GameObjectListProperties2, List<GameObject>>(true, false, false, true);
		// }
		// #endregion

		private IEnumerator RunObjectTest<TType, TValue>(ILevelEditorObject referenceObject) where TType : Component, IValue<TValue> where TValue : Object
		{
			cube.AddComponent<TType>();

			bool isNull = referenceObject == null;
			ILevelEditorObject refObject = referenceObject;

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;
			uint refId = 0;

			if (!isNull)
			{
				refId = refObject.InstanceID;
			}

			TType type = newCube.MyGameObject.GetComponent<TType>();
			TValue value = GetValue<TValue>(refObject);

			type.Value = value;

			Assert.AreEqual(value, type.Value, "Value was not set.");

			Save();

			objectManager.DeleteAllObjects();
			refObject = null;

			Load();

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			if (!isNull)
			{
				refObject = objectManager.GetObject(refId);
				Assert.IsNotNull(refObject, "Reference object was not loaded.");
			}

			type = newCube.MyGameObject.GetComponent<TType>();

			value = GetValue<TValue>(refObject);
			Assert.AreEqual(value, type.Value, "Value was not properly saved.");

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
		}

		private IEnumerator RunObjectTest<TType, TValue>(ILevelEditorObject referenceObject1, ILevelEditorObject referenceObject2) where TType : Component, IValues<TValue> where TValue : Object
		{
			cube.AddComponent<TType>();

			bool isNull1 = referenceObject1 == null;
			bool isNull2 = referenceObject2 == null;
			ILevelEditorObject refObject1 = referenceObject1;
			ILevelEditorObject refObject2 = referenceObject2;

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;
			uint ref1Id = 0;
			uint ref2Id = 0;

			if (!isNull1)
			{
				ref1Id = refObject1.InstanceID;
			}

			if (!isNull2)
			{
				ref2Id = refObject2.InstanceID;
			}

			TType type = newCube.MyGameObject.GetComponent<TType>();
			TValue value1 = GetValue<TValue>(refObject1);
			TValue value2 = GetValue<TValue>(refObject2);

			type.Value1 = value1;
			type.Value2 = value2;

			Assert.AreEqual(value1, type.Value1, "Value 1 was not set.");
			Assert.AreEqual(value2, type.Value2, "Value 2 was not set.");

			Save();

			objectManager.DeleteAllObjects();
			refObject1 = null;
			refObject2 = null;

			Load();

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			if (!isNull1)
			{
				refObject1 = objectManager.GetObject(ref1Id);
				Assert.IsNotNull(refObject1, "Reference object 1 was not loaded.");
			}

			if (!isNull2)
			{
				refObject2 = objectManager.GetObject(ref2Id);
				Assert.IsNotNull(refObject2, "Reference object 2 was not loaded.");
			}

			type = newCube.MyGameObject.GetComponent<TType>();

			value1 = GetValue<TValue>(refObject1);
			value2 = GetValue<TValue>(refObject2);
			Assert.AreEqual(value1, type.Value1, "Value 1 was not properly saved.");
			Assert.AreEqual(value2, type.Value2, "Value 2 was not properly saved.");

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
		}

		private IEnumerator RunObjectCollectionTest<TType, TValue>(ILevelEditorObject[] referenceObjects) where TType : Component, IValue<TValue> where TValue : class
		{
			cube.AddComponent<TType>();

			GetObjectsArrays(referenceObjects, out bool isNull, out bool[] objectNulls, out uint[] instanceIds);

			ILevelEditorObject[] refObjects = referenceObjects;

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;

			TType type = newCube.MyGameObject.GetComponent<TType>();
			TValue value = isNull ? null : GetValue<TValue>(refObjects);

			type.Value = value;

			if (value is ICollection valueCol && type.Value is ICollection typeCol)
			{
				Assert.IsTrue(valueCol.IsSameAs(typeCol), "Value collection was not properly set.");
				Debug.Log(typeCol.Count);
			}
			else
			{
				Assert.AreEqual(value, type.Value, "Value was not properly set.");
			}

			Save();

			objectManager.DeleteAllObjects();

			Load();

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			refObjects = GetBackLevelEditorObjects(isNull, objectNulls, instanceIds);

			type = newCube.MyGameObject.GetComponent<TType>();

			value = GetValue<TValue>(refObjects);

			if (value is ICollection valueColNew && type.Value is ICollection typeColNew)
			{
				Assert.IsTrue(valueColNew.IsSameAs(typeColNew), "Value collection was not properly loaded.");
			}
			else
			{
				Assert.AreEqual(value, type.Value, "Value was not properly loaded.");
			}

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
		}

		private IEnumerator RunObjectCollectionTest<TType, TValue>(ILevelEditorObject[] referenceObjects1, ILevelEditorObject[] referenceObjects2) where TType : Component, IValues<TValue> where TValue : class
		{
			cube.AddComponent<TType>();

			GetObjectsArrays(referenceObjects1, out bool isNull1, out bool[] objectNulls1, out uint[] instanceIds1);
			GetObjectsArrays(referenceObjects2, out bool isNull2, out bool[] objectNulls2, out uint[] instanceIds2);

			ILevelEditorObject[] refObjects1 = referenceObjects1;
			ILevelEditorObject[] refObjects2 = referenceObjects2;

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;

			TType type = newCube.MyGameObject.GetComponent<TType>();
			TValue value1 = isNull1 ? null : GetValue<TValue>(refObjects1);
			TValue value2 = isNull2 ? null : GetValue<TValue>(refObjects2);

			type.Value1 = value1;
			type.Value2 = value2;

			CheckCollectionValues(type, value1, value2);

			Save();

			objectManager.DeleteAllObjects();

			Load();

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			refObjects1 = GetBackLevelEditorObjects(isNull1, objectNulls1, instanceIds1);
			refObjects2 = GetBackLevelEditorObjects(isNull2, objectNulls2, instanceIds2);

			type = newCube.MyGameObject.GetComponent<TType>();

			value1 = GetValue<TValue>(refObjects1);
			value2 = GetValue<TValue>(refObjects2);

			CheckCollectionValues(type, value1, value2);

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
		}

		private static void CheckCollectionValues<TType, TValue>(TType type, TValue value1, TValue value2) where TType : Component, IValues<TValue> where TValue : class
		{
			if (value1 is ICollection value1ColNew && type.Value1 is ICollection type1ColNew)
			{
				Assert.IsTrue(value1ColNew.IsSameAs(type1ColNew), "Value 1 collection was not properly set.");
			}
			else
			{
				Assert.AreEqual(value1, type.Value1, "Value 1 was not properly set.");
			}

			if (value2 is ICollection value2ColNew && type.Value2 is ICollection type2ColNew)
			{
				Assert.IsTrue(value2ColNew.IsSameAs(type2ColNew), "Value 2 collection was not properly set.");
			}
			else
			{
				Assert.AreEqual(value2, type.Value2, "Value 2 was not properly set.");
			}
		}

		private ILevelEditorObject[] GetBackLevelEditorObjects(bool isNull, IReadOnlyList<bool> objectNulls, IReadOnlyList<uint> instanceIds)
		{
			ILevelEditorObject[] objects = null;

			if (!isNull)
			{
				objects = new ILevelEditorObject[objectNulls.Count];
				for (int i = 0; i < objects.Length; i++)
				{
					if (!objectNulls[i])
					{
						objects[i] = objectManager.GetObject(instanceIds[i]);
						Assert.IsNotNull(objects, $"Reference {i} object was not loaded.");
					}
				}
			}

			return objects;
		}

		private static void GetObjectsArrays(IReadOnlyList<ILevelEditorObject> referenceObjects, out bool isNull, out bool[] objectNulls, out uint[] instanceIds)
		{
			isNull = referenceObjects == null;

			objectNulls = referenceObjects == null ? Array.Empty<bool>() : new bool[referenceObjects.Count];

			instanceIds = referenceObjects == null ? Array.Empty<uint>() : new uint[referenceObjects.Count];

			if (referenceObjects != null)
			{
				for (int i = 0; i < objectNulls.Length; i++)
				{
					objectNulls[i] = referenceObjects[i] == null;
					instanceIds[i] = referenceObjects[i] == null ? 0 : referenceObjects[i].InstanceID;
				}
			}
		}

		private static T GetValue<T>(ILevelEditorObject obj) where T : Object
		{
			T value = null;
			if (obj != null)
			{
				if (typeof(T) == typeof(GameObject))
				{
					value = obj.MyGameObject as T;
				}
				else if (typeof(T) == typeof(Transform))
				{
					value = obj.MyGameObject.transform as T;
				}
				else
				{
					value = obj.MyGameObject.GetComponent<T>();
				}
			}

			return value;
		}

		private static T GetValue<T>(IReadOnlyList<ILevelEditorObject> objects) where T : class
		{
			T value = default;
			if (objects != null)
			{
				if (typeof(T) == typeof(List<GameObject>))
				{
					value = new List<GameObject>(objects.Count) as T;
				}
				else if (typeof(T) == typeof(GameObject[]))
				{
					value = new GameObject[objects.Count] as T;
				}
				else if (typeof(T) == typeof(List<Transform>))
				{
					value = new List<Transform>(objects.Count) as T;
				}
				else if (typeof(T) == typeof(Transform[]))
				{
					value = new Transform[objects.Count] as T;
				}
				else if (typeof(T) == typeof(ScriptReference[]))
				{
					value = new ScriptReference[objects.Count] as T;
				}
				else if (typeof(T) == typeof(List<ScriptReference>))
				{
					value = new List<ScriptReference>(objects.Count) as T;
				}

				for (int i = 0; i < objects.Count; i++)
				{
					if (objects[i] != null)
					{
						switch (value)
						{
							case List<GameObject> goList:
								goList.Add(objects[i].MyGameObject);
								break;
							case GameObject[] goArray:
								goArray[i] = objects[i].MyGameObject;
								break;
							case List<Transform> trsList:
								trsList.Add(objects[i].MyGameObject.transform);
								break;
							case Transform[] trsArray:
								trsArray[i] = objects[i].MyGameObject.transform;
								break;
							case ScriptReference[] compArray:
								compArray[i] = objects[i].MyGameObject.GetComponent<ScriptReference>();
								break;
							case List<ScriptReference> compList:
								compList.Add(objects[i].MyGameObject.GetComponent<ScriptReference>());
								break;
						}
					}
				}
			}

			return value;
		}

		private IEnumerator RunReferenceTest<TType, TValue>(bool makeNull) where TType : Component, IValue<TValue> where TValue : Object
		{
			ILevelEditorObject refSphere = null;
			uint refSphereId = 0;
			if (!makeNull)
			{
				refSphere = objectManager.CreateObject("sphere");
				refSphereId = refSphere.InstanceID;
			}

			yield return RunObjectTest<TType, TValue>(refSphere);

			refSphere = objectManager.GetObject(refSphereId);
			if (!makeNull && refSphere != null)
			{
				objectManager.DeleteObject(refSphere);
			}
		}

		private IEnumerator RunReferenceTest<TType, TValue>(bool null1, bool null2) where TType : Component, IValues<TValue> where TValue : Object
		{
			ILevelEditorObject refSphere = null;
			ILevelEditorObject refCapsule = null;

			uint refSphereId = 0;
			uint refCapsuleId = 0;

			if (!null1)
			{
				refSphere = objectManager.CreateObject("sphere");
				refSphereId = refSphere.InstanceID;
			}

			if (!null2)
			{
				refCapsule = objectManager.CreateObject("capsule");
				refCapsuleId = refCapsule.InstanceID;
			}

			yield return RunObjectTest<TType, TValue>(refSphere, refCapsule);

			refSphere = objectManager.GetObject(refSphereId);
			if (!null1 && refSphere != null)
			{
				objectManager.DeleteObject(refSphere);
			}

			refCapsule = objectManager.GetObject(refCapsuleId);
			if (!null2 && refCapsule != null)
			{
				objectManager.DeleteObject(refCapsule);
			}
		}

		private IEnumerator RunReferenceCollectionTest<TComponent, TValue>(bool null1, bool null2) where TComponent : Component, IValue<TValue> where TValue : class
		{
			ILevelEditorObject refSphere = null;
			ILevelEditorObject refCapsule = null;

			uint refSphereId = 0;
			uint refCapsuleId = 0;

			if (!null1)
			{
				refSphere = objectManager.CreateObject("sphere");
				refSphereId = refSphere.InstanceID;
			}

			if (!null2)
			{
				refCapsule = objectManager.CreateObject("capsule");
				refCapsuleId = refCapsule.InstanceID;
			}

			yield return RunObjectCollectionTest<TComponent, TValue>(new[] { refSphere, refCapsule });

			refSphere = objectManager.GetObject(refSphereId);
			if (!null1 && refSphere != null)
			{
				objectManager.DeleteObject(refSphere);
			}

			refCapsule = objectManager.GetObject(refCapsuleId);
			if (!null2 && refCapsule != null)
			{
				objectManager.DeleteObject(refCapsule);
			}
		}

		private IEnumerator RunReferenceCollectionTest<TComponent, TValue>(bool null1, bool null2, bool null3, bool null4) where TComponent : Component, IValues<TValue> where TValue : class
		{
			ILevelEditorObject refSphere = null;
			ILevelEditorObject refCapsule = null;
			ILevelEditorObject refCylinder = null;
			ILevelEditorObject refCube = null;

			uint refSphereId = 0;
			uint refCapsuleId = 0;
			uint refCylinderId = 0;
			uint refCubeId = 0;

			if (!null1)
			{
				refSphere = objectManager.CreateObject("sphere");
				refSphereId = refSphere.InstanceID;
			}

			if (!null2)
			{
				refCapsule = objectManager.CreateObject("capsule");
				refCapsuleId = refCapsule.InstanceID;
			}

			if (!null3)
			{
				refCylinder = objectManager.CreateObject("cylinder");
				refCylinderId = refCylinder.InstanceID;
			}

			if (!null4)
			{
				refCube = objectManager.CreateObject("cube");
				refCubeId = refCube.InstanceID;
			}

			yield return RunObjectCollectionTest<TComponent, TValue>(new[] { refSphere, refCapsule }, new[] { refCylinder, refCube });

			refSphere = objectManager.GetObject(refSphereId);
			if (!null1 && refSphere != null)
			{
				objectManager.DeleteObject(refSphere);
			}

			refCapsule = objectManager.GetObject(refCapsuleId);
			if (!null2 && refCapsule != null)
			{
				objectManager.DeleteObject(refCapsule);
			}

			refCylinder = objectManager.GetObject(refCylinderId);
			if (!null3 && refCylinder != null)
			{
				objectManager.DeleteObject(refCylinder);
			}

			refCube = objectManager.GetObject(refCubeId);
			if (!null4 && refCube != null)
			{
				objectManager.DeleteObject(refCube);
			}
		}
	}
}