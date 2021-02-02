using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Vector3Converter : JsonConverter<Vector3>
    {
        public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            float x = 0;
            float y = 0;
            float z = 0;

            if (token["x"] != null)
            {
                x = (float)token["x"];
            }

            if (token["y"] != null)
            {
                y = (float)token["y"];
            }

            if (token["z"] != null)
            {
                z = (float)token["z"];
            }

            return new Vector3(x, y, z);
        }

        public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("x");
            writer.WriteValue(value.x);
            writer.WritePropertyName("y");
            writer.WriteValue(value.y);
            writer.WritePropertyName("z");
            writer.WriteValue(value.z);

            writer.WriteEndObject();
        }
    }
}
