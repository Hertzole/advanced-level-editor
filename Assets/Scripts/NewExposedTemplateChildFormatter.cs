using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

public class NewExposedTemplateChildFormatter : IMessagePackFormatter<NewExposedTemplateChild.ChildWrapper>
{
	public void Serialize(ref MessagePackWriter writer, NewExposedTemplateChild.ChildWrapper value, MessagePackSerializerOptions options)
	{
		writer.WriteArrayHeader(2);
		writer.WriteInt32(0);
		value.Serialize(0, ref writer, options);
		writer.WriteInt32(1);
		value.Serialize(1, ref writer, options);
	}

	public NewExposedTemplateChild.ChildWrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		if (reader.TryReadNil())
		{
			throw new InvalidOperationException("typecode is null, struct not supported.");
		}

		options.Security.DepthStep(ref reader);

		int length = reader.ReadArrayHeader();
		NewExposedTemplateChild.ChildWrapper wrapper = new NewExposedTemplateChild.ChildWrapper
		{
			Values = new Dictionary<int, object>(3),
			Dirty = new Dictionary<int, bool>(3)
		};

		for (int i = 0; i < length; i++)
		{
			int id = reader.ReadInt32();
			if (id == 0)
			{
				wrapper.Values[0] = wrapper.Deserialize(0, ref reader, options);
				wrapper.Dirty[0] = true;
				continue;
			}

			if (id == 1)
			{
				wrapper.Values[1] = wrapper.Deserialize(1, ref reader, options);
				wrapper.Dirty[1] = true;
				continue;
			}

			if (id == 2)
			{
				wrapper.Values[2] = wrapper.Deserialize(2, ref reader, options);
				wrapper.Dirty[2] = true;
			}
		}

		reader.Depth--;
		return wrapper;
	}
}