using System.Collections.Generic;

namespace Hertzole.ALE
{
    public static class SerializationHelper
    {
        public static Dictionary<string, int> GetTypePalette(LevelEditorSaveData data)
        {
            Dictionary<string, int> palette = new Dictionary<string, int>();
            int nextID = 0;
            for (int i = 0; i < data.objects.Count; i++)
            {
                for (int j = 0; j < data.objects[i].components.Length; j++)
                {
                    LevelEditorComponentData comp = data.objects[i].components[j];

                    if (!palette.ContainsKey(comp.type))
                    {
                        palette.Add(comp.type, nextID);
                        nextID++;
                    }

                    for (int k = 0; k < comp.properties.Length; k++)
                    {
                        LevelEditorPropertyData prop = comp.properties[k];
                        if (!palette.ContainsKey(prop.typeName))
                        {
                            palette.Add(prop.typeName, nextID);
                            nextID++;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, LevelEditorCustomData> customData in data.customData)
            {
                if (!palette.ContainsKey(customData.Value.type))
                {
                    palette.Add(customData.Value.type, nextID);
                    nextID++;
                }
            }

            return palette;
        }

        public static Dictionary<string, int> GetObjectPalette(LevelEditorSaveData data)
        {
            Dictionary<string, int> palette = new Dictionary<string, int>();
            int nextID = 0;
            for (int i = 0; i < data.objects.Count; i++)
            {
                if (!palette.ContainsKey(data.objects[i].id))
                {
                    palette.Add(data.objects[i].id, nextID);
                    nextID++;
                }
            }

            return palette;
        }
    }
}
