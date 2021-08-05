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
#if ALE_LOCALIZATION
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Tables;
#endif

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

        private ExposedField boundProperty;
        private IExposedToLevelEditor boundComponent;
        
#if ALE_LOCALIZATION
        private LocalizeStringEvent localStringComp;
#endif

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

        public ExposedField BoundProperty { get { return boundProperty; } }
        public IExposedToLevelEditor BoundComponent { get { return boundComponent; } }

        public ILevelEditorUI UI { get; set; }

        public object RawValue
        {
            get { return boundComponent.GetValue(boundProperty.ID); }
        }

        private void Awake()
        {
#if OBSOLETE
            Debug.LogError($"{gameObject.name} is still using {nameof(LevelEditorInspectorField)} and it will be stripped on build. Remove it.");
#endif

#if ALE_LOCALIZATION
            localStringComp = GetComponentInChildren<LocalizeStringEvent>();
#endif
            
            OnAwake();
        }

        protected virtual void OnAwake() { }

        public void Bind(ExposedField property, IExposedToLevelEditor exposed)
        {
            exposed.OnValueChanged += OnExposedValueChanged;

            boundProperty = property;
            boundComponent = exposed;
            
#if ALE_LOCALIZATION
            if (!string.IsNullOrWhiteSpace(property.CustomName) && localStringComp != null)
            {
                Label = TextUtility.FormatVariableLabel(property.Name);
                LocalizedString result = UI.InspectorPanel.GetLocalizedInspectorField(property.CustomName);
                if (result != null)
                {
                    localStringComp.StringReference = result;
                }
            }
            else
#endif
            {
                Label = string.IsNullOrEmpty(property.CustomName) ? TextUtility.FormatVariableLabel(property.Name) : property.CustomName;
            }

            OnBound(property, exposed);
            SetFieldValue(exposed.GetValue(property.ID));
        }

        protected virtual void OnBound(ExposedField property, IExposedToLevelEditor exposed) { }

        public void Unbind()
        {
            boundComponent.OnValueChanged -= OnExposedValueChanged;

            OnUnbound();
        }

        protected virtual void OnUnbound() { }

        private void OnExposedValueChanged(int id, object value)
        {
            if (id == boundProperty.ID)
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

        protected void BeginEdit()
        {
            boundComponent.BeginEdit(boundProperty.ID);
        }

        protected void ModifyPropertyValue(object value, bool notify)
        {
            boundComponent.ModifyValue(value, notify);
        }

        protected void EndEdit(bool notify = true, bool undo = true)
        {
            boundComponent.EndEdit(notify, undo ? UI.LevelEditor.Undo : null);
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
        public T Value { get { return (T)RawValue; } }

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

        protected abstract void SetFieldValue(T value);

        protected void ModifyPropertyValue(T value, bool notify)
        {
            ModifyPropertyValue((object) value, notify);
        }
    }
}
#endif
