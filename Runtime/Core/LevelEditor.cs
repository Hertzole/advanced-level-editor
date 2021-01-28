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
        private ScriptableObject resources = null;

        [Space]

        [SerializeField, RequireType(typeof(ILevelEditorCamera))]
        private GameObject editorCamera = null;
        [SerializeField, RequireType(typeof(ILevelEditorUI))]
        private GameObject ui = null;
        [SerializeField, RequireType(typeof(ILevelEditorSaveManager))]
        private GameObject saveManager = null;
        [SerializeField, RequireType(typeof(ILevelEditorObjectManager))]
        private GameObject objectManager = null;
        [SerializeField, RequireType(typeof(ILevelEditorInput))]
        private GameObject input = null;
        [SerializeField, RequireType(typeof(ILevelEditorSelection))]
        private GameObject selection = null;
        [SerializeField, RequireType(typeof(ILevelEditorPlayMode))]
        private GameObject playMode = null;

        [Space]

        [SerializeField]
        private LevelEditorSnapping snapSettings = new LevelEditorSnapping(true, true, true);

        private bool isDirty = false;

        private int selectedMode = -1;

        private ILevelEditorMode[] editorModes;

        private ILevelEditorResources realResources;
        private ILevelEditorCamera editorCameraComp;
        private ILevelEditorUI uiComp;
        private ILevelEditorSaveManager saveManagerComp;
        private ILevelEditorObjectManager objectManagerComp;
        private ILevelEditorPlayMode playModeComp;
        private ILevelEditorInput inputComp;
        private ILevelEditorSelection selectionComp;

        public ILevelEditorSnapping Snapping { get { return snapSettings; } }
        public ILevelEditorCamera LevelEditorCamera { get { return editorCameraComp; } }
        public ILevelEditorUI UI { get { return uiComp; } }
        public ILevelEditorSaveManager SaveManager { get { return saveManagerComp; } }
        public ILevelEditorObjectManager ObjectManager { get { return objectManagerComp; } }
        public ILevelEditorPlayMode PlayMode { get { return playModeComp; } }
        public ILevelEditorInput Input { get { return inputComp; } }
        public ILevelEditorSelection Selection { get { return selectionComp; } }

        public bool IsDirty { get { return isDirty; } }

        private void Awake()
        {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
            if (!resources.ExistsAndImplements<ILevelEditorResources>(nameof(resources), this))
            {
                return;
            }
#endif

            realResources = resources as ILevelEditorResources;
            editorCameraComp = editorCamera.NeedComponent<ILevelEditorCamera>();
            uiComp = ui.NeedComponent<ILevelEditorUI>();
            saveManagerComp = saveManager.NeedComponent<ILevelEditorSaveManager>();
            objectManagerComp = objectManager.NeedComponent<ILevelEditorObjectManager>();
            inputComp = input.NeedComponent<ILevelEditorInput>();
            selectionComp = selection.NeedComponent<ILevelEditorSelection>();
            if (playMode != null) // Play mode is not required.
            {
                playModeComp = playMode.NeedComponent<ILevelEditorPlayMode>();
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
#if DEBUG
            if (uiComp == null)
            {
                LevelEditorLogger.DebugLogError("LevelEditor Start stopped because there's no ILevelEditorUI assigned.");
                return;
            }

            if (resources == null)
            {
                LevelEditorLogger.DebugLogError("LevelEditor Start stopped because there's no ILevelEditorResources assigned.");
                return;
            }
#endif

            uiComp.Initialize(this);
            uiComp.InitializeResources(realResources.GetResources());

            if (editorModes != null && editorModes.Length > 0)
            {
                for (int i = 0; i < editorModes.Length; i++)
                {
                    editorModes[i].OnModeDisable();
                }

                SetMode(0);
            }
            else
            {
                LevelEditorLogger.DebugLogError("There are no editor mode components (Extends LevelEditorMode or implements ILevelEditorMode) attached on the level editor object. At least one must be present to function.");
            }
        }

        private void OnEnable()
        {
#if DEBUG
            if (objectManagerComp == null)
            {
                LevelEditorLogger.LogError("LevelEditor OnEnable stopped because no object manager.");
                return;
            }
#endif

            objectManagerComp.OnCreatedObject += OnCreateDeleteObject;

            if (playModeComp != null)
            {
                playModeComp.OnStartPlayMode += OnStartPlayMode;
                playModeComp.OnStopPlayMode += OnStopPlayMode;
            }
        }

        private void OnDisable()
        {
#if DEBUG
            if (objectManagerComp == null)
            {
                LevelEditorLogger.LogError("LevelEditor OnDisable stopped because no object manager.");
                return;
            }
#endif

            objectManagerComp.OnCreatedObject -= OnCreateDeleteObject;

            if (playModeComp != null)
            {
                playModeComp.OnStartPlayMode -= OnStartPlayMode;
                playModeComp.OnStopPlayMode -= OnStopPlayMode;
            }
        }

        private void Update()
        {
            //if (Keyboard.current != null && editorModes != null && editorModes.Length > 0)
            //{
            //    if (Keyboard.current.digit1Key.wasPressedThisFrame)
            //    {
            //        if (editorModes.Length > 0)
            //        {
            //            SetMode(0);
            //        }
            //    }

            //    if (Keyboard.current.digit2Key.wasPressedThisFrame)
            //    {
            //        if (editorModes.Length > 1)
            //        {
            //            SetMode(1);
            //        }
            //    }

            //    if (Keyboard.current.digit3Key.wasPressedThisFrame)
            //    {
            //        if (editorModes.Length > 2)
            //        {
            //            SetMode(2);
            //        }
            //    }
            //}

            if (selectedMode >= 0 && playModeComp.IfElse((x) => !x.IsPlaying, () => true))
            {
                editorModes[selectedMode].OnModeUpdate();
            }
        }

        public void SetMode(int newMode, bool returnOnOutOfRange = true)
        {
            if (newMode < 0)
            {
                if (returnOnOutOfRange)
                {
                    return;
                }

                newMode = 0;
            }
            else if (newMode >= editorModes.Length)
            {
                if (returnOnOutOfRange)
                {
                    return;
                }

                newMode = editorModes.Length - 1;
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

        public void NewLevel()
        {
            objectManagerComp.DeleteAllObjects();
            objectManagerComp.ResetInstanceID();
            isDirty = false;
            UI.InspectorPanel.BindObject(null);
        }

        public void MarkDirty()
        {
            isDirty = true;
        }

        public bool StartPlayMode(out string failReason)
        {
#if DEBUG
            if (playModeComp == null)
            {
                Debug.LogError("There's no play mode assigned on the level editor. Play mode can not be started. " +
                    "This will not be caught in release! Remove play mode functionality from your level editor.");
                failReason = "Play mode is not supported.";
                return false;
            }
#endif

            if (!playModeComp.CanStartPlayMode(out failReason))
            {
                return false;
            }

            playModeComp.StartPlayMode(true);
            return true;
        }

        public bool StopPlayMode(out string failReason)
        {
#if DEBUG
            if (playModeComp == null)
            {
                Debug.LogError("There's no play mode assigned on the level editor. Play mode can not be stopped. " +
                    "This will not be caught in release! Remove play mode functionality from your level editor.");
                failReason = "Play mode is not supported.";
                return false;
            }
#endif

            if (!playModeComp.CanStopPlayMode(out failReason))
            {
                return false;
            }

            playModeComp.StopPlayMode(true);
            return true;
        }

        private void OnCreateDeleteObject(object sender, LevelEditorObjectEvent args)
        {
            MarkDirty();
        }

        private void OnStartPlayMode()
        {
            uiComp.OnPlayModeStart();
            editorModes[selectedMode].OnModeDisable();
        }

        private void OnStopPlayMode()
        {
            uiComp.OnPlayModeStop();
            editorModes[selectedMode].OnModeEnable();
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
            if (!resources.ExistsAndImplements<ILevelEditorResources>(nameof(resources), this, false))
            {
                resources = null;
            }
        }
#endif
    }
}
