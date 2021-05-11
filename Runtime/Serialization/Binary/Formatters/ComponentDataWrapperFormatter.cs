using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE
{
	public class ComponentDataWrapperFormatter : MessagePackFormatter<ComponentDataWrapper>
	{
		public override void Serialize(ref MessagePackWriter writer, ComponentDataWrapper value, MessagePackSerializerOptions options)
		{
			writer.WriteUInt32(value.instanceId);
		}

		public override ComponentDataWrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			options.Security.DepthStep(ref reader);
			uint instanceId = reader.ReadUInt32();
			reader.Depth--;

			return new ComponentDataWrapper(instanceId);
		}
	}
}