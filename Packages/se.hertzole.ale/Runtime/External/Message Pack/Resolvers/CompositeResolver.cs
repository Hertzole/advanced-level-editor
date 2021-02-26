// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MessagePack.Resolvers
{
    /// <summary>
    /// Represents a collection of formatters and resolvers acting as one.
    /// </summary>
    /// <remarks>
    /// This class is not thread-safe for mutations. It is thread-safe when not being written to.
    /// </remarks>
    public static class CompositeResolver
    {
        private static readonly ReadOnlyDictionary<Type, MessagePackFormatter> EmptyFormattersByType = new ReadOnlyDictionary<Type, MessagePackFormatter>(new Dictionary<Type, MessagePackFormatter>());

        /// <summary>
        /// Initializes a new instance of an <see cref="IFormatterResolver"/> with the specified formatters and sub-resolvers.
        /// </summary>
        /// <param name="formatters">
        /// A list of instances of <see cref="MessagePackFormatter{T}"/> to prefer (above the <paramref name="resolvers"/>).
        /// The formatters are searched in the order given, so if two formatters support serializing the same type, the first one is used.
        /// May not be null, but may be <see cref="Array.Empty{T}"/>.
        /// </param>
        /// <param name="resolvers">
        /// A list of resolvers to use for serializing types for which <paramref name="formatters"/> does not include a formatter.
        /// The resolvers are searched in the order given, so if two resolvers support serializing the same type, the first one is used.
        /// May not be null, but may be <see cref="Array.Empty{T}"/>.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IFormatterResolver"/>.
        /// </returns>
        public static IFormatterResolver Create(IReadOnlyList<MessagePackFormatter> formatters, IReadOnlyList<IFormatterResolver> resolvers)
        {
            if (formatters is null)
            {
                throw new ArgumentNullException(nameof(formatters));
            }

            if (resolvers is null)
            {
                throw new ArgumentNullException(nameof(resolvers));
            }

            // Make a copy of the resolvers list provided by the caller to guard against them changing it later.
            MessagePackFormatter[] immutableFormatters = formatters.ToArray();
            IFormatterResolver[] immutableResolvers = resolvers.ToArray();

            return new CachingResolver(immutableFormatters, immutableResolvers);
        }

        public static IFormatterResolver Create(params IFormatterResolver[] resolvers)
        {
            return Create(Array.Empty<MessagePackFormatter>(), resolvers);
        }

        public static IFormatterResolver Create(params MessagePackFormatter[] formatters)
        {
            return Create(formatters, Array.Empty<IFormatterResolver>());
        }

        private class CachingResolver : IFormatterResolver
        {
            private readonly ThreadsafeTypeKeyHashTable<MessagePackFormatter> formattersCache = new ThreadsafeTypeKeyHashTable<MessagePackFormatter>();
            private readonly MessagePackFormatter[] subFormatters;
            private readonly IFormatterResolver[] subResolvers;

            /// <summary>
            /// Initializes a new instance of the <see cref="CachingResolver"/> class.
            /// </summary>
            internal CachingResolver(MessagePackFormatter[] subFormatters, IFormatterResolver[] subResolvers)
            {
                this.subFormatters = subFormatters ?? throw new ArgumentNullException(nameof(subFormatters));
                this.subResolvers = subResolvers ?? throw new ArgumentNullException(nameof(subResolvers));
            }

            public MessagePackFormatter GetFormatter<T>()
            {
                if (!formattersCache.TryGetValue(typeof(T), out MessagePackFormatter formatter))
                {
                    foreach (MessagePackFormatter subFormatter in subFormatters)
                    {
                        if (subFormatter is MessagePackFormatter<T>)
                        {
                            formatter = subFormatter;
                            goto CACHE;
                        }
                    }

                    foreach (IFormatterResolver resolver in subResolvers)
                    {
                        formatter = resolver.GetFormatter<T>();
                        if (formatter != null)
                        {
                            goto CACHE;
                        }
                    }

                    // when not found, cache null.
                    CACHE:
                    formattersCache.TryAdd(typeof(T), formatter);
                }

                return (MessagePackFormatter<T>)formatter;
            }
        }
    }
}
