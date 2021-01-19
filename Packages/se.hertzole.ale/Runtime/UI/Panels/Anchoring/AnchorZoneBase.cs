using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [DisallowMultipleComponent]
    public abstract class AnchorZoneBase : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
    {
        private int hoveredPointerId = PanelManager.NON_EXISTING_TOUCH;

        protected Panel panel;
        private Graphic raycastZone;

        public Panel Panel { get { return panel; } }
        public RectTransform RectTransform { get; private set; }
        public PanelCanvas Canvas { get { return panel.Canvas; } }

        protected void Awake()
        {
            RectTransform = (RectTransform)transform;
            raycastZone = gameObject.AddComponent<NonDrawingGraphic>();
        }

        protected void OnEnable()
        {
            hoveredPointerId = PanelManager.NON_EXISTING_TOUCH;
        }

        public abstract bool Execute(PanelTab panelTab, PointerEventData eventData);
        public abstract bool GetAnchoredPreviewRectangleAt(PointerEventData eventData, out Rect rect);

        public void Initialize(Panel panel)
        {
            this.panel = panel;
        }

        public void SetActive(bool value)
        {
            hoveredPointerId = PanelManager.NON_EXISTING_TOUCH;
            raycastZone.raycastTarget = value;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (PanelManager.Instance.AnchorPreviewPanelTo(this))
            {
                hoveredPointerId = eventData.pointerId;
            }
        }

        // Saves the system from a complete shutdown in a rare case
        public void OnPointerDown(PointerEventData eventData)
        {
            PanelManager.Instance.CancelDraggingPanel();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerId == hoveredPointerId)
            {
                hoveredPointerId = PanelManager.NON_EXISTING_TOUCH;
                PanelManager.Instance.StopAnchorPreviewPanelTo(this);
            }
        }
    }
}
