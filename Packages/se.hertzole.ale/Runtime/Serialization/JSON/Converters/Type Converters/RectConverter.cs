using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class RectConverter : JsonConverter<Rect>
    {
        private const string PROP_X = "x";
        private const string PROP_Y = "y";
        private const string PROP_WIDTH = "w";
        private const string PROP_HEIGHT = "h";

        public override Rect ReadJson(JsonReader reader, Type objectType, Rect existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            float x = token.GetValue(PROP_X, 0f);
            float y = token.GetValue(PROP_Y, 0f);
            float width = token.GetValue(PROP_WIDTH, 0f);
            float height = token.GetValue(PROP_HEIGHT, 0f);

            return new Rect(x, y, width, height);
        }

        public override void WriteJson(JsonWriter writer, Rect value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_X);
            writer.WriteValue(value.x);
            writer.WritePropertyName(PROP_Y);
            writer.WriteValue(value.y);
            writer.WritePropertyName(PROP_WIDTH);
            writer.WriteValue(value.width);
            writer.WritePropertyName(PROP_HEIGHT);
            writer.WriteValue(value.height);

            writer.WriteEndObject();
        }
    }
}
