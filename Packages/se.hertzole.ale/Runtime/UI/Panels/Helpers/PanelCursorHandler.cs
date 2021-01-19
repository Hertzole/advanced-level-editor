using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    public class PanelCursorHandler : MonoBehaviour
    {
        private bool isResizing;

        private Vector2 prevPointerPos;

        private PanelResizeHelper activeResizeHelper;
        private PointerEventData activeEventData;

        [SerializeField]
        private Texture2D horizontalCursor = null;
        [SerializeField]
        private Texture2D verticalCursor = null;
        [SerializeField]
        private Texture2D diagonalCursorTopLeft = null;
        [SerializeField]
        private Texture2D diagonalCursorTopRight = null;

        private static PanelCursorHandler instance = null;

        private void Awake()
        {
            instance = this;
        }

        public static void OnPointerEnter(PanelResizeHelper resizeHelper, PointerEventData eventData)
        {
            if (instance == null)
            {
                return;
            }

            instance.activeResizeHelper = resizeHelper;
            instance.activeEventData = eventData;
        }

        public static void OnPointerExit(PanelResizeHelper resizeHelper)
        {
            if (instance == null)
            {
                return;
            }

            if (instance.activeResizeHelper == resizeHelper)
            {
                instance.activeResizeHelper = null;
                instance.activeEventData = null;

                if (!instance.isResizing)
                {
                    SetDefaultCursor();
                }
            }
        }

        public static void OnBeginResize(PanelDirection primary, PanelDirection secondary)
        {
            if (instance == null)
            {
                return;
            }

            instance.isResizing = true;
            instance.UpdateCursor(primary, secondary);
        }

        public static void OnEndResize()
        {
            if (instance == null)
            {
                return;
            }

            instance.isResizing = false;

            if (instance.activeResizeHelper == null)
            {
                SetDefaultCursor();
            }
            else
            {
                instance.prevPointerPos = new Vector2(-1f, -1f);
            }
        }

        private void Update()
        {
            if (isResizing)
            {
                return;
            }

            if (activeResizeHelper != null)
            {
                Vector2 pointerPos = activeEventData.position;
                if (pointerPos != prevPointerPos)
                {
                    if (activeEventData.dragging)
                    {
                        SetDefaultCursor();
                    }
                    else
                    {
                        PanelDirection direction = activeResizeHelper.Direction;
                        PanelDirection secondDirection = activeResizeHelper.GetSecondDirection(activeEventData.position);
                        if (activeResizeHelper.Panel.CanResizeInDirection(direction))
                        {
                            UpdateCursor(direction, secondDirection);
                        }
                        else if (secondDirection != PanelDirection.None)
                        {
                            UpdateCursor(secondDirection, PanelDirection.None);
                        }
                        else
                        {
                            SetDefaultCursor();
                        }
                    }

                    prevPointerPos = pointerPos;
                }
            }
        }

        private static void SetDefaultCursor()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        private void UpdateCursor(PanelDirection primary, PanelDirection secondary)
        {
            Texture2D cursorTex;
            if (primary == PanelDirection.Left)
            {
                if (secondary == PanelDirection.Top)
                {
                    cursorTex = diagonalCursorTopLeft;
                }
                else if (secondary == PanelDirection.Bottom)
                {
                    cursorTex = diagonalCursorTopRight;
                }
                else
                {
                    cursorTex = horizontalCursor;
                }
            }
            else if (primary == PanelDirection.Right)
            {
                if (secondary == PanelDirection.Top)
                {
                    cursorTex = diagonalCursorTopRight;
                }
                else if (secondary == PanelDirection.Bottom)
                {
                    cursorTex = diagonalCursorTopLeft;
                }
                else
                {
                    cursorTex = horizontalCursor;
                }
            }
            else if (primary == PanelDirection.Top)
            {
                if (secondary == PanelDirection.Left)
                {
                    cursorTex = diagonalCursorTopLeft;
                }
                else if (secondary == PanelDirection.Right)
                {
                    cursorTex = diagonalCursorTopRight;
                }
                else
                {
                    cursorTex = verticalCursor;
                }
            }
            else
            {
                if (secondary == PanelDirection.Left)
                {
                    cursorTex = diagonalCursorTopRight;
                }
                else if (secondary == PanelDirection.Right)
                {
                    cursorTex = diagonalCursorTopLeft;
                }
                else
                {
                    cursorTex = verticalCursor;
                }
            }

            Cursor.SetCursor(cursorTex, new Vector2(cursorTex.width * 0.5f, cursorTex.height * 0.5f), CursorMode.Auto);
        }
    }
}
