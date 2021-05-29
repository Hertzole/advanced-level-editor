using System;
using MessagePack;

namespace Hertzole.ALE
{
	public interface IDynamicResolver
	{
		bool SerializeDynamic(Type type, ref MessagePackWriter writer, object value, MessagePackSerializerOptions options);
		
		bool DeserializeDynamic(Type type, ref MessagePackReader reader, out object value, MessagePackSerializerOptions options);
	}
}