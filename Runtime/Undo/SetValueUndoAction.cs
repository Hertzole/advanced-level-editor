namespace Hertzole.ALE
{
    public class SetValueUndoAction : IUndoAction
    {
        public IExposedToLevelEditor exposed;
        public int propertyId;
        public object previousValue;
        public object newValue;

        public SetValueUndoAction(IExposedToLevelEditor exposed, int propertyId, object previousValue, object newValue)
        {
            this.exposed = exposed;
            this.propertyId = propertyId;
            this.previousValue = previousValue;
            this.newValue = newValue;
        }

        public void Execute(ILevelEditorUndo undo)
        {
            exposed.SetValue(propertyId, newValue, true);
        }

        public void Undo(ILevelEditorUndo undo)
        {
            exposed.SetValue(propertyId, previousValue, true);
        }

        public void DisposeAction(ILevelEditorUndo undo) { }

        public override string ToString()
        {
            return $"SetValueUndoAction ({exposed}, {propertyId}, {previousValue}, {newValue})";
        }
    }
}
