using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Hertzole.ALE.Formatters
{
	public class TransformWrapperFormatter : IMessagePackFormatter<TransformWrapper.Wrapper>
	{
		public void Serialize(ref MessagePackWriter writer, TransformWrapper.Wrapper value, MessagePackSerializerOptions options)
		{
			IMessagePackFormatter<Vector3> vectorFormatter = options.Resolver.GetFormatterWithVerify<Vector3>();

			writer.WriteArrayHeader(8);
			writer.WriteInt8(0);
			vectorFormatter.Serialize(ref writer, value.position, options);
			writer.WriteInt8(1);
			vectorFormatter.Serialize(ref writer, value.rotation, options);
			writer.WriteInt8(2);
			vectorFormatter.Serialize(ref writer, value.scale, options);
			writer.WriteInt8(3);
			options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Serialize(ref writer, value.parent, options);
		}

		public TransformWrapper.Wrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}

			options.Security.DepthStep(ref reader);

			int length = reader.ReadArrayHeader() / 2;
			Vector3 position = default;
			Vector3 rotation = default;
			Vector3 scale = default;
			ComponentDataWrapper parent = default;

			IMessagePackFormatter<Vector3> vectorFormatter = options.Resolver.GetFormatterWithVerify<Vector3>();
			
			for (int i = 0; i < length; i++)
			{
				byte id = reader.ReadByte();
				switch (id)
				{
					case 0:
						position = vectorFormatter.Deserialize(ref reader, options);
						break;
					case 1:
						rotation = vectorFormatter.Deserialize(ref reader, options);
						break;
					case 2:
						scale = vectorFormatter.Deserialize(ref reader, options);
						break;
					case 3:
						parent = options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
				}
			}
			
			reader.Depth--;
			return new TransformWrapper.Wrapper(position, rotation, scale, parent);
		}
	}
}