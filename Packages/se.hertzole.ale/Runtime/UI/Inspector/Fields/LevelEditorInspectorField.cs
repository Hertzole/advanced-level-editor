#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using TMPro;
using UnityEngine;

namespace Hertzole.ALE
{
#if OBSOLETE
    [System.Obsolete("LevelEditorInspectorField has been will be stripped on build.", true)]
#endif
    public abstract class LevelEditorInspectorField : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI label = null;

        private ExposedProperty property;
        private IExposedToLevelEditor exposed;

        public int Index { get; set; }

        public string Label { get { return label.text; } set { label.text = value; } }

        public ExposedProperty BoundProperty { get { return property; } }
        public IExposedToLevelEditor BoundComponent { get { return exposed; } }

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
            this.property = property;
            Label = property.Name;
            this.exposed = exposed;

            OnBound(property, exposed);
            SetFieldValue(exposed.GetValue(property.ID));
        }

        protected virtual void OnBound(ExposedProperty property, IExposedToLevelEditor exposed) { }

        public virtual bool SupportsType(ExposedProperty property)
        {
            return false;
        }

        protected virtual void SetFieldValue(object value) { }

        protected void SetPropertyValue(object value)
        {
            exposed.SetValue(property.ID, value, true);
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
                Transform labelTrasnsform = transform.Find("Label");
                if (labelTrasnsform != null)
                {
                    label = labelTrasnsform.GetComponent<TextMeshProUGUI>();
                }
                if (label == null)
                {
                    labelTrasnsform = transform.Find("Level Editor Label");
                    if (labelTrasnsform != null)
                    {
                        label = labelTrasnsform.GetComponent<TextMeshProUGUI>();
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
        public override bool SupportsType(ExposedProperty property)
        {
            if (property.IsArray)
            {
                return property.Type.IsArray && property.Type == typeof(T);
            }
            else if (property.IsArray && !property.Type.IsArray)
            {
                return false;
            }
            else
            {
                return property.Type == typeof(T);
            }
        }

        protected override void SetFieldValue(object value)
        {
            SetFieldValue((T)value);
        }

        public abstract void SetFieldValue(T value);

        protected void SetPropertyValue(T value)
        {
            SetPropertyValue((object)value);
        }
    }
}
#endif
