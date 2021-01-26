using UnityEngine.Events;

namespace Hertzole.ALE
{
    public class LevelEditorWindowEvent : UnityEvent { }

    public interface ILevelEditorWindow
    {
        LevelEditorWindowEvent OnWindowClose { get; }
        LevelEditorWindowEvent OnWindowOpen { get; }

        void Initialize(ILevelEditor levelEditor);

        void Show();

        void Show(bool dismissOnBackgroundClick);
    }
}
