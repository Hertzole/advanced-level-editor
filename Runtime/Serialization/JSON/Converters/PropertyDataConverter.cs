using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class PropertyDataConverter : JsonConverter<LevelEditorPropertyData>
    {
        private Dictionary<string, int> typePalette;
        private Dictionary<int, string> invertedTypePalette;

        private const string PROP_ID = "id";
        private const string PROP_TYPE = "type";
        private const string PROP_ISARRAY = "isArray";
        private const string PROP_VALUE = "value";

        public PropertyDataConverter(Dictionary<string, int> typePalette)
        {
            this.typePalette = typePalette;
        }

        public PropertyDataConverter(Dictionary<int, string> invertedTypePalette)
        {
            this.invertedTypePalette = invertedTypePalette;
        }

        public override LevelEditorPropertyData ReadJson(JsonReader reader, Type objectType, LevelEditorPropertyData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            int id = token.GetValue(PROP_ID, -1);
            string type = invertedTypePalette[token.GetValue(PROP_TYPE, 0)];
            bool isArray = token.GetValue(PROP_ISARRAY, false);

            Type realType = LevelEditorJsonSerializer.GetTypeFromString(type);
            if (isArray && realType != null)
            {
                realType = realType.MakeArrayType();
            }

            object value = token.GetValue(realType, PROP_VALUE, default, serializer);

            return new LevelEditorPropertyData() { id = id, typeName = type, isArray = isArray, value = value };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorPropertyData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_ID);
            writer.WriteValue(value.id);
            writer.WritePropertyName(PROP_TYPE);
            writer.WriteValue(typePalette[value.typeName]);
            writer.WritePropertyName(PROP_ISARRAY);
            writer.WriteValue(value.isArray);
            writer.WritePropertyName(PROP_VALUE);

            Type type = LevelEditorJsonSerializer.GetTypeFromString(value.typeName);
            if (value.isArray)
            {
                type = type.MakeArrayType();
            }

            serializer.Serialize(writer, value.value, type);

            writer.WriteEndObject();
        }
    }
}
