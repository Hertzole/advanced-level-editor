using System;
using MessagePack;

namespace Hertzole.ALE
{
	public interface IWrapperResolver
	{
		bool SerializeWrapper(ref MessagePackWriter writer, IWrapper wrapper, MessagePackSerializerOptions options);

		bool DeserializeWrapper(ref MessagePackReader reader, MessagePackSerializerOptions options, Type type, out IWrapper value);
	}
}