using System;
using System.IO;
using UnityEngine;
#if ALE_JSON
using Newtonsoft.Json;
#endif

namespace Hertzole.ALE
{
    public static class LevelEditorWriter<T>
    {
        public static Action<LevelEditorWriter, T, string> Write { get; set; }
    }

    public class LevelEditorWriter : IDisposable
    {
        private bool disposedValue;

        private const string INVALID_COMPONENT = "{0} is not a valid Unity Component to save. It needs to derive from UnityEngine.Component and have a LevelEditorObject component attached.";

        private BinaryWriter binary;
#if ALE_JSON
        private JsonWriter json;
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

        public LevelEditorWriter(BinaryWriter writer)
        {
            binary = writer ?? throw new ArgumentNullException(nameof(writer));
        }

#if ALE_JSON
        public LevelEditorWriter(JsonWriter writer)
        {
            json = writer ?? throw new ArgumentNullException(nameof(writer));
        }
#endif

        public void Write<T>(T value, string name = "value")
        {
            if (LevelEditorWriter<T>.Write == null)
            {
                Debug.LogWarning($"No writer for '{typeof(T)}'.");
                return;
            }

            LevelEditorWriter<T>.Write(this, value, name);
        }

        public void WriteStartObject(string name = null)
        {
#if ALE_JSON
            if (json != null)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
            }
#endif
        }

        public void WriteEndObject()
        {
#if ALE_JSON
            if (json != null)
            {
                json.WriteEndObject();
            }
#endif
        }

        public void WriteStartArray(int length, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(length);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartArray();
            }
#endif
        }

        public void WriteEndArray()
        {
#if ALE_JSON
            if (json != null)
            {
                json.WriteEndArray();
            }
#endif
        }

        public void Write(byte value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(sbyte value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(short value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(ushort value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(int value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(uint value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(long value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(ulong value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(float value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(double value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(decimal value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(bool value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(string value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(char value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteValue(value);
            }
#endif
        }

        public void Write(Vector2 value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value.x);
                binary.Write(value.y);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
                json.WritePropertyName("x");
                json.WriteValue(value.x);
                json.WritePropertyName("y");
                json.WriteValue(value.y);
                json.WriteEndObject();
            }
#endif
        }

        public void Write(Vector2Int value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value.x);
                binary.Write(value.y);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
                json.WritePropertyName("x");
                json.WriteValue(value.x);
                json.WritePropertyName("y");
                json.WriteValue(value.y);
                json.WriteEndObject();
            }
#endif
        }

        public void Write(Vector3 value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value.x);
                binary.Write(value.y);
                binary.Write(value.z);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
                json.WritePropertyName("x");
                json.WriteValue(value.x);
                json.WritePropertyName("y");
                json.WriteValue(value.y);
                json.WritePropertyName("z");
                json.WriteValue(value.z);
                json.WriteEndObject();
            }
#endif
        }

        public void Write(Vector3Int value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value.x);
                binary.Write(value.y);
                binary.Write(value.z);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
                json.WritePropertyName("x");
                json.WriteValue(value.x);
                json.WritePropertyName("y");
                json.WriteValue(value.y);
                json.WritePropertyName("z");
                json.WriteValue(value.z);
                json.WriteEndObject();
            }
#endif
        }

        public void Write(Vector4 value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value.x);
                binary.Write(value.y);
                binary.Write(value.z);
                binary.Write(value.w);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
                json.WritePropertyName("x");
                json.WriteValue(value.x);
                json.WritePropertyName("y");
                json.WriteValue(value.y);
                json.WritePropertyName("z");
                json.WriteValue(value.z);
                json.WritePropertyName("w");
                json.WriteValue(value.w);
                json.WriteEndObject();
            }
#endif
        }

        public void Write(Quaternion value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value.x);
                binary.Write(value.y);
                binary.Write(value.z);
                binary.Write(value.w);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
                json.WritePropertyName("x");
                json.WriteValue(value.x);
                json.WritePropertyName("y");
                json.WriteValue(value.y);
                json.WritePropertyName("z");
                json.WriteValue(value.z);
                json.WritePropertyName("w");
                json.WriteValue(value.w);
                json.WriteEndObject();
            }
#endif
        }

        public void Write(Color value, string name = "value")
        {
            Write((Color32)value, name);
        }

        public void Write(Color32 value, string name = "value")
        {
            if (binary != null)
            {
                binary.Write(value.r);
                binary.Write(value.g);
                binary.Write(value.b);
                binary.Write(value.a);
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                json.WriteStartObject();
                json.WritePropertyName("r");
                json.WriteValue(value.r);
                json.WritePropertyName("g");
                json.WriteValue(value.g);
                json.WritePropertyName("b");
                json.WriteValue(value.b);
                json.WritePropertyName("a");
                json.WriteValue(value.a);
                json.WriteEndObject();
            }
#endif
        }

        public void Write(Component value, string name = "value")
        {
            if (binary != null)
            {
                if (value == null)
                {
                    binary.Write(0);
                    return;
                }

                if (value.TryGetComponent(out ILevelEditorObject obj))
                {
                    binary.Write(obj.InstanceID);
                }
                else
                {
                    Debug.LogError(string.Format(INVALID_COMPONENT, value.GetType().FullName));
                }
            }
#if ALE_JSON
            else
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    json.WritePropertyName(name);
                }

                if (value == null)
                {
                    json.WriteValue(0);
                    return;
                }

                if (value.TryGetComponent(out ILevelEditorObject obj))
                {
                    json.WriteValue(obj.InstanceID);
                }
                else
                {
                    Debug.LogError(string.Format(INVALID_COMPONENT, value.GetType().FullName));
                }
            }
#endif
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
#if ALE_JSON
                json = null;
#endif

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
