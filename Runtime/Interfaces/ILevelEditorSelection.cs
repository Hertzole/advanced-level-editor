using System;

namespace Hertzole.ALE
{
    public class SelectionEventArgs : EventArgs
    {
        public ILevelEditorObject OldObject { get; private set; }
        public ILevelEditorObject NewObject { get; private set; }

        public SelectionEventArgs(ILevelEditorObject oldObject, ILevelEditorObject newObject)
        {
            OldObject = oldObject;
            NewObject = newObject;
        }
    }

    public interface ILevelEditorSelection
    {
        ILevelEditorObject Selection { get; }
        event EventHandler<SelectionEventArgs> OnSelectionChanged;

        void SetSelection(ILevelEditorObject target, bool registerUndo = true);
    }
}
