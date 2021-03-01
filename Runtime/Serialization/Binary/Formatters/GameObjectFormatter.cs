using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Hertzole.ALE
{
    public class GameObjectFormatter : MessagePackFormatter
    {
        public override void SerializeObject(ref MessagePackWriter writer, object value, MessagePackSerializerOptions options)
        {
            if (value != null && value is GameObject comp && comp != null && comp.TryGetComponent(out ILevelEditorObject obj))
            {
                writer.WriteInt32(obj.InstanceID);
            }
            else
            {
                writer.WriteNil();
            }
        }

        public override object DeserializeObject(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            return reader.ReadInt32();
        }
    }
}
