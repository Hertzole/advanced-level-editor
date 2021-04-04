using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    public class TreeItemReference : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI label;

        private RectTransform canvasTransform;
        private PointerEventData currentPointer;

        private RectTransform rectTransform;

        public TextMeshProUGUI Label { get { return label; } }

        public virtual void Initialize(Canvas canvas)
        {
            rectTransform = (RectTransform)transform;
            canvasTransform = (RectTransform)canvas.transform;
        }

        public virtual void SetContent(object reference)
        {
            if (reference is Object unityObject)
            {
                label.text = unityObject.name;
            }
            else
            {
                label.text = reference.ToString();
            }
        }

        public void SetPointer(PointerEventData pointer)
        {
            currentPointer = pointer;

            Reposition();
        }

        public void Reposition()
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, currentPointer.position, null, out Vector2 pos))
            {
                rectTransform.anchoredPosition = pos;
            }
        }

        private void Update()
        {
            if (currentPointer != null && currentPointer.dragging)
            {
                Reposition();
            }
            else
            {
                currentPointer = null;
                gameObject.SetActive(false);
            }
        }
    }
}
