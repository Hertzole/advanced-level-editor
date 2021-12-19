namespace Hertzole.ALE
{
	public class SelectObjectUndoAction : IUndoAction
	{
		private readonly ILevelEditorObject previous;
		private readonly ILevelEditorObject current;

		public SelectObjectUndoAction(ILevelEditorObject previous, ILevelEditorObject current)
		{
			this.previous = previous;
			this.current = current;
		}

		public void Undo(ILevelEditorUndo undo)
		{
			if (previous == null)
			{
				undo.LevelEditor.Selection.SetSelection(null, false);
				return;
			}
			
			if (LevelEditorWorld.TryGetObject(previous.InstanceID, out ILevelEditorObject previousObj))
			{
				undo.LevelEditor.Selection.SetSelection(previousObj, false);
			}
		}

		public void Redo(ILevelEditorUndo undo)
		{
			if (current == null)
			{
				undo.LevelEditor.Selection.SetSelection(null, false);
				return;
			}
			
			if (LevelEditorWorld.TryGetObject(current.InstanceID, out ILevelEditorObject currentObj))
			{
				undo.LevelEditor.Selection.SetSelection(currentObj, false);
			}
		}
	}
}