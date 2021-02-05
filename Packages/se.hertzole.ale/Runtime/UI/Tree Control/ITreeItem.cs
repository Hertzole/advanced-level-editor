using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public interface ITreeItem
    {
        object Item { get; set; }

        bool HasChildren { get; set; }
        bool Expanded { get; set; }
        bool Selected { get; set; }

        int Depth { get; set; }

        List<object> Children { get; }

        LevelEditorExpander.ExpandEvent OnExpandedChanged { get; }
        event EventHandler<TreeItemSelectedEventArgs> OnSelected;

        void Initialize(TreeControl tree);

        void SetIsExpandedWithoutNotify(bool expanded);

        void SetSelectedWithoutNotify(bool selected);
    }
}
