using Hertzole.ALE.Binary;
using MessagePack;
using MessagePack.Formatters;
using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorPropertyDataFormatter : IMessagePackFormatter<LevelEditorPropertyData>
    {
        public void Serialize(ref MessagePackWriter writer, LevelEditorPropertyData value, MessagePackSerializerOptions options)
        {
            if (!LevelEditorSerializer.HasType(value.type))
            {
                Debug.LogError($"{value.typeName} is not a supported type.");
                writer.WriteNil();
                return;
            }

            Debug.Log("Write type " + value.type + " | " + value.typeName + " | " + value.value);

            writer.WriteArrayHeader(4);
            writer.WriteInt32(value.id);
            options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.typeName, options);
            options.Resolver.GetFormatterWithVerify<bool>().Serialize(ref writer, value.isArray, options);
            LevelEditorSerializer.Serialize(ref writer, value.type, value.value, options);
        }

        public LevelEditorPropertyData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return new LevelEditorPropertyData();
            }

            options.Security.DepthStep(ref reader);

            int id = -1;
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
                        id = reader.ReadInt32();
                        break;
                    case 1:
                        typeName = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        type = LevelEditorSerializer.GetType(typeName);
                        break;
                    case 2:
                        isArray = options.Resolver.GetFormatterWithVerify<bool>().Deserialize(ref reader, options);
                        break;
                    case 3:
                        value = ValueFormatter.Instance.Deserialize(ref reader, type, options);
                        Debug.Log("Deserialize " + type + " | " + id + " | " + value);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;
            return new LevelEditorPropertyData() { id = id, typeName = typeName, isArray = isArray, value = value, type = type };
        }
    }
}
