using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Vector3IntConverter : JsonConverter<Vector3Int>
    {
        private const string PROP_X = "x";
        private const string PROP_Y = "y";
        private const string PROP_Z = "z";

        public override Vector3Int ReadJson(JsonReader reader, Type objectType, Vector3Int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            int x = token.GetValue(PROP_X, 0);
            int y = token.GetValue(PROP_Y, 0);
            int z = token.GetValue(PROP_Z, 0);

            return new Vector3Int(x, y, z);
        }

        public override void WriteJson(JsonWriter writer, Vector3Int value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_X);
            writer.WriteValue(value.x);
            writer.WritePropertyName(PROP_Y);
            writer.WriteValue(value.y);
            writer.WritePropertyName(PROP_Z);
            writer.WriteValue(value.z);

            writer.WriteEndObject();
        }
    }
}
