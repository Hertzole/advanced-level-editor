using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Hertzole.ALE
{
	public static class LevelEditorLogger
	{
		[Conditional("ALE_DEBUG")]
		public static void Log(object message)
		{
			Debug.Log("[ALE] :: " + message);
		}

		[Conditional("ALE_DEBUG")]
		public static void Log(object message, Object context)
		{
			Debug.Log("[ALE] :: " + message, context);
		}

		[Conditional("ALE_DEBUG")]
		public static void LogError(object message)
		{
			Debug.LogError("[ALE] :: " + message);
		}

		[Conditional("ALE_DEBUG")]
		public static void LogError(object message, Object context)
		{
			Debug.LogError("[ALE] :: " + message, context);
		}

		[Conditional("ALE_DEBUG")]
		public static void LogWarning(object message)
		{
			Debug.LogWarning("[ALE] :: " + message);
		}

		[Conditional("ALE_DEBUG")]
		public static void LogWarning(object message, Object context)
		{
			Debug.LogWarning("[ALE] :: " + message, context);
		}
	}
}