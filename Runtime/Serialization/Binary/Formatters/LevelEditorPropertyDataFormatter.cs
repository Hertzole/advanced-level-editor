using MessagePack;
using MessagePack.Formatters;
using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorPropertyDataFormatter : MessagePackFormatter<LevelEditorPropertyData>
    {
        public override void Serialize(ref MessagePackWriter writer, LevelEditorPropertyData value, MessagePackSerializerOptions options)
        {
            if (!LevelEditorSerializer.HasType(value.type))
            {
                Debug.LogError($"{value.type} is not a supported type.");
                writer.WriteNil();
                return;
            }

            writer.WriteArrayHeader(3);
            writer.WriteInt32(value.id);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.typeName, options);
            options.Resolver.GetFormatterDynamic(value.type).SerializeObject(ref writer, value.value, options);
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

            int count = reader.ReadArrayHeader();
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        id = reader.ReadInt32();
                        break;
                    case 1:
                        typeName = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        type = LevelEditorSerializer.GetType(typeName);
                        break;
                    case 2:
                        value = options.Resolver.GetFormatterDynamic(type).DeserializeObject(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return new LevelEditorPropertyData() { id = id, typeName = typeName, value = value, type = type };
        }
    }
}
