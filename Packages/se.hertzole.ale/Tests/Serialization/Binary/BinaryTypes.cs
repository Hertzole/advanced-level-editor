using MessagePack;
using NUnit.Framework;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
    public class BinaryTypes
    {
        [Test]
        public void TestVector2()
        {
            Vector2 value = new Vector2(1.1f, 22.22f);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Vector2>(bytes);
            Assert.AreEqual(1.1f, value.x);
            Assert.AreEqual(22.22f, value.y);
        }

        [Test]
        public void TestVector3()
        {
            Vector3 value = new Vector3(1.1f, 22.22f, 333.333f);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Vector3>(bytes);
            Assert.AreEqual(1.1f, value.x);
            Assert.AreEqual(22.22f, value.y);
            Assert.AreEqual(333.333f, value.z);
        }

        [Test]
        public void TestVector4()
        {
            Vector4 value = new Vector4(1.1f, 22.22f, 333.333f, 4444.4444f);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Vector4>(bytes);
            Assert.AreEqual(1.1f, value.x);
            Assert.AreEqual(22.22f, value.y);
            Assert.AreEqual(333.333f, value.z);
            Assert.AreEqual(4444.4444f, value.w);
        }

        [Test]
        public void TestQuaternion()
        {
            Quaternion value = new Quaternion(1.1f, 22.22f, 333.333f, 4444.4444f);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Quaternion>(bytes);
            Assert.AreEqual(1.1f, value.x);
            Assert.AreEqual(22.22f, value.y);
            Assert.AreEqual(333.333f, value.z);
            Assert.AreEqual(4444.4444f, value.w);
        }

        [Test]
        public void TestVector2Int()
        {
            Vector2Int value = new Vector2Int(1, 22);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Vector2Int>(bytes);
            Assert.AreEqual(1, value.x);
            Assert.AreEqual(22, value.y);
        }

        [Test]
        public void TestVector3Int()
        {
            Vector3Int value = new Vector3Int(1, 22, 333);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Vector3Int>(bytes);
            Assert.AreEqual(1, value.x);
            Assert.AreEqual(22, value.y);
            Assert.AreEqual(333, value.z);
        }

        [Test]
        public void TestColor()
        {
            Color value = new Color(0.15f, 0.25f, 0.50f, 0.75f);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Color>(bytes);
            Assert.AreEqual(0.15f, value.r);
            Assert.AreEqual(0.25f, value.g);
            Assert.AreEqual(0.50f, value.b);
            Assert.AreEqual(0.75f, value.a);
        }

        [Test]
        public void TestColor32()
        {
            Color32 value = new Color32(15, 25, 50, 75);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Color32>(bytes);
            Assert.AreEqual(15, value.r);
            Assert.AreEqual(25, value.g);
            Assert.AreEqual(50, value.b);
            Assert.AreEqual(75, value.a);
        }

        [Test]
        public void TestRect()
        {
            Rect value = new Rect(1, 2, 30, 40);
            byte[] bytes = MessagePackSerializer.Serialize(value);

            value = MessagePackSerializer.Deserialize<Rect>(bytes);
            Assert.AreEqual(1, value.x);
            Assert.AreEqual(2, value.y);
            Assert.AreEqual(30, value.width);
            Assert.AreEqual(40, value.height);
        }
    }
}
