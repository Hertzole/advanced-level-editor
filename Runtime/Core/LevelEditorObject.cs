using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
    [AddComponentMenu("")]
#endif
    public class LevelEditorObject : MonoBehaviour, ILevelEditorObject, IEquatable<LevelEditorObject>
    {
        private bool gotComponents = false;
        private bool gotPlayModeObjects = false;
        private bool markedForDeletion = false;

        private IExposedToLevelEditor[] exposedComponents;
        private ILevelEditorPlayModeObject[] playModeObjects;
        private ILevelEditorGizmos[] gizmos;
        private ILevelEditorPoolable[] poolables;
        private IExposedWrapper[] originalValues;
        private IExposedWrapper[] playModeValues;

        public string Name
        {
            get { return gameObject.name; }
            set
            {
                if (gameObject.name != value)
                {
                    gameObject.name = value;
                    OnStateChanged?.Invoke(this, new LevelEditorObjectStateArgs(gameObject.name, gameObject.activeInHierarchy));
                }
            }
        }
        public bool IsActive
        {
            get { return gameObject.activeInHierarchy; }
            set
            {
                if (gameObject.activeSelf != value)
                {
                    gameObject.SetActive(value);
                    OnStateChanged?.Invoke(this, new LevelEditorObjectStateArgs(gameObject.name, gameObject.activeInHierarchy));
                }
            }
        }

        public bool IsDestroyed { get; private set; }

        public LevelEditorIdentifier ID { get; set; }
        public uint InstanceID { get; set; }

        public ILevelEditorObject Parent { get; set; }

        public List<ILevelEditorObject> Children { get; set; } = new List<ILevelEditorObject>();

        GameObject ILevelEditorObject.MyGameObject { get { return markedForDeletion ? null : gameObject; } }

        public event EventHandler<LevelEditorObjectStateArgs> OnStateChanged;

        private void Awake()
        {
            gizmos = GetComponentsInChildren<ILevelEditorGizmos>();
            poolables = GetComponentsInChildren<ILevelEditorPoolable>();
        }

        private void OnEnable()
        {
            for (int i = 0; i < gizmos.Length; i++)
            {
                LevelEditorGLRenderer.Add(gizmos[i]);
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < gizmos.Length; i++)
            {
                LevelEditorGLRenderer.Remove(gizmos[i]);
            }
        }

        private void OnDestroy()
        {
            markedForDeletion = true;
        }

        public IExposedToLevelEditor[] GetExposedComponents()
        {
            CacheExposedComponents();

            return exposedComponents;
        }

        public void ApplyExposedData(LevelEditorComponentData[] components)
        {
            CacheExposedComponents();
            
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i].type == null)
                {
                    continue;
                }
                
                string compName = components[i].type.FullName;
                
                for (int j = 0; j < exposedComponents.Length; j++)
                {
                    if (compName == exposedComponents[j].TypeName)
                    {
                        exposedComponents[j].ApplyWrapper(components[i].wrapper);
                    }
                }
            }
        }

        public void StartPlayMode()
        {
            CachePlayModeObjects();
            CacheExposedComponents();
            
            for (int i = 0; i < exposedComponents.Length; i++)
            {
                playModeValues[i] = exposedComponents[i].GetWrapper();
            }

            if (playModeObjects != null)
            {
                for (int i = 0; i < playModeObjects.Length; i++)
                {
                    playModeObjects[i].OnStartPlayMode();
                }
            }
        }

        public void StopPlayMode()
        {
            CachePlayModeObjects();
            CacheExposedComponents();

            for (int i = 0; i < exposedComponents.Length; i++)
            {
                exposedComponents[i].ApplyWrapper(playModeValues[i], true);
            }

            if (playModeObjects != null)
            {
                for (int i = 0; i < playModeObjects.Length; i++)
                {
                    playModeObjects[i].OnStopPlayMode();
                }
            }
        }

        public void AddChild(ILevelEditorObject child)
        {
            if (child == null || Children.Contains(child))
            {
                return;
            }

            Children.Add(child);
            child.MyGameObject.transform.SetParent(transform);
        }

        public void RemoveChild(ILevelEditorObject child)
        {
            if (child == null)
            {
                return;
            }

            Children.Remove(child);
        }
        
        private void CacheExposedComponents()
        {
            if (gotComponents)
            {
                return;
            }

            exposedComponents = GetComponents<IExposedToLevelEditor>();
            if (exposedComponents.Length > 1)
            {
                Array.Sort(exposedComponents, (x, y) => x.Order.CompareTo(y.Order));
            }

            if (exposedComponents != null && exposedComponents.Length > 0)
            {
                originalValues = new IExposedWrapper[exposedComponents.Length];

                for (int i = 0; i < originalValues.Length; i++)
                {
                    originalValues[i] = exposedComponents[i].GetWrapper();
                }

                playModeValues = new IExposedWrapper[exposedComponents.Length];
            }
            
            gotComponents = true;
        }

        private void CachePlayModeObjects()
        {
            if (gotPlayModeObjects)
            {
                return;
            }

            playModeObjects = GetComponentsInChildren<ILevelEditorPlayModeObject>();
            gotPlayModeObjects = true;
        }

        public bool Equals(LevelEditorObject other)
        {
            return Equals((ILevelEditorObject)other);
        }

        public bool Equals(ILevelEditorObject other)
        {
            return other != null && other.InstanceID == InstanceID && other.ID == ID;
        }

        public void OnPooled()
        {
            LevelEditorWorld.RemoveObject(this);
            IsDestroyed = true;

            for (int i = 0; i < poolables.Length; i++)
            {
                poolables[i].OnLevelEditorPooled();
            }
        }

        public void OnUnPooled()
        {
            IsDestroyed = false;
            LevelEditorWorld.AddObject(this);

            if (originalValues != null)
            {
                for (int i = 0; i < originalValues.Length; i++)
                {
                    exposedComponents[i].ApplyWrapper(originalValues[i], true);
                }
            }
            
            for (int i = 0; i < poolables.Length; i++)
            {
                poolables[i].OnLevelEditorUnpooled();
            }
        }
    }
}
