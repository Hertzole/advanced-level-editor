using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class CustomDataConverter : JsonConverter<LevelEditorCustomData>
    {
        private Dictionary<string, int> typePalette;
        private Dictionary<int, string> invertedTypePalette;

        public CustomDataConverter(Dictionary<string, int> typePalette)
        {
            this.typePalette = typePalette;
        }

        public CustomDataConverter(Dictionary<int, string> invertedTypePalette)
        {
            this.invertedTypePalette = invertedTypePalette;
        }

        public override LevelEditorCustomData ReadJson(JsonReader reader, Type objectType, LevelEditorCustomData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            reader.Read();
            string type = invertedTypePalette[(int)reader.ReadAsInt32()];
            reader.Read();
            bool isArray = (bool)reader.ReadAsBoolean();
            reader.Read();
            Type realType = LevelEditorJsonSerializer.GetTypeFromString(type);
            if (realType != null && isArray)
            {
                realType = realType.MakeArrayType();
            }
            reader.Read();
            object value = serializer.Deserialize(reader, realType);

            reader.Read();

            return new LevelEditorCustomData() { type = type, isArray = isArray, value = value };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorCustomData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("type");
            writer.WriteValue(typePalette[value.type]);
            writer.WritePropertyName("isArray");
            writer.WriteValue(value.isArray);
            writer.WritePropertyName("value");
            serializer.Serialize(writer, value.value);

            writer.WriteEndObject();
        }
    }
}
