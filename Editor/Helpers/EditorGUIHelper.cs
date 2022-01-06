using System;
using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public static class EditorGUIHelper
    {
        public static void DrawHeaderLayout(string name)
        {
            EditorGUILayout.Space(4);
            EditorGUILayout.LabelField(name, EditorStyles.boldLabel);
        }

        // https://github.com/UnityTechnologies/ScriptableRenderPipeline/blob/master/com.unity.render-pipelines.core/CoreRP/Editor/CoreEditorUtils.cs#L92
        public static void DrawSplitter()
        {
            Rect rect = GUILayoutUtility.GetRect(1f, 1f);

            DrawSplitter(rect);
        }

        public static void DrawSplitter(Rect rect)
        {
            rect.xMin = 0f;
            rect.width += 4f;

            if (Event.current.type != EventType.Repaint)
            {
                return;
            }

            EditorGUI.DrawRect(rect, !EditorGUIUtility.isProSkin ? new Color(0.6f, 0.6f, 0.6f, 1.333f) : new Color(0.12f, 0.12f, 0.12f, 1.333f));
        }

        public static bool DrawHeaderFoldout(string title, bool state)
        {
            Rect backgroundRect = GUILayoutUtility.GetRect(1f, 17f);
            return DrawHeaderFoldout(backgroundRect, title, state);
        }

        //https://github.com/UnityTechnologies/ScriptableRenderPipeline/blob/master/com.unity.render-pipelines.core/CoreRP/Editor/CoreEditorUtils.cs#L133
        public static bool DrawHeaderFoldout(Rect rect, string title, bool state)
        {
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            Rect labelRect = rect;
            labelRect.xMin += 16f;
            labelRect.xMax -= 20f;

            Rect foldoutRect = rect;
            foldoutRect.y += 1f;
            foldoutRect.width = 13f;
            foldoutRect.height = 13f;

            rect.xMin = 0f;
            rect.width += 4f;

            // Background
            float backgroundTint = EditorGUIUtility.isProSkin ? 0.1f : 1f;
            EditorGUI.DrawRect(rect, new Color(backgroundTint, backgroundTint, backgroundTint, 0.2f));

            // Title
            EditorGUI.LabelField(labelRect, title, EditorStyles.boldLabel);

            // Active checkbox
            state = GUI.Toggle(foldoutRect, state, GUIContent.none, EditorStyles.foldout);

            Event e = Event.current;
            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition) && e.button == 0)
            {
                state = !state;
                e.Use();
            }

            EditorGUI.indentLevel = indent;

            return state;
        }

        public static void DrawFancyFoldout(SerializedProperty foldoutProperty, string title, bool indent, Action drawCallback)
        {
            DrawFancyFoldout(EditorGUILayout.GetControlRect(), foldoutProperty, title, indent, drawCallback);
        }

        public static void DrawFancyFoldout(Rect rect, SerializedProperty foldoutProperty, string title, bool indent, Action drawCallback)
        {
            DrawSplitter(new Rect(rect.position, new Vector2(rect.width, 1f)));
            bool state = foldoutProperty.isExpanded;
            state = DrawHeaderFoldout(new Rect(rect.position, new Vector2(rect.width, 17f)), title, state);

            if (state)
            {
                if (indent)
                {
                    EditorGUI.indentLevel++;
                }

                drawCallback();

                if (indent)
                {
                    EditorGUI.indentLevel--;
                }
            }
            
            foldoutProperty.isExpanded = state;
        }
    }
}
