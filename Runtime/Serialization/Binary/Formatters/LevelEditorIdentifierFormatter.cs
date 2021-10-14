using MessagePack;
using MessagePack.Formatters;

namespace Hertzole.ALE
{
	public class LevelEditorIdentifierFormatter : IMessagePackFormatter<LevelEditorIdentifier>
	{
		public void Serialize(ref MessagePackWriter writer, LevelEditorIdentifier value, MessagePackSerializerOptions options)
		{
			writer.WriteInt32(value.value);
		}

		public LevelEditorIdentifier Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return new LevelEditorIdentifier(0);
			}

			return new LevelEditorIdentifier(reader.ReadInt32());
		}
	}
}