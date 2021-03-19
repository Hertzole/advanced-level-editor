using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public static class PlayModeCheck
    {
        [InitializeOnLoadMethod]
        public static void OnInitializeOnLoad()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                CheckWeave();
            }
        }

        private static void CheckWeave()
        {
            if (!SessionState.GetBool(WeaverConstants.WEAVE_SUCCESS, false))
            {
                SessionState.SetBool(WeaverConstants.WEAVE_SUCCESS, true);
                CompileHook.WeaveAllAssemblies();

                if (!SessionState.GetBool(WeaverConstants.WEAVE_SUCCESS, false))
                {
                    Debug.LogError("Can't enter play mode until weaver issues are resolved.");
                    EditorApplication.isPlaying = false;
                }
            }
        }
    }
}
