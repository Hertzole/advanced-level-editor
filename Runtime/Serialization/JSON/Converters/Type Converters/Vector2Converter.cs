using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Vector2Converter : JsonConverter<Vector2>
    {
        public override Vector2 ReadJson(JsonReader reader, Type objectType, Vector2 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            float x = 0;
            float y = 0;

            if (token["x"] != null)
            {
                x = (float)token["x"];
            }

            if (token["y"] != null)
            {
                y = (float)token["y"];
            }

            return new Vector2(x, y);
        }

        public override void WriteJson(JsonWriter writer, Vector2 value, JsonSerializer serializer)
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
