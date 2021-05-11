using MessagePack;
using MessagePack.Formatters;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public sealed class LevelEditorSaveDataFormatter : IMessagePackFormatter<LevelEditorSaveData>
    {
        public void Serialize(ref MessagePackWriter writer, LevelEditorSaveData value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(3);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.name, options);
            options.Resolver.GetFormatterWithVerify<List<LevelEditorObjectData>>().Serialize(ref writer, value.objects, options);
            options.Resolver.GetFormatterWithVerify<Dictionary<string, LevelEditorCustomData>>().Serialize(ref writer, value.customData, options);
        }

        public LevelEditorSaveData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            string name = null;
            List<LevelEditorObjectData> objects = null;
            Dictionary<string, LevelEditorCustomData> customData = null;

            int count = reader.ReadArrayHeader();
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        name = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        objects = options.Resolver.GetFormatterWithVerify<List<LevelEditorObjectData>>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        customData = options.Resolver.GetFormatterWithVerify<Dictionary<string, LevelEditorCustomData>>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return new LevelEditorSaveData(name) { objects = objects, customData = customData };
        }
    }
}
