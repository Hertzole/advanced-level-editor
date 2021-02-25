using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE.Binary
{
    public sealed class LevelEditorCustomDataFormatter : IMessagePackFormatter<LevelEditorCustomData>
    {
        public void Serialize(ref MessagePackWriter writer, LevelEditorCustomData value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(3);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.type, options);
            options.Resolver.GetFormatterWithVerify<bool>().Serialize(ref writer, value.isArray, options);
            options.Resolver.GetFormatterWithVerify<object>().Serialize(ref writer, value.value, options);
        }

        public LevelEditorCustomData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            string type = null;
            bool isArray = false;
            object value = null;

            int count = reader.ReadArrayHeader();
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        type = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        isArray = options.Resolver.GetFormatterWithVerify<bool>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        value = options.Resolver.GetFormatterWithVerify<object>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new LevelEditorCustomData(type, isArray, value);
        }
    }
}
