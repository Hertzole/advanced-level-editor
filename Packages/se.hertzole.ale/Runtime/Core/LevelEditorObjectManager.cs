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
    public class LevelEditorObjectManager : MonoBehaviour, ILevelEditorObjectManager
    {
        [SerializeField] 
        private bool poolObjects = true;
        [SerializeField, RequireType(typeof(ILevelEditorResources))]
        private ScriptableObject resources = null;
        [SerializeField, RequireType(typeof(ILevelEditorUndo))]
        private GameObject undo = null;

        private uint nextInstanceID = 0;

        private ILevelEditorResources realResources;
        private ILevelEditorUndo undoComp;

        private readonly List<ILevelEditorObject> allObjects = new List<ILevelEditorObject>();

        private Dictionary<LevelEditorIdentifier, Stack<ILevelEditorObject>> pooledObjects = new Dictionary<LevelEditorIdentifier, Stack<ILevelEditorObject>>();
        private Dictionary<LevelEditorIdentifier, List<ILevelEditorObject>> activeObjects = new Dictionary<LevelEditorIdentifier, List<ILevelEditorObject>>();
        private Dictionary<LevelEditorIdentifier, int> objectCount = new Dictionary<LevelEditorIdentifier, int>();
        private Dictionary<uint, ILevelEditorObject> objectsWithId = new Dictionary<uint, ILevelEditorObject>();

        public bool PoolObjects { get { return poolObjects; } set { poolObjects = value; } }

        public ILevelEditorUndo Undo
        {
            get
            {
                if (undoComp == null && undo != null)
                {
                    undoComp = undo.GetComponent<ILevelEditorUndo>();
                }

                return undoComp;
            }
            set
            {
                undoComp = value;
                if (value is Component comp)
                {
                    undo = comp.gameObject;
                }
            }
        }

        public ILevelEditorResources Resources
        {
            get { return realResources ??= resources as ILevelEditorResources; }
            set
            {
                realResources = value;
                if (value is ScriptableObject so)
                {
                    resources = so;
                }
            }
        }

        public event EventHandler<LevelEditorObjectEventSpawningEvent> OnCreatingObject;
        public event EventHandler<LevelEditorObjectEventDeletingEvent> OnDeletingObject;

        public event EventHandler<LevelEditorObjectEvent> OnCreatedObject;
        public event EventHandler<LevelEditorObjectEvent> OnCreatedObjectFromSaveData;
        public event EventHandler<LevelEditorObjectEvent> OnDeletedObject;

        private void OnDestroy()
        {
            DeleteAllObjects(false);
        }

        public ILevelEditorObject CreateObject(ILevelEditorResource resource, Vector3 position, Quaternion rotation, Transform parent, uint instanceID, bool registerUndo = true)
        {
            LevelEditorLogger.Log($"Create object | Resource: {resource} | Position: {position} | Rotation: {rotation} | Parent: {parent} | Instance ID: {instanceID} | Register undo: {registerUndo}");

            if (resource.Asset is GameObject go)
            {
                return CreateLevelEditorObject((p, r, par) =>
                {
                    GameObject objGo = Instantiate(go, p, r, par);
                    return objGo.GetOrAddComponent<LevelEditorObject>();
                }, resource, instanceID, registerUndo, position, rotation, parent);
            }

            if (resource.Asset is Component comp)
            {
                return CreateLevelEditorObject((p, r, par) =>
                {
                    Component objGo = Instantiate(comp, p, r, par);
                    return objGo.gameObject.GetOrAddComponent<LevelEditorObject>();
                }, resource, instanceID, registerUndo, position, rotation, parent);
            }

            Debug.LogError($"Tried to create {resource.Name} ({resource.ID}) but the asset is not a prefab.");
            return null;
        }

        private ILevelEditorObject CreateLevelEditorObject(Func<Vector3, Quaternion, Transform, ILevelEditorObject> createObject, ILevelEditorResource resource, uint instanceID, bool registerUndo, Vector3 position, Quaternion rotation, Transform parent)
        {
            if (objectsWithId.ContainsKey(instanceID))
            {
                throw new DuplicateIDException($"There already is an object with the instance ID {instanceID}.");
            }

            LevelEditorObjectEventSpawningEvent args = new LevelEditorObjectEventSpawningEvent(resource);

            OnCreatingObject?.Invoke(this, args);

            if (args.Cancel)
            {
                LevelEditorLogger.Log("CreateObject canceled. Returning null.");
                return null;
            }
            
            ILevelEditorObject obj;

            if (poolObjects && pooledObjects.ContainsKey(resource.ID) && pooledObjects[resource.ID].Count > 0)
            {
                obj = pooledObjects[resource.ID].Pop();
                obj.MyGameObject.transform.SetPositionAndRotation(position, rotation);
                obj.MyGameObject.transform.SetParent(parent);
            }
            else
            {
                obj = createObject.Invoke(position, rotation, parent);
                obj.ID = resource.ID;

                LevelEditorComponentWrapper.AddWrappers(obj.MyGameObject);
                obj.GetExposedComponents();
            }
            
            obj.MyGameObject.name = resource.Name;
            obj.InstanceID = instanceID;
            obj.MyGameObject.SetActive(true);

            if (instanceID >= nextInstanceID)
            {
                nextInstanceID = instanceID;
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

            obj.OnUnPooled();

            objectsWithId[obj.InstanceID] = obj;

            OnCreatedObject?.Invoke(this, new LevelEditorObjectEvent(obj));

            if (registerUndo && Undo != null)
            {
                undoComp.AddAction(new CreateObjectUndoAction(resource, position, rotation, parent, instanceID, obj));
            }

            return obj;
        }

        public void CreateObjectsFromSaveData(LevelEditorSaveData data)
        {
            if (data.objects != null && data.objects.Count > 0)
            {
                ILevelEditorObject[] savedObjects = new ILevelEditorObject[data.objects.Count];

                for (int i = 0; i < data.objects.Count; i++)
                {
                    ILevelEditorObject obj = this.CreateObject(data.objects[i]);
                    savedObjects[i] = obj;
                }

                Assert.AreEqual(data.objects.Count, savedObjects.Length);

                for (int i = 0; i < savedObjects.Length; i++)
                {
                    LevelEditorComponentData[] components = data.objects[i].components;

                    if (savedObjects[i] == null)
                    {
                        continue;
                    }
                    
                    savedObjects[i].ApplyExposedData(components);
                    OnCreatedObjectFromSaveData?.Invoke(this, new LevelEditorObjectEvent(savedObjects[i]));
                }
            }
        }

        public bool DeleteObject(ILevelEditorObject target, bool registerUndo = true)
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

            DeleteObjectInternal(target, registerUndo);

            allObjects.Remove(target);

            return true;
        }

        public void DeleteAllObjects(bool registerUndo = true)
        {
            for (int i = 0; i < allObjects.Count; i++)
            {
                if(allObjects[i] == null || allObjects[i].MyGameObject == null)
                {
                    continue;
                }
                
                DeleteObjectInternal(allObjects[i], false);
            }

            allObjects.Clear();
        }

        private void DeleteObjectInternal(ILevelEditorObject target, bool registerUndo)
        {
            if (target.MyGameObject == null)
            {
                return;
            }
            
            if (!pooledObjects.ContainsKey(target.ID))
            {
                pooledObjects.Add(target.ID, new Stack<ILevelEditorObject>());
            }

            objectsWithId.Remove(target.InstanceID);

            pooledObjects[target.ID].Push(target);
            activeObjects[target.ID].Remove(target);
            objectCount[target.ID]--;

            target.OnPooled();

            if (target.MyGameObject.TryGetComponent(out ILevelEditorGizmos gizmos))
            {
                LevelEditorGLRenderer.Remove(gizmos);
            }

            if (target.Parent != null)
            {
                target.Parent.RemoveChild(target);
            }

            if (target.HasChildren())
            {
                //TODO: If deleting children, register delete multiple undo.
                for (int i = 0; i < target.Children.Count; i++)
                {
                    DeleteObject(target.Children[i], false);
                }

                target.Children.Clear();
            }

            if (registerUndo && Undo != null)
            {
                undoComp.AddAction(new DeleteObjectUndoAction(target));
            }
            
            if (poolObjects)
            {
                target.MyGameObject.SetActive(false);
            }
            else
            {
                Destroy(target.MyGameObject);
            }

            OnDeletedObject?.Invoke(this, new LevelEditorObjectEvent(target));
        }

        public void ResetInstanceID()
        {
            nextInstanceID = 0;
        }

        public List<ILevelEditorObject> GetAllObjects()
        {
            return allObjects;
        }

        public ILevelEditorObject GetObject(uint instanceID)
        {
            return objectsWithId.TryGetValue(instanceID, out ILevelEditorObject obj) ? obj : null;
        }

        public int GetObjectCount(LevelEditorIdentifier id)
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

        public uint GetNextInstanceID()
        {
            return nextInstanceID + 1;
        }
    }
}
