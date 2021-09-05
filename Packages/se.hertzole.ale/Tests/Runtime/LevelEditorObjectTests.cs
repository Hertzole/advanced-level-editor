using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
    public class LevelEditorObjectTests : LevelEditorTest
    {
        [UnityTest]
        public IEnumerator ResetByteOnSpawn()
        {
            cube.AddComponent<ByteTest1>();
            cube.AddComponent<ByteTest2>();
            cube.AddComponent<ByteTest3>();
            cube.AddComponent<ByteTest4>();
            cube.AddComponent<ByteTest5>();
            cube.AddComponent<ByteTest6>();
            cube.AddComponent<ByteTest7>();
            cube.AddComponent<ByteTest8>();

            yield return null;

            ILevelEditorObject newCube = objectManager.CreateObject("cube");
            var byte1 = newCube.MyGameObject.GetComponent<ByteTest1>();
            var byte2 = newCube.MyGameObject.GetComponent<ByteTest2>();
            var byte3 = newCube.MyGameObject.GetComponent<ByteTest3>();
            var byte4 = newCube.MyGameObject.GetComponent<ByteTest4>();
            var byte5 = newCube.MyGameObject.GetComponent<ByteTest5>();
            var byte6 = newCube.MyGameObject.GetComponent<ByteTest6>();
            var byte7 = newCube.MyGameObject.GetComponent<ByteTest7>();
            var byte8 = newCube.MyGameObject.GetComponent<ByteTest8>();

            byte1.value = 1;
            byte2.value = 3;
            byte3.value1 = 4;
            byte3.value2 = 5;
            byte4.value1 = 6;
            byte4.value2 = 7;
            byte5.Value = 8;
            byte6.Value = 9;
            byte7.Value1 = 10;
            byte7.Value2 = 11;
            byte8.Value1 = 12;
            byte8.Value2 = 13;

            yield return null;

            objectManager.DeleteObject(newCube);

            yield return null;

            newCube = objectManager.CreateObject("cube");
            
            yield return null;

            byte1 = newCube.MyGameObject.GetComponent<ByteTest1>();
            byte2 = newCube.MyGameObject.GetComponent<ByteTest2>();
            byte3 = newCube.MyGameObject.GetComponent<ByteTest3>();
            byte4 = newCube.MyGameObject.GetComponent<ByteTest4>();
            byte5 = newCube.MyGameObject.GetComponent<ByteTest5>();
            byte6 = newCube.MyGameObject.GetComponent<ByteTest6>();
            byte7 = newCube.MyGameObject.GetComponent<ByteTest7>();
            byte8 = newCube.MyGameObject.GetComponent<ByteTest8>();
            
            Assert.AreEqual<byte>(byte1.value, 0);
            Assert.AreEqual<byte>(byte2.value, 0);
            Assert.AreEqual<byte>(byte3.value1, 0);
            Assert.AreEqual<byte>(byte3.value2, 0);
            Assert.AreEqual<byte>(byte4.value1, 0);
            Assert.AreEqual<byte>(byte4.value2, 0);
            Assert.AreEqual<byte>(byte5.Value, 0);
            Assert.AreEqual<byte>(byte6.Value, 0);
            Assert.AreEqual<byte>(byte7.Value1, 0);
            Assert.AreEqual<byte>(byte7.Value2, 0);
            Assert.AreEqual<byte>(byte8.Value1, 0);
            Assert.AreEqual<byte>(byte8.Value2, 0);
        }
        
        [UnityTest]
        public IEnumerator ResetVectorOnSpawn()
        {
            cube.AddComponent<Vector3Test1>();
            cube.AddComponent<Vector3Test2>();
            cube.AddComponent<Vector3Test3>();
            cube.AddComponent<Vector3Test4>();
            cube.AddComponent<Vector3Test5>();
            cube.AddComponent<Vector3Test6>();
            cube.AddComponent<Vector3Test7>();
            cube.AddComponent<Vector3Test8>();

            yield return null;

            ILevelEditorObject newCube = objectManager.CreateObject("cube");
            var v1 = newCube.MyGameObject.GetComponent<Vector3Test1>();
            var v2 = newCube.MyGameObject.GetComponent<Vector3Test2>();
            var v3 = newCube.MyGameObject.GetComponent<Vector3Test3>();
            var v4 = newCube.MyGameObject.GetComponent<Vector3Test4>();
            var v5 = newCube.MyGameObject.GetComponent<Vector3Test5>();
            var v6 = newCube.MyGameObject.GetComponent<Vector3Test6>();
            var v7 = newCube.MyGameObject.GetComponent<Vector3Test7>();
            var v8 = newCube.MyGameObject.GetComponent<Vector3Test8>();

            v1.value = Vector3.one * 1;
            v2.value = Vector3.one * 2;
            v3.value1 = Vector3.one * 3;
            v3.value2 = Vector3.one * 4;
            v4.value1 = Vector3.one * 5;
            v4.value2 = Vector3.one * 6;
            v5.Value = Vector3.one * 7;
            v6.Value = Vector3.one * 8;
            v7.Value1 = Vector3.one * 9;
            v7.Value2 = Vector3.one * 10;
            v8.Value1 = Vector3.one * 11;
            v8.Value2 = Vector3.one * 12;

            yield return null;

            objectManager.DeleteObject(newCube);

            yield return null;

            newCube = objectManager.CreateObject("cube");
            
            v1 = newCube.MyGameObject.GetComponent<Vector3Test1>();
            v2 = newCube.MyGameObject.GetComponent<Vector3Test2>();
            v3 = newCube.MyGameObject.GetComponent<Vector3Test3>();
            v4 = newCube.MyGameObject.GetComponent<Vector3Test4>();
            v5 = newCube.MyGameObject.GetComponent<Vector3Test5>();
            v6 = newCube.MyGameObject.GetComponent<Vector3Test6>();
            v7 = newCube.MyGameObject.GetComponent<Vector3Test7>();
            v8 = newCube.MyGameObject.GetComponent<Vector3Test8>();
            
            Assert.AreEqual(v1.value, Vector3.zero);
            Assert.AreEqual(v2.value, Vector3.zero);
            Assert.AreEqual(v3.value1, Vector3.zero);
            Assert.AreEqual(v3.value2, Vector3.zero);
            Assert.AreEqual(v4.value1, Vector3.zero);
            Assert.AreEqual(v4.value2, Vector3.zero);
            Assert.AreEqual(v5.Value, Vector3.zero);
            Assert.AreEqual(v6.Value, Vector3.zero);
            Assert.AreEqual(v7.Value1, Vector3.zero);
            Assert.AreEqual(v7.Value2, Vector3.zero);
            Assert.AreEqual(v8.Value1, Vector3.zero);
            Assert.AreEqual(v8.Value2, Vector3.zero);
        }
        
        [UnityTest]
        public IEnumerator ResetReferenceOnSpawn()
        {
            cube.AddComponent<TransformReferenceScript>();
            cube.AddComponent<GameObjectReferenceScript>();

            yield return null;

            ILevelEditorObject newCube = objectManager.CreateObject("cube");
            var ref1 = newCube.MyGameObject.GetComponent<TransformReferenceScript>();
            var ref2 = newCube.MyGameObject.GetComponent<GameObjectReferenceScript>();

            ref1.value = sphere.transform;
            ref2.value = capsule.gameObject;

            yield return null;

            objectManager.DeleteObject(newCube);

            yield return null;

            newCube = objectManager.CreateObject("cube");
            
            ref1 = newCube.MyGameObject.GetComponent<TransformReferenceScript>();
            ref2 = newCube.MyGameObject.GetComponent<GameObjectReferenceScript>();
            
            Assert.AreEqual(ref1.value, null);
            Assert.AreEqual(ref2.value, null);
        }
        
        [UnityTest]
        public IEnumerator ResetTransformOnSpawn()
        {
            ILevelEditorObject newCube = objectManager.CreateObject("cube");
            newCube.MyGameObject.transform.position = new Vector3(10, 20, 30);
            newCube.MyGameObject.transform.eulerAngles = new Vector3(10, 20, 30);
            newCube.MyGameObject.transform.localScale = new Vector3(10, 20, 30);

            yield return null;

            objectManager.DeleteObject(newCube);

            yield return null;

            newCube = objectManager.CreateObject("cube");
            
            Assert.AreEqual(newCube.MyGameObject.transform.position, Vector3.zero);
            Assert.AreEqual(newCube.MyGameObject.transform.eulerAngles, Vector3.zero);
            Assert.AreEqual(newCube.MyGameObject.transform.localScale, Vector3.one);
        }
    }
}
