using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public class ExposedProperty : ExposedField, IEquatable<ExposedProperty>
    {
        public int ID { get; private set; }

        public bool IsVisible { get; private set; }
        public bool IsArray { get; private set; }

        public string Name { get; private set; }
        public string CustomName { get; private set; }
        public string TypeName { get { return Type.FullName; } }

        public Type Type { get; private set; }

        public ExposedProperty(int id, Type type, string name, string customName, bool isVisible, bool isArray)
        {
            ID = id;
            Type = type;
            Name = name;
            CustomName = customName;
            IsVisible = isVisible;
            IsArray = isArray;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ExposedProperty);
        }

        public bool Equals(ExposedProperty other)
        {
            return other != null && ID == other.ID && IsVisible == other.IsVisible && IsArray == other.IsArray && Name == other.Name && CustomName == other.CustomName && TypeName == other.TypeName;
        }

        public override int GetHashCode()
        {
            int hashCode = 312150486;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + IsVisible.GetHashCode();
            hashCode = hashCode * -1521134295 + IsArray.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypeName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(Type);
            return hashCode;
        }

        public static bool operator ==(ExposedProperty left, ExposedProperty right)
        {
            return EqualityComparer<ExposedProperty>.Default.Equals(left, right);
        }

        public static bool operator !=(ExposedProperty left, ExposedProperty right)
        {
            return !(left == right);
        }
    }
}
