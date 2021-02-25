//using MessagePack;
//using MessagePack.Formatters;
//using System;
//using System.Linq.Expressions;
//using System.Reflection;
//using UnityEngine;

//namespace Hertzole.ALE.Binary
//{
//    public sealed class ValueFormatter
//    {
//        public static readonly ValueFormatter Instance = new ValueFormatter();

//        private delegate void SerializeMethod(object dynamicFormatter, ref MessagePackWriter writer, object value, MessagePackSerializerOptions options);
//        private delegate object DeserializeMethod(object dynamicFormatter, ref MessagePackReader reader, MessagePackSerializerOptions options);

//        private static readonly ThreadsafeTypeKeyHashTable<SerializeMethod> serializerDelegates = new ThreadsafeTypeKeyHashTable<SerializeMethod>();
//        private static readonly ThreadsafeTypeKeyHashTable<DeserializeMethod> deserializerDelegates = new ThreadsafeTypeKeyHashTable<DeserializeMethod>();

//        public void Serialize(ref MessagePackWriter writer, Type type, object value, MessagePackSerializerOptions options)
//        {
//            if (value is null)
//            {
//                writer.WriteNil();
//                return;
//            }

//            if (type == typeof(Component) || type.IsSubclassOf(typeof(Component)))
//            {
//                LevelEditorSerializer.Serialize(ref writer, typeof(Component), value as Component, options);
//                return;
//            }

//            TypeInfo ti = type.GetTypeInfo();

//            if (type == typeof(object))
//            {
//                // serialize to empty map
//                writer.WriteMapHeader(0);
//                return;
//            }

//            if (PrimitiveObjectFormatter.IsSupportedType(type, ti, value))
//            {
//                if (!(value is System.Collections.IDictionary || value is System.Collections.ICollection))
//                {
//                    PrimitiveObjectFormatter.Instance.Serialize(ref writer, value, options);
//                    return;
//                }
//            }

//            Debug.Log(type + " | " + options);
//            if (options != null)
//            {
//                Debug.Log(options.Resolver);
//            }

//            object formatter = options.Resolver.GetFormatterDynamic(type);
//            Debug.Log(formatter + " | " + type);
//            if (!serializerDelegates.TryGetValue(type, out SerializeMethod serializerDelegate))
//            {
//                lock (serializerDelegates)
//                {
//                    if (!serializerDelegates.TryGetValue(type, out serializerDelegate))
//                    {
//                        Type formatterType = typeof(IMessagePackFormatter<>).MakeGenericType(type);
//                        ParameterExpression param0 = Expression.Parameter(typeof(object), "formatter");
//                        ParameterExpression param1 = Expression.Parameter(typeof(MessagePackWriter).MakeByRefType(), "writer");
//                        ParameterExpression param2 = Expression.Parameter(typeof(object), "value");
//                        ParameterExpression param3 = Expression.Parameter(typeof(MessagePackSerializerOptions), "options");

//                        MethodInfo serializeMethodInfo = formatterType.GetRuntimeMethod("Serialize", new[] { typeof(MessagePackWriter).MakeByRefType(), type, typeof(MessagePackSerializerOptions) });

//                        MethodCallExpression body = Expression.Call(
//                            Expression.Convert(param0, formatterType),
//                            serializeMethodInfo,
//                            param1,
//                            ti.IsValueType ? Expression.Unbox(param2, type) : Expression.Convert(param2, type),
//                            param3);

//                        serializerDelegate = Expression.Lambda<SerializeMethod>(body, param0, param1, param2, param3).Compile();

//                        serializerDelegates.TryAdd(type, serializerDelegate);
//                    }
//                }
//            }

//            serializerDelegate(formatter, ref writer, value, options);
//        }

//        public object Deserialize(ref MessagePackReader reader, Type type, MessagePackSerializerOptions options)
//        {
//            if (reader.TryReadNil())
//            {
//                return null;
//            }

//            //if (type == typeof(Component) || type.IsSubclassOf(typeof(Component)))
//            //{
//            //    return ComponentFormatter.Deserialize(ref reader, options);
//            //}

//            TypeInfo ti = type.GetTypeInfo();

//            if (type == typeof(object))
//            {
//                // serialize to empty map
//                int mapHeader = reader.ReadMapHeader();
//                return mapHeader;
//            }

//            //if (PrimitiveObjectFormatter.IsSupportedType(type, ti, value))
//            //{
//            //    if (!(value is System.Collections.IDictionary || value is System.Collections.ICollection))
//            //    {
//            //        PrimitiveObjectFormatter.Instance.Serialize(ref writer, value, options);
//            //        return;
//            //    }
//            //}

//            object formatter = options.Resolver.GetFormatterDynamic(type);
//            if (!deserializerDelegates.TryGetValue(type, out DeserializeMethod deserializerDelegate))
//            {
//                lock (deserializerDelegates)
//                {
//                    if (!deserializerDelegates.TryGetValue(type, out deserializerDelegate))
//                    {
//                        Type formatterType = typeof(MessagePackFormatter<>).MakeGenericType(type);
//                        ParameterExpression param0 = Expression.Parameter(typeof(object), "formatter");
//                        ParameterExpression param1 = Expression.Parameter(typeof(MessagePackReader).MakeByRefType(), "reader");
//                        ParameterExpression param3 = Expression.Parameter(typeof(MessagePackSerializerOptions), "options");

//                        MethodInfo deserializeMethodInfo = formatterType.GetRuntimeMethod("Deserialize", new[] { typeof(MessagePackReader).MakeByRefType(), typeof(MessagePackSerializerOptions) });

//                        MethodCallExpression body = Expression.Call(Expression.Convert(param0, formatterType), deserializeMethodInfo, param1, param3);

//                        deserializerDelegate = Expression.Lambda<DeserializeMethod>(Expression.Convert(body, typeof(object)), param0, param1, param3).Compile();

//                        deserializerDelegates.TryAdd(type, deserializerDelegate);
//                    }
//                }
//            }

//            return deserializerDelegate(formatter, ref reader, options);
//        }
//    }
//}
