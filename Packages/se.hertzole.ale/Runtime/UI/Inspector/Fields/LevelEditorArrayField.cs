using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorArrayField : LevelEditorInspectorField
    {
        [SerializeField]
        private TMP_InputField lengthField = null;
        [SerializeField]
        private LevelEditorExpander expander = null;
        [SerializeField]
        private RectTransform contentHolder = null;
        [SerializeField]
        private int fieldsSpacing = 4;

        //private bool hasField = true;

        private float originalHeight;

        private RectTransform rect;
        private VerticalLayoutGroup verticalLayout;

        private List<LevelEditorInspectorField> fields = new List<LevelEditorInspectorField>();

        protected override void OnAwake()
        {
            rect = (RectTransform)transform;

            lengthField.onEndEdit.AddListener(OnEndEdit);
            expander.OnValueChanged.AddListener(OnExpandedChanged);

            originalHeight = rect.sizeDelta.y;

            verticalLayout = contentHolder.gameObject.GetOrAddComponent<VerticalLayoutGroup>();
            verticalLayout.padding.top = fieldsSpacing;
            verticalLayout.spacing = fieldsSpacing;
            verticalLayout.childForceExpandWidth = true;
            verticalLayout.childForceExpandHeight = false;
            verticalLayout.childControlHeight = false;
        }

        public override bool SupportsType(Type type, bool isArray)
        {
            return false; // Not supported yet...

            //if (!isArray)
            //{
            //    return false;
            //}

            //hasField = true;

            //if (UI != null && UI.InspectorPanel is LevelEditorInspector inspector)
            //{
            //    hasField = inspector.HasField(type, false);
            //}

            //return hasField;
        }

        protected override void SetFieldValue(object value)
        {
            object[] valueArray = (object[])value;
            lengthField.SetTextWithoutNotify(valueArray.Length.ToString());

            if (expander.IsExpanded)
            {
                GenerateFields();
            }
        }

        private void OnExpandedChanged(bool isExpanded)
        {
            if (isExpanded)
            {
                contentHolder.gameObject.SetActive(true);

                GenerateFields();
            }
            else
            {
                PoolFields();
                contentHolder.gameObject.SetActive(false);
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, originalHeight);
            }

            //LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)rect.parent);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)rect.parent.parent.parent);
        }

        private void GenerateFields()
        {
            if (UI != null && UI.InspectorPanel is LevelEditorInspector inspector)
            {
                object[] valueArray = (object[])RawValue;
                float height = originalHeight + fieldsSpacing;
                for (int i = 0; i < valueArray.Length; i++)
                {
                    LevelEditorInspectorField field = inspector.GetField(BoundProperty.Type, contentHolder);
                    field.Depth = Depth + 1;
                    field.Label = $"Element {i}";
                    height += ((RectTransform)field.transform).sizeDelta.y + fieldsSpacing;

                    fields.Add(field);
                }
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, height);
            }
        }

        private void PoolFields()
        {
            if (UI != null && UI.InspectorPanel is LevelEditorInspector inspector)
            {
                for (int i = 0; i < fields.Count; i++)
                {
                    inspector.PoolField(fields[i]);
                }

                fields.Clear();
            }
        }

        private void OnEndEdit(string value)
        {

        }
    }
}
