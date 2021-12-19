using UnityEngine;

namespace Hertzole.ALE
{
	/// <summary>
	///     The same as <see cref="TransformObjectUndoAction" /> but for multiple objects. If you're just saving one object,
	///     use <see cref="TransformObjectUndoAction" /> instead.
	/// </summary>
	public class TransformObjectsUndoAction : IUndoAction
	{
		private readonly uint[] objects;

		private readonly Vector3[] fromPositions;
		private readonly Vector3[] fromRotations;
		private readonly Vector3[] fromScales;

		private readonly Vector3[] toPositions;
		private readonly Vector3[] toRotations;
		private readonly Vector3[] toScales;

		public TransformObjectsUndoAction(uint[] objects, Vector3[] fromPositions, Vector3[] fromRotations, Vector3[] fromScales, Vector3[] toPositions, Vector3[] toRotations, Vector3[] toScales)
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
			for (int i = 0; i < objects.Length; i++)
			{
				if (LevelEditorWorld.TryGetObject(objects[i], out ILevelEditorObject target))
				{
					Transform targetTransform = target.MyGameObject.transform;
					targetTransform.position = fromPositions[i];
					targetTransform.eulerAngles = fromRotations[i];
					targetTransform.localScale = fromScales[i];
				}
			}
		}

		public void Redo(ILevelEditorUndo undo)
		{
			for (int i = 0; i < objects.Length; i++)
			{
				if (LevelEditorWorld.TryGetObject(objects[i], out ILevelEditorObject target))
				{
					Transform targetTransform = target.MyGameObject.transform;
					targetTransform.position = toPositions[i];
					targetTransform.eulerAngles = toRotations[i];
					targetTransform.localScale = toScales[i];
				}
			}
		}
	}
}