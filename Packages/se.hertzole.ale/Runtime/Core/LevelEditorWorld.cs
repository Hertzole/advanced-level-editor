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
			getObjectsList.Clear();
		}
		
		private static readonly List<ILevelEditorObject> objects = new List<ILevelEditorObject>();
		private static readonly List<ILevelEditorObject> getObjectsList = new List<ILevelEditorObject>();

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
			bool result = TryGetObjects(new uint[1] { instanceId }, out ILevelEditorObject[] values);
			if (values != null && values.Length == 1)
			{
				value = values[0];
			}
			else
			{
				value = null;
			}

			return result;
		}
		
		public static bool TryGetObjects(uint[] ids, out ILevelEditorObject[] value)
		{
			if (objects == null || objects.Count == 0)
			{
				value = Array.Empty<ILevelEditorObject>();
				return false;
			}
			
			getObjectsList.Clear();

			for (int i = 0; i < ids.Length; i++)
			{
				for (int j = 0; j < objects.Count; j++)
				{
					if (objects[j].InstanceID == ids[i])
					{
						getObjectsList.Add(objects[j]);
						break;
					}
				}
			}

			value = getObjectsList.ToArray();
			return value.Length > 0;
		}

		public static bool TryGetObject<T>(uint instanceId, out T value) where T : Object
		{
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
			bool result = TryGetObjects(new uint[1] { instanceId }, type, out Object[] values);
			if (values != null && values.Length == 1)
			{
				value = values[0];
			}
			else
			{
				value = null;
			}

			return result;
		}
		
		public static bool TryGetObjects<T>(uint[] ids, out T[] value) where T : Object
		{
			if (objects == null || objects.Count == 0)
			{
				value = Array.Empty<T>();
				return false;
			}

			List<T> values = new List<T>();

			for (int i = 0; i < ids.Length; i++)
			{
				for (int j = 0; j < objects.Count; j++)
				{
					if (objects[j].InstanceID == ids[i])
					{
						if (typeof(T) == typeof(GameObject))
						{
							values.Add(objects[j].MyGameObject as T);
							break;
						}

						if (typeof(T) == typeof(Transform))
						{
							values.Add(objects[j].MyGameObject.transform as T);
							break;
						}
					
						if (objects[j].MyGameObject.TryGetComponent(out T val))
						{
							values.Add(val);
							break;
						}
					}
				}
			}
			
			value = values.ToArray();
			return values.Count > 0;
		}
		
		public static bool TryGetObjects(uint[] ids, Type type, out Object[] value)
		{
			if (objects == null || objects.Count == 0)
			{
				value = null;
				return false;
			}

			List<Object> values = new List<Object>();

			for (int i = 0; i < ids.Length; i++)
			{
				for (int j = 0; j < objects.Count; j++)
				{
					if (objects[j].InstanceID == ids[i])
					{
						if (type == typeof(GameObject))
						{
							values.Add(objects[j].MyGameObject);
							break;
						}

						if (type == typeof(Transform))
						{
							values.Add(objects[j].MyGameObject.transform);
							break;
						}
					
						if (objects[j].MyGameObject.TryGetComponent(type, out Component val))
						{
							values.Add(val);
							break;
						}
					}
				}
			}

			value = values.ToArray();
			return values.Count > 0;
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