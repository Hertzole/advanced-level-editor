using UnityEngine.Events;

namespace Hertzole.ALE
{
    public class LevelEditorWindowEvent : UnityEvent { }

    public interface ILevelEditorWindow
    {
        bool Showing { get; }

        LevelEditorWindowEvent OnWindowClose { get; }
        LevelEditorWindowEvent OnWindowOpen { get; }

        void Dismiss();

        void Show();

        void Show(bool dismissOnBackgroundClick);
    }
}
