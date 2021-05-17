using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Hertzole.ALE
{
    [AddComponentMenu("")]
    public class TransformWrapper : LevelEditorComponentWrapper<Transform>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RegisterTransformWrapper()
        {
            if (ALESettings.Get().ApplyTransformWrapper)
            {
                RegisterWrapper<Transform, TransformWrapper>();
            }
        }

        public override int Order { get { return -100000; } }
        public override bool HasVisibleFields { get { return true; } }

        private const string POSITION = "position";
        private const string ROTATION = "rotation";
        private const string SCALE = "scale";
        private const string PARENT = "parent";

        private ReadOnlyCollection<ExposedProperty> cachedProperties = new ReadOnlyCollection<ExposedProperty>(new ExposedProperty[]
        {
            new ExposedProperty(0, typeof(Vector3), POSITION, null, true),
            new ExposedProperty(1, typeof(Vector3), ROTATION, null, true),
            new ExposedProperty(2, typeof(Vector3), SCALE, null, true),
            new ExposedProperty(3, typeof(Transform), PARENT, null, false)
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
                    return transform.position;
                case 1:
                    return transform.eulerAngles;
                case 2:
                    return transform.localScale;
                case 3:
                    return new ComponentDataWrapper(transform.parent);
                default:
                    throw new ArgumentException($"No exposed property with the ID '{id}'.");
            }
        }

        public override void SetValue(int id, object value, bool notify)
        {
            bool changed = false;

            switch (id)
            {
                case 0:
                    if (transform.position != (Vector3) value)
                    {
                        transform.position = (Vector3) value;
                        changed = true;
                    }

                    break;
                case 1:
                    if (transform.eulerAngles != (Vector3) value)
                    {
                        transform.eulerAngles = (Vector3) value;
                        changed = true;
                    }

                    break;
                case 2:
                    if (transform.localScale != (Vector3) value)
                    {
                        transform.localScale = (Vector3) value;
                        changed = true;
                    }

                    break;
                case 3:
                    if (value is ComponentDataWrapper wrapper && !wrapper.Equals(transform.parent))
                    {
                        if(wrapper.TryGetObject(out ILevelEditorObject parent))
                        {
                            transform.SetParent(parent.MyGameObject.transform);
                            LevelEditorObject.Parent = parent;
                            parent.AddChild(LevelEditorObject);
                        }
                        else
                        {
                            transform.SetParent(null);
                        }
                    }
                    
                    break;
                default:
                    throw new ArgumentException($"No exposed property with the ID '{id}'.");
            }

            if (notify && changed)
            {
                InvokeOnValueChanged(id, value);
            }
        }

        public override Type GetValueType(int id)
        {
            switch (id)
            {
                case 0:
                case 1:
                case 2:
                    return typeof(Vector3);
                case 3:
                    return typeof(Transform);
                default:
                    throw new ArgumentException($"No exposed property with the ID '{id}'.");
            }
        }
    }
}