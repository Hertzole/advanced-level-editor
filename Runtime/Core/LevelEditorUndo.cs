using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
	public class LevelEditorUndo : MonoBehaviour, ILevelEditorUndo
	{
#if UNITY_EDITOR
		[Header("References")]
#endif
		[SerializeField]
		[RequireType(typeof(ILevelEditor))]
		private GameObject levelEditor = null;
		[SerializeField]
		[RequireType(typeof(ILevelEditorInput))]
		private GameObject input = null;

#if UNITY_EDITOR
		[Header("Input")]
#endif
		[SerializeField]
		private bool handleUndoRedoInput = true;
		[SerializeField]
		private string modifierAction = "Ctrl Modifier";
		[SerializeField]
		private string undoAction = "Undo";
		[SerializeField]
		private string redoAction = "Redo";

		private ILevelEditor realLevelEditor;
		private ILevelEditorInput inputComp;

		private int counter = 0;

		private readonly List<IUndoAction> actionHistory = new List<IUndoAction>();

		public bool HandleUndoRedoInput { get { return handleUndoRedoInput; } set { handleUndoRedoInput = value; } }

		public ILevelEditorInput Input
		{
			get
			{
				if (inputComp == null && input != null)
				{
					inputComp = input.GetComponent<ILevelEditorInput>();
				}

				return inputComp;
			}
			set
			{
				inputComp = value;
				if (value is Component comp)
				{
					input = comp.gameObject;
				}
			}
		}

		public ILevelEditor LevelEditor
		{
			get
			{
				if (realLevelEditor == null && levelEditor != null)
				{
					realLevelEditor = levelEditor.GetComponent<ILevelEditor>();
				}

				return realLevelEditor;
			}
			set
			{
				realLevelEditor = value;
				if (value is Component comp)
				{
					levelEditor = comp.gameObject;
				}
			}
		}

		public event Action<IUndoAction> OnUndo;
		public event Action<IUndoAction> OnRedo;

		private void Update()
		{
			if (handleUndoRedoInput)
			{
				HandleInput();
			}
		}

		protected virtual void HandleInput()
		{
			if (Input.GetButton(modifierAction))
			{
				if (Input.GetButtonDown(undoAction))
				{
					Undo();
				}

				if (Input.GetButtonDown(redoAction))
				{
					Redo();
				}
			}
		}

		public void AddAction(IUndoAction action)
		{
			LevelEditorLogger.Log($"Add undo action | Action: {action}");

			// Remove the actions above if we cut into the history.
			while (actionHistory.Count > counter)
			{
				actionHistory.RemoveAt(counter);
			}

			actionHistory.Add(action);
			counter++;
		}

		public void Redo()
		{
			LevelEditorLogger.Log("Redo");

			if (counter < actionHistory.Count)
			{
				IUndoAction action = actionHistory[counter];
				action.Redo(this);
				counter++;

				OnRedo?.Invoke(action);
			}
		}

		public void Undo()
		{
			LevelEditorLogger.Log("Undo");

			if (counter > 0)
			{
				counter--;
				IUndoAction action = actionHistory[counter];
				action.Undo(this);

				OnUndo?.Invoke(action);
			}
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			GetStandardComponents();
		}

		private void Reset()
		{
			GetStandardComponents();
		}

		private void GetStandardComponents()
		{
			if (levelEditor == null && TryGetComponent<ILevelEditorObjectManager>(out _))
			{
				levelEditor = gameObject;
			}

			if (input == null && TryGetComponent<ILevelEditorInput>(out _))
			{
				input = gameObject;
			}
		}
#endif
	}
}