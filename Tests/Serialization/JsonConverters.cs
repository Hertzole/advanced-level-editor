#if ALE_JSON
using Hertzole.ALE.Json;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
    public class JsonConverters : SerializationTest
    {
        private JsonSerializerSettings settings;

        protected override void OnSceneSetup()
        {
            base.OnSceneSetup();

            settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>()
                {
                    new Color32Converter(),
                    new ColorConverter(),
                    new ComponentConverter(),
                    new Vector2Converter(),
                    new Vector2IntConverter(),
                    new Vector3Converter(),
                    new Vector3IntConverter(),
                    new Vector4Converter(),
                    new QuaternionConverter(),
                    new RectConverter()
                }
            };
        }

        [UnityTest]
        public IEnumerator TestColor32()
        {
            Color32 value = new Color32(10, 20, 30, 40);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"r\":10,\"g\":20,\"b\":30,\"a\":40}", json);

            value = JsonConvert.DeserializeObject<Color32>(json, settings);

            Assert.AreEqual<byte>(10, value.r);
            Assert.AreEqual<byte>(20, value.g);
            Assert.AreEqual<byte>(30, value.b);
            Assert.AreEqual<byte>(40, value.a);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestColor()
        {
            Color value = new Color(0.25f, 0.5f, 0.75f, 1f);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"r\":64,\"g\":128,\"b\":191,\"a\":255}", json);

            value = JsonConvert.DeserializeObject<Color>(json, settings);

            Assert.AreApproximatelyEqual(0.25f, value.r, 0.01f);
            Assert.AreApproximatelyEqual(0.5f, value.g, 0.01f);
            Assert.AreApproximatelyEqual(0.75f, value.b, 0.01f);
            Assert.AreApproximatelyEqual(1f, value.a, 0.01f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestVector2()
        {
            Vector2 value = new Vector2(5.5f, 10.25f);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"x\":5.5,\"y\":10.25}", json);

            value = JsonConvert.DeserializeObject<Vector2>(json, settings);

            Assert.AreEqual(value.x, 5.5f);
            Assert.AreEqual(value.y, 10.25f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestVector2Int()
        {
            Vector2Int value = new Vector2Int(5, 10);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"x\":5,\"y\":10}", json);

            value = JsonConvert.DeserializeObject<Vector2Int>(json, settings);

            Assert.AreEqual(value.x, 5);
            Assert.AreEqual(value.y, 10);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestVector3()
        {
            Vector3 value = new Vector3(5.5f, 10.25f, 20.75f);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"x\":5.5,\"y\":10.25,\"z\":20.75}", json);

            value = JsonConvert.DeserializeObject<Vector3>(json, settings);

            Assert.AreEqual(value.x, 5.5f);
            Assert.AreEqual(value.y, 10.25f);
            Assert.AreEqual(value.z, 20.75f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestVector3Int()
        {
            Vector3Int value = new Vector3Int(5, 10, 20);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"x\":5,\"y\":10,\"z\":20}", json);

            value = JsonConvert.DeserializeObject<Vector3Int>(json, settings);

            Assert.AreEqual(value.x, 5);
            Assert.AreEqual(value.y, 10);
            Assert.AreEqual(value.z, 20);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestVector4()
        {
            Vector4 value = new Vector4(5.5f, 10.25f, 20.75f, 30.44f);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"x\":5.5,\"y\":10.25,\"z\":20.75,\"w\":30.44}", json);

            value = JsonConvert.DeserializeObject<Vector4>(json, settings);

            Assert.AreEqual(value.x, 5.5f);
            Assert.AreEqual(value.y, 10.25f);
            Assert.AreEqual(value.z, 20.75f);
            Assert.AreEqual(value.w, 30.44f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestQuaternion()
        {
            Quaternion value = new Quaternion(5.5f, 10.25f, 20.75f, 30.44f);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"x\":5.5,\"y\":10.25,\"z\":20.75,\"w\":30.44}", json);

            value = JsonConvert.DeserializeObject<Quaternion>(json, settings);

            Assert.AreEqual(value.x, 5.5f);
            Assert.AreEqual(value.y, 10.25f);
            Assert.AreEqual(value.z, 20.75f);
            Assert.AreEqual(value.w, 30.44f);

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestRect()
        {
            Rect value = new Rect(5.5f, 10.25f, 20.75f, 30.44f);
            string json = JsonConvert.SerializeObject(value, settings);

            Assert.AreEqual("{\"x\":5.5,\"y\":10.25,\"w\":20.75,\"h\":30.44}", json);

            value = JsonConvert.DeserializeObject<Rect>(json, settings);

            Assert.AreEqual(value.x, 5.5f);
            Assert.AreEqual(value.y, 10.25f);
            Assert.AreEqual(value.width, 20.75f);
            Assert.AreEqual(value.height, 30.44f);

            yield return null;
        }
    }
}
#endif
