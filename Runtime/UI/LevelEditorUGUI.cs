using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
	[DisallowMultipleComponent]
	[AddComponentMenu("ALE/UI/uGUI/Level Editor uGUI", 0)]
#endif
	public class LevelEditorUGUI : MonoBehaviour, ILevelEditorUI
	{
		[SerializeField]
		private ScriptableObject resources;
		[SerializeField]
		[RequireType(typeof(ILevelEditor))]
		private GameObject levelEditor;

		[Space]
		[SerializeField]
		private GameObject editorRoot;
		[SerializeField]
		private GameObject playModeRoot;

		[Header("Panels")]
		[SerializeField]
		[RequireType(typeof(ILevelEditorResourceView))]
		private GameObject resourcePanel;
		[SerializeField]
		[RequireType(typeof(ILevelEditorInspector))]
		private GameObject inspectorPanel;
		[SerializeField]
		[RequireType(typeof(ILevelEditorHierarchy))]
		private GameObject hierarchyPanel;

		[Header("Modals")]
		[SerializeField]
		private GameObject modalsBackground;
		[SerializeField]
		[RequireType(typeof(ILevelEditorSaveModal))]
		private GameObject saveModal;
		[SerializeField]
		[RequireType(typeof(ILevelEditorLoadModal))]
		private GameObject loadModal;
		[SerializeField]
		[RequireType(typeof(ILevelEditorMessageModal))]
		private GameObject messageModal;

		[Header("Windows")]
		[SerializeField]
		[RequireType(typeof(ILevelEditorColorPickerWindow))]
		private GameObject colorPickerWindow;
		[SerializeField]
		[RequireType(typeof(ILevelEditorObjectPickerWindow))]
		private GameObject objectPickerWindow;

		private bool isInputFieldSelected;
		private bool isInputting;

		// The previously selected game object in the event system.
		protected GameObject previouslySelectedGameObject;
		
		private ILevelEditorResources realResources;

		public ILevelEditor LevelEditor { get; private set; }

		public ILevelEditorInspector InspectorPanel { get; private set; }
		public ILevelEditorResourceView ResourcePanel { get; private set; }
		public ILevelEditorHierarchy HierarchyPanel { get; private set; }

		public ILevelEditorSaveModal SaveModal { get; private set; }
		public ILevelEditorLoadModal LoadModal { get; private set; }
		public ILevelEditorMessageModal MessageModal { get; private set; }

		public ILevelEditorColorPickerWindow ColorPickerWindow { get; private set; }
		public ILevelEditorObjectPickerWindow ObjectPickerWindow { get; private set; }

		protected virtual void Awake()
		{
			if (levelEditor != null)
			{
				LevelEditor = levelEditor.NeedComponent<ILevelEditor>();
				if (LevelEditor != null && LevelEditor.Selection != null)
				{
					LevelEditor.Selection.OnSelectionChanged += OnSelectionChanged;
				}
			}

			if (inspectorPanel != null)
			{
				InspectorPanel = inspectorPanel.NeedComponent<ILevelEditorInspector>();
			}

			if (resourcePanel != null)
			{
				ResourcePanel = resourcePanel.NeedComponent<ILevelEditorResourceView>();
			}

			if (hierarchyPanel != null)
			{
				HierarchyPanel = hierarchyPanel.NeedComponent<ILevelEditorHierarchy>();
			}

			SaveModal = GetModal(SaveModal, saveModal, OnSaveModalClose);
			LoadModal = GetModal(LoadModal, loadModal, OnLoadModalClose);
			MessageModal = GetModal(MessageModal, messageModal, OnMessageModalClose);

			if (colorPickerWindow != null)
			{
				ColorPickerWindow = colorPickerWindow.NeedComponent<ILevelEditorColorPickerWindow>();
			}

			if (objectPickerWindow != null)
			{
				ObjectPickerWindow = objectPickerWindow.NeedComponent<ILevelEditorObjectPickerWindow>();
			}

			ToggleSaveModal(false, true);
			ToggleLoadModal(false, true);
			ToggleMessageModal(false, true);
			
			InitializeObjects();
		}

		private void OnDestroy()
		{
			if (LevelEditor != null && LevelEditor.Selection != null)
			{
				LevelEditor.Selection.OnSelectionChanged -= OnSelectionChanged;
			}
		}

		protected virtual void Update()
		{
			isInputFieldSelected = UpdateIfInputFieldSelected();
		}
		
		protected virtual bool UpdateIfInputFieldSelected()
		{
			EventSystem current = EventSystem.current;
            
			// There is no EventSystem, just return false.
			if (current == null)
			{
				previouslySelectedGameObject = null;
				return false;
			}

			// Use a cached value to minimize TryGetComponent calls.
			// Check if it isn't the same as the previous object first.
			if (current.currentSelectedGameObject != previouslySelectedGameObject)
			{
				// Update the previous object.
				previouslySelectedGameObject = current.currentSelectedGameObject;
				// If it isn't null and has a input field component, the user is probably inputting text..
				// Else, they are not.
				if (previouslySelectedGameObject != null && (previouslySelectedGameObject.TryGetComponent(out TMP_InputField _) || previouslySelectedGameObject.TryGetComponent(out InputField _)))
				{
					isInputting = true;
				}
				else
				{
					isInputting = false;
				}
			}
			
			return isInputting;
		}

		protected virtual void InitializeObjects()
		{
			InitializeHelper.TryInitializeObject(inspectorPanel);
			InitializeHelper.TryInitializeObject(hierarchyPanel);
			InitializeHelper.TryInitializeObject(resourcePanel);
			
			InitializeHelper.TryInitializeObject(saveModal);
			InitializeHelper.TryInitializeObject(loadModal);
			InitializeHelper.TryInitializeObject(messageModal);
			
			InitializeHelper.TryInitializeObject(colorPickerWindow);
			InitializeHelper.TryInitializeObject(objectPickerWindow);
		}

		private void OnMessageModalClose()
		{
			ToggleMessageModal(false, false);
		}

		private void OnLoadModalClose()
		{
			ToggleLoadModal(false, false);
		}

		private void OnSaveModalClose()
		{
			ToggleSaveModal(false, false);
		}

		public virtual void ClickNewLevel()
		{
			if (LevelEditor.IsDirty && MessageModal != null)
			{
				MessageModal.ShowPrompt("New Level", "Are you sure you want to create a new level?\nAll unsaved changes will be lost!", "Yes", "No", onClickConfirm: ConfirmNewLevel);
				ToggleMessageModal(true, false);
			}
		}

		protected virtual void ConfirmNewLevel()
		{
			LevelEditor.NewLevel();
		}

		public virtual void ClickSaveLevel()
		{
			ToggleSaveModal(true, false);
		}

		public virtual void ClickLoadLevel()
		{
			ToggleLoadModal(true, false);
		}

		public virtual void ClickPlayLevel()
		{
			if (!LevelEditor.StartPlayMode(out string failReason))
			{
				if (MessageModal != null)
				{
					MessageModal.ShowMessage("Play Mode Error", failReason, "Okay");
					ToggleMessageModal(true, false);
				}
			}
		}

		protected virtual void OnSelectionChanged(object sender, SelectionEventArgs e)
		{
			if (InspectorPanel != null)
			{
				InspectorPanel.BindObject(e.NewObject);
			}
		}

		public static T GetModal<T>(T old, GameObject go, Action onClose) where T : ILevelEditorModal
		{
			if (old != null)
			{
				old.OnClose -= onClose;
			}

			if (go != null && go.TryGetComponent(out T result))
			{
				result.OnClose += onClose;
				return result;
			}

			return default;
		}

		protected virtual void UpdateModalBackground()
		{
			UpdateModalBackground(IsModalActiveAndExists(SaveModal) || IsModalActiveAndExists(LoadModal) || IsModalActiveAndExists(MessageModal));
		}

		protected virtual void UpdateModalBackground(bool isShowing)
		{
			if (modalsBackground != null)
			{
				modalsBackground.gameObject.SetActive(isShowing);
			}
		}

		public static bool IsModalActiveAndExists(ILevelEditorModal go)
		{
			return go != null && go.MyGameObject.activeInHierarchy;
		}

		public virtual void ToggleInspectorPanel(bool toggle, bool instant)
		{
			if (InspectorPanel == null)
			{
				return;
			}

			InspectorPanel.MyGameObject.SetActive(toggle);
		}

		public void ToggleResourcePanel(bool toggle, bool instant)
		{
			if (ResourcePanel == null)
			{
				return;
			}

			ResourcePanel.MyGameObject.SetActive(toggle);
		}

		public virtual void ToggleHierarchyPanel(bool toggle, bool instant)
		{
			if (HierarchyPanel == null)
			{
				return;
			}

			HierarchyPanel.MyGameObject.SetActive(toggle);
		}

		public virtual void ToggleSaveModal(bool toggle, bool instant)
		{
			if (SaveModal == null)
			{
				return;
			}

			SaveModal.MyGameObject.SetActive(toggle);
			UpdateModalBackground();
		}

		public virtual void ToggleLoadModal(bool toggle, bool instant)
		{
			if (LoadModal == null)
			{
				return;
			}
			
			LoadModal.MyGameObject.SetActive(toggle);
			UpdateModalBackground();
		}

		public virtual void ToggleMessageModal(bool toggle, bool instant)
		{
			if (MessageModal == null)
			{
				return;
			}

			MessageModal.MyGameObject.SetActive(toggle);
			UpdateModalBackground();
		}

		public virtual bool IsInputFieldSelected()
		{
			return isInputFieldSelected;
		}

		public virtual void OnStartPlayMode()
		{
			if (editorRoot != null)
			{
				editorRoot.SetActive(false);
			}

			if (playModeRoot != null)
			{
				playModeRoot.SetActive(true);
			}
		}

		public virtual void OnStopPlayMode()
		{
			if (editorRoot != null)
			{
				editorRoot.SetActive(true);
			}

			if (playModeRoot != null)
			{
				playModeRoot.SetActive(false);
			}
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (resources != null && !(resources is ILevelEditorResources))
			{
				Debug.LogError("Resources needs to implement ILevelEditorResources!");
				resources = null;
			}
		}
#endif
	}
}