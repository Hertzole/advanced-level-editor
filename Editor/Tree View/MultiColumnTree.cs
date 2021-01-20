using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Editor
{
    public abstract class MultiColumnTreeView<T, TSort, TColumns> : TreeViewWithTreeModel<T> where T : IEditorTreeViewItem<T> where TSort : Enum where TColumns : Enum
    {
        protected abstract TSort[] SortOptions { get; }

        protected virtual float RowHeight { get { return 20f; } }
        protected virtual bool ShowControls { get; set; } = true;
        protected virtual int ColumnIndexForTreeFoldouts { get { return 1; } }

        protected virtual bool ShowBorder { get { return true; } }
        protected virtual bool ShowAlternatingRowBackgrounds { get { return true; } }

        public static void TreeToList(TreeViewItem root, IList<TreeViewItem> result)
        {
            if (root == null)
            {
                throw new NullReferenceException("root");
            }

            if (result == null)
            {
                throw new NullReferenceException("result");
            }

            result.Clear();

            if (root.children == null)
            {
                return;
            }

            Stack<TreeViewItem> stack = new Stack<TreeViewItem>();
            for (int i = root.children.Count - 1; i >= 0; i--)
            {
                stack.Push(root.children[i]);
            }

            while (stack.Count > 0)
            {
                TreeViewItem current = stack.Pop();
                result.Add(current);

                if (current.hasChildren && current.children[0] != null)
                {
                    for (int i = current.children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(current.children[i]);
                    }
                }
            }
        }

        public MultiColumnTreeView(TreeViewState state, TreeModel<T> model) : base(state, model)
        {
            Assert.AreEqual(SortOptions.Length, Enum.GetValues(typeof(TColumns)).Length, "Ensure number of sort options are in sync with number of TColumns enum values");

            MultiColumnHeaderState headerState = CreateDefaultMultiColumnHeaderState();

            MultiColumnHeader columnHeader = new MultiColumnHeader(headerState);
            columnHeader.canSort = false;
            multiColumnHeader = columnHeader;

            // Custom setup
            rowHeight = RowHeight;
            columnIndexForTreeFoldouts = ColumnIndexForTreeFoldouts;
            showAlternatingRowBackgrounds = ShowAlternatingRowBackgrounds;
            showBorder = ShowBorder;
            customFoldoutYOffset = (RowHeight - EditorGUIUtility.singleLineHeight) * 0.5f; // center foldout in the row since we also center content. See RowGUI
            //extraSpaceBeforeIconAndLabel = ToggleWidth;
            columnHeader.sortingChanged += OnSortingChanged;

            Reload();
        }

        internal override T GetItemInternal()
        {
            return GetNewItem();
        }

        protected abstract T GetNewItem();

        // Note we We only build the visible rows, only the backend has the full tree information. 
        // The treeview only creates info for the row list.
        protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
        {
            IList<TreeViewItem> rows = base.BuildRows(root);
            SortIfNeeded(root, rows);
            return rows;
        }

        void OnSortingChanged(MultiColumnHeader multiColumnHeader)
        {
            SortIfNeeded(rootItem, GetRows());
        }

        void SortIfNeeded(TreeViewItem root, IList<TreeViewItem> rows)
        {
            if (rows.Count <= 1)
            {
                return;
            }

            if (multiColumnHeader.sortedColumnIndex == -1)
            {
                return; // No column to sort for (just use the order the data are in)
            }

            // Sort the roots of the existing tree items
            SortByMultipleColumns();
            TreeToList(root, rows);
            Repaint();
        }

        protected abstract IOrderedEnumerable<TreeViewItem<T>> Sort(TSort sortOption, IEnumerable<TreeViewItem<T>> items, bool ascending);

        private void SortByMultipleColumns()
        {
            int[] sortedColumns = multiColumnHeader.state.sortedColumns;

            if (sortedColumns.Length == 0)
            {
                return;
            }

            IEnumerable<TreeViewItem<T>> myTypes = rootItem.children.Cast<TreeViewItem<T>>();
            IOrderedEnumerable<TreeViewItem<T>> orderedQuery = InitialOrder(myTypes, sortedColumns);
            for (int i = 1; i < sortedColumns.Length; i++)
            {
                TSort sortOption = SortOptions[sortedColumns[i]];
                bool ascending = multiColumnHeader.IsSortedAscending(sortedColumns[i]);

                orderedQuery = Sort(sortOption, orderedQuery, ascending);
            }

            rootItem.children = orderedQuery.Cast<TreeViewItem>().ToList();
        }

        private IOrderedEnumerable<TreeViewItem<T>> InitialOrder(IEnumerable<TreeViewItem<T>> myTypes, int[] history)
        {
            TSort sortOption = SortOptions[history[0]];
            bool ascending = multiColumnHeader.IsSortedAscending(history[0]);

            return Sort(sortOption, myTypes, ascending);
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            TreeViewItem<T> item = (TreeViewItem<T>)args.item;

            for (int i = 0; i < args.GetNumVisibleColumns(); ++i)
            {
                CellGUI(args.GetCellRect(i), item, (TColumns)(object)args.GetColumn(i), ref args);
            }
        }

        protected void CellLabelGUI(Rect cellRect, RowGUIArgs args)
        {
            args.rowRect = cellRect;
            base.RowGUI(args);
        }

        protected abstract void CellGUI(Rect cellRect, TreeViewItem<T> item, TColumns column, ref RowGUIArgs args);

        // Rename
        //--------

        protected override bool CanRename(TreeViewItem item)
        {
            // Only allow rename if we can show the rename overlay with a certain width (label might be clipped by other columns)
            Rect renameRect = GetRenameRect(treeViewRect, 0, item);
            return renameRect.width > 30;
        }

        protected override void RenameEnded(RenameEndedArgs args)
        {
            // Set the backend name and reload the tree to reflect the new model
            if (args.acceptedRename)
            {
                T element = TreeModel.Find(args.itemID);
                element.Name = args.newName;
                Reload();
            }
        }

        protected override Rect GetRenameRect(Rect rowRect, int row, TreeViewItem item)
        {
            Rect cellRect = GetCellRectForTreeFoldouts(rowRect);
            CenterRectUsingSingleLineHeight(ref cellRect);
            return base.GetRenameRect(cellRect, row, item);
        }

        // Misc
        //--------

        protected override bool CanMultiSelect(TreeViewItem item)
        {
            return true;
        }

        private MultiColumnHeaderState CreateDefaultMultiColumnHeaderState()
        {
            MultiColumnHeaderState.Column[] columns = CreateColumns();
            Assert.AreEqual(columns.Length, Enum.GetValues(typeof(TColumns)).Length, "Number of columns should match number of enum values: You probably forgot to update one of them.");

            MultiColumnHeaderState state = new MultiColumnHeaderState(columns);
            return state;
        }

        protected abstract MultiColumnHeaderState.Column[] CreateColumns();
    }

    public static class TreeViewExtensions
    {
        public static IOrderedEnumerable<T> Order<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector, bool ascending)
        {
            if (ascending)
            {
                return source.OrderBy(selector);
            }
            else
            {
                return source.OrderByDescending(selector);
            }
        }

        public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> selector, bool ascending)
        {
            if (ascending)
            {
                return source.ThenBy(selector);
            }
            else
            {
                return source.ThenByDescending(selector);
            }
        }
    }
}
