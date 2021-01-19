using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    public class PanelAnchorZone : AnchorZoneBase
    {
        public override bool Execute(PanelTab panelTab, PointerEventData eventData)
        {
            PanelDirection anchorDirection = GetAnchorDirection(eventData);
            if (anchorDirection == PanelDirection.None)
            {
                return false;
            }

            Panel detachedPanel = PanelManager.Instance.DetachPanelTab(panelTab.Panel, panelTab.Panel.GetTabIndex(panelTab));
            PanelManager.Instance.AnchorPanel(detachedPanel, panel, anchorDirection);

            return true;
        }

        public override bool GetAnchoredPreviewRectangleAt(PointerEventData eventData, out Rect rect)
        {
            PanelDirection anchorDirection = GetAnchorDirection(eventData);
            if (anchorDirection == PanelDirection.None)
            {
                rect = new Rect();
                return false;
            }

            Vector2 size = panel.RectTransform.sizeDelta;
            size.y -= panel.Internal.HeaderHeight;

            float anchorWidth = Mathf.Min(panel.Canvas.PanelAnchorZoneLength, size.x * panel.Canvas.PanelAnchorZoneLengthRatio);
            float anchorHeight = Mathf.Min(panel.Canvas.PanelAnchorZoneLength, size.y * panel.Canvas.PanelAnchorZoneLengthRatio);

            if (anchorDirection == PanelDirection.Left)
            {
                rect = new Rect(0f, 0f, anchorWidth, size.y);
            }
            else if (anchorDirection == PanelDirection.Top)
            {
                rect = new Rect(0f, size.y - anchorHeight, size.x, anchorHeight);
            }
            else if (anchorDirection == PanelDirection.Right)
            {
                rect = new Rect(size.x - anchorWidth, 0f, anchorWidth, size.y);
            }
            else
            {
                rect = new Rect(0f, 0f, size.x, anchorHeight);
            }

            rect.position += panel.RectTransform.anchoredPosition + (rect.size - panel.Canvas.Size) * 0.5f;
            return true;
        }

        private PanelDirection GetAnchorDirection(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(panel.RectTransform, eventData.position, panel.Canvas.Internal.worldCamera, out Vector2 pointerPos);

            Vector2 size = panel.RectTransform.sizeDelta;
            size.y -= panel.Internal.HeaderHeight;

            float anchorWidth = Mathf.Min(panel.Canvas.PanelAnchorZoneLength, size.x * panel.Canvas.PanelAnchorZoneLengthRatio);
            float anchorHeight = Mathf.Min(panel.Canvas.PanelAnchorZoneLength, size.y * panel.Canvas.PanelAnchorZoneLengthRatio);

            if (pointerPos.y < anchorHeight)
            {
                return PanelDirection.Bottom;
            }

            if (pointerPos.y > size.y - anchorHeight)
            {
                return PanelDirection.Top;
            }

            if (pointerPos.x < anchorWidth)
            {
                return PanelDirection.Left;
            }

            if (pointerPos.x > size.x - anchorWidth)
            {
                return PanelDirection.Right;
            }

            return PanelDirection.None;
        }
    }
}
