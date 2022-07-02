﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public enum ItemDropAction { SetLastChild, SetPreviousSibling, SetNextSibling }

    [RequireComponent(typeof(ScrollRect), typeof(RecycledListView))]
    public abstract class TreeControl : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private const float POINTER_VALIDATE_INTERVAL = 5f;

        [Header("Reorder")]
        [SerializeField]
        protected bool canReorderItems = true;
        [SerializeField]
        protected RectTransform dragDropTargetVisual;
        [SerializeField]
        private TreeItemReference dragItemReferencePrefab;

        [SerializeField]
        private float siblingIndexModificationArea = 5f;
        [SerializeField]
        private float scrollableArea = 75f;

        [Header("Selection")]
        [SerializeField]
        private bool canUnselect = true;

        [SerializeField]
        [HideInInspector]
        private ScrollRect scroll;
        [SerializeField]
        [HideInInspector]
        protected RecycledListView listView;

        private float autoScrollSpeed;
        private Canvas canvas;

        private object draggingItem;

        private TreeItemReference dragReferenceItem;
        private float height;
        protected bool initialized;

        private bool isDragging;
        private float itemHeight;
        private float nextPointerValidation;
        private float oneOverScrollableArea;

        private PointerEventData pointer;

        private float pointerLastYPos;
        private Canvas popupCanvas;

        private RectTransform rectTransform;
        protected object selectedItem;

        public object DraggingItem { get { return draggingItem; } }

        protected virtual void Awake()
        {
            rectTransform = (RectTransform)transform;

            canvas = GetComponentInParent<Canvas>();

            oneOverScrollableArea = 1f / scrollableArea;

            itemHeight = GetItemHeight();

            listView.OnCreateItem = CreateItem;
            listView.OnBindItem += BindItem;

            if (canReorderItems && dragDropTargetVisual != null)
            {
                dragDropTargetVisual.gameObject.SetActive(false);
            }
        }

        protected virtual void Update()
        {
            UpdateDragging();
            AutoScroll();
        }

        private void OnRectTransformDimensionsChange()
        {
            height = 0;
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
            
            if (target == null)
            {
                InvokeOnReparent(draggingItem, null, ItemDropAction.SetLastChild);
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
                            insertDirection = 1;
                        }
                    }
                    else if (insertDirection > 0 && dataIndex < listView.ItemCount - 1)
                    {
                        object newTarget = listView.GetItem(dataIndex + 1);
                        if (newTarget != null)
                        {
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
                        if (InvokeOnReparenting(draggingItem, target, ItemDropAction.SetLastChild))
                        {
                            listView.RemoveItem(draggingItem);
                            InvokeOnReparent(draggingItem, target, ItemDropAction.SetLastChild);
                        }

                        break;
                    case -1:
                        if (InvokeOnReparenting(draggingItem, target, ItemDropAction.SetPreviousSibling))
                        {
                            listView.MoveItem(draggingItem, targetIndex);
                            InvokeOnReparent(draggingItem, target, ItemDropAction.SetPreviousSibling);
                        }

                        break;
                    case 1:
                        if (InvokeOnReparenting(draggingItem, target, ItemDropAction.SetNextSibling))
                        {
                            listView.MoveItem(draggingItem, targetIndex + 1);
                            InvokeOnReparent(draggingItem, target, ItemDropAction.SetNextSibling);
                        }

                        break;
                }

                SelectItemInternal(draggingItem);
            }

            draggingItem = null;
            StopDragging();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!canUnselect)
            {
                return;
            }

            if (eventData.button == PointerEventData.InputButton.Left)
            {
                SelectItemInternal(null);
            }
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

        protected virtual void InternalInitialize()
        {
            if (initialized)
            {
                Debug.LogWarning(gameObject.name + " has already been initialized.");

                return;
            }

            initialized = true;
        }

        protected virtual float GetItemHeight()
        {
            return 0f;
        }

        protected virtual void UpdateDragging()
        {
            if (pointer == null || !canReorderItems)
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

        public void UpdateList()
        {
            listView.UpdateList();
        }

        public void SetItems(IEnumerable<object> items, bool updateList = true)
        {
            listView.SetItems(items, updateList);
        }

        public void AddItems(IEnumerable<object> items, bool updateList = true)
        {
            listView.AddItems(items, updateList);
        }

        public void AddItem(object item, bool updateList = true)
        {
            listView.AddItem(item, updateList);
        }

        public void RemoveItem(object item, bool updateList = true)
        {
            if (selectedItem == item)
            {
                SelectItemInternal(null);
            }

            listView.RemoveItem(item, updateList);
        }

        public void ClearItems()
        {
            SelectItemInternal(null);
            listView.ClearItems();
        }

        public void RebindItem(object item)
        {
            listView.BindItem(item);
        }

        public void StartDragging(object item, PointerEventData eventData)
        {
            if (!canReorderItems)
            {
                return;
            }

            isDragging = true;
            draggingItem = item;

            CreateDragItemReference(item, eventData, canvas);

            pointer = eventData;
            pointerLastYPos = -1f;
            nextPointerValidation = POINTER_VALIDATE_INTERVAL;

            UpdateDragging();
        }

        private void StopDragging()
        {
            pointer = null;
            isDragging = false;

            if (dragDropTargetVisual != null && dragDropTargetVisual.gameObject.activeSelf)
            {
                dragDropTargetVisual.gameObject.SetActive(false);
            }

            autoScrollSpeed = 0;
        }

        public void ToggleReferenceItem(bool enableItem)
        {
            if (dragReferenceItem == null && enableItem)
            {
                dragReferenceItem = Instantiate(dragItemReferencePrefab, popupCanvas.transform, false);
            }
            else
            {
                dragReferenceItem.gameObject.SetActive(enableItem);
            }
        }

        protected virtual void SelectItemInternal(object item, bool updateUI = true) { }

        protected virtual RecycledListItem CreateItem()
        {
            throw new NotImplementedException("Make sure to override CreateItem!");
        }

        protected virtual void BindItem(int index, object obj, RecycledListItem item)
        {
            throw new NotImplementedException("Make sure to override BindItem!");
        }

        private void CreateDragItemReference(object reference, PointerEventData draggingPointer, Canvas referenceCanvas)
        {
            if (dragItemReferencePrefab == null)
            {
                return;
            }

            bool hasCanvasChanged = CreatePopupCanvas(referenceCanvas);

            ToggleReferenceItem(true);

            if (hasCanvasChanged)
            {
                dragReferenceItem.Initialize(popupCanvas);
            }

            dragReferenceItem.SetPointer(draggingPointer);

            dragReferenceItem.SetContent(reference);
        }

        protected virtual void InvokeOnReparent(object draggingItem, object target, ItemDropAction action)
        {
            throw new NotImplementedException("Make sure to override InvokeOnReparent!");
        }

        protected virtual bool InvokeOnReparenting(object draggingItem, object target, ItemDropAction action)
        {
            throw new NotImplementedException("Make sure to override InvokeOnReparenting!");
        }

        private bool CreatePopupCanvas(Canvas referenceCanvas)
        {
            bool hasCanvasChanged = !popupCanvas;
            if (popupCanvas == null)
            {
                popupCanvas = new GameObject("Popup Canvas").AddComponent<Canvas>();
                popupCanvas.gameObject.AddComponent<CanvasScaler>();

                popupCanvas.renderMode = referenceCanvas.renderMode;
            }

            if (hasCanvasChanged)
            {
                // Forces canvas to rebuild.
                popupCanvas.gameObject.SetActive(false);
                popupCanvas.gameObject.SetActive(true);
            }

            return hasCanvasChanged;
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
        public TreeBindItemEventArgs(int index, TItem item, T treeItem)
        {
            Index = index;
            Item = item;
            TreeItem = treeItem;
        }

        public int Index { get; }
        public TItem Item { get; }
        public T TreeItem { get; }
    }

    public class TreeReparentEventArgs<T> : EventArgs
    {
        public TreeReparentEventArgs(T draggingItem, T target, ItemDropAction action)
        {
            DraggingItem = draggingItem;
            Target = target;
            Action = action;
        }

        public T DraggingItem { get; }
        public T Target { get; }
        public ItemDropAction Action { get; }
    }

    public class TreeReparentingEventArgs<T> : TreeReparentEventArgs<T>
    {
        public TreeReparentingEventArgs(T draggingItem, T target, ItemDropAction action) : base(draggingItem, target, action) { }
        public bool Cancel { get; set; }
    }

    public class TreeExpandingEventArgs<T> : EventArgs
    {
        public TreeExpandingEventArgs(T parent, bool isExpanded)
        {
            Parent = parent;
            IsExpanded = isExpanded;
            Children = new List<T>();
        }

        public T Parent { get; }
        public bool IsExpanded { get; }
        public List<T> Children { get; }
    }

    public class TreeSelectionArgs<T> : EventArgs
    {
        public TreeSelectionArgs(T oldItem, T newItem)
        {
            Old = oldItem;
            New = newItem;
        }

        public T Old { get; }
        public T New { get; }
    }

    public abstract class TreeControl<TTreeItem, TItem> : TreeControl where TTreeItem : RecycledListItem, ITreeItem
    {
        [SerializeField]
        private TTreeItem itemPrefab;

        private readonly Dictionary<object, bool> expandedStates = new Dictionary<object, bool>();
        private Func<TItem, List<TItem>> getChildren;

        private Func<TItem, TItem> getParent;

        public TItem SelectedItem { get { return (TItem)selectedItem; } }

        protected override void Awake()
        {
            base.Awake();

            listView.Initialize(null, ((RectTransform)itemPrefab.transform).sizeDelta.y);
        }

        public event EventHandler<TreeBindItemEventArgs<TTreeItem, TItem>> OnBindItem;
        public event EventHandler<TreeReparentingEventArgs<TItem>> OnReparenting;
        public event EventHandler<TreeReparentEventArgs<TItem>> OnReparent;
        public event EventHandler<TreeExpandingEventArgs<TItem>> OnItemExpandingCollapsing;
        public event EventHandler<TreeSelectionArgs<TItem>> OnSelectionChanged;

        public void Initialize(Func<TItem, TItem> getParent, Func<TItem, List<TItem>> getChildren)
        {
            this.getParent = getParent;
            this.getChildren = getChildren;

            InternalInitialize();
        }

        protected override void SelectItemInternal(object item, bool updateUI = true)
        {
            if (!initialized)
            {
                Debug.LogError($"{gameObject.name} needs to be initialized first! Call the Initialize method.", gameObject);

                return;
            }

            if (selectedItem == item)
            {
                return;
            }

            TItem oldItem = (TItem)selectedItem;

            if (updateUI)
            {
                if (item != null)
                {
                    ((ITreeItem)listView.GetListItem(listView.IndexOf(item))).Selected = true;
                }
                else
                {
                    listView.ForEachListItem((i, listItem) => ((ITreeItem)listItem).SetSelectedWithoutNotify(false));
                }
            }

            selectedItem = item;

            OnSelectionChanged?.Invoke(this, new TreeSelectionArgs<TItem>(oldItem, (TItem)selectedItem));
        }

        public void SelectItem(TItem item)
        {
            SelectItemInternal(item);
        }

        public void ExpandTo(TItem item)
        {
            TItem parent = getParent(item);
            do
            {
                OnItemExpanded(item, true, false);
                parent = getParent(parent);
            } while (parent != null || listView.HasItem(parent));

            listView.UpdateList(false);
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
            ((ITreeItem)item).SetSelectedWithoutNotify(selectedItem == obj);

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

        protected override bool InvokeOnReparenting(object draggingItem, object target, ItemDropAction action)
        {
            if (target == null)
            {
                return true;
            }
            
            TItem dragItem = (TItem) draggingItem;
            TItem targetItem = (TItem) target;

            // Checks if target has the draggingItem as parent.
            TItem parent = getParent.Invoke(targetItem);
            // Keep going until we find the draggingItem or we reach the root.
            while (!EqualityComparer<TItem>.Default.Equals(parent, default))
            {
                if (EqualityComparer<TItem>.Default.Equals(parent, dragItem))
                {
                    // The target is a child of the draggingItem, we can't reparent.
                    return false;
                }
                
                parent = getParent.Invoke(parent);
            }

            TreeReparentingEventArgs<TItem> args = new TreeReparentingEventArgs<TItem>(dragItem, targetItem, action);
            OnReparenting?.Invoke(this, args);

            return !args.Cancel;
        }

        protected override void InvokeOnReparent(object draggingItem, object target, ItemDropAction action)
        {
            TItem dragItem = (TItem) draggingItem;
            TItem targetItem = (TItem) target;

            TreeReparentEventArgs<TItem> args = new TreeReparentEventArgs<TItem>(dragItem, targetItem, action);
            OnReparent?.Invoke(this, args);
            if (action != ItemDropAction.SetLastChild)
            {
                MoveChildren(dragItem);
            }

            if (action == ItemDropAction.SetLastChild)
            {
                // If the target exists, add it as a child of the target.
                // Else just set it as the last item in the list.
                if (target != null)
                {
                    ITreeItem listItem = (ITreeItem)listView.GetListItem(listView.IndexOf(target));
                    List<TItem> children = new List<TItem>();
                    GetAllChildren(targetItem, children, true);

                    if (!listItem.Expanded)
                    {
                        listItem.SetIsExpandedWithoutNotify(true);
                        expandedStates[target] = true;

                        for (int i = children.Count - 1; i >= 0; i--)
                        {
                            listView.InsertItem(children[i], listView.IndexOf(target) + 1, false);
                        }
                    }
                    else
                    {
                        listView.InsertItem(draggingItem, listView.IndexOf(target) + children.Count, false);
                    }
                }
                else
                {
                    listView.MoveItem(draggingItem, listView.ItemCount, false);
                    SelectItem(dragItem);
                }
            }

            listView.UpdateList(false);
        }

        protected override RecycledListItem CreateItem()
        {
            TTreeItem item = Instantiate(itemPrefab);
            item.OnExpandedChanged.AddListener(expanded => OnItemExpanded((TItem)item.Item, expanded));
            item.OnSelected += OnItemSelected;
            item.Initialize(this);

            return item;
        }

        private void OnItemSelected(object sender, TreeItemSelectedEventArgs e)
        {
            SelectItemInternal(e.Item, false);
            
            listView.ForEachListItem((i, item) => { ((ITreeItem) item).SetSelectedWithoutNotify(i == e.Index); });
        }

        private void OnItemExpanded(TItem item, bool isExpanded, bool updateList = true)
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

            if (updateList)
            {
                listView.UpdateList(false);
            }
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
