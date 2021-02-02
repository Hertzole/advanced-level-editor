using System;
using UnityEngine;

namespace Hertzole.ALE
{
    [AddComponentMenu("")]
    public class TransformWrapper : MonoBehaviour, IExposedToLevelEditor
    {
        private ILevelEditorObject levelEditorObject;
        private ILevelEditorObject LevelEditorObject
        {
            get
            {
                if (levelEditorObject == null)
                {
                    levelEditorObject = GetComponent<LevelEditorObject>();
                }

                return levelEditorObject;
            }
        }

        string IExposedToLevelEditor.ComponentName { get { return "Transform"; } }

        string IExposedToLevelEditor.TypeName { get { return "UnityEngine.Transform"; } }

        int IExposedToLevelEditor.Order { get { return -100000; } }

        private const string POSITION = "position";
        private const string ROTATION = "rotation";
        private const string SCALE = "scale";
        private const string PARENT = "parent";

        public event Action<int, object> OnValueChanged;

        ExposedProperty[] IExposedToLevelEditor.GetProperties()
        {
            return new ExposedProperty[4]
            {
                new ExposedProperty(0, typeof(Vector3), POSITION, null, true, false),
                new ExposedProperty(1, typeof(Vector3), ROTATION, null, true, false),
                new ExposedProperty(2, typeof(Vector3), SCALE, null, true, false),
                new ExposedProperty(3, typeof(Transform), PARENT, null, false, false),
            };
        }

        object IExposedToLevelEditor.GetValue(int id)
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
                    return transform.parent == null ? null : transform.parent;
                default:
                    throw new ArgumentException($"No exposed property with the ID '{id}'.");
            }
        }

        void IExposedToLevelEditor.SetValue(int id, object value, bool notify)
        {
            bool changed = false;

            switch (id)
            {
                case 0:
                    if (transform.position != (Vector3)value)
                    {
                        transform.position = (Vector3)value;
                        changed = true;
                    }
                    break;
                case 1:
                    if (transform.eulerAngles != (Vector3)value)
                    {
                        transform.eulerAngles = (Vector3)value;
                        changed = true;
                    }
                    break;
                case 2:
                    if (transform.localScale != (Vector3)value)
                    {
                        transform.localScale = (Vector3)value;
                        changed = true;
                    }
                    break;
                case 3:
                    if (transform.parent != (Transform)value)
                    {
                        transform.SetParent((Transform)value, true);
                        changed = true;
                        if (transform.parent != null)
                        {
                            LevelEditorObject.Parent = transform.parent.GetComponent<ILevelEditorObject>();
                            levelEditorObject.Parent.AddChild(levelEditorObject);
                        }
                    }
                    break;
                default:
                    throw new ArgumentException($"No exposed property with the ID '{id}'.");
            }

            if (notify && changed)
            {
                OnValueChanged?.Invoke(id, value);
            }
        }

        Type IExposedToLevelEditor.GetValueType(int id)
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
