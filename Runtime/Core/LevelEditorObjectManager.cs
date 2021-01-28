using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
    [AddComponentMenu("ALE/Object Manager", 2)]
#endif
    //TODO: Make pooling toggleable.
    public class LevelEditorObjectManager : MonoBehaviour, ILevelEditorObjectManager
    {
        [SerializeField]
        private ScriptableObject resources = null;

        private int instanceID;

        private ILevelEditorResources realResources;

        private List<ILevelEditorObject> allObjects = new List<ILevelEditorObject>();

        private Dictionary<string, Stack<ILevelEditorObject>> pooledObjects = new Dictionary<string, Stack<ILevelEditorObject>>();
        private Dictionary<string, List<ILevelEditorObject>> activeObjects = new Dictionary<string, List<ILevelEditorObject>>();
        private Dictionary<string, int> objectCount = new Dictionary<string, int>();

        public ILevelEditorResources Resources
        {
            get
            {
                if (realResources == null) { realResources = resources as ILevelEditorResources; }
                return realResources;
            }
        }

        public event EventHandler<LevelEditorObjectEventSpawningEvent> OnCreatingObject;
        public event EventHandler<LevelEditorObjectEventDeletingEvent> OnDeletingObject;
        public event EventHandler<LevelEditorObjectEvent> OnCreatedObject;
        public event EventHandler<LevelEditorObjectEvent> OnDeletedObject;

#if !ALE_STRIP_SAFETY || UNITY_EDITOR
        private void Awake()
        {
            if (!resources.ExistsAndImplements<ILevelEditorResources>(nameof(resources), this))
            {
                return;
            }
        }
#endif

        public ILevelEditorObject CreateObject(ILevelEditorResource resource, Vector3 position, Quaternion rotation, Transform parent, int instanceID)
        {
            if (resource.Asset is GameObject go)
            {
                LevelEditorObjectEventSpawningEvent args = new LevelEditorObjectEventSpawningEvent(resource);

                OnCreatingObject?.Invoke(this, args);

                if (args.Cancel)
                {
                    LevelEditorLogger.Log("CreateObject canceled. Returning null.");
                    return null;
                }

                ILevelEditorObject obj;

                if (pooledObjects.ContainsKey(resource.ID) && pooledObjects[resource.ID].Count > 0)
                {
                    obj = pooledObjects[resource.ID].Pop();
                    obj.MyGameObject.transform.SetPositionAndRotation(position, rotation);
                    obj.MyGameObject.transform.SetParent(parent);
                }
                else
                {
                    GameObject objGo = Instantiate(go, position, rotation, parent);
                    obj = objGo.GetOrAddComponent<LevelEditorObject>();
                    obj.ID = resource.ID;

                    objGo.GetOrAddComponent<TransformWrapper>();
                    if (objGo.TryGetComponent<Rigidbody>(out _))
                    {
                        objGo.GetOrAddComponent<RigidbodyWrapper>();
                    }
                }

                obj.MyGameObject.name = resource.Name;
                obj.InstanceID = instanceID;
                obj.MyGameObject.SetActive(true);

                if (instanceID >= this.instanceID)
                {
                    this.instanceID = instanceID + 1;
                }

                if (!activeObjects.ContainsKey(resource.ID))
                {
                    activeObjects.Add(resource.ID, new List<ILevelEditorObject>());
                }

                if (!objectCount.ContainsKey(resource.ID))
                {
                    objectCount.Add(resource.ID, 0);
                }

                activeObjects[resource.ID].Add(obj);
                objectCount[resource.ID]++;
                allObjects.Add(obj);

                if (obj.MyGameObject.TryGetComponent(out ILevelEditorPoolable poolable))
                {
                    poolable.OnLevelEditorUnpooled();
                }

                if (obj.MyGameObject.TryGetComponent(out ILevelEditorGizmos gizmos))
                {
                    LevelEditorGLRenderer.Add(gizmos);
                }

                OnCreatedObject?.Invoke(this, new LevelEditorObjectEvent(obj));

                return obj;
            }
            else
            {
                Debug.LogError($"Tried to create {resource.ID} but the asset is not a prefab.");
                return null;
            }
        }

        public void CreateObjectsFromSaveData(LevelEditorSaveData data)
        {
            if (data.objects != null && data.objects.Count > 0)
            {
                ILevelEditorObject[] allObjects = new ILevelEditorObject[data.objects.Count];

                for (int i = 0; i < data.objects.Count; i++)
                {
                    ILevelEditorObject obj = this.CreateObject(data.objects[i]);
                    allObjects[i] = obj;
                }

                Assert.AreEqual(data.objects.Count, allObjects.Length);

                for (int i = 0; i < allObjects.Length; i++)
                {
                    LevelEditorComponentData[] components = data.objects[i].components;
                    for (int j = 0; j < components.Length; j++)
                    {
                        LevelEditorPropertyData[] properties = components[j].properties;
                        for (int k = 0; k < properties.Length; k++)
                        {
                            if (properties[k].typeName == "UnityEngine.Component")
                            {
                                ILevelEditorObject targetObj = GetObject((int)properties[k].value);
                                properties[k].value = targetObj ?? null;
                            }
                        }
                    }

                    allObjects[i].ApplyExposedData(components);
                }
            }
        }

        public bool DeleteObject(ILevelEditorObject target)
        {
            if (target == null)
            {
                return false;
            }

            LevelEditorObjectEventDeletingEvent args = new LevelEditorObjectEventDeletingEvent(target);

            OnDeletingObject?.Invoke(this, args);

            if (args.Cancel)
            {
                LevelEditorLogger.Log("DeleteObject canceled.");
                return false;
            }

            DeleteObjectInternal(target);

            allObjects.Remove(target);

            return true;
        }

        public void DeleteAllObjects()
        {
            for (int i = 0; i < allObjects.Count; i++)
            {
                DeleteObjectInternal(allObjects[i]);
            }

            allObjects.Clear();
        }

        private void DeleteObjectInternal(ILevelEditorObject target)
        {
            if (!pooledObjects.ContainsKey(target.ID))
            {
                pooledObjects.Add(target.ID, new Stack<ILevelEditorObject>());
            }

            pooledObjects[target.ID].Push(target);
            activeObjects[target.ID].Remove(target);
            objectCount[target.ID]--;

            if (target.MyGameObject.TryGetComponent(out ILevelEditorPoolable poolable))
            {
                poolable.OnLevelEditorPooled();
            }

            if (target.MyGameObject.TryGetComponent(out ILevelEditorGizmos gizmos))
            {
                LevelEditorGLRenderer.Remove(gizmos);
            }

            target.MyGameObject.SetActive(false);

            OnDeletedObject?.Invoke(this, new LevelEditorObjectEvent(target));
        }

        public void ResetInstanceID()
        {
            instanceID = 0;
        }

        public List<ILevelEditorObject> GetAllObjects()
        {
            return allObjects;
        }

        public ILevelEditorObject GetObject(int instanceID)
        {
            for (int i = 0; i < allObjects.Count; i++)
            {
                if (allObjects[i].InstanceID == instanceID)
                {
                    return allObjects[i];
                }
            }

            return null;
        }

        public int GetObjectCount(string id)
        {
            if (objectCount.TryGetValue(id, out int count))
            {
                return count;
            }

            Debug.LogError("No object with the ID " + id + ".");
            return 0;
        }

        public int GetTotalObjectCount()
        {
            return allObjects.Count;
        }

        public int GetNextInstanceID()
        {
            return instanceID + 1;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (!resources.ExistsAndImplements<ILevelEditorResources>(nameof(resources), this, false))
            {
                resources = null;
            }
        }
#endif
    }
}
