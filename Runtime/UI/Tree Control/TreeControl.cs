using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public enum ItemDropAction { SetLastChild, SetPreviousSibling, SetNextSibling }

    [RequireComponent(typeof(ScrollRect), typeof(RecycledListView))]
    public abstract class TreeControl : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Reorder")]
        [SerializeField]
        protected bool canReorderItems = true;
        [SerializeField]
        protected RectTransform dragDropTargetVisual = null;
        [SerializeField]
        private TreeItemReference dragItemReference = null;
        [SerializeField]
        private float siblingIndexModificationArea = 5f;
        [SerializeField]
        private float scrollableArea = 75f;

        [SerializeField]
        [HideInInspector]
        private ScrollRect scroll = null;
        [SerializeField]
        [HideInInspector]
        protected RecycledListView listView = null;

        private bool isDragging = false;

        private float pointerLastYPos = 0f;
        private float nextPointerValidation = 0;
        private float height;
        private float oneOverScrollableArea;
        private float autoScrollSpeed;
        private float itemHeight;

        private const float POINTER_VALIDATE_INTERVAL = 5f;

        private object draggingItem;

        private RectTransform rectTransform;

        private Camera canvasCamera;

        private PointerEventData pointer;

        protected virtual void Awake()
        {
            rectTransform = (RectTransform)transform;

            canvasCamera = Camera.main;

            oneOverScrollableArea = 1f / scrollableArea;

            itemHeight = GetItemHeight();

            listView.OnCreateItem = CreateItem;
            listView.OnBindItem += BindItem;

            if (dragDropTargetVisual != null)
            {
                dragDropTargetVisual.gameObject.SetActive(false);
            }
        }

        protected virtual float GetItemHeight() { return 0f; }

        private void OnRectTransformDimensionsChange()
        {
            height = 0;
        }

        protected virtual void Update()
        {
            UpdateDragging();
            AutoScroll();
        }

        protected virtual void UpdateDragging()
        {
            if (pointer == null)
            {
                return;
            }

            nextPointerValidation -= Time.unscaledDeltaTime;
            if (nextPointerValidation <= 0)
            {
                nextPointerValidation = POINTER_VALIDATE_INTERVAL;

                if (!pointer.IsPointerValid())
                {
                    pointer = null;
                    return;
                }
            }

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, pointer.position, null, out Vector2 position) && position.y != pointerLastYPos)
            {
                pointerLastYPos = -position.y;

                if (height <= 0f)
                {
                    height = rectTransform.rect.height;
                }

                float scrollAmount = 0f;
                float viewportYPos = pointerLastYPos;
                if (pointerLastYPos < scrollableArea)
                {
                    scrollAmount = (scrollableArea - pointerLastYPos) * oneOverScrollableArea;
                }
                else if (pointerLastYPos > height - scrollableArea)
                {
                    scrollAmount = (height - scrollableArea - viewportYPos) * oneOverScrollableArea;
                }

                float contentYPos = pointerLastYPos + scroll.content.anchoredPosition.y;
                if (contentYPos < 0f)
                {
                    if (dragDropTargetVisual != null && dragDropTargetVisual.gameObject.activeSelf)
                    {
                        dragDropTargetVisual.gameObject.SetActive(false);
                    }

                    autoScrollSpeed = 0;
                }
                else
                {
                    if (contentYPos < listView.ItemCount * itemHeight)
                    {
                        if (dragDropTargetVisual != null && !dragDropTargetVisual.gameObject.activeSelf)
                        {
                            dragDropTargetVisual.SetAsLastSibling();
                            dragDropTargetVisual.gameObject.SetActive(true);
                        }

                        float relativePosition = contentYPos % itemHeight;
                        float absolutePosition = -contentYPos + relativePosition;

                        if (dragDropTargetVisual != null)
                        {
                            if (relativePosition < siblingIndexModificationArea)
                            {
                                // Above the target.
                                dragDropTargetVisual.anchoredPosition = new Vector2(0f, absolutePosition + 2f);
                                dragDropTargetVisual.sizeDelta = new Vector2(20f, 4f);
                            }
                            else if (relativePosition > itemHeight - siblingIndexModificationArea)
                            {
                                // Below the target.
                                dragDropTargetVisual.anchoredPosition = new Vector2(0f, absolutePosition - itemHeight + 2f);
                                dragDropTargetVisual.sizeDelta = new Vector2(20f, 4f);
                            }
                            else
                            {
                                // On the target.
                                dragDropTargetVisual.anchoredPosition = new Vector2(0f, absolutePosition);
                                dragDropTargetVisual.sizeDelta = new Vector2(20f, itemHeight);
                            }
                        }
                    }
                    else if (dragDropTargetVisual != null && dragDropTargetVisual.gameObject.activeSelf)
                    {
                        dragDropTargetVisual.gameObject.SetActive(false);
                    }

                    autoScrollSpeed = scrollAmount * 75f;
                }
            }
        }

        protected void AutoScroll()
        {
            if (autoScrollSpeed != 0f)
            {
                scroll.verticalNormalizedPosition = Mathf.Clamp01(scroll.verticalNormalizedPosition + autoScrollSpeed * Time.unscaledDeltaTime / listView.ItemCount);
            }
        }

        public void AddItems(IEnumerable<object> items)
        {
            listView.AddItems(items);
        }

        public void AddItem(object item)
        {
            listView.AddItem(item);
        }

        public void StartDragging(object item, PointerEventData eventData)
        {
            if (!canReorderItems)
            {
                return;
            }

            isDragging = true;
            draggingItem = item;

            //TODO: Create drag reference.
            CreateDragItemReference(item, eventData);

            pointer = eventData;
            pointerLastYPos = -1f;
            nextPointerValidation = POINTER_VALIDATE_INTERVAL;

            UpdateDragging();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!canReorderItems || !isDragging)
            {
                return;
            }

            float contentYPos = pointerLastYPos + scroll.content.anchoredPosition.y;
            int dataIndex = (int)contentYPos / (int)itemHeight;

            object target = listView.GetItem(dataIndex);
            RecycledListItem listItem = listView.GetListItem(dataIndex);
            if (target == null)
            {
                InvokeOnReparent(draggingItem, target, ItemDropAction.SetLastChild);
            }
            else
            {
                int insertDirection = 0;
                float relativePosition = contentYPos % itemHeight;
                if (relativePosition < siblingIndexModificationArea)
                {
                    insertDirection = -1;
                }
                else if (relativePosition > itemHeight - siblingIndexModificationArea)
                {
                    insertDirection = 1;
                }

                if (insertDirection != 0)
                {
                    if (insertDirection < 0 && dataIndex > 0)
                    {
                        object newTarget = listView.GetItem(dataIndex - 1);
                        if (newTarget != null)
                        {
                            target = newTarget;
                            listItem = listView.GetListItem(dataIndex - 1);
                            insertDirection = 1;
                        }
                    }
                    else if (insertDirection > 0 && dataIndex < listView.ItemCount - 1)
                    {
                        object newTarget = listView.GetItem(dataIndex + 1);
                        if (newTarget != null)
                        {
                            listItem = listView.GetListItem(dataIndex + 1);
                            target = newTarget;
                            insertDirection = -1;
                        }
                    }
                }

                // Dropped onto self.
                if (target == null || target == draggingItem)
                {
                    StopDragging();
                    return;
                }


                int targetIndex = listView.IndexOf(target);

                switch (insertDirection)
                {
                    case 0:
                        listView.RemoveItem(draggingItem);
                        InvokeOnReparent(draggingItem, target, ItemDropAction.SetLastChild);
                        break;
                    case -1:
                        listView.MoveItem(draggingItem, targetIndex);
                        InvokeOnReparent(draggingItem, target, ItemDropAction.SetPreviousSibling);
                        break;
                    case 1:
                        listView.MoveItem(draggingItem, targetIndex + 1);
                        InvokeOnReparent(draggingItem, target, ItemDropAction.SetNextSibling);
                        break;
                }
            }

            draggingItem = null;
            StopDragging();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!eventData.dragging || !isDragging)
            {
                return;
            }

            StartDragging(draggingItem, eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            bool oldDragging = isDragging;
            StopDragging();
            isDragging = oldDragging;
        }

        private void StopDragging()
        {
            pointer = null;
            canvasCamera = null;
            isDragging = false;

            if (dragDropTargetVisual != null && dragDropTargetVisual.gameObject.activeSelf)
            {
                dragDropTargetVisual.gameObject.SetActive(false);
            }

            autoScrollSpeed = 0;
        }

        protected virtual RecycledListItem CreateItem()
        {
            throw new NotImplementedException("Make sure to override CreateItem!");
        }

        protected virtual void BindItem(int index, object obj, RecycledListItem item)
        {
            throw new NotImplementedException("Make sure to override BindItem!");
        }

        private void CreateDragItemReference(object reference, PointerEventData draggingPointer)
        {

        }

        protected virtual void InvokeOnReparent(object draggingItem, object target, ItemDropAction action)
        {
            throw new NotImplementedException("Make sure to override InvokeOnReparent!");
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
            if (scroll == null)
            {
                scroll = GetComponent<ScrollRect>();
            }

            if (listView == null)
            {
                listView = GetComponent<RecycledListView>();
            }
        }
