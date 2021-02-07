using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Color32Converter : JsonConverter<Color32>
    {
        private const string PROP_R = "r";
        private const string PROP_G = "g";
        private const string PROP_B = "b";
        private const string PROP_A = "a";

        public override Color32 ReadJson(JsonReader reader, Type objectType, Color32 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            byte r = token.GetValue<byte>(PROP_R, 0);
            byte g = token.GetValue<byte>(PROP_G, 0);
            byte b = token.GetValue<byte>(PROP_B, 0);
            byte a = token.GetValue<byte>(PROP_A, 0);

            return new Color32(r, g, b, a);
        }

        public override void WriteJson(JsonWriter writer, Color32 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_R);
            writer.WriteValue(value.r);
            writer.WritePropertyName(PROP_G);
            writer.WriteValue(value.g);
            writer.WritePropertyName(PROP_B);
            writer.WriteValue(value.b);
            writer.WritePropertyName(PROP_A);
            writer.WriteValue(value.a);

            writer.WriteEndObject();
        }
    }
}
