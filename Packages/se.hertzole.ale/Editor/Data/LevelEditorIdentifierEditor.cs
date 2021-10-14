using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
	[CustomPropertyDrawer(typeof(LevelEditorIdentifier))]
	public class LevelEditorIdentifierEditor : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginChangeCheck();
			EditorGUI.PropertyField(position, property.FindPropertyRelative("stringValue"), label);
			if (EditorGUI.EndChangeCheck())
			{
				property.FindPropertyRelative("value").intValue = property.FindPropertyRelative("stringValue").stringValue.GetStableHashCode();
			}
		}
	}
}