using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE.Formatters
{
	public class RigidbodyWrapperFormatter : IMessagePackFormatter<RigidbodyWrapper.Wrapper>
	{
		public void Serialize(ref MessagePackWriter writer, RigidbodyWrapper.Wrapper value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(5);
			writer.WriteInt8(0);
			value.Serialize(0, ref writer, options);
			writer.WriteInt8(1);
			value.Serialize(1, ref writer, options);
			writer.WriteInt8(2);
			value.Serialize(2, ref writer, options);
			writer.WriteInt8(3);
			value.Serialize(3, ref writer, options);
			writer.WriteInt8(4);
			value.Serialize(4, ref writer, options);
		}

		public RigidbodyWrapper.Wrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}

			options.Security.DepthStep(ref reader);

			int length = reader.ReadArrayHeader();

			RigidbodyWrapper.Wrapper wrapper = new RigidbodyWrapper.Wrapper
			{
				Values = new Dictionary<int, object>(5),
				Dirty = new Dictionary<int, bool>(5)
			};

			for (int i = 0; i < length; i++)
			{
				byte id = reader.ReadByte();
				switch (id)
				{
					case 0:
						wrapper.Values[0] = wrapper.Deserialize(0, ref reader, options);
						wrapper.Dirty[0] = true;
						break;
					case 1:
						wrapper.Values[1] = wrapper.Deserialize(1, ref reader, options);
						wrapper.Dirty[1] = true;
						break;
					case 2:
						wrapper.Values[2] = wrapper.Deserialize(2, ref reader, options);
						wrapper.Dirty[2] = true;
						break;
					case 3:
						wrapper.Values[3] = wrapper.Deserialize(3, ref reader, options);
						wrapper.Dirty[3] = true;
						break;
					case 4:
						wrapper.Values[4] = wrapper.Deserialize(4, ref reader, options);
						wrapper.Dirty[4] = true;
						break;
					default:
						reader.Skip();
						break;
				}
			}

			reader.Depth--;
			return wrapper;
		}
	}
}