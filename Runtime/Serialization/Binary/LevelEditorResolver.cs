using System;
using System.Collections.Generic;
using Hertzole.ALE.Formatters;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Hertzole.ALE
{
	public class LevelEditorResolver : IFormatterResolver, IWrapperSerializer, IDynamicResolver
	{
		private static bool serializerRegistered;

		private static readonly List<IFormatterResolver> customResolvers = new List<IFormatterResolver>();
		private static readonly List<IWrapperSerializer> wrapperSerializers = new List<IWrapperSerializer>();
		private static readonly List<IDynamicResolver> dynamicResolvers = new List<IDynamicResolver>();

#if UNITY_EDITOR
		[InitializeOnLoadMethod]
#else
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
#endif
		private static void RegisterResolvers()
		{
			#if UNITY_EDITOR
			EditorApplication.delayCall += RegisterResolversInternal;
#else
			RegisterResolversInternal();
#endif
		}

		private static void RegisterResolversInternal()
		{
			if (serializerRegistered)
			{
				return;
			}

			LevelEditorLogger.Log("Registering LevelEditorResolver.");

			customResolvers.Add(Instance);
			customResolvers.Add(UnityResolver.Instance);
			customResolvers.Add(UnityBlitResolver.Instance);
			customResolvers.Add(StandardResolver.Instance);

			StaticCompositeResolver.Instance.Register(customResolvers.ToArray());
			MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance).WithCompression(MessagePackCompression.Lz4Block);

			serializerRegistered = true;
		}

		public static readonly IFormatterResolver Instance = new LevelEditorResolver();

		private LevelEditorResolver() { }

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.Formatter;
		}

		public static void RegisterResolver(IFormatterResolver resolver)
		{
			// Insert it in the beginning to prioritize new resolvers.
			customResolvers.Insert(0, resolver);
		}

		public static void RegisterWrapperSerializer(IWrapperSerializer serializer)
		{
			wrapperSerializers.Add(serializer);
		}

		public static void RegisterDynamicResolver(IDynamicResolver resolver)
		{
			dynamicResolvers.Add(resolver);
		}

		public bool SerializeWrapper(ref MessagePackWriter writer, IExposedWrapper value, MessagePackSerializerOptions options)
		{
			for (int i = 0; i < wrapperSerializers.Count; i++)
			{
				if (wrapperSerializers[i].SerializeWrapper(ref writer, value, options))
				{
					return true;
				}
			}

			return false;
		}

		public bool DeserializeWrapper(Type type, ref MessagePackReader reader, MessagePackSerializerOptions options, out IExposedWrapper wrapper)
		{
			for (int i = 0; i < wrapperSerializers.Count; i++)
			{
				if (wrapperSerializers[i].DeserializeWrapper(type, ref reader, options, out wrapper))
				{
					return true;
				}
			}

			throw new FormatterNotRegisteredException($"Found no wrapper formatter for type {type}.");
		}

		public bool SerializeDynamic(Type type, ref MessagePackWriter writer, object value, MessagePackSerializerOptions options)
		{
			for (int i = 0; i < dynamicResolvers.Count; i++)
			{
				if (dynamicResolvers[i].SerializeDynamic(type, ref writer, value, options))
				{
					return true;
				}
			}

			throw new FormatterNotRegisteredException($"Found no formatter for type {type}.");
		}

		public bool DeserializeDynamic(Type type, ref MessagePackReader reader, out object value, MessagePackSerializerOptions options)
		{
			for (int i = 0; i < dynamicResolvers.Count; i++)
			{
				if (dynamicResolvers[i].DeserializeDynamic(type, ref reader, out value, options))
				{
					return true;
				}
			}

			throw new FormatterNotRegisteredException($"Found no formatter for type {type}.");
		}

		private static class FormatterCache<T>
		{
			internal static readonly IMessagePackFormatter<T> Formatter;

			static FormatterCache()
			{
				IMessagePackFormatter f = LevelEditorResolverGetFormatterHelper.GetFormatter(typeof(T));
				if (f != null)
				{
					Formatter = (IMessagePackFormatter<T>) f;
				}
			}
		}

		private static class LevelEditorResolverGetFormatterHelper
		{
			private static readonly Dictionary<Type, int> lookup = new Dictionary<Type, int>(8)
			{
				{ typeof(LevelEditorSaveData), 0 },
				{ typeof(LevelEditorObjectData), 1 },
				{ typeof(LevelEditorComponentData), 2 },
				{ typeof(LevelEditorCustomData), 3 },
				{ typeof(List<LevelEditorObjectData>), 4 },
				{ typeof(LevelEditorComponentData[]), 5 },
				{ typeof(LevelEditorPropertyData[]), 6 },
				{ typeof(Dictionary<string, LevelEditorCustomData>), 7 },
				{ typeof(ComponentDataWrapper), 8 },
				{ typeof(ComponentDataWrapper[]), 9 },
				{ typeof(List<ComponentDataWrapper>), 10 },
				{ typeof(TransformWrapper.Wrapper), 11 },
				{ typeof(RigidbodyWrapper.Wrapper), 12 }
			};
			
			internal static IMessagePackFormatter GetFormatter(Type t)
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
						return new LevelEditorCustomDataFormatter();
					case 4:
						return new ListFormatter<LevelEditorObjectData>();
					case 5:
						return new ArrayFormatter<LevelEditorComponentData>();
					case 6:
						return new ArrayFormatter<LevelEditorPropertyData>();
					case 7:
						return new DictionaryFormatter<string, LevelEditorCustomData>();
					case 8:
						return new ComponentDataWrapperFormatter();
					case 9:
						return new ArrayFormatter<ComponentDataWrapper>();
					case 10:
						return new ListFormatter<ComponentDataWrapper>();
					case 11:
						return new TransformWrapperFormatter();
					case 12:
						return new RigidbodyWrapperFormatter();
					default:
						return null;
				}
			}
		}
	}
}