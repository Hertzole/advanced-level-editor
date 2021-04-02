using System;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;

namespace Hertzole.ALE
{
    public static class LevelEditorSerializer
    {
        private static readonly Dictionary<string, Type> typeMap = new Dictionary<string, Type>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RegisterTypes()
        {
            RegisterType<Vector3>();
            RegisterType<Component>();
            RegisterType<bool>();
            RegisterType<float>();
        }

        public static void RegisterType<T>()
        {
            typeMap[typeof(T).FullName] = typeof(T);
        }

        public static byte[] SerializeBinary<T>(T data)
        {
            return MessagePackSerializer.Serialize(data);
        }

        public static T DeserializeBinary<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes);
        }

        public static string SerializeJson<T>(T data)
        {
            return MessagePackSerializer.SerializeToJson(data);
        }

        public static T DeserializeJson<T>(string json)
        {
            byte[] bytes = MessagePackSerializer.ConvertFromJson(json);

            return MessagePackSerializer.Deserialize<T>(bytes);
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
    }
}