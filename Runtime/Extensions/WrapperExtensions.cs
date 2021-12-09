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
			
			// Special case, strings can be null. If we request a string and it's null, just return the default value.
			if (value == null && typeof(T) == typeof(string))
			{
				return default;
			}

			throw new ArgumentException($"Value ({value}, {(value == null ? "No type" : value.GetType().FullName)}) with ID {id} is not of value {typeof(T)}.");
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