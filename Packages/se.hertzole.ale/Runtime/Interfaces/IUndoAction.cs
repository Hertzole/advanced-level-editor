namespace Hertzole.ALE
{
    public interface IUndoAction
    {
        void Undo(ILevelEditorUndo undo);

        void Redo(ILevelEditorUndo undo);
    }
}
