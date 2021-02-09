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
        [SerializeField]
        private TMP_InputField textField = null;
        [SerializeField]
        private bool placeholderAsName = true;

        private bool isChar;

        public event Action<string> OnStringValueChanged;
        public event Action<char> OnCharValueChanged;

        protected override void OnAwake()
        {
            this.LogIfStripped();

            textField.onValueChanged.AddListener(x =>
            {
                if (isChar)
                {
                    if (string.IsNullOrEmpty(x))
                    {
                        x = "\0";
                    }

                    char charValue = char.Parse(x);

                    SetPropertyValue(charValue);
                    OnCharValueChanged?.Invoke(charValue);
                }
                else
                {
                    SetPropertyValue(x);
                    OnStringValueChanged?.Invoke(x);
                }
            });
        }

        public override bool SupportsType(Type type, bool isArray)
        {
            return !isArray && (type == typeof(string) || type == typeof(char));
        }

        protected override void OnBound(ExposedProperty property, IExposedToLevelEditor exposed)
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
