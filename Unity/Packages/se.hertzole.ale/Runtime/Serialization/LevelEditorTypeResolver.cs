using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
	public static class LevelEditorTypeResolver
	{
		private static readonly Dictionary<int, Type> typeMap = new Dictionary<int, Type>();

		public static void RegisterType<T>()
		{
			RegisterType<T>(typeof(T).GetFullName().GetStableHashCode());
		}

		public static void RegisterType<T>(int hash)
		{
			LevelEditorLogger.Log("Registered type " + typeof(T).GetFullName() + " with hash " + hash);
			typeMap[hash] = typeof(T);
		}

		public static Type GetType(int hash)
		{
			return typeMap.TryGetValue(hash, out Type type) ? type : null;
		}
	}
}