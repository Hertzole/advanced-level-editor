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

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id)
        {
            return x.CreateObject(x.GetResource(id));
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource)
        {
            return x.CreateObject(resource, Vector3.zero, Quaternion.identity, null, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position)
        {
            return x.CreateObject(resource, position, Quaternion.identity, null, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, null, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Transform parent)
        {
            return x.CreateObject(resource, position, Quaternion.identity, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Transform parent)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, int instanceID)
        {
            return x.CreateObject(resource, position, Quaternion.identity, null, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, int instanceID)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, null, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Transform parent, int instanceID)
        {
            return x.CreateObject(resource, position, Quaternion.identity, parent, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Transform parent, int instanceID)
        {
            return x.CreateObject(x.GetResource(id), position, Quaternion.identity, parent, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Quaternion rotation, Transform parent)
        {
            return x.CreateObject(resource, Vector3.zero, rotation, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Quaternion rotation, Transform parent)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, rotation, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Quaternion rotation, Transform parent, int instanceID)
        {
            return x.CreateObject(resource, Vector3.zero, rotation, parent, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Quaternion rotation, Transform parent, int instanceID)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, rotation, parent, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Transform parent)
        {
            return x.CreateObject(resource, Vector3.zero, Quaternion.identity, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Transform parent)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, Quaternion.identity, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Transform parent, int instanceID)
        {
            return x.CreateObject(resource, Vector3.zero, Quaternion.identity, parent, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Transform parent, int instanceID)
        {
            return x.CreateObject(x.GetResource(id), Vector3.zero, Quaternion.identity, parent, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Quaternion rotation)
        {
            return x.CreateObject(resource, position, rotation, null, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, null, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Quaternion rotation, int instanceID)
        {
            return x.CreateObject(resource, position, rotation, null, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation, int instanceID)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, null, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, ILevelEditorResource resource, Vector3 position, Quaternion rotation, Transform parent)
        {
            return x.CreateObject(resource, position, rotation, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation, Transform parent)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, parent, x.GetNextInstanceID());
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, string id, Vector3 position, Quaternion rotation, Transform parent, int instanceID)
        {
            return x.CreateObject(x.GetResource(id), position, rotation, parent, instanceID);
        }

        public static ILevelEditorObject CreateObject(this ILevelEditorObjectManager x, LevelEditorObjectData data)
        {
            ILevelEditorObject obj = x.CreateObject(x.GetResource(data.id), Vector3.zero, Quaternion.identity, null, data.instanceId);
            obj.MyGameObject.name = data.name;
            obj.MyGameObject.SetActive(data.active);

            return obj;
        }
    }
}
