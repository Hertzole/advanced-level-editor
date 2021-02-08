using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    //TODO: LevelEditorCameraEditor
    [CustomEditor(typeof(LevelEditorCamera))]
    public class LevelEditorCameraEditor : UnityEditor.Editor
    {
        private GUIContent twoDModeContent = new GUIContent("2D Mode");
        private GUIContent boundsMinContent = new GUIContent("Bounds Min");
        private GUIContent boundsMaxContent = new GUIContent("Bounds Max");
        private GUIContent canFlyContent = new GUIContent("Can Pan With Right Click");
        private GUIContent canPanContent = new GUIContent("Can Pan With Middle Click");

        private SerializedProperty twoDMode;
        private SerializedProperty limitBounds;
        private SerializedProperty bounds3DMin;
        private SerializedProperty bounds3DMax;
        private SerializedProperty bounds2DMin;
        private SerializedProperty bounds2DMax;
        private SerializedProperty moveSpeed;
        private SerializedProperty lookSpeed;
        private SerializedProperty orbitSpeed;
        private SerializedProperty scrollModifier;
        private SerializedProperty zoomSpeed;
        private SerializedProperty minZoom;
        private SerializedProperty maxZoom;
        private SerializedProperty canFly;
        private SerializedProperty canElevate;
        private SerializedProperty canZoom;
        private SerializedProperty canDolly;
        private SerializedProperty canPan;
        private SerializedProperty canOrbit;
        private SerializedProperty altModifier;
        private SerializedProperty cameraZoom;
        private SerializedProperty cameraFly;
        private SerializedProperty cameraMove;
        private SerializedProperty cameraLook;
        private SerializedProperty cameraElevate;
        private SerializedProperty cameraOrbit;
        private SerializedProperty cameraPan;
        private SerializedProperty input;

        private void OnEnable()
        {
            twoDMode = serializedObject.FindProperty(nameof(twoDMode));

            limitBounds = serializedObject.FindProperty(nameof(limitBounds));
            bounds3DMin = serializedObject.FindProperty(nameof(bounds3DMin));
            bounds3DMax = serializedObject.FindProperty(nameof(bounds3DMax));
            bounds2DMin = serializedObject.FindProperty(nameof(bounds2DMin));
            bounds2DMax = serializedObject.FindProperty(nameof(bounds2DMax));

            moveSpeed = serializedObject.FindProperty(nameof(moveSpeed));
            lookSpeed = serializedObject.FindProperty(nameof(lookSpeed));
            orbitSpeed = serializedObject.FindProperty(nameof(orbitSpeed));
            scrollModifier = serializedObject.FindProperty(nameof(scrollModifier));
            zoomSpeed = serializedObject.FindProperty(nameof(zoomSpeed));
            minZoom = serializedObject.FindProperty(nameof(minZoom));
            maxZoom = serializedObject.FindProperty(nameof(maxZoom));

            canFly = serializedObject.FindProperty(nameof(canFly));
            canElevate = serializedObject.FindProperty(nameof(canElevate));
            canZoom = serializedObject.FindProperty(nameof(canZoom));
            canDolly = serializedObject.FindProperty(nameof(canDolly));
            canPan = serializedObject.FindProperty(nameof(canPan));
            canOrbit = serializedObject.FindProperty(nameof(canOrbit));

            altModifier = serializedObject.FindProperty(nameof(altModifier));
            cameraZoom = serializedObject.FindProperty(nameof(cameraZoom));
            cameraFly = serializedObject.FindProperty(nameof(cameraFly));
            cameraMove = serializedObject.FindProperty(nameof(cameraMove));
            cameraLook = serializedObject.FindProperty(nameof(cameraLook));
            cameraElevate = serializedObject.FindProperty(nameof(cameraElevate));
            cameraOrbit = serializedObject.FindProperty(nameof(cameraOrbit));
            cameraPan = serializedObject.FindProperty(nameof(cameraPan));
            input = serializedObject.FindProperty(nameof(input));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(twoDMode, twoDModeContent);
            EditorGUILayout.PropertyField(limitBounds);
            if (limitBounds.boolValue)
            {
                if (twoDMode.boolValue)
                {
                    EditorGUILayout.PropertyField(bounds2DMin, boundsMinContent);
                    EditorGUILayout.PropertyField(bounds2DMax, boundsMaxContent);
                }
                else
                {
                    EditorGUILayout.PropertyField(bounds3DMin, boundsMinContent);
                    EditorGUILayout.PropertyField(bounds3DMax, boundsMaxContent);
                }
            }

            EditorGUILayout.Space();

            EditorGUIHelper.DrawFancyFoldout(twoDMode, "Speeds", true, () =>
            {
                if (!twoDMode.boolValue)
                {
                    EditorGUILayout.PropertyField(moveSpeed);
                    EditorGUILayout.PropertyField(lookSpeed);
                    EditorGUILayout.PropertyField(orbitSpeed);
                }
                EditorGUILayout.PropertyField(scrollModifier);
                EditorGUILayout.PropertyField(zoomSpeed);
                EditorGUILayout.PropertyField(minZoom);
                EditorGUILayout.PropertyField(maxZoom);
            });

            EditorGUILayout.Space();

            EditorGUIHelper.DrawFancyFoldout(canFly, "Capabilities", true, () =>
            {
                if (!twoDMode.boolValue)
                {
                    EditorGUILayout.PropertyField(canFly);
                    EditorGUILayout.PropertyField(canElevate);
                    EditorGUILayout.PropertyField(canZoom);
                    EditorGUILayout.PropertyField(canDolly);
                    EditorGUILayout.PropertyField(canPan);
                    EditorGUILayout.PropertyField(canOrbit);
                }
                else
                {
                    EditorGUILayout.PropertyField(canFly, canFlyContent);
                    EditorGUILayout.PropertyField(canPan, canPanContent);
                    EditorGUILayout.PropertyField(canDolly);
                    EditorGUILayout.PropertyField(canZoom);
                }
            });

            EditorGUILayout.Space();

            EditorGUIHelper.DrawFancyFoldout(altModifier, "Input", true, () =>
            {
                EditorGUILayout.PropertyField(input);
                EditorGUILayout.PropertyField(altModifier);
                EditorGUILayout.PropertyField(cameraZoom);
                EditorGUILayout.PropertyField(cameraFly);
                EditorGUILayout.PropertyField(cameraMove);
                EditorGUILayout.PropertyField(cameraLook);
                EditorGUILayout.PropertyField(cameraElevate);
                EditorGUILayout.PropertyField(cameraOrbit);
                EditorGUILayout.PropertyField(cameraPan);
            });

            serializedObject.ApplyModifiedProperties();
        }
    }
}
