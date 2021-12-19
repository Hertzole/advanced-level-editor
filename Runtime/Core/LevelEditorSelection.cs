using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorSelection : MonoBehaviour, ILevelEditorSelection
    {
        [SerializeField]
        [RequireType(typeof(ILevelEditorUndo))]
        private GameObject undo = default;

        private ILevelEditorUndo realUndo;
        
        public ILevelEditorObject Selection { get; private set; }

        public event EventHandler<SelectionEventArgs> OnSelectionChanged;

        private void Awake()
        {
            if (undo != null)
            {
                realUndo = undo.NeedComponent<ILevelEditorUndo>();
            }
        }

        public void SetSelection(ILevelEditorObject target, bool registerUndo = true)
        {
            if (Selection == target)
            {
                return;
            }

            ILevelEditorObject old = Selection;
            Selection = target;
            OnSelectionChanged?.Invoke(this, new SelectionEventArgs(old, target));

            if (registerUndo && realUndo != null)
            {
                realUndo.AddAction(new SelectObjectUndoAction(old, target));
            }
        }
        
#if UNITY_EDITOR
        private void Reset()
        {
            GetStandardComponents();
        }

        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (undo == null && TryGetComponent<ILevelEditorUndo>(out _))
            {
                undo = gameObject;
            }
        }
#endif
    }
}
