using System;
using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE.Formatters
{
	public class RigidbodyWrapperFormatter : IMessagePackFormatter<RigidbodyWrapper.Wrapper>
	{
		public void Serialize(ref MessagePackWriter writer, RigidbodyWrapper.Wrapper value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(10);
			writer.WriteInt8(0);
			options.Resolver.GetFormatterWithVerify<float>().Serialize(ref writer, value.mass, options);
			writer.WriteInt8(1);
			options.Resolver.GetFormatterWithVerify<float>().Serialize(ref writer, value.drag, options);
			writer.WriteInt8(2);
			options.Resolver.GetFormatterWithVerify<float>().Serialize(ref writer, value.angularDrag, options);
			writer.WriteInt8(3);
			options.Resolver.GetFormatterWithVerify<bool>().Serialize(ref writer, value.useGravity, options);
			writer.WriteInt8(4);
			options.Resolver.GetFormatterWithVerify<bool>().Serialize(ref writer, value.isKinematic, options);
		}

		public RigidbodyWrapper.Wrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}

			options.Security.DepthStep(ref reader);

			int length = reader.ReadArrayHeader() / 2;
			float mass = default;
			float drag = default;
			float angularDrag = default;
			bool useGravity = default;
			bool isKinematic = default;

			for (int i = 0; i < length; i++)
			{
				byte id = reader.ReadByte();
				switch (id)
				{
					case 0:
						mass = reader.ReadSingle();
						break;
					case 1:
						drag = reader.ReadSingle();
						break;
					case 2:
						angularDrag = reader.ReadSingle();
						break;
					case 3:
						useGravity = reader.ReadBoolean();
						break;
					case 4:
						isKinematic = reader.ReadBoolean();
						break;
					default:
						reader.Skip();
						break;
				}
			}
			
			reader.Depth--;
			return new RigidbodyWrapper.Wrapper(mass, drag, angularDrag, useGravity, isKinematic);
		}
	}
}