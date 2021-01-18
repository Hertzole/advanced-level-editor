using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public struct ExposedProperty : IEquatable<ExposedProperty>
    {
        public string name;
        public string typeName;

        public string[] formerlySerializedAs;

        public bool visible;
        public bool isArray;

        public Type type;

        public ExposedProperty(Type type, string name, bool visible, bool isArray, string[] formerlySerializedAs) : this()
        {
            this.type = type;
            typeName = type.FullName;
            this.name = name;
            this.visible = visible;
            this.isArray = isArray;
            this.formerlySerializedAs = formerlySerializedAs;
        }

        public override bool Equals(object obj)
        {
            return obj is ExposedProperty property && Equals(property);
        }

        public bool Equals(ExposedProperty other)
        {
            return isArray == other.isArray && visible == other.visible && name == other.name && typeName == other.typeName
                && EqualityComparer<Type>.Default.Equals(type, other.type)
                && EqualityComparer<string[]>.Default.Equals(formerlySerializedAs, other.formerlySerializedAs);
        }

        public override int GetHashCode()
        {
            int hashCode = 1359384865;
            hashCode = hashCode * -1521134295 + isArray.GetHashCode();
            hashCode = hashCode * -1521134295 + visible.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(typeName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(formerlySerializedAs);
            return hashCode;
        }

        public static bool operator ==(ExposedProperty left, ExposedProperty right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExposedProperty left, ExposedProperty right)
        {
            return !(left == right);
        }
    }
}
