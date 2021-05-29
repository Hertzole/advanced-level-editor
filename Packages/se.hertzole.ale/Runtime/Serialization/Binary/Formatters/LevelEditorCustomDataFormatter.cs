using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using System;

namespace Hertzole.ALE
{
    public class LevelEditorCustomDataFormatter : IMessagePackFormatter<LevelEditorCustomData>
    {
        private static ReadOnlySpan<byte> SpanType { get { return new byte[1 + 4] { 164, 116, 121, 112, 101 }; } }
        private static ReadOnlySpan<byte> SpanValue { get { return new byte[1 + 5] { 165, 118, 97, 108, 117, 101 }; } }

        public void Serialize(ref MessagePackWriter writer, LevelEditorCustomData value, MessagePackSerializerOptions options)
        {
            writer.WriteMapHeader(2);
            writer.WriteRaw(SpanType);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.type.FullName, options);
            writer.WriteRaw(SpanValue);
            ((LevelEditorResolver) LevelEditorResolver.Instance).SerializeDynamic(value.type, ref writer, value.value, options);
        }

        public LevelEditorCustomData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            object value = null;
            Type type = null;

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

                        type = LevelEditorSerializer.GetType(options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options));
                        continue;
                    case 5:
                        if (AutomataKeyGen.GetKey(ref stringKey) != 435761734006UL)
                        {
                            goto FAIL;
                        } 
                        
                        ((LevelEditorResolver) LevelEditorResolver.Instance).DeserializeDynamic(type, ref reader, out value, options);
                        continue;
                }
            }

            reader.Depth--;

            return new LevelEditorCustomData(type, value);
        }
    }
}
