namespace Hertzole.ALE
{
    public class SetValueUndoAction : IUndoAction
    {
        private readonly IExposedToLevelEditor exposed;
        private readonly int propertyId;
        private readonly object previousValue;
        private readonly object newValue;

        public SetValueUndoAction(IExposedToLevelEditor exposed, int propertyId, object previousValue, object newValue)
        {
            this.exposed = exposed;
            this.propertyId = propertyId;
            this.previousValue = previousValue;
            this.newValue = newValue;
        }

        public void Redo(ILevelEditorUndo undo)
        {
            exposed.SetValue(propertyId, newValue, true);
        }

        public void Undo(ILevelEditorUndo undo)
        {
            exposed.SetValue(propertyId, previousValue, true);
        }

        public override string ToString()
        {
            return $"SetValueUndoAction ({exposed}, {propertyId}, {previousValue}, {newValue})";
        }
    }
}
