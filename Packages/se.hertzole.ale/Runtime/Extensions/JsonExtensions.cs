#if ALE_JSON
using Newtonsoft.Json;
using System;
using UnityEngine.Assertions;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static byte ReadAsByte(this JsonReader reader)
        {
            return Convert.ToByte(reader.ReadAsInt32());
        }

        public static sbyte ReadAsSByte(this JsonReader reader)
        {
            return Convert.ToSByte(reader.ReadAsInt32());
        }

        public static short ReadAsInt16(this JsonReader reader)
        {
            return Convert.ToInt16(reader.ReadAsInt32());
        }

        public static ushort ReadAsUInt16(this JsonReader reader)
        {
            return Convert.ToUInt16(reader.ReadAsInt32());
        }

        public static uint ReadAsUInt32(this JsonReader reader)
        {
            return Convert.ToUInt32(reader.ReadAsInt32());
        }

        public static long ReadAsInt64(this JsonReader reader)
        {
            reader.Read();
            Assert.AreEqual(reader.TokenType, JsonToken.Integer);
            return Convert.ToInt64(reader.Value);
        }

        public static ulong ReadAsUInt64(this JsonReader reader)
        {
            reader.Read();
            Assert.AreEqual(reader.TokenType, JsonToken.Integer);
            return Convert.ToUInt64(reader.Value);
        }

        public static float ReadAsFloat(this JsonReader reader)
        {
            return Convert.ToSingle(reader.ReadAsDouble());
        }

        public static char ReadAsChar(this JsonReader reader)
        {
            return Convert.ToChar(reader.ReadAsString());
        }
    }
}
#endif
