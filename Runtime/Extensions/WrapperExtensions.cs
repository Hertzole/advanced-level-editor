using System;

namespace Hertzole.ALE
{
	public static partial class LevelEditorExtensions
	{
		public static T GetValue<T>(this IExposedWrapper wrapper, int id)
		{
			if (wrapper.Values == null)
			{
				return default;
			}

			if (!wrapper.Values.TryGetValue(id, out object value))
			{
				throw new ArgumentException($"There's no value with the ID {id}.");
			}

			if (value is T result)
			{
				return result;
			}

			return default;
		}

		public static bool IsDirty(this IExposedWrapper wrapper, int id)
		{
			if (wrapper.Dirty == null)
			{
				return false;
			}

			return wrapper.Dirty.TryGetValue(id, out bool dirty) && dirty;
		}
	}
}