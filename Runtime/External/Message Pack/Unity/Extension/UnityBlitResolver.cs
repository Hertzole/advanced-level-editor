// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MessagePack.Formatters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MessagePack.Unity.Extension
{
    /// <summary>
    /// Special Resolver for Vector2[], Vector3[], Vector4[], Quaternion[], Color[], Bounds[], Rect[].
    /// </summary>
    public class UnityBlitResolver : IFormatterResolver
    {
        public static readonly UnityBlitResolver Instance = new UnityBlitResolver();

        private UnityBlitResolver()
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
                Formatter = (MessagePackFormatter<T>)UnityBlitResolverGetFormatterHelper.GetFormatter(typeof(T));
            }
        }
    }

    /// <summary>
    /// Special Resolver for Vector2[], Vector3[], Vector4[], Quaternion[], Color[], Bounds[], Rect[] + int[], float[], double[].
    /// </summary>
    public class UnityBlitWithPrimitiveArrayResolver : IFormatterResolver
    {
        public static readonly UnityBlitWithPrimitiveArrayResolver Instance = new UnityBlitWithPrimitiveArrayResolver();

        private UnityBlitWithPrimitiveArrayResolver()
        {
        }

        public MessagePackFormatter GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly MessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                Formatter = (MessagePackFormatter<T>)UnityBlitWithPrimitiveResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (Formatter == null)
                {
                    Formatter = (MessagePackFormatter<T>)UnityBlitResolver.Instance.GetFormatter<T>();
                }
            }
        }
    }

    internal static class UnityBlitResolverGetFormatterHelper
    {
        private static readonly Dictionary<Type, Type> FormatterMap = new Dictionary<Type, Type>()
        {
              { typeof(Vector2[]), typeof(Vector2ArrayBlitFormatter) },
              { typeof(Vector3[]), typeof(Vector3ArrayBlitFormatter) },
              { typeof(Vector4[]), typeof(Vector4ArrayBlitFormatter) },
              { typeof(Quaternion[]), typeof(QuaternionArrayBlitFormatter) },
              { typeof(Color[]), typeof(ColorArrayBlitFormatter) },
              { typeof(Bounds[]), typeof(BoundsArrayBlitFormatter) },
              { typeof(Rect[]), typeof(RectArrayBlitFormatter) },
        };

        internal static object GetFormatter(Type t)
        {
            Type formatterType;
            if (FormatterMap.TryGetValue(t, out formatterType))
            {
                return Activator.CreateInstance(formatterType);
            }

            return null;
        }
    }

    internal static class UnityBlitWithPrimitiveResolverGetFormatterHelper
    {
        private static readonly Dictionary<Type, Type> FormatterMap = new Dictionary<Type, Type>()
        {
              { typeof(int[]), typeof(IntArrayBlitFormatter) },
              { typeof(float[]), typeof(FloatArrayBlitFormatter) },
              { typeof(double[]), typeof(DoubleArrayBlitFormatter) },
        };

        internal static object GetFormatter(Type t)
        {
            Type formatterType;
            if (FormatterMap.TryGetValue(t, out formatterType))
            {
                return Activator.CreateInstance(formatterType);
            }

            return null;
        }
    }
}
