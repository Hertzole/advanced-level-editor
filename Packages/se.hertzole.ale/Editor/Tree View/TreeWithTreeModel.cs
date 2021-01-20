using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public class TreeViewItem<T> : TreeViewItem where T : IEditorTreeViewItem<T>
    {
        public T Data { get; set; }

        public TreeViewItem(int id, int depth, string displayName, T data) : base(id, depth, displayName)
        {
            Data = data;
        }
    }

    public class TreeViewWithTreeModel<T> : TreeView where T : IEditorTreeViewItem<T>
    {
        private TreeModel<T> treeModel;
        private readonly List<TreeViewItem> rows = new List<TreeViewItem>(100);

        public event Action OnTreeChanged;

        public TreeModel<T> TreeModel { get { return treeModel; } }
        public event Action<IList<TreeViewItem>> OnBeforeDroppingDraggedItems;

        public TreeViewWithTreeModel(TreeViewState state, TreeModel<T> model) : base(state)
        {
            Init(model);
        }

        public TreeViewWithTreeModel(TreeViewState state, MultiColumnHeader multiColumnHeader, TreeModel<T> model) : base(state, multiColumnHeader)
        {
            Init(model);
        }

        private void Init(TreeModel<T> model)
        {
            treeModel = model;
            treeModel.OnModelChanged += ModelChanged;
        }

        private void ModelChanged()
        {
            OnTreeChanged?.Invoke();

            Reload();
        }

        public void AddItemToRoot()
        {
            AddItem(treeModel.Root);
        }

        public void AddItemToSelection()
        {
            IList<int> selection = GetSelection();
            if (selection.Count == 1)
            {
                AddItem(treeModel.Find(selection[0]));
            }
        }

        internal virtual T GetItemInternal()
        {
            return default;
        }

        public void AddItem(T parent)
        {
            int depth = parent != null ? parent.TreeDepth + 1 : 0;
            int id = TreeModel.GenerateUniqueID();
            T element = GetItemInternal();
            element.TreeDepth = depth;
            element.TreeID = id;
            TreeModel.AddElement(element, parent, 0);
            SetSelection(new[] { id }, TreeViewSelectionOptions.RevealAndFrame);
            TreeViewItem newElement = FindItem(id, rootItem);
            BeginRename(newElement);
        }

        protected override TreeViewItem BuildRoot()
        {
            int depthForHiddenRoot = -1;
            return new TreeViewItem<T>(treeModel.Root.TreeID, depthForHiddenRoot, treeModel.Root.Name, treeModel.Root);
        }

        protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
        {
            if (treeModel.Root == null)
            {
                Debug.LogError("tree model root is null. did you call SetData()?");
            }

            rows.Clear();
            if (!string.IsNullOrEmpty(searchString))
            {
                Search(treeModel.Root, searchString, rows);
            }
            else
            {
                if (treeModel.Root.HasChildren())
                {
                    AddChildrenRecursive(treeModel.Root, 0, rows);
                }
            }

            // We still need to setup the child parent information for the rows since this 
            // information is used by the TreeView internal logic (navigation, dragging etc)
            SetupParentsAndChildrenFromDepths(root, rows);

            return rows;
        }

        private void AddChildrenRecursive(T parent, int depth, IList<TreeViewItem> newRows)
        {
            foreach (T child in parent.Children)
            {
                TreeViewItem<T> item = new TreeViewItem<T>(child.TreeID, depth, child.Name, child);
                newRows.Add(item);

                if (child.HasChildren())
                {
                    if (IsExpanded(child.TreeID))
                    {
                        AddChildrenRecursive(child, depth + 1, newRows);
                    }
                    else
                    {
                        item.children = CreateChildListForCollapsedParent();
                    }
                }
            }
        }

        private void Search(T searchFromThis, string search, List<TreeViewItem> result)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentException("Invalid search: cannot be null or empty", nameof(search));
            }

            const int kItemDepth = 0; // tree is flattened when searching

            Stack<T> stack = new Stack<T>();
            foreach (T element in searchFromThis.Children)
            {
                stack.Push(element);
            }

            while (stack.Count > 0)
            {
                T current = stack.Pop();
                // Matches search?
                if (current.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(new TreeViewItem<T>(current.TreeID, kItemDepth, current.Name, current));
                }

                if (current.Children != null && current.Children.Count > 0)
                {
                    foreach (T element in current.Children)
                    {
                        stack.Push(element);
                    }
                }
            }
            SortSearchResult(result);
        }

        protected virtual void SortSearchResult(List<TreeViewItem> rows)
        {
            rows.Sort((x, y) => EditorUtility.NaturalCompare(x.displayName, y.displayName)); // sort by displayName by default, can be overriden for multicolumn solutions
        }

        protected override IList<int> GetAncestors(int id)
        {
            return treeModel.GetAncestors(id);
        }

        protected override IList<int> GetDescendantsThatHaveChildren(int id)
        {
            return treeModel.GetDescendantsThatHaveChildren(id);
        }


        // Dragging
        //-----------

        const string k_GenericDragID = "GenericDragColumnDragging";

        protected override bool CanStartDrag(CanStartDragArgs args)
        {
            return true;
        }

        protected override void SetupDragAndDrop(SetupDragAndDropArgs args)
        {
            if (hasSearch)
            {
                return;
            }

            DragAndDrop.PrepareStartDrag();
            List<TreeViewItem> draggedRows = GetRows().Where(item => args.draggedItemIDs.Contains(item.id)).ToList();
            DragAndDrop.SetGenericData(k_GenericDragID, draggedRows);
            DragAndDrop.objectReferences = new UnityEngine.Object[] { }; // this IS required for dragging to work
            string title = draggedRows.Count == 1 ? draggedRows[0].displayName : "< Multiple >";
            DragAndDrop.StartDrag(title);
        }

        protected override DragAndDropVisualMode HandleDragAndDrop(DragAndDropArgs args)
        {
            // Check if we can handle the current drag data (could be dragged in from other areas/windows in the editor)
            List<TreeViewItem> draggedRows = DragAndDrop.GetGenericData(k_GenericDragID) as List<TreeViewItem>;
            if (draggedRows == null)
            {
                return DragAndDropVisualMode.None;
            }

            // Parent item is null when dragging outside any tree view items.
            switch (args.dragAndDropPosition)
            {
                case DragAndDropPosition.UponItem:
                case DragAndDropPosition.BetweenItems:
                    {
                        bool validDrag = ValidDrag(args.parentItem, draggedRows);
                        if (args.performDrop && validDrag)
                        {
                            T parentData = ((TreeViewItem<T>)args.parentItem).Data;
                            OnDropDraggedElementsAtIndex(draggedRows, parentData, args.insertAtIndex == -1 ? 0 : args.insertAtIndex);
                        }
                        return validDrag ? DragAndDropVisualMode.Move : DragAndDropVisualMode.None;
                    }

                case DragAndDropPosition.OutsideItems:
                    {
                        if (args.performDrop)
                        {
                            OnDropDraggedElementsAtIndex(draggedRows, treeModel.Root, treeModel.Root.Children.Count);
                        }

                        return DragAndDropVisualMode.Move;
                    }
                default:
                    Debug.LogError("Unhandled enum " + args.dragAndDropPosition);
                    return DragAndDropVisualMode.None;
            }
        }

        public virtual void OnDropDraggedElementsAtIndex(List<TreeViewItem> draggedRows, T parent, int insertIndex)
        {
            OnBeforeDroppingDraggedItems?.Invoke(draggedRows);

            List<T> draggedElements = new List<T>();
            foreach (TreeViewItem x in draggedRows)
            {
                draggedElements.Add(((TreeViewItem<T>)x).Data);
            }

            int[] selectedIDs = draggedElements.Select(x => x.TreeID).ToArray();
            treeModel.MoveElements(parent, insertIndex, draggedElements);
            SetSelection(selectedIDs, TreeViewSelectionOptions.RevealAndFrame);
        }

        private bool ValidDrag(TreeViewItem parent, List<TreeViewItem> draggedItems)
        {
            TreeViewItem currentParent = parent;
            while (currentParent != null)
            {
                if (draggedItems.Contains(currentParent))
                {
                    return false;
                }

                currentParent = currentParent.parent;
            }
            return true;
        }
    }
}
