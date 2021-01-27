using System;

namespace Hertzole.ALE
{
    public struct LevelEditorObjectData : IEquatable<LevelEditorObjectData>
    {
        public string name;
        public bool active;
        public string id;
        public int instanceId;
        public LevelEditorComponentData[] components;

        public LevelEditorObjectData(ILevelEditorObject obj)
        {
            name = obj.MyGameObject.name;
            active = obj.MyGameObject.activeSelf;
            id = obj.ID;
            instanceId = obj.InstanceID;

            IExposedToLevelEditor[] objComps = obj.GetExposedComponents();

            components = new LevelEditorComponentData[objComps.Length];

            for (int i = 0; i < objComps.Length; i++)
            {
                components[i] = new LevelEditorComponentData(objComps[i]);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is LevelEditorObjectData data)
            {
                return Equals(data);
            }

            return false;
        }

        public bool Equals(LevelEditorObjectData data)
        {
            return data.name == name && data.id == id && data.instanceId == instanceId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash = hash * 17 * name.GetHashCode();
                hash = hash * 17 * id.GetHashCode();
                hash = hash * 17 * instanceId.GetHashCode();

                return hash;
            }
        }

        public override string ToString()
        {
            return $"Level Editor Object Data ({name}, {id}, {instanceId}, {active}, {(components == null ? "null" : components.Length.ToString())} components)";
        }

        public static bool operator ==(LevelEditorObjectData left, LevelEditorObjectData right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LevelEditorObjectData left, LevelEditorObjectData right)
        {
            return !(left == right);
        }
    }
}
