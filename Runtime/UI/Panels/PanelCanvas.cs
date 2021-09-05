﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PanelManager))]
    public class PanelCanvas : MonoBehaviour, IPointerEnterHandler, ISerializationCallbackReceiver
    {
        public class InternalSettings
        {
            private readonly PanelCanvas canvas;
            public readonly Camera worldCamera;

            public InternalSettings(PanelCanvas canvas)
            {
                this.canvas = canvas;

#if UNITY_EDITOR
                if (!canvas.UnityCanvas) // is null while inspecting this component in edit mode
                {
                    return;
                }
#endif

                if (canvas.UnityCanvas.renderMode == RenderMode.ScreenSpaceOverlay ||
                    (canvas.UnityCanvas.renderMode == RenderMode.ScreenSpaceCamera && !canvas.UnityCanvas.worldCamera))
                {
                    worldCamera = null;
                }
                else
                {
                    worldCamera = canvas.UnityCanvas.worldCamera ? canvas.UnityCanvas.worldCamera : Camera.main;
                }
            }

            public Panel DummyPanel { get { return canvas.dummyPanel; } }

            public List<PanelProperties> InitialPanelsUnanchored
            {
                get
                {
                    if (canvas.initialPanelsUnanchored == null)
                    {
                        canvas.initialPanelsUnanchored = new List<PanelProperties>();
                    }

                    return canvas.initialPanelsUnanchored;
                }
            }

            public AnchoredPanelProperties InitialPanelsAnchored
            {
                get
                {
                    if (canvas.initialPanelsAnchored == null)
                    {
                        canvas.initialPanelsAnchored = new AnchoredPanelProperties();
                    }

                    return canvas.initialPanelsAnchored;
                }
            }

            public bool IsLastDockedPanel(Panel panel)
            {
                return panel.IsDocked && !PanelGroupHasAnyOtherPanels(canvas.RootPanelGroup, panel);
            }

            private bool PanelGroupHasAnyOtherPanels(PanelGroup group, Panel panel)
            {
                for (int i = 0; i < group.Count; i++)
                {
                    if (group[i] is Panel _panel)
                    {
                        if (_panel != panel && _panel != canvas.dummyPanel)
                        {
                            return true;
                        }
                    }
                    else if (PanelGroupHasAnyOtherPanels((PanelGroup)group[i], panel))
                    {
                        return true;
                    }
                }

                return false;
            }

            public void AnchorZonesSetActive(bool value) { canvas.AnchorZonesSetActive(value); }
            public void ReceiveRaycasts(bool value) { canvas.background.raycastTarget = value; }
            public void OnApplicationQuit() { canvas.OnApplicationQuit(); }
        }

        [System.Serializable]
        public class PanelProperties
        {
            public List<PanelTabProperties> tabs = new List<PanelTabProperties>();
        }

        public class AnchoredPanelProperties
        {
            public PanelProperties panel = new PanelProperties();
            public PanelDirection anchorDirection;
            public Vector2 initialSize;

            public List<AnchoredPanelProperties> subPanels = new List<AnchoredPanelProperties>();
        }

        // Credit: https://docs.unity3d.com/Manual/script-Serialization-Custom.html
        [System.Serializable]
        public struct SerializableAnchoredPanelProperties
        {
            public PanelProperties panel;
            public PanelDirection anchorDirection;
            public Vector2 initialSize;

            public int childCount;
            public int indexOfFirstChild;
        }

        [System.Serializable]
        public class PanelTabProperties : ISerializationCallbackReceiver
        {
            public RectTransform content = null;
            public string id = null;
            public Vector2 minimumSize = new Vector2(250f, 300f);

            public string tabLabel = "Panel";
            public Sprite tabIcon = null;

            void ISerializationCallbackReceiver.OnBeforeSerialize()
            {
                if (string.IsNullOrEmpty(id))
                {
                    id = System.Guid.NewGuid().ToString();
                }
            }

            void ISerializationCallbackReceiver.OnAfterDeserialize()
            {
            }
        }

        public RectTransform RectTransform { get; private set; }
        public Canvas UnityCanvas { get; private set; }

#if UNITY_EDITOR
        private InternalSettings m_internal;
        public InternalSettings Internal
        {
            get
            {
                if (m_internal == null)
                {
                    m_internal = new InternalSettings(this);
                }

                return m_internal;
            }
        }
#else
		public InternalSettings Internal { get; private set; }
#endif

        [SerializeField]
        [HideInInspector]
        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public UnanchoredPanelGroup UnanchoredPanelGroup { get; private set; }
        public PanelGroup RootPanelGroup { get; private set; }

        public Vector2 Size { get; private set; }

        private Panel dummyPanel;
        private Graphic background;

        private RectTransform anchorZonesParent;
        private readonly CanvasAnchorZone[] anchorZones = new CanvasAnchorZone[4]; // one for each side

        [SerializeField]
        private Panel panelPrefab = null;
        public Panel PanelPrefab { get { return panelPrefab; } set { panelPrefab = value; } }
        [SerializeField]
        private bool leaveFreeSpace = true;
        public bool LeaveFreeSpace
        {
            get { return leaveFreeSpace; }
            set
            {
                leaveFreeSpace = value;
                if (!leaveFreeSpace)
                {
                    dummyPanel.Detach();
                }
                else if (!dummyPanel.IsDocked)
                {
                    // Add the free space to the middle
                    if (RootPanelGroup.Count <= 1)
                    {
                        RootPanelGroup.AddElement(dummyPanel);
                    }
                    else
                    {
                        RootPanelGroup.AddElementBefore(RootPanelGroup[RootPanelGroup.Count / 2], dummyPanel);
                    }
                }
            }
        }

        [SerializeField]
        private Vector2 minimumFreeSpace = new Vector2(50f, 50f);
        [SerializeField]
        private bool preventDetachingLastDockedPanel = false;

        public bool PreventDetachingLastDockedPanel { get { return preventDetachingLastDockedPanel; } set { preventDetachingLastDockedPanel = value; } }

        [SerializeField]
        private float panelResizableAreaLength = 12f;
        public float PanelResizableAreaLength { get { return panelResizableAreaLength; } }

        [SerializeField]
        private float canvasAnchorZoneLength = 20f;
        public float CanvasAnchorZoneLength { get { return canvasAnchorZoneLength; } }

        [SerializeField]
        private float panelAnchorZoneLength = 100f;
        public float PanelAnchorZoneLength { get { return panelAnchorZoneLength; } }

        private const float PANEL_ANCHOR_ZONE_LENGTH_RATIO = 0.31f;
        public float PanelAnchorZoneLengthRatio { get { return PANEL_ANCHOR_ZONE_LENGTH_RATIO; } }

        [SerializeField]
        private List<PanelProperties> initialPanelsUnanchored = new List<PanelProperties>();

        [SerializeField]
        [HideInInspector]
        private List<SerializableAnchoredPanelProperties> initialPanelsAnchoredSerialized = new List<SerializableAnchoredPanelProperties>();
        private AnchoredPanelProperties initialPanelsAnchored;

        private bool updateBounds = true;
        private bool isDirty = false;

        private bool isQuitting = false;

        private void Awake()
        {
            RectTransform = (RectTransform)transform;
            UnityCanvas = GetComponentInParent<Canvas>();
#if !UNITY_EDITOR
			Internal = new InternalSettings( this );
#endif

            UnanchoredPanelGroup = new UnanchoredPanelGroup(this);
            RectTransform.ChangePivotWithoutAffectingPosition(new Vector2(0.5f, 0.5f));

            //if (!GetComponent<RectMask2D>())
            //{
            //    gameObject.AddComponent<RectMask2D>();
            //}

            Size = RectTransform.rect.size;

            InitializeRootGroup();
            InitializeAnchorZones();

            background = GetComponent<Graphic>();
            if (!background)
            {
                background = gameObject.AddComponent<NonDrawingGraphic>();
                background.raycastTarget = false;
            }

            PanelManager.Instance.RegisterCanvas(this);
        }

        private void Start()
        {
            Size = RectTransform.rect.size;

            HashSet<Transform> createdTabs = new HashSet<Transform>(); // A set to prevent duplicate tabs or to prevent making canvas itself a panel
            Transform tr = transform;
            while (tr)
            {
                createdTabs.Add(tr);
                tr = tr.parent;
            }

            Dictionary<Panel, Vector2> initialSizes = null;
            if (initialPanelsAnchored != null)
            {
                initialSizes = new Dictionary<Panel, Vector2>(initialPanelsAnchoredSerialized.Count);
                CreateAnchoredPanelsRecursively(initialPanelsAnchored.subPanels, dummyPanel, createdTabs, initialSizes);
            }

            for (int i = 0; i < initialPanelsUnanchored.Count; i++)
            {
                CreateInitialPanel(initialPanelsUnanchored[i], null, PanelDirection.None, createdTabs);
            }

            initialPanelsUnanchored = null;
            initialPanelsAnchored = null;
            initialPanelsAnchoredSerialized = null;

            LeaveFreeSpace = leaveFreeSpace;
            LateUpdate(); // Update layout

            if (leaveFreeSpace)
            {
                // Minimize all panels to their minimum size
                dummyPanel.ResizeTo(new Vector2(99999f, 99999f));
            }

            if (initialSizes != null)
            {
                ResizeAnchoredPanelsRecursively(RootPanelGroup, initialSizes);
            }
        }

        private void OnDestroy()
        {
            if (!isQuitting)
            {
                PanelManager.Instance.UnregisterCanvas(this);
            }
        }

        private void OnApplicationQuit()
        {
            isQuitting = true;
        }

        private void LateUpdate()
        {
            if (isDirty)
            {
                PanelManager.Instance.StopCanvasOperations(this);

                RootPanelGroup.Internal.UpdateLayout();
                UnanchoredPanelGroup.Internal.UpdateLayout();

                RootPanelGroup.Internal.UpdateSurroundings(null, null, null, null);
            }

            if (updateBounds)
            {
                UpdateBounds();
                updateBounds = false;
            }

            if (isDirty)
            {
                RootPanelGroup.Internal.EnsureMinimumSize();
                UnanchoredPanelGroup.Internal.EnsureMinimumSize();

                isDirty = false;
            }
        }

        public void SetDirty()
        {
            isDirty = true;
            updateBounds = true;
        }

        public void ForceRebuildLayoutImmediate()
        {
            LateUpdate();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            PanelManager.Instance.OnPointerEnteredCanvas(this, eventData);
        }

        private void OnRectTransformDimensionsChange()
        {
            updateBounds = true;
        }

        private void UpdateBounds()
        {
            Size = RectTransform.rect.size;

            RootPanelGroup.Internal.UpdateBounds(Vector2.zero, Size);
            UnanchoredPanelGroup.Internal.UpdateBounds(Vector2.zero, Size);
        }

        private void CreateAnchoredPanelsRecursively(List<AnchoredPanelProperties> anchoredPanels, Panel rootPanel, HashSet<Transform> createdTabs, Dictionary<Panel, Vector2> initialSizes)
        {
            if (anchoredPanels == null)
            {
                return;
            }

            for (int i = 0; i < anchoredPanels.Count; i++)
            {
                Panel panel = CreateInitialPanel(anchoredPanels[i].panel, rootPanel, anchoredPanels[i].anchorDirection, createdTabs);
                if (panel == null)
                {
                    panel = rootPanel;
                }
                else if (anchoredPanels[i].initialSize != Vector2.zero)
                {
                    initialSizes[panel] = anchoredPanels[i].initialSize;
                }

                CreateAnchoredPanelsRecursively(anchoredPanels[i].subPanels, panel, createdTabs, initialSizes);
            }
        }

        private void ResizeAnchoredPanelsRecursively(PanelGroup group, Dictionary<Panel, Vector2> initialSizes)
        {
            if (group == null)
            {
                return;
            }

            int count = group.Count;
            for (int i = 0; i < count; i++)
            {
                Panel panel = group[i] as Panel;
                if (panel != null)
                {
                    if (initialSizes.TryGetValue(panel, out Vector2 initialSize))
                    {
                        panel.ResizeTo(initialSize, PanelDirection.Right, PanelDirection.Top);
                    }
                }
                else
                {
                    ResizeAnchoredPanelsRecursively(group[i] as PanelGroup, initialSizes);
                }
            }
        }

        private Panel CreateInitialPanel(PanelProperties properties, Panel anchor, PanelDirection anchorDirection, HashSet<Transform> createdTabs)
        {
            Panel panel = null;
            for (int i = 0; i < properties.tabs.Count; i++)
            {
                PanelTabProperties panelProps = properties.tabs[i];
                if (panelProps.content)
                {
                    if (createdTabs.Contains(panelProps.content))
                    {
                        continue;
                    }

                    if (panelProps.content.parent != RectTransform)
                    {
                        panelProps.content.SetParent(RectTransform, false);
                    }

                    PanelTab tab;
                    if (panel == null)
                    {
                        panel = PanelUtils.CreatePanelFor(panelProps.content, this, panelPrefab);
                        tab = panel[0];
                    }
                    else
                    {
                        tab = panel.AddTab(panelProps.content);
                    }

                    tab.Icon = panelProps.tabIcon;
                    tab.Label = panelProps.tabLabel;
                    tab.MinSize = panelProps.minimumSize;
                    tab.ID = panelProps.id;

                    createdTabs.Add(panelProps.content);
                }
            }

            if (panel != null)
            {
                panel.ActiveTab = 0;

                if (anchor != null && anchorDirection != PanelDirection.None)
                {
                    panel.DockToPanel(anchor, anchorDirection);
                }
            }

            return panel;
        }

        private void InitializeRootGroup()
        {
            dummyPanel = PanelUtils.Internal.CreatePanel(null, this, panelPrefab);
            dummyPanel.gameObject.name = "DummyPanel";
            dummyPanel.CanvasGroup.alpha = 0f;
            dummyPanel.CanvasGroup.interactable = false;
            dummyPanel.CanvasGroup.blocksRaycasts = false;
            dummyPanel.Internal.SetDummy(minimumFreeSpace);

            RootPanelGroup = new PanelGroup(this, PanelDirection.Right);
            RootPanelGroup.AddElement(dummyPanel);
        }

        private void InitializeAnchorZones()
        {
            anchorZonesParent = (RectTransform)new GameObject("CanvasAnchorZone", typeof(RectTransform)).transform;
            anchorZonesParent.SetParent(RectTransform, false);
            anchorZonesParent.anchorMin = Vector2.zero;
            anchorZonesParent.anchorMax = Vector2.one;
            anchorZonesParent.sizeDelta = Vector2.zero;

            CreateAnchorZone(PanelDirection.Left, new Vector2(0f, 0f), new Vector2(0f, 1f), new Vector2(canvasAnchorZoneLength, 0f));
            CreateAnchorZone(PanelDirection.Top, new Vector2(0f, 1f), new Vector2(1f, 1f), new Vector2(0f, canvasAnchorZoneLength));
            CreateAnchorZone(PanelDirection.Right, new Vector2(1f, 0f), new Vector2(1f, 1f), new Vector2(canvasAnchorZoneLength, 0f));
            CreateAnchorZone(PanelDirection.Bottom, new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(0f, canvasAnchorZoneLength));

            for (int i = 0; i < anchorZones.Length; i++)
            {
                anchorZones[i].SetActive(false);
            }
        }

        private void CreateAnchorZone(PanelDirection direction, Vector2 anchorMin, Vector2 anchorMax, Vector2 sizeDelta)
        {
            CanvasAnchorZone anchorZone = new GameObject("AnchorZone" + direction, typeof(RectTransform)).AddComponent<CanvasAnchorZone>();
            anchorZone.Initialize(dummyPanel);
            anchorZone.SetDirection(direction);

            anchorZone.RectTransform.SetParent(anchorZonesParent, false);

            anchorZone.RectTransform.pivot = anchorMin;
            anchorZone.RectTransform.anchorMin = anchorMin;
            anchorZone.RectTransform.anchorMax = anchorMax;
            anchorZone.RectTransform.anchoredPosition = Vector2.zero;
            anchorZone.RectTransform.sizeDelta = sizeDelta;

            anchorZones[(int)direction] = anchorZone;
        }

        private void AnchorZonesSetActive(bool value)
        {
            if (!enabled)
            {
                return;
            }

            if (value)
            {
                anchorZonesParent.SetAsLastSibling();
            }

            for (int i = 0; i < anchorZones.Length; i++)
            {
                anchorZones[i].SetActive(value);
            }
        }

        [ContextMenu("Save Layout")]
        public void SaveLayout()
        {
            PanelSerialization.SerializeCanvas(this);
        }

        [ContextMenu("Load Layout")]
        public void LoadLayout()
        {
            PanelSerialization.DeserializeCanvas(this);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (initialPanelsAnchoredSerialized == null)
            {
                initialPanelsAnchoredSerialized = new List<SerializableAnchoredPanelProperties>();
            }
            else
            {
                initialPanelsAnchoredSerialized.Clear();
            }

            if (initialPanelsAnchored == null)
            {
                initialPanelsAnchored = new AnchoredPanelProperties();
            }

            if (string.IsNullOrEmpty(id))
            {
                id = System.Guid.NewGuid().ToString();
            }

            AddToSerializedAnchoredPanelProperties(initialPanelsAnchored);
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (initialPanelsAnchoredSerialized != null && initialPanelsAnchoredSerialized.Count > 0)
            {
                ReadFromSerializedAnchoredPanelProperties(0, out initialPanelsAnchored);
            }
            else
            {
                initialPanelsAnchored = new AnchoredPanelProperties();
            }
        }

        private void AddToSerializedAnchoredPanelProperties(AnchoredPanelProperties props)
        {
            SerializableAnchoredPanelProperties serializedProps = new SerializableAnchoredPanelProperties()
            {
                panel = props.panel,
                anchorDirection = props.anchorDirection,
                initialSize = props.initialSize,
                childCount = props.subPanels.Count,
                indexOfFirstChild = initialPanelsAnchoredSerialized.Count + 1
            };

            initialPanelsAnchoredSerialized.Add(serializedProps);
            for (int i = 0; i < props.subPanels.Count; i++)
            {
                AddToSerializedAnchoredPanelProperties(props.subPanels[i]);
            }
        }

        private int ReadFromSerializedAnchoredPanelProperties(int index, out AnchoredPanelProperties props)
        {
            SerializableAnchoredPanelProperties serializedProps = initialPanelsAnchoredSerialized[index];
            AnchoredPanelProperties newProps = new AnchoredPanelProperties()
            {
                panel = serializedProps.panel,
                anchorDirection = serializedProps.anchorDirection,
                initialSize = serializedProps.initialSize,
                subPanels = new List<AnchoredPanelProperties>()
            };

            for (int i = 0; i != serializedProps.childCount; i++)
            {
                index = ReadFromSerializedAnchoredPanelProperties(++index, out AnchoredPanelProperties childProps);
                newProps.subPanels.Add(childProps);
            }

            props = newProps;
            return index;
        }
    }
}
