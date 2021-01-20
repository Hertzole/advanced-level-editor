using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public static class TreeUtility
    {
        // Returns the root of the tree parsed from the list (always the first element).
        // Important: the first item and is required to have a depth value of -1. 
        // The rest of the items should have depth >= 0. 
        public static T ListToTree<T>(IList<T> list, bool hasChildrenOnly = false) where T : IEditorTreeViewItem<T>
        {
            return AssignChildren(list, hasChildrenOnly)[0];
        }

        public static T[] AssignChildren<T>(IList<T> list, bool hasChildrenOnly = false) where T : IEditorTreeViewItem<T>
        {
            List<T> result = new List<T>(list);

            // Validate input
            ValidateDepthValues(result);

            // Clear old states
            foreach (T element in result)
            {
                element.Parent = default;
                element.Children = null;
            }

            // Set child and parent references using depth info
            for (int parentIndex = 0; parentIndex < result.Count; parentIndex++)
            {
                T parent = result[parentIndex];
                bool alreadyHasValidChildren = parent.Children != null;
                if (alreadyHasValidChildren)
                {
                    continue;
                }

                int parentDepth = parent.TreeDepth;
                int childCount = 0;

                // Count children based depth value, we are looking at children until it's the same depth as this object
                for (int i = parentIndex + 1; i < result.Count; i++)
                {
                    if (result[i].TreeDepth == parentDepth + 1)
                    {
                        childCount++;
                    }

                    if (result[i].TreeDepth <= parentDepth)
                    {
                        break;
                    }
                }

                // Fill child array
                List<T> childList = null;
                if (childCount != 0)
                {
                    childList = new List<T>(childCount); // Allocate once
                    childCount = 0;
                    for (int i = parentIndex + 1; i < result.Count; i++)
                    {
                        if (result[i].TreeDepth == parentDepth + 1)
                        {
                            list[i].Parent = parent;
                            childList.Add(result[i]);
                            childCount++;
                        }

                        if (result[i].TreeDepth <= parentDepth)
                        {
                            break;
                        }
                    }
                }

                parent.Children = childList;
            }

            if (hasChildrenOnly)
            {
                RemoveNonParents(result[0]);
            }

            return result.ToArray();
        }

        private static void RemoveNonParents<T>(T parent) where T : IEditorTreeViewItem<T>
        {
            if (parent.HasChildren())
            {
                for (int i = parent.Children.Count - 1; i >= 0; i--)
                {
                    if (parent.Children[i].HasChildren())
                    {
                        RemoveNonParents(parent.Children[i]);
                    }
                    else
                    {
                        parent.Children.RemoveAt(i);
                    }
                }
            }
        }

        public static void ValidateDepthValues<T>(IList<T> list) where T : IEditorTreeViewItem<T>
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("list should have items, count is 0, check before calling ValidateDepthValues", nameof(list));
            }

            if (list[0].TreeDepth != -1)
            {
                throw new ArgumentException("list item at index 0 should have a depth of -1 (since this should be the hidden root of the tree). Depth is: " + list[0].TreeDepth, nameof(list));
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                int depth = list[i].TreeDepth;
                int nextDepth = list[i + 1].TreeDepth;
                if (nextDepth > depth && nextDepth - depth > 1)
                {
                    throw new ArgumentException(string.Format("Invalid depth info in input list. Depth cannot increase more than 1 per row. Index {0} has depth {1} while index {2} has depth {3}", i, depth, i + 1, nextDepth));
                }
            }

            for (int i = 1; i < list.Count; ++i)
            {
                if (list[i].TreeDepth < 0)
                {
                    throw new ArgumentException("Invalid depth value for item at index " + i + ". Only the first item (the root) should have depth below 0.");
                }
            }

            if (list.Count > 1 && list[1].TreeDepth != 0)
            {
                throw new ArgumentException("Input list item at index 1 is assumed to have a depth of 0", nameof(list));
            }
        }
    }
}
