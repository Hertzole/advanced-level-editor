using UnityEngine;
using UnityEngine.Assertions;

namespace Hertzole.ALE
{
	public class DeleteObjectUndoAction : IUndoAction
	{
		private readonly uint targetInstanceId;
		private readonly LevelEditorIdentifier targetId;
		private readonly IExposedWrapper[] savedValues;

		public DeleteObjectUndoAction(ILevelEditorObject obj)
		{
			targetId = obj.ID;
			targetInstanceId = obj.InstanceID;
			IExposedToLevelEditor[] exposed = obj.GetExposedComponents();
			savedValues = new IExposedWrapper[exposed.Length];
			for (int i = 0; i < exposed.Length; i++)
			{
				savedValues[i] = exposed[i].GetWrapper();
			}
		}
		
		public void Undo(ILevelEditorUndo undo)
		{
			ILevelEditorObject newObj = undo.ObjectManager.CreateObject(targetId, targetInstanceId, false);
			
			IExposedToLevelEditor[] exposed = newObj.GetExposedComponents();
			
			Assert.AreEqual(exposed.Length, savedValues.Length);
			
			for (int i = 0; i < exposed.Length; i++)
			{
				exposed[i].ApplyWrapper(savedValues[i], true);
			}
		}

		public void Redo(ILevelEditorUndo undo)
		{
			if(LevelEditorWorld.TryGetObject(targetInstanceId, out var target))
			{
				undo.ObjectManager.DeleteObject(target, false);
			}
		}
	}
}