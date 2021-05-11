using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE
{
	public class ComponentDataWrapperFormatter : IMessagePackFormatter<ComponentDataWrapper>
	{
		public void Serialize(ref MessagePackWriter writer, ComponentDataWrapper value, MessagePackSerializerOptions options)
		{
			writer.WriteUInt32(value.instanceId);
		}

		public ComponentDataWrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			options.Security.DepthStep(ref reader);
			uint instanceId = reader.ReadUInt32();
			reader.Depth--;

			return new ComponentDataWrapper(instanceId);
		}
	}
}