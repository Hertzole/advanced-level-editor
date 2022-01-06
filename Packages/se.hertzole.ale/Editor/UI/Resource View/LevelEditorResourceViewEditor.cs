using UnityEditor;

namespace Hertzole.ALE.Editor
{
    [CustomEditor(typeof(LevelEditorResourceView))]
    public class LevelEditorResourceViewEditor : UnityEditor.Editor
    {
        private SerializedProperty resources;
        private SerializedProperty folderTree;
        private SerializedProperty showRoot;
        private SerializedProperty rootName;
        private SerializedProperty assetsContent;
        private SerializedProperty assetButtonPrefab;
        private SerializedProperty displayFirstSpriteAsIcon;
        private SerializedProperty iconHandling;
        private SerializedProperty generateAsync;
        private SerializedProperty asyncWaitMethod;
        private SerializedProperty previewSettings;

        private void OnEnable()
        {
            resources = serializedObject.FindProperty(nameof(resources));
            folderTree = serializedObject.FindProperty(nameof(folderTree));
            showRoot = serializedObject.FindProperty(nameof(showRoot));
            rootName = serializedObject.FindProperty(nameof(rootName));
            assetsContent = serializedObject.FindProperty(nameof(assetsContent));
            assetButtonPrefab = serializedObject.FindProperty(nameof(assetButtonPrefab));
            displayFirstSpriteAsIcon = serializedObject.FindProperty(nameof(displayFirstSpriteAsIcon));
            iconHandling = serializedObject.FindProperty(nameof(iconHandling));
            generateAsync = serializedObject.FindProperty(nameof(generateAsync));
            asyncWaitMethod = serializedObject.FindProperty(nameof(asyncWaitMethod));
            previewSettings = serializedObject.FindProperty(nameof(previewSettings));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(resources);
            
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

            EditorGUILayout.PropertyField(previewSettings);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
