using System;
using System.Collections.Generic;
using MessagePack;

namespace Hertzole.ALE
{
	public static class LevelEditorSerializer
	{
		private static readonly Dictionary<int, Type> typeMap = new Dictionary<int, Type>();

		public static void RegisterType<T>()
		{
			typeMap[typeof(T).FullName.GetStableHashCode()] = typeof(T);
		}

		public static void RegisterType<T>(int hash)
		{
			typeMap[hash] = typeof(T);
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
			int hash = typeName.GetStableHashCode();

			if (!typeMap.ContainsKey(hash))
			{
				throw new ArgumentException($"{typeName} has not been registered. Register it using LevelEditorSerializer.RegisterType<{typeName}>().");
			}

			return GetType(hash);
		}

		public static Type GetType(int hash)
		{
			return typeMap[hash];
		}
	}
}