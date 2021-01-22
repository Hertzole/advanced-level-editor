using System;

namespace Hertzole.ALE
{
    public class SelectionEvent : EventArgs
    {
        public ILevelEditorObject OldObject { get; private set; }
        public ILevelEditorObject NewObject { get; private set; }

        public SelectionEvent(ILevelEditorObject oldObject, ILevelEditorObject newObject)
        {
            OldObject = oldObject;
            NewObject = newObject;
        }
    }

    public interface ILevelEditorSelection
    {
        ILevelEditorObject Selection { get; set; }
        event EventHandler<SelectionEvent> OnSelectionChanged;
    }
}
