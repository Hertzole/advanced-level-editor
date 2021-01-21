namespace Hertzole.ALE
{
    public interface ILevelEditor
    {
        ILevelEditorSnapping Snapping { get; }

        ILevelEditorCamera LevelEditorCamera { get; }
        ILevelEditorUI UI { get; }
        ILevelEditorSaveManager SaveManager { get; }
        ILevelEditorObjectManager ObjectManager { get; }
        ILevelEditorInput Input { get; }
        ILevelEditorSelection Selection { get; }
        ILevelEditorPlayMode PlayMode { get; }

        bool IsDirty { get; }

        void SetMode(int newMode, bool returnOnOutOfRange = true);

        void NewLevel();

        void MarkDirty();

        bool StartPlayMode(out string failReason);

        bool StopPlayMode(out string failReason);
    }
}
