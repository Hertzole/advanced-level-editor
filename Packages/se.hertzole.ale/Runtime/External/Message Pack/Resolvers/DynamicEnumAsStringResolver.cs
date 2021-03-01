// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;
using MessagePack.Internal;
using System;
using System.Reflection;

namespace MessagePack.Resolvers
{
    public sealed class DynamicEnumAsStringResolver : IFormatterResolver
    {
        /// <summary>
        /// The singleton instance that can be used.
        /// </summary>
        public static readonly DynamicEnumAsStringResolver Instance;

        /// <summary>
        /// A <see cref="MessagePackSerializerOptions"/> instance with this formatter pre-configured.
        /// </summary>
        public static readonly MessagePackSerializerOptions Options;

        static DynamicEnumAsStringResolver()
        {
            Instance = new DynamicEnumAsStringResolver();
            Options = new MessagePackSerializerOptions(Instance);
        }

        private DynamicEnumAsStringResolver()
        {
        }

        public MessagePackFormatter GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            public static readonly MessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                TypeInfo ti = typeof(T).GetTypeInfo();

                if (ti.IsNullable())
                {
                    // build underlying type and use wrapped formatter.
                    ti = ti.GenericTypeArguments[0].GetTypeInfo();
                    if (!ti.IsEnum)
                    {
                        return;
                    }

                    object innerFormatter = DynamicEnumAsStringResolver.Instance.GetFormatterDynamic(ti.AsType());
                    if (innerFormatter == null)
                    {
                        return;
                    }

                    Formatter = (MessagePackFormatter<T>)Activator.CreateInstance(typeof(StaticNullableFormatter<>).MakeGenericType(ti.AsType()), new object[] { innerFormatter });
                    return;
                }
                else if (!ti.IsEnum)
                {
                    return;
                }

                Formatter = (MessagePackFormatter<T>)(object)new EnumAsStringFormatter<T>();
            }
        }
    }
}
