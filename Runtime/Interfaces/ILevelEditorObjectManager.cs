using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorObjectManager
    {
        event Action<ILevelEditorObject> OnCreateObject;
        event Action<ILevelEditorObject> OnDeleteObject;

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
