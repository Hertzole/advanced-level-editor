using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
    public class Equals
    {
        [Test]
        public void SerializedLevelDataEquals()
        {
            EqualTest(BuildSerializedLevelData(), BuildSerializedLevelData());
        }

        [Test]
        public void SaveDataEquals()
        {
            EqualTest(BuildSaveData(), BuildSaveData());
        }

        [Test]
        public void CustomDataEquals()
        {
            EqualTest(BuildCustomData(), BuildCustomData());
        }

        [Test]
        public void ObjectDataEquals()
        {
            EqualTest(BuildObjectData(), BuildObjectData());
        }

        [Test]
        public void ComponentDataEquals()
        {
            EqualTest(BuildComponentData(), BuildComponentData());
        }

        [Test]
        public void PropertyDataEquals()
        {
            EqualTest(BuildPropertyData(), BuildPropertyData());
        }

        private void EqualTest<T>(T a, T b)
        {
            Assert.AreEqual(a, b);
        }

        private SerializedLevelData BuildSerializedLevelData()
        {
            SerializedLevelData data = new SerializedLevelData
            {
                TypePalette = new Dictionary<string, int>()
                {
                    { "temp1", 0 },
                    { "temp2", 1 },
                },
                ObjectPalette = new Dictionary<string, int>()
                {
                    { "temp3", 3 },
                    { "temp4", 3 }
                },
                Data = BuildSaveData()
            };

            return data;
        }

        private LevelEditorSaveData BuildSaveData()
        {
            return new LevelEditorSaveData()
            {
                name = "Test Level",
                objects = new List<LevelEditorObjectData>() { BuildObjectData(), BuildObjectData() },
                customData = new Dictionary<string, LevelEditorCustomData>()
                {
                    { "data1", new LevelEditorCustomData(typeof(string).FullName, false, "Hello world") },
                    { "data2", new LevelEditorCustomData(typeof(int).FullName, false, 42) }
                }
            };
        }

        private LevelEditorCustomData BuildCustomData()
        {
            return new LevelEditorCustomData()
            {
                isArray = false,
                type = typeof(string).FullName,
                value = "Hello world"
            };
        }

        private LevelEditorObjectData BuildObjectData()
        {
            return new LevelEditorObjectData()
            {
                active = true,
                name = "Test Object",
                id = "test_object",
                instanceId = 1,
                components = new LevelEditorComponentData[2] { BuildComponentData(), BuildComponentData() }
            };
        }

        private LevelEditorComponentData BuildComponentData()
        {
            return new LevelEditorComponentData()
            {
                type = typeof(Transform).FullName,
                properties = new LevelEditorPropertyData[2] { BuildPropertyData(), BuildPropertyData() }
            };
        }

        private LevelEditorPropertyData BuildPropertyData()
        {
            return new LevelEditorPropertyData()
            {
                id = 0,
                isArray = false,
                type = typeof(string),
                typeName = typeof(string).FullName,
                value = "Hello world"
            };
        }
    }
}
