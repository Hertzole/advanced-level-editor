// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/* THIS (.cs) FILE IS GENERATED. DO NOT CHANGE IT.
 * CHANGE THE .tt FILE INSTEAD. */

using System;

#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters
{
    public sealed class Int16Formatter : MessagePackFormatter<Int16>
    {
        public static readonly Int16Formatter Instance = new Int16Formatter();

        private Int16Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int16 value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Int16 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadInt16();
        }
    }

    public sealed class NullableInt16Formatter : MessagePackFormatter<Int16?>
    {
        public static readonly NullableInt16Formatter Instance = new NullableInt16Formatter();

        private NullableInt16Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int16? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Int16? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadInt16();
            }
        }
    }

    public sealed class Int16ArrayFormatter : MessagePackFormatter<Int16[]>
    {
        public static readonly Int16ArrayFormatter Instance = new Int16ArrayFormatter();

        private Int16ArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int16[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override Int16[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<Int16>();
            }

            short[] array = new Int16[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadInt16();
            }

            return array;
        }
    }

    public sealed class Int32Formatter : MessagePackFormatter<Int32>
    {
        public static readonly Int32Formatter Instance = new Int32Formatter();

        private Int32Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int32 value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Int32 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadInt32();
        }
    }

    public sealed class NullableInt32Formatter : MessagePackFormatter<Int32?>
    {
        public static readonly NullableInt32Formatter Instance = new NullableInt32Formatter();

        private NullableInt32Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int32? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Int32? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadInt32();
            }
        }
    }

    public sealed class Int32ArrayFormatter : MessagePackFormatter<Int32[]>
    {
        public static readonly Int32ArrayFormatter Instance = new Int32ArrayFormatter();

        private Int32ArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int32[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override Int32[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<Int32>();
            }

            int[] array = new Int32[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadInt32();
            }

            return array;
        }
    }

    public sealed class Int64Formatter : MessagePackFormatter<Int64>
    {
        public static readonly Int64Formatter Instance = new Int64Formatter();

        private Int64Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int64 value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Int64 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadInt64();
        }
    }

    public sealed class NullableInt64Formatter : MessagePackFormatter<Int64?>
    {
        public static readonly NullableInt64Formatter Instance = new NullableInt64Formatter();

        private NullableInt64Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int64? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Int64? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadInt64();
            }
        }
    }

    public sealed class Int64ArrayFormatter : MessagePackFormatter<Int64[]>
    {
        public static readonly Int64ArrayFormatter Instance = new Int64ArrayFormatter();

        private Int64ArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int64[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override Int64[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<Int64>();
            }

            long[] array = new Int64[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadInt64();
            }

            return array;
        }
    }

    public sealed class UInt16Formatter : MessagePackFormatter<UInt16>
    {
        public static readonly UInt16Formatter Instance = new UInt16Formatter();

        private UInt16Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt16 value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override UInt16 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadUInt16();
        }
    }

    public sealed class NullableUInt16Formatter : MessagePackFormatter<UInt16?>
    {
        public static readonly NullableUInt16Formatter Instance = new NullableUInt16Formatter();

        private NullableUInt16Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt16? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override UInt16? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadUInt16();
            }
        }
    }

    public sealed class UInt16ArrayFormatter : MessagePackFormatter<UInt16[]>
    {
        public static readonly UInt16ArrayFormatter Instance = new UInt16ArrayFormatter();

        private UInt16ArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt16[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override UInt16[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<UInt16>();
            }

            ushort[] array = new UInt16[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadUInt16();
            }

            return array;
        }
    }

    public sealed class UInt32Formatter : MessagePackFormatter<UInt32>
    {
        public static readonly UInt32Formatter Instance = new UInt32Formatter();

        private UInt32Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt32 value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override UInt32 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadUInt32();
        }
    }

    public sealed class NullableUInt32Formatter : MessagePackFormatter<UInt32?>
    {
        public static readonly NullableUInt32Formatter Instance = new NullableUInt32Formatter();

        private NullableUInt32Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt32? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override UInt32? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadUInt32();
            }
        }
    }

    public sealed class UInt32ArrayFormatter : MessagePackFormatter<UInt32[]>
    {
        public static readonly UInt32ArrayFormatter Instance = new UInt32ArrayFormatter();

        private UInt32ArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt32[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override UInt32[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<UInt32>();
            }

            uint[] array = new UInt32[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadUInt32();
            }

            return array;
        }
    }

    public sealed class UInt64Formatter : MessagePackFormatter<UInt64>
    {
        public static readonly UInt64Formatter Instance = new UInt64Formatter();

        private UInt64Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt64 value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override UInt64 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadUInt64();
        }
    }

    public sealed class NullableUInt64Formatter : MessagePackFormatter<UInt64?>
    {
        public static readonly NullableUInt64Formatter Instance = new NullableUInt64Formatter();

        private NullableUInt64Formatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt64? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override UInt64? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadUInt64();
            }
        }
    }

    public sealed class UInt64ArrayFormatter : MessagePackFormatter<UInt64[]>
    {
        public static readonly UInt64ArrayFormatter Instance = new UInt64ArrayFormatter();

        private UInt64ArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt64[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override UInt64[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<UInt64>();
            }

            ulong[] array = new UInt64[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadUInt64();
            }

            return array;
        }
    }

    public sealed class SingleFormatter : MessagePackFormatter<Single>
    {
        public static readonly SingleFormatter Instance = new SingleFormatter();

        private SingleFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Single value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Single Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadSingle();
        }
    }

    public sealed class NullableSingleFormatter : MessagePackFormatter<Single?>
    {
        public static readonly NullableSingleFormatter Instance = new NullableSingleFormatter();

        private NullableSingleFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Single? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Single? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadSingle();
            }
        }
    }

    public sealed class SingleArrayFormatter : MessagePackFormatter<Single[]>
    {
        public static readonly SingleArrayFormatter Instance = new SingleArrayFormatter();

        private SingleArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Single[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override Single[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<Single>();
            }

            float[] array = new Single[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadSingle();
            }

            return array;
        }
    }

    public sealed class DoubleFormatter : MessagePackFormatter<Double>
    {
        public static readonly DoubleFormatter Instance = new DoubleFormatter();

        private DoubleFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Double value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Double Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadDouble();
        }
    }

    public sealed class NullableDoubleFormatter : MessagePackFormatter<Double?>
    {
        public static readonly NullableDoubleFormatter Instance = new NullableDoubleFormatter();

        private NullableDoubleFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Double? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Double? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadDouble();
            }
        }
    }

    public sealed class DoubleArrayFormatter : MessagePackFormatter<Double[]>
    {
        public static readonly DoubleArrayFormatter Instance = new DoubleArrayFormatter();

        private DoubleArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Double[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override Double[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<Double>();
            }

            double[] array = new Double[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadDouble();
            }

            return array;
        }
    }

    public sealed class BooleanFormatter : MessagePackFormatter<Boolean>
    {
        public static readonly BooleanFormatter Instance = new BooleanFormatter();

        private BooleanFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Boolean value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Boolean Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadBoolean();
        }
    }

    public sealed class NullableBooleanFormatter : MessagePackFormatter<Boolean?>
    {
        public static readonly NullableBooleanFormatter Instance = new NullableBooleanFormatter();

        private NullableBooleanFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Boolean? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Boolean? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadBoolean();
            }
        }
    }

    public sealed class BooleanArrayFormatter : MessagePackFormatter<Boolean[]>
    {
        public static readonly BooleanArrayFormatter Instance = new BooleanArrayFormatter();

        private BooleanArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Boolean[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override Boolean[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<Boolean>();
            }

            bool[] array = new Boolean[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadBoolean();
            }

            return array;
        }
    }

    public sealed class ByteFormatter : MessagePackFormatter<Byte>
    {
        public static readonly ByteFormatter Instance = new ByteFormatter();

        private ByteFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Byte value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Byte Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadByte();
        }
    }

    public sealed class NullableByteFormatter : MessagePackFormatter<Byte?>
    {
        public static readonly NullableByteFormatter Instance = new NullableByteFormatter();

        private NullableByteFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Byte? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Byte? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadByte();
            }
        }
    }

    public sealed class SByteFormatter : MessagePackFormatter<SByte>
    {
        public static readonly SByteFormatter Instance = new SByteFormatter();

        private SByteFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, SByte value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override SByte Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadSByte();
        }
    }

    public sealed class NullableSByteFormatter : MessagePackFormatter<SByte?>
    {
        public static readonly NullableSByteFormatter Instance = new NullableSByteFormatter();

        private NullableSByteFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, SByte? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override SByte? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadSByte();
            }
        }
    }

    public sealed class SByteArrayFormatter : MessagePackFormatter<SByte[]>
    {
        public static readonly SByteArrayFormatter Instance = new SByteArrayFormatter();

        private SByteArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, SByte[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override SByte[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<SByte>();
            }

            sbyte[] array = new SByte[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadSByte();
            }

            return array;
        }
    }

    public sealed class CharFormatter : MessagePackFormatter<Char>
    {
        public static readonly CharFormatter Instance = new CharFormatter();

        private CharFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Char value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override Char Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadChar();
        }
    }

    public sealed class NullableCharFormatter : MessagePackFormatter<Char?>
    {
        public static readonly NullableCharFormatter Instance = new NullableCharFormatter();

        private NullableCharFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Char? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override Char? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadChar();
            }
        }
    }

    public sealed class CharArrayFormatter : MessagePackFormatter<Char[]>
    {
        public static readonly CharArrayFormatter Instance = new CharArrayFormatter();

        private CharArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Char[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override Char[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<Char>();
            }

            char[] array = new Char[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadChar();
            }

            return array;
        }
    }

    public sealed class DateTimeFormatter : MessagePackFormatter<DateTime>
    {
        public static readonly DateTimeFormatter Instance = new DateTimeFormatter();

        private DateTimeFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, DateTime value, MessagePackSerializerOptions options)
        {
            writer.Write(value);
        }

        public override DateTime Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadDateTime();
        }
    }

    public sealed class NullableDateTimeFormatter : MessagePackFormatter<DateTime?>
    {
        public static readonly NullableDateTimeFormatter Instance = new NullableDateTimeFormatter();

        private NullableDateTimeFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, DateTime? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.Write(value.Value);
            }
        }

        public override DateTime? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }
            else
            {
                return reader.ReadDateTime();
            }
        }
    }

    public sealed class DateTimeArrayFormatter : MessagePackFormatter<DateTime[]>
    {
        public static readonly DateTimeArrayFormatter Instance = new DateTimeArrayFormatter();

        private DateTimeArrayFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, DateTime[] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                writer.WriteArrayHeader(value.Length);
                for (int i = 0; i < value.Length; i++)
                {
                    writer.Write(value[i]);
                }
            }
        }

        public override DateTime[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<DateTime>();
            }

            DateTime[] array = new DateTime[len];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadDateTime();
            }

            return array;
        }
    }
}
