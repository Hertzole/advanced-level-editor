using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [DisallowMultipleComponent]
    public class PanelTab : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        internal class InternalSettings
        {
            private readonly PanelTab tab;
            public readonly RectTransform rectTransform;

            public InternalSettings(PanelTab tab)
            {
                this.tab = tab;
                rectTransform = (RectTransform)tab.transform;
            }

            public bool IsBeingDetached { get { return tab.pointerId != PanelManager.NON_EXISTING_TOUCH; } }

            public void Initialize(Panel panel, RectTransform content)
            {
                tab.panel = panel;
                tab.Content = content;
            }

            public void ChangeCloseButtonVisibility(bool isVisible)
            {
                if (tab.closeButton && isVisible != tab.closeButton.gameObject.activeSelf)
                {
                    tab.closeButton.gameObject.SetActive(isVisible);

                    float tabSizeDelta = tab.closeButton.GetComponent<LayoutElement>().preferredWidth;
                    tab.GetComponent<LayoutElement>().preferredWidth += isVisible ? tabSizeDelta : -tabSizeDelta;
                }
            }

            public void Stop()
            {
                if (tab.pointerId != PanelManager.NON_EXISTING_TOUCH)
                {
                    tab.ResetBackgroundColor();
                    tab.pointerId = PanelManager.NON_EXISTING_TOUCH;

                    PanelNotificationCenter.Internal.TabDragStateChanged(tab, false);
                }
            }

            public void SetActive(bool activeState) { tab.SetActive(activeState); }
        }

        [SerializeField]
        private Image background = null;
        [SerializeField]
        private Image icon = null;
        [SerializeField]
        private TextMeshProUGUI label = null;
        [SerializeField]
        private Button closeButton = null;

        internal InternalSettings Internal { get; private set; }

        private string id = null;
        public string ID
        {
            get { return id; }
            set
            {
                if (!string.IsNullOrEmpty(value) && id != value)
                {
                    PanelNotificationCenter.Internal.TabIDChanged(this, id, value);
                    id = value;
                }
            }
        }

        private Panel panel;
        public Panel Panel { get { return panel; } }

        public int Index { get { return panel.GetTabIndex(this); } set { panel.AddTab(this, value); } }
        public RectTransform Content { get; private set; }

        private Vector2 minSize;
        public Vector2 MinSize
        {
            get { return minSize; }
            set
            {
                if (minSize != value)
                {
                    minSize = value;
                    panel.Internal.RecalculateMinSize();
                }
            }
        }

        public Sprite Icon
        {
            get { return icon != null ? icon.sprite : null; }
            set
            {
                if (icon != null)
                {
                    icon.gameObject.SetActive(value != null);
                    icon.sprite = value;
                }
            }
        }

        public string Label
        {
            get { return label != null ? label.text : null; }
            set
            {
                if (label != null && value != null)
                {
                    label.text = value;
                }
            }
        }

        private int pointerId = PanelManager.NON_EXISTING_TOUCH;

        private void Awake()
        {
            minSize = new Vector2(100f, 100f);
            Internal = new InternalSettings(this);

            icon.preserveAspect = true;

            if (closeButton != null)
            {
                closeButton.onClick.AddListener(() => PanelNotificationCenter.Internal.TabClosed(this));
            }
        }

        private void Start()
        {
            if (string.IsNullOrEmpty(id))
            {
                ID = System.Guid.NewGuid().ToString();
            }
        }

        private void OnEnable()
        {
            pointerId = PanelManager.NON_EXISTING_TOUCH;
        }

        private void OnDestroy()
        {
            PanelNotificationCenter.Internal.TabIDChanged(this, id, null);
        }

        public void AttachTo(Panel panel, int tabIndex = -1)
        {
            panel.AddTab(Content, tabIndex);
        }

        public Panel Detach()
        {
            return panel.DetachTab(this);
        }

        public void Destroy()
        {
            panel.RemoveTab(this);
        }

        private void SetActive(bool activeState)
        {
            if (!Content)
            {
                panel.Internal.RemoveTab(panel.GetTabIndex(this), true);
            }
            else
            {
                if (activeState)
                {
                    background.color = panel.TabSelectedColor;
                    label.color = panel.TabSelectedTextColor;
                }
                else
                {
                    background.color = panel.TabNormalColor;
                    label.color = panel.TabNormalTextColor;
                }

                Content.gameObject.SetActive(activeState);
            }
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (!Content)
            {
                panel.Internal.RemoveTab(panel.GetTabIndex(this), true);
            }
            else
            {
                panel.ActiveTab = panel.GetTabIndex(this);
            }
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            // Cancel drag event if panel is already being dragged by another pointer,
            // or PanelManager does not want the panel to be dragged at that moment
            if (!PanelManager.Instance.OnBeginPanelTabTranslate(this, eventData))
            {
                eventData.pointerDrag = null;
                return;
            }

            pointerId = eventData.pointerId;

            background.color = panel.TabDetachingColor;
            label.color = panel.TabDetachingTextColor;

            PanelNotificationCenter.Internal.TabDragStateChanged(this, true);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (eventData.pointerId != pointerId)
            {
                eventData.pointerDrag = null;
                return;
            }

            PanelManager.Instance.OnPanelTabTranslate(this, eventData);
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerId != pointerId)
            {
                return;
            }

            pointerId = PanelManager.NON_EXISTING_TOUCH;
            ResetBackgroundColor();

            PanelManager.Instance.OnEndPanelTabTranslate(this, eventData);
            PanelNotificationCenter.Internal.TabDragStateChanged(this, false);
        }

        private void ResetBackgroundColor()
        {
            if (panel.ActiveTab == panel.GetTabIndex(this))
            {
                background.color = panel.TabSelectedColor;
                label.color = panel.TabSelectedTextColor;
            }
            else
            {
                background.color = panel.TabNormalColor;
                label.color = panel.TabNormalTextColor;
            }
        }
    }
}
