using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class CustomDataConverter : JsonConverter<LevelEditorCustomData>
    {
        private Dictionary<string, int> typePalette;
        private Dictionary<int, string> invertedTypePalette;

        private const string PROP_TYPE = "type";
        private const string PROP_ISARRAY = "isArray";
        private const string PROP_VALUE = "value";

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
            JToken token = JToken.Load(reader);

            string type = invertedTypePalette[token.GetValue(PROP_TYPE, 0)];
            bool isArray = token.GetValue(PROP_ISARRAY, false);

            Type realType = LevelEditorJsonSerializer.GetTypeFromString(type);
            if (realType != null && isArray)
            {
                realType = realType.MakeArrayType();
            }

            object value = token.GetValue(realType, PROP_VALUE, default, serializer);

            return new LevelEditorCustomData() { typeName = type, isArray = isArray, value = value };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorCustomData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_TYPE);
            writer.WriteValue(typePalette[value.typeName]);
            writer.WritePropertyName(PROP_ISARRAY);
            writer.WriteValue(value.isArray);
            writer.WritePropertyName(PROP_VALUE);
            serializer.Serialize(writer, value.value);

            writer.WriteEndObject();
        }
    }
}
