// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;
using System;
using System.Collections.Generic;

namespace MessagePack.Resolvers
{
    /// <summary>
    /// Singleton version of CompositeResolver, which be able to register a collection of formatters and resolvers to a single instance.
    /// </summary>
    public class StaticCompositeResolver : IFormatterResolver
    {
        public static readonly StaticCompositeResolver Instance = new StaticCompositeResolver();

        private bool freezed;
        private IReadOnlyList<MessagePackFormatter> formatters;
        private IReadOnlyList<IFormatterResolver> resolvers;

        private StaticCompositeResolver()
        {
            formatters = Array.Empty<MessagePackFormatter>();
            resolvers = Array.Empty<IFormatterResolver>();
        }

        /// <summary>
        /// Initializes a singleton instance with the specified formatters.
        /// This method can only call before use StaticCompositeResolver.Instance.GetFormatter.
        /// If call twice in the Register methods, registered formatters and resolvers will be overridden.
        /// </summary>
        /// <param name="formatters">
        /// A list of instances of <see cref="MessagePackFormatter{T}"/>.
        /// The formatters are searched in the order given, so if two formatters support serializing the same type, the first one is used.
        /// </param>
        public void Register(params MessagePackFormatter[] formatters)
        {
            if (freezed)
            {
                throw new InvalidOperationException("Register must call on startup(before use GetFormatter<T>).");
            }

            if (this.formatters is null)
            {
                throw new ArgumentNullException(nameof(formatters));
            }

            this.formatters = formatters;
            resolvers = Array.Empty<IFormatterResolver>();
        }

        /// <summary>
        /// Initializes a singleton instance with the specified formatters and sub-resolvers.
        /// This method can only call before use StaticCompositeResolver.Instance.GetFormatter.
        /// If call twice in the Register methods, registered formatters and resolvers will be overridden.
        /// </summary>
        /// <param name="resolvers">
        /// A list of resolvers to use for serializing types.
        /// The resolvers are searched in the order given, so if two resolvers support serializing the same type, the first one is used.
        /// </param>
        public void Register(params IFormatterResolver[] resolvers)
        {
            if (freezed)
            {
                throw new InvalidOperationException("Register must call on startup(before use GetFormatter<T>).");
            }

            if (resolvers is null)
            {
                throw new ArgumentNullException(nameof(resolvers));
            }

            formatters = Array.Empty<MessagePackFormatter>();
            this.resolvers = resolvers;
        }

        /// <summary>
        /// Initializes a singleton instance with the specified formatters and sub-resolvers.
        /// This method can only call before use StaticCompositeResolver.Instance.GetFormatter.
        /// If call twice in the Register methods, registered formatters and resolvers will be overridden.
        /// </summary>
        /// <param name="formatters">
        /// A list of instances of <see cref="MessagePackFormatter{T}"/>.
        /// The formatters are searched in the order given, so if two formatters support serializing the same type, the first one is used.
        /// </param>
        /// <param name="resolvers">
        /// A list of resolvers to use for serializing types for which <paramref name="formatters"/> does not include a formatter.
        /// The resolvers are searched in the order given, so if two resolvers support serializing the same type, the first one is used.
        /// </param>
        public void Register(IReadOnlyList<MessagePackFormatter> formatters, IReadOnlyList<IFormatterResolver> resolvers)
        {
            if (freezed)
            {
                throw new InvalidOperationException("Register must call on startup(before use GetFormatter<T>).");
            }

            if (formatters is null)
            {
                throw new ArgumentNullException(nameof(formatters));
            }

            if (resolvers is null)
            {
                throw new ArgumentNullException(nameof(resolvers));
            }

            this.formatters = formatters;
            this.resolvers = resolvers;
        }

        /// <summary>
        /// Gets an <see cref="MessagePackFormatter{T}"/> instance that can serialize or deserialize some type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of value to be serialized or deserialized.</typeparam>
        /// <returns>A formatter, if this resolver supplies one for type <typeparamref name="T"/>; otherwise <c>null</c>.</returns>
        public MessagePackFormatter<T> GetFormatter<T>()
        {
            return Cache<T>.Formatter;
        }

        private static class Cache<T>
        {
            public static readonly MessagePackFormatter<T> Formatter;

            static Cache()
            {
                Instance.freezed = true;
                foreach (MessagePackFormatter item in Instance.formatters)
                {
                    if (item is MessagePackFormatter<T> f)
                    {
                        Formatter = f;
                        return;
                    }
                }

                foreach (IFormatterResolver item in Instance.resolvers)
                {
                    MessagePackFormatter<T> f = item.GetFormatter<T>();
                    if (f != null)
                    {
                        Formatter = f;
                        return;
                    }
                }
            }
        }
    }
}
