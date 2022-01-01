namespace Hertzole.ALE.Tests.Serialization.Binary
{
	public class BinaryPrimitives : PrimitivesTest
	{
		protected override void OnSetUp()
		{
			saveManager.LevelFormat = LevelEditorSaveManager.FormatType.Binary;
		}
	}
}