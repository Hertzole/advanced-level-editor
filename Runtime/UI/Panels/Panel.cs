using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [DisallowMultipleComponent]
    public class Panel : MonoBehaviour, IPanelGroupElement
    {
        internal class InternalSettings
        {
            private readonly Panel panel;

            public InternalSettings(Panel panel)
            {
                this.panel = panel;
                BackgroundSprite = panel.GetComponent<Image>().sprite;
            }

            public PanelGroup Group { set { panel.Group = value; } }
            public ScrollRect ContentScrollRect { get { return panel.contentScrollRect; } }
            public RectTransform HighlightTransform { get { return panel.resizeZonesParent; } }
            public float HeaderHeight { get { return panel.headerHeight; } }
            public bool IsDummy { get; private set; }
            public PanelAnchorZone PanelAnchorZone { get { return panel.panelAnchorZone; } }
            public PanelHeaderAnchorZone HeaderAnchorZone { get { return panel.headerAnchorZone; } }
            public Sprite BackgroundSprite { get; private set; }

            public void SetDummy(Vector2 minSize)
            {
                if (!IsDummy)
                {
                    Destroy(panel.header.gameObject);
                    Destroy(panel.resizeZonesParent.gameObject);
                    Destroy(panel.contentParent.gameObject);
                    Destroy(panel.GetComponent<Graphic>());
                    Destroy(panel.headerAnchorZone.gameObject);

                    panel.header = null;
                    panel.resizeZonesParent = null;
                    panel.contentParent = null;
                    panel.headerAnchorZone = null;
                    panel.headerHeight = 0f;
                    panel.panelAnchorZone.RectTransform.sizeDelta = Vector2.zero;

                    panel.MinSize = minSize;
                    IsDummy = true;
                }
            }

            public void UpdateBounds(Vector2 position, Vector2 size)
            {
                panel.RectTransform.anchoredPosition = position;
                panel.RectTransform.sizeDelta = size;
            }

            public void UpdateSurroundings(IPanelGroupElement left, IPanelGroupElement top, IPanelGroupElement right, IPanelGroupElement bottom)
            {
                panel.surroundings[(int)PanelDirection.Left] = left;
                panel.surroundings[(int)PanelDirection.Top] = top;
                panel.surroundings[(int)PanelDirection.Right] = right;
                panel.surroundings[(int)PanelDirection.Bottom] = bottom;

                ValidateTabs();
            }

            public void ChangeCloseButtonVisibility(bool isVisible)
            {
                if (panel.closeButton && isVisible != panel.closeButton.gameObject.activeSelf)
                {
                    panel.closeButton.gameObject.SetActive(isVisible);

                    float panelHeaderPadding = ((RectTransform)panel.closeButton.transform).rect.width;
                    ((RectTransform)panel.header.transform).offsetMax += new Vector2(isVisible ? -panelHeaderPadding : panelHeaderPadding, 0f);
                }
            }

            public void ValidateTabs()
            {
                if (IsDummy)
                {
                    return;
                }

                if (panel.tabs.Count == 0)
                {
                    Destroy(panel.gameObject);
                }
                else
                {
                    for (int i = panel.tabs.Count - 1; i >= 0; i--)
                    {
                        if (!panel.tabs[i].Content || panel.tabs[i].Content.parent != panel.contentParent)
                        {
                            RemoveTab(i, true);
                        }
                    }
                }
            }

            public int GetTabIndexAt(PointerEventData pointer, out Vector2 tabPreviewRect) // x: position, y: size
            {
                int tabCount = panel.tabs.Count;
                if (tabCount == 0)
                {
                    tabPreviewRect = new Vector2(0f, panel.Size.x);
                    return 0;
                }

                RectTransformUtility.ScreenPointToLocalPointInRectangle(panel.tabsParent, pointer.position, panel.Canvas.Internal.worldCamera, out Vector2 touchPos);

                float tabPosition = 0f;
                for (int i = 0; i < tabCount; i++)
                {
                    float nextTabPosition = panel.tabs[i].Internal.rectTransform.anchoredPosition.x;
                    if (touchPos.x < nextTabPosition)
                    {
                        if (i > 0)
                        {
                            i--;
                        }

                        tabPreviewRect = new Vector2(tabPosition, panel.tabs[i].Internal.rectTransform.sizeDelta.x + 4f);
                        return i;
                    }

                    tabPosition = nextTabPosition;
                }

                float tabSize = panel.tabs[tabCount - 1].Internal.rectTransform.sizeDelta.x;
                if (!panel.tabs[tabCount - 1].Internal.IsBeingDetached && touchPos.x > tabPosition + tabSize * 0.66f)
                {
                    float remainingSize = panel.Size.x - tabPosition - tabSize;
                    if (remainingSize < 30f)
                    {
                        tabPreviewRect = new Vector2(tabPosition + tabSize * 0.5f, remainingSize + tabSize * 0.5f);
                    }
                    else if (remainingSize > tabSize)
                    {
                        tabPreviewRect = new Vector2(tabPosition + tabSize, tabSize);
                    }
                    else
                    {
                        tabPreviewRect = new Vector2(tabPosition + tabSize, remainingSize);
                    }

                    return tabCount;
                }

                tabPreviewRect = new Vector2(tabPosition, tabSize + 4f);
                return tabCount - 1;
            }

            public void RemoveTab(int tabIndex, bool destroyTabObject)
            {
                if (destroyTabObject)
                {
                    Destroy(panel.tabs[tabIndex].gameObject);
                }

                panel.tabs.RemoveAt(tabIndex);
                RecalculateMinSize();

                if (!IsDummy)
                {
                    if (panel.tabs.Count == 0)
                    {
                        Destroy(panel.gameObject);
                    }
                    else if (panel.ActiveTab == tabIndex)
                    {
                        panel.activeTab = -1;
                        panel.ActiveTab = 0;
                    }
                    else if (panel.ActiveTab > tabIndex)
                    {
                        panel.activeTab--;
                    }
                }
            }

            public void RecalculateMinSize()
            {
                panel.minSize = -Vector2.one;

                Vector2 minSize = Vector2.zero;
                for (int i = 0; i < panel.tabs.Count; i++)
                {
                    Vector2 tabMinSize = panel.tabs[i].MinSize;

                    if (tabMinSize.x > minSize.x)
                    {
                        minSize.x = tabMinSize.x;
                    }

                    if (tabMinSize.y > minSize.y)
                    {
                        minSize.y = tabMinSize.y;
                    }
                }

                minSize.y += panel.headerHeight;
                panel.MinSize = minSize;
            }

            public void Stop()
            {
                if (IsDummy)
                {
                    return;
                }

                panel.header.Stop();

                for (int i = 0; i < panel.tabs.Count; i++)
                {
                    panel.tabs[i].Internal.Stop();
                }

                for (int i = 0; i < panel.resizeZones.Length; i++)
                {
                    panel.resizeZones[i].Stop();
                }
            }

            public void AnchorZonesSetActive(bool value) { panel.AnchorZonesSetActive(value); }
            public void OnResize(PanelDirection direction, Vector2 screenPoint) { panel.OnResize(direction, screenPoint); }
            public void OnTranslate(Vector2 deltaPosition) { panel.OnTranslate(deltaPosition); }
            public void OnApplicationQuit() { panel.OnApplicationQuit(); }
        }

        public RectTransform RectTransform { get; private set; }
        public CanvasGroup CanvasGroup { get; private set; }

        public PanelCanvas Canvas { get { return Group.Canvas; } }
        public PanelGroup Group { get; private set; }

        internal InternalSettings Internal { get; private set; }

        [SerializeField]
        private PanelTab tabPrefab = null;
        [SerializeField]
        private PanelHeader header = null;

        [SerializeField]
        private RectTransform tabsParent = null;
        private readonly List<PanelTab> tabs = new List<PanelTab>();

        [SerializeField]
        private RectTransform contentParent = null;

        [SerializeField]
        private Button closeButton = null;

        private RectTransform resizeZonesParent;
        private readonly PanelResizeHelper[] resizeZones = new PanelResizeHelper[4]; // one for each side

        private readonly IPanelGroupElement[] surroundings = new IPanelGroupElement[4]; // one for each side

        private PanelAnchorZone panelAnchorZone;
        private PanelHeaderAnchorZone headerAnchorZone;

        [SerializeField]
        private float headerHeight = 50f;

        [SerializeField]
        private Color tabNormalColor = Color.white;
        public Color TabNormalColor { get { return tabNormalColor; } }

        [SerializeField]
        private Color tabNormalTextColor = Color.white;
        public Color TabNormalTextColor { get { return tabNormalTextColor; } }

        [SerializeField]
        private Color tabSelectedColor = Color.white;
        public Color TabSelectedColor { get { return tabSelectedColor; } }

        [SerializeField]
        private Color tabSelectedTextColor = Color.white;
        public Color TabSelectedTextColor { get { return tabSelectedTextColor; } }

        [SerializeField]
        private Color tabDetachingColor = Color.white;
        public Color TabDetachingColor { get { return tabDetachingColor; } }

        [SerializeField]
        private Color tabDetachingTextColor = Color.white;
        public Color TabDetachingTextColor { get { return tabDetachingTextColor; } }

        public Vector2 Position { get { return RectTransform.anchoredPosition; } }
        public Vector2 Size { get { return RectTransform.sizeDelta; } }

        private Vector2 minSize = new Vector2(200f, 200f);
        public Vector2 MinSize
        {
            get { return minSize; }
            private set
            {
                if (minSize != value)
                {
                    minSize = value;
                    Group.Internal.SetDirty();
                }
            }
        }

        private Vector2 floatingSize;
        public Vector2 FloatingSize
        {
            get { return floatingSize; }
            set
            {
                if (floatingSize != value)
                {
                    floatingSize = value;

                    if (floatingSize.x < minSize.x)
                    {
                        floatingSize.x = minSize.x;
                    }

                    if (floatingSize.y < minSize.y)
                    {
                        floatingSize.y = minSize.y;
                    }

                    if (!IsDocked && RectTransform.sizeDelta != floatingSize)
                    {
                        RectTransform.sizeDelta = floatingSize;
                        ((UnanchoredPanelGroup)Group).RestrictPanelToBounds(this);
                    }
                }
            }
        }

        public int NumberOfTabs { get { return tabs.Count; } }
        public PanelTab this[int tabIndex]
        {
            get
            {
                if (tabIndex >= 0 && tabIndex < tabs.Count)
                {
                    return tabs[tabIndex];
                }

                return null;
            }
            set
            {
                if (value)
                {
                    AddTab(value.Content, tabIndex);
                }
            }
        }

        private int activeTab = -1;
        public int ActiveTab
        {
            get { return activeTab; }
            set
            {
                if (activeTab != value && value >= 0 && value < tabs.Count)
                {
                    if (activeTab >= 0 && activeTab < tabs.Count)
                    {
                        tabs[activeTab].Internal.SetActive(false);
                    }

                    activeTab = value;
                    tabs[activeTab].Internal.SetActive(true);

                    contentScrollRect = tabs[activeTab].Content.GetComponentInChildren<ScrollRect>();

                    PanelNotificationCenter.Internal.ActiveTabChanged(tabs[activeTab]);
                }
            }
        }

        public bool IsDocked { get { return !(Group is UnanchoredPanelGroup); } }

        private ScrollRect contentScrollRect;
        private bool isQuitting = false;

        private void Awake()
        {
            RectTransform = (RectTransform)transform;
            CanvasGroup = GetComponent<CanvasGroup>();
            Internal = new InternalSettings(this);

            RectTransform.anchorMin = Vector2.zero;
            RectTransform.anchorMax = Vector2.zero;
            RectTransform.pivot = Vector2.zero;

            PanelManager.Instance.RegisterPanel(this);

            InitializeResizeZones();
            InitializeAnchorZone();

            AnchorZonesSetActive(false);

            if (closeButton != null)
            {
                closeButton.onClick.AddListener(() => PanelNotificationCenter.Internal.PanelClosed(this));
                closeButton.transform.SetAsLastSibling();
            }
        }

        private void Start()
        {
            if (!Internal.IsDummy)
            {
                PanelNotificationCenter.Internal.PanelCreated(this);
            }
        }

        private void OnEnable()
        {
            if (Group is UnanchoredPanelGroup unanchoredGroup)
            {
                unanchoredGroup.RestrictPanelToBounds(this);
                RectTransform.SetAsLastSibling();
            }

            if (!Internal.IsDummy)
            {
                PanelNotificationCenter.Internal.PanelBecameActive(this);
            }
        }

        private void OnDisable()
        {
            if (Group != null && Canvas.gameObject.activeInHierarchy)
            {
                Canvas.UnanchoredPanelGroup.AddElement(this);
            }

            if (!Internal.IsDummy)
            {
                PanelNotificationCenter.Internal.PanelBecameInactive(this);
            }
        }

        private void OnDestroy()
        {
            if (!isQuitting)
            {
                PanelManager.Instance.UnregisterPanel(this);

                if (!Internal.IsDummy)
                {
                    PanelNotificationCenter.Internal.PanelDestroyed(this);
                }
            }
        }

        private void OnApplicationQuit()
        {
            isQuitting = true;
        }

        public PanelTab AddTab(RectTransform tabContent, int tabIndex = -1)
        {
            if (!tabContent)
            {
                return null;
            }

            // Reset active tab because otherwise, it acts buggy in rare cases
            if (activeTab >= 0 && activeTab < tabs.Count)
            {
                tabs[activeTab].Internal.SetActive(false);
            }

            activeTab = -1;

            if (tabIndex < 0 || tabIndex > tabs.Count)
            {
                tabIndex = tabs.Count;
            }

            int thisTabIndex = GetTabIndex(tabContent);
            if (thisTabIndex == -1)
            {
                PanelTab tab = PanelUtils.GetAssociatedTab(tabContent);
                if (!tab)
                {
                    tab = Instantiate(tabPrefab, tabsParent, false);
                    tabs.Insert(tabIndex, tab);

                    tabContent.anchorMin = Vector2.zero;
                    tabContent.anchorMax = Vector2.one;
                    tabContent.sizeDelta = Vector2.zero;
                    tabContent.anchoredPosition = Vector2.zero;
                    tabContent.localScale = Vector3.one;
                }
                else
                {
                    tabs.Insert(tabIndex, tab);

                    tab.Internal.rectTransform.SetParent(null, false); // workaround for a rare internal Unity crash
                    tab.Internal.rectTransform.SetParent(tabsParent, false);

                    tab.Panel.Internal.RemoveTab(tab.Index, false);
                }

                tab.Internal.Initialize(this, tabContent);
                tab.Internal.rectTransform.SetSiblingIndex(tabIndex);

                tabContent.SetParent(null, false); // workaround for a rare internal Unity crash
                tabContent.SetParent(contentParent, false);

                Internal.RecalculateMinSize();
            }
            else if (thisTabIndex != tabIndex)
            {
                if (tabIndex == tabs.Count)
                {
                    tabIndex = tabs.Count - 1;
                }

                PanelTab tab = tabs[thisTabIndex];
                tab.Internal.rectTransform.SetSiblingIndex(tabIndex);

                tabs.RemoveAt(thisTabIndex);
                tabs.Insert(tabIndex, tab);
            }

            ActiveTab = tabIndex;
            return tabs[tabIndex];
        }

        public PanelTab AddTab(PanelTab tab, int tabIndex = -1)
        {
            if (!tab)
            {
                return null;
            }

            return AddTab(tab.Content, tabIndex);
        }

        public PanelTab AddTab(string tabID)
        {
            PanelNotificationCenter.TryGetTab(tabID, out PanelTab tab);

            return AddTab(tab);
        }

        public void RemoveTab(int tabIndex)
        {
            if (tabIndex >= 0 && tabIndex < tabs.Count)
            {
                Internal.RemoveTab(tabIndex, true);
            }
        }

        public void RemoveTab(PanelTab tab)
        {
            RemoveTab(GetTabIndex(tab));
        }

        public void RemoveTab(string tabID)
        {
            PanelNotificationCenter.TryGetTab(tabID, out PanelTab tab);

            RemoveTab(tab);
        }

        public int GetTabIndex(RectTransform tabContent)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (tabs[i].Content == tabContent)
                {
                    return i;
                }
            }

            return -1;
        }

        public int GetTabIndex(PanelTab tab)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (tabs[i] == tab)
                {
                    return i;
                }
            }

            return -1;
        }

        public int GetTabIndex(string tabID)
        {
            if (PanelNotificationCenter.TryGetTab(tabID, out PanelTab tab))
            {
                return GetTabIndex(tab);
            }

            return -1;
        }

        public PanelTab GetTab(RectTransform tabContent)
        {
            int tabIndex = GetTabIndex(tabContent);
            if (tabIndex >= 0)
            {
                return tabs[tabIndex];
            }

            return null;
        }

        public void DockToRoot(PanelDirection direction)
        {
            PanelManager.Instance.AnchorPanel(this, Canvas, direction);
        }

        public void DockToPanel(IPanelGroupElement anchor, PanelDirection direction)
        {
            PanelManager.Instance.AnchorPanel(this, anchor, direction);
        }

        public void Detach()
        {
            PanelManager.Instance.DetachPanel(this);
        }

        public Panel DetachTab(int tabIndex)
        {
            return PanelManager.Instance.DetachPanelTab(this, tabIndex);
        }

        public Panel DetachTab(PanelTab tab)
        {
            return DetachTab(GetTabIndex(tab));
        }

        public Panel DetachTab(string tabID)
        {
            return DetachTab(GetTabIndex(tabID));
        }

        public void BringForward()
        {
            if (!IsDocked)
            {
                RectTransform.SetAsLastSibling();
            }
        }

        public void MoveTo(Vector2 screenPoint)
        {
            if (IsDocked)
            {
                return;
            }

            RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.RectTransform, screenPoint, Canvas.Internal.worldCamera, out Vector2 position);

            RectTransform.anchoredPosition = position + (Canvas.Size - RectTransform.sizeDelta) * 0.5f;
            ((UnanchoredPanelGroup)Group).RestrictPanelToBounds(this);
        }

        public void ResizeTo(Vector2 newSize, PanelDirection horizontalDir = PanelDirection.Right, PanelDirection verticalDir = PanelDirection.Bottom)
        {
            if (IsDocked)
            {
                Group.Internal.ResizeElementTo(this, newSize, horizontalDir, verticalDir);
            }
            else
            {
                FloatingSize = newSize;
            }
        }

        private void InitializeResizeZones()
        {
            resizeZonesParent = (RectTransform)new GameObject("PanelResizeZones", typeof(RectTransform)).transform;
            resizeZonesParent.SetParent(RectTransform, false);
            resizeZonesParent.anchorMin = Vector2.zero;
            resizeZonesParent.anchorMax = Vector2.one;
            resizeZonesParent.sizeDelta = new Vector2(Canvas.PanelResizableAreaLength, Canvas.PanelResizableAreaLength);
            resizeZonesParent.SetAsLastSibling();

            RectTransform resizeZone = GetResizeZone(PanelDirection.Left).RectTransform;
            resizeZone.anchorMin = new Vector2(0f, 0f);
            resizeZone.anchorMax = new Vector2(0f, 1f);
            resizeZone.anchoredPosition = new Vector2(Canvas.PanelResizableAreaLength * 0.5f, 0f);
            resizeZone.sizeDelta = new Vector2(Canvas.PanelResizableAreaLength, 0f);

            // Top resize zone is smaller; this makes it easier to pick the panel from the short gap above a tab
            resizeZone = GetResizeZone(PanelDirection.Top).RectTransform;
            resizeZone.anchorMin = new Vector2(0f, 1f);
            resizeZone.anchorMax = new Vector2(1f, 1f);
            resizeZone.anchoredPosition = new Vector2(0f, -Canvas.PanelResizableAreaLength * 0.25f - 1f);
            resizeZone.sizeDelta = new Vector2(0f, 2f + Canvas.PanelResizableAreaLength * 0.5f);

            resizeZone = GetResizeZone(PanelDirection.Right).RectTransform;
            resizeZone.anchorMin = new Vector2(1f, 0f);
            resizeZone.anchorMax = new Vector2(1f, 1f);
            resizeZone.anchoredPosition = new Vector2(-Canvas.PanelResizableAreaLength * 0.5f, 0f);
            resizeZone.sizeDelta = new Vector2(Canvas.PanelResizableAreaLength, 0f);

            resizeZone = GetResizeZone(PanelDirection.Bottom).RectTransform;
            resizeZone.anchorMin = new Vector2(0f, 0f);
            resizeZone.anchorMax = new Vector2(1f, 0f);
            resizeZone.anchoredPosition = new Vector2(0f, Canvas.PanelResizableAreaLength * 0.5f);
            resizeZone.sizeDelta = new Vector2(0f, Canvas.PanelResizableAreaLength);

            resizeZones[(int)PanelDirection.Left].Initialize(this, PanelDirection.Left, resizeZones[(int)PanelDirection.Bottom], resizeZones[(int)PanelDirection.Top]);
            resizeZones[(int)PanelDirection.Top].Initialize(this, PanelDirection.Top, resizeZones[(int)PanelDirection.Left], resizeZones[(int)PanelDirection.Right]);
            resizeZones[(int)PanelDirection.Right].Initialize(this, PanelDirection.Right, resizeZones[(int)PanelDirection.Bottom], resizeZones[(int)PanelDirection.Top]);
            resizeZones[(int)PanelDirection.Bottom].Initialize(this, PanelDirection.Bottom, resizeZones[(int)PanelDirection.Left], resizeZones[(int)PanelDirection.Right]);
        }

        private void InitializeAnchorZone()
        {
            RectTransform panelAnchorZoneTR = (RectTransform)new GameObject("AnchorZone", typeof(RectTransform)).transform;
            panelAnchorZoneTR.SetParent(RectTransform, false);
            panelAnchorZoneTR.pivot = new Vector2(0.5f, 0f);
            panelAnchorZoneTR.anchorMin = Vector2.zero;
            panelAnchorZoneTR.anchorMax = Vector2.one;
            panelAnchorZoneTR.sizeDelta = new Vector2(0f, -headerHeight);
            panelAnchorZoneTR.SetAsLastSibling();

            panelAnchorZone = panelAnchorZoneTR.gameObject.AddComponent<PanelAnchorZone>();
            panelAnchorZone.Initialize(this);

            RectTransform headerAnchorZoneTR = (RectTransform)new GameObject("HeaderAnchorZone", typeof(RectTransform)).transform;
            headerAnchorZoneTR.SetParent(RectTransform, false);
            headerAnchorZoneTR.pivot = new Vector2(0.5f, 1f);
            headerAnchorZoneTR.anchorMin = new Vector2(0f, 1f);
            headerAnchorZoneTR.anchorMax = new Vector2(1f, 1f);
            headerAnchorZoneTR.sizeDelta = new Vector2(0f, headerHeight);
            headerAnchorZoneTR.SetAsLastSibling();

            headerAnchorZone = headerAnchorZoneTR.gameObject.AddComponent<PanelHeaderAnchorZone>();
            headerAnchorZone.Initialize(this);
        }

        private PanelResizeHelper GetResizeZone(PanelDirection direction)
        {
            PanelResizeHelper resizeZone = resizeZones[(int)direction];
            if (resizeZone != null)
            {
                return resizeZone;
            }

            resizeZone = new GameObject("ResizeZone" + direction, typeof(RectTransform)).AddComponent<PanelResizeHelper>();
            resizeZone.RectTransform.SetParent(resizeZonesParent, false);
            resizeZone.gameObject.AddComponent<NonDrawingGraphic>();

            resizeZones[(int)direction] = resizeZone;

            return resizeZone;
        }

        private void AnchorZonesSetActive(bool value)
        {
            panelAnchorZone.SetActive(IsDocked && value);

            if (headerAnchorZone != null)
            {
                headerAnchorZone.SetActive(value);
            }
        }

        public bool CanResizeInDirection(PanelDirection direction)
        {
            if (direction == PanelDirection.None)
            {
                return false;
            }

            if (!IsDocked)
            {
                return true;
            }

            return surroundings[(int)direction] != null;
        }

        public IPanelGroupElement GetSurroundingElement(PanelDirection direction)
        {
            return surroundings[(int)direction];
        }

        #region Drag Handlers
        private void OnResize(PanelDirection direction, Vector2 screenPoint)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(RectTransform, screenPoint, Canvas.Internal.worldCamera, out Vector2 localPoint);

            Vector2 sizeDelta = RectTransform.sizeDelta;
            if (!IsDocked)
            {
                Vector2 anchoredPosition = RectTransform.anchoredPosition;

                if (direction == PanelDirection.Left)
                {
                    float width = sizeDelta.x - localPoint.x;
                    if (width < minSize.x)
                    {
                        width = minSize.x;
                    }

                    anchoredPosition.x += sizeDelta.x - width;
                    sizeDelta.x = width;
                }
                else if (direction == PanelDirection.Top)
                {
                    float height = localPoint.y;
                    if (height < minSize.y)
                    {
                        height = minSize.y;
                    }

                    sizeDelta.y = height;
                }
                else if (direction == PanelDirection.Right)
                {
                    float width = localPoint.x;
                    if (width < minSize.x)
                    {
                        width = minSize.x;
                    }

                    sizeDelta.x = width;
                }
                else
                {
                    float height = sizeDelta.y - localPoint.y;
                    if (height < minSize.y)
                    {
                        height = minSize.y;
                    }

                    anchoredPosition.y += sizeDelta.y - height;
                    sizeDelta.y = height;
                }

                RectTransform.sizeDelta = sizeDelta;
                RectTransform.anchoredPosition = anchoredPosition;
            }
            else
            {
                float deltaSize;
                if (direction == PanelDirection.Left)
                {
                    deltaSize = -localPoint.x;
                }
                else if (direction == PanelDirection.Top)
                {
                    deltaSize = localPoint.y - sizeDelta.y;
                }
                else if (direction == PanelDirection.Right)
                {
                    deltaSize = localPoint.x - sizeDelta.x;
                }
                else
                {
                    deltaSize = -localPoint.y;
                }

                if (deltaSize >= 0f)
                {
                    Group.Internal.TryChangeSizeOf(this, direction, deltaSize);
                }
                else
                {
                    IPanelGroupElement surrounding = surroundings[(int)direction];
                    if (surrounding != null)
                    {
                        surrounding.Group.Internal.TryChangeSizeOf(surrounding, direction.Opposite(), -deltaSize);
                    }
                }
            }
        }

        private void OnTranslate(Vector2 deltaPosition)
        {
            RectTransform.anchoredPosition += deltaPosition;
        }
        #endregion
    }
}
