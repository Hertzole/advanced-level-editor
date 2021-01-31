using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if ALE_JSON
using System.Text;
using UnityEngine.Assertions;
using Newtonsoft.Json;
#endif

namespace Hertzole.ALE
{
    public static class LevelEditorSerializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeWritersReaders()
        {
            SetWriterReader<byte>((writer, value, name) => writer.Write((byte)value, name), (reader, withName) => reader.ReadByte(withName));
            SetWriterReader<sbyte>((writer, value, name) => writer.Write((sbyte)value, name), (reader, withName) => reader.ReadSByte(withName));
            SetWriterReader<short>((writer, value, name) => writer.Write((short)value, name), (reader, withName) => reader.ReadShort(withName));
            SetWriterReader<ushort>((writer, value, name) => writer.Write((ushort)value, name), (reader, withName) => reader.ReadUShort(withName));
            SetWriterReader<int>((writer, value, name) => writer.Write((int)value, name), (reader, withName) => reader.ReadInt(withName));
            SetWriterReader<uint>((writer, value, name) => writer.Write((uint)value, name), (reader, withName) => reader.ReadUInt(withName));
            SetWriterReader<long>((writer, value, name) => writer.Write((long)value, name), (reader, withName) => reader.ReadLong(withName));
            SetWriterReader<ulong>((writer, value, name) => writer.Write((ulong)value, name), (reader, withName) => reader.ReadULong(withName));
            SetWriterReader<float>((writer, value, name) => writer.Write((float)value, name), (reader, withName) => reader.ReadFloat(withName));
            SetWriterReader<double>((writer, value, name) => writer.Write((double)value, name), (reader, withName) => reader.ReadDouble(withName));
            SetWriterReader<decimal>((writer, value, name) => writer.Write((decimal)value, name), (reader, withName) => reader.ReadDecimal(withName));
            SetWriterReader<string>((writer, value, name) => writer.Write((string)value, name), (reader, withName) => reader.ReadString(withName));
            SetWriterReader<char>((writer, value, name) => writer.Write((char)value, name), (reader, withName) => reader.ReadChar(withName));
            SetWriterReader<bool>((writer, value, name) => writer.Write((bool)value, name), (reader, withName) => reader.ReadBool(withName));
            SetWriterReader<Vector2>((writer, value, name) => writer.Write((Vector2)value, name), (reader, withName) => reader.ReadVector2(withName));
            SetWriterReader<Vector2Int>((writer, value, name) => writer.Write((Vector2Int)value, name), (reader, withName) => reader.ReadVector2Int(withName));
            SetWriterReader<Vector3>((writer, value, name) => writer.Write((Vector3)value, name), (reader, withName) => reader.ReadVector3(withName));
            SetWriterReader<Vector3Int>((writer, value, name) => writer.Write((Vector3Int)value, name), (reader, withName) => reader.ReadVector3Int(withName));
            SetWriterReader<Vector4>((writer, value, name) => writer.Write((Vector4)value, name), (reader, withName) => reader.ReadVector4(withName));
            SetWriterReader<Quaternion>((writer, value, name) => writer.Write((Quaternion)value, name), (reader, withName) => reader.ReadQuaternion(withName));
            SetWriterReader<Color>((writer, value, name) => writer.Write((Color)value, name), (reader, withName) => reader.ReadColor(withName));
            SetWriterReader<Color32>((writer, value, name) => writer.Write((Color32)value, name), (reader, withName) => reader.ReadColor32(withName));
            SetWriterReader<Component>((writer, value, name) => writer.Write((Component)value, name), (reader, withName) => reader.ReadComponent(withName));
        }

        private static Dictionary<string, Action<LevelEditorWriter, object, string>> writers = new Dictionary<string, Action<LevelEditorWriter, object, string>>();

        private static Dictionary<string, Func<LevelEditorReader, bool, object>> readers = new Dictionary<string, Func<LevelEditorReader, bool, object>>();

        public static void SetWriterReader<T>(Action<LevelEditorWriter, object, string> writer, Func<LevelEditorReader, bool, object> reader)
        {
            writers[typeof(T).FullName] = writer;
            readers[typeof(T).FullName] = reader;
            LevelEditorWriter<T>.WriteAction = writer;
            LevelEditorReader<T>.ReadAction = reader;
        }

        public static byte[] SerializeBinary(LevelEditorSaveData data)
        {
            MemoryStream stream = new MemoryStream();
            LevelEditorWriter writer = new LevelEditorWriter(new BinaryWriter(stream));

            Serialize(data, writer);

            byte[] bytes = stream.ToArray();
            writer.Dispose();
            stream.Dispose();

            return bytes;
        }

#if !ALE_JSON
        [Obsolete("SerializeJson can only be used with the Json.Net package. Install 'com.unity.nuget-newtonsoft-json' package to use Json.")]
#endif
        public static string SerializeJson(LevelEditorSaveData data, bool prettyPrint = false)
        {
#if ALE_JSON
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            LevelEditorWriter writer = new LevelEditorWriter(new JsonTextWriter(sw) { Formatting = prettyPrint ? Formatting.Indented : Formatting.None });
            Serialize(data, writer);

            writer.Dispose();
            sw.Dispose();

            return sb.ToString();
#else
            return string.Empty;
#endif
        }

