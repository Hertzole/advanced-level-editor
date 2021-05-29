using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Hertzole.ALE
{
    public class LevelEditorResolver : IFormatterResolver, IWrapperSerializer, IDynamicResolver
    {
        private static bool serializerRegistered;

        private static List<IFormatterResolver> customResolvers = new List<IFormatterResolver>();
        private static List<IWrapperSerializer> wrapperSerializers = new List<IWrapperSerializer>(); 
        private static List<IDynamicResolver> dynamicResolvers = new List<IDynamicResolver>(); 

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void RegisterResolvers()
        {
            if (serializerRegistered)
            {
                return;
            }

            customResolvers.Add(Instance);
            customResolvers.Add(UnityResolver.Instance);
            customResolvers.Add(UnityBlitResolver.Instance);
            customResolvers.Add(StandardResolver.Instance);

            StaticCompositeResolver.Instance.Register(customResolvers.ToArray());
            MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance).WithCompression(MessagePackCompression.Lz4Block);

            serializerRegistered = true;
        }

        public static readonly IFormatterResolver Instance = new LevelEditorResolver();

        private LevelEditorResolver() { }

        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        public static void RegisterResolver(IFormatterResolver resolver)
        {
            // Insert it in the beginning to prioritize new resolvers.
            customResolvers.Insert(0, resolver);
        }

        public static void RegisterWrapperSerializer(IWrapperSerializer serializer)
        {
            wrapperSerializers.Add(serializer);
        }

        public static void RegisterDynamicResolver(IDynamicResolver resolver)
        {
            dynamicResolvers.Add(resolver);
        }
        
        public bool SerializeWrapper(ref MessagePackWriter writer, IExposedWrapper value, MessagePackSerializerOptions options)
        {
            for (int i = 0; i < wrapperSerializers.Count; i++)
            {
                if (wrapperSerializers[i].SerializeWrapper(ref writer, value, options))
                {
                    return true;
                }
            }

            return false;
        }

        public bool DeserializeWrapper(Type type, ref MessagePackReader reader, MessagePackSerializerOptions options, out IExposedWrapper wrapper)
        {
            for (int i = 0; i < wrapperSerializers.Count; i++)
            {
                if (wrapperSerializers[i].DeserializeWrapper(type, ref reader, options, out wrapper))
                {
                    return true;
                }
            }

            wrapper = null;
            return false;
        }
        
        public bool SerializeDynamic(Type type, ref MessagePackWriter writer, object value, MessagePackSerializerOptions options)
        {
            for (int i = 0; i < dynamicResolvers.Count; i++)
            {
                if (dynamicResolvers[i].SerializeDynamic(type, ref writer, value, options))
                {
                    return true;
                }
            }

            throw new NotImplementedException($"Found no formatter for type {type}.");
        }

        public bool DeserializeDynamic(Type type, ref MessagePackReader reader, out object value, MessagePackSerializerOptions options)
        {
            for (int i = 0; i < dynamicResolvers.Count; i++)
            {
                if (dynamicResolvers[i].DeserializeDynamic(type, ref reader, out value, options))
                {
                    return true;
                }
            }

            throw new NotImplementedException($"Found no formatter for type {type}.");
        }

        private static class FormatterCache<T>
        {
            internal static readonly IMessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                IMessagePackFormatter f = LevelEditorResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    Formatter = (IMessagePackFormatter<T>)f;
                }
            }
        }

        private static class LevelEditorResolverGetFormatterHelper
        {
            private static readonly Dictionary<Type, int> lookup;

            static LevelEditorResolverGetFormatterHelper()
            {
                lookup = new Dictionary<Type, int>(8)
                {
                    { typeof(LevelEditorSaveData), 0 },
                    { typeof(LevelEditorObjectData), 1 },
                    { typeof(LevelEditorComponentData), 2 },
                    // { typeof(LevelEditorPropertyData), 3 },
                    { typeof(LevelEditorCustomData), 4 },
                    { typeof(List<LevelEditorObjectData>), 5 },
                    { typeof(LevelEditorComponentData[]), 6 },
                    { typeof(LevelEditorPropertyData[]), 7 },
                    { typeof(Dictionary<string, LevelEditorCustomData>), 8 },
                    { typeof(ComponentDataWrapper), 9 },
                    { typeof(ComponentDataWrapper[]), 10 },
                    { typeof(List<ComponentDataWrapper>), 11 }
                };
            }

            internal static IMessagePackFormatter GetFormatter(Type t)
            {
                if (!lookup.TryGetValue(t, out int key))
                {
                    return null;
                }

                switch (key)
                {
                    case 0:
                        return new LevelEditorSaveDataFormatter();
                    case 1:
                        return new LevelEditorObjectDataFormatter();
                    case 2:
                        return new LevelEditorComponentDataFormatter();
                    // case 3:
                    //     return new LevelEditorPropertyDataFormatter();
                    case 4:
                        return new LevelEditorCustomDataFormatter();
                    case 5:
                        return new ListFormatter<LevelEditorObjectData>();
                    case 6:
                        return new ArrayFormatter<LevelEditorComponentData>();
                    case 7:
                        return new ArrayFormatter<LevelEditorPropertyData>();
                    case 8:
                        return new DictionaryFormatter<string, LevelEditorCustomData>();
                    case 9:
                        return new ComponentDataWrapperFormatter();
                    case 10:
                        return new ArrayFormatter<ComponentDataWrapper>();
                    case 11:
                        return new ListFormatter<ComponentDataWrapper>();
                    default:
                        return null;
                }
            }
        }
    }
}
