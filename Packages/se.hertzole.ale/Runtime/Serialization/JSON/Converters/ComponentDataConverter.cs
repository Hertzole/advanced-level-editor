using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class ComponentDataConverter : JsonConverter<LevelEditorComponentData>
    {
        private Dictionary<string, int> typePalette;
        private Dictionary<int, string> invertedTypePalette;

        private const string PROP_TYPE = "type";
        private const string PROP_PROPERTIES = "properties";

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
            JToken token = JToken.Load(reader);

            string type = invertedTypePalette[token.GetValue(PROP_TYPE, 0)];
            LevelEditorPropertyData[] properties = token.GetValue(PROP_PROPERTIES, Array.Empty<LevelEditorPropertyData>(), serializer);

            return new LevelEditorComponentData() { type = type, properties = properties };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorComponentData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_TYPE);
            writer.WriteValue(typePalette[value.type]);
            writer.WritePropertyName(PROP_PROPERTIES);
            serializer.Serialize(writer, value.properties);

            writer.WriteEndObject();
        }
    }
}
