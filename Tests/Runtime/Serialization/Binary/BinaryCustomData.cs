namespace Hertzole.ALE.Tests.Serialization.Binary
{
	public class BinaryCustomData : CustomDataTest
	{
		protected override LevelEditorSaveManager.FormatType GetFormatType()
		{
			return LevelEditorSaveManager.FormatType.Binary;
		}
	}
}