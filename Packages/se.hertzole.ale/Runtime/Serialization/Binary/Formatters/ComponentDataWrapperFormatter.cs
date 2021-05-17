using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE
{
	public class ComponentDataWrapperFormatter : IMessagePackFormatter<ComponentDataWrapper>
	{
		public void Serialize(ref MessagePackWriter writer, ComponentDataWrapper value, MessagePackSerializerOptions options)
		{
			if (value.objects == null || value.objects.Length == 0)
			{
				writer.WriteNil();
				return;
			}
			
			writer.WriteArrayHeader(value.objects.Length);
			for (int i = 0; i < value.objects.Length; i++)
			{
				writer.WriteUInt32(value.objects[i]);
			}
		}

		public ComponentDataWrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return new ComponentDataWrapper(0);
			}
			
			options.Security.DepthStep(ref reader);

			int length = reader.ReadArrayHeader();
			uint[] objects = new uint[length];
			for (int i = 0; i < length; i++)
			{
				objects[i] = reader.ReadUInt32();
			}
			
			reader.Depth--;

			return new ComponentDataWrapper(objects);
		}
	}
}