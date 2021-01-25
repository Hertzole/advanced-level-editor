using UnityEditor;
using UnityEditor.UI;

namespace Hertzole.ALE.Editor
{
    [CustomEditor(typeof(BoxSlider), true)]
    [CanEditMultipleObjects]
    public class BoxSliderEditor : SelectableEditor
    {

        SerializedProperty handleRect;
        SerializedProperty minValue;
        SerializedProperty maxValue;
        SerializedProperty wholeNumbers;
        SerializedProperty value;
        SerializedProperty valueY;
        SerializedProperty onValueChanged;

        protected override void OnEnable()
        {
            base.OnEnable();
            handleRect = serializedObject.FindProperty("handleRect");

            minValue = serializedObject.FindProperty("minValue");
            maxValue = serializedObject.FindProperty("maxValue");
            wholeNumbers = serializedObject.FindProperty("wholeNumbers");
            value = serializedObject.FindProperty("value");
            valueY = serializedObject.FindProperty("valueY");
            onValueChanged = serializedObject.FindProperty("onValueChanged");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            serializedObject.Update();

            EditorGUILayout.PropertyField(handleRect);

            if (handleRect.objectReferenceValue != null)
            {
                EditorGUI.BeginChangeCheck();


                EditorGUILayout.PropertyField(minValue);
                EditorGUILayout.PropertyField(maxValue);
                EditorGUILayout.PropertyField(wholeNumbers);
                EditorGUILayout.Slider(value, minValue.floatValue, maxValue.floatValue);
                EditorGUILayout.Slider(valueY, minValue.floatValue, maxValue.floatValue);

                // Draw the event notification options
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(onValueChanged);
            }
            else
            {
                EditorGUILayout.HelpBox("Specify a RectTransform for the slider fill or the slider handle or both. Each must have a parent RectTransform that it can slide within.", MessageType.Info);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
