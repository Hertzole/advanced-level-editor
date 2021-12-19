using System;
using System.Collections.Generic;
using MessagePack;
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

        private int editingId;

        private Vector3 previousPosition;
        private Vector3 previousRotation;
        private Vector3 previousScale;

        private Transform myTransform;
        
        private object beginEditValue;
        private object lastEditValue;

        public override int Order { get { return -100000; } }
        public override bool HasVisibleFields { get { return true; } }

        private const string POSITION = "position";
        private const int POSITION_ID = 0;
        private const string ROTATION = "rotation";
        private const int ROTATION_ID = 1;
        private const string SCALE = "scale";
        private const int SCALE_ID = 2;
        private const string PARENT = "parent";
        private const int PARENT_ID = 3;

        private readonly ExposedField[] cachedProperties = new ExposedField[]
        {
            new ExposedProperty(POSITION_ID, typeof(Vector3), POSITION, null, true),
            new ExposedProperty(ROTATION_ID, typeof(Vector3), ROTATION, null, true),
            new ExposedProperty(SCALE_ID, typeof(Vector3), SCALE, null, true),
            new ExposedProperty(PARENT_ID, typeof(Transform), PARENT, null, false)
        };

        private void Awake()
        {
            myTransform = transform;
        }

        private void Update()
        {
            Vector3 position = myTransform.position;
            Vector3 rotation = myTransform.eulerAngles;
            Vector3 scale = myTransform.localScale;
            
            if (previousPosition != position)
            {
                beginEditValue = previousPosition;
                previousPosition = position;
                lastEditValue = position;

                InvokeOnValueChanged(POSITION_ID, position);
            }
            
            if (previousRotation != rotation)
            {
                beginEditValue = previousRotation;
                previousRotation = rotation;
                lastEditValue = ROTATION_ID;

                InvokeOnValueChanged(ROTATION_ID, rotation);
            }
            
            if (previousScale != scale)
            {
                beginEditValue = previousScale;
                previousScale = scale;
                lastEditValue = scale;

                InvokeOnValueChanged(SCALE_ID, scale);
            }
        }

        public override IReadOnlyList<ExposedField> GetProperties()
        {
            return cachedProperties;
        }

        public override object GetValue(int id)
        {
            switch (id)
            {
                case POSITION_ID:
                    return transform.position;
                case ROTATION_ID:
                    return transform.eulerAngles;
                case SCALE_ID:
                    return transform.localScale;
                case PARENT_ID:
                    return new ComponentDataWrapper(transform.parent);
                default:
                    throw new ArgumentException($"No exposed property with the ID '{id}'.");
            }
        }

        public override void BeginEdit(int id)
        {
            editingId = id;
            switch (id)
            {
                case POSITION_ID:
                    beginEditValue = Target.position;
                    break;
                case ROTATION_ID:
                    beginEditValue = Target.eulerAngles;
                    break;
                case SCALE_ID:
                    beginEditValue = Target.localScale;
                    break;
                case PARENT_ID:
                    beginEditValue = new ComponentDataWrapper(Target.parent);
                    break;
                default:
                    throw new InvalidExposedPropertyException(id);
            }
        }

        public override void ModifyValue(object value, bool notify)
        {
            bool changed = false;
            
             switch (editingId)
            {
                case POSITION_ID:
                    if (Target.position != (Vector3) value)
                    {
                        Target.position = (Vector3) value;
                        changed = true;
                        lastEditValue = Target.position;
                    }

                    break;
                case ROTATION_ID:
                    if (Target.eulerAngles != (Vector3) value)
                    {
                        Target.eulerAngles = (Vector3) value;
                        changed = true;
                        lastEditValue = Target.eulerAngles;
                    }

                    break;
                case SCALE_ID:
                    if (Target.localScale != (Vector3) value)
                    {
                        Target.localScale = (Vector3) value;
                        changed = true;
                        lastEditValue = Target.localScale;
                    }

                    break;
                case PARENT_ID:
                    if (value is ComponentDataWrapper wrapper && !wrapper.Equals(Target.parent))
                    {
                        SetParent(wrapper);
                    }
                    
                    break;
                default:
                    throw new InvalidExposedPropertyException(editingId);
            }

            if (notify && changed)
            {
                InvokeOnValueChanged(editingId, value);
            }
        }

        public override void EndEdit(bool notify, ILevelEditorUndo undo)
        {
            if (notify)
            {
                InvokeOnValueChanged(editingId, lastEditValue);
            }

            if (undo != null)
            {
                undo.AddAction(new SetValueUndoAction(this, editingId, beginEditValue, lastEditValue));
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

            lastEditValue = new ComponentDataWrapper(transform.parent);
        }

        public override IExposedWrapper GetWrapper()
        {
            return new Wrapper(Target.position, Target.eulerAngles, Target.localScale, new ComponentDataWrapper(Target.parent), false);
        }

        public override void ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyMask = false)
        {
            if (wrapper is Wrapper w)
            {
                if (ignoreDirtyMask || wrapper.IsDirty(POSITION_ID))
                {
                    Target.position = w.GetValue<Vector3>(POSITION_ID);
                }
                
                if (ignoreDirtyMask || wrapper.IsDirty(ROTATION_ID))
                {
                    Target.eulerAngles = w.GetValue<Vector3>(ROTATION_ID);
                }
                
                if (ignoreDirtyMask || wrapper.IsDirty(SCALE_ID))
                {
                    Target.localScale = w.GetValue<Vector3>(SCALE_ID);
                }
                
                if (ignoreDirtyMask || wrapper.IsDirty(PARENT_ID))
                {
                    SetParent(w.GetValue<ComponentDataWrapper>(PARENT_ID));
                }
            }
        }

        public struct Wrapper : IExposedWrapper, IEquatable<Wrapper>
        {
            public Dictionary<int, object> Values { get; set; }
            public Dictionary<int, bool> Dirty { get; set; }

            public Wrapper(Vector3 position, Vector3 rotation, Vector3 scale, ComponentDataWrapper parent, bool isDirty)
            {
                Values = new Dictionary<int, object>(4)
                {
                    { POSITION_ID, position },
                    { ROTATION_ID, rotation },
                    { SCALE_ID, scale },
                    { PARENT_ID, parent },
                };

                Dirty = new Dictionary<int, bool>(4)
                {
                    { POSITION_ID, isDirty },
                    { ROTATION_ID, isDirty },
                    { SCALE_ID, isDirty },
                    { PARENT_ID, isDirty }
                };
            }
            
            public bool Equals(Wrapper other)
            {
                return Values.DictionaryEquals(other.Values);
            }

            public override bool Equals(object obj)
            {
                return obj is Wrapper other && Equals(other);
            }

            public override int GetHashCode()
            {
                return Values.GetHashCode();
            }

            public static bool operator ==(Wrapper left, Wrapper right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Wrapper left, Wrapper right)
            {
                return !left.Equals(right);
            }

            public void Serialize(int id, ref MessagePackWriter writer, MessagePackSerializerOptions options)
            {
                switch (id)
                {
                    case POSITION_ID:
                        options.Resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, (Vector3) Values[POSITION_ID], options);
                        break;
                    case ROTATION_ID:
                        options.Resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, (Vector3) Values[ROTATION_ID], options);
                        break;
                    case SCALE_ID:
                        options.Resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, (Vector3) Values[SCALE_ID], options);
                        break;
                    case PARENT_ID:
                        options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Serialize(ref writer, (ComponentDataWrapper) Values[PARENT_ID], options);
                        break;
                }
            }

            public object Deserialize(int id, ref MessagePackReader reader, MessagePackSerializerOptions options)
            {
                switch (id)
                {
                    case POSITION_ID:
                        return options.Resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
                    case ROTATION_ID:
                        return options.Resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
                    case SCALE_ID:
                        return options.Resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
                    case PARENT_ID:
                        return options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Deserialize(ref reader, options);
                }

                return default;
            }
        }
    }
}