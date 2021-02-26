using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public struct LevelEditorPropertyData : IEquatable<LevelEditorPropertyData>
    {
        public int id;
        public string typeName;
        public object value;
        public Type type;

        public LevelEditorPropertyData(ExposedProperty property, IExposedToLevelEditor exposedComponent)
        {
            id = property.ID;
            value = exposedComponent.GetValue(property.ID);
            // Used for Unity references. They need to be converted to a simple component.
            type = property.Type.IsSubclassOf(typeof(Component)) ? typeof(Component) : property.Type;
            typeName = type.FullName;
        }

        public override bool Equals(object obj)
        {
            return obj is LevelEditorPropertyData data && Equals(data);
        }

        public bool Equals(LevelEditorPropertyData other)
        {
            return id == other.id && typeName == other.typeName && value.AdvancedEquals(other.value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 23;
                hashCode = hashCode * 17 * id.GetHashCode();
                hashCode = hashCode * 17 * typeName.GetHashCode();
                hashCode = hashCode * 17 * value.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(LevelEditorPropertyData left, LevelEditorPropertyData right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LevelEditorPropertyData left, LevelEditorPropertyData right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"LevelEditorPropertyData (ID: {id}, Type Name: {typeName}, Value: {value})";
        }
    }
}
