#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using System;
using TMPro;
using UnityEngine;

namespace Hertzole.ALE
{
#if OBSOLETE
    [System.Obsolete("LevelEditorInspectorField has been stripped and will be removed on build.", true)]
#endif
    public abstract class LevelEditorInspectorField : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI label = null;
        //[SerializeField]
        //private float indentAmount = 16f;

        private int depth = 0;

        private ExposedProperty property;
        private IExposedToLevelEditor exposed;

        public int Index { get; set; }
        public int Depth
        {
            get { return depth; }
            set
            {
                if (depth != value)
                {
                    depth = value;
                    //fullContent.sizeDelta = new Vector2(-indentAmount * depth, fullContent.sizeDelta.y);
                    //TODO: Set indent.
                }
            }
        }

        public string Label { get { return label.text; } set { label.text = value; } }

        public ExposedProperty BoundProperty { get { return property; } }
        public IExposedToLevelEditor BoundComponent { get { return exposed; } }

        public ILevelEditorUI UI { get; set; }

        public object BeginEditValue { get; set; }

        public object RawValue
        {
            get { return exposed.GetValue(property.ID); }
            set { exposed.SetValue(property.ID, value, true); }
        }

        private void Awake()
        {
#if OBSOLETE
            Debug.LogError($"{gameObject.name} is still using {nameof(LevelEditorInspectorField)} and it will be stripped on build. Remove it.");
#endif

            OnAwake();
        }

        protected virtual void OnAwake() { }

        public void Bind(ExposedProperty property, IExposedToLevelEditor exposed)
        {
            exposed.OnValueChanged += OnExposedValueChanged;

            this.property = property;
            Label = string.IsNullOrEmpty(property.CustomName) ? TextUtility.FormatVariableLabel(property.Name) : property.CustomName;
            this.exposed = exposed;

            OnBound(property, exposed);
            SetFieldValue(exposed.GetValue(property.ID));
        }

        protected virtual void OnBound(ExposedProperty property, IExposedToLevelEditor exposed) { }

        public void Unbind()
        {
            exposed.OnValueChanged -= OnExposedValueChanged;

            OnUnbound();
        }

        protected virtual void OnUnbound() { }

        private void OnExposedValueChanged(int id, object value)
        {
            if (id == property.ID)
            {
                SetFieldValue(value);
            }
        }

        public virtual bool SupportsType(ExposedProperty property)
        {
            //TODO: Support arrays
            return SupportsType(property.Type, property.Type.IsArray);
        }

        public virtual bool SupportsType(Type type, bool isArray)
        {
            return false;
        }

        public virtual bool SupportsTypeDirect(Type type)
        {
            return false;
        }

        protected virtual void SetFieldValue(object value) { }

        protected void SetPropertyValue(object value, bool undo = false)
        {
            if (undo && UI.LevelEditor.Undo != null)
            {
                UI.LevelEditor.Undo.AddAction(new SetValueUndoAction(exposed, property.ID, BeginEditValue, value), false);
            }

            exposed.SetValue(property.ID, value, true);
        }

        protected virtual void BeginEdit()
        {
            BeginEditValue = RawValue;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        protected virtual void GetStandardComponents()
        {
            if (label == null)
            {
                Transform labelTransform = transform.Find("Label");
                if (labelTransform != null)
                {
                    label = labelTransform.GetComponent<TextMeshProUGUI>();
                }
                if (label == null)
                {
                    labelTransform = transform.Find("Level Editor Label");
                    if (labelTransform != null)
                    {
                        label = labelTransform.GetComponent<TextMeshProUGUI>();
                    }
                }
            }
        }
#endif
    }

#if OBSOLETE
    [System.Obsolete("LevelEditorInspectorField has been stripped and will be removed on build.", true)]
#endif
    public abstract class LevelEditorInspectorField<T> : LevelEditorInspectorField
    {
        public T Value { get { return (T)RawValue; } set { RawValue = value; } }

        public override bool SupportsType(Type type, bool isArray)
        {
            if (isArray)
            {
                return type.IsArray && type == typeof(T);
            }
            else if (isArray && !type.IsArray)
            {
                return false;
            }
            else
            {
                return type == typeof(T);
            }
        }

        public override bool SupportsTypeDirect(Type type)
        {
            return type == typeof(T);
        }

        protected override void SetFieldValue(object value)
        {
            SetFieldValue((T)value);
        }

        public abstract void SetFieldValue(T value);

        protected void SetPropertyValue(T value, bool undo = false)
        {
            SetPropertyValue((object)value, undo);
        }
    }
}
#endif
