using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorObjectEvent : EventArgs
    {
        public LevelEditorObjectEvent(ILevelEditorObject levelEditorObject)
        {
            Object = levelEditorObject;
        }

        public ILevelEditorObject Object { get; private set; }
    }

    public class LevelEditorObjectEventSpawningEvent : EventArgs
    {
        public bool Cancel { get; set; }

        public ILevelEditorResource Resource { get; private set; }

        public LevelEditorObjectEventSpawningEvent(ILevelEditorResource resource)
        {
            Resource = resource;
        }
    }

    public class LevelEditorObjectEventDeletingEvent : EventArgs
    {
        public bool Cancel { get; set; }

        public ILevelEditorObject Object { get; private set; }

        public LevelEditorObjectEventDeletingEvent(ILevelEditorObject levelEditorObject)
        {
            Object = levelEditorObject;
        }
    }

    public interface ILevelEditorObjectManager
    {
        event EventHandler<LevelEditorObjectEventSpawningEvent> OnCreatingObject;
        event EventHandler<LevelEditorObjectEventDeletingEvent> OnDeletingObject;

        event EventHandler<LevelEditorObjectEvent> OnCreatedObject;
        event EventHandler<LevelEditorObjectEvent> OnCreatedObjectFromSaveData;
        event EventHandler<LevelEditorObjectEvent> OnDeletedObject;

        ILevelEditorResources Resources { get; }

        ILevelEditorObject CreateObject(ILevelEditorResource resource, Vector3 position, Quaternion rotation, Transform parent, int instanceID);

        void CreateObjectsFromSaveData(LevelEditorSaveData data);

        bool DeleteObject(ILevelEditorObject target);

        void DeleteAllObjects();

        void ResetInstanceID();

        List<ILevelEditorObject> GetAllObjects();

        ILevelEditorObject GetObject(int instanceID);

        int GetObjectCount(string id);

        int GetTotalObjectCount();

        int GetNextInstanceID();
    }
}
