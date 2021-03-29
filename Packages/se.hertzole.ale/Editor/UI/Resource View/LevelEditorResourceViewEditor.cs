using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    [CustomEditor(typeof(LevelEditorResourceView))]
    public class LevelEditorResourceViewEditor : UnityEditor.Editor
    {
        private SerializedProperty folderTree;
        private SerializedProperty showRoot;
        private SerializedProperty rootName;
        private SerializedProperty assetsContent;
        private SerializedProperty assetButtonPrefab;
        private SerializedProperty displayFirstSpriteAsIcon;
        private SerializedProperty iconHandling;
        private SerializedProperty generateAsync;
        private SerializedProperty asyncWaitMethod;
        private SerializedProperty isOrtographic;
        private SerializedProperty backgroundColor;
        private SerializedProperty padding;
        private SerializedProperty previewDirection;
        private SerializedProperty imageSize;

        private bool generatePreview = true;

        private Texture previewTexture;

        private void OnEnable()
        {
            folderTree = serializedObject.FindProperty(nameof(folderTree));
            showRoot = serializedObject.FindProperty(nameof(showRoot));
            rootName = serializedObject.FindProperty(nameof(rootName));
            assetsContent = serializedObject.FindProperty(nameof(assetsContent));
            assetButtonPrefab = serializedObject.FindProperty(nameof(assetButtonPrefab));
            displayFirstSpriteAsIcon = serializedObject.FindProperty(nameof(displayFirstSpriteAsIcon));
            iconHandling = serializedObject.FindProperty(nameof(iconHandling));
            generateAsync = serializedObject.FindProperty(nameof(generateAsync));
            asyncWaitMethod = serializedObject.FindProperty(nameof(asyncWaitMethod));
            isOrtographic = serializedObject.FindProperty(nameof(isOrtographic));
            backgroundColor = serializedObject.FindProperty(nameof(backgroundColor));
            padding = serializedObject.FindProperty(nameof(padding));
            previewDirection = serializedObject.FindProperty(nameof(previewDirection));
            imageSize = serializedObject.FindProperty(nameof(imageSize));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(folderTree);
            EditorGUILayout.PropertyField(showRoot);
            EditorGUILayout.PropertyField(rootName);
            EditorGUILayout.PropertyField(assetsContent);
            EditorGUILayout.PropertyField(assetButtonPrefab);
            EditorGUILayout.PropertyField(displayFirstSpriteAsIcon);
            EditorGUILayout.PropertyField(iconHandling);
            EditorGUILayout.PropertyField(generateAsync);
            EditorGUILayout.PropertyField(asyncWaitMethod);

            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(isOrtographic);
            EditorGUILayout.PropertyField(backgroundColor);
            padding.floatValue = EditorGUILayout.Slider(padding.displayName, padding.floatValue, -0.25f, 0.25f);

            EditorGUILayout.PropertyField(previewDirection);
            EditorGUILayout.PropertyField(imageSize);

            if (EditorGUI.EndChangeCheck())
            {
                generatePreview = true;
            }

            EditorGUIHelper.DrawFancyFoldout(isOrtographic, "Preview", false, () =>
            {
                if (generatePreview)
                {
                    if (previewTexture != null)
                    {
                        DestroyImmediate(previewTexture);
                    }

                    RuntimePreviewGenerator.OrthographicMode = isOrtographic.boolValue;
                    RuntimePreviewGenerator.Padding = padding.floatValue;
                    RuntimePreviewGenerator.BackgroundColor = backgroundColor.colorValue;
                    RuntimePreviewGenerator.PreviewDirection = previewDirection.vector3Value;

                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    previewTexture = RuntimePreviewGenerator.GenerateModelPreview(go.transform, imageSize.vector2IntValue.x, imageSize.vector2IntValue.y, true);
                    DestroyImmediate(go);

                    generatePreview = false;
                }

                Color oColor = GUI.backgroundColor;
                GUI.backgroundColor = Color.clear;
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();


                GUILayout.Box(previewTexture, GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth));

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUI.backgroundColor = oColor;

            });

            serializedObject.ApplyModifiedProperties();
        }
    }
}
