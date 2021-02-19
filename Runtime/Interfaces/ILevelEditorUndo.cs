namespace Hertzole.ALE
{
    public interface ILevelEditorUndo
    {
        ILevelEditorObjectManager ObjectManager { get; }

        /// <summary>
        /// Adds an action to the history.
        /// </summary>
        /// <param name="action">The action you want to add.</param>
        /// <param name="execute">If true, the action's execute function will be called.</param>
        void AddAction(IUndoAction action, bool execute = true);

        void Undo();

        void Redo();
    }
}
