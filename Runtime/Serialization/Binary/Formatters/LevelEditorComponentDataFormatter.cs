using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE
{
    public class LevelEditorComponentDataFormatter : IMessagePackFormatter<LevelEditorComponentData>
    {
        public void Serialize(ref MessagePackWriter writer, LevelEditorComponentData value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(2);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.type, options);
            options.Resolver.GetFormatterWithVerify<LevelEditorPropertyData[]>().Serialize(ref writer, value.properties, options);
        }

        public LevelEditorComponentData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            string type = null;
            LevelEditorPropertyData[] properties = null;

            int count = reader.ReadArrayHeader();
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        type = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        properties = options.Resolver.GetFormatterWithVerify<LevelEditorPropertyData[]>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return new LevelEditorComponentData() { type = type, properties = properties };
        }
    }
}
