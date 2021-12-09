using System;
using System.Collections.Generic;
using MessagePack;
using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE
{
	public static class LevelEditorSerializer
	{
		private static bool previousCompress;
		private static readonly Dictionary<int, Type> typeMap = new Dictionary<int, Type>();

		public static LevelEditorSerializerOptions Options { get; set; } = new LevelEditorSerializerOptions(MessagePackSerializerOptions.Standard);

#if UNITY_EDITOR
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetStatics()
		{
			previousCompress = false;
		}
#endif

		public static void RegisterType<T>()
		{
			typeMap[typeof(T).FullName.GetStableHashCode()] = typeof(T);
		}

		public static void RegisterType<T>(int hash)
		{
			typeMap[hash] = typeof(T);
		}

		public static byte[] SerializeBinary<T>(T data, bool compress = true)
		{
			SetCompression(compress);

			return MessagePackSerializer.Serialize(data, Options);
		}

		public static T DeserializeBinary<T>(byte[] bytes, bool compressed = true)
		{
			SetCompression(compressed);
			
			return MessagePackSerializer.Deserialize<T>(bytes, Options);
		}

		public static string SerializeJson<T>(T data)
		{
			try
			{
				return MessagePackSerializer.SerializeToJson(data, Options);
			}
			catch (Exception e)
			{
				Debug.LogError(e);
				return string.Empty;
			}
		}

		public static T DeserializeJson<T>(string json)
		{
			byte[] bytes = MessagePackSerializer.ConvertFromJson(json, Options);

			return MessagePackSerializer.Deserialize<T>(bytes, Options);
		}

		private static void SetCompression(bool compress)
		{
			if (compress != previousCompress)
			{
				previousCompress = compress;
				Options = (LevelEditorSerializerOptions) Options.WithCompression(compress ? MessagePackCompression.Lz4Block : MessagePackCompression.None);
			}
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
			return typeMap.TryGetValue(hash, out Type type) ? type : null;
		}
	}
}