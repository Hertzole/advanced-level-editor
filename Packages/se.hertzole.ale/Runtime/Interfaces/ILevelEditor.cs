namespace Hertzole.ALE
{
    public interface ILevelEditor
    {
        ILevelEditorSnapping Snapping { get; }

        ILevelEditorCamera LevelEditorCamera { get; }
        ILevelEditorUI UI { get; }
        ILevelEditorSaveManager SaveManager { get; }
        ILevelEditorObjectManager ObjectManager { get; }
        ILevelEditorPlayMode PlayMode { get; }

        void SetMode(int newMode);

        void NewLevel();

        bool IsDirty();

        void MarkDirty();

        bool StartPlayMode(out string failReason);

        bool StopPlayMode(out string failReason);
    }
}
