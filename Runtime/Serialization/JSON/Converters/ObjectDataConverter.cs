using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class ObjectDataConverter : JsonConverter<LevelEditorObjectData>
    {
        private Dictionary<string, int> objectPalette;
        private Dictionary<int, string> invertedObjectPalette;

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
            //reader.Read();

            reader.Read();
            string id = invertedObjectPalette[(int)reader.ReadAsInt32()];
            reader.Read();
            int instanceId = (int)reader.ReadAsInt32();
            reader.Read();
            string name = reader.ReadAsString();
            reader.Read();
            bool active = (bool)reader.ReadAsBoolean();
            reader.Read();
            reader.Read();
            LevelEditorComponentData[] components = serializer.Deserialize<LevelEditorComponentData[]>(reader);

            reader.Read();

            return new LevelEditorObjectData() { id = id, instanceId = instanceId, name = name, active = active, components = components };
        }

        public override void WriteJson(JsonWriter writer, LevelEditorObjectData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteValue(objectPalette[value.id]);
            writer.WritePropertyName("instance");
            writer.WriteValue(value.instanceId);
            writer.WritePropertyName("name");
            writer.WriteValue(value.name);
            writer.WritePropertyName("active");
            writer.WriteValue(value.active);
            writer.WritePropertyName("components");
            serializer.Serialize(writer, value.components);

            writer.WriteEndObject();
        }
    }
}
