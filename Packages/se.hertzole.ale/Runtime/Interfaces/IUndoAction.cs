namespace Hertzole.ALE
{
    public interface IUndoAction
    {
        void Undo(ILevelEditorUndo undo);

        void Execute(ILevelEditorUndo undo);

        void DisposeAction(ILevelEditorUndo undo);
    }
}
