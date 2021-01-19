#if UNITY_EDITOR || ( !UNITY_ANDROID && !UNITY_IOS )
#define ENABLE_CURSOR_MANAGEMENT
#endif

using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    [DisallowMultipleComponent]
    public class PanelResizeHelper : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
#if ENABLE_CURSOR_MANAGEMENT
        , IPointerEnterHandler, IPointerExitHandler
#endif
    {
        private PanelDirection direction;
        private PanelDirection secondDirection;

        private Panel panel;
        private PanelResizeHelper helperBefore, helperAfter;

        private int pointerId = PanelManager.NON_EXISTING_TOUCH;

        public PanelDirection Direction { get { return direction; } }

        public Panel Panel { get { return panel; } }
        public RectTransform RectTransform { get; private set; }

        private void Awake()
        {
            RectTransform = (RectTransform)transform;
        }

        private void OnEnable()
        {
            pointerId = PanelManager.NON_EXISTING_TOUCH;
        }

        public void Initialize(Panel panel, PanelDirection direction, PanelResizeHelper helperBefore, PanelResizeHelper helperAfter)
        {
            this.panel = panel;

            this.direction = direction;
            this.helperBefore = helperBefore;
            this.helperAfter = helperAfter;
        }

#if ENABLE_CURSOR_MANAGEMENT
        public void OnPointerEnter(PointerEventData eventData)
        {
            PanelCursorHandler.OnPointerEnter(this, eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PanelCursorHandler.OnPointerExit(this);
        }
#endif

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Cancel drag event if panel is already being resized by another pointer
            // or panel is anchored to a fixed anchor in that direction
            if (!panel.CanResizeInDirection(direction))
            {
                eventData.pointerDrag = null;
                return;
            }

            pointerId = eventData.pointerId;
            secondDirection = GetSecondDirection(eventData.pressPosition);

#if ENABLE_CURSOR_MANAGEMENT
            PanelCursorHandler.OnBeginResize(direction, secondDirection);
#endif
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.pointerId != pointerId)
            {
                return;
            }

            panel.Internal.OnResize(direction, eventData.position);

            if (secondDirection != PanelDirection.None)
            {
                panel.Internal.OnResize(secondDirection, eventData.position);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerId != pointerId)
            {
                return;
            }

            if (!panel.IsDocked)
            {
                ((UnanchoredPanelGroup)panel.Group).RestrictPanelToBounds(panel);
            }

            pointerId = PanelManager.NON_EXISTING_TOUCH;

#if ENABLE_CURSOR_MANAGEMENT
            PanelCursorHandler.OnEndResize();
#endif
        }

        public PanelDirection GetSecondDirection(Vector2 pointerPosition)
        {
            if (panel.IsDocked)
            {
                return PanelDirection.None;
            }

            PanelDirection result;
            if (RectTransformUtility.RectangleContainsScreenPoint(helperBefore.RectTransform, pointerPosition, panel.Canvas.Internal.worldCamera))
            {
                result = helperBefore.direction;
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(helperAfter.RectTransform, pointerPosition, panel.Canvas.Internal.worldCamera))
            {
                result = helperAfter.direction;
            }
            else
            {
                result = PanelDirection.None;
            }

            if (!panel.CanResizeInDirection(result))
            {
                result = PanelDirection.None;
            }

            return result;
        }

        public void Stop()
        {
            if (pointerId != PanelManager.NON_EXISTING_TOUCH)
            {
                if (!panel.IsDocked)
                {
                    ((UnanchoredPanelGroup)panel.Group).RestrictPanelToBounds(panel);
                }

                pointerId = PanelManager.NON_EXISTING_TOUCH;

#if ENABLE_CURSOR_MANAGEMENT
                PanelCursorHandler.OnEndResize();
#endif
            }
        }
    }
}
