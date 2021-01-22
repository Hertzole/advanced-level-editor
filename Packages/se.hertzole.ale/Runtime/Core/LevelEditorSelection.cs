using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorSelection : MonoBehaviour, ILevelEditorSelection
    {
        private ILevelEditorObject selection;

        public ILevelEditorObject Selection { get { return selection; } set { SetSelection(value); } }

        public event EventHandler<SelectionEvent> OnSelectionChanged;

        private void SetSelection(ILevelEditorObject target)
        {
            if (selection == target)
            {
                return;
            }

            ILevelEditorObject old = selection;
            selection = target;
            OnSelectionChanged?.Invoke(this, new SelectionEvent(old, target));
        }
    }
}
