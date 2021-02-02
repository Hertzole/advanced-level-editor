using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Vector2IntConverter : JsonConverter<Vector2Int>
    {
        public override Vector2Int ReadJson(JsonReader reader, Type objectType, Vector2Int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            int x = 0;
            int y = 0;

            if (token["x"] != null)
            {
                x = (int)token["x"];
            }

            if (token["y"] != null)
            {
                y = (int)token["y"];
            }

            return new Vector2Int(x, y);
        }

        public override void WriteJson(JsonWriter writer, Vector2Int value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("x");
            writer.WriteValue(value.x);
            writer.WritePropertyName("y");
            writer.WriteValue(value.y);

            writer.WriteEndObject();
        }
    }
}
