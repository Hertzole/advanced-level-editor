using System;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using UnityEngine;

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
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.type.FullName, options);
            writer.WriteRaw(SpanProperties);
            ((LevelEditorResolver)LevelEditorResolver.Instance).SerializeWrapper(ref writer, value.wrapper, options);
        }

        public LevelEditorComponentData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            Type actualType = null;
            IExposedWrapper wrapper = null;

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

                        string type = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        actualType = LevelEditorSerializer.GetType(type);
                        continue;
                    case 10:
                        if (!MemoryExtensions.SequenceEqual(stringKey, SpanProperties.Slice(1)))
                        {
                            goto FAIL;
                        }

                        ((LevelEditorResolver) LevelEditorResolver.Instance).DeserializeWrapper(actualType, ref reader, options, out wrapper);
                        continue;
                }
            }

            reader.Depth--;

            return new LevelEditorComponentData(actualType, wrapper);
        }
    }
}
