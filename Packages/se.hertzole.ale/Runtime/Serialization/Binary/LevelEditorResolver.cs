using System;
using System.Collections.Generic;
using Hertzole.ALE.Formatters;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
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

		public static readonly IFormatterResolver instance = new LevelEditorResolver();

		private LevelEditorResolver() { }

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

			customResolvers.Add(instance);
			customResolvers.Add(UnityResolver.Instance);
			customResolvers.Add(UnityBlitResolver.Instance);
			customResolvers.Add(StandardResolver.Instance);

			StaticCompositeResolver.Instance.Register(customResolvers.ToArray());
			LevelEditorSerializer.Options = (LevelEditorSerializerOptions) LevelEditorSerializer.Options.WithResolver(StaticCompositeResolver.Instance);

			serializerRegistered = true;
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
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
			internal static readonly IMessagePackFormatter<T> formatter = GetFormatter();

			private static IMessagePackFormatter<T> GetFormatter()
			{
				IMessagePackFormatter f = LevelEditorResolverGetFormatterHelper.GetFormatter(typeof(T));
				return (IMessagePackFormatter<T>) f;
			}
		}

		private static class LevelEditorResolverGetFormatterHelper
		{
			private static readonly Dictionary<Type, IMessagePackFormatter> lookup = new Dictionary<Type, IMessagePackFormatter>
			{
				// Standard
				{ typeof(LevelEditorSaveData), new LevelEditorSaveDataFormatter() },
				{ typeof(LevelEditorObjectData), new LevelEditorObjectDataFormatter() },
				{ typeof(LevelEditorComponentData), new LevelEditorComponentDataFormatter() },
				{ typeof(LevelEditorCustomData), new LevelEditorCustomDataFormatter() },
				{ typeof(ComponentDataWrapper), new ComponentDataWrapperFormatter() },
				{ typeof(LevelEditorIdentifier), new LevelEditorIdentifierFormatter() },
				{ typeof(LevelEditorSaveData?), new StaticNullableFormatter<LevelEditorSaveData>(new LevelEditorSaveDataFormatter()) },
				{ typeof(LevelEditorObjectData?), new StaticNullableFormatter<LevelEditorObjectData>(new LevelEditorObjectDataFormatter()) },
				{ typeof(LevelEditorComponentData?), new StaticNullableFormatter<LevelEditorComponentData>(new LevelEditorComponentDataFormatter()) },
				{ typeof(LevelEditorCustomData?), new StaticNullableFormatter<LevelEditorCustomData>(new LevelEditorCustomDataFormatter()) },
				{ typeof(ComponentDataWrapper?), new StaticNullableFormatter<ComponentDataWrapper>(new ComponentDataWrapperFormatter()) },
				{ typeof(LevelEditorIdentifier?), new StaticNullableFormatter<LevelEditorIdentifier>(new LevelEditorIdentifierFormatter()) },

				// Standard array
				{ typeof(LevelEditorSaveData[]), new ArrayFormatter<LevelEditorSaveData>() },
				{ typeof(LevelEditorObjectData[]), new ArrayFormatter<LevelEditorObjectData>() },
				{ typeof(LevelEditorComponentData[]), new ArrayFormatter<LevelEditorComponentData>() },
				{ typeof(LevelEditorCustomData[]), new ArrayFormatter<LevelEditorCustomData>() },
				{ typeof(ComponentDataWrapper[]), new ArrayFormatter<ComponentDataWrapper>() },
				{ typeof(LevelEditorIdentifier[]), new ArrayFormatter<LevelEditorIdentifier>() },
				{ typeof(LevelEditorSaveData?[]), new ArrayFormatter<LevelEditorSaveData?>() },
				{ typeof(LevelEditorObjectData?[]), new ArrayFormatter<LevelEditorObjectData?>() },
				{ typeof(LevelEditorComponentData?[]), new ArrayFormatter<LevelEditorComponentData?>() },
				{ typeof(LevelEditorCustomData?[]), new ArrayFormatter<LevelEditorCustomData?>() },
				{ typeof(ComponentDataWrapper?[]), new ArrayFormatter<ComponentDataWrapper?>() },
				{ typeof(LevelEditorIdentifier?[]), new ArrayFormatter<LevelEditorIdentifier?>() },

				// Standard list
				{ typeof(List<LevelEditorSaveData>), new ListFormatter<LevelEditorSaveData>() },
				{ typeof(List<LevelEditorObjectData>), new ListFormatter<LevelEditorObjectData>() },
				{ typeof(List<LevelEditorComponentData>), new ListFormatter<LevelEditorComponentData>() },
				{ typeof(List<LevelEditorCustomData>), new ListFormatter<LevelEditorCustomData>() },
				{ typeof(List<ComponentDataWrapper>), new ListFormatter<ComponentDataWrapper>() },
				{ typeof(List<LevelEditorIdentifier>), new ListFormatter<LevelEditorIdentifier>() },
				{ typeof(List<LevelEditorSaveData?>), new ListFormatter<LevelEditorSaveData?>() },
				{ typeof(List<LevelEditorObjectData?>), new ListFormatter<LevelEditorObjectData?>() },
				{ typeof(List<LevelEditorComponentData?>), new ListFormatter<LevelEditorComponentData?>() },
				{ typeof(List<LevelEditorCustomData?>), new ListFormatter<LevelEditorCustomData?>() },
				{ typeof(List<ComponentDataWrapper?>), new ListFormatter<ComponentDataWrapper?>() },
				{ typeof(List<LevelEditorIdentifier?>), new ListFormatter<LevelEditorIdentifier?>() },

				// Wrappers
				{ typeof(TransformWrapper.Wrapper), new TransformWrapperFormatter() },
				{ typeof(RigidbodyWrapper.Wrapper), new RigidbodyWrapperFormatter() },

				// Specials
				{ typeof(Dictionary<string, LevelEditorCustomData>), new DictionaryFormatter<string, LevelEditorCustomData>() }
			};

			internal static IMessagePackFormatter GetFormatter(Type t)
			{
				return lookup.TryGetValue(t, out IMessagePackFormatter formatter) ? formatter : null;
			}
		}
	}
}