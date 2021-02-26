using System;
using System.Collections.Generic;
using UnityEngine;

public static class LevelEditorSerializer
{
    private static readonly Dictionary<string, Type> typeMap = new Dictionary<string, Type>();

    private static bool registeredTypes = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void ReigsterTypes()
    {
        if (registeredTypes)
        {
            return;
        }

        RegisterType<byte>();
        RegisterType<sbyte>();
        RegisterType<short>();
        RegisterType<ushort>();
        RegisterType<int>();
        RegisterType<uint>();
        RegisterType<long>();
        RegisterType<ulong>();
        RegisterType<float>();
        RegisterType<double>();
        RegisterType<decimal>();
        RegisterType<string>();
        RegisterType<char>();
        RegisterType<bool>();
        RegisterType<Vector2>();
        RegisterType<Vector2Int>();
        RegisterType<Vector3>();
        RegisterType<Vector3Int>();
        RegisterType<Vector4>();
        RegisterType<Quaternion>();
        RegisterType<Rect>();
        RegisterType<Color>();
        RegisterType<Color32>();
        RegisterType<Component>();

        registeredTypes = true;
    }

    public static void RegisterType<T>()
    {
        typeMap[typeof(T).FullName] = typeof(T);
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

    public static bool HasType(Type type, bool isArray)
    {
        if (isArray)
        {
            type = type.GetElementType();
        }

        return HasType(type.FullName);
    }
}
