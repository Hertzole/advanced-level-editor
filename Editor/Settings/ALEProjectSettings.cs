using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public class ALEProjectSettings : SettingsProvider
    {
        private ALESettings settings;

        public ALEProjectSettings(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords) { }

        public override void OnGUI(string searchContext)
        {
            if (settings == null)
            {
                settings = ALESettings.Get();
            }

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Space(6f);

                using (new GUILayout.VerticalScope())
                {
                    EditorGUIHelper.DrawHeaderLayout("Wrappers");

                    bool applyTransform = settings.ApplyTransformWrapper;
                    EditorGUI.BeginChangeCheck();
                    applyTransform = EditorGUILayout.Toggle("Apply Transform", applyTransform);
                    if (EditorGUI.EndChangeCheck())
                    {
                        settings.ApplyTransformWrapper = applyTransform;
                        settings.EditorSave();
                    }

                    bool applyRigidbody = settings.ApplyRigidbodyWrapper;
                    EditorGUI.BeginChangeCheck();
                    applyRigidbody = EditorGUILayout.Toggle("Apply Rigidbody", applyRigidbody);
                    if (EditorGUI.EndChangeCheck())
                    {
                        settings.ApplyRigidbodyWrapper = applyRigidbody;
                        settings.EditorSave();
                    }
                }
            }
        }

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new ALEProjectSettings("Hertzole/Advanced Level Editor", SettingsScope.Project)
            {
                label = "Advanced Level Editor",
                keywords = new string[]
                {
                    "transform",
                    "rigidbody",
                    "ale",
                    "level editor"
                }
            };
        }
    }
}
