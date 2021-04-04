using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityObject = UnityEngine.Object;

namespace Hertzole.ALE
{
    public class LevelEditorObjectField : LevelEditorInspectorField, IDropHandler
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

        protected virtual void OnClickObjectButton()
        {
            BeginEdit();
            UI.ObjectPickerWindow.Show(BoundProperty.Type, isComponent);
            UI.ObjectPickerWindow.OnWindowClose.AddListener(OnPickerWindowClose);
            UI.ObjectPickerWindow.OnObjectSelected += OnPickerObjectSelected;
        }

        private void OnPickerWindowClose()
        {
            UI.ObjectPickerWindow.OnWindowClose.RemoveListener(OnPickerWindowClose);
            UI.ObjectPickerWindow.OnObjectSelected -= OnPickerObjectSelected;

            SetPropertyValue(RawValue, true);
        }

        private void OnPickerObjectSelected(UnityObject obj)
        {
            if (isComponent)
            {
                SetUnityObject(obj);
            }
            else
            {
                throw new NotImplementedException("Non-components are not supported yet.");
            }
        }

        private void SetUnityObject(UnityObject obj)
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

        public void OnDrop(PointerEventData eventData)
        {
            if (IsValidDrop(out UnityObject draggingItem))
            {
                SetUnityObject(draggingItem);
            }
        }

        private bool IsValidDrop(out UnityObject obj)
        {
            if (UI != null && UI.HierarchyPanel != null && UI.HierarchyPanel is LevelEditorHierarchy hierarchy &&
               hierarchy.TreeControl != null && hierarchy.TreeControl.DraggingItem != null && hierarchy.TreeControl.DraggingItem is UnityObject unityObj)
            {
                obj = unityObj;
                return true;
            }

            obj = null;
            return false;
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
