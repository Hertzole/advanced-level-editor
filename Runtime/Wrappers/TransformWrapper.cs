using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class TransformWrapper : MonoBehaviour, IExposedToLevelEditor
    {
        string IExposedToLevelEditor.ComponentName { get { return "Transform"; } }

        string IExposedToLevelEditor.TypeName { get { return "UnityEngine.Transform"; } }

        int IExposedToLevelEditor.Order { get { return -100000; } }

        private const string POSITION = "position";
        private const string ROTATION = "rotation";
        private const string SCALE = "scale";
        private const string PARENT = "parent";

        public event Action<string, object> OnValueChanged;

        ExposedProperty[] IExposedToLevelEditor.GetProperties()
        {
            return new ExposedProperty[4]
            {
                new ExposedProperty(typeof(Vector3), POSITION, true, false, Array.Empty<string>()),
                new ExposedProperty(typeof(Vector3), ROTATION, true, false, Array.Empty<string>()),
                new ExposedProperty(typeof(Vector3), SCALE, true, false, Array.Empty<string>()),
                new ExposedProperty(typeof(Transform), PARENT, false, false, Array.Empty<string>()),
            };
        }

        object IExposedToLevelEditor.GetValue(string valueName)
        {
            switch (valueName)
            {
                case POSITION:
                    return transform.position;
                case ROTATION:
                    return transform.eulerAngles;
                case SCALE:
                    return transform.localScale;
                case PARENT:
                    return transform.parent;
                default:
                    throw new ArgumentException($"No exposed property called '{valueName}'.");
            }
        }

        void IExposedToLevelEditor.SetValue(string valueName, object value, bool notify)
        {
            bool changed = false;

            switch (valueName)
            {
                case POSITION:
                    if (transform.position != (Vector3)value)
                    {
                        transform.position = (Vector3)value;
                        changed = true;
                    }
                    break;
                case ROTATION:
                    if (transform.eulerAngles != (Vector3)value)
                    {
                        transform.eulerAngles = (Vector3)value;
                        changed = true;
                    }
                    break;
                case SCALE:
                    if (transform.localScale != (Vector3)value)
                    {
                        transform.localScale = (Vector3)value;
                        changed = true;
                    }
                    break;
                case PARENT:
                    if (transform.parent != (Transform)value)
                    {
                        transform.SetParent((Transform)value, true);
                        changed = true;
                    }
                    break;
                default:
                    throw new ArgumentException($"No exposed property called '{valueName}'.");
            }

            if (notify && changed)
            {
                OnValueChanged?.Invoke(valueName, value);
            }
        }

        Type IExposedToLevelEditor.GetValueType(string valueName)
        {
            switch (valueName)
            {
                case POSITION:
                case ROTATION:
                case SCALE:
                    return typeof(Vector3);
                case PARENT:
                    return typeof(Transform);
                default:
                    throw new ArgumentException($"No exposed property called '{valueName}'.");
            }
        }
    }
}
