using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Hertzole.ALE
{
	/// <summary>
	/// Only used to keep track of level editor objects. Does not actually delete or create any objects.
	/// </summary>
	public static class LevelEditorWorld
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetStatics()
		{
			objects.Clear();
		}
		
		private static readonly List<ILevelEditorObject> objects = new List<ILevelEditorObject>();

		public static void AddObject(ILevelEditorObject value)
		{
			LevelEditorLogger.Log($"Add object to world: {value}");
			Assert.IsFalse(objects.Contains(value), "This object has already been added to the world.");

			objects.Add(value);
		}

		public static bool RemoveObject(ILevelEditorObject value)
		{
			LevelEditorLogger.Log($"Remove objects from world: {value}");
			return objects.Remove(value);
		}

		public static bool RemoveObject(uint instanceId)
		{
			LevelEditorLogger.Log($"Remove object from world using instance ID: {instanceId}");
			return TryGetObject(instanceId, out ILevelEditorObject value) && RemoveObject(value);
		}

		public static bool TryGetObject(uint instanceId, out ILevelEditorObject value)
		{
			if (objects == null || objects.Count == 0)
			{
				value = null;
				return false;
			}
			
			for (int i = 0; i < objects.Count; i++)
			{
				if (objects[i].InstanceID == instanceId)
				{
					value = objects[i];
					return true;
				}
			}

			value = null;
			return false;
		}

		public static bool TryGetObject<T>(uint instanceId, out T value) where T : Object
		{
			LevelEditorLogger.Log($"TryGetObject<{typeof(T)}>({instanceId})");
			
			if (TryGetObject(instanceId, typeof(T), out Object val))
			{
				value = (T) val;
				return true;
			}

			value = null;
			return false;
		}

		public static bool TryGetObject(uint instanceId, Type type, out Object value)
		{
			if (objects == null || objects.Count == 0)
			{
				value = null;
				return false;
			}
			
			for (int i = 0; i < objects.Count; i++)
			{
				if (objects[i].InstanceID == instanceId)
				{
					if (type == typeof(GameObject))
					{
						value = objects[i].MyGameObject;
						return true;
					}

					if (type == typeof(Transform))
					{
						value = objects[i].MyGameObject.transform;
						return true;
					}
					
					if (objects[i].MyGameObject.TryGetComponent(type, out Component val))
					{
						value = val;
						return true;
					}

					value = null;
					return false;
				}
			}

			value = null;
			return false;
		}

		public static T[] GetObjects<T>() where T : Object
		{
			if (objects == null || objects.Count == 0)
			{
				return Array.Empty<T>();
			}
			
			return (T[])GetObjects(typeof(T));
		}
		
		public static Object[] GetObjects(Type type)
		{
			if (objects == null || objects.Count == 0)
			{
				return Array.Empty<Object>();
			}

			// If the type is GameObject we can just return all objects.
			if (type == typeof(GameObject))
			{
				Object[] goResult = new Object[objects.Count];
				for (int i = 0; i < objects.Count; i++)
				{
					goResult[i] = objects[i].MyGameObject;
				}

				return goResult;
			}

			// If the type is Transform we can just return all objects.
			if (type == typeof(Transform))
			{
				Object[] transformResult = new Object[objects.Count];
				for (int i = 0; i < objects.Count; i++)
				{
					transformResult[i] = objects[i].MyGameObject.transform;
				}

				return transformResult;
			}

			List<Object> result = new List<Object>();
			for (int i = 0; i < objects.Count; i++)
			{
				if (objects[i].MyGameObject.TryGetComponent(type, out Component value))
				{
					result.Add(value);
				}
			}

			return result.ToArray();
		}
	}
}