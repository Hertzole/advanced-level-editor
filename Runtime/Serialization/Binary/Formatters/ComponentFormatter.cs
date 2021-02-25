using MessagePack;
using MessagePack.Formatters;
using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class ComponentFormatter : IMessagePackFormatter<Component>
    {
        public void Serialize(ref MessagePackWriter writer, Component value, MessagePackSerializerOptions options)
        {
            if (value != null && value.TryGetComponent(out ILevelEditorObject obj))
            {
                writer.WriteInt32(obj.InstanceID);
            }
            else
            {
                writer.WriteNil();
            }
        }

        public object DeserializeObject(ref MessagePackReader reader)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            return reader.ReadInt32();
        }

        public Component Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            throw new NotSupportedException("Use DeserializeObject instead.");
        }
    }
}
