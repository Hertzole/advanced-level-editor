using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
    public abstract class SerializationTest
    {
        [Test]
        public void SaveDataSerialization()
        {
            LevelEditorSaveData data = BuildSaveData();

            LevelEditorSaveData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void CustomDataSerialization()
        {
            LevelEditorCustomData data = BuildCustomData();

            LevelEditorCustomData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void CustomDataArraySerialization()
        {
            LevelEditorCustomData data = BuildCustomData();
            data.type = typeof(string[]);
            data.typeName = typeof(string[]).FullName;
            data.value = new string[] { "Hello", "World" };
            data.isArray = true;

            LevelEditorSerializer.RegisterType<string[]>();

            LevelEditorCustomData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void ObjectDataSerialization()
        {
            LevelEditorObjectData data = BuildObjectData();

            LevelEditorObjectData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void ComponentDataSerialization()
        {
            LevelEditorComponentData data = BuildComponentData();

            LevelEditorComponentData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataSerialization()
        {
            LevelEditorPropertyData data = BuildPropertyData();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataStringSerialization()
        {
            LevelEditorPropertyData data = BuildPropertyData();
            data.typeName = typeof(string).FullName;
            data.type = typeof(string);
            data.value = "Hello world";

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataIntSerialization()
        {
            LevelEditorPropertyData data = BuildPropertyData();
            data.typeName = typeof(int).FullName;
            data.type = typeof(int);
            data.value = 65;

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataComponentSerialization()
        {
            LevelEditorPropertyData data = BuildPropertyData();
            data.typeName = typeof(Component).FullName;
            data.type = typeof(Component);
            data.value = null;

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataArraySerialization()
        {
            ExposedArray array = new ExposedArray(0, typeof(string[]), "test", null, true, typeof(string));
            LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
            {
                value = new string[] { "Hello", "World" }
            };

            LevelEditorSerializer.RegisterType<string[]>();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataListSerialization()
        {
            ExposedArray array = new ExposedArray(0, typeof(List<string>), "test", null, true, typeof(string));
            LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
            {
                value = new List<string>() { "Hello", "World" }
            };

            LevelEditorSerializer.RegisterType<List<string>>();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataComponentArraySerialization()
        {
            ExposedArray array = new ExposedArray(0, typeof(Component[]), "test", null, true, typeof(Component));
            LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
            {
                value = new Component[0]
            };

            LevelEditorSerializer.RegisterType<Component[]>();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataComponentListSerialization()
        {
            ExposedArray array = new ExposedArray(0, typeof(List<Component>), "test", null, true, typeof(List<Component>));
            LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
            {
                value = new List<Component>()
            };

            LevelEditorSerializer.RegisterType<List<Component>>();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataTransformArraySerialization()
        {
            ExposedArray array = new ExposedArray(0, typeof(Transform[]), "test", null, true, typeof(Transform));
            LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
            {
                value = new Transform[0]
            };

            LevelEditorSerializer.RegisterType<Component[]>();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataGameObjectArraySerialization()
        {
            ExposedArray array = new ExposedArray(0, typeof(GameObject[]), "test", null, true, typeof(GameObject));
            LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
            {
                value = new GameObject[0]
            };

            LevelEditorSerializer.RegisterType<GameObject[]>();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        [Test]
        public void PropertyDataGameObjectListSerialization()
        {
            ExposedArray array = new ExposedArray(0, typeof(List<GameObject>), "test", null, true, typeof(GameObject));
            LevelEditorPropertyData data = new LevelEditorPropertyData(array, null)
            {
                value = new List<GameObject>()
            };

            LevelEditorSerializer.RegisterType<List<GameObject>>();

            LevelEditorPropertyData newData = SerializeAndDeserialize(data);
            Assert.AreEqual(data, newData);
        }

        protected abstract T SerializeAndDeserialize<T>(T data);

        public static LevelEditorSaveData BuildSaveData()
        {
            return new LevelEditorSaveData()
            {
                name = "Test Level",
                objects = new List<LevelEditorObjectData>() { BuildObjectData(), BuildObjectData() },
                customData = new Dictionary<string, LevelEditorCustomData>()
                {
                    { "data1", new LevelEditorCustomData(typeof(string), false, "Hello world") },
                    { "data2", new LevelEditorCustomData(typeof(int), false, 42) }
                }
            };
        }

        public static LevelEditorCustomData BuildCustomData()
        {
            return new LevelEditorCustomData(typeof(string), false, "Hello world");
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
                type = typeof(Vector3),
                typeName = typeof(Vector3).FullName,
                value = new Vector3(1.5f, 25f, 33.33f)
            };
        }
    }
}
