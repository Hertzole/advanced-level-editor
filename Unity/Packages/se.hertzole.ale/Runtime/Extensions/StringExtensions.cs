namespace Hertzole.ALE
{
	public static partial class LevelEditorExtensions
	{
		public static int GetStableHashCode(this string text)
		{
			unchecked
			{
				int hash = 23;
				for (int i = 0; i < text.Length; i++)
				{
					hash = hash * 31 + text[i];
				}

				return hash;
			}
		}
	}
}