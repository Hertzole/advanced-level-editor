// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
    /// <summary>
    /// A base class for <see cref="IFormatterResolver"/> classes that want to cache their responses for perf reasons.
    /// </summary>
    internal abstract class CachingFormatterResolver : IFormatterResolver
    {
        /// <summary>
        /// The cache of types to their formatters.
        /// </summary>
        private readonly ThreadsafeTypeKeyHashTable<MessagePackFormatter> formatters = new ThreadsafeTypeKeyHashTable<MessagePackFormatter>();

        /// <inheritdoc />
        public MessagePackFormatter<T> GetFormatter<T>()
        {
            if (!formatters.TryGetValue(typeof(T), out MessagePackFormatter formatter))
            {
                formatter = GetFormatterCore<T>();
                formatters.TryAdd(typeof(T), formatter);
            }

            return (MessagePackFormatter<T>)formatter;
        }

        /// <summary>
        /// Looks up a formatter for a type that has not been previously cached.
        /// </summary>
        /// <typeparam name="T">The type to be formatted.</typeparam>
        /// <returns>The formatter to use, or <c>null</c> if none found.</returns>
        protected abstract MessagePackFormatter<T> GetFormatterCore<T>();
    }
}
