using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
	[DisallowMultipleComponent]
	[AddComponentMenu("ALE/Level Editor", 1)]
#endif
	[DefaultExecutionOrder(-10000)]
	public class LevelEditor : MonoBehaviour, ILevelEditor
	{
		[SerializeField]
		[RequireType(typeof(ILevelEditorCamera))]
		private GameObject editorCamera;
		[SerializeField]
		[RequireType(typeof(ILevelEditorUI))]
		private GameObject ui;
		[SerializeField]
		[RequireType(typeof(ILevelEditorSaveManager))]
		private GameObject saveManager;
		[SerializeField]
		[RequireType(typeof(ILevelEditorObjectManager))]
		private GameObject objectManager;
		[SerializeField]
		[RequireType(typeof(ILevelEditorInput))]
		private GameObject input;
		[SerializeField]
		[RequireType(typeof(ILevelEditorSelection))]
		private GameObject selection;
		[SerializeField]
		[RequireType(typeof(ILevelEditorUndo))]
		private GameObject undo;
		[SerializeField]
		[RequireType(typeof(ILevelEditorPlayMode))]
		private GameObject playMode;

		[Space]
		[SerializeField]
		private LevelEditorSnapping snapSettings = new LevelEditorSnapping();

		private ILevelEditorMode[] editorModes;

		private int selectedMode = -1;

		public ILevelEditorSnapping Snapping { get { return snapSettings; } }
		public ILevelEditorCamera LevelEditorCamera { get; set; }
		public ILevelEditorUI UI { get; set; }
		public ILevelEditorSaveManager SaveManager { get; set; }
		public ILevelEditorObjectManager ObjectManager { get; set; }
		public ILevelEditorPlayMode PlayMode { get; set; }
		public ILevelEditorInput Input { get; set; }
		public ILevelEditorSelection Selection { get; set; }
		public ILevelEditorUndo Undo { get; set; }

		public IReadOnlyList<ILevelEditorMode> EditorModes { get { return editorModes; } set { editorModes = value.ToArrayFast(); } }

		public bool IsDirty { get; private set; }

		private void Awake()
		{
			if (editorCamera != null)
			{
				LevelEditorCamera = editorCamera.NeedComponent<ILevelEditorCamera>();
			}

			if (ui != null)
			{
				UI = ui.NeedComponent<ILevelEditorUI>();
			}

			if (saveManager != null)
			{
				SaveManager = saveManager.NeedComponent<ILevelEditorSaveManager>();
			}

			if (objectManager != null)
			{
				ObjectManager = objectManager.NeedComponent<ILevelEditorObjectManager>();
			}

			if (input != null)
			{
				Input = input.NeedComponent<ILevelEditorInput>();
			}

			if (selection != null)
			{
				Selection = selection.NeedComponent<ILevelEditorSelection>();
			}

			if (undo != null)
			{
				Undo = undo.NeedComponent<ILevelEditorUndo>();
			}

			if (playMode != null)
			{
				PlayMode = playMode.NeedComponent<ILevelEditorPlayMode>();
			}

			editorModes = GetComponents<ILevelEditorMode>();

			if (editorModes != null && editorModes.Length > 0)
			{
				for (int i = 0; i < editorModes.Length; i++)
				{
					if (editorModes[i] is LevelEditorMode mode)
					{
						mode.LevelEditor = this;
					}
				}
			}
		}

		private void Start()
		{
			if (editorModes != null && editorModes.Length > 0)
			{
				for (int i = 0; i < editorModes.Length; i++)
				{
					editorModes[i].OnModeDisable();
				}

				SetMode(0);
			}
		}

		private void Update()
		{
			if (selectedMode >= 0 && editorModes.Length > 0 && (PlayMode != null && !PlayMode.IsPlaying || PlayMode == null))
			{
				editorModes[selectedMode].OnModeUpdate();
			}
		}

		private void LateUpdate()
		{
			if (selectedMode >= 0 && editorModes.Length > 0 && (PlayMode != null && !PlayMode.IsPlaying || PlayMode == null))
			{
				editorModes[selectedMode].OnModeLateUpdate();
			}
		}

		private void OnEnable()
		{
			if (ObjectManager != null)
			{
				ObjectManager.OnCreatedObject += OnCreateDeleteObject;
			}

			if (PlayMode != null)
			{
				PlayMode.OnStartPlayMode += OnStartPlayMode;
				PlayMode.OnStopPlayMode += OnStopPlayMode;
			}
		}

		private void OnDisable()
		{
			if (ObjectManager != null)
			{
				ObjectManager.OnCreatedObject -= OnCreateDeleteObject;
			}

			if (PlayMode != null)
			{
				PlayMode.OnStartPlayMode -= OnStartPlayMode;
				PlayMode.OnStopPlayMode -= OnStopPlayMode;
			}
		}

		private void OnCreateDeleteObject(object sender, LevelEditorObjectEvent args)
		{
			MarkDirty();
		}

		private void OnStartPlayMode()
		{
			UI.OnStartPlayMode();
			editorModes[selectedMode].OnModeDisable();
		}

		private void OnStopPlayMode()
		{
			UI.OnStopPlayMode();
			editorModes[selectedMode].OnModeEnable();
		}

		public void SetMode(int newMode, bool wrapAroundOutOfRange = false)
		{
#if !ALE_STRIP_SAFETY
			if (editorModes.Length == 0)
			{
				throw new MissingReferenceException($"There are no editor modes attached on {gameObject.name}.");
			}
#endif

			if (newMode < 0)
			{
				if (wrapAroundOutOfRange)
				{
					newMode = editorModes.Length - 1;
				}
#if !ALE_STRIP_SAFETY
				else
				{
					throw new ArgumentOutOfRangeException(nameof(newMode), $"{nameof(newMode)} must be between 0 and {editorModes.Length - 1}.");
				}
#endif
			}
			else if (newMode >= editorModes.Length)
			{
				if (wrapAroundOutOfRange)
				{
					newMode = 0;
				}
#if !ALE_STRIP_SAFETY
				else
				{
					throw new ArgumentOutOfRangeException(nameof(newMode), $"{nameof(newMode)} must be between 0 and {editorModes.Length - 1}.");
				}
#endif
			}

			if (selectedMode == newMode)
			{
				return;
			}

			if (selectedMode >= 0)
			{
				editorModes[selectedMode].OnModeDisable();
			}

			selectedMode = newMode;
			editorModes[selectedMode].OnModeEnable();
		}

		public void SetMode<T>() where T : ILevelEditorMode
		{
			for (int i = 0; i < editorModes.Length; i++)
			{
				if (editorModes[i] is T)
				{
					SetMode(i);
					return;
				}
			}

#if !ALE_STRIP_SAFETY
			throw new ArgumentException($"There's no editor mode on {gameObject.name} with the type {typeof(T)}.");
#endif
		}

		public T GetMode<T>() where T : ILevelEditorMode
		{
			if (editorModes == null || editorModes.Length == 0)
			{
				return default;
			}

			for (int i = 0; i < editorModes.Length; i++)
			{
				if (editorModes[i] is T mode)
				{
					return mode;
				}
			}

#if !ALE_STRIP_SAFETY
			throw new ArgumentException($"There's no editor mode on {gameObject.name} with the type {typeof(T)}.");
#else
            return default;
#endif
		}

		public bool TryGetEditorMode<T>(out T mode) where T : ILevelEditorMode
		{
			mode = default;
			if (editorModes == null || editorModes.Length == 0)
			{
				return false;
			}

			for (int i = 0; i < editorModes.Length; i++)
			{
				if (editorModes[i] is T foundMode)
				{
					mode = foundMode;
					return true;
				}
			}

			return false;
		}

		public void NewLevel()
		{
			ObjectManager.DeleteAllObjects();
			ObjectManager.ResetInstanceID();
			IsDirty = false;
			UI.InspectorPanel.BindObject(null);
		}

		public void MarkDirty()
		{
			IsDirty = true;
		}

		public bool StartPlayMode(out string failReason)
		{
#if DEBUG
			if (PlayMode == null)
			{
				Debug.LogError("There's no play mode assigned on the level editor. Play mode can not be started. " +
				               "This will not be caught in release! Remove play mode functionality from your level editor.");

				failReason = "Play mode is not supported.";
				return false;
			}
#endif

			if (!PlayMode.CanStartPlayMode(out failReason))
			{
				return false;
			}

			PlayMode.StartPlayMode(this);
			return true;
		}

		public bool StopPlayMode(out string failReason)
		{
#if DEBUG
			if (PlayMode == null)
			{
				Debug.LogError("There's no play mode assigned on the level editor. Play mode can not be stopped. " +
				               "This will not be caught in release! Remove play mode functionality from your level editor.");

				failReason = "Play mode is not supported.";
				return false;
			}
#endif

			if (!PlayMode.CanStopPlayMode(out failReason))
			{
				return false;
			}

			PlayMode.StopPlayMode(this);
			return true;
		}
	}
}