#endif
    }

    public class TreeBindItemEventArgs<T, TItem> : EventArgs
    {
        public int Index { get; private set; }
        public TItem Item { get; private set; }
        public T TreeItem { get; private set; }

        public TreeBindItemEventArgs(int index, TItem item, T treeItem)
        {
            Index = index;
            Item = item;
            TreeItem = treeItem;
        }
    }

    public class TreeReparentEventArgs<T> : EventArgs
    {
        public T DraggingItem { get; private set; }
        public T Target { get; private set; }
        public ItemDropAction Action { get; private set; }

        public TreeReparentEventArgs(T draggingItem, T target, ItemDropAction action)
        {
            DraggingItem = draggingItem;
            Target = target;
            Action = action;
        }
    }

    public class TreeExpandingEventArgs<T> : EventArgs
    {
        public T Parent { get; private set; }
        public bool IsExpanded { get; private set; }
        public List<T> Children { get; private set; }

        public TreeExpandingEventArgs(T parent, bool isExpanded)
        {
            Parent = parent;
            IsExpanded = isExpanded;
            Children = new List<T>();
        }
    }

    public abstract class TreeControl<TTreeItem, TItem> : TreeControl where TTreeItem : RecycledListItem, ITreeItem
    {
        [SerializeField]
        private TTreeItem itemPrefab = null;

        public event EventHandler<TreeBindItemEventArgs<TTreeItem, TItem>> OnBindItem;
        public event EventHandler<TreeReparentEventArgs<TItem>> OnReparent;
        public event EventHandler<TreeExpandingEventArgs<TItem>> OnItemExpandingCollapsing;

        private Func<TItem, TItem> getParent;
        private Func<TItem, List<TItem>> getChildren;

        private Dictionary<object, bool> expandedStates = new Dictionary<object, bool>();

        protected override void Awake()
        {
            base.Awake();

            listView.Initialize(null, ((RectTransform)itemPrefab.transform).sizeDelta.y);
        }

        public void Initialize(Func<TItem, TItem> getParent, Func<TItem, List<TItem>> getChildren)
        {
            this.getParent = getParent;
            this.getChildren = getChildren;
        }

        protected override float GetItemHeight()
        {
            return ((RectTransform)itemPrefab.transform).rect.height;
        }

        protected override void BindItem(int index, object obj, RecycledListItem item)
        {
            ((TTreeItem)item).Item = obj;
            int depth = 0;
            TItem parent = getParent((TItem)obj);

            while (parent != null)
            {
                parent = getParent(parent);
                depth++;
            }
            ((TTreeItem)item).Depth = depth;

            TreeBindItemEventArgs<TTreeItem, TItem> args = new TreeBindItemEventArgs<TTreeItem, TItem>(index, (TItem)obj, (TTreeItem)item);
            OnBindItem?.Invoke(this, args);
            if (args.TreeItem.HasChildren)
            {
                if (!expandedStates.TryGetValue(obj, out bool expanded))
                {
                    expanded = false;
                }
                args.TreeItem.SetIsExpandedWithoutNotify(expanded);
            }
        }

        protected override void InvokeOnReparent(object draggingItem, object target, ItemDropAction action)
        {
            TreeReparentEventArgs<TItem> args = new TreeReparentEventArgs<TItem>((TItem)draggingItem, (TItem)target, action);
            OnReparent?.Invoke(this, args);
            MoveChildren((TItem)draggingItem);

            ITreeItem listItem = (ITreeItem)listView.GetListItem(listView.IndexOf(target));

            if (listItem.Expanded && action == ItemDropAction.SetLastChild)
            {
                List<TItem> children = getChildren((TItem)target);
                listView.InsertItem(draggingItem, listView.IndexOf(target) + children.Count);
            }

            listView.UpdateList(false);
        }

        protected override RecycledListItem CreateItem()
        {
            TTreeItem item = Instantiate(itemPrefab);
            item.OnExpandedChanged.AddListener((expanded) => OnItemExpanded((TItem)item.Item, expanded));
            item.Initialize(this);
            return item;
        }

        private void OnItemExpanded(TItem item, bool isExpanded)
        {
            expandedStates[item] = isExpanded;

            if (isExpanded)
            {
                TreeExpandingEventArgs<TItem> args = new TreeExpandingEventArgs<TItem>(item, true);
                OnItemExpandingCollapsing?.Invoke(this, args);

                int parentIndex = listView.IndexOf(item);

                AddChildren(item, parentIndex);
            }
            else
            {
                TreeExpandingEventArgs<TItem> args = new TreeExpandingEventArgs<TItem>(item, false);
                OnItemExpandingCollapsing?.Invoke(this, args);

                for (int i = args.Children.Count - 1; i >= 0; i--)
                {
                    RemoveChildren(args.Children[i]);
                }

            }
            listView.UpdateList(false);
        }

        private void AddChildren(TItem parent, int parentIndex)
        {
            List<TItem> children = getChildren(parent);
            if (children == null || children.Count == 0)
            {
                listView.InsertItem(parent, parentIndex + 1, false);
            }
            else
            {
                for (int i = 0; i < children.Count; i++)
                {
                    listView.InsertItem(children[i], parentIndex + i + 1, false);
                }

                for (int i = 0; i < children.Count; i++)
                {
                    if (expandedStates.TryGetValue(children[i], out bool expanded) && expanded)
                    {
                        AddChildren(children[i], listView.IndexOf(children[i]));
                    }
                }
            }
        }

        private void RemoveChildren(TItem parent)
        {
            List<TItem> children = getChildren(parent);
            if (children == null || children.Count == 0)
            {
                listView.RemoveItem(parent, false);
                return;
            }

            for (int i = children.Count - 1; i >= 0; i--)
            {
                RemoveChildren(children[i]);
            }

            listView.RemoveItem(parent, false);
        }

        private void MoveChildren(TItem parent)
        {
            List<TItem> children = new List<TItem>();
            GetAllChildren(parent, children, true);
            if (children == null || children.Count == 0)
            {
                return;
            }

            int parentIndex = listView.IndexOf(parent);
            for (int i = 0; i < children.Count; i++)
            {
                Debug.Log(children[i]);
                listView.MoveItem(children[i], parentIndex + i + 1, false);
            }
        }

        private void GetAllChildren(TItem parent, List<TItem> list, bool expandedOnly)
        {
            List<TItem> children = getChildren(parent);
            if (children == null || children.Count == 0)
            {
                return;
            }

            for (int i = 0; i < children.Count; i++)
            {
                list.Add(children[i]);

                if (expandedOnly)
                {
                    if (!expandedStates.TryGetValue(children[i], out bool expanded))
                    {
                        expanded = false;
                    }

                    if (!expanded)
                    {
                        continue;
                    }
                }

                GetAllChildren(children[i], list, expandedOnly);
            }
        }
    }
}
