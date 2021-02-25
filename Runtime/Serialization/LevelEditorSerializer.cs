using Hertzole.ALE;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Unity;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class LevelEditorSerializer
{
    private static readonly Dictionary<string, Type> typeMap = new Dictionary<string, Type>();
    private static readonly Dictionary<Type, object> formatters = new Dictionary<Type, object>();

    private static bool registeredTypes = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void ReigsterTypes()
    {
        if (registeredTypes)
        {
            return;
        }

        RegisterType<byte>(ByteFormatter.Instance);
        RegisterType<sbyte>(SByteFormatter.Instance);
        RegisterType<short>(Int16Formatter.Instance);
        RegisterType<ushort>(UInt16Formatter.Instance);
        RegisterType<int>(Int32Formatter.Instance);
        RegisterType<uint>(UInt32Formatter.Instance);
        RegisterType<long>(Int64Formatter.Instance);
        RegisterType<ulong>(UInt64Formatter.Instance);
        RegisterType<float>(SingleFormatter.Instance);
        RegisterType<double>(DoubleFormatter.Instance);
        RegisterType<decimal>(DecimalFormatter.Instance);
        RegisterType<string>(NullableStringFormatter.Instance);
        RegisterType<char>(CharFormatter.Instance);
        RegisterType<bool>(BooleanFormatter.Instance);
        RegisterType<Vector2>(new Vector2Formatter());
        RegisterType<Vector2Int>(new Vector2IntFormatter());
        RegisterType<Vector3>(new Vector3Formatter());
        RegisterType<Vector3Int>(new Vector3IntFormatter());
        RegisterType<Vector4>(new Vector4Formatter());
        RegisterType<Quaternion>(new QuaternionFormatter());
        RegisterType<Rect>(new RectFormatter());
        RegisterType<Color>(new ColorFormatter());
        RegisterType<Color32>(new Color32Formatter());
        RegisterType<Component>(new ComponentFormatter());

        registeredTypes = true;
    }

    public static void RegisterType<T>(IMessagePackFormatter<T> formatter)
    {
        typeMap[typeof(T).FullName] = typeof(T);
        formatters[typeof(T)] = formatter;
    }

    public static Type GetType(string typeName)
    {
        if (!typeMap.ContainsKey(typeName))
        {
            throw new ArgumentException($"{typeName} has not been registered. Register it using LevelEditorSerializer.RegisterType<{typeName}>().");
        }

        return typeMap[typeName];
    }

    public static bool HasType(string typeName)
    {
        return typeMap.ContainsKey(typeName);
    }

    public static bool HasType(Type type)
    {
        return HasType(type.FullName);
    }

    private delegate void SerializeMethod(ref MessagePackWriter writer, object value, MessagePackSerializerOptions options);
    public static void Serialize(ref MessagePackWriter writer, Type type, object value, MessagePackSerializerOptions options)
    {
        object formatter = formatters[type];
        //if (formatter is IMessagePackFormatter f)
        //{
        //    //f.Serialize(ref writer, (T)value, options);
        //}

        //object[] temp = new object[]
        //{
        //    writer
        //};

        MethodInfo serializeMethod = formatter.GetType().GetMethod(nameof(IMessagePackFormatter<int>.Serialize));
        Debug.Log(serializeMethod);
        Delegate sm = Delegate.CreateDelegate(typeof(SerializeMethod), formatter, serializeMethod);
        Debug.Log(sm);
        //sm.Invoke(ref writer, Convert.ChangeType(value, type), options);
    }

    //public static object Deserialize(Type type)
    //{
    //    //var formatter = 
    //}
}
