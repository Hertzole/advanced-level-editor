using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class ComponentDataConverter : JsonConverter<LevelEditorComponentData>
    {
        private Dictionary<string, int> typePalette;
        private Dictionary<int, string> invertedTypePalette;

        public ComponentDataConverter(Dictionary<string, int> typePalette)
        {
            this.typePalette = typePalette;
        }

        public ComponentDataConverter(Dictionary<int, string> invertedTypePalette)
        {
            this.invertedTypePalette = invertedTypePalette;
        }

        public override LevelEditorComponentData ReadJson(JsonReader reader, Type objectType, LevelEditorComponentData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            reader.Read();
            string type = invertedTypePalette[(int)reader.ReadAsInt32()];
            reader.Read();
            reader.Read();
            LevelEditorPropertyData[] properties = serializer.Deserialize<LevelEditorPropertyData[]>(reader);

            reader.Read();

            return new LevelEditorComponentData() { type = type, properties = properties };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorComponentData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("type");
            writer.WriteValue(typePalette[value.type]);
            writer.WritePropertyName("properties");
            serializer.Serialize(writer, value.properties);

            writer.WriteEndObject();
        }
    }
}
