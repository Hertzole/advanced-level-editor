using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    public class PanelHeaderAnchorZone : AnchorZoneBase
    {
        public override bool Execute(PanelTab panelTab, PointerEventData eventData)
        {
            int tabIndex = panel.Internal.GetTabIndexAt(eventData, out _);

            panel.AddTab(panelTab.Content, tabIndex);
            return true;
        }

        public override bool GetAnchoredPreviewRectangleAt(PointerEventData eventData, out Rect rect)
        {
            panel.Internal.GetTabIndexAt(eventData, out Vector2 tabPreviewRect);

            rect = new Rect(tabPreviewRect.x, panel.RectTransform.sizeDelta.y - panel.Internal.HeaderHeight, tabPreviewRect.y, panel.Internal.HeaderHeight);
            rect.position += panel.RectTransform.anchoredPosition + (rect.size - panel.Canvas.Size) * 0.5f;

            return true;
        }
    }
}
