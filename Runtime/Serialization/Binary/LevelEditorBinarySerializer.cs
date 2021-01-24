using Hertzole.ALE.External;
using System.Collections.Generic;
using System.IO;

namespace Hertzole.ALE
{
    public static class LevelEditorBinarySerializer
    {
        public const int SAVE_VERSION = 1;

        private static readonly BaseFormatter[] standardFormatters = new BaseFormatter[]
        {
            new BoolFormatter(),
            new ByteFormatter(),
            new SByteFormatter(),
            new ShortFormatter(),
            new UShortFormatter(),
            new IntFormatter(),
            new UIntFormatter(),
            new LongFormatter(),
            new ULongFormatter(),
            new FloatFormatter(),
            new DoubleFormatter(),
            new DecimalFormatter(),
            new StringFormatter(),
            new CharFormatter(),
            new Vector2Formatter(),
            new Vector2IntFormatter(),
            new Vector3Formatter(),
            new Vector3IntFormatter(),
            new Vector4Formatter(),
            new ColorFormatter(),
            new Color32Formatter(),
            new UnityComponentFormatter()
        };

        public static void Serialize(LevelEditorSaveData data, string path, params BaseFormatter[] formatters)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            BaseFormatter[] allFormatters = CombineFormatters(standardFormatters, formatters);

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

            //var writeStream = File.Open(path, FileMode.Create);

            using (MemoryStream writeStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(writeStream))
                {
                    writer.Write(SAVE_VERSION);
                    writer.Write(data.name);

                    writer.Write(objectPalette.Count);
                    // Write all the object IDs and their type ID.
                    foreach (KeyValuePair<string, int> obj in objectPalette)
                    {
                        writer.Write(obj.Key);
                        writer.Write(obj.Value);
                    }

                    writer.Write(typePalette.Count); // Write how many types there are.
                    foreach (KeyValuePair<string, int> type in typePalette)
                    {
                        writer.Write(type.Key);
                        writer.Write(type.Value);
                    }

                    writer.Write(data.objects.Count); // Write how many objects there are in the level.
                    for (int i = 0; i < data.objects.Count; i++)
                    {
                        LevelEditorObjectData obj = data.objects[i];
                        writer.Write(objectPalette[obj.id]); // Use the palette to save space.
                        writer.Write(obj.instanceId);
                        writer.Write(obj.name);
                        writer.Write(obj.active);
                        writer.Write(obj.components.Length); // Write how many components there are on the object.
                        for (int j = 0; j < obj.components.Length; j++)
                        {
                            LevelEditorComponentData comp = obj.components[j];
                            writer.Write(typePalette[comp.type]); // Use the palette to save space.
                            writer.Write(comp.properties.Length); // Write how many properties there are on the object.
                            for (int k = 0; k < comp.properties.Length; k++)
                            {
                                LevelEditorPropertyData prop = comp.properties[k];
                                writer.Write(prop.id); // Write property name.
                                writer.Write(typePalette[prop.typeName]); // Write type name.
                                writer.Write(prop.isArray); // Write if it's an array.
                                if (prop.isArray)
                                {
                                    object[] valueArray = (object[])prop.value;

                                    writer.Write(valueArray.Length); // Write array length.

                                    if (TryGetFormatter(prop.typeName, allFormatters, out BaseFormatter formatter))
                                    {
                                        for (int v = 0; v < valueArray.Length; v++)
                                        {
                                            formatter.Serialize(valueArray[i], writer);
                                        }
                                    }
                                }
                                else
                                {
                                    if (TryGetFormatter(prop.typeName, allFormatters, out BaseFormatter formatter))
                                    {
                                        formatter.Serialize(prop.value, writer);
                                    }
                                }
                            }
                        }
                    }

                    writer.Write(data.customData.Count);
                    foreach (KeyValuePair<string, LevelEditorCustomData> custom in data.customData)
                    {
                        writer.Write(custom.Key);
                        writer.Write(typePalette[custom.Value.type]);
                        if (TryGetFormatter(custom.Value.type, allFormatters, out BaseFormatter formatter))
                        {
                            formatter.Serialize(custom.Value.value, writer);
                        }
                    }
                }

