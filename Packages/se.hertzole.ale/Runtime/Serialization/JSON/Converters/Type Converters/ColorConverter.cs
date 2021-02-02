using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class ColorConverter : JsonConverter<Color>
    {
        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            byte r = 0;
            byte g = 0;
            byte b = 0;
            byte a = 0;

            if (token["r"] != null)
            {
                r = (byte)token["r"];
            }

            if (token["g"] != null)
            {
                g = (byte)token["g"];
            }

            if (token["b"] != null)
            {
                b = (byte)token["b"];
            }

            if (token["a"] != null)
            {
                a = (byte)token["a"];
            }

            return new Color32(r, g, b, a);
        }

        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            Color32 col = value;

            writer.WriteStartObject();

            writer.WritePropertyName("r");
            writer.WriteValue(col.r);
            writer.WritePropertyName("g");
            writer.WriteValue(col.g);
            writer.WritePropertyName("b");
            writer.WriteValue(col.b);
            writer.WritePropertyName("a");
            writer.WriteValue(col.b);

            writer.WriteEndObject();
        }
    }
}
