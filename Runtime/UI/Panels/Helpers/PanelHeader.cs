using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    [DisallowMultipleComponent]
    public class PanelHeader : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        private Panel panel = null;

        private int pointerId = PanelManager.NON_EXISTING_TOUCH;

        private Vector2 initialTouchPos;

        public Vector2 InitialTouchPos { get { return initialTouchPos; } }

        public Panel Panel { get { return panel; } }

        private void OnEnable()
        {
            pointerId = PanelManager.NON_EXISTING_TOUCH;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!PanelManager.Instance.OnBeginPanelTranslate(panel))
            {
                eventData.pointerDrag = null;
                return;
            }

            pointerId = eventData.pointerId;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(panel.RectTransform, eventData.position, panel.Canvas.Internal.worldCamera, out initialTouchPos);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.pointerId != pointerId)
            {
                eventData.pointerDrag = null;
                return;
            }

            PanelManager.Instance.OnPanelTranslate(this, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerId != pointerId)
            {
                return;
            }

            pointerId = PanelManager.NON_EXISTING_TOUCH;
            PanelManager.Instance.OnEndPanelTranslate(panel);
        }

        public void Stop()
        {
            pointerId = PanelManager.NON_EXISTING_TOUCH;
        }
    }
}
