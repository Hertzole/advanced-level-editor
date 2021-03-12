using System;

namespace Hertzole.ALE
{
    public interface ILevelEditorPlayMode
    {
        bool IsPlaying { get; }

        event Action OnStartPlayMode;
        event Action OnStopPlayMode;

        bool CanStartPlayMode(out string failReason);

        bool CanStopPlayMode(out string failReason);

        void StartPlayMode(ILevelEditor levelEditor);

        void StopPlayMode(ILevelEditor levelEditor);
    }
}
