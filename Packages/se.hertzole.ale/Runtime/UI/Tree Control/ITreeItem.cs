using System.Collections.Generic;

namespace Hertzole.ALE
{
    public interface ITreeItem
    {
        object Item { get; set; }

        bool HasChildren { get; set; }
        bool Expanded { get; set; }

        int Depth { get; set; }

        List<object> Children { get; }

        TreeItemExpander.ExpandEvent OnExpandedChanged { get; }

        void Initialize(TreeControl tree);

        void SetIsExpandedWithoutNotify(bool expanded);
    }
}
