using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public struct LevelEditorCustomData : IEquatable<LevelEditorCustomData>
    {
        public string typeName;
        public bool isArray;
        public object value;
        public Type type;

        public LevelEditorCustomData(Type type, bool isArray, object value)
        {
            typeName = type.FullName;
            this.type = type;
            this.isArray = isArray;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is LevelEditorCustomData data && Equals(data);
        }

        public bool Equals(LevelEditorCustomData other)
        {
            return typeName == other.typeName && isArray == other.isArray && value.AdvancedEquals(other.value);
        }

        public override int GetHashCode()
        {
            int hashCode = 1148455455;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(typeName);
            hashCode = hashCode * -1521134295 + isArray.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(value);
            return hashCode;
        }

        public static bool operator ==(LevelEditorCustomData left, LevelEditorCustomData right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LevelEditorCustomData left, LevelEditorCustomData right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"{nameof(LevelEditorCustomData)} ({typeName}, {isArray}, {type}, {value})";
        }
    }
}
