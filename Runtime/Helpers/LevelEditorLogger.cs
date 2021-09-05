using UnityEngine;
using Conditional = System.Diagnostics.ConditionalAttribute;
// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace Hertzole.ALE
{
    public static class LevelEditorLogger
    {
        [Conditional("ALE_DEBUG")]
        public static void Log(object message)
        {
            Debug.Log($"[ALE] {message}");
        }

        [Conditional("ALE_DEBUG")]
        public static void LogWarning(object message)
        {
            Debug.LogWarning($"[ALE] {message}");
        }

        [Conditional("ALE_DEBUG")]
        public static void LogError(object message)
        {
            Debug.LogError($"[ALE] {message}");
        }

        [Conditional("ALE_DEBUG")]
        public static void LogTodo(object message)
        {
            Debug.Log($"<color=green><i>TODO: {message}</i></color>");
        }

        /// <summary>
        /// Only logs messages if DEBUG script define is present. Usually only in development builds and Unity editor.
        /// </summary>
        [Conditional("DEBUG")]
        public static void DebugLog(object message)
        {
            Debug.Log(message);
        }

        /// <summary>
        /// Only logs messages if DEBUG script define is present. Usually only in development builds and Unity editor.
        /// </summary>
        [Conditional("DEBUG")]
        public static void DebugLogWarning(object message)
        {
            Debug.LogWarning(message);
        }

        /// <summary>
        /// Only logs messages if DEBUG script define is present. Usually only in development builds and Unity editor.
        /// </summary>
        [Conditional("DEBUG")]
        public static void DebugLogError(object message)
        {
            Debug.LogError(message);
        }
    }
}
