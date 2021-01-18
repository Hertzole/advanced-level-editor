using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorObject : IEquatable<ILevelEditorObject>
    {
        string ID { get; set; }
        int InstanceID { get; set; }

        GameObject MyGameObject { get; }

        ILevelEditorObject Parent { get; set; }

        List<ILevelEditorObject> Children { get; }

        IExposedToLevelEditor[] GetExposedComponents();

        void ApplyExposedData(LevelEditorComponentData[] components);

        void StartPlayMode();

        void StopPlayMode();

        void AddChildren(ILevelEditorObject child);

        void RemoveChildren(ILevelEditorObject child);
    }
}
