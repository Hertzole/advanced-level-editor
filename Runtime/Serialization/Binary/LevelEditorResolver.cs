using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Hertzole.ALE.Binary
{
    public class LevelEditorResolver : IFormatterResolver
    {
        private static bool serializerRegistered = false;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RegisterResolvers()
        {
            if (serializerRegistered)
            {
                return;
            }

            StaticCompositeResolver.Instance.Register(UnityResolver.Instance,
                                                      UnityBlitResolver.Instance,
                                                      StandardResolver.Instance,
                                                      LevelEditorResolver.Instance);
            MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);

            serializerRegistered = true;
        }

        public static readonly IFormatterResolver Instance = new LevelEditorResolver();

        private LevelEditorResolver() { }

        public MessagePackFormatter GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly MessagePackFormatter Formatter;

            static FormatterCache()
            {
                MessagePackFormatter f = LevelEditorResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    Formatter = f;
                }
            }
        }

        internal static class LevelEditorResolverGetFormatterHelper
        {
            private static readonly Dictionary<Type, int> lookup;

            static LevelEditorResolverGetFormatterHelper()
            {
                lookup = new Dictionary<Type, int>(8)
                {
                    { typeof(LevelEditorSaveData), 0 },
                    { typeof(LevelEditorObjectData), 1 },
                    { typeof(LevelEditorComponentData), 2 },
                    { typeof(LevelEditorPropertyData), 3 },
                    { typeof(LevelEditorCustomData), 4 },
                    { typeof(List<LevelEditorObjectData>), 5 },
                    { typeof(LevelEditorComponentData[]), 6 },
                    { typeof(LevelEditorPropertyData[]), 7 },
                    { typeof(Dictionary<string, LevelEditorCustomData>), 8 },
                    { typeof(Component), 9 },
                    { typeof(GameObject), 10 },
                };
            }

            internal static MessagePackFormatter GetFormatter(Type t)
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
                    case 3:
                        return new LevelEditorPropertyDataFormatter();
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
                        return new ComponentFormatter();
                    case 10:
                        return new GameObjectFormatter();
                    default:
                        return null;
                }
            }
        }

        // Used only for making sure methods are generated in AOT.
        [Preserve]
        private static void AOTPreserve()
        {
            StaticCompositeResolver.Instance.GetFormatter<LevelEditorSaveData>();
            StaticCompositeResolver.Instance.GetFormatter<LevelEditorObjectData>();
            StaticCompositeResolver.Instance.GetFormatter<LevelEditorComponentData>();
            StaticCompositeResolver.Instance.GetFormatter<LevelEditorPropertyData>();
            StaticCompositeResolver.Instance.GetFormatter<LevelEditorCustomData>();
        }
    }
}
