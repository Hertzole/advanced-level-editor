using UnityEngine;

namespace Hertzole.ALE
{
    public class CreateObjectUndoAction : IUndoAction
    {
        private ILevelEditorResource resource;
        private Vector3 position;
        private Quaternion rotation;
        private Transform parent;
        private uint instanceID;

        private ILevelEditorObject obj;

        public CreateObjectUndoAction(ILevelEditorResource resource, Vector3 position, Quaternion rotation, Transform parent, uint instanceID, ILevelEditorObject obj)
        {
            this.resource = resource;
            this.position = position;
            this.rotation = rotation;
            this.parent = parent;
            this.instanceID = instanceID;
            this.obj = obj;
        }

        public void Execute(ILevelEditorUndo undo)
        {
            obj = undo.ObjectManager.CreateObject(resource, position, rotation, parent, instanceID, false);
        }

        public void Undo(ILevelEditorUndo undo)
        {
            undo.ObjectManager.DeleteObject(obj);
        }

        public void DisposeAction(ILevelEditorUndo undo)
        {
            //TOOD: Finally delete object.
        }

        public override string ToString()
        {
            return $"CreateObjectUndoAction ({resource}, {position}, {rotation}, {parent}, {instanceID})";
        }
    }
}
