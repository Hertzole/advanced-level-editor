using MessagePack;

namespace Hertzole.ALE
{
	public interface IDynamicResolver
	{
		bool SerializeDynamic(ref MessagePackWriter writer, object value, MessagePackSerializerOptions options);

		bool DeserializeDynamic(ref MessagePackReader reader, MessagePackSerializerOptions options, out object value);
	}
}