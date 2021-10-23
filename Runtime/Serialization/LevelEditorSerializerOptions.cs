using MessagePack;

namespace Hertzole.ALE
{
	public class LevelEditorSerializerOptions : MessagePackSerializerOptions
	{
		public ushort SaveVersion { get; set; } = 1;
		
		protected internal LevelEditorSerializerOptions(IFormatterResolver resolver) : base(resolver) { }

		public LevelEditorSerializerOptions(MessagePackSerializerOptions copyFrom) : base(copyFrom) { }

		protected override MessagePackSerializerOptions Clone()
		{
			return new LevelEditorSerializerOptions(this);
		}
	}
}