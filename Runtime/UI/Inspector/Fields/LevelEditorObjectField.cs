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

        private bool isSceneObject = false;

        public ObjectEvent OnValueChanged { get { return onValueChanged; } }

        protected override void OnAwake()
        {
            objectButton.onClick.AddListener(OnClickObjectButton);
        }

        protected virtual void OnClickObjectButton()
        {
            BeginEdit();
            UI.ObjectPickerWindow.Show(BoundProperty.Type, isSceneObject);
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
            SetUnityObject(obj);
        }

        private void SetUnityObject(UnityObject obj)
        {
            if (!isSceneObject)
            {
                throw new NotSupportedException($"Non-scene objects are not supported.");
            }
            
            if (obj == null)
            {
                SetPropertyValue(new ComponentDataWrapper(0));
                onValueChanged.Invoke(null);
            }
            else
            {
                if (obj is ILevelEditorObject levelObject)
                {
                    if (BoundProperty.Type == typeof(GameObject))
                    {
                        SetPropertyValue(new ComponentDataWrapper(levelObject.MyGameObject));
                        onValueChanged.Invoke(levelObject.MyGameObject);
                    }
                    else
                    {
                        Component value = levelObject.MyGameObject.GetComponent(BoundProperty.Type);
                        SetPropertyValue(new ComponentDataWrapper(value));
                        onValueChanged.Invoke(value);
                    }
                }
                else if(obj is GameObject go)
                {
                    SetPropertyValue(new ComponentDataWrapper(go));
                    onValueChanged.Invoke(obj);
                }
                else
                {
                    SetPropertyValue(new ComponentDataWrapper((Component)obj));
                    onValueChanged.Invoke(obj);
                }
            }

            UpdateLabel(obj);
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
            UnityObject obj = null;
            
            if (value is ComponentDataWrapper dataWrapper)
            {
                obj = dataWrapper.GetObject(BoundProperty.Type);
            }
            else if (value is UnityObject unityObj)
            {
                obj = unityObj;
            }

            UpdateLabel(obj);

            isSceneObject = BoundProperty.Type.IsSubclassOf(typeof(Component)) || BoundProperty.Type == typeof(GameObject);
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
