using MessagePack;
using MessagePack.Formatters;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.Binary
{
    public class LevelEditorResolver : IFormatterResolver
    {
        public static readonly IFormatterResolver Instance = new LevelEditorResolver();

        private LevelEditorResolver() { }

        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly IMessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                object f = LevelEditorResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    Formatter = (IMessagePackFormatter<T>)f;
                }
            }
        }

        internal static class LevelEditorResolverGetFormatterHelper
        {
            private static readonly Dictionary<Type, int> lookup;

            static LevelEditorResolverGetFormatterHelper()
            {
                lookup = new Dictionary<Type, int>(0)
                {
                    { typeof(LevelEditorSaveData), 0 },
                    { typeof(LevelEditorObjectData), 1 },
                    { typeof(LevelEditorComponentData), 2 },
                    { typeof(LevelEditorPropertyData), 3 },
                    { typeof(LevelEditorCustomData), 4 },
                };
            }

            internal static object GetFormatter(Type t)
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
                    default:
                        return null;
                }
            }
        }
    }
}
