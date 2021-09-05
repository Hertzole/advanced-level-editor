using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using NUnit.Framework;
using UnityEngine;

namespace Hertzole.ALE.Tests.Editor
{
	public class SerializeEditorTime
	{
		[Test]
		public void SerializeLevelDataBinary()
		{
			LevelEditorSaveData data = GetData();
			byte[] binary = LevelEditorSerializer.SerializeBinary(data);
			data = LevelEditorSerializer.DeserializeBinary<LevelEditorSaveData>(binary);

			Assert.AreEqual("Test Level", data.name);
			Assert.AreEqual(1, data.objects.Count);
		}
		
		[Test]
		public void SerializeLevelDataJson()
		{
			LevelEditorSaveData data = GetData();
			var json = LevelEditorSerializer.SerializeJson(data);
			data = LevelEditorSerializer.DeserializeJson<LevelEditorSaveData>(json);

			Assert.AreEqual("Test Level", data.name);
			Assert.AreEqual(1, data.objects.Count);
		}
		
		[Test]
		public void SerializeComponentDataBinary()
		{
			GameObject go = new GameObject("temp", typeof(ByteTest4));

			IExposedToLevelEditor exposed = go.GetComponent<IExposedToLevelEditor>();
			exposed.SetValue(5, (byte) 10, false);

			Assert.AreEqual((byte) 10, (byte) exposed.GetValue(5));
			
			LevelEditorComponentData data = new LevelEditorComponentData(exposed);
			byte[] binary = LevelEditorSerializer.SerializeBinary(data);
			data = LevelEditorSerializer.DeserializeBinary<LevelEditorComponentData>(binary);

			exposed.SetValue(5, (byte) 0, false);
			Assert.AreEqual((byte) 0, (byte) exposed.GetValue(5));

			exposed.ApplyWrapper(data.wrapper, true);
			
			Assert.AreEqual((byte) 10, (byte) exposed.GetValue(5));

			Object.DestroyImmediate(go);
		}

		private static LevelEditorSaveData GetData()
		{
			return new LevelEditorSaveData("Test Level")
			{
				objects = new List<LevelEditorObjectData>
				{
					new LevelEditorObjectData
					{
						active = true,
						id = "delete_me",
						instanceId = 0,
						name = "Haha"
					}
				}
			};
		}
	}
}