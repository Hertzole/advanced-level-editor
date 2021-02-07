using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
    public class Serialization : SerializationTest
    {
        private LevelEditorObjectManager objectManager;
        private LevelEditorSaveManager saveManager;

        protected override void OnSceneSetup()
        {
            base.OnSceneSetup();

            GameObject prefabBase = GameObject.CreatePrimitive(PrimitiveType.Cube);
            prefabBase.name = "Prefab";

            LevelEditorResource resource = new LevelEditorResource()
            {
                Asset = prefabBase,
                Name = "Test prefab",
                ID = "test_prefab",
            };

            LevelEditorResourceList list = ScriptableObject.CreateInstance<LevelEditorResourceList>();
            list.AddResource(resource);

            objectManager = new GameObject("Object Manager").AddComponent<LevelEditorObjectManager>();
            objectManager.ResourcesObject = list;

            saveManager = new GameObject("Save manager").AddComponent<LevelEditorSaveManager>();
            saveManager.ObjectManager = objectManager;

            sceneObjects.Add(prefabBase);
            sceneObjects.Add(objectManager.gameObject);
            sceneObjects.Add(saveManager.gameObject);
        }

        [UnityTest]
        public IEnumerator SerializeJson()
        {
            ILevelEditorObject obj = objectManager.CreateObject("test_prefab", new Vector3(10, 15, 5));

            int instanceId = obj.InstanceID;

            saveManager.SaveLevel("test_level", FilePath);

            objectManager.DeleteAllObjects();

            yield return null;

            saveManager.LoadLevel(FilePath);

            obj = objectManager.GetObject(instanceId);

            Assert.AreEqual(instanceId, obj.InstanceID);
            Assert.AreEqual(obj.MyGameObject.transform.position, new Vector3(10, 15, 5));

            yield return null;
        }
    }
}
