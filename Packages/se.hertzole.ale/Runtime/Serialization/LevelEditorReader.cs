//using System;
//using System.IO;
//using UnityEngine;
//#if ALE_JSON
//using UnityEngine.Assertions;
//using Newtonsoft.Json;
//#endif

//namespace Hertzole.ALE
//{
//    public static class LevelEditorReader<T>
//    {
//        internal static Func<LevelEditorReader, bool, object> ReadAction { get; set; }
//        internal static T Read(LevelEditorReader reader, bool withName)
//        {
//            return (T)ReadAction.Invoke(reader, withName);
//        }
//    }

//    public class LevelEditorReader : IDisposable
//    {
//        private bool disposedValue;

//        private const string INVALID_COMPONENT = "{0} is not a valid Unity Component to save. It needs to derive from UnityEngine.Component and have a LevelEditorObject component attached.";

//        private BinaryReader binary;
//#if ALE_JSON
//        private JsonReader json;
//#endif

//        public bool IsJson
//        {
//            get
//            {
//#if ALE_JSON
//                return json != null;
//#else
//                return false;
//#endif
//            }
//        }

//        public BinaryReader Binary { get { return binary; } }
//#if ALE_JSON
//        public JsonReader Json { get { return json; } }
//#endif

//        public LevelEditorReader(BinaryReader reader)
//        {
//            binary = reader ?? throw new ArgumentNullException(nameof(reader));
//        }

//#if ALE_JSON
//        public LevelEditorReader(JsonReader reader)
//        {
//            json = reader ?? throw new ArgumentNullException(nameof(reader));
//        }
//#endif

//        public T Read<T>(bool withName = true)
//        {
//            if (LevelEditorReader<T>.ReadAction == null)
//            {
//                Debug.LogWarning($"No reader for '{typeof(T)}'.");
//                return default;
//            }

//            return LevelEditorReader<T>.Read(this, withName);
//        }

//        public void ReadObjectStart(bool withName = false)
//        {
//#if ALE_JSON
//            if (IsJson)
//            {
//                if (withName)
//                {
//                    json.Read();
//                    Assert.AreEqual(json.TokenType, JsonToken.PropertyName);
//                }
//                json.Read();
//                Assert.AreEqual(json.TokenType, JsonToken.StartObject, json.Path);
//            }
//#endif
//        }

//        public void ReadObjectEnd()
//        {
//#if ALE_JSON
//            if (IsJson)
//            {
//                json.Read();
//                Assert.AreEqual(json.TokenType, JsonToken.EndObject);
//            }
//#endif
//        }

//        public void ReadArray(bool readObject, Func<int, bool> forEach)
//        {
//            if (binary != null)
//            {
//                int count = binary.ReadInt32();
//                for (int i = 0; i < count; i++)
//                {
//                    if (!forEach.Invoke(i))
//                    {
//                        break;
//                    }
//                }
//            }
//#if ALE_JSON
//            else
//            {
//                json.Read(); // Read property name.
//                Assert.AreEqual(json.TokenType, JsonToken.PropertyName);
//                json.Read();
//                Assert.AreEqual(json.TokenType, JsonToken.StartArray);
//                int depth = json.Depth;
//                int index = 0;
//                while (true)
//                {
//                    if (readObject)
//                    {
//                        json.Read();
//                    }

//                    if ((json.TokenType == JsonToken.EndArray && json.Depth == depth))
//                    {
//                        break;
//                    }

//                    if (!forEach.Invoke(index))
//                    {
//                        break;
//                    }

//                    if (readObject)
//                    {
//                        json.Read();
//                    }

//                    index++;
//                }
//                Assert.AreEqual(json.TokenType, JsonToken.EndArray);

//            }
//#endif
//        }

//        public byte ReadByte(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadByte();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsByte();
//            }
//#else
//            return 0;
//#endif
//        }

//        public sbyte ReadSByte(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadSByte();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsSByte();
//            }
//#else
//            return 0;
//#endif
//        }

//        public short ReadShort(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadInt16();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsInt16();
//            }
//#else
//            return 0;
//#endif
//        }

//        public ushort ReadUShort(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadUInt16();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsUInt16();
//            }
//#else
//            return 0;
//#endif
//        }

//        public int ReadInt(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadInt32();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return (int)json.ReadAsInt32();
//            }
//#else
//            return 0;
//#endif
//        }

