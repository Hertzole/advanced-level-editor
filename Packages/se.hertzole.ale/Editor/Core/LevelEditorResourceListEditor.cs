using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    [CustomEditor(typeof(LevelEditorResourceList))]
    public class LevelEditorResourceListEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("You can also just double click the asset in the project window to open the editor.", MessageType.Info);

            EditorGUILayout.Space();

            if (GUILayout.Button("Open Editor"))
            {
                LevelEditorResourcesWindow.OpenAsset((LevelEditorResourceList)target);
            }
        }
    }
}
