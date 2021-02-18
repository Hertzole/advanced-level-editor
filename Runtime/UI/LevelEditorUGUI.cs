using System;
using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
    [AddComponentMenu("ALE/UI/uGUI/Level Editor uGUI", 0)]
#endif
    public class LevelEditorUGUI : MonoBehaviour, ILevelEditorUI
    {
        [SerializeField]
        private GameObject editorRoot = null;
        [SerializeField]
        private GameObject playModeRoot = null;

        [Header("Panels")]
        [SerializeField, RequireType(typeof(ILevelEditorResourceView))]
        private GameObject resourcePanel = null;
        [SerializeField, RequireType(typeof(ILevelEditorInspector))]
        private GameObject inspectorPanel = null;
        [SerializeField, RequireType(typeof(ILevelEditorHierarchy))]
        private GameObject hierarchyPanel = null;

        [Header("Modals")]
        [SerializeField]
        private GameObject modalsBackground = null;
        [SerializeField, RequireType(typeof(ILevelEditorSaveModal))]
        private GameObject saveModal = null;
        [SerializeField, RequireType(typeof(ILevelEditorLoadModal))]
        private GameObject loadModal = null;
        [SerializeField, RequireType(typeof(ILevelEditorNotificationModal))]
        private GameObject notificationModal = null;

        [Header("Windows")]
        [SerializeField]
        [RequireType(typeof(ILevelEditorColorPickerWindow))]
        private GameObject colorPickerWindow = null;
        [SerializeField]
        [RequireType(typeof(ILevelEditorObjectPickerWindow))]
        private GameObject objectPickerWindow = null;

        private ILevelEditor levelEditor;
        private ILevelEditorSaveModal realSaveModal;
        private ILevelEditorLoadModal realLoadModal;
        private ILevelEditorNotificationModal realNotificationModal;
        private ILevelEditorInspector realInspectorPanel;
        private ILevelEditorResourceView realResourcePanel;
        private ILevelEditorHierarchy realHierarchy;
        private ILevelEditorColorPickerWindow realColorPickerWindow;
        private ILevelEditorObjectPickerWindow realObjectPickerWindow;

        public ILevelEditor LevelEditor { get { return levelEditor; } }
        public ILevelEditorSaveModal SaveModal { get { return realSaveModal; } }
        public ILevelEditorLoadModal LoadModal { get { return realLoadModal; } }
        public ILevelEditorNotificationModal NotificationModal { get { return realNotificationModal; } }
        public ILevelEditorInspector InspectorPanel { get { return realInspectorPanel; } }
        public ILevelEditorResourceView ResourcePanel { get { return realResourcePanel; } }
        public ILevelEditorHierarchy HierarchyPanel { get { return realHierarchy; } }
        public ILevelEditorColorPickerWindow ColorPickerWindow { get { return realColorPickerWindow; } }
        public ILevelEditorObjectPickerWindow ObjectPickerWindow { get { return realObjectPickerWindow; } }

        protected virtual void Awake()
        {
            if (saveModal != null)
            {
                realSaveModal = saveModal.NeedComponent<ILevelEditorSaveModal>();
            }

            if (loadModal != null)
            {
                realLoadModal = loadModal.NeedComponent<ILevelEditorLoadModal>();
            }

            if (notificationModal != null)
            {
                realNotificationModal = notificationModal.NeedComponent<ILevelEditorNotificationModal>();
            }

            if (inspectorPanel != null)
            {
                realInspectorPanel = inspectorPanel.NeedComponent<ILevelEditorInspector>();
            }

            if (resourcePanel != null)
            {
                realResourcePanel = resourcePanel.NeedComponent<ILevelEditorResourceView>();
            }
            if (hierarchyPanel != null)
            {
                realHierarchy = hierarchyPanel.NeedComponent<ILevelEditorHierarchy>();
            }
            if (colorPickerWindow != null)
            {
                realColorPickerWindow = colorPickerWindow.NeedComponent<ILevelEditorColorPickerWindow>();
            }
            if (objectPickerWindow != null)
            {
                realObjectPickerWindow = objectPickerWindow.NeedComponent<ILevelEditorObjectPickerWindow>();
            }

            ToggleSaveModal(false);
            ToggleLoadModal(false);

            if (!ReferenceEquals(notificationModal, null))
            {
                notificationModal.SetActive(false);
            }

            if (!ReferenceEquals(colorPickerWindow, null))
            {
                colorPickerWindow.SetActive(false);
            }

            if (!ReferenceEquals(objectPickerWindow, null))
            {
                objectPickerWindow.SetActive(false);
            }
        }

        public void Initialize(ILevelEditor levelEditor)
        {
            this.levelEditor = levelEditor;

            if (!ReferenceEquals(levelEditor.Selection, null))
            {
                levelEditor.Selection.OnSelectionChanged += OnSelectionChanged;
            }

            if (!ReferenceEquals(realInspectorPanel, null))
            {
                realInspectorPanel.Initialize(this);
            }

            if (!ReferenceEquals(realHierarchy, null))
            {
                realHierarchy.Initialize(levelEditor);
            }

            if (!ReferenceEquals(realSaveModal, null))
            {
                realSaveModal.Initialize();
            }

            if (!ReferenceEquals(realLoadModal, null))
            {
                realLoadModal.Initialize();
            }

            if (!ReferenceEquals(realObjectPickerWindow, null))
            {
                realObjectPickerWindow.Initialize(levelEditor);
            }

            OnInitialize();
        }

        protected virtual void OnInitialize() { }

        private void OnDestroy()
        {
            if (levelEditor != null && levelEditor.Selection != null)
            {
                levelEditor.Selection.OnSelectionChanged -= OnSelectionChanged;
            }
        }

        public virtual void InitializeResources(ILevelEditorResource[] resources)
        {
            if (ReferenceEquals(null, realResourcePanel))
            {
                return;
            }

            realResourcePanel.Initialize(resources);
        }

        protected virtual void OnEnable()
        {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
            if (realSaveModal == null)
            {
                LevelEditorLogger.LogWarning("Stopped LevelEditorUGUI OnEnable because no save modal.");
                return;
            }

            if (realLoadModal == null)
            {
                LevelEditorLogger.LogWarning("Stopped LevelEditorUGUI OnEnable because no load modal.");
                return;
            }
#endif

            if (!ReferenceEquals(null, realSaveModal))
            {
                realSaveModal.OnClickSave += OnSavePanelClickSave;
                realSaveModal.OnClickClose += OnSavePanelClickClose;
            }

            if (!ReferenceEquals(null, realLoadModal))
            {
                realLoadModal.OnClickLoadLevel += OnLoadPanelClickLoadLevel;
                realLoadModal.OnClickClose += OnLoadPanelClickClose;
            }
        }

        protected virtual void OnDisable()
        {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
            if (realSaveModal == null)
            {
                LevelEditorLogger.LogWarning("Stopped LevelEditorUGUI OnDisable because no save modal.");
                return;
            }

            if (realLoadModal == null)
            {
                LevelEditorLogger.LogWarning("Stopped LevelEditorUGUI OnDisable because no load modal.");
                return;
            }
#endif

            if (!ReferenceEquals(null, realSaveModal))
            {
                realSaveModal.OnClickSave -= OnSavePanelClickSave;
                realSaveModal.OnClickClose -= OnSavePanelClickClose;
            }

            if (!ReferenceEquals(null, realLoadModal))
            {
                realLoadModal.OnClickLoadLevel -= OnLoadPanelClickLoadLevel;
                realLoadModal.OnClickClose -= OnLoadPanelClickClose;
            }
        }

        private void OnSavePanelClickSave(string levelName)
        {
            levelEditor.SaveManager.SaveLevel(levelName);
        }

        private void OnSavePanelClickClose()
        {
            ToggleSaveModal(false);
        }

        private void OnLoadPanelClickLoadLevel(string levelPath)
        {
            levelEditor.SaveManager.LoadLevel(levelPath);
        }

        private void OnLoadPanelClickClose()
        {
            ToggleLoadModal(false);
        }

        private void ClickNewLevel()
        {
            if (levelEditor.IsDirty)
            {
                ShowNotification("Notice!", "All your unsaved changes will be lost.\nAre you sure you want to create a new level?", "Yes", "No", ConfirmNewLevel, CloseNotification);
            }
        }

        private void ConfirmNewLevel()
        {
            levelEditor.NewLevel();
            CloseNotification();
        }

        private void ClickPlayLevel()
        {
            if (!levelEditor.StartPlayMode(out string failReason))
            {
                ShowNotification("Error", failReason, "OK", string.Empty, CloseNotification, null);
            }
        }

        public virtual void ToggleResourcePanel(bool toggle)
        {
            if (resourcePanel != null)
            {
                resourcePanel.SetActive(toggle);
            }
        }

        public virtual void ToggleSaveModal(bool toggle)
        {
            if (ReferenceEquals(null, saveModal))
            {
                return;
            }

            saveModal.SetActive(toggle);
            UpdateModalBackground();
        }

        public virtual void ToggleLoadModal(bool toggle)
        {
            if (ReferenceEquals(null, loadModal))
            {
                return;
            }

            if (toggle)
            {
                realLoadModal.PopulateLevels(levelEditor.SaveManager.GetLevels());
            }
            loadModal.SetActive(toggle);
            UpdateModalBackground();
        }

        protected virtual void UpdateModalBackground()
        {
            modalsBackground.IfExists(x => x.SetActive(saveModal.activeSelf || loadModal.activeSelf));
        }

        public virtual void ToggleInspectorPanel(bool toggle)
        {
            inspectorPanel.SetActive(toggle);
        }

        public virtual void ShowNotification(string title, string text, string yesButton, string noButton, Action onClickYes, Action onClickNo)
        {
            realNotificationModal.Show(title, text, yesButton, noButton, onClickYes, onClickNo);
            notificationModal.gameObject.SetActive(true);
        }

        public virtual void CloseNotification()
        {
            notificationModal.gameObject.SetActive(false);
        }

        public virtual void OnPlayModeStart()
        {
            editorRoot.IfExists(x => x.SetActive(false));
            playModeRoot.IfExists(x => x.SetActive(true));
        }

        public virtual void OnPlayModeStop()
        {
            editorRoot.IfExists(x => x.SetActive(true));
            playModeRoot.IfExists(x => x.SetActive(false));
        }

        protected virtual void OnSelectionChanged(object sender, SelectionEvent e)
        {
            if (realInspectorPanel != null)
            {
                realInspectorPanel.BindObject(e.NewObject);
            }
        }
    }
}
