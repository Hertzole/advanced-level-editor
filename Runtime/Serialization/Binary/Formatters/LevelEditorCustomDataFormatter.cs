using MessagePack;
using MessagePack.Formatters;
using System;

namespace Hertzole.ALE.Binary
{
    public class LevelEditorCustomDataFormatter : MessagePackFormatter<LevelEditorCustomData>
    {
        public override void Serialize(ref MessagePackWriter writer, LevelEditorCustomData value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(3);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.typeName, options);
            options.Resolver.GetFormatterWithVerify<bool>().Serialize(ref writer, value.isArray, options);
            LevelEditorSerializer.Serialize(ref writer, value.type, value.value, value.isArray, options);
        }

        public override LevelEditorCustomData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            string typeName = null;
            bool isArray = false;
            object value = null;
            Type type = null;

            int count = reader.ReadArrayHeader();
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        typeName = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        type = LevelEditorSerializer.GetType(typeName);
                        break;
                    case 1:
                        isArray = options.Resolver.GetFormatterWithVerify<bool>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        value = LevelEditorSerializer.Deserialize(ref reader, type, isArray, options);
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
