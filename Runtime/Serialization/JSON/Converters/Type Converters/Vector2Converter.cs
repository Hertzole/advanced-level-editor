using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Vector2Converter : JsonConverter<Vector2>
    {
        private const string PROP_X = "x";
        private const string PROP_Y = "y";

        public override Vector2 ReadJson(JsonReader reader, Type objectType, Vector2 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            float x = token.GetValue(PROP_X, 0f);
            float y = token.GetValue(PROP_Y, 0f);

            return new Vector2(x, y);
        }

        public override void WriteJson(JsonWriter writer, Vector2 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_X);
            writer.WriteValue(value.x);
            writer.WritePropertyName(PROP_Y);
            writer.WriteValue(value.y);

            writer.WriteEndObject();
        }
    }
}
