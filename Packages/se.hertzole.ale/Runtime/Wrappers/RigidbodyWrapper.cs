using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class RigidbodyWrapper : MonoBehaviour, IExposedToLevelEditor, ILevelEditorPlayModeObject
    {
        private bool useGravity;
        private bool isKinematic;

        private Rigidbody rb;
        private Rigidbody Rb
        {
            get
            {
                if (rb == null)
                {
                    rb = GetComponent<Rigidbody>();
                    useGravity = rb.useGravity;
                    isKinematic = rb.isKinematic;
                }
                return rb;
            }
        }

        string IExposedToLevelEditor.ComponentName { get { return "Rigidbody"; } }

        string IExposedToLevelEditor.TypeName { get { return "UnityEngine.Rigidbody"; } }

        int IExposedToLevelEditor.Order { get { return 0; } }

        public event Action<int, object> OnValueChanged;

        private void Awake()
        {
            Rb.useGravity = false;
            Rb.isKinematic = true;
        }

        ExposedProperty[] IExposedToLevelEditor.GetProperties()
        {
            return new ExposedProperty[]
            {
                new ExposedProperty(0, typeof(float), "mass", null, true, false),
                new ExposedProperty(1, typeof(float), "drag", null, true, false),
                new ExposedProperty(2, typeof(float), "angularDrag", null, true, false),
                new ExposedProperty(3, typeof(bool), "useGravity", null, true, false),
                new ExposedProperty(4, typeof(bool), "isKinematic", null, true, false)
            };
        }

        object IExposedToLevelEditor.GetValue(int id)
        {
            switch (id)
            {
                case 0:
                    return Rb.mass;
                case 1:
                    return Rb.drag;
                case 2:
                    return Rb.angularDrag;
                case 3:
                    return useGravity;
                case 4:
                    return isKinematic;
                default:
                    throw new ArgumentException($"There's no exposed field with the ID '{id}'.");
            }
        }

        Type IExposedToLevelEditor.GetValueType(int id)
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

        void IExposedToLevelEditor.SetValue(int id, object value, bool notify)
        {
            bool changed = false;

            switch (id)
            {
                case 0:
                    if ((float)value != Rb.mass)
                    {
                        Rb.mass = (float)value;
                        changed = true;
                    }
                    break;
                case 1:
                    if ((float)value != Rb.drag)
                    {
                        Rb.drag = (float)value;
                        changed = true;
                    }
                    break;
                case 2:
                    if ((float)value != Rb.angularDrag)
                    {
                        Rb.angularDrag = (float)value;
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
                    break;
            }

            if (notify && changed)
            {
                OnValueChanged?.Invoke(id, value);
            }
        }

        void ILevelEditorPlayModeObject.OnStartPlayMode()
        {
            Rb.useGravity = useGravity;
            Rb.isKinematic = isKinematic;
        }

        void ILevelEditorPlayModeObject.OnStopPlayMode()
        {
            Rb.useGravity = false;
            Rb.isKinematic = true;
        }
    }
}
