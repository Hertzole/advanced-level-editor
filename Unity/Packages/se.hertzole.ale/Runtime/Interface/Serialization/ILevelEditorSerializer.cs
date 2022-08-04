namespace Hertzole.ALE
{
	public interface ILevelEditorSerializer
	{
		byte[] Serialize<T>(T value, bool compress = true);
		
		T Deserialize<T>(byte[] data, bool compressed = true);
	}
}