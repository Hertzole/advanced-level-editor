using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    [CustomPropertyDrawer(typeof(RequireTypeAttribute))]
    public class RequireTypeAttributeEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.PropertyField(position, property, label);

                if (attribute is RequireTypeAttribute required)
                {
                    if (property.objectReferenceValue is GameObject go)
                    {
                        if (!go.GetComponent(required.Type))
                        {
                            Debug.LogError($"Field '{property.displayName}' needs to have a object that has '{required.Type.Name}' attached.");
                            property.objectReferenceValue = null;
                        }
                    }
                }
            }
        }
    }
}
