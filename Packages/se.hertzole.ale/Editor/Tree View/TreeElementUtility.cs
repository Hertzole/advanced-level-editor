using System;
using System.Collections.Generic;


namespace Hertzole.ALE.Editor
{

    // TreeElementUtility and TreeElement are useful helper classes for backend tree data structures.
    // See tests at the bottom for examples of how to use.

    public static class TreeElementUtility
    {
        public static void TreeToList<T>(T root, IList<T> result) where T : IEditorTreeViewItem<T>
        {
            if (result == null)
            {
                throw new NullReferenceException("The input 'IList<T> result' list is null");
            }

            result.Clear();

            Stack<T> stack = new Stack<T>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                T current = stack.Pop();
                result.Add(current);

                if (current.Children != null && current.Children.Count > 0)
                {
                    for (int i = current.Children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(current.Children[i]);
                    }
                }
            }
        }

        // Returns the root of the tree parsed from the list (always the first element).
        // Important: the first item and is required to have a depth value of -1. 
        // The rest of the items should have depth >= 0. 
        public static T ListToTree<T>(IList<T> list) where T : IEditorTreeViewItem<T>
        {
            return TreeUtility.ListToTree(list);
        }

        // Check state of input list
        public static void ValidateDepthValues<T>(IList<T> list) where T : IEditorTreeViewItem<T>
        {
            TreeUtility.ValidateDepthValues(list);
        }

        // For updating depth values below any given element e.g after reparenting elements
        public static void UpdateDepthValues<T>(T root) where T : IEditorTreeViewItem<T>
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root), "The root is null");
            }

            if (!root.HasChildren())
            {
                return;
            }

            Stack<T> stack = new Stack<T>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                T current = stack.Pop();
                if (current.Children != null)
                {
                    foreach (T child in current.Children)
                    {
                        child.TreeDepth = current.TreeDepth + 1;
                        stack.Push(child);
                    }
                }
            }
        }

        // Returns true if there is an ancestor of child in the elements list
        static bool IsChildOf<T>(T child, IList<T> elements) where T : IEditorTreeViewItem<T>
        {
            while (child != null)
            {
                child = child.Parent;
                if (elements.Contains(child))
                {
                    return true;
                }
            }
            return false;
        }

        public static IList<T> FindCommonAncestorsWithinList<T>(IList<T> elements) where T : IEditorTreeViewItem<T>
        {
            if (elements.Count == 1)
            {
                return new List<T>(elements);
            }

            List<T> result = new List<T>(elements);
            result.RemoveAll(g => IsChildOf(g, elements));
            return result;
        }
    }
}
