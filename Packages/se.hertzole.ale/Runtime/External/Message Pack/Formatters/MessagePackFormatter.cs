using UnityEngine;

namespace MessagePack.Formatters
{
    public abstract class MessagePackFormatter
    {
        public abstract void SerializeObject(ref MessagePackWriter writer, object value, MessagePackSerializerOptions options);

        public abstract object DeserializeObject(ref MessagePackReader reader, MessagePackSerializerOptions options);
    }

    public abstract class MessagePackFormatter<T> : MessagePackFormatter
    {
        public sealed override void SerializeObject(ref MessagePackWriter writer, object value, MessagePackSerializerOptions options)
        {
            Debug.Log(value);
            Serialize(ref writer, (T)value, options);
        }

        public sealed override object DeserializeObject(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return Deserialize(ref reader, options);
        }

        public abstract void Serialize(ref MessagePackWriter writer, T value, MessagePackSerializerOptions options);

        public abstract T Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options);
    }
}
