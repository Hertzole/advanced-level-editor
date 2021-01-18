using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorObject : MonoBehaviour, ILevelEditorObject
    {
        public string ID
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int InstanceID
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        public GameObject MyGameObject
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public ILevelEditorObject Parent
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        public List<ILevelEditorObject> Children
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public void AddChildren(ILevelEditorObject child)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyExposedData(LevelEditorComponentData[] components)
        {
            throw new System.NotImplementedException();
        }

        public IExposedToLevelEditor[] GetExposedComponents()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveChildren(ILevelEditorObject child)
        {
            throw new System.NotImplementedException();
        }

        public void StartPlayMode()
        {
            throw new System.NotImplementedException();
        }

        public void StopPlayMode()
        {
            throw new System.NotImplementedException();
        }

        public bool Equals(ILevelEditorObject other)
        {
            throw new System.NotImplementedException();
        }
    }
}
