using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
	[CustomPropertyDrawer(typeof(PreviewGeneratorSettings))]
	public class PreviewGeneratorSettingsEditor : PropertyDrawer
	{
		private bool generatePreview = true;
		
		private Texture2D previewTexture;
		
		private static float NewLine { get { return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing; } }

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Rect r = position;
			r.height = EditorGUIUtility.singleLineHeight;
			EditorGUI.BeginChangeCheck();
			EditorGUI.PropertyField(r, property, label, false);
			if (property.isExpanded)
			{
				SerializedProperty isOrthographic = property.FindPropertyRelative("isOrthographic");
				SerializedProperty backgroundColor = property.FindPropertyRelative("backgroundColor");
				SerializedProperty padding = property.FindPropertyRelative("padding");
				SerializedProperty previewDirection = property.FindPropertyRelative("previewDirection");
				SerializedProperty imageSize = property.FindPropertyRelative("imageSize");

				EditorGUI.indentLevel++;

				r.y += NewLine;
				EditorGUI.PropertyField(r, isOrthographic);
				r.y += NewLine;
				EditorGUI.PropertyField(r, backgroundColor);
				r.y += NewLine;
				padding.floatValue = EditorGUI.Slider(r, padding.displayName, padding.floatValue, -0.25f, 0.25f);
				r.y += NewLine;
				EditorGUI.PropertyField(r, previewDirection);
				r.y += NewLine;
				EditorGUI.PropertyField(r, imageSize);

				if (EditorGUI.EndChangeCheck())
				{
					generatePreview = true;
				}

				r.y += NewLine;
				EditorGUIHelper.DrawFancyFoldout(r, padding, "Preview", false, () =>
				{
					if (generatePreview)
					{
						if (previewTexture != null)
						{
							Object.DestroyImmediate(previewTexture);
						}

						RuntimePreviewGenerator.OrthographicMode = isOrthographic.boolValue;
						RuntimePreviewGenerator.Padding = padding.floatValue;
						RuntimePreviewGenerator.BackgroundColor = backgroundColor.colorValue;
						RuntimePreviewGenerator.PreviewDirection = previewDirection.vector3Value;

						GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
						previewTexture = RuntimePreviewGenerator.GenerateModelPreview(go.transform, imageSize.vector2IntValue.x, imageSize.vector2IntValue.y, true);
						Object.DestroyImmediate(go);

						generatePreview = false;
					}

					Color oColor = GUI.backgroundColor;
					float backgroundTint = EditorGUIUtility.isProSkin ? 0.1f : 1f;
					GUI.backgroundColor = new Color(backgroundTint, backgroundTint, backgroundTint, 0.2f);
				
					r.y += NewLine;
					float width = imageSize.vector2IntValue.x > EditorGUIUtility.currentViewWidth ? EditorGUIUtility.currentViewWidth : imageSize.vector2IntValue.x;
					float center = r.position.x + (EditorGUIUtility.currentViewWidth / 2f) - width / 2f;
					GUI.Box(new Rect(center, r.y, width, imageSize.vector2IntValue.y), previewTexture);
					
					GUI.backgroundColor = oColor;
				});

				EditorGUI.indentLevel--;
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = EditorGUIUtility.singleLineHeight;

			if (property.isExpanded)
			{
				height += NewLine * 5;
				height += 17; // Preview foldout.
				if (property.FindPropertyRelative("padding").isExpanded)
				{
					height += property.FindPropertyRelative("imageSize").vector2IntValue.y;
				}
			}

			return height;
		}
	}
}