                //TODO: Make compression optional. It needs to be able to detect if a file is compressed.
                byte[] compressedBytes = CLZF2.Compress(writeStream.ToArray());
                File.WriteAllBytes(path, compressedBytes);
            }
        }

        public static LevelEditorSaveData Deserialize(string path, params BaseFormatter[] formatters)
        {
            return Deserialize(File.ReadAllBytes(path), formatters);
        }

        public static LevelEditorSaveData Deserialize(byte[] bytes, params BaseFormatter[] formatters)
        {
            BaseFormatter[] allFormatters = CombineFormatters(standardFormatters, formatters);

            LevelEditorSaveData data = new LevelEditorSaveData();

            byte[] uncompressedBytes = CLZF2.Decompress(bytes);

            using (MemoryStream fileStream = new MemoryStream(uncompressedBytes))
            {
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    int saveVersion = reader.ReadInt32();
                    data.name = reader.ReadString();

                    int objectPaletteCount = reader.ReadInt32();
                    // The palette is reversed compared to the serialize method due to when reading you only get the int ID 
                    // so it's much easier to map int to string.
                    Dictionary<int, string> objectPalette = new Dictionary<int, string>();
                    for (int i = 0; i < objectPaletteCount; i++)
                    {
                        string strId = reader.ReadString(); // Read the object ID.
                        int intId = reader.ReadInt32(); // Read the type ID.
                        objectPalette.Add(intId, strId);
                    }

                    int typePaletteCount = reader.ReadInt32();
                    Dictionary<int, string> typePalette = new Dictionary<int, string>();
                    for (int i = 0; i < typePaletteCount; i++)
                    {
                        string strId = reader.ReadString();
                        int intId = reader.ReadInt32();
                        typePalette.Add(intId, strId);
                    }

                    int objectCount = reader.ReadInt32();
                    data.objects = new List<LevelEditorObjectData>();
                    for (int i = 0; i < objectCount; i++)
                    {
                        LevelEditorObjectData obj = new LevelEditorObjectData
                        {
                            id = objectPalette[reader.ReadInt32()],
                            instanceId = reader.ReadInt32(),
                            name = reader.ReadString(),
                            active = reader.ReadBoolean()
                        };

                        int componentCount = reader.ReadInt32();
                        obj.components = new LevelEditorComponentData[componentCount];
                        for (int j = 0; j < componentCount; j++)
                        {
                            LevelEditorComponentData comp = new LevelEditorComponentData
                            {
                                type = typePalette[reader.ReadInt32()]
                            };

                            int propertyCount = reader.ReadInt32();
                            comp.properties = new LevelEditorPropertyData[propertyCount];
                            for (int k = 0; k < propertyCount; k++)
                            {
                                LevelEditorPropertyData prop = new LevelEditorPropertyData
                                {
                                    id = reader.ReadInt32(),
                                    typeName = typePalette[reader.ReadInt32()]
                                };
                                bool isArray = reader.ReadBoolean(); // Read if it's an array.
                                if (isArray)
                                {
                                    int arrayLength = reader.ReadInt32(); // Read array length.
                                    if (TryGetFormatter(prop.typeName, allFormatters, out BaseFormatter formatter))
                                    {
                                        object[] valueArray = new object[arrayLength];
                                        for (int v = 0; v < arrayLength; v++)
                                        {
                                            valueArray[v] = formatter.DeserializeValue(reader);
                                        }
                                    }
                                }
                                else
                                {
                                    if (TryGetFormatter(prop.typeName, allFormatters, out BaseFormatter formatter))
                                    {
                                        prop.value = formatter.DeserializeValue(reader);
                                    }
                                }

                                comp.properties[k] = prop;
                            }

                            obj.components[j] = comp;
                        }

                        data.objects.Add(obj);
                    }

                    int customDataCount = reader.ReadInt32();
                    data.customData = new Dictionary<string, LevelEditorCustomData>();
                    for (int i = 0; i < customDataCount; i++)
                    {
                        string key = reader.ReadString();
                        string type = typePalette[reader.ReadInt32()];
                        if (TryGetFormatter(type, allFormatters, out BaseFormatter formatter))
                        {
                            object value = formatter.DeserializeValue(reader);
                            data.customData.Add(key, new LevelEditorCustomData(type, value));
                        }
                    }
                }
            }

            return data;
        }

        private static bool TryGetFormatter(string type, BaseFormatter[] formatters, out BaseFormatter formatter)
        {
            if (formatters == null || formatters.Length == 0)
            {
                LevelEditorLogger.DebugLogError("Couldn't serialize a value. No formatter for type '" + type + "'.");
                formatter = null;
                return false;
            }

            for (int i = 0; i < formatters.Length; i++)
            {
                if (formatters[i].TypeName == type)
                {
                    formatter = formatters[i];
                    return true;
                }
            }

            LevelEditorLogger.DebugLogError("Couldn't serialize a value. No formatter for type '" + type + "'.");
            formatter = null;
            return false;
        }

        private static BaseFormatter[] CombineFormatters(BaseFormatter[] standard, BaseFormatter[] custom)
        {
            if (custom == null || custom.Length == 0)
            {
                return standard;
            }

            BaseFormatter[] allFormatters = new BaseFormatter[standard.Length + custom.Length];
            for (int i = 0; i < standard.Length; i++)
            {
                allFormatters[i] = standard[i];
            }

            for (int i = standard.Length; i < custom.Length + standard.Length; i++)
            {
                allFormatters[i] = custom[i - standard.Length];
            }

            return allFormatters;
        }
    }
}
