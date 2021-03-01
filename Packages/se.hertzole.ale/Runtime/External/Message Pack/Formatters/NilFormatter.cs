// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace MessagePack.Formatters
{
    public class NilFormatter : MessagePackFormatter<Nil>
    {
        public static readonly MessagePackFormatter<Nil> Instance = new NilFormatter();

        private NilFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Nil value, MessagePackSerializerOptions options)
        {
            writer.WriteNil();
        }

        public override Nil Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadNil();
        }
    }

    // NullableNil is same as Nil.
    public class NullableNilFormatter : MessagePackFormatter<Nil?>
    {
        public static readonly MessagePackFormatter<Nil?> Instance = new NullableNilFormatter();

        private NullableNilFormatter()
        {
        }

        public override void Serialize(ref MessagePackWriter writer, Nil? value, MessagePackSerializerOptions options)
        {
            writer.WriteNil();
        }

        public override Nil? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            return reader.ReadNil();
        }
    }
}
