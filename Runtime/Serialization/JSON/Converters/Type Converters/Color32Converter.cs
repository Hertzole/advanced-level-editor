using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Color32Converter : JsonConverter<Color32>
    {
        public override Color32 ReadJson(JsonReader reader, Type objectType, Color32 existingValue, bool hasExistingValue, JsonSerializer serializer)
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

        public override void WriteJson(JsonWriter writer, Color32 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("r");
            writer.WriteValue(value.r);
            writer.WritePropertyName("g");
            writer.WriteValue(value.g);
            writer.WritePropertyName("b");
            writer.WriteValue(value.b);
            writer.WritePropertyName("a");
            writer.WriteValue(value.a);

            writer.WriteEndObject();
        }
    }
}
