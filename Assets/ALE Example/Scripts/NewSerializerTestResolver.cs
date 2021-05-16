using System;
using System.Collections.Generic;
using Hertzole.ALE;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

public class NewSerializerTestResolver : IFormatterResolver, IWrapperSerializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void RegisterResolver()
    {
        LevelEditorResolver.RegisterResolver(Instance);
        LevelEditorResolver.RegisterWrapperSerializer((NewSerializerTestResolver) Instance);
        LevelEditorSerializer.RegisterType<NewSerializeTestScript>();
    }

    private static readonly IFormatterResolver Instance = new NewSerializerTestResolver();

    private NewSerializerTestResolver() { }

    public IMessagePackFormatter<T> GetFormatter<T>()
    {
        return FormatterCache<T>.formatter;
    }

    private static class FormatterCache<T>
    {
        internal static readonly IMessagePackFormatter<T> formatter;

        static FormatterCache()
        {
            object f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
            if (f != null)
            {
                formatter = (IMessagePackFormatter<T>) f;
            }
        }
    }

    public bool SerializeWrapper(Type type, ref MessagePackWriter writer, IExposedWrapper value, MessagePackSerializerOptions options)
    {
        if (value is NewSerializeTestScript.Wrapper wrapper)
        {
            GetFormatter<NewSerializeTestScript.Wrapper>().Serialize(ref writer, wrapper, options);
            return true;
        }
        if (value is NewSerializeTestScript.Wrapper wrapper2)
        {
            GetFormatter<NewSerializeTestScript.Wrapper>().Serialize(ref writer, wrapper2, options);
            return true;
        }
        if (value is NewSerializeTestScript.Wrapper wrapper3)
        {
            GetFormatter<NewSerializeTestScript.Wrapper>().Serialize(ref writer, wrapper3, options);
            return true;
        }

        return false;
    }

    public bool DeserializeWrapper(Type type, ref MessagePackReader reader, MessagePackSerializerOptions options, out IExposedWrapper wrapper)
    {
        if (type == typeof(NewSerializeTestScript))
        {
            wrapper = GetFormatter<NewSerializeTestScript.Wrapper>().Deserialize(ref reader, options);
            return true;
        }
        else if (type == typeof(NewSerializeTestScript))
        {
            wrapper = GetFormatter<NewSerializeTestScript.Wrapper>().Deserialize(ref reader, options);
            return true;
        }
        else if (type == typeof(NewSerializeTestScript))
        {
            wrapper = GetFormatter<NewSerializeTestScript.Wrapper>().Deserialize(ref reader, options);
            return true;
        }
        else if (type == typeof(NewSerializeTestScript))
        {
            wrapper = GetFormatter<NewSerializeTestScript.Wrapper>().Deserialize(ref reader, options);
            return true;
        }
        else if (type == typeof(NewSerializeTestScript))
        {
            wrapper = GetFormatter<NewSerializeTestScript.Wrapper>().Deserialize(ref reader, options);
            return true;
        }
        else if (type == typeof(NewSerializeTestScript))
        {
            wrapper = GetFormatter<NewSerializeTestScript.Wrapper>().Deserialize(ref reader, options);
            return true;
        }
        else if (type == typeof(NewSerializeTestScript))
        {
            wrapper = GetFormatter<NewSerializeTestScript.Wrapper>().Deserialize(ref reader, options);
            return true;
        }

        wrapper = null;
        return false;
    }
    
    internal static class GeneratedResolverGetFormatterHelper
    {
        private static readonly Dictionary<Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new Dictionary<Type, int>
            {
                { typeof(NewSerializeTestScript.Wrapper), 0 },
                { typeof(NewSerializeTestScript.Wrapper), 1 },
                { typeof(NewSerializeTestScript.Wrapper), 2 },
                { typeof(NewSerializeTestScript.Wrapper), 3 },
                { typeof(NewSerializeTestScript.Wrapper), 4 },
                { typeof(NewSerializeTestScript.Wrapper), 5 },
                { typeof(NewSerializeTestScript.Wrapper), 6 },
                { typeof(NewSerializeTestScript.Wrapper), 7 },
                { typeof(NewSerializeTestScript.Wrapper), 8 },
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
                case 0: return new NewSerializeTestFormatter();
                case 1: return new NewSerializeTestFormatter();
                case 2: return new NewSerializeTestFormatter();
                case 3: return new NewSerializeTestFormatter();
                case 4: return new NewSerializeTestFormatter();
                case 5: return new NewSerializeTestFormatter();
                case 6: return new NewSerializeTestFormatter();
                case 7: return new NewSerializeTestFormatter();
                case 8: return new NewSerializeTestFormatter();
                default: return null;
            }
        }
    }
}
