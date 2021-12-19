using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

// Used to disable cast warnings because IExposedToLevelEditor is never explicitly set but is set
// when the code has been weaved.
// ReSharper disable SuspiciousTypeConversion.Global

namespace Hertzole.ALE.Tests
{
	public class UndoTests : LevelEditorTest
	{
		private LevelEditorUndo undo;

		protected override void OnSceneSetup(List<GameObject> objects)
		{
			undo = levelEditor.gameObject.AddComponent<LevelEditorUndo>();
			undo.HandleUndoRedoInput = false;
			undo.LevelEditor = levelEditor;
			levelEditor.Undo = undo;
			objectManager.Undo = undo;
		}

		[UnityTest]
		public IEnumerator RemovedObjectKeepsPropertiesPooled()
		{
			objectManager.PoolObjects = true;
			yield return RemovedObjectsKeepsProperties();
		}

		[UnityTest]
		public IEnumerator RemovedObjectKeepsPropertiesNotPooled()
		{
			objectManager.PoolObjects = false;
			yield return RemovedObjectsKeepsProperties();
		}

		private IEnumerator RemovedObjectsKeepsProperties()
		{
			ByteTest4 byteTest = cube.AddComponent<ByteTest4>();
			byteTest.value1 = 69;
			byteTest.value2 = 42;

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			yield return WaitFrames(1);

			Assert.AreEqual<byte>(69, byteTest.value1);
			Assert.AreEqual<byte>(42, byteTest.value2);

			uint newCubeInstanceId = newCube.InstanceID;

			byteTest = newCube.MyGameObject.GetComponent<ByteTest4>();
			byteTest.value1 = 6;
			byteTest.value2 = 9;

			yield return WaitFrames(1);

			Assert.AreEqual<byte>(6, byteTest.value1);
			Assert.AreEqual<byte>(9, byteTest.value2);

			objectManager.DeleteObject(newCube);

			yield return WaitFrames(1);

			// Make sure the object doesn't exist.
			Assert.IsFalse(LevelEditorWorld.TryGetObject(newCubeInstanceId, out _));

			newCube = objectManager.CreateObject("cube");

			yield return WaitFrames(1);

			uint previousInstanceId = newCubeInstanceId;

			newCubeInstanceId = newCube.InstanceID;
			byteTest = newCube.MyGameObject.GetComponent<ByteTest4>();
			Assert.AreEqual<byte>(69, byteTest.value1);
			Assert.AreEqual<byte>(42, byteTest.value2);

			yield return WaitFrames(1);

			// Undo create object.
			undo.Undo();

			yield return WaitFrames(1);

			// Make sure the object doesn't exist.
			Assert.IsFalse(LevelEditorWorld.TryGetObject(newCubeInstanceId, out _));

			// Undo delete object.
			undo.Undo();

			yield return WaitFrames(1);

			// Make sure the object exists.
			Assert.IsTrue(LevelEditorWorld.TryGetObject(previousInstanceId, out newCube));
			byteTest = newCube.MyGameObject.GetComponent<ByteTest4>();
			Assert.AreEqual<byte>(6, byteTest.value1);
			Assert.AreEqual<byte>(9, byteTest.value2);
		}

		[UnityTest]
		public IEnumerator UndoRedoCreateObjectPooled()
		{
			objectManager.PoolObjects = true;
			yield return UndoRedoCreateObject();
		}

		[UnityTest]
		public IEnumerator UndoRedoCreateObjectNotPooled()
		{
			objectManager.PoolObjects = false;
			yield return UndoRedoCreateObject();
		}

		private IEnumerator UndoRedoCreateObject()
		{
			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint instanceId = newCube.InstanceID;

			yield return WaitFrames(1);

			// Make sure the object exists.
			Assert.IsTrue(LevelEditorWorld.TryGetObject(instanceId, out _));

			undo.Undo();

			yield return WaitFrames(1);

			// Make sure the object doesn't exist.
			Assert.IsFalse(LevelEditorWorld.TryGetObject(instanceId, out _));

			undo.Redo();

			yield return WaitFrames(1);

			// Make sure the object exists.
			Assert.IsTrue(LevelEditorWorld.TryGetObject(instanceId, out _));
		}

		[UnityTest]
		public IEnumerator UndoRedoDeleteObjectPooled()
		{
			objectManager.PoolObjects = true;
			yield return UndoRedoDeleteObject();
		}

		[UnityTest]
		public IEnumerator UndoRedoDeleteObjectNotPooled()
		{
			objectManager.PoolObjects = false;
			yield return UndoRedoCreateObject();
		}

		private IEnumerator UndoRedoDeleteObject()
		{
			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint instanceId = newCube.InstanceID;

			yield return WaitFrames(1);

			// Make sure the object exists.
			Assert.IsTrue(LevelEditorWorld.TryGetObject(instanceId, out _));
			objectManager.DeleteObject(newCube);

			yield return WaitFrames(1);

			// Make sure the object doesn't exist.
			Assert.IsFalse(LevelEditorWorld.TryGetObject(instanceId, out _));

			undo.Undo();

			yield return WaitFrames(1);

			// Make sure the object exists.
			Assert.IsTrue(LevelEditorWorld.TryGetObject(instanceId, out _));

			undo.Redo();

			yield return WaitFrames(1);

			// Make sure the object doesn't exist.
			Assert.IsFalse(LevelEditorWorld.TryGetObject(instanceId, out _));
		}

		[UnityTest]
		public IEnumerator SetSimpleValueUndo()
		{
			cube.AddComponent<ByteTest1>();

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint instanceId = newCube.InstanceID;

			yield return WaitFrames(1);

			IExposedToLevelEditor exposedScript = newCube.MyGameObject.GetComponent<ByteTest1>() as IExposedToLevelEditor;
			Assert.IsNotNull(exposedScript);

			exposedScript.SetValue(0, byte.MaxValue, true, undo);

			Assert.AreEqual<byte>(byte.MaxValue, (byte) exposedScript.GetValue(0));

			// Undo set value.
			undo.Undo();

			yield return WaitFrames(1);

			Assert.IsTrue(LevelEditorWorld.TryGetObject(instanceId, out _), "Object does not exist.");
			Assert.AreEqual<byte>(0, (byte) exposedScript.GetValue(0));
		}
	}
}