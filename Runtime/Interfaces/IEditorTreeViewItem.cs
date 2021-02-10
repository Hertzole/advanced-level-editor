using System.Collections.Generic;

namespace Hertzole.ALE
{
    public interface IEditorTreeViewItem<T>
    {
        int TreeID { get; set; }
        int TreeDepth { get; set; }
        string Name { get; set; }

        T Parent { get; set; }
        List<T> Children { get; set; }
    }
}
