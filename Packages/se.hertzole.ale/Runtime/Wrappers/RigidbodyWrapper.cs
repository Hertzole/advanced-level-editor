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
            LevelEditorSerializer.RegisterType<Rigidbody>();

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

        public override IExposedWrapper GetWrapper()
        {
            return new Wrapper(Target.mass, Target.drag, Target.angularDrag, Target.useGravity, Target.isKinematic);
        }

        public override void ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyMask = false)
        {
            if (wrapper is Wrapper w)
            {
                Target.mass = w.mass;
                Target.drag = w.drag;
                Target.angularDrag = w.angularDrag;
                Target.useGravity = w.useGravity;
                Target.isKinematic = w.isKinematic;
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

        //TODO: Implement DirtyMask.
        public readonly struct Wrapper : IExposedWrapper, IEquatable<Wrapper>
        {
            public readonly float mass;
            public readonly float drag;
            public readonly float angularDrag;
            public readonly bool useGravity;
            public readonly bool isKinematic;

            public Wrapper(float mass, float drag, float angularDrag, bool useGravity, bool isKinematic)
            {
                this.mass = mass;
                this.drag = drag;
                this.angularDrag = angularDrag;
                this.useGravity = useGravity;
                this.isKinematic = isKinematic;
            }
            
            public bool Equals(Wrapper other)
            {
                return mass.Equals(other.mass) && drag.Equals(other.drag) && angularDrag.Equals(other.angularDrag) && useGravity == other.useGravity && isKinematic == other.isKinematic;
            }

            public override bool Equals(object obj)
            {
                return obj is Wrapper other && Equals(other);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = mass.GetHashCode();
                    hashCode = (hashCode * 397) ^ drag.GetHashCode();
                    hashCode = (hashCode * 397) ^ angularDrag.GetHashCode();
                    hashCode = (hashCode * 397) ^ useGravity.GetHashCode();
                    hashCode = (hashCode * 397) ^ isKinematic.GetHashCode();
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
