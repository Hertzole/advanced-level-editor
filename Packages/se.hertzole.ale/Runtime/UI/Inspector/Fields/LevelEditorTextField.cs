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
using UnityEngine.Events;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#if !OBSOLETE
    [AddComponentMenu("ALE/UI/uGUI/Fields/Text Field", 200)]
#else
    [System.Obsolete("LevelEditorTextField has been stripped and will be removed on build.", true)]
#endif
#endif
    public class LevelEditorTextField : LevelEditorInspectorField
    {
        [Serializable]
        public class CharEvent : UnityEvent<char> { }

        [SerializeField]
        private TMP_InputField textField = null;
        [SerializeField]
        private bool placeholderAsName = true;
        [SerializeField]
        private TMP_InputField.OnChangeEvent onStringValueChanged = new TMP_InputField.OnChangeEvent();
        [SerializeField]
        private TMP_InputField.OnChangeEvent onStringEndEdit = new TMP_InputField.OnChangeEvent();
        [SerializeField]
        private CharEvent onCharValueChanged = new CharEvent();
        [SerializeField]
        private CharEvent onCharEndEdit = new CharEvent();

        private bool isChar;

        public TMP_InputField.OnChangeEvent OnStringValueChanged { get { return onStringValueChanged; } }
        public CharEvent OnCharValueChanged { get { return onCharValueChanged; } }

        public TMP_InputField.OnChangeEvent OnStringEndEdit { get { return onStringEndEdit; } }
        public CharEvent OnCharEndEdit { get { return onCharEndEdit; } }

        protected override void OnAwake()
        {
            this.LogIfStripped();

            textField.onSelect.AddListener(x => BeginEdit());
            textField.onValueChanged.AddListener(x => ValueChanged(x, false));
            textField.onEndEdit.AddListener(x => ValueChanged(x, true));
        }

        private void ValueChanged(string value, bool endEdit)
        {
            //TODO: Investigate duplicate undo action.

            if (isChar)
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "\0";
                }

                char charValue = char.Parse(value);

                ModifyPropertyValue(charValue, true);
                if (endEdit)
                {
                    onCharEndEdit.Invoke(charValue);
                    EndEdit();
                }
                else
                {
                    onCharValueChanged.Invoke(charValue);
                }
            }
            else
            {
                ModifyPropertyValue(value, true);
                if (endEdit)
                {
                    onStringEndEdit.Invoke(value);
                    EndEdit();
                }
                else
                {
                    onStringValueChanged.Invoke(value);
                }
            }
        }

        public override bool SupportsType(Type type, bool isArray)
        {
            return !isArray && (type == typeof(string) || type == typeof(char));
        }

        protected override void OnBound(ExposedField property, IExposedToLevelEditor exposed)
        {
            isChar = property.Type == typeof(char);

            textField.characterLimit = isChar ? 1 : 0;

            if (placeholderAsName && textField.placeholder is TextMeshProUGUI placeholder)
            {
                placeholder.text = property.Name;
            }
        }

        protected override void SetFieldValue(object value)
        {
            if (isChar)
            {
                textField.SetTextWithoutNotify(((char)value).ToString());
            }
            else
            {
                textField.SetTextWithoutNotify((string)value);
            }
        }
    }
}
#endif
