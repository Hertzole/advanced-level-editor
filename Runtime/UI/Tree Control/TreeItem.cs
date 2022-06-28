using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class TreeItemSelectedEventArgs : EventArgs
    {
        public bool IsSelected { get; private set; }
        public int Index { get; private set; }
        public object Item { get; private set; }

        public TreeItemSelectedEventArgs(bool isSelected, int index, object item)
        {
            IsSelected = isSelected;
            Index = index;
            Item = item;
        }
    }

    [RequireComponent(typeof(Toggle))]
    public class TreeItem : RecycledListItem, ITreeItem, IDragHandler, IBeginDragHandler
    {
        [SerializeField]
        private TextMeshProUGUI labelText = null;
        [SerializeField] 
        private Image icon = default;
        [SerializeField]
        private LevelEditorExpander expander = null;
        [SerializeField]
        private RectTransform content = null;
        [SerializeField]
        private float indentAmount = 20f;

        [SerializeField]
        [HideInInspector]
        private Toggle toggle = null;

        public TextMeshProUGUI LabelText { get { return labelText; } set { labelText = value; } }
        public Image Icon { get { return icon; } set { icon = value; } }

        private bool hasChildren;
        private bool selected;

        private int depth;

        protected TreeControl parentTree;

        private List<object> children = new List<object>();

        public object Item { get; set; }

        public bool HasChildren { get { return hasChildren; } set { hasChildren = value; expander.CanExpand = value; } }
        public bool Expanded { get { return expander.IsExpanded; } set { expander.IsExpanded = value; } }

        public bool Interactable { get { return toggle.interactable; } set { toggle.interactable = value; } }
        public bool Selected { get { return selected; } set { SetSelected(value, true); } }
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

        public LevelEditorExpander.ExpandEvent OnExpandedChanged { get { return expander.OnValueChanged; } }
        public event EventHandler<TreeItemSelectedEventArgs> OnSelected;

        public List<object> Children { get { return children; } }

        private void Awake()
        {
            toggle.onValueChanged.AddListener((x) => SetSelected(x, true));
        }

        public void Initialize(TreeControl tree)
        {
            parentTree = tree;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            parentTree.StartDragging(Item, eventData);
        }

        public void OnDrag(PointerEventData eventData) { }

        public void SetIsExpandedWithoutNotify(bool expanded)
        {
            expander.SetIsExpandedWithoutNotify(expanded);
        }

        public void SetSelectedWithoutNotify(bool selected)
        {
            SetSelected(selected, false);
        }

        private void SetSelected(bool selected, bool notify)
        {
            toggle.interactable = !selected;
            if (notify)
            {
                toggle.isOn = selected;
                OnSelected?.Invoke(this, new TreeItemSelectedEventArgs(selected, Position, Item));
            }
            else
            {
                toggle.SetIsOnWithoutNotify(selected);
            }

            this.selected = selected;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (toggle == null)
            {
                toggle = GetComponent<Toggle>();
            }
        }
#endif
    }
}
