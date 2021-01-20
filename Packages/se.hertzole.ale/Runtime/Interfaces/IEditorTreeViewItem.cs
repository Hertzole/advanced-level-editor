using System.Collections.Generic;

namespace Hertzole.ALE
{
    public interface IEditorTreeViewItem<T>
    {
        public int TreeID { get; set; }
        public int TreeDepth { get; set; }
        public string Name { get; set; }

        public T Parent { get; set; }
        public List<T> Children { get; set; }
    }
}
