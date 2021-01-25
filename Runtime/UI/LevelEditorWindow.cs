using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        private bool canDrag = true;
        [SerializeField]
        private RectTransform dragArea;

        private bool dragging = false;

        private Vector2 dragDelta;

        private RectTransform rectTransform;
        private GameObject blocker;
        private Canvas rootCanvas;

        private LevelEditorWindowEvent onWindowOpen = new LevelEditorWindowEvent();
        private LevelEditorWindowEvent onWindowClose = new LevelEditorWindowEvent();

        public bool CanDrag { get { return canDrag; } set { canDrag = value; } }
        public RectTransform DragArea { get { return dragArea; } set { dragArea = value; } }
        public RectTransform RectTransform { get { if (!rectTransform) { rectTransform = (RectTransform)transform; } return rectTransform; } }

        public LevelEditorWindowEvent OnWindowOpen { get { return onWindowOpen; } set { onWindowOpen = value; } }
        public LevelEditorWindowEvent OnWindowClose { get { return onWindowClose; } set { onWindowClose = value; } }

        protected virtual void Awake()
        {
            rootCanvas = GetComponentInParent<Canvas>();
            gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
            OnShow();
            OnWindowOpen.Invoke();
        }

        public virtual void Show(bool dismissOnBackgroundClick)
        {
            Show(dismissOnBackgroundClick, Color.clear);
        }

        public virtual void Show(bool dismissOnBackgroundClick, Color backgroundColor)
        {
            Show();

            Canvas windowCanvas = gameObject.GetComponent<Canvas>();
            GraphicRaycaster raycaster = gameObject.GetComponent<GraphicRaycaster>();

            if (windowCanvas == null)
            {
                windowCanvas = gameObject.AddComponent<Canvas>();
            }

            if (raycaster == null)
            {
                gameObject.AddComponentIfNull<GraphicRaycaster>();
            }

            windowCanvas.overrideSorting = true;
            windowCanvas.sortingOrder = 30000;

            blocker = CreateBlocker(rootCanvas, dismissOnBackgroundClick, backgroundColor);
            transform.SetAsLastSibling();
        }

        public virtual void Dismiss()
        {
            DestroyBlocker();
            gameObject.SetActive(false);

            OnDismiss();
            OnWindowClose.Invoke();
        }

        protected GameObject CreateBlocker(Canvas rootCanvas, bool dismissOnClick, Color backgroundColor)
        {
            GameObject blocker = new GameObject("Blocker");

            RectTransform blockerRect = blocker.AddComponent<RectTransform>();
            blockerRect.SetParent(rootCanvas.transform, false);
            blockerRect.anchorMin = Vector3.zero;
            blockerRect.anchorMax = Vector3.one;
            blockerRect.sizeDelta = Vector2.zero;

            Canvas blockerCanvas = blocker.AddComponent<Canvas>();
            blockerCanvas.overrideSorting = true;
            Canvas windowCanvas = gameObject.GetComponent<Canvas>();
            blockerCanvas.sortingLayerID = windowCanvas.sortingLayerID;
            blockerCanvas.sortingOrder = windowCanvas.sortingOrder - 1;

            blocker.AddComponent<GraphicRaycaster>();

            Image blockerImage = blocker.AddComponent<Image>();
            blockerImage.color = backgroundColor;

            if (dismissOnClick)
            {
                Button blockerButton = blocker.AddComponent<Button>();
                blockerButton.onClick.AddListener(Dismiss);
            }

            return blocker;
        }

        protected void DestroyBlocker()
        {
            if (blocker)
            {
                Destroy(blocker);
            }
        }

        protected virtual void OnShow() { }

        protected virtual void OnDismiss() { }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!canDrag)
            {
                return;
            }

            if (RectTransformUtility.RectangleContainsScreenPoint(DragArea, eventData.position))
            {
                dragging = true;
                dragDelta = new Vector2(transform.position.x, transform.position.y) - eventData.position;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canDrag)
            {
                return;
            }

            if (!dragging)
            {
                return;
            }

            transform.position = GetClampedPosition(eventData.position + dragDelta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!canDrag)
            {
                return;
            }

            if (!dragging)
            {
                return;
            }

            dragging = false;
        }

        private Vector2 GetClampedPosition(Vector2 position)
        {
            position.x = Mathf.Clamp(position.x, 0 + (RectTransform.sizeDelta.x / 2), rootCanvas.pixelRect.width - (RectTransform.sizeDelta.x / 2));
            position.y = Mathf.Clamp(position.y, 0 + (RectTransform.sizeDelta.y / 2), rootCanvas.pixelRect.height - (RectTransform.sizeDelta.y / 2));

            return position;
        }
    }
}
