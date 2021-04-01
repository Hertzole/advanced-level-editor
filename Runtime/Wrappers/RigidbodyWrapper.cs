using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Hertzole.ALE
{
    public class RigidbodyWrapper : LevelEditorComponentWrapper<Rigidbody>, ILevelEditorPlayModeObject
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RegisterRigidbodyWrapper()
        {
            Debug.Log(ALESettings.Get().ApplyRigidbodyWrapper);
            
            if (ALESettings.Get().ApplyRigidbodyWrapper)
            {
                RegisterWrapper<Rigidbody, RigidbodyWrapper>();
            }
        }

        public override bool HasVisibleFields { get { return true; } }

        private bool useGravity;
        private bool isKinematic;

        private void Awake()
        {
            useGravity = Target.useGravity;
            isKinematic = Target.isKinematic;

            Target.useGravity = false;
            Target.isKinematic = true;
        }

        private ReadOnlyCollection<ExposedProperty> cachedProperties = new ReadOnlyCollection<ExposedProperty>(new ExposedProperty[]
        {
            new ExposedProperty(0, typeof(float), "mass", null, true),
            new ExposedProperty(1, typeof(float), "drag", null, true),
            new ExposedProperty(2, typeof(float), "angularDrag", null, true),
            new ExposedProperty(3, typeof(bool), "useGravity", null, true),
            new ExposedProperty(4, typeof(bool), "isKinematic", null, true)
        });

        public override ReadOnlyCollection<ExposedProperty> GetProperties()
        {
            return cachedProperties;
        }

        public override object GetValue(int id)
        {
            switch (id)
            {
                case 0:
                    return Target.mass;
                case 1:
                    return Target.drag;
                case 2:
                    return Target.angularDrag;
                case 3:
                    return useGravity;
                case 4:
                    return isKinematic;
                default:
                    throw new ArgumentException($"There's no exposed field with the ID '{id}'.");
            }
        }

        public override Type GetValueType(int id)
        {
            switch (id)
            {
                case 0:
                case 1:
                case 2:
                    return typeof(float);
                case 3:
                case 4:
                    return typeof(bool);
                default:
                    throw new ArgumentException($"There's no exposed field with the ID '{id}'.");
            }
        }

        public override void SetValue(int id, object value, bool notify)
        {
            bool changed = false;

            switch (id)
            {
                case 0:
                    if ((float)value != Target.mass)
                    {
                        Target.mass = (float)value;
                        changed = true;
                    }
                    break;
                case 1:
                    if ((float)value != Target.drag)
                    {
                        Target.drag = (float)value;
                        changed = true;
                    }
                    break;
                case 2:
                    if ((float)value != Target.angularDrag)
                    {
                        Target.angularDrag = (float)value;
                        changed = true;
                    }
                    break;
                case 3:
                    if ((bool)value != useGravity)
                    {
                        useGravity = (bool)value;
                        changed = true;
                    }
                    break;
                case 4:
                    if ((bool)value != isKinematic)
                    {
                        isKinematic = (bool)value;
                        changed = true;
                    }
                    break;
                default:
                    Debug.LogWarning($"There's no exposed fields with the ID {id}.");
                    break;
            }

            if (notify && changed)
            {
                InvokeOnValueChanged(id, value);
            }
        }

        void ILevelEditorPlayModeObject.OnStartPlayMode()
        {
            Target.useGravity = useGravity;
            Target.isKinematic = isKinematic;
        }

        void ILevelEditorPlayModeObject.OnStopPlayMode()
        {
            Target.useGravity = false;
            Target.isKinematic = true;
        }
    }
}
