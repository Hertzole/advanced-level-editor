using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;
using System;

namespace Hertzole.ALE.Binary
{
    public sealed class LevelEditorObjectDataFormatter : MessagePackFormatter<LevelEditorObjectData>
    {
        private static ReadOnlySpan<byte> SpanName { get { return new byte[1 + 4] { 164, 110, 97, 109, 101 }; } }
        private static ReadOnlySpan<byte> SpanActive { get { return new byte[1 + 6] { 166, 97, 99, 116, 105, 118, 101 }; } }
        private static ReadOnlySpan<byte> SpanID { get { return new byte[1 + 2] { 162, 105, 100 }; } }
        private static ReadOnlySpan<byte> SpanInstanceID { get { return new byte[1 + 10] { 170, 105, 110, 115, 116, 97, 110, 99, 101, 73, 100 }; } }
        private static ReadOnlySpan<byte> SpanComponents { get { return new byte[1 + 10] { 170, 99, 111, 109, 112, 111, 110, 101, 110, 116, 115 }; } }

        public override void Serialize(ref MessagePackWriter writer, LevelEditorObjectData value, MessagePackSerializerOptions options)
        {
            MessagePackFormatter<string> stringFormatter = options.Resolver.GetFormatterWithVerify<string>();
            writer.WriteMapHeader(5);

            writer.WriteRaw(SpanName);
            stringFormatter.Serialize(ref writer, value.name, options);

            writer.WriteRaw(SpanActive);
            writer.Write(value.active);

            writer.WriteRaw(SpanID);
            stringFormatter.Serialize(ref writer, value.id, options);

            writer.WriteRaw(SpanInstanceID);
            writer.Write(value.instanceId);

            writer.WriteRaw(SpanComponents);
            options.Resolver.GetFormatterWithVerify<LevelEditorComponentData[]>().Serialize(ref writer, value.components, options);
        }

        public override LevelEditorObjectData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            options.Security.DepthStep(ref reader);

            string name = null;
            bool active = false;
            string id = null;
            int instanceId = -1;
            LevelEditorComponentData[] components = null;

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
                        if (AutomataKeyGen.GetKey(ref stringKey) != 1701667182UL)
                        {
                            goto FAIL;
                        }

                        name = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        continue;
                    case 6:
                        if (AutomataKeyGen.GetKey(ref stringKey) != 111559249781601UL)
                        {
                            goto FAIL;
                        }

                        active = reader.ReadBoolean();
                        continue;
                    case 2:
                        if (AutomataKeyGen.GetKey(ref stringKey) != 25705UL)
                        {
                            goto FAIL;
                        }

                        id = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        continue;
                    case 10:
                        switch (AutomataKeyGen.GetKey(ref stringKey))
                        {
                            default: goto FAIL;
                            case 7305804385369681513UL:
                                if (AutomataKeyGen.GetKey(ref stringKey) != 25673UL)
                                {
                                    goto FAIL;
                                }

                                instanceId = reader.ReadInt32();
                                continue;

                            case 7954885741726494563UL:
                                if (AutomataKeyGen.GetKey(ref stringKey) != 29556UL)
                                {
                                    goto FAIL;
                                }

                                components = options.Resolver.GetFormatterWithVerify<LevelEditorComponentData[]>().Deserialize(ref reader, options);
                                continue;

                        }
                }
            }

            reader.Depth--;

            return new LevelEditorObjectData() { name = name, active = active, id = id, components = components, instanceId = instanceId };
        }
    }
}
