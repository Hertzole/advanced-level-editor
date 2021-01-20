using System;
using System.Collections.Generic;
using System.Linq;


namespace Hertzole.ALE.Editor
{
    // The TreeModel is a utility class working on a list of serializable TreeElements where the order and the depth of each TreeElement define
    // the tree structure. Note that the TreeModel itself is not serializable (in Unity we are currently limited to serializing lists/arrays) but the 
    // input list is.
    // The tree representation (parent and children references) are then build internally using TreeElementUtility.ListToTree (using depth 
    // values of the elements). 
    // The first element of the input list is required to have depth == -1 (the hiddenroot) and the rest to have
    // depth >= 0 (otherwise an exception will be thrown)

    public class TreeModel<T> where T : IEditorTreeViewItem<T>
    {
        private IList<T> data;
        private T root;
        private int maxID;

        public T Root { get { return root; } set { root = value; } }
        public event Action OnModelChanged;

        public int NumberOfDataElements
        {
            get { return data.Count; }
        }

        public TreeModel(IList<T> data)
        {
            SetData(data);
        }

        public T Find(int id)
        {
            return data.FirstOrDefault(element => element.TreeID == id);
        }

        public void SetData(IList<T> data)
        {
            Init(data);
        }

        void Init(IList<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Input data is null. Ensure input is a non-null list.");
            }

            this.data = data;
            if (this.data.Count > 0)
            {
                root = TreeElementUtility.ListToTree(data);
            }

            maxID = this.data.Max(e => e.TreeID);
        }

        public int GenerateUniqueID()
        {
            return ++maxID;
        }

        public IList<int> GetAncestors(int id)
        {
            List<int> parents = new List<int>();
            T element = Find(id);
            if (element != null)
            {
                while (element.Parent != null)
                {
                    parents.Add(element.Parent.TreeID);
                    element = element.Parent;
                }
            }
            return parents;
        }

        public IList<int> GetDescendantsThatHaveChildren(int id)
        {
            T searchFromThis = Find(id);
            if (searchFromThis != null)
            {
                return GetParentsBelowStackBased(searchFromThis);
            }
            return new List<int>();
        }

        IList<int> GetParentsBelowStackBased(T searchFromThis)
        {
            Stack<T> stack = new Stack<T>();
            stack.Push(searchFromThis);

            List<int> parentsBelow = new List<int>();
            while (stack.Count > 0)
            {
                T current = stack.Pop();
                if (current.HasChildren())
                {
                    parentsBelow.Add(current.TreeID);
                    foreach (T T in current.Children)
                    {
                        stack.Push(T);
                    }
                }
            }

            return parentsBelow;
        }

        public void RemoveElements(IList<int> elementIDs)
        {
            IList<T> elements = data.Where(element => elementIDs.Contains(element.TreeID)).ToArray();
            RemoveElements(elements);
        }

        public void RemoveElements(IList<T> elements)
        {
            foreach (T element in elements)
            {
                if (element.Equals(root))
                {
                    throw new ArgumentException("It is not allowed to remove the root element");
                }
            }

            IList<T> commonAncestors = TreeElementUtility.FindCommonAncestorsWithinList(elements);

            foreach (T element in commonAncestors)
            {
                element.Parent.Children.Remove(element);
                element.Parent = default;
            }

            TreeElementUtility.TreeToList(root, data);

            Changed();
        }

        public void AddElements(IList<T> elements, T parent, int insertPosition)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements), "elements is null");
            }

            if (elements.Count == 0)
            {
                throw new ArgumentNullException(nameof(elements), "elements Count is 0: nothing to add");
            }

            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent), "parent is null");
            }

            if (parent.Children == null)
            {
                parent.Children = new List<T>();
            }

            parent.Children.InsertRange(insertPosition, elements.Cast<T>());
            foreach (T element in elements)
            {
                element.Parent = parent;
                element.TreeDepth = parent.TreeDepth + 1;
                TreeElementUtility.UpdateDepthValues(element);
            }

            TreeElementUtility.TreeToList(root, data);

            Changed();
        }

        public void AddRoot(T root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root), "root is null");
            }

            if (data == null)
            {
                throw new InvalidOperationException("Internal Error: data list is null");
            }

            if (data.Count != 0)
            {
                throw new InvalidOperationException("AddRoot is only allowed on empty data list");
            }

            root.TreeID = GenerateUniqueID();
            root.TreeDepth = -1;
            data.Add(root);
        }

        public void AddElement(T element, T parent, int insertPosition)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "element is null");
            }

            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent), "parent is null");
            }

            if (parent.Children == null)
            {
                parent.Children = new List<T>();
            }

            parent.Children.Insert(insertPosition, element);
            element.Parent = parent;

            TreeElementUtility.UpdateDepthValues(parent);
            TreeElementUtility.TreeToList(root, data);

            Changed();
        }

        public void MoveElements(T parentElement, int insertionIndex, List<T> elements)
        {
            if (insertionIndex < 0)
            {
                throw new ArgumentException("Invalid input: insertionIndex is -1, client needs to decide what index elements should be reparented at");
            }

            // Invalid reparenting input
            if (parentElement == null)
            {
                return;
            }

            // We are moving items so we adjust the insertion index to accomodate that any items above the insertion index is removed before inserting
            if (insertionIndex > 0)
            {
                insertionIndex -= parentElement.Children.GetRange(0, insertionIndex).Count(elements.Contains);
            }

            // Remove draggedItems from their parents
            foreach (T draggedItem in elements)
            {
                draggedItem.Parent.Children.Remove(draggedItem);    // remove from old parent
                draggedItem.Parent = parentElement;                 // set new parent
            }

            if (parentElement.Children == null)
            {
                parentElement.Children = new List<T>();
            }

            // Insert dragged items under new parent
            parentElement.Children.InsertRange(insertionIndex, elements);

            TreeElementUtility.UpdateDepthValues(Root);
            TreeElementUtility.TreeToList(root, data);

            Changed();
        }

        private void Changed()
        {
            OnModelChanged?.Invoke();
        }
    }
}
