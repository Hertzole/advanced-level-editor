namespace Hertzole.ALE.Tests.Serialization.Binary
{
	public class BinaryUnityPrimitives : UnityPrimitives
	{
		protected override void OnSetUp()
		{
			saveManager.LevelFormat = LevelEditorSaveManager.FormatType.Binary;
		}
	}
}