﻿using System;
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

            rect.xMin = 0f;
            rect.width += 4f;

            if (Event.current.type != EventType.Repaint)
            {
                return;
            }

            EditorGUI.DrawRect(rect, !EditorGUIUtility.isProSkin ? new Color(0.6f, 0.6f, 0.6f, 1.333f) : new Color(0.12f, 0.12f, 0.12f, 1.333f));
        }

        //https://github.com/UnityTechnologies/ScriptableRenderPipeline/blob/master/com.unity.render-pipelines.core/CoreRP/Editor/CoreEditorUtils.cs#L133
        public static bool DrawHeaderFoldout(string title, bool state)
        {
            Rect backgroundRect = GUILayoutUtility.GetRect(1f, 17f);

            Rect labelRect = backgroundRect;
            labelRect.xMin += 16f;
            labelRect.xMax -= 20f;

            Rect foldoutRect = backgroundRect;
            foldoutRect.y += 1f;
            foldoutRect.width = 13f;
            foldoutRect.height = 13f;

            backgroundRect.xMin = 0f;
            backgroundRect.width += 4f;

            // Background
            float backgroundTint = EditorGUIUtility.isProSkin ? 0.1f : 1f;
            EditorGUI.DrawRect(backgroundRect, new Color(backgroundTint, backgroundTint, backgroundTint, 0.2f));

            // Title
            EditorGUI.LabelField(labelRect, title, EditorStyles.boldLabel);

            // Active checkbox
            state = GUI.Toggle(foldoutRect, state, GUIContent.none, EditorStyles.foldout);

            Event e = Event.current;
            if (e.type == EventType.MouseDown && backgroundRect.Contains(e.mousePosition) && e.button == 0)
            {
                state = !state;
                e.Use();
            }

            return state;
        }

        public static void DrawFancyFoldout(SerializedProperty foldoutProperty, string title, bool indent, Action drawCallback)
        {
            DrawSplitter();
            bool state = foldoutProperty.isExpanded;
            state = DrawHeaderFoldout(title, state);

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

                GUILayout.Space(2f);
            }

            foldoutProperty.isExpanded = state;
        }
    }
}
