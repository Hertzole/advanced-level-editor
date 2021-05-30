using System;
using MessagePack;
using UnityEngine;

namespace Hertzole.ALE
{
	public class LevelEditorWrapperResolver : IWrapperSerializer
	{
		private static readonly LevelEditorWrapperResolver instance = new LevelEditorWrapperResolver();
		private static bool registeredResolver = false;
		
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RegisterResolver()
		{
			if (registeredResolver)
			{
				return;
			}

			registeredResolver = true;
			
			LevelEditorResolver.RegisterWrapperSerializer(instance);
		}
		
		public bool SerializeWrapper(ref MessagePackWriter writer, IExposedWrapper value, MessagePackSerializerOptions options)
		{
			if (value is TransformWrapper.Wrapper transformWrapper)
			{
				options.Resolver.GetFormatter<TransformWrapper.Wrapper>().Serialize(ref writer, transformWrapper, options);
				return true;
			}
			
			if (value is RigidbodyWrapper.Wrapper rigidbodyWrapper)
			{
				options.Resolver.GetFormatter<RigidbodyWrapper.Wrapper>().Serialize(ref writer, rigidbodyWrapper, options);
				return true;
			}

			return false;
		}

		public bool DeserializeWrapper(Type type, ref MessagePackReader reader, MessagePackSerializerOptions options, out IExposedWrapper wrapper)
		{
			if (type == typeof(Transform))
			{
				wrapper = options.Resolver.GetFormatter<TransformWrapper.Wrapper>().Deserialize(ref reader, options);
				return true;
			}
			
			if (type == typeof(Rigidbody))
			{
				wrapper = options.Resolver.GetFormatter<RigidbodyWrapper.Wrapper>().Deserialize(ref reader, options);
				return true;
			}

			wrapper = null;
			return false;
		}
	}
}