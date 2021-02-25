// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters
{
    /* multi dimensional array serialize to [i, j, [seq]] */

    public sealed class TwoDimensionalArrayFormatter<T> : MessagePackFormatter<T[,]>
    {
        private const int ArrayLength = 3;

        public override void Serialize(ref MessagePackWriter writer, T[,] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                int i = value.GetLength(0);
                int j = value.GetLength(1);

                MessagePackFormatter<T> formatter = options.Resolver.GetFormatterWithVerify<T>();

                writer.WriteArrayHeader(ArrayLength);
                writer.Write(i);
                writer.Write(j);

                writer.WriteArrayHeader(value.Length);
                foreach (T item in value)
                {
                    writer.CancellationToken.ThrowIfCancellationRequested();
                    formatter.Serialize(ref writer, item, options);
                }
            }
        }

        public override T[,] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }
            else
            {
                MessagePackFormatter<T> formatter = options.Resolver.GetFormatterWithVerify<T>();

                int len = reader.ReadArrayHeader();
                if (len != ArrayLength)
                {
                    throw new MessagePackSerializationException("Invalid T[,] format");
                }

                int iLength = reader.ReadInt32();
                int jLength = reader.ReadInt32();
                int maxLen = reader.ReadArrayHeader();

                T[,] array = new T[iLength, jLength];

                int i = 0;
                int j = -1;
                options.Security.DepthStep(ref reader);
                try
                {
                    for (int loop = 0; loop < maxLen; loop++)
                    {
                        reader.CancellationToken.ThrowIfCancellationRequested();
                        if (j < jLength - 1)
                        {
                            j++;
                        }
                        else
                        {
                            j = 0;
                            i++;
                        }

                        array[i, j] = formatter.Deserialize(ref reader, options);
                    }
                }
                finally
                {
                    reader.Depth--;
                }

                return array;
            }
        }
    }

    public sealed class ThreeDimensionalArrayFormatter<T> : MessagePackFormatter<T[,,]>
    {
        private const int ArrayLength = 4;

        public override void Serialize(ref MessagePackWriter writer, T[,,] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                int i = value.GetLength(0);
                int j = value.GetLength(1);
                int k = value.GetLength(2);

                MessagePackFormatter<T> formatter = options.Resolver.GetFormatterWithVerify<T>();

                writer.WriteArrayHeader(ArrayLength);
                writer.Write(i);
                writer.Write(j);
                writer.Write(k);

                writer.WriteArrayHeader(value.Length);
                foreach (T item in value)
                {
                    writer.CancellationToken.ThrowIfCancellationRequested();
                    formatter.Serialize(ref writer, item, options);
                }
            }
        }

        public override T[,,] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }
            else
            {
                MessagePackFormatter<T> formatter = options.Resolver.GetFormatterWithVerify<T>();

                int len = reader.ReadArrayHeader();
                if (len != ArrayLength)
                {
                    throw new MessagePackSerializationException("Invalid T[,,] format");
                }

                int iLength = reader.ReadInt32();
                int jLength = reader.ReadInt32();
                int kLength = reader.ReadInt32();
                int maxLen = reader.ReadArrayHeader();

                T[,,] array = new T[iLength, jLength, kLength];

                int i = 0;
                int j = 0;
                int k = -1;
                options.Security.DepthStep(ref reader);
                try
                {
                    for (int loop = 0; loop < maxLen; loop++)
                    {
                        reader.CancellationToken.ThrowIfCancellationRequested();
                        if (k < kLength - 1)
                        {
                            k++;
                        }
                        else if (j < jLength - 1)
                        {
                            k = 0;
                            j++;
                        }
                        else
                        {
                            k = 0;
                            j = 0;
                            i++;
                        }

                        array[i, j, k] = formatter.Deserialize(ref reader, options);
                    }
                }
                finally
                {
                    reader.Depth--;
                }

                return array;
            }
        }
    }

    public sealed class FourDimensionalArrayFormatter<T> : MessagePackFormatter<T[,,,]>
    {
        private const int ArrayLength = 5;

        public override void Serialize(ref MessagePackWriter writer, T[,,,] value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
            }
            else
            {
                int i = value.GetLength(0);
                int j = value.GetLength(1);
                int k = value.GetLength(2);
                int l = value.GetLength(3);

                MessagePackFormatter<T> formatter = options.Resolver.GetFormatterWithVerify<T>();

                writer.WriteArrayHeader(ArrayLength);
                writer.Write(i);
                writer.Write(j);
                writer.Write(k);
                writer.Write(l);

                writer.WriteArrayHeader(value.Length);
                foreach (T item in value)
                {
                    writer.CancellationToken.ThrowIfCancellationRequested();
                    formatter.Serialize(ref writer, item, options);
                }
            }
        }

        public override T[,,,] Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }
            else
            {
                MessagePackFormatter<T> formatter = options.Resolver.GetFormatterWithVerify<T>();

                int len = reader.ReadArrayHeader();
                if (len != ArrayLength)
                {
                    throw new MessagePackSerializationException("Invalid T[,,,] format");
                }

                int iLength = reader.ReadInt32();
                int jLength = reader.ReadInt32();
                int kLength = reader.ReadInt32();
                int lLength = reader.ReadInt32();
                int maxLen = reader.ReadArrayHeader();
                T[,,,] array = new T[iLength, jLength, kLength, lLength];

                int i = 0;
                int j = 0;
                int k = 0;
                int l = -1;
                options.Security.DepthStep(ref reader);
                try
                {
                    for (int loop = 0; loop < maxLen; loop++)
                    {
                        reader.CancellationToken.ThrowIfCancellationRequested();
                        if (l < lLength - 1)
                        {
                            l++;
                        }
                        else if (k < kLength - 1)
                        {
                            l = 0;
                            k++;
                        }
                        else if (j < jLength - 1)
                        {
                            l = 0;
                            k = 0;
                            j++;
                        }
                        else
                        {
                            l = 0;
                            k = 0;
                            j = 0;
                            i++;
                        }

                        array[i, j, k, l] = formatter.Deserialize(ref reader, options);
                    }
                }
                finally
                {
                    reader.Depth--;
                }

                return array;
            }
        }
    }
}
