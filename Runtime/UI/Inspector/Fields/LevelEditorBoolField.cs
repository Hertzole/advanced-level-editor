#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#if !OBSOLETE
    [AddComponentMenu("ALE/UI/uGUI/Fields/Bool Field", 200)]
#else
    [System.Obsolete("LevelEditorBoolField has been stripped and will be removed on build.", true)]
#endif
#endif
    public class LevelEditorBoolField : LevelEditorInspectorField<bool>
    {
        [SerializeField]
        private Toggle toggle = null;

        [SerializeField]
        private Toggle.ToggleEvent onValueChanged = new Toggle.ToggleEvent();

        public Toggle.ToggleEvent OnValueChanged { get { return onValueChanged; } }

        protected override void OnAwake()
        {
            this.LogIfStripped();

            toggle.onValueChanged.AddListener(x =>
            {
                BeginEdit();
                ModifyPropertyValue(x, true);
                EndEdit();
                onValueChanged.Invoke(x);
            });
        }

        protected override void SetFieldValue(bool value)
        {
            toggle.SetIsOnWithoutNotify(value);
        }
    }
}
#endif
