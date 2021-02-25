// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;
using System;
using System.Linq; // require UNITY_2018_3_OR_NEWER

namespace MessagePack.Resolvers
{
    /// <summary>
    /// Get formatter from <see cref="MessagePackFormatterAttribute"/>.
    /// </summary>
    public sealed class AttributeFormatterResolver : IFormatterResolver
    {
        /// <summary>
        /// The singleton instance that can be used.
        /// </summary>
        public static readonly AttributeFormatterResolver Instance = new AttributeFormatterResolver();

        private AttributeFormatterResolver()
        {
        }

        public MessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            public static readonly MessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
#if UNITY_2018_3_OR_NEWER && !NETFX_CORE
                MessagePackFormatterAttribute attr = (MessagePackFormatterAttribute)typeof(T).GetCustomAttributes(typeof(MessagePackFormatterAttribute), true).FirstOrDefault();
#else
                MessagePackFormatterAttribute attr = typeof(T).GetTypeInfo().GetCustomAttribute<MessagePackFormatterAttribute>();
#endif
                if (attr == null)
                {
                    return;
                }

                Type formatterType = attr.FormatterType;
                if (formatterType.IsGenericType && !formatterType.IsConstructedGenericType)
                {
                    formatterType = formatterType.MakeGenericType(typeof(T).GetGenericArguments());
                }

                if (attr.Arguments == null)
                {
                    Formatter = (MessagePackFormatter<T>)Activator.CreateInstance(formatterType);
                }
                else
                {
                    Formatter = (MessagePackFormatter<T>)Activator.CreateInstance(formatterType, attr.Arguments);
                }
            }
        }
    }
}
