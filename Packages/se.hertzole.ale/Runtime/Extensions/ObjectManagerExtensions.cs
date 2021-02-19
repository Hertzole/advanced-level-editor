using UnityEngine;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static ILevelEditorResource GetResource(this ILevelEditorObjectManager x, string id)
        {
            return x.Resources.GetResource(id);
        }

        public static ILevelEditorResource GetResource(this ILevelEditorObjectManager x, int index)
        {
            return x.Resources.GetResource(index);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, bool registerUndo = true)
        {
            return x.CreateObject(resource, Vector3.zero, Quaternion.identity, null, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, bool registerUndo = true)
        {
            return x.CreateObject(resource, position, Quaternion.identity, null, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, null, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(resource, position, Quaternion.identity, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(resource, position, Quaternion.identity, null, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, null, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Transform parent, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(resource, position, Quaternion.identity, parent, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Transform parent, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, parent, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Quaternion rotation, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(resource, Vector3.zero, rotation, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Quaternion rotation, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, rotation, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Quaternion rotation, Transform parent, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(resource, Vector3.zero, rotation, parent, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Quaternion rotation, Transform parent, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, rotation, parent, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(resource, Vector3.zero, Quaternion.identity, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, Quaternion.identity, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Transform parent, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(resource, Vector3.zero, Quaternion.identity, parent, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Transform parent, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, Quaternion.identity, parent, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Quaternion rotation, bool registerUndo = true)
        {
            return x.CreateObject(resource, position, rotation, null, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, null, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Quaternion rotation, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(resource, position, rotation, null, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, null, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Quaternion rotation, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(resource, position, rotation, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation, Transform parent, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, parent, x.GetNextInstanceID(), registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation, Transform parent, int instanceID, bool registerUndo = true)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, parent, instanceID, registerUndo);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, LevelEditorObjectData data, bool registerUndo = false)
        {
            ILevelEditorObject obj = x.CreateObject(x.GetResource(data.id), Vector3.zero, Quaternion.identity, null, data.instanceId, registerUndo);
            obj.MyGameObject.name = data.name;
            obj.MyGameObject.SetActive(data.active);

            return obj;
        }
    }
}
