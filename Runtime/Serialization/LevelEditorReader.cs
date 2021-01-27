using System;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
#if ALE_JSON
using Newtonsoft.Json;
#endif

namespace Hertzole.ALE
{
    public static class LevelEditorReader<T>
    {
        public static Action<LevelEditorReader> Read { get; set; }
    }

    public class LevelEditorReader : IDisposable
    {
        private bool disposedValue;

        private const string INVALID_COMPONENT = "{0} is not a valid Unity Component to save. It needs to derive from UnityEngine.Component and have a LevelEditorObject component attached.";

        private BinaryReader binary;
#if ALE_JSON
        private JsonReader json;
#endif

        public bool IsJson
        {
            get
            {
#if ALE_JSON
                return json != null;
#else
                return false;
#endif
            }
        }

        public BinaryReader Binary { get { return binary; } }
#if ALE_JSON
        public JsonReader Json { get { return json; } }
#endif

        public LevelEditorReader(BinaryReader reader)
        {
            binary = reader ?? throw new ArgumentNullException(nameof(reader));
        }

#if ALE_JSON
        public LevelEditorReader(JsonReader reader)
        {
            json = reader ?? throw new ArgumentNullException(nameof(reader));
        }
#endif

        public void Read<T>()
        {
            if (LevelEditorReader<T>.Read == null)
            {
                Debug.LogWarning($"No reader for '{typeof(T)}'.");
                return;
            }

            LevelEditorReader<T>.Read(this);
        }

        [System.Diagnostics.Conditional("ALE_JSON")]
        public void ReadObjectStart(bool withName = false)
        {
#if ALE_JSON
            if (IsJson)
            {
                json.Read();
                if (withName)
                {
                    json.Read();
                }
                Assert.AreEqual(json.TokenType, JsonToken.StartObject, json.Path);
            }
#endif
        }

        [System.Diagnostics.Conditional("ALE_JSON")]
        public void ReadObjectEnd()
        {
#if ALE_JSON
            if (IsJson)
            {
                json.Read();
                Assert.AreEqual(json.TokenType, JsonToken.EndObject);
            }
#endif
        }

        public void ReadArray(bool readObject, Action<int> forEach)
        {
            if (binary != null)
            {
                int count = binary.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    forEach.Invoke(i);
                }
            }
#if ALE_JSON
            else
            {
                json.Read(); // Read property name.
                Assert.AreEqual(json.TokenType, JsonToken.PropertyName);
                json.Read();
                Assert.AreEqual(json.TokenType, JsonToken.StartArray);
                int depth = json.Depth;
                int index = 0;
                while (true)
                {
                    if (readObject)
                    {
                        json.Read();
                    }

                    if ((json.TokenType == JsonToken.EndArray && json.Depth == depth))
                    {
                        break;
                    }

                    forEach.Invoke(index);

                    if (readObject)
                    {
                        json.Read();
                    }

                    //json.Read();
                    //Debug.Log(json.ToGoodString());

                    //json.Read();



                    index++;
                }
                Assert.AreEqual(json.TokenType, JsonToken.EndArray);

            }
#else
            return 0;
#endif
        }

        public byte ReadByte()
        {
            if (binary != null)
            {
                return binary.ReadByte();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsByte();
            }
#else
            return 0;
#endif
        }

        public sbyte ReadSByte()
        {
            if (binary != null)
            {
                return binary.ReadSByte();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsSByte();
            }
#else
            return 0;
#endif
        }

        public short ReadShort()
        {
            if (binary != null)
            {
                return binary.ReadInt16();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsInt16();
            }
#else
            return 0;
#endif
        }

        public ushort ReadUShort()
        {
            if (binary != null)
            {
                return binary.ReadUInt16();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsUInt16();
            }
#else
            return 0;
#endif
        }

        public int ReadInt()
        {
            if (binary != null)
            {
                return binary.ReadInt32();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return (int)json.ReadAsInt32();
            }
#else
            return 0;
#endif
        }

