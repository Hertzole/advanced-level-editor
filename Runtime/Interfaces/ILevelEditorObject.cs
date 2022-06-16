using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorObjectStateArgs : EventArgs
    {
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public LevelEditorObjectStateArgs(string name, bool active)
        {
            Name = name;
            Active = active;
        }
    }

    public interface ILevelEditorObject : IEquatable<ILevelEditorObject>
    {
        string Name { get; set; }
        bool IsActive { get; set; }
        bool IsDestroyed { get; }

        LevelEditorIdentifier ID { get; set; }
        uint InstanceID { get; set; }

        GameObject MyGameObject { get; }

        ILevelEditorObject Parent { get; set; }
        List<ILevelEditorObject> Children { get; }

        event EventHandler<LevelEditorObjectStateArgs> OnStateChanged;

        IExposedToLevelEditor[] GetExposedComponents();

        void ApplyExposedData(LevelEditorComponentData[] components);

        void StartPlayMode();

        void StopPlayMode();

        void AddChild(ILevelEditorObject child);

        void RemoveChild(ILevelEditorObject child);

        void OnPooled();

        void OnUnPooled();
    }
}
