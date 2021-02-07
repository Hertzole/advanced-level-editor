using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Vector2IntConverter : JsonConverter<Vector2Int>
    {
        private const string PROP_X = "x";
        private const string PROP_Y = "y";

        public override Vector2Int ReadJson(JsonReader reader, Type objectType, Vector2Int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            int x = token.GetValue(PROP_X, 0);
            int y = token.GetValue(PROP_Y, 0);

            return new Vector2Int(x, y);
        }

        public override void WriteJson(JsonWriter writer, Vector2Int value, JsonSerializer serializer)
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
