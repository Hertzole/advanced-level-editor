using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class PropertyDataConverter : JsonConverter<LevelEditorPropertyData>
    {
        private Dictionary<string, int> typePalette;
        private Dictionary<int, string> invertedTypePalette;

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

            int id = -1;
            string type = null;
            bool isArray = false;

            if (token["id"] != null)
            {
                id = (int)token["id"];
            }

            if (token["type"] != null)
            {
                type = invertedTypePalette[(int)token["type"]];
            }

            if (token["isArray"] != null)
            {
                isArray = (bool)token["isArray"];
            }

            Type realType = LevelEditorJsonSerializer.GetTypeFromString(type);
            if (isArray && realType != null)
            {
                realType = realType.MakeArrayType();
            }

            object value = token["value"] != null ? token["value"].ToObject(realType, serializer) : default;

            return new LevelEditorPropertyData() { id = id, typeName = type, isArray = isArray, value = value };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorPropertyData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteValue(value.id);
            writer.WritePropertyName("type");
            writer.WriteValue(typePalette[value.typeName]);
            writer.WritePropertyName("isArray");
            writer.WriteValue(value.isArray);
            writer.WritePropertyName("value");

            Type type = LevelEditorJsonSerializer.GetTypeFromString(value.typeName);
            if (value.isArray)
            {
                type = type.MakeArrayType();
            }

            Debug.Log(value.value + " | " + type + " | " + value.typeName + " | " + value.type + " | " + (value.value == null).ToString());

            serializer.Serialize(writer, value.value, value.type);

            writer.WriteEndObject();
        }
    }
}
