// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters
{
    /// <summary>
    /// Serialize by .NET native DateTime binary format.
    /// </summary>
    public sealed class NativeDateTimeFormatter : MessagePackFormatter<DateTime>
    {
        public static readonly NativeDateTimeFormatter Instance = new NativeDateTimeFormatter();

        public override void Serialize(ref MessagePackWriter writer, DateTime value, MessagePackSerializerOptions options)
        {
            long dateData = value.ToBinary();
            writer.Write(dateData);
        }

        public override DateTime Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            long dateData = reader.ReadInt64();
            return DateTime.FromBinary(dateData);
        }
    }

    public sealed class NativeDateTimeArrayFormatter : MessagePackFormatter<DateTime[]>
    {
        public static readonly NativeDateTimeArrayFormatter Instance = new NativeDateTimeArrayFormatter();

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
                    writer.Write(value[i].ToBinary());
                }
            }
        }

        public override DateTime[] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            int len = reader.ReadArrayHeader();
            if (len == 0)
            {
                return Array.Empty<DateTime>();
            }

            DateTime[] array = new DateTime[len];
            for (int i = 0; i < array.Length; i++)
            {
                long dateData = reader.ReadInt64();
                array[i] = DateTime.FromBinary(dateData);
            }

            return array;
        }
    }
}
