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
        
        public bool HandleUndoRedoInput { get { return handleUndoRedoInput; } set { handleUndoRedoInput = value; } }

        public ILevelEditorObjectManager ObjectManager
        {
            get
            {
                if (objectManagerComp == null && objectManager != null)
                {
                    objectManagerComp = objectManager.GetComponent<ILevelEditorObjectManager>();
                }

                return objectManagerComp;
            }
            set { objectManagerComp = value; }
        }
        public ILevelEditorInput Input 
        {
            get
            {
                if (inputComp == null && input != null)
                {
                    inputComp = input.GetComponent<ILevelEditorInput>();
                }

                return inputComp;
            }
            set { inputComp = value; } 
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
            if (Input.GetButton(modifierAction))
            {
                if (Input.GetButtonDown(undoAction))
                {
                    Undo();
                }

                if (Input.GetButtonDown(redoAction))
                {
                    Redo();
                }
            }
        }

        public void AddAction(IUndoAction action, bool execute)
        {
            LevelEditorLogger.Log($"Add undo action | Action: {action} | Execute: {execute}");
            
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
            LevelEditorLogger.Log($"Undo | Counter: {counter}");
            
            if (counter > 0)
            {
                counter--;
                LevelEditorLogger.Log($"Undo {actionHistory[counter]}");
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
