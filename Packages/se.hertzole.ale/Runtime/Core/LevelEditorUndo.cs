using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorUndo : MonoBehaviour, ILevelEditorUndo
    {
#if UNITY_EDITOR
        [Header("References")]
#endif
        [SerializeField, RequireType(typeof(ILevelEditorObjectManager))]
        private GameObject objectManager = null;
        [SerializeField, RequireType(typeof(ILevelEditorInput))]
        private GameObject input = null;

#if UNITY_EDITOR
        [Header("Input")]
#endif
        [SerializeField]
        private bool handleUndoRedoInput = true;
        [SerializeField]
        private string modifierAction = "Ctrl Modifier";
        [SerializeField]
        private string undoAction = "Undo";
        [SerializeField]
        private string redoAction = "Redo";

        private int counter = 0;

        private ILevelEditorObjectManager objectManagerComp;
        private ILevelEditorInput inputComp;

        private List<IUndoAction> actionHistory = new List<IUndoAction>();

        public ILevelEditorObjectManager ObjectManager { get { return objectManagerComp; } }

        private void Awake()
        {
            objectManagerComp = objectManager.NeedComponent<ILevelEditorObjectManager>();
            inputComp = input.NeedComponent<ILevelEditorInput>();
        }

        private void Update()
        {
            if (handleUndoRedoInput)
            {
                HandleInput();
            }
        }

        protected virtual void HandleInput()
        {
            if (inputComp.GetButton(modifierAction))
            {
                if (inputComp.GetButtonDown(undoAction))
                {
                    Undo();
                }

                if (inputComp.GetButtonDown(redoAction))
                {
                    Redo();
                }
            }
        }

        public void AddAction(IUndoAction action, bool execute)
        {
            // Remove the actions above if we cut into the history.
            while (actionHistory.Count > counter)
            {
                actionHistory.RemoveAt(counter);
            }

            actionHistory.Add(action);
            counter++;

            if (execute)
            {
                action.Execute(this);
            }
        }

        public void Redo()
        {
            if (counter < actionHistory.Count)
            {
                actionHistory[counter].Execute(this);
                counter++;
            }
        }

        public void Undo()
        {
            if (counter > 0)
            {
                counter--;
                actionHistory[counter].Undo(this);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (objectManager == null)
            {
                if (TryGetComponent<ILevelEditorObjectManager>(out _))
                {
                    objectManager = gameObject;
                }
            }

            if (input == null)
            {
                if (TryGetComponent<ILevelEditorInput>(out _))
                {
                    input = gameObject;
                }
            }
        }
#endif
    }
}
