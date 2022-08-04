namespace Hertzole.ALE.SourceGenerator.Extensions;

public static class StringExtensions
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