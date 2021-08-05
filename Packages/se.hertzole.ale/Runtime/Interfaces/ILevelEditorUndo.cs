namespace Hertzole.ALE
{
    public interface ILevelEditorUndo
    {
        ILevelEditorObjectManager ObjectManager { get; }

        /// <summary>
        /// Adds an action to the history.
        /// </summary>
        /// <param name="action">The action you want to add.</param>
        void AddAction(IUndoAction action);

        void Undo();

        void Redo();
    }
}
