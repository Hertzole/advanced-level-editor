using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE.Binary
{
    public sealed class LevelEditorObjectDataFormatter : IMessagePackFormatter<LevelEditorObjectData>
    {
        public void Serialize(ref MessagePackWriter writer, LevelEditorObjectData value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(5);
            IMessagePackFormatter<string> stringFormatter = options.Resolver.GetFormatterWithVerify<string>();
            stringFormatter.Serialize(ref writer, value.name, options);
            options.Resolver.GetFormatterWithVerify<bool>().Serialize(ref writer, value.active, options);
            stringFormatter.Serialize(ref writer, value.id, options);
            writer.WriteInt32(value.instanceId);
            options.Resolver.GetFormatterWithVerify<LevelEditorComponentData[]>().Serialize(ref writer, value.components, options);
        }

        public LevelEditorObjectData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            string name = null;
            bool active = false;
            string id = null;
            int instanceId = -1;
            LevelEditorComponentData[] components = null;

            IMessagePackFormatter<string> stringFormatter = options.Resolver.GetFormatterWithVerify<string>();
            int count = reader.ReadArrayHeader();
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        name = stringFormatter.Deserialize(ref reader, options);
                        break;
                    case 1:
                        active = options.Resolver.GetFormatterWithVerify<bool>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        id = stringFormatter.Deserialize(ref reader, options);
                        break;
                    case 3:
                        instanceId = reader.ReadInt32();
                        break;
                    case 4:
                        components = options.Resolver.GetFormatterWithVerify<LevelEditorComponentData[]>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return new LevelEditorObjectData() { name = name, active = active, id = id, components = components, instanceId = instanceId };
        }
    }
}
