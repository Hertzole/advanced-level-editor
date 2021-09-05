// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
//
// namespace Hertzole.ALE.Tests
// {
//     public class Equals
//     {
//         [Test]
//         public void SaveDataEquals()
//         {
//             EqualTest(BuildSaveData(), BuildSaveData());
//         }
//
//         [Test]
//         public void CustomDataEquals()
//         {
//             EqualTest(BuildCustomData(), BuildCustomData());
//         }
//
//         [Test]
//         public void ObjectDataEquals()
//         {
//             EqualTest(BuildObjectData(), BuildObjectData());
//         }
//
//         [Test]
//         public void ComponentDataEquals()
//         {
//             EqualTest(BuildComponentData(), BuildComponentData());
//         }
//
//         [Test]
//         public void PropertyDataEquals()
//         {
//             EqualTest(BuildPropertyData(), BuildPropertyData());
//         }
//
//         [Test]
//         public void PropertyDataArrayEquals()
//         {
//             LevelEditorPropertyData a = BuildPropertyData();
//             LevelEditorPropertyData b = BuildPropertyData();
//
//             a.type = typeof(string[]);
//             a.typeName = typeof(string[]).FullName;
//             a.value = new string[] { "Hello", "World" };
//
//             b.type = typeof(string[]);
//             b.typeName = typeof(string[]).FullName;
//             b.value = new string[] { "Hello", "World" };
//
//             EqualTest(a, b);
//         }
//
//         private void EqualTest<T>(T a, T b)
//         {
//             Assert.AreEqual(a, b);
//         }
//         
//         public static LevelEditorSaveData BuildSaveData()
//         {
//             return new LevelEditorSaveData()
//             {
//                 name = "Test Level",
//                 objects = new List<LevelEditorObjectData>() { BuildObjectData(), BuildObjectData() },
//                 customData = new Dictionary<string, LevelEditorCustomData>()
//                 {
//                     { "data1", new LevelEditorCustomData(typeof(string), "Hello world") },
//                     { "data2", new LevelEditorCustomData(typeof(int), 42) }
//                 }
//             };
//         }
//         
//         public static LevelEditorCustomData BuildCustomData()
//         {
//             return new LevelEditorCustomData(typeof(string), "Hello world");
//         }
//         
//         public static LevelEditorObjectData BuildObjectData()
//         {
//             return new LevelEditorObjectData()
//             {
//                 active = true,
//                 name = "Test Object",
//                 id = "test_object",
//                 instanceId = 1,
//                 components = new LevelEditorComponentData[2] { BuildComponentData(), BuildComponentData() }
//             };
//         }
//         
//         public static LevelEditorComponentData BuildComponentData()
//         {
//             return new LevelEditorComponentData()
//             {
//                 type = typeof(Transform),
//                 // properties = new LevelEditorPropertyData[2] { BuildPropertyData(), BuildPropertyData() }
//             };
//         }
//         
//         public static LevelEditorPropertyData BuildPropertyData()
//         {
//             return new LevelEditorPropertyData()
//             {
//                 id = 0,
//                 type = typeof(Vector3),
//                 typeName = typeof(Vector3).FullName,
//                 value = new Vector3(1.5f, 25f, 33.33f)
//             };
//         }
//     }
// }
