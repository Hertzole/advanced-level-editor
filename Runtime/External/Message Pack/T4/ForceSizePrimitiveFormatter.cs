// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/* THIS (.cs) FILE IS GENERATED. DO NOT CHANGE IT.
 * CHANGE THE .tt FILE INSTEAD. */

using System;

#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters
{
    public sealed class ForceInt16BlockFormatter : MessagePackFormatter<Int16>
    {
        public static readonly ForceInt16BlockFormatter Instance = new ForceInt16BlockFormatter();

        private ForceInt16BlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int16 value, MessagePackSerializerOptions options)
        {
            writer.WriteInt16(value);
        }

        public override Int16 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadInt16();
        }
    }

    public sealed class NullableForceInt16BlockFormatter : MessagePackFormatter<Int16?>
    {
        public static readonly NullableForceInt16BlockFormatter Instance = new NullableForceInt16BlockFormatter();

        private NullableForceInt16BlockFormatter()
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
                writer.WriteInt16(value.Value);
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

    public sealed class ForceInt16BlockArrayFormatter : MessagePackFormatter<Int16[]>
    {
        public static readonly ForceInt16BlockArrayFormatter Instance = new ForceInt16BlockArrayFormatter();

        private ForceInt16BlockArrayFormatter()
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
                    writer.WriteInt16(value[i]);
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
            options.Security.DepthStep(ref reader);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadInt16();
                }
            }
            finally
            {
                reader.Depth--;
            }

            return array;
        }
    }

    public sealed class ForceInt32BlockFormatter : MessagePackFormatter<Int32>
    {
        public static readonly ForceInt32BlockFormatter Instance = new ForceInt32BlockFormatter();

        private ForceInt32BlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int32 value, MessagePackSerializerOptions options)
        {
            writer.WriteInt32(value);
        }

        public override Int32 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadInt32();
        }
    }

    public sealed class NullableForceInt32BlockFormatter : MessagePackFormatter<Int32?>
    {
        public static readonly NullableForceInt32BlockFormatter Instance = new NullableForceInt32BlockFormatter();

        private NullableForceInt32BlockFormatter()
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
                writer.WriteInt32(value.Value);
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

    public sealed class ForceInt32BlockArrayFormatter : MessagePackFormatter<Int32[]>
    {
        public static readonly ForceInt32BlockArrayFormatter Instance = new ForceInt32BlockArrayFormatter();

        private ForceInt32BlockArrayFormatter()
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
                    writer.WriteInt32(value[i]);
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
            options.Security.DepthStep(ref reader);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadInt32();
                }
            }
            finally
            {
                reader.Depth--;
            }

            return array;
        }
    }

    public sealed class ForceInt64BlockFormatter : MessagePackFormatter<Int64>
    {
        public static readonly ForceInt64BlockFormatter Instance = new ForceInt64BlockFormatter();

        private ForceInt64BlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Int64 value, MessagePackSerializerOptions options)
        {
            writer.WriteInt64(value);
        }

        public override Int64 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadInt64();
        }
    }

    public sealed class NullableForceInt64BlockFormatter : MessagePackFormatter<Int64?>
    {
        public static readonly NullableForceInt64BlockFormatter Instance = new NullableForceInt64BlockFormatter();

        private NullableForceInt64BlockFormatter()
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
                writer.WriteInt64(value.Value);
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

    public sealed class ForceInt64BlockArrayFormatter : MessagePackFormatter<Int64[]>
    {
        public static readonly ForceInt64BlockArrayFormatter Instance = new ForceInt64BlockArrayFormatter();

        private ForceInt64BlockArrayFormatter()
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
                    writer.WriteInt64(value[i]);
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
            options.Security.DepthStep(ref reader);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadInt64();
                }
            }
            finally
            {
                reader.Depth--;
            }

            return array;
        }
    }

    public sealed class ForceUInt16BlockFormatter : MessagePackFormatter<UInt16>
    {
        public static readonly ForceUInt16BlockFormatter Instance = new ForceUInt16BlockFormatter();

        private ForceUInt16BlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt16 value, MessagePackSerializerOptions options)
        {
            writer.WriteUInt16(value);
        }

        public override UInt16 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadUInt16();
        }
    }

    public sealed class NullableForceUInt16BlockFormatter : MessagePackFormatter<UInt16?>
    {
        public static readonly NullableForceUInt16BlockFormatter Instance = new NullableForceUInt16BlockFormatter();

        private NullableForceUInt16BlockFormatter()
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
                writer.WriteUInt16(value.Value);
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

    public sealed class ForceUInt16BlockArrayFormatter : MessagePackFormatter<UInt16[]>
    {
        public static readonly ForceUInt16BlockArrayFormatter Instance = new ForceUInt16BlockArrayFormatter();

        private ForceUInt16BlockArrayFormatter()
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
                    writer.WriteUInt16(value[i]);
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
            options.Security.DepthStep(ref reader);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadUInt16();
                }
            }
            finally
            {
                reader.Depth--;
            }

            return array;
        }
    }

    public sealed class ForceUInt32BlockFormatter : MessagePackFormatter<UInt32>
    {
        public static readonly ForceUInt32BlockFormatter Instance = new ForceUInt32BlockFormatter();

        private ForceUInt32BlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt32 value, MessagePackSerializerOptions options)
        {
            writer.WriteUInt32(value);
        }

        public override UInt32 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadUInt32();
        }
    }

    public sealed class NullableForceUInt32BlockFormatter : MessagePackFormatter<UInt32?>
    {
        public static readonly NullableForceUInt32BlockFormatter Instance = new NullableForceUInt32BlockFormatter();

        private NullableForceUInt32BlockFormatter()
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
                writer.WriteUInt32(value.Value);
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

    public sealed class ForceUInt32BlockArrayFormatter : MessagePackFormatter<UInt32[]>
    {
        public static readonly ForceUInt32BlockArrayFormatter Instance = new ForceUInt32BlockArrayFormatter();

        private ForceUInt32BlockArrayFormatter()
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
                    writer.WriteUInt32(value[i]);
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
            options.Security.DepthStep(ref reader);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadUInt32();
                }
            }
            finally
            {
                reader.Depth--;
            }

            return array;
        }
    }

    public sealed class ForceUInt64BlockFormatter : MessagePackFormatter<UInt64>
    {
        public static readonly ForceUInt64BlockFormatter Instance = new ForceUInt64BlockFormatter();

        private ForceUInt64BlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, UInt64 value, MessagePackSerializerOptions options)
        {
            writer.WriteUInt64(value);
        }

        public override UInt64 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadUInt64();
        }
    }

    public sealed class NullableForceUInt64BlockFormatter : MessagePackFormatter<UInt64?>
    {
        public static readonly NullableForceUInt64BlockFormatter Instance = new NullableForceUInt64BlockFormatter();

        private NullableForceUInt64BlockFormatter()
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
                writer.WriteUInt64(value.Value);
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

    public sealed class ForceUInt64BlockArrayFormatter : MessagePackFormatter<UInt64[]>
    {
        public static readonly ForceUInt64BlockArrayFormatter Instance = new ForceUInt64BlockArrayFormatter();

        private ForceUInt64BlockArrayFormatter()
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
                    writer.WriteUInt64(value[i]);
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
            options.Security.DepthStep(ref reader);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadUInt64();
                }
            }
            finally
            {
                reader.Depth--;
            }

            return array;
        }
    }

    public sealed class ForceByteBlockFormatter : MessagePackFormatter<Byte>
    {
        public static readonly ForceByteBlockFormatter Instance = new ForceByteBlockFormatter();

        private ForceByteBlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Byte value, MessagePackSerializerOptions options)
        {
            writer.WriteUInt8(value);
        }

        public override Byte Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadByte();
        }
    }

    public sealed class NullableForceByteBlockFormatter : MessagePackFormatter<Byte?>
    {
        public static readonly NullableForceByteBlockFormatter Instance = new NullableForceByteBlockFormatter();

        private NullableForceByteBlockFormatter()
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
                writer.WriteUInt8(value.Value);
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

    public sealed class ForceSByteBlockFormatter : MessagePackFormatter<SByte>
    {
        public static readonly ForceSByteBlockFormatter Instance = new ForceSByteBlockFormatter();

        private ForceSByteBlockFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, SByte value, MessagePackSerializerOptions options)
        {
            writer.WriteInt8(value);
        }

        public override SByte Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadSByte();
        }
    }

    public sealed class NullableForceSByteBlockFormatter : MessagePackFormatter<SByte?>
    {
        public static readonly NullableForceSByteBlockFormatter Instance = new NullableForceSByteBlockFormatter();

        private NullableForceSByteBlockFormatter()
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
                writer.WriteInt8(value.Value);
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

    public sealed class ForceSByteBlockArrayFormatter : MessagePackFormatter<SByte[]>
    {
        public static readonly ForceSByteBlockArrayFormatter Instance = new ForceSByteBlockArrayFormatter();

        private ForceSByteBlockArrayFormatter()
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
                    writer.WriteInt8(value[i]);
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
            options.Security.DepthStep(ref reader);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = reader.ReadSByte();
                }
            }
            finally
            {
                reader.Depth--;
            }

            return array;
        }
    }
}
