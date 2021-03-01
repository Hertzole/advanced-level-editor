using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorPropertyDataFormatter : MessagePackFormatter<LevelEditorPropertyData>
    {
        private static ReadOnlySpan<byte> SpanID { get { return new byte[1 + 2] { 162, 105, 100 }; } }
        private static ReadOnlySpan<byte> SpanType { get { return new byte[1 + 4] { 164, 116, 121, 112, 101 }; } }
        private static ReadOnlySpan<byte> SpanValue { get { return new byte[1 + 5] { 165, 118, 97, 108, 117, 101 }; } }

        public override void Serialize(ref MessagePackWriter writer, LevelEditorPropertyData value, MessagePackSerializerOptions options)
        {
            if (!LevelEditorSerializer.HasType(value.type))
            {
                Debug.LogError($"{value.type} is not a supported type.");
                writer.WriteNil();
                return;
            }

            MessagePackFormatter valueFormatter = options.Resolver.GetFormatterDynamic(value.type);
            if (valueFormatter == null)
            {
                Debug.LogError($"Found no formatter for {value.type}.");
                writer.WriteNil();
                return;
            }

            writer.WriteMapHeader(3);

            writer.WriteRaw(SpanID);
            writer.WriteInt32(value.id);

            writer.WriteRaw(SpanType);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.typeName, options);

            writer.WriteRaw(SpanValue);
            valueFormatter.SerializeObject(ref writer, value.value, options);
        }

        public override LevelEditorPropertyData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return new LevelEditorPropertyData();
            }

            options.Security.DepthStep(ref reader);

            int id = -1;
            string typeName = null;
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
                    case 2:
                        if (AutomataKeyGen.GetKey(ref stringKey) != 25705UL)
                        {
                            goto FAIL;
                        }

                        id = reader.ReadInt32();
                        continue;
                    case 4:
                        if (AutomataKeyGen.GetKey(ref stringKey) != 1701869940UL)
                        {
                            goto FAIL;
                        }

                        typeName = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        type = LevelEditorSerializer.GetType(typeName);
                        continue;
                    case 5:
                        if (AutomataKeyGen.GetKey(ref stringKey) != 435761734006UL)
                        {
                            goto FAIL;
                        }

                        value = options.Resolver.GetFormatterDynamic(type).DeserializeObject(ref reader, options);
                        continue;

                }
            }

            reader.Depth--;
            return new LevelEditorPropertyData() { id = id, typeName = typeName, value = value, type = type };
        }
    }
}
