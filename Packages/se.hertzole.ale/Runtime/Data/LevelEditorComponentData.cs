using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hertzole.ALE
{
    public struct LevelEditorComponentData : IEquatable<LevelEditorComponentData>
    {
        public string type;
        // public LevelEditorPropertyData[] properties;
        public IExposedWrapper wrapper;

        public LevelEditorComponentData(IExposedToLevelEditor exposed)
        {
            type = exposed.TypeName;
            // ReadOnlyCollection<ExposedProperty> exposedProperties = exposed.GetProperties();
            // properties = new LevelEditorPropertyData[exposedProperties.Count];
            // for (int i = 0; i < properties.Length; i++)
            // {
            //     properties[i] = new LevelEditorPropertyData(exposedProperties[i], exposed);
            // }

            wrapper = exposed.GetWrapper();
        }

        public override bool Equals(object obj)
        {
            return obj is LevelEditorComponentData data && Equals(data);
        }

        public bool Equals(LevelEditorComponentData other)
        {
            // return type == other.type && properties.SequenceEqual(other.properties);
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 23;
                hashCode = hashCode * 17 * type.GetHashCode();
                // hashCode = hashCode * 17 * properties.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(LevelEditorComponentData left, LevelEditorComponentData right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LevelEditorComponentData left, LevelEditorComponentData right)
        {
            return !(left == right);
        }

        // public override string ToString()
        // {
        //     return $"LevelEditorComponentData (Type: {type}, Property Count: {(properties == null ? "Null" : properties.Length.ToString())})";
        // }
    }
}
