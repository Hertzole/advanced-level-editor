namespace Hertzole.ALE
{
	public static partial class LevelEditorExtensions
	{
		public static bool HasExposedProperties(this ILevelEditorObject obj)
		{
			IExposedToLevelEditor[] components = obj.GetExposedComponents();
			if (components == null || components.Length == 0)
			{
				return false;
			}

			for (int i = 0; i < components.Length; i++)
			{
				if (components[i].HasVisibleFields)
				{
					return true;
				}
			}

			return false;
		}
	}
}