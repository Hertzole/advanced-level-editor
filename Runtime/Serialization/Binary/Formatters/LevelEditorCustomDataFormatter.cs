using MessagePack;
using MessagePack.Formatters;
using System;

namespace Hertzole.ALE.Binary
{
    public class LevelEditorCustomDataFormatter : MessagePackFormatter<LevelEditorCustomData>
    {
        public override void Serialize(ref MessagePackWriter writer, LevelEditorCustomData value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(2);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.typeName, options);
            options.Resolver.GetFormatterDynamic(value.type).SerializeObject(ref writer, value.value, options);
        }

        public override LevelEditorCustomData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            object value = null;
            Type type = null;

            int count = reader.ReadArrayHeader();
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        type = LevelEditorSerializer.GetType(options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options));
                        break;
                    case 1:
                        value = options.Resolver.GetFormatterDynamic(type).DeserializeObject(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new LevelEditorCustomData(type, value);
        }
    }
}