//        public uint ReadUInt(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadUInt32();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsUInt32();
//            }
//#else
//            return 0;
//#endif
//        }

//        public long ReadLong(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadInt64();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsInt64();
//            }
//#else
//            return 0;
//#endif
//        }

//        public ulong ReadULong(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadUInt64();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsUInt64();
//            }
//#else
//            return 0;
//#endif
//        }

//        public float ReadFloat(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadSingle();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read(); // Read property name.
//                }

//                return json.ReadAsFloat();
//            }
//#else
//            return 0;
//#endif
//        }

//        public double ReadDouble(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadDouble();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return (double)json.ReadAsDouble();
//            }
//#else
//            return 0;
//#endif
//        }

//        public decimal ReadDecimal(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadDecimal();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return (decimal)json.ReadAsDecimal();
//            }
//#else
//            return 0;
//#endif
//        }

//        public bool ReadBool(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadBoolean();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return (bool)json.ReadAsBoolean();
//            }
//#else
//            return false;
//#endif
//        }

//        public string ReadString(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadString();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                    Assert.AreEqual(json.TokenType, JsonToken.PropertyName);
//                }

//                return json.ReadAsString();
//            }
//#else
//            return string.Empty;
//#endif
//        }

//        public char ReadChar(bool withName = true)
//        {
//            if (binary != null)
//            {
//                return binary.ReadChar();
//            }
//#if ALE_JSON
//            else
//            {
//                if (withName)
//                {
//                    json.Read();
//                }

//                return json.ReadAsChar();
//            }
//#else
//            return char.MinValue;
//#endif
//        }

//        public Vector2 ReadVector2(bool withName = true)
//        {
//            ReadObjectStart(withName);
//            float x = ReadFloat();
//            float y = ReadFloat();
//            ReadObjectEnd();

//            return new Vector2(x, y);
//        }

//        public Vector2Int ReadVector2Int(bool withName = true)
//        {
//            ReadObjectStart(withName);
//            int x = ReadInt();
//            int y = ReadInt();
//            ReadObjectEnd();

//            return new Vector2Int(x, y);
//        }

//        public Vector3 ReadVector3(bool withName = true)
//        {
//            ReadObjectStart(withName);
//            float x = ReadFloat();
//            float y = ReadFloat();
//            float z = ReadFloat();
//            ReadObjectEnd();

//            return new Vector3(x, y, z);
//        }

//        public Vector3Int ReadVector3Int(bool withName = true)
//        {
//            ReadObjectStart(withName);
//            int x = ReadInt();
//            int y = ReadInt();
//            int z = ReadInt();
//            ReadObjectEnd();

//            return new Vector3Int(x, y, z);
//        }

//        public Vector4 ReadVector4(bool withName = true)
//        {
//            ReadObjectStart(withName);
//            float x = ReadFloat();
//            float y = ReadFloat();
//            float z = ReadFloat();
//            float w = ReadFloat();
//            ReadObjectEnd();

//            return new Vector4(x, y, z, w);
//        }

//        public Quaternion ReadQuaternion(bool withName = true)
//        {
//            ReadObjectStart(withName);
//            float x = ReadFloat();
//            float y = ReadFloat();
//            float z = ReadFloat();
//            float w = ReadFloat();
//            ReadObjectEnd();

//            return new Quaternion(x, y, z, w);
//        }

//        public Color ReadColor(bool withName = true)
//        {
//            return ReadColor32(withName);
//        }

//        public Color32 ReadColor32(bool withName = true)
//        {
//            ReadObjectStart(withName);
//            byte r = ReadByte();
//            byte g = ReadByte();
//            byte b = ReadByte();
//            byte a = ReadByte();
//            ReadObjectEnd();

//            return new Color32(r, g, b, a);
//        }

//        public int ReadComponent(bool withName = true)
//        {
//            return ReadInt(withName);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposedValue)
//            {
//                if (disposing)
//                {
//                    if (binary != null)
//                    {
//                        binary.Dispose();
//                    }
//#if ALE_JSON
//                    if (json != null)
//                    {
//                        ((IDisposable)json).Dispose();
//                    }
//#endif
//                }

//                binary = null;
//#if ALE_JSON
//                json = null;
//#endif

//                disposedValue = true;
//            }
//        }

//        public void Dispose()
//        {
//            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
//            Dispose(disposing: true);
//            GC.SuppressFinalize(this);
//        }
//    }
//}
