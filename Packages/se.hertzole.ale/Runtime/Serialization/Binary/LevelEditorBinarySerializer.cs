using System.Collections.Generic;
using System.IO;

namespace Hertzole.ALE
{
    [System.Obsolete("LevelEditorBinarySerializer is not ready for production yet.")]
    public static class LevelEditorBinarySerializer
    {
        public const byte SAVE_VERSION = 1;

        public static byte[] Serialize(LevelEditorSaveData data)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            byte[] result = null;

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

            try
            {
                writer.Write(SAVE_VERSION);
                writer.Write(data.name);

                writer.Write(data.objects.Count);
                foreach (LevelEditorObjectData obj in data.objects)
                {
                    writer.Write(typePalette[obj.id]);
                    writer.Write(obj.instanceId);
                    writer.Write(obj.name);
                    writer.Write(obj.active);

                    foreach (LevelEditorComponentData comp in obj.components)
                    {
                        writer.Write(typePalette[comp.type]);
                        writer.Write(comp.properties.Length);

                        foreach (LevelEditorPropertyData prop in comp.properties)
                        {
                            writer.Write(prop.id);
                            writer.Write(prop.typeName);
                            writer.Write(prop.isArray);
                            //TODO: Write value.
                        }
                    }
                }

                writer.Write(data.customData.Count);
                foreach (KeyValuePair<string, LevelEditorCustomData> d in data.customData)
                {
                    writer.Write(d.Key);
                    writer.Write(d.Value.type);
                    writer.Write(d.Value.isArray);
                    //TODO: Write value.
                }

                result = stream.ToArray();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                stream.Dispose();
                writer.Dispose();
            }

            return result;
        }
    }
}
