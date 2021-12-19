using UnityEngine;

namespace Hertzole.ALE
{
	/// <summary>
	///     The same as <see cref="TransformObjectsUndoAction" /> but for a singular object. This is mostly just to save on
	///     garbage because it doesn't use arrays.
	/// </summary>
	public class TransformObjectUndoAction : IUndoAction
	{
		private readonly uint objects;

		private readonly Vector3 fromPositions;
		private readonly Vector3 fromRotations;
		private readonly Vector3 fromScales;

		private readonly Vector3 toPositions;
		private readonly Vector3 toRotations;
		private readonly Vector3 toScales;

		public TransformObjectUndoAction(uint objects, Vector3 fromPositions, Vector3 fromRotations, Vector3 fromScales, Vector3 toPositions, Vector3 toRotations, Vector3 toScales)
		{
			this.objects = objects;
			this.fromPositions = fromPositions;
			this.fromRotations = fromRotations;
			this.fromScales = fromScales;
			this.toPositions = toPositions;
			this.toRotations = toRotations;
			this.toScales = toScales;
		}

		public void Undo(ILevelEditorUndo undo)
		{
			if (LevelEditorWorld.TryGetObject(objects, out ILevelEditorObject target))
			{
				Transform targetTransform = target.MyGameObject.transform;
				targetTransform.position = fromPositions;
				targetTransform.eulerAngles = fromRotations;
				targetTransform.localScale = fromScales;
			}
		}

		public void Redo(ILevelEditorUndo undo)
		{
			if (LevelEditorWorld.TryGetObject(objects, out ILevelEditorObject target))
			{
				Transform targetTransform = target.MyGameObject.transform;
				targetTransform.position = toPositions;
				targetTransform.eulerAngles = toRotations;
				targetTransform.localScale = toScales;
			}
		}
	}
}