using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    public class CanvasAnchorZone : AnchorZoneBase
    {
        private PanelDirection direction;

        public void SetDirection(PanelDirection direction)
        {
            this.direction = direction;
        }

        public override bool Execute(PanelTab panelTab, PointerEventData eventData)
        {
            Panel detachedPanel = PanelManager.Instance.DetachPanelTab(panelTab.Panel, panelTab.Panel.GetTabIndex(panelTab));
            PanelManager.Instance.AnchorPanel(detachedPanel, panel.Canvas, direction);

            return true;
        }

        public override bool GetAnchoredPreviewRectangleAt(PointerEventData eventData, out Rect rect)
        {
            Vector2 size = panel.Canvas.Size;
            if (direction == PanelDirection.Left)
            {
                rect = new Rect(0f, 0f, size.x * 0.2f, size.y);
            }
            else if (direction == PanelDirection.Top)
            {
                rect = new Rect(0f, size.y * 0.8f, size.x, size.y * 0.2f);
            }
            else if (direction == PanelDirection.Right)
            {
                rect = new Rect(size.x * 0.8f, 0f, size.x * 0.2f, size.y);
            }
            else
            {
                rect = new Rect(0f, 0f, size.x, size.y * 0.2f);
            }

            rect.position += (rect.size - size) * 0.5f;
            return true;
        }
    }
}
