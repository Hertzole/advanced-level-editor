using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class QuaternionConverter : JsonConverter<Quaternion>
    {
        private const string PROP_X = "x";
        private const string PROP_Y = "y";
        private const string PROP_Z = "z";
        private const string PROP_W = "w";

        public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            float x = token.GetValue(PROP_X, 0f);
            float y = token.GetValue(PROP_Y, 0f);
            float z = token.GetValue(PROP_Z, 0f);
            float w = token.GetValue(PROP_W, 0f);

            return new Quaternion(x, y, z, w);
        }

        public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_X);
            writer.WriteValue(value.x);
            writer.WritePropertyName(PROP_Y);
            writer.WriteValue(value.y);
            writer.WritePropertyName(PROP_Z);
            writer.WriteValue(value.z);
            writer.WritePropertyName(PROP_W);
            writer.WriteValue(value.w);

            writer.WriteEndObject();
        }
    }
}