        public uint ReadUInt()
        {
            if (binary != null)
            {
                return binary.ReadUInt32();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsUInt32();
            }
#else
            return 0;
#endif
        }

        public long ReadLong()
        {
            if (binary != null)
            {
                return binary.ReadInt64();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsInt64();
            }
#else
            return 0;
#endif
        }

        public ulong ReadULong()
        {
            if (binary != null)
            {
                return binary.ReadUInt64();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsUInt64();
            }
#else
            return 0;
#endif
        }

        public float ReadFloat()
        {
            if (binary != null)
            {
                return binary.ReadSingle();
            }
#if ALE_JSON
            else
            {
                json.Read(); // Read property name.
                return json.ReadAsFloat();
            }
#else
            return 0;
#endif
        }

        public double ReadDouble()
        {
            if (binary != null)
            {
                return binary.ReadDouble();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return (double)json.ReadAsDouble();
            }
#else
            return 0;
#endif
        }

        public decimal ReadDecimal()
        {
            if (binary != null)
            {
                return binary.ReadDecimal();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return (decimal)json.ReadAsDecimal();
            }
#else
            return 0;
#endif
        }

        public bool ReadBool()
        {
            if (binary != null)
            {
                return binary.ReadBoolean();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return (bool)json.ReadAsBoolean();
            }
#endif
        }

        public string ReadString()
        {
            if (binary != null)
            {
                return binary.ReadString();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsString();
            }
#else
            return string.Empty;
#endif
        }

        public char ReadChar()
        {
            if (binary != null)
            {
                return binary.ReadChar();
            }
#if ALE_JSON
            else
            {
                json.Read();
                return json.ReadAsChar();
            }
#else
            return char.MinValue;
#endif
        }

        public Vector2 ReadVector2()
        {
            ReadObjectStart(true);
            float x = ReadFloat();
            float y = ReadFloat();
            ReadObjectEnd();

            return new Vector2(x, y);
        }

        public Vector2Int ReadVector2Int()
        {
            ReadObjectStart(true);
            int x = ReadInt();
            int y = ReadInt();
            ReadObjectEnd();

            return new Vector2Int(x, y);
        }

        public Vector3 ReadVector3()
        {
            ReadObjectStart(true);
            float x = ReadFloat();
            float y = ReadFloat();
            float z = ReadFloat();
            ReadObjectEnd();

            return new Vector3(x, y, z);
        }

        public Vector3Int ReadVector3Int()
        {
            ReadObjectStart(true);
            int x = ReadInt();
            int y = ReadInt();
            int z = ReadInt();
            ReadObjectEnd();

            return new Vector3Int(x, y, z);
        }

        public Vector4 ReadVector4()
        {
            ReadObjectStart(true);
            float x = ReadFloat();
            float y = ReadFloat();
            float z = ReadFloat();
            float w = ReadFloat();
            ReadObjectEnd();

            return new Vector4(x, y, z, w);
        }

        public Quaternion ReadQuaternion()
        {
            ReadObjectStart(true);
            float x = ReadFloat();
            float y = ReadFloat();
            float z = ReadFloat();
            float w = ReadFloat();
            ReadObjectEnd();

            return new Quaternion(x, y, z, w);
        }

        public Color ReadColor()
        {
            return ReadColor32();
        }

        public Color32 ReadColor32()
        {
            ReadObjectStart(true);
            byte r = ReadByte();
            byte g = ReadByte();
            byte b = ReadByte();
            byte a = ReadByte();
            ReadObjectEnd();

            return new Color32(r, g, b, a);
        }

        public int ReadComponent()
        {
            return ReadInt();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (binary != null)
                    {
                        binary.Dispose();
                    }
#if ALE_JSON
                    if (json != null)
                    {
                        ((IDisposable)json).Dispose();
                    }
#endif
                }

                binary = null;
                json = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
