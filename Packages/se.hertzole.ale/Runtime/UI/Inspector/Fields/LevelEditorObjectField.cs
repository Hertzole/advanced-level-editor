using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityObject = UnityEngine.Object;

namespace Hertzole.ALE
{
    //TODO: Implement drop support
    public class LevelEditorObjectField : LevelEditorInspectorField
    {
        [Serializable]
        public class ObjectEvent : UnityEvent<UnityObject> { }

        [SerializeField]
        private Button objectButton = null;
        [SerializeField]
        private TextMeshProUGUI objectLabel = null;
        [SerializeField]
        private string labelFormat = "{0} ({1})";
        [SerializeField]
        private string nullValueText = "None";
        [SerializeField]
        private ObjectEvent onValueChanged = new ObjectEvent();

        private bool isComponent = false;

        public ObjectEvent OnValueChanged { get { return onValueChanged; } }

        protected override void OnAwake()
        {
            objectButton.onClick.AddListener(OnClickObjectButton);
        }

        private void OnClickObjectButton()
        {
            UI.ObjectPickerWindow.Show(BoundProperty.Type, isComponent);
            UI.ObjectPickerWindow.OnWindowClose.AddListener(OnPickerWindowClose);
            UI.ObjectPickerWindow.OnObjectSelected += OnPickerObjectSelected;
        }

        private void OnPickerWindowClose()
        {
            UI.ObjectPickerWindow.OnWindowClose.RemoveListener(OnPickerWindowClose);
            UI.ObjectPickerWindow.OnObjectSelected -= OnPickerObjectSelected;
        }

        private void OnPickerObjectSelected(UnityObject obj)
        {
            if (isComponent)
            {
                if (obj == null)
                {
                    SetPropertyValue(null);
                    onValueChanged.Invoke(null);
                }
                else
                {
                    Component value = ((Component)obj).GetComponent(BoundProperty.Type);
                    SetPropertyValue(value);
                    onValueChanged.Invoke(value);
                }

                UpdateLabel((UnityObject)RawValue);
            }
            else
            {
                throw new NotImplementedException("Non-components are not supported yet.");
            }
        }

        public override bool SupportsType(Type type, bool isArray)
        {
            if (isArray || type.IsArray)
            {
                return false;
            }

            return type.IsSubclassOf(typeof(UnityObject));
        }

        protected override void SetFieldValue(object value)
        {
            UnityObject obj = (UnityObject)value;

            UpdateLabel(obj);

            isComponent = BoundProperty.Type.IsSubclassOf(typeof(Component));
        }

        private void UpdateLabel(UnityObject value)
        {
            objectLabel.text = string.Format(labelFormat, value == null ? nullValueText : value.name, BoundProperty.Type.Name);
        }

#if UNITY_EDITOR
        protected override void GetStandardComponents()
        {
            base.GetStandardComponents();

            if (objectButton != null && objectLabel == null)
            {
                objectLabel = objectButton.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
#endif
    }
}
