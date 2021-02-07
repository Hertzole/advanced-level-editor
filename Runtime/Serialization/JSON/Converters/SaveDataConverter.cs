using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        private const string PROP_OBJECT_PALETTE = "objectPalette";
        private const string PROP_TYPE_PALETTE = "typePalette";
        private const string PROP_NAME = "name";
        private const string PROP_OBJECTS = "objects";
        private const string PROP_CUSTOM_DATA = "customData";

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

            JToken token = JToken.Load(reader);

            objectPalette = token.GetValue(PROP_OBJECT_PALETTE, new Dictionary<string, int>());
            typePalette = token.GetValue(PROP_TYPE_PALETTE, new Dictionary<string, int>());

            foreach (KeyValuePair<string, int> o in objectPalette)
            {
                invertedObjectPalette.Add(o.Value, o.Key);
            }

            foreach (KeyValuePair<string, int> t in typePalette)
            {
                invertedTypePalette.Add(t.Value, t.Key);
            }

            data.name = token.GetValue(PROP_NAME, string.Empty);
            data.objects = token.GetValue(PROP_OBJECTS, new List<LevelEditorObjectData>(), serializer);
            data.customData = token.GetValue(PROP_CUSTOM_DATA, new Dictionary<string, LevelEditorCustomData>(), serializer);

            return data;
        }

        public override void WriteJson(JsonWriter writer, LevelEditorSaveData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_OBJECT_PALETTE);
            serializer.Serialize(writer, objectPalette);
            writer.WritePropertyName(PROP_TYPE_PALETTE);
            serializer.Serialize(writer, typePalette);

            writer.WritePropertyName(PROP_NAME);
            writer.WriteValue(value.name);
            writer.WritePropertyName(PROP_OBJECTS);
            serializer.Serialize(writer, value.objects);

            writer.WritePropertyName(PROP_CUSTOM_DATA);
            serializer.Serialize(writer, value.customData);

            writer.WriteEndObject();
        }
    }
}
