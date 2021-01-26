using System;

namespace Hertzole.ALE
{
    public interface ILevelEditorObjectPickerWindow : ILevelEditorWindow
    {
        void Show(Type type, bool sceneObject);

        event Action<UnityEngine.Object> OnObjectSelected;
    }
}
