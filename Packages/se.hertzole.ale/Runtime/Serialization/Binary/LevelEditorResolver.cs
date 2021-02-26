using MessagePack;
using MessagePack.Formatters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Binary
{
    public class LevelEditorResolver : IFormatterResolver
    {
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
                    default:
                        return null;
                }
            }
        }
    }
}
