using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
    public class ExposedToLevelEditorTests
    {
        private TestExposedBehavior testObject;

        [UnitySetUp]
        public IEnumerator Setup()
        {
            testObject = new GameObject().AddComponent<TestExposedBehavior>();

            yield break;
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            Object.DestroyImmediate(testObject.gameObject);

            yield break;
        }

        [UnityTest]
        public IEnumerator TestName()
        {
            AssertIsExposed(out IExposedToLevelEditor exposed);

            Assert.AreEqual(exposed.ComponentName, nameof(TestExposedBehavior));

            yield break;
        }

        [UnityTest]
        public IEnumerator TestOrder()
        {
            AssertIsExposed(out IExposedToLevelEditor exposed);

            Assert.AreEqual(exposed.Order, 0);

            yield break;
        }

        [UnityTest]
        public IEnumerator TestType()
        {
            AssertIsExposed(out IExposedToLevelEditor exposed);

            Assert.AreEqual(exposed.ComponentType, typeof(TestExposedBehavior));

            yield break;
        }

        [UnityTest]
        public IEnumerator TestVisibleFields()
        {
            AssertIsExposed(out IExposedToLevelEditor exposed);

            Assert.IsTrue(exposed.HasVisibleFields);

            yield break;
        }

        [UnityTest]
        public IEnumerator TestSetValue()
        {
            AssertIsExposed(out IExposedToLevelEditor exposed);

            int lastChanged = -1;
            object lastValue = null;

            exposed.OnValueChanged += (i, o) =>
            {
                lastChanged = i;
                lastValue = o;
            };

            AssertValueChanged<string>(0, "New string");
            AssertValueChanged<int>(1, 42);
            AssertValueChanged<Vector3>(2, new Vector3(1, 2, 3));
            AssertValueChanged<Color>(3, new Color(0.25f, 0.5f, 0.75f, 1f));
            AssertValueChanged<Color32>(4, new Color32(10, 20, 30, 40));
            AssertValueChanged<Transform>(5, testObject.transform);

            yield break;

            void AssertValueChanged<T>(int id, object value)
            {
                Debug.Log($"Assert value changed {id} {value}");

                exposed.SetValue(id, value, true);

                Assert.AreEqual(lastChanged, id, $"{id} ID did not match the last changed ({lastChanged}).");
                Assert.IsTrue(lastValue is T, $"{lastValue} is not {typeof(T)}.");
                Assert.AreEqual(lastValue, value, $"{lastValue} is not the same as {value}");
            }
        }

        [UnityTest]
        public IEnumerator TestGetValueType()
        {
            AssertIsExposed(out IExposedToLevelEditor exposed);
            
            Assert.AreEqual(typeof(string), exposed.GetValueType(0));
            Assert.AreEqual(typeof(int), exposed.GetValueType(1));
            Assert.AreEqual(typeof(Vector3), exposed.GetValueType(2));
            Assert.AreEqual(typeof(Color), exposed.GetValueType(3));
            Assert.AreEqual(typeof(Color32), exposed.GetValueType(4));
            Assert.AreEqual(typeof(Transform), exposed.GetValueType(5));
            
            yield break;
        }

        private void AssertIsExposed(out IExposedToLevelEditor exposed)
        {
            exposed = testObject.GetComponent<IExposedToLevelEditor>();

            Assert.IsNotNull(exposed, "ExposedBehavior has not been exposed.");
        }

        private class TestExposedBehavior : MonoBehaviour
        {
            [ExposeToLevelEditor(0)]
            public string stringValue = "";

            [ExposeToLevelEditor(1)]
            public int intValue;

            [ExposeToLevelEditor(2)]
            public Vector3 vector3Value;

            [ExposeToLevelEditor(3)]
            public Color colorValue;

            [ExposeToLevelEditor(4)]
            public Color32 color32Value;

            [ExposeToLevelEditor(5)]
            public Transform transformValue;

            [ExposeToLevelEditor(6)]
            public string nullStringValue;
        }
    }
}