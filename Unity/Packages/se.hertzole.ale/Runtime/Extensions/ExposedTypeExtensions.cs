namespace Hertzole.ALE
{
	public static partial class LevelEditorExtensions
	{
		public static void SetValue<T>(this IExposedType exposedType, int id, T value)
		{
			if (exposedType.ExposedVars.TryGetExposedVar(id, out ExposedVar<T> exposedVar))
			{
				exposedVar.Value = value;
			}
		}

		public static T GetValue<T>(this IExposedType exposedType, int id)
		{
			if (exposedType.ExposedVars.TryGetExposedVar(id, out ExposedVar<T> exposedVar))
			{
				return exposedVar.Value;
			}

			return default;
		}
	}
}