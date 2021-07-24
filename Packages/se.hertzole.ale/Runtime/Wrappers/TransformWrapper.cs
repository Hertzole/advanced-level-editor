using System;
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
            LevelEditorSerializer.RegisterType<Transform>();
            
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
                        SetParent(wrapper);
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

        private void SetParent(ComponentDataWrapper wrapper)
        {
            if(wrapper.TryGetObject(out ILevelEditorObject parent))
            {
                Target.SetParent(parent.MyGameObject.transform);
                LevelEditorObject.Parent = parent;
                parent.AddChild(LevelEditorObject);
            }
            else
            {
                Target.SetParent(null);
            }
        }

        public override IExposedWrapper GetWrapper()
        {
            return new Wrapper(Target.position, Target.eulerAngles, Target.localScale, new ComponentDataWrapper(Target.parent));
        }

        public override void ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyMask = false)
        {
            if (wrapper is Wrapper w)
            {
                Target.SetPositionAndRotation(w.position, Quaternion.Euler(w.rotation));
                Target.localScale = w.scale;
                SetParent(w.parent);
            }
        }

        //TODO: Implement DirtyMask.
        public readonly struct Wrapper : IExposedWrapper, IEquatable<Wrapper>
        {
            public readonly Vector3 position;
            public readonly Vector3 rotation;
            public readonly Vector3 scale;
            public readonly ComponentDataWrapper parent;

            public Wrapper(Vector3 position, Vector3 rotation, Vector3 scale, ComponentDataWrapper parent)
            {
                this.position = position;
                this.rotation = rotation;
                this.scale = scale;
                this.parent = parent;
            }
            
            public bool Equals(Wrapper other)
            {
                return position.Equals(other.position) && rotation.Equals(other.rotation) && scale.Equals(other.scale) && parent.Equals(other.parent);
            }

            public override bool Equals(object obj)
            {
                return obj is Wrapper other && Equals(other);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = position.GetHashCode();
                    hashCode = (hashCode * 397) ^ rotation.GetHashCode();
                    hashCode = (hashCode * 397) ^ scale.GetHashCode();
                    hashCode = (hashCode * 397) ^ parent.GetHashCode();
                    return hashCode;
                }
            }

            public static bool operator ==(Wrapper left, Wrapper right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Wrapper left, Wrapper right)
            {
                return !left.Equals(right);
            }
        }
    }
}