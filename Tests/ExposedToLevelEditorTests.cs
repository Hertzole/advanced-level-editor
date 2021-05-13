using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
    public class ExposedToLevelEditorTests : LevelEditorTest
    {
        private TestExposedBehavior testObject;

        protected override void OnSceneSetup(List<GameObject> sceneObjects)
        {
            testObject = new GameObject().AddComponent<TestExposedBehavior>();

            sceneObjects.Add(testObject.gameObject);
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
            bool second = false;

            exposed.OnValueChanged += (i, o) =>
            {
                lastChanged = i;
                lastValue = o;
            };

            AssertValueChanged<string>(0, "New string");
            AssertValueChanged<int>(1, 42);
            AssertValueChanged<Vector3>(2, new Vector3(1, 2, 3));
            AssertValueChanged<Color>(3, new Color(0.25f, 0.5f, 0.75f, 1f));
            // AssertValueChanged<Transform>(5, testObject.transform);
            AssertValueChanged<Color32>(4, new Color32(10, 20, 30, 40));
            AssertValueChanged<string>(6, "New value");
            AssertValueChanged<string[]>(7, new string[] { "Hello", "World!" });
            AssertValueChanged<string[]>(8, new string[] { "Hello from other side" });
            AssertValueChanged<int[]>(9, new int[] { 0, 1, 2, 3 });
            AssertValueChanged<List<string>>(10, new List<string> { "Hello", "World" });
            // AssertValueChanged<GameObject>(11, testObject.gameObject);
            // AssertValueChanged<List<Transform>>(12, new List<Transform>(){ testObject.transform });
            // AssertValueChanged<List<TestExposedBehavior>>(13, new List<TestExposedBehavior>(){ testObject });

            yield break;

            void AssertValueChanged<T>(int id, object value)
            {
                lastChanged = -1;
                lastValue = null;

                exposed.SetValue(id, value, true);

                Assert.AreEqual(lastChanged, id, $"{id} ID did not match the last changed ({lastChanged}).");
                if (value == null)
                {
                    Assert.IsNull(lastValue, "Last value was not null when a null value was set.");
                }
                else
                {
                    Assert.IsTrue(lastValue is T, $"{lastValue} is not {typeof(T)}.");
                }

                Assert.AreEqual(lastValue, value, $"{lastValue} is not the same as {value}");

                if (!second)
                {
                    second = true;
                    AssertValueChanged<T>(id, default(T));
                }
                else
                {
                    second = false;
                }
            }
        }

        // [UnityTest]
        // public IEnumerator TestGetValueType()
        // {
        //     AssertIsExposed(out IExposedToLevelEditor exposed);
        //
        //     Assert.AreEqual(typeof(string), exposed.GetValueType(0));
        //     Assert.AreEqual(typeof(int), exposed.GetValueType(1));
        //     Assert.AreEqual(typeof(Vector3), exposed.GetValueType(2));
        //     Assert.AreEqual(typeof(Color), exposed.GetValueType(3));
        //     Assert.AreEqual(typeof(Color32), exposed.GetValueType(4));
        //     Assert.AreEqual(typeof(Transform), exposed.GetValueType(5));
        //     Assert.AreEqual(typeof(string), exposed.GetValueType(6));
        //     Assert.AreEqual(typeof(string[]), exposed.GetValueType(7));
        //     Assert.AreEqual(typeof(string[]), exposed.GetValueType(8));
        //     Assert.AreEqual(typeof(int[]), exposed.GetValueType(9));
        //     Assert.AreEqual(typeof(List<string>), exposed.GetValueType(10));
        //     Assert.AreEqual(typeof(GameObject), exposed.GetValueType(11));
        //     Assert.AreEqual(typeof(List<Transform>), exposed.GetValueType(12));
        //     Assert.AreEqual(typeof(List<TestExposedBehavior>), exposed.GetValueType(13));
        //
        //     yield break;
        // }

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
            [ExposeToLevelEditor(7)]
            public string[] nullStringArray;
            [ExposeToLevelEditor(8)]
            public string[] stringArray = new string[] { "Hello", "World" };
            [ExposeToLevelEditor(9)]
            public int[] intArray;
            [ExposeToLevelEditor(10)]
            public List<string> stringList = new List<string>();
            [ExposeToLevelEditor(11)]
            public GameObject gameObjectField;
            [ExposeToLevelEditor(12)]
            public List<Transform> transformList = new List<Transform>();
            [ExposeToLevelEditor(13)]
            public List<TestExposedBehavior> exposedList = new List<TestExposedBehavior>();
        }
    }
}
