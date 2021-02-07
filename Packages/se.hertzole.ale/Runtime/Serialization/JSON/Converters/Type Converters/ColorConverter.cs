using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class ColorConverter : JsonConverter<Color>
    {
        private const string PROP_R = "r";
        private const string PROP_G = "g";
        private const string PROP_B = "b";
        private const string PROP_A = "a";

        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            byte r = token.GetValue<byte>(PROP_R, 0);
            byte g = token.GetValue<byte>(PROP_G, 0);
            byte b = token.GetValue<byte>(PROP_B, 0);
            byte a = token.GetValue<byte>(PROP_A, 0);

            return new Color32(r, g, b, a);
        }

        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            Color32 col = value;

            writer.WriteStartObject();

            writer.WritePropertyName(PROP_R);
            writer.WriteValue(col.r);
            writer.WritePropertyName(PROP_G);
            writer.WriteValue(col.g);
            writer.WritePropertyName(PROP_B);
            writer.WriteValue(col.b);
            writer.WritePropertyName(PROP_A);
            writer.WriteValue(col.a);

            writer.WriteEndObject();
        }
    }
}
