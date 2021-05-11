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
        LevelEditorResolver.RegisterWrapperSerializer((NewSerializerTestResolver)Instance);
        LevelEditorSerializer.RegisterType<NewSerializeTestScript>();
    }

    private static readonly IFormatterResolver Instance = new NewSerializerTestResolver();

    private NewSerializerTestResolver()
    {
    }

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
                formatter = (IMessagePackFormatter<T>)f;
            }
        }
    }

    public bool SerializeWrapper(Type type, ref MessagePackWriter writer, IExposedWrapper value, MessagePackSerializerOptions options)
    {
        Debug.Log(value);
        
        if (value is NewSerializeTestScript.Wrapper wrapper)
        {
            Debug.Log("Serialize wrapper");
            GetFormatter<NewSerializeTestScript.Wrapper>().Serialize(ref writer, wrapper, options);
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

        wrapper = null;
        return false;
    }
}

internal static class GeneratedResolverGetFormatterHelper
{
    private static readonly Dictionary<Type, int> lookup;

    static GeneratedResolverGetFormatterHelper()
    {
        lookup = new Dictionary<Type, int>(2)
        {
            { typeof(NewSerializeTestScript.Wrapper), 0 },
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
            default: return null;
        }
    }
}
