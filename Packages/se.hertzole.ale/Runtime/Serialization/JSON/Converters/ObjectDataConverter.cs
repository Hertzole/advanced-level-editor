using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class ObjectDataConverter : JsonConverter<LevelEditorObjectData>
    {
        private Dictionary<string, int> objectPalette;
        private Dictionary<int, string> invertedObjectPalette;

        private const string PROP_ID = "id";
        private const string PROP_INSTANCE = "instance";
        private const string PROP_NAME = "name";
        private const string PROP_ACTIVE = "active";
        private const string PROP_COMPONENTS = "components";

        public ObjectDataConverter(Dictionary<string, int> objectPalette)
        {
            this.objectPalette = objectPalette;
        }

        public ObjectDataConverter(Dictionary<int, string> invertedObjectPalette)
        {
            this.invertedObjectPalette = invertedObjectPalette;
        }

        public override LevelEditorObjectData ReadJson(JsonReader reader, Type objectType, LevelEditorObjectData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            string id = invertedObjectPalette[token.GetValue(PROP_ID, 0)];
            int instanceId = token.GetValue(PROP_INSTANCE, 0);
            string name = token.GetValue(PROP_NAME, string.Empty);
            bool active = token.GetValue(PROP_ACTIVE, true);
            LevelEditorComponentData[] components = token.GetValue(PROP_COMPONENTS, Array.Empty<LevelEditorComponentData>(), serializer);

            return new LevelEditorObjectData() { id = id, instanceId = instanceId, name = name, active = active, components = components };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorObjectData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_ID);
            writer.WriteValue(objectPalette[value.id]);
            writer.WritePropertyName(PROP_INSTANCE);
            writer.WriteValue(value.instanceId);
            writer.WritePropertyName(PROP_NAME);
            writer.WriteValue(value.name);
            writer.WritePropertyName(PROP_ACTIVE);
            writer.WriteValue(value.active);
            writer.WritePropertyName(PROP_COMPONENTS);
            serializer.Serialize(writer, value.components);

            writer.WriteEndObject();
        }
    }
}
