using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
    public abstract class SerializationTest
    {
        //[Test]
        //public void SerializedSaveDataSerialization()
        //{
        //    SerializeTest(BuildSerializedLevelData());
        //}

        [Test]
        public void SaveDataSerialization()
        {
            SerializeTest(BuildSaveData());
        }

        [Test]
        public void CustomDataSerialization()
        {
            SerializeTest(BuildCustomData());
        }

        [Test]
        public void ObjectDataSerialization()
        {
            SerializeTest(BuildObjectData());
        }

        [Test]
        public void ComponentDataSerialization()
        {
            SerializeTest(BuildComponentData());
        }

        [Test]
        public void PropertyDataSerialization()
        {
            SerializeTest(BuildPropertyData());
        }

        [Test]
        public void PropertyDataStringSerialization()
        {
            LevelEditorPropertyData data = BuildPropertyData();
            data.typeName = typeof(string).FullName;
            data.type = typeof(string);
            data.value = "Hello world";

            SerializeTest(data);
        }

        [Test]
        public void PropertyDataIntSerialization()
        {
            LevelEditorPropertyData data = BuildPropertyData();
            data.typeName = typeof(int).FullName;
            data.type = typeof(int);
            data.value = 65;

            SerializeTest(data);
        }

        protected abstract void SerializeTest<T>(T data);

        //public static SerializedLevelData BuildSerializedLevelData()
        //{
        //    SerializedLevelData data = new SerializedLevelData
        //    {
        //        TypePalette = new Dictionary<string, int>()
        //        {
        //            { "temp1", 0 },
        //            { "temp2", 1 },
        //        },
        //        ObjectPalette = new Dictionary<string, int>()
        //        {
        //            { "temp3", 3 },
        //            { "temp4", 3 }
        //        },
        //        Data = BuildSaveData()
        //    };

        //    return data;
        //}

        public static LevelEditorSaveData BuildSaveData()
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

        public static LevelEditorCustomData BuildCustomData()
        {
            return new LevelEditorCustomData()
            {
                isArray = false,
                type = typeof(string).FullName,
                value = "Hello world"
            };
        }

        public static LevelEditorObjectData BuildObjectData()
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

        public static LevelEditorComponentData BuildComponentData()
        {
            return new LevelEditorComponentData()
            {
                type = typeof(Transform).FullName,
                properties = new LevelEditorPropertyData[2] { BuildPropertyData(), BuildPropertyData() }
            };
        }

        public static LevelEditorPropertyData BuildPropertyData()
        {
            return new LevelEditorPropertyData()
            {
                id = 0,
                isArray = false,
                type = typeof(Vector3),
                typeName = typeof(Vector3).FullName,
                value = new Vector3(1.5f, 25f, 33.33f)
            };
        }
    }
}
