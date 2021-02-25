// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Dynamic;

namespace MessagePack.Formatters
{
    public class ExpandoObjectFormatter : MessagePackFormatter<ExpandoObject>
    {
        public static readonly MessagePackFormatter<ExpandoObject> Instance = new ExpandoObjectFormatter();

        private ExpandoObjectFormatter()
        {
        }

        public override ExpandoObject Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            ExpandoObject result = new ExpandoObject();
            int count = reader.ReadMapHeader();
            if (count > 0)
            {
                IFormatterResolver resolver = options.Resolver;
                MessagePackFormatter<string> keyFormatter = resolver.GetFormatterWithVerify<string>();
                MessagePackFormatter<object> valueFormatter = resolver.GetFormatterWithVerify<object>();
                IDictionary<string, object> dictionary = result;

                options.Security.DepthStep(ref reader);
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        string key = keyFormatter.Deserialize(ref reader, options);
                        object value = valueFormatter.Deserialize(ref reader, options);
                        dictionary.Add(key, value);
                    }
                }
                finally
                {
                    reader.Depth--;
                }
            }

            return result;
        }

        public override void Serialize(ref MessagePackWriter writer, ExpandoObject value, MessagePackSerializerOptions options)
        {
            IDictionary<string, object> dict = value;
            MessagePackFormatter<string> keyFormatter = options.Resolver.GetFormatterWithVerify<string>();
            MessagePackFormatter<object> valueFormatter = options.Resolver.GetFormatterWithVerify<object>();

            writer.WriteMapHeader(dict.Count);
            foreach (KeyValuePair<string, object> item in dict)
            {
                keyFormatter.Serialize(ref writer, item.Key, options);
                valueFormatter.Serialize(ref writer, item.Value, options);
            }
        }
    }
}
