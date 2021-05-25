using System;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Hertzole.ALE
{
    public readonly struct LevelEditorComponentData : IEquatable<LevelEditorComponentData>
    {
        public readonly Type type;
        public readonly IExposedWrapper wrapper;

        public LevelEditorComponentData(IExposedToLevelEditor exposed)
        {
            type = exposed.ComponentType;
            wrapper = exposed.GetWrapper();
        }

        public LevelEditorComponentData(Type type, IExposedWrapper wrapper)
        {
            this.type = type;
            this.wrapper = wrapper;
        }

        public override bool Equals(object obj)
        {
            return obj is LevelEditorComponentData data && Equals(data);
        }

        public bool Equals(LevelEditorComponentData other)
        {
            if (wrapper == null && other.wrapper == null)
            {
                return type == other.type;
            }

            if (wrapper == null || other.wrapper == null)
            {
                return false;
            }
            
            return type == other.type && wrapper.Equals(other.wrapper);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 23;
                hashCode = hashCode * 17 * type.GetHashCode();
                hashCode = hashCode * 17 * (wrapper == null ? 0 : wrapper.GetHashCode());
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
    }
}
