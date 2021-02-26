// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
    public sealed class PrimitiveObjectResolver : IFormatterResolver
    {
        /// <summary>
        /// The singleton instance that can be used.
        /// </summary>
        public static readonly PrimitiveObjectResolver Instance;

        /// <summary>
        /// A <see cref="MessagePackSerializerOptions"/> instance with this formatter pre-configured.
        /// </summary>
        public static readonly MessagePackSerializerOptions Options;

        static PrimitiveObjectResolver()
        {
            Instance = new PrimitiveObjectResolver();
            Options = new MessagePackSerializerOptions(Instance);
        }

        private PrimitiveObjectResolver()
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
                //Formatter = (typeof(T) == typeof(object))
                //    ? (MessagePackFormatter<T>)PrimitiveObjectFormatter.Instance
                //    : null;
            }
        }
    }

    ////#if !UNITY_2018_3_OR_NEWER

    ////    /// <summary>
    ////    /// In `object`, when serializing resolve by concrete type and when deserializing use primitive.
    ////    /// </summary>
    ////    public sealed class DynamicObjectTypeFallbackResolver : IFormatterResolver
    ////    {
    ////        public static readonly DynamicObjectTypeFallbackResolver Instance = new DynamicObjectTypeFallbackResolver();

    ////        DynamicObjectTypeFallbackResolver()
    ////        {

    ////        }

    ////        public MessagePackFormatter<T> GetFormatter<T>()
    ////        {
    ////            return FormatterCache<T>.formatter;
    ////        }

    ////        static class FormatterCache<T>
    ////        {
    ////            public static readonly MessagePackFormatter<T> formatter;

    ////            static FormatterCache()
    ////            {
    ////                formatter = (typeof(T) == typeof(object))
    ////                    ? (MessagePackFormatter<T>)(object)DynamicObjectTypeFallbackFormatter.Instance
    ////                    : null;
    ////            }
    ////        }
    ////    }

    ////#endif
}
