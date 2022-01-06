using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
	public class EditorModeChangeEventArgs : EventArgs
	{
		public ILevelEditorMode PreviousMode { get; }
		public ILevelEditorMode NewMode { get; }

		public EditorModeChangeEventArgs(ILevelEditorMode previousMode, ILevelEditorMode newMode)
		{
			PreviousMode = previousMode;
			NewMode = newMode;
		}
	}

	public interface ILevelEditor
	{
		ILevelEditorSnapping Snapping { get; }

		ILevelEditorCamera LevelEditorCamera { get; set; }
		ILevelEditorUI UI { get; set; }
		ILevelEditorSaveManager SaveManager { get; set; }
		ILevelEditorObjectManager ObjectManager { get; set; }
		ILevelEditorInput Input { get; set; }
		ILevelEditorSelection Selection { get; set; }
		ILevelEditorPlayMode PlayMode { get; set; }
		ILevelEditorUndo Undo { get; set; }

		IReadOnlyList<ILevelEditorMode> EditorModes { get; set; }

		event EventHandler<EditorModeChangeEventArgs> OnEditorModeChanged; 

		bool IsDirty { get; }

		void SetMode(int newMode, bool wrapAroundOutOfRange = false);

		void SetMode<T>() where T : ILevelEditorMode;

		T GetMode<T>() where T : ILevelEditorMode;

		bool TryGetEditorMode<T>(out T mode) where T : ILevelEditorMode;

		void NewLevel();

		void MarkDirty();

		bool StartPlayMode(out string failReason);

		bool StopPlayMode(out string failReason);
	}
}