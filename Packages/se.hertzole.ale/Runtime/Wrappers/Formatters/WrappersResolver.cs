using System;
using MessagePack;
using UnityEngine;

namespace Hertzole.ALE.Formatters
{
	public class WrappersResolver : IWrapperSerializer
	{
		private static bool registered;
		
		private static readonly WrappersResolver instance = new WrappersResolver();
		
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RegisterWrapper()
		{
			if (registered)
			{
				return;
			}

			registered = true;
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
			if (type == typeof(TransformWrapper.Wrapper))
			{
				wrapper = options.Resolver.GetFormatter<TransformWrapper.Wrapper>().Deserialize(ref reader, options);
				return true;
			}
			
			if (type == typeof(RigidbodyWrapper.Wrapper))
			{
				wrapper = options.Resolver.GetFormatter<RigidbodyWrapper.Wrapper>().Deserialize(ref reader, options);
				return true;
			}

			wrapper = null;
			return false;
		}
	}
}