        public static LevelEditorSaveData DeserializeBinary(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            BinaryReader reader = new BinaryReader(stream);

            LevelEditorSaveData data = Deserialize(new LevelEditorReader(reader));

            reader.Dispose();
            stream.Dispose();

            return data;
        }

#if !ALE_JSON
        [Obsolete("SerializeJson can only be used with the Json.Net package. Install 'com.unity.nuget-newtonsoft-json' package to use Json.")]
#endif
        public static LevelEditorSaveData DeserializeJson(string json)
        {
#if ALE_JSON
            JsonTextReader reader = new JsonTextReader(new StringReader(json));

            LevelEditorSaveData data = Deserialize(new LevelEditorReader(reader));
            ((IDisposable)reader).Dispose();

            return data;
#else
            return new LevelEditorSaveData();
#endif
        }

        private static void Serialize(LevelEditorSaveData data, LevelEditorWriter writer)
        {
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

            writer.WriteStartObject();

            writer.Write(data.name, "name");

            if (writer.IsJson)
            {
                writer.WriteStartObject("objectPalette");
                foreach (KeyValuePair<string, int> obj in objectPalette)
                {
                    writer.Write(obj.Value, obj.Key);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartArray(objectPalette.Count, "objectPalette");
                // Write all the object IDs and their type ID.
                foreach (KeyValuePair<string, int> obj in objectPalette)
                {
                    writer.Write(obj.Key, "key");
                    writer.Write(obj.Value, "value");
                }
                writer.WriteEndArray();
            }

            if (writer.IsJson)
            {
                writer.WriteStartObject("typePalette");
                foreach (KeyValuePair<string, int> obj in typePalette)
                {
                    writer.Write(obj.Value, obj.Key);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartArray(typePalette.Count, "typePalette"); // Write how many types there are.
                foreach (KeyValuePair<string, int> type in typePalette)
                {
                    writer.WriteStartObject();

                    writer.Write(type.Key, "key");
                    writer.Write(type.Value, "value");

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();
            }

            writer.WriteStartArray(data.objects.Count, "objects"); // Write how many objects there are in the level.
            for (int i = 0; i < data.objects.Count; i++)
            {
                LevelEditorObjectData obj = data.objects[i];

                writer.WriteStartObject();

                writer.Write(objectPalette[obj.id], "id"); // Use the palette to save space.
                writer.Write(obj.instanceId, "instanceID");
                writer.Write(obj.name, "name");
                writer.Write(obj.active, "active");
                writer.WriteStartArray(obj.components.Length, "components"); // Write how many components there are on the object.
                for (int j = 0; j < obj.components.Length; j++)
                {
                    LevelEditorComponentData comp = obj.components[j];

                    writer.WriteStartObject();

                    writer.Write(typePalette[comp.type], "type"); // Use the palette to save space.
                    writer.WriteStartArray(comp.properties.Length, "properties"); // Write how many properties there are on the object.
                    for (int k = 0; k < comp.properties.Length; k++)
                    {
                        LevelEditorPropertyData prop = comp.properties[k];

                        writer.WriteStartObject();

                        writer.Write(prop.id, "id"); // Write property name.
                        writer.Write(typePalette[prop.typeName], "type"); // Write type name.
                        writer.Write(prop.isArray, "isArray"); // Write if it's an array.
                        WriteCustomType(writer, prop.typeName, prop.value, prop.isArray);
                        writer.WriteEndObject(); // Property
                    }
                    writer.WriteEndArray(); // Properties
                    writer.WriteEndObject(); // Component
                }
                writer.WriteEndArray(); // Components
                writer.WriteEndObject(); // Object
            }

            writer.WriteEndArray(); // Objects

            writer.WriteStartArray(data.customData.Count, "customData");

            foreach (KeyValuePair<string, LevelEditorCustomData> cData in data.customData)
            {
                writer.WriteStartObject();
                writer.Write(cData.Key, "key");
                writer.Write(typePalette[cData.Value.type], "type");
                writer.Write(cData.Value.isArray, "isArray");

                WriteCustomType(writer, cData.Value.type, cData.Value.value, cData.Value.isArray);

                writer.WriteEndObject();
            }

            writer.WriteEndArray(); // Custom data

            writer.WriteEndObject(); // Data
        }

        private static void WriteCustomType(LevelEditorWriter writer, string type, object value, bool isArray)
        {
            if (TryGetWriter(type, out Action<LevelEditorWriter, object, string> typeWriter))
            {
                if (isArray)
                {
                    object[] valueArray = (object[])value;

                    writer.WriteStartArray(valueArray.Length);
                    for (int v = 0; v < valueArray.Length; v++)
                    {
                        typeWriter.Invoke(writer, valueArray[v], string.Empty);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    typeWriter.Invoke(writer, value, "value");
                }
            }
        }

        private static LevelEditorSaveData Deserialize(LevelEditorReader reader)
        {
            LevelEditorSaveData data = new LevelEditorSaveData(null);

            reader.ReadObjectStart();
            data.name = reader.ReadString();

            // The palette is reversed compared to the serialize method due to when reading you only get the int ID 
            // so it's much easier to map int to string.
            Dictionary<int, string> objectPalette = new Dictionary<int, string>();
            Dictionary<int, string> typePalette = new Dictionary<int, string>();

            ReadPalette(reader, objectPalette);
            ReadPalette(reader, typePalette);

            data.objects = new List<LevelEditorObjectData>();

            reader.ReadArray(true, (i) =>
            {
                int id = reader.ReadInt();
                int instanceID = reader.ReadInt();
                string name = reader.ReadString();
                bool active = reader.ReadBool();

                LevelEditorObjectData obj = new LevelEditorObjectData
                {
                    id = objectPalette[id],
                    instanceId = instanceID,
                    name = name,
                    active = active
                };

                List<LevelEditorComponentData> components = new List<LevelEditorComponentData>();

                reader.ReadArray(true, (j) =>
                {
                    LevelEditorComponentData comp = new LevelEditorComponentData();

                    List<LevelEditorPropertyData> properties = new List<LevelEditorPropertyData>();

                    int type = reader.ReadInt();
                    comp.type = typePalette[type];
                    reader.ReadArray(true, (k) =>
                    {
                        int propertyId = reader.ReadInt();
                        int propertyType = reader.ReadInt();
                        bool isArray = reader.ReadBool();

                        LevelEditorPropertyData prop = new LevelEditorPropertyData
                        {
                            id = propertyId,
                            typeName = typePalette[propertyType],
                            isArray = isArray
                        };

                        if (TryGetReader(prop.typeName, out Func<LevelEditorReader, bool, object> typeReader))
                        {
                            if (isArray)
                            {
                                List<object> objectArray = new List<object>();

                                reader.ReadArray(false, (x) =>
                                {
                                    object value = typeReader.Invoke(reader, false);

#if ALE_JSON
                                    if (reader.IsJson && reader.Json.TokenType == JsonToken.EndArray)
                                    {
                                        return false;
                                    }
#endif

                                    objectArray.Add(value);

                                    return true;
                                });

                                prop.value = objectArray.ToArray();
                            }
                            else
                            {
                                prop.value = typeReader.Invoke(reader, true);
                            }
                        }

                        properties.Add(prop);

                        return true;
                    });

                    comp.properties = properties.ToArray();
                    components.Add(comp);

                    return true;
                });

                obj.components = components.ToArray();
                data.objects.Add(obj);

                return true;
            });

            reader.ReadArray(true, (i) =>
            {
                string key = reader.ReadString();
                string type = typePalette[reader.ReadInt()];
                bool isArray = reader.ReadBool();
                object value = null;

                if (TryGetReader(type, out Func<LevelEditorReader, bool, object> typeReader))
                {
                    if (isArray)
                    {
                        List<object> objectArray = new List<object>();

                        reader.ReadArray(false, (x) =>
                        {
                            object value = typeReader.Invoke(reader, false);

#if ALE_JSON
                            if (reader.IsJson && reader.Json.TokenType == JsonToken.EndArray)
                            {
                                return false;
                            }
#endif

                            objectArray.Add(value);

                            return true;
                        });

                        value = objectArray.ToArray();
                    }
                    else
                    {
                        value = typeReader.Invoke(reader, true);
                    }
                }

                data.customData.Add(key, new LevelEditorCustomData(type, isArray, value));

                return true;
            });

            reader.ReadObjectEnd(); // Data end

            return data;
        }

        private static bool TryGetWriter(string type, out Action<LevelEditorWriter, object, string> writer)
        {
            if (writers.TryGetValue(type, out writer))
            {
                return true;
            }
            else
            {
                Debug.LogWarning($"No writer for type '{type}'.");
                return false;
            }
        }

        private static bool TryGetReader(string type, out Func<LevelEditorReader, bool, object> reader)
        {
            if (readers.TryGetValue(type, out reader))
            {
                return true;
            }
            else
            {
                Debug.LogWarning($"No reader for type '{type}'.");
                return false;
            }
        }

        private static void ReadPalette(LevelEditorReader reader, Dictionary<int, string> palette)
        {
            if (reader.IsJson)
            {
#if ALE_JSON
                reader.Json.Read();
                reader.Json.Read();
                Assert.AreEqual(reader.Json.TokenType, JsonToken.StartObject);
                while (reader.Json.TokenType != JsonToken.EndObject)
                {
                    reader.Json.Read();
                    if (reader.Json.TokenType == JsonToken.EndObject)
                    {
                        break;
                    }

                    if (reader.Json.Value is string key)
                    {
                        int value = (int)reader.Json.ReadAsInt32();
                        palette.Add(value, key);
                    }
                }
#endif
            }
            else
            {
                reader.ReadArray(false, (i) =>
                {
                    string stringId = reader.ReadString();
                    int intId = reader.ReadInt();
                    palette.Add(intId, stringId);

                    return true;
                });
            }
        }
    }
}
