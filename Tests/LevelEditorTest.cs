using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
    public class LevelEditorTest
    {
	    protected readonly List<GameObject> sceneObjects = new List<GameObject>();

        protected GameObject cube;
        protected GameObject cylinder;
        protected GameObject sphere;
        protected GameObject capsule;

        protected LevelEditor levelEditor;
        protected LevelEditorObjectManager objectManager;
        protected LevelEditorResourceList resources;
        protected LevelEditorSaveManager saveManager;

        [UnitySetUp]
        public IEnumerator SceneSetup()
        {
            sceneObjects.Clear();

            CreateResources();
            CreateManagers();
            SetUpWrappers();
            
            OnSceneSetup(sceneObjects);

#if UNITY_EDITOR
            yield return new EnterPlayMode();
#else
            yield return null;
#endif
        }

        protected virtual void OnSceneSetup(List<GameObject> objects) { }
        
        private void CreateResources()
		{
			resources = ScriptableObject.CreateInstance<LevelEditorResourceList>();

			cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

			sceneObjects.Add(cube);
			sceneObjects.Add(sphere);
			sceneObjects.Add(capsule);
			sceneObjects.Add(cylinder);

			LevelEditorResource cubeResource = new LevelEditorResource
			{
				Name = "Cube",
				Asset = cube,
				ID = "cube"
			};

			LevelEditorResource sphereResource = new LevelEditorResource
			{
				Name = "Sphere",
				Asset = sphere,
				ID = "sphere"
			};

			LevelEditorResource capsuleResource = new LevelEditorResource
			{
				Name = "Capsule",
				Asset = capsule,
				ID = "capsule"
			};

			LevelEditorResource cylinderResource = new LevelEditorResource
			{
				Name = "Cylinder",
				Asset = cylinder,
				ID = "cylinder"
			};

			resources.AddResource(cubeResource);
			resources.AddResource(sphereResource);
			resources.AddResource(capsuleResource);
			resources.AddResource(cylinderResource);
		}

		private void CreateManagers()
		{
			GameObject levelEditorGo = new GameObject("Level Editor");
			levelEditor = levelEditorGo.AddComponent<LevelEditor>();

			sceneObjects.Add(levelEditorGo);
			
			GameObject objectManagerGo = new GameObject("Object Manager");
			objectManager = objectManagerGo.AddComponent<LevelEditorObjectManager>();
			objectManager.Resources = resources;
			objectManager.PoolObjects = true;

			sceneObjects.Add(objectManagerGo);

			GameObject saveManagerGo = new GameObject("Save Manager");
			saveManager = saveManagerGo.AddComponent<LevelEditorSaveManager>();
			saveManager.ObjectManager = objectManager;

			sceneObjects.Add(saveManagerGo);

			levelEditor.ObjectManager = objectManager;
			levelEditor.SaveManager = saveManager;
		}

		private void SetUpWrappers()
		{
			if (!LevelEditorComponentWrapper.HasWrapper<Transform>())
			{
				LevelEditorComponentWrapper.RegisterWrapper<Transform, TransformWrapper>();
			}

			if (!LevelEditorComponentWrapper.HasWrapper<Rigidbody>())
			{
				LevelEditorComponentWrapper.RegisterWrapper<Rigidbody, RigidbodyWrapper>();
			}
		}

        [UnityTearDown]
        public IEnumerator TearDownScene()
        {
	        objectManager.DeleteAllObjects(false);
	        
	        Object.DestroyImmediate(resources);
	        
            for (int i = 0; i < sceneObjects.Count; i++)
            {
                Object.DestroyImmediate(sceneObjects[i].gameObject);
            }
            
            sceneObjects.Clear();

            OnTearDownScene();

#if UNITY_EDITOR
            yield return new ExitPlayMode();
#else
            yield return null;
#endif
        }

        protected virtual void OnTearDownScene() { }

        public static IEnumerator WaitFrames(int frames)
        {
	        for (int i = 0; i < frames; i++)
	        {
		        yield return null;
	        }
        }
        
        public static void AreApproximatelyEqual(Vector3 expected, Vector3 actual)
        {
	        Assert.AreApproximatelyEqual(expected.x, actual.x);
	        Assert.AreApproximatelyEqual(expected.y, actual.y);
	        Assert.AreApproximatelyEqual(expected.z, actual.z);
        }

        public static void AreApproximatelyEqual(Vector3 expected, Vector3 actual, float tolerance)
        {
	        Assert.AreApproximatelyEqual(expected.x, actual.x, tolerance);
	        Assert.AreApproximatelyEqual(expected.y, actual.y, tolerance);
	        Assert.AreApproximatelyEqual(expected.z, actual.z, tolerance);
        }
    }
}
