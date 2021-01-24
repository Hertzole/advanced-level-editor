using System;
using System.IO;

namespace Hertzole.ALE
{
    public abstract class BaseFormatter
    {
        public virtual string TypeName { get; }

        public bool SupportsType<T>()
        {
            return SupportsType(typeof(T));
        }

        public virtual bool SupportsType(Type type)
        {
            return SupportsType(type.FullName);
        }

        public virtual bool SupportsType(string typeName)
        {
            return typeName == TypeName;
        }

        public virtual void Serialize(object value, BinaryWriter writer) { }

        public virtual object DeserializeValue(BinaryReader reader) { return null; }
    }

    public abstract class BaseFormatter<T> : BaseFormatter
    {
        private readonly string typeName;

        public override string TypeName { get { return typeName; } }

        protected BaseFormatter()
        {
            typeName = typeof(T).FullName;
        }

        public override void Serialize(object value, BinaryWriter writer)
        {
            Serialize(value == null ? default : (T)value, writer);
        }

        public abstract void Serialize(T value, BinaryWriter writer);

        public override object DeserializeValue(BinaryReader reader)
        {
            return Deserialize(reader);
        }

        public abstract T Deserialize(BinaryReader reader);
    }
}
