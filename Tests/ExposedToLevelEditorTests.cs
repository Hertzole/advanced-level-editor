using System.Collections;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
	public class ExposedToLevelEditorTests : LevelEditorTest
	{
		[UnityTest]
		public IEnumerator SetValueByte()
		{
			cube.AddComponent<ByteTest1>();
			cube.AddComponent<ByteTest5>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			IExposedToLevelEditor exposed1 = newCube.MyGameObject.GetComponent<ByteTest1>() as IExposedToLevelEditor;
			IExposedToLevelEditor exposed2 = newCube.MyGameObject.GetComponent<ByteTest5>() as IExposedToLevelEditor;
			Assert.IsNotNull(exposed1);
			Assert.IsNotNull(exposed2);

			exposed1.SetValue(0, (byte) 10, true);
			exposed2.SetValue(0, (byte) 20, true);

			yield return null;

			Assert.AreEqual<byte>((byte) exposed1.GetValue(0), 10);
			Assert.AreEqual<byte>((byte) exposed2.GetValue(0), 20);

			yield return null;
		}
		
		[UnityTest]
		public IEnumerator SetValueVector()
		{
			cube.AddComponent<Vector3Test1>();
			cube.AddComponent<Vector3Test5>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			IExposedToLevelEditor exposed1 = newCube.MyGameObject.GetComponent<Vector3Test1>() as IExposedToLevelEditor;
			IExposedToLevelEditor exposed2 = newCube.MyGameObject.GetComponent<Vector3Test5>() as IExposedToLevelEditor;
			Assert.IsNotNull(exposed1);
			Assert.IsNotNull(exposed2);

			exposed1.SetValue(0, new Vector3(1, 2, 3), true);
			exposed2.SetValue(0, new Vector3(4, 5, 6), true);

			yield return null;

			Assert.AreEqual((Vector3) exposed1.GetValue(0), new Vector3(1, 2, 3));
			Assert.AreEqual((Vector3) exposed2.GetValue(0), new Vector3(4, 5, 6));

			yield return null;
		}
		
		[UnityTest]
		public IEnumerator SetValueReferences()
		{
			cube.AddComponent<TransformReferenceScript>();
			cube.AddComponent<GameObjectReferenceScript>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");
			IExposedToLevelEditor exposed1 = newCube.MyGameObject.GetComponent<TransformReferenceScript>() as IExposedToLevelEditor;
			IExposedToLevelEditor exposed2 = newCube.MyGameObject.GetComponent<GameObjectReferenceScript>() as IExposedToLevelEditor;
			Assert.IsNotNull(exposed1);
			Assert.IsNotNull(exposed2);

			exposed1.SetValue(0, new ComponentDataWrapper(newSphere.MyGameObject.transform), true);
			exposed2.SetValue(0, new ComponentDataWrapper(newCapsule.MyGameObject), true);

			yield return null;

			Assert.AreEqual(((ComponentDataWrapper) exposed1.GetValue(0)).GetObject<Transform>(), newSphere.MyGameObject.transform);
			Assert.AreEqual(((ComponentDataWrapper) exposed2.GetValue(0)).GetObject<GameObject>(), newCapsule.MyGameObject);

			yield return null;
		}
		
		[UnityTest]
		public IEnumerator SetValueReferenceArray()
		{
			cube.AddComponent<TransformReferenceArrayScript>();
			cube.AddComponent<GameObjectReferenceArrayScript>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");
			IExposedToLevelEditor exposed1 = newCube.MyGameObject.GetComponent<TransformReferenceArrayScript>() as IExposedToLevelEditor;
			IExposedToLevelEditor exposed2 = newCube.MyGameObject.GetComponent<GameObjectReferenceArrayScript>() as IExposedToLevelEditor;
			Assert.IsNotNull(exposed1);
			Assert.IsNotNull(exposed2);

			exposed1.SetValue(0, new ComponentDataWrapper(new Component[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform }), true);
			exposed2.SetValue(0, new ComponentDataWrapper(new GameObject[] { newCapsule.MyGameObject, newSphere.MyGameObject }), true);

			yield return null;

			Transform[] transforms = ((ComponentDataWrapper) exposed1.GetValue(0)).GetObjects<Transform>();
			GameObject[] gameObjects = ((ComponentDataWrapper) exposed2.GetValue(0)).GetObjects<GameObject>();

			Assert.AreEqual(transforms.Length, 2);
			Assert.AreEqual(gameObjects.Length, 2);

			Assert.AreEqual(transforms[0], newSphere.MyGameObject.transform);
			Assert.AreEqual(transforms[1], newCapsule.MyGameObject.transform);

			Assert.AreEqual(gameObjects[0], newCapsule.MyGameObject);
			Assert.AreEqual(gameObjects[1], newSphere.MyGameObject);

			yield return null;
		}
		
		[UnityTest]
		public IEnumerator SetValueReferenceList()
		{
			cube.AddComponent<TransformReferenceListScript>();
			cube.AddComponent<GameObjectReferenceListScript>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");
			IExposedToLevelEditor exposed1 = newCube.MyGameObject.GetComponent<TransformReferenceListScript>() as IExposedToLevelEditor;
			IExposedToLevelEditor exposed2 = newCube.MyGameObject.GetComponent<GameObjectReferenceListScript>() as IExposedToLevelEditor;
			Assert.IsNotNull(exposed1);
			Assert.IsNotNull(exposed2);

			exposed1.SetValue(0, new ComponentDataWrapper(new Component[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform }), true);
			exposed2.SetValue(0, new ComponentDataWrapper(new GameObject[] { newCapsule.MyGameObject, newSphere.MyGameObject }), true);

			yield return null;

			Transform[] transforms = ((ComponentDataWrapper) exposed1.GetValue(0)).GetObjects<Transform>();
			GameObject[] gameObjects = ((ComponentDataWrapper) exposed2.GetValue(0)).GetObjects<GameObject>();

			Assert.AreEqual(transforms.Length, 2);
			Assert.AreEqual(gameObjects.Length, 2);

			Assert.AreEqual(transforms[0], newSphere.MyGameObject.transform);
			Assert.AreEqual(transforms[1], newCapsule.MyGameObject.transform);

			Assert.AreEqual(gameObjects[0], newCapsule.MyGameObject);
			Assert.AreEqual(gameObjects[1], newSphere.MyGameObject);

			yield return null;
		}
	}
}