// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters
{
    public sealed class NullableFormatter<T> : MessagePackFormatter<T?>
        where T : struct
    {
        public override void Serialize(ref MessagePackWriter writer, T? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                options.Resolver.GetFormatterWithVerify<T>().Serialize(ref writer, value.Value, options);
            }
        }

        public override T? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                reader.ReadNil();
                return null;
            }
            else
            {
                return options.Resolver.GetFormatterWithVerify<T>().Deserialize(ref reader, options);
            }
        }
    }

    public sealed class StaticNullableFormatter<T> : MessagePackFormatter<T?>
        where T : struct
    {
        private readonly MessagePackFormatter<T> underlyingFormatter;

        public StaticNullableFormatter(MessagePackFormatter<T> underlyingFormatter)
        {
            this.underlyingFormatter = underlyingFormatter;
        }

        public override void Serialize(ref MessagePackWriter writer, T? value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                underlyingFormatter.Serialize(ref writer, value.Value, options);
            }
        }

        public override T? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }
            else
            {
                return underlyingFormatter.Deserialize(ref reader, options);
            }
        }
    }
}
