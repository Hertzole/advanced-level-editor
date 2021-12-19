using System;

namespace Hertzole.ALE
{
    public interface ILevelEditorUndo
    {
        ILevelEditor LevelEditor { get; }

        event Action<IUndoAction> OnUndo; 
        event Action<IUndoAction> OnRedo; 

        /// <summary>
        /// Adds an action to the history.
        /// </summary>
        /// <param name="action">The action you want to add.</param>
        void AddAction(IUndoAction action);

        void Undo();

        void Redo();
    }
}
