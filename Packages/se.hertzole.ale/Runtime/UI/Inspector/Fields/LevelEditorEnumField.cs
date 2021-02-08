using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorEnumField : LevelEditorInspectorField
    {
        [SerializeField]
        private TMP_Dropdown dropdown = null;

        private List<string> enumNames = new List<string>();
        private List<object> enumValues = new List<object>();

        protected override void OnAwake()
        {
            dropdown.onValueChanged.AddListener(OnDropdownChanged);
        }

        protected override void OnBound(ExposedProperty property, IExposedToLevelEditor exposed)
        {
            enumNames.Clear();
            enumValues.Clear();

            string[] names = Enum.GetNames(property.Type);
            enumNames.AddRange(names);

            Array values = Enum.GetValues(property.Type);
            for (int i = 0; i < values.Length; i++)
            {
                enumValues.Add(values.GetValue(i));
            }
        }

        public override bool SupportsType(Type type, bool isArray)
        {
            return !isArray && type.IsEnum;
        }

        protected override void SetFieldValue(object value)
        {
            dropdown.ClearOptions();

            for (int i = 0; i < enumNames.Count; i++)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(enumNames[i]));
            }

            dropdown.RefreshShownValue();

            int index = enumNames.IndexOf(value.ToString());
            dropdown.SetValueWithoutNotify(index);
        }

        private void OnDropdownChanged(int newIndex)
        {
            SetPropertyValue(enumValues[newIndex]);
        }
    }
}
