#if ALE_JSON
using Newtonsoft.Json;
#endif
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hertzole.ALE
{
#if !ALE_JSON
    [System.Obsolete("Install 'com.unity.nuget.newtonsoft-json' in the package manager to enable JSON support.")]
#endif
    [System.Obsolete("Work in progress and not ready to use!")]
    public static class LevelEditorJSONSerializer
    {
        public static void Serialize(LevelEditorSaveData data, string path, bool prettyPrint = false)
        {
#if ALE_JSON
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            Dictionary<string, int> objectPalette = new Dictionary<string, int>();
            int nextID = 0;
            for (int i = 0; i < data.objects.Count; i++)
            {
                if (!objectPalette.ContainsKey(data.objects[i].id))
                {
                    objectPalette.Add(data.objects[i].id, nextID);
                    nextID++;
                }
            }

            Dictionary<string, int> typePalette = new Dictionary<string, int>();
            nextID = 0;
            for (int i = 0; i < data.objects.Count; i++)
            {
                for (int j = 0; j < data.objects[i].components.Length; j++)
                {
                    LevelEditorComponentData comp = data.objects[i].components[j];

                    if (!typePalette.ContainsKey(comp.type))
                    {
                        typePalette.Add(comp.type, nextID);
                        nextID++;
                    }

                    for (int k = 0; k < comp.properties.Length; k++)
                    {
                        LevelEditorPropertyData prop = comp.properties[k];
                        if (!typePalette.ContainsKey(prop.typeName))
                        {
                            typePalette.Add(prop.typeName, nextID);
                            nextID++;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, LevelEditorCustomData> customData in data.customData)
            {
                if (!typePalette.ContainsKey(customData.Value.type))
                {
                    typePalette.Add(customData.Value.type, nextID);
                    nextID++;
                }
            }

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = prettyPrint ? Formatting.Indented : Formatting.None;

                writer.WriteStartObject();

                writer.WritePropertyName("name");
                writer.WriteValue(data.name);

                writer.WritePropertyName("objectPalette");
                writer.WriteStartObject();

                foreach (KeyValuePair<string, int> obj in objectPalette)
                {
                    writer.WritePropertyName(obj.Key);
                    writer.WriteValue(obj.Value);
                }

                writer.WriteEndObject();

                writer.WritePropertyName("typePalette");
                writer.WriteStartObject();

                foreach (KeyValuePair<string, int> type in typePalette)
                {
                    writer.WritePropertyName(type.Key);
                    writer.WriteValue(type.Value);
                }

                writer.WriteEndObject();

                writer.WritePropertyName("objects");
                writer.WriteStartArray();

                for (int i = 0; i < data.objects.Count; i++)
                {
                    writer.WriteStartObject();

                    LevelEditorObjectData obj = data.objects[i];
                    writer.WritePropertyName("id");
                    writer.WriteValue(objectPalette[obj.id]);
                    writer.WritePropertyName("instanceID");
                    writer.WriteValue(obj.instanceId);
                    writer.WritePropertyName("name");
                    writer.WriteValue(obj.name);
                    writer.WritePropertyName("active");
                    writer.WriteValue(obj.active);

                    writer.WritePropertyName("components");
                    writer.WriteStartArray();

                    for (int j = 0; j < obj.components.Length; j++)
                    {
                        writer.WriteStartObject();

                        LevelEditorComponentData comp = obj.components[j];
                        writer.WritePropertyName("type");
                        writer.WriteValue(typePalette[comp.type]);
                        writer.WritePropertyName("properties");
                        writer.WriteStartArray();

                        for (int k = 0; k < comp.properties.Length; k++)
                        {
                            writer.WriteStartObject();

                            LevelEditorPropertyData prop = comp.properties[k];
                            writer.WritePropertyName("id");
                            writer.WriteValue(prop.id);
                            writer.WritePropertyName("type");
                            writer.WriteValue(typePalette[prop.typeName]);
                            writer.WritePropertyName("isArray");
                            writer.WriteValue(prop.isArray);
                            if (prop.isArray)
                            {

                            }
                            else
                            {
                                writer.WritePropertyName("value");
                                writer.WriteValue(prop.value);
                            }

                            writer.WriteEndObject();
                        }

                        writer.WriteEndArray();

                        writer.WriteEndObject();
                    }

                    writer.WriteEndArray();

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();

                writer.WriteEndObject();
            }

            File.WriteAllText(path, sb.ToString());
#endif
        }


    }
}
