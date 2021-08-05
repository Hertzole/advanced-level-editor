using UnityEngine;

namespace Hertzole.ALE
{
    public class CreateObjectUndoAction : IUndoAction
    {
        private readonly ILevelEditorResource resource;
        private readonly Vector3 position;
        private readonly Quaternion rotation;
        private readonly Transform parent;
        private readonly uint instanceID;

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

        public void Redo(ILevelEditorUndo undo)
        {
            obj = undo.ObjectManager.CreateObject(resource, position, rotation, parent, instanceID, false);
        }

        public void Undo(ILevelEditorUndo undo)
        {
            undo.ObjectManager.DeleteObject(obj, false);
        }

        public override string ToString()
        {
            return $"CreateObjectUndoAction ({resource}, {position}, {rotation}, {parent}, {instanceID})";
        }
    }
}
