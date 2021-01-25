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

        private ILevelEditor levelEditor;
        private ILevelEditorSaveModal realSaveModal;
        private ILevelEditorLoadModal realLoadModal;
        private ILevelEditorNotificationModal realNotificationModal;
        private ILevelEditorInspector realInspectorPanel;
        private ILevelEditorResourceView realResourcePanel;
        private ILevelEditorHierarchy realHierarchy;
        private ILevelEditorColorPickerWindow realColorPickerWindow;

        public ILevelEditor LevelEditor { get { return levelEditor; } }
        public ILevelEditorSaveModal SaveModal { get { return realSaveModal; } }
        public ILevelEditorLoadModal LoadModal { get { return realLoadModal; } }
        public ILevelEditorNotificationModal NotificationModal { get { return realNotificationModal; } }
        public ILevelEditorInspector InspectorPanel { get { return realInspectorPanel; } }
        public ILevelEditorResourceView ResourcePanel { get { return realResourcePanel; } }
        public ILevelEditorHierarchy HierarchyPanel { get { return realHierarchy; } }
        public ILevelEditorColorPickerWindow ColorPickerWindow { get { return realColorPickerWindow; } }

        protected virtual void Awake()
        {
            realSaveModal = saveModal.NeedComponent<ILevelEditorSaveModal>();
            realLoadModal = loadModal.NeedComponent<ILevelEditorLoadModal>();
            realNotificationModal = notificationModal.NeedComponent<ILevelEditorNotificationModal>();
            realInspectorPanel = inspectorPanel.NeedComponent<ILevelEditorInspector>();
            realResourcePanel = resourcePanel.NeedComponent<ILevelEditorResourceView>();
            realHierarchy = hierarchyPanel.NeedComponent<ILevelEditorHierarchy>();
            realColorPickerWindow = colorPickerWindow.NeedComponent<ILevelEditorColorPickerWindow>();

            ToggleSaveModal(false);
            ToggleLoadModal(false);

            notificationModal.IfExists(x => x.gameObject.SetActive(false));
        }

        public void Initialize(ILevelEditor levelEditor)
        {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
            if (realSaveModal == null)
            {
                LevelEditorLogger.LogWarning("Stopped LevelEditorUGUI Initialize because no save modal.");
                return;
            }

            if (realLoadModal == null)
            {
                LevelEditorLogger.LogWarning("Stopped LevelEditorUGUI Initialize because no load modal.");
                return;
            }
#endif

            this.levelEditor = levelEditor;

            levelEditor.Selection.OnSelectionChanged += OnSelectionChanged;

            realInspectorPanel.Initialize(this);
            realHierarchy.Initialize(levelEditor);

            realSaveModal.Initialize();
            realLoadModal.Initialize();
        }

        private void OnDestroy()
        {
            if (levelEditor != null && levelEditor.Selection != null)
            {
                levelEditor.Selection.OnSelectionChanged -= OnSelectionChanged;
            }
        }

        public virtual void InitializeResources(ILevelEditorResource[] resources)
        {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
            if (realResourcePanel == null)
            {
                throw new NullReferenceException("InitializeResources failed. No project panel. Did you call this in Start? Did Awake on LevelEditorGUI complete?");
            }
#endif

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

            realSaveModal.OnClickSave += OnSavePanelClickSave;
            realSaveModal.OnClickClose += OnSavePanelClickClose;

            realLoadModal.OnClickLoadLevel += OnLoadPanelClickLoadLevel;
            realLoadModal.OnClickClose += OnLoadPanelClickClose;
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

            realSaveModal.OnClickSave -= OnSavePanelClickSave;
            realSaveModal.OnClickClose -= OnSavePanelClickClose;

            realLoadModal.OnClickLoadLevel -= OnLoadPanelClickLoadLevel;
            realLoadModal.OnClickClose -= OnLoadPanelClickClose;
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
            saveModal.SetActive(toggle);
            UpdateModalBackground();
        }

        public virtual void ToggleLoadModal(bool toggle)
        {
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

        private void OnSelectionChanged(object sender, SelectionEvent e)
        {
            InspectorPanel.BindObject(e.NewObject);
        }
    }
}
