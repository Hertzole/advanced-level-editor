namespace Hertzole.ALE
{
    public interface ILevelEditor
    {
        ILevelEditorSnapping Snapping { get; }

        ILevelEditorCamera LevelEditorCamera { get; set; }
        ILevelEditorUI UI { get; set; }
        ILevelEditorSaveManager SaveManager { get; set; }
        ILevelEditorObjectManager ObjectManager { get; set; }
        ILevelEditorInput Input { get; set; }
        ILevelEditorSelection Selection { get; set; }
        ILevelEditorPlayMode PlayMode { get; set; }
        ILevelEditorUndo Undo { get; set; }

        bool IsDirty { get; }

        void SetMode(int newMode, bool returnOnOutOfRange = true);

        void SetMode<T>() where T : ILevelEditorMode;

        bool TryGetEditorMode<T>(out T mode) where T : ILevelEditorMode;

        void NewLevel();

        void MarkDirty();

        bool StartPlayMode(out string failReason);

        bool StopPlayMode(out string failReason);
    }
}
