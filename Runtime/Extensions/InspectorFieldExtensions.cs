#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP_UGUI
#endif

using Conditional = System.Diagnostics.ConditionalAttribute;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        [Conditional("STRIP_UGUI")]
        public static void LogIfStripped(this LevelEditorInspectorField x)
        {
#if STRIP_UGUI
            UnityEngine.Debug.LogError($"{x.gameObject.name} is still using {x.GetType().Name}. It will be stripped on build. Make sure to remove it!", x.gameObject);
#endif
        }
    }
}
