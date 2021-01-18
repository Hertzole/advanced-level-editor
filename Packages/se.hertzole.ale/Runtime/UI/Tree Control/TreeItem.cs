using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    public class TreeItem : RecycledListItem, ITreeItem, IDragHandler, IBeginDragHandler, IPointerClickHandler
    {
        [SerializeField]
        private TextMeshProUGUI labelText = null;
        [SerializeField]
        private TreeItemExpander expander = null;
        [SerializeField]
        private RectTransform content = null;
        [SerializeField]
        private float indentAmount = 20f;

        public TextMeshProUGUI LabelText { get { return labelText; } set { labelText = value; } }

        private bool hasChildren;

        private int depth;

        protected TreeControl parentTree;

        private List<object> children = new List<object>();

        public object Item { get; set; }

        public bool HasChildren { get { return hasChildren; } set { hasChildren = value; expander.CanExpand = value; } }
        public bool Expanded { get { return expander.IsExpanded; } set { expander.IsExpanded = value; } }

        public int Depth
        {
            get { return depth; }
            set
            {
                if (depth != value)
                {
                    depth = value;
                    content.offsetMin = new Vector2(indentAmount * value, content.offsetMin.y);
                }
            }
        }

        public TreeItemExpander.ExpandEvent OnExpandedChanged { get { return expander.OnValueChanged; } }

        public List<object> Children { get { return children; } }

        public void Initialize(TreeControl tree)
        {
            parentTree = tree;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            parentTree.StartDragging(Item, eventData);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {

        }

        public void SetIsExpandedWithoutNotify(bool expanded)
        {
            expander.SetIsExpandedWithoutNotify(expanded);
        }
    }
}
