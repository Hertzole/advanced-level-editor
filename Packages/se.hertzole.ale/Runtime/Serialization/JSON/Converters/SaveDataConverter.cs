using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Json
{
    public class SaveDataConverter : JsonConverter<LevelEditorSaveData>
    {
        private Dictionary<string, int> objectPalette;
        private Dictionary<string, int> typePalette;

        private Dictionary<int, string> invertedObjectPalette;
        private Dictionary<int, string> invertedTypePalette;

        public SaveDataConverter(Dictionary<string, int> objectPalette, Dictionary<string, int> typePalette)
        {
            this.objectPalette = objectPalette;
            this.typePalette = typePalette;
        }

        public SaveDataConverter(Dictionary<int, string> invertedObjectPalette, Dictionary<int, string> invertedTypePalette)
        {
            this.invertedObjectPalette = invertedObjectPalette;
            this.invertedTypePalette = invertedTypePalette;
        }

        public override LevelEditorSaveData ReadJson(JsonReader reader, Type objectType, LevelEditorSaveData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            LevelEditorSaveData data = new LevelEditorSaveData(null);

            reader.Read();

            reader.Read();
            objectPalette = serializer.Deserialize<Dictionary<string, int>>(reader);

            reader.Read();
            reader.Read();
            typePalette = serializer.Deserialize<Dictionary<string, int>>(reader);

            foreach (KeyValuePair<string, int> o in objectPalette)
            {
                invertedObjectPalette.Add(o.Value, o.Key);
            }

            foreach (KeyValuePair<string, int> t in typePalette)
            {
                invertedTypePalette.Add(t.Value, t.Key);
            }

            reader.Read();
            data.name = reader.ReadAsString();
            reader.Read();
            reader.Read();
            data.objects = serializer.Deserialize<List<LevelEditorObjectData>>(reader);

            reader.Read();
            reader.Read();
            data.customData = serializer.Deserialize<Dictionary<string, LevelEditorCustomData>>(reader);

            reader.Read();

            return data;
        }

        public override void WriteJson(JsonWriter writer, LevelEditorSaveData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("objectPalette");
            serializer.Serialize(writer, objectPalette);
            writer.WritePropertyName("typePalette");
            serializer.Serialize(writer, typePalette);

            writer.WritePropertyName("name");
            writer.WriteValue(value.name);
            writer.WritePropertyName("objects");
            serializer.Serialize(writer, value.objects);

            writer.WritePropertyName("customData");
            serializer.Serialize(writer, value.customData);

            writer.WriteEndObject();
        }
    }
}
