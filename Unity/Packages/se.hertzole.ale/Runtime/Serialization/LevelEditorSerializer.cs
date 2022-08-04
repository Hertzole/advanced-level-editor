using MessagePack;

namespace Hertzole.ALE
{
	public class LevelEditorSerializer : ILevelEditorSerializer
	{
		private bool previousCompress = false;

		private MessagePackSerializerOptions options = new MessagePackSerializerOptions(LevelEditorResolver.instance);
		
		public byte[] Serialize<T>(T value, bool compress = true)
		{
			if (compress != previousCompress)
			{
				previousCompress = compress;
				UpdateCompression();
			}

			return MessagePackSerializer.Serialize(value, options);
		}

		public T Deserialize<T>(byte[] data, bool compressed = true)
		{
			if (compressed != previousCompress)
			{
				previousCompress = compressed;
				UpdateCompression();
			}

			return MessagePackSerializer.Deserialize<T>(data, options);
		}

		private void UpdateCompression()
		{
			options = options.WithCompression(previousCompress ? MessagePackCompression.Lz4Block : MessagePackCompression.None);
		}
	}
}