using System;
using System.Collections.Generic;
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
            value = exposedComponent?.GetValue(property.ID);
            // Used for Unity references. They need to be converted to a simple component.
            type = property.Type;
            if (property is ExposedArray array)
            {
                if (array.ElementType.IsSubclassOf(typeof(Component)))
                {
                    if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
                    {
                        //type = typeof(List<>).MakeGenericType(typeof(Component));
                        throw new NotSupportedException($"List<{array.ElementType}> is not supported. For collection of Unity objects, use array instead.");
                    }
                    else
                    {
                        type = typeof(Component).MakeArrayType();
                    }
                }
            }
            else
            {
                // type = property.Type.IsSubclassOf(typeof(Component)) ? typeof(Component) : property.Type;
                type = ComponentDataWrapper.IsComponent(property.Type) ? typeof(ComponentDataWrapper) : property.Type;
            }
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
