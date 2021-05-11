using System;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Hertzole.ALE
{
    public class LevelEditorComponentDataFormatter : IMessagePackFormatter<LevelEditorComponentData>
    {
        private static ReadOnlySpan<byte> SpanType { get { return new byte[1 + 4] { 164, 116, 121, 112, 101 }; } }
        private static ReadOnlySpan<byte> SpanProperties { get { return new byte[1 + 10] { 170, 112, 114, 111, 112, 101, 114, 116, 105, 101, 115 }; } }

        public void Serialize(ref MessagePackWriter writer, LevelEditorComponentData value, MessagePackSerializerOptions options)
        {
            writer.WriteMapHeader(2);
            writer.WriteRaw(SpanType);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.type, options);
            writer.WriteRaw(SpanProperties);
            options.Resolver.GetFormatterWithVerify<LevelEditorPropertyData[]>().Serialize(ref writer, value.properties, options);
        }

        public LevelEditorComponentData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            string type = null;
            LevelEditorPropertyData[] properties = null;

            int count = reader.ReadMapHeader();
            for (int i = 0; i < count; i++)
            {
                ReadOnlySpan<byte> stringKey = CodeGenHelpers.ReadStringSpan(ref reader);

                switch (stringKey.Length)
                {
                    default:
                        FAIL:
                        reader.Skip();
                        continue;
                    case 4:
                        if (AutomataKeyGen.GetKey(ref stringKey) != 1701869940UL)
                        {
                            goto FAIL;
                        }

                        type = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        continue;
                    case 10:
                        if (!MemoryExtensions.SequenceEqual(stringKey, SpanProperties.Slice(1)))
                        {
                            goto FAIL;
                        }

                        properties = options.Resolver.GetFormatterWithVerify<LevelEditorPropertyData[]>().Deserialize(ref reader, options);
                        continue;
                }
            }

            reader.Depth--;

            return new LevelEditorComponentData() { type = type, properties = properties };
        }
    }
}
