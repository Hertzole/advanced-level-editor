using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorSelection : MonoBehaviour, ILevelEditorSelection
    {
        private static ILevelEditorObject currentSelected;

        public static ILevelEditorObject CurrentSelected { get { return currentSelected; } set { SetSelected(value); } }

        public static event Action<ILevelEditorObject> OnSelectionChanged;

#if UNITY_2019_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics()
        {
            currentSelected = null;
            OnSelectionChanged = null;
        }
#endif

        private static void SetSelected(ILevelEditorObject value)
        {
            if (currentSelected != null && currentSelected.Equals(value))
            {
                return;
            }

            currentSelected = value;
            OnSelectionChanged?.Invoke(currentSelected);
        }
    }
}
