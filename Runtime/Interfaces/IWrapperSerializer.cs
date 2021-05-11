using System;
using MessagePack;

namespace Hertzole.ALE
{
	public interface IWrapperSerializer
	{
		bool SerializeWrapper(Type type, ref MessagePackWriter writer, IExposedWrapper value, MessagePackSerializerOptions options);

		bool DeserializeWrapper(Type type, ref MessagePackReader reader, MessagePackSerializerOptions options, out IExposedWrapper wrapper);
	}
}