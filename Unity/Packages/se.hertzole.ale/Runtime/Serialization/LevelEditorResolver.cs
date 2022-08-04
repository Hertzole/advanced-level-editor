using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using UnityEditor;

namespace Hertzole.ALE
{
	public class LevelEditorResolver : ILevelEditorResolver
	{
		private static bool registeredResolver = false;

		private static readonly List<IFormatterResolver> customResolvers = new List<IFormatterResolver>();
		private static readonly List<IWrapperResolver> wrapperResolvers = new List<IWrapperResolver>();
		private static readonly List<IDynamicResolver> dynamicResolvers = new List<IDynamicResolver>();

		public static readonly IFormatterResolver instance = new LevelEditorResolver();

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
			if (registeredResolver)
			{
				return;
			}

			customResolvers.Add(instance);
			customResolvers.Add(BuiltinResolver.Instance);
			customResolvers.Add(UnityBlitResolver.Instance);
			customResolvers.Add(UnityResolver.Instance);

			registeredResolver = true;

			LevelEditorLogger.Log("Registering ALE resolvers");
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.Formatter;
		}

		public static void RegisterResolver(ILevelEditorResolver resolver)
		{
			LevelEditorLogger.Log("Registering level editor resolver: " + resolver.GetType().Name);

			customResolvers.Insert(0, resolver);
			wrapperResolvers.Add(resolver);
			dynamicResolvers.Add(resolver);
		}

		private static class FormatterCache<T>
		{
			internal static readonly IMessagePackFormatter<T> Formatter = GetFormatter();

			private static IMessagePackFormatter<T> GetFormatter()
			{
				LevelEditorLogger.Log("Getting formatter for type: " + typeof(T).Name);

				IMessagePackFormatter f = LevelEditorResolverGetFormatterHelper.GetFormatter(typeof(T));
				LevelEditorLogger.Log("Formatter: " + f);
				if (f == null)
				{
					for (int i = 0; i < customResolvers.Count; i++)
					{
						f = customResolvers[i].GetFormatter<T>();
						if (f != null)
						{
							return (IMessagePackFormatter<T>) f;
						}
					}
				}
				else
				{
					return (IMessagePackFormatter<T>) f;
				}

				return null;
			}
		}

		public bool SerializeWrapper(ref MessagePackWriter writer, IWrapper wrapper, MessagePackSerializerOptions options)
		{
			LevelEditorLogger.Log("Serializing wrapper: " + wrapper.GetType().FullName);

			for (int i = 0; i < wrapperResolvers.Count; i++)
			{
				if (wrapperResolvers[i].SerializeWrapper(ref writer, wrapper, options))
				{
					return true;
				}
			}

			return false;
		}

		public bool SerializeDynamic(ref MessagePackWriter writer, object value, MessagePackSerializerOptions options)
		{
			for (int i = 0; i < dynamicResolvers.Count; i++)
			{
				if (dynamicResolvers[i].SerializeDynamic(ref writer, value, options))
				{
					return true;
				}
			}

			return false;
		}

		public bool DeserializeWrapper(ref MessagePackReader reader, MessagePackSerializerOptions options, Type type, out IWrapper value)
		{
			LevelEditorLogger.Log("Deserializing wrapper: " + type.FullName);

			for (int i = 0; i < wrapperResolvers.Count; i++)
			{
				if (wrapperResolvers[i].DeserializeWrapper(ref reader, options, type, out value))
				{
					return true;
				}
			}

			value = default;
			return false;
		}

		public bool DeserializeDynamic(ref MessagePackReader reader, MessagePackSerializerOptions options, out object value)
		{
			for (int i = 0; i < dynamicResolvers.Count; i++)
			{
				if (dynamicResolvers[i].DeserializeDynamic(ref reader, options, out value))
				{
					return true;
				}
			}

			value = default;
			return false;
		}

		private static class LevelEditorResolverGetFormatterHelper
		{
			private static readonly Dictionary<Type, IMessagePackFormatter> lookup = new Dictionary<Type, IMessagePackFormatter>
			{
				// Standard
				// { typeof(LevelEditorSaveData), new LevelEditorSaveDataFormatter() },
				// { typeof(LevelEditorObjectData), new LevelEditorObjectDataFormatter() },
				// { typeof(LevelEditorComponentData), new LevelEditorComponentDataFormatter() },
				// { typeof(LevelEditorCustomData), new LevelEditorCustomDataFormatter() },
				// { typeof(LevelEditorIdentifier), new LevelEditorIdentifierFormatter() },
				//
				// // Standard + array
				// { typeof(LevelEditorSaveData[]), new ArrayFormatter<LevelEditorSaveData>() },
				// { typeof(LevelEditorObjectData[]), new ArrayFormatter<LevelEditorObjectData>() },
				// { typeof(LevelEditorComponentData[]), new ArrayFormatter<LevelEditorComponentData>() },
				// { typeof(LevelEditorCustomData[]), new ArrayFormatter<LevelEditorCustomData>() },
				// { typeof(LevelEditorIdentifier[]), new ArrayFormatter<LevelEditorIdentifier>() },
				//
				// // Standard + list
				// { typeof(List<LevelEditorSaveData>), new ListFormatter<LevelEditorSaveData>() },
				// { typeof(List<LevelEditorObjectData>), new ListFormatter<LevelEditorObjectData>() },
				// { typeof(List<LevelEditorComponentData>), new ListFormatter<LevelEditorComponentData>() },
				// { typeof(List<LevelEditorCustomData>), new ListFormatter<LevelEditorCustomData>() },
				// { typeof(List<LevelEditorIdentifier>), new ListFormatter<LevelEditorIdentifier>() },
				//
				// // Extra
				// { typeof(Dictionary<string, LevelEditorCustomData>), new DictionaryFormatter<string, LevelEditorCustomData>() }
			};

			internal static IMessagePackFormatter GetFormatter(Type t)
			{
				return lookup.TryGetValue(t, out IMessagePackFormatter formatter) ? formatter : null;
			}
		}
	}
}