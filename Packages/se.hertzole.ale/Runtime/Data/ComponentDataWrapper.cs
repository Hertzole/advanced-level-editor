using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hertzole.ALE
{
	public readonly struct ComponentDataWrapper : IEquatable<ComponentDataWrapper>
	{
		public readonly uint[] objects;

		public ComponentDataWrapper(uint target) : this(new uint[] { target }) { }
		
		public ComponentDataWrapper(uint[] objects)
		{
			this.objects = objects;
		}

		public ComponentDataWrapper(Component component) : this(new Component[] { component }) { }

		public ComponentDataWrapper(IReadOnlyList<Component> component)
		{
			if (component == null || component.Count == 0)
			{
				objects = new uint[0];
			}
			else
			{
				objects = new uint[component.Count];
				
				for (int i = 0; i < component.Count; i++)
				{
					if (component[i] != null && component[i].TryGetComponent(out ILevelEditorObject obj))
					{
						objects[i] = obj.InstanceID;
					}
					else
					{
						objects[i] = 0;
					}
				}
			}
		}

		public ComponentDataWrapper(GameObject go) : this(new GameObject[] { go }) { }

		public ComponentDataWrapper(IReadOnlyList<GameObject> go)
		{
			if (go == null || go.Count == 0)
			{
				objects = new uint[0];
			}
			else
			{
				objects = new uint[go.Count];
				
				for (int i = 0; i < go.Count; i++)
				{
					if (go[i] != null && go[i].TryGetComponent(out ILevelEditorObject obj))
					{
						objects[i] = obj.InstanceID;
					}
					else
					{
						objects[i] = 0;
					}
				}
			}
		}

		public static bool IsComponent(Type type)
		{
			return type.IsSubclassOf(typeof(Component)) || type == typeof(GameObject);
		}

		public T GetObject<T>() where T : Object
		{
			return (T)GetObject(typeof(T));
		}
		
		public Object GetObject(Type type) 
		{
			if (objects == null || objects.Length == 0)
			{
				return null;
			}
			
			return LevelEditorWorld.TryGetObject(objects[0], type, out Object value) ? value : null;
		}

		public T[] GetObjects<T>() where T : Object
		{
			if (objects == null || objects.Length == 0)
			{
				return Array.Empty<T>();
			}

			return LevelEditorWorld.TryGetObjects(objects, out T[] value) ? value : Array.Empty<T>();
		}

		public bool TryGetObject<T>(Type type, out T value) where T : Object
		{
			if (objects == null || objects.Length == 0)
			{
				value = null;
				return false;
			}

			return LevelEditorWorld.TryGetObject(objects[0], out value);
		}
		
		public bool TryGetObject(Type type, out Object value)
		{
			if (objects == null || objects.Length == 0)
			{
				value = null;
				return false;
			}

			return LevelEditorWorld.TryGetObject(objects[0], type, out value);
		}
		
		public bool TryGetObject(out ILevelEditorObject value)
		{
			if (objects == null || objects.Length == 0)
			{
				value = null;
				return false;
			}

			return LevelEditorWorld.TryGetObject(objects[0], out value);
		}

		public bool Equals(Component component)
		{
			if (objects == null || objects.Length != 1)
			{
				return false;
			}
			
			if (objects[0] == 0 && component == null)
			{
				return true;
			}

			if (component == null)
			{
				return false;
			}

			if (!component.TryGetComponent(out ILevelEditorObject obj))
			{
				return false;
			}
			
			return objects[0] == obj.InstanceID;
		}
		
		public bool Equals(IReadOnlyList<Component> components)
		{
			if (objects == null && components == null)
			{
				return true;
			}

			if (objects == null || components == null)
			{
				return false;
			}
			
			if (objects.Length != components.Count)
			{
				return false;
			}

			for (int i = 0; i < objects.Length; i++)
			{
				if (!components[i].TryGetComponent(out ILevelEditorObject obj))
				{
					return false;
				}

				if (objects[i] != obj.InstanceID)
				{
					return false;
				}
			}
			
			return true;
		}
		
		public bool Equals(GameObject go)
		{
			if (objects == null || objects.Length != 1)
			{
				return false;
			}
			
			if (objects[0] == 0 && go == null)
			{
				return true;
			}

			if (go == null)
			{
				return false;
			}

			if (!go.TryGetComponent(out ILevelEditorObject obj))
			{
				return false;
			}

			return objects[0] == obj.InstanceID;
		}
		
		public bool Equals(IReadOnlyList<GameObject> gameObjects)
		{
			if (objects == null && gameObjects == null)
			{
				return true;
			}

			if (objects == null || gameObjects == null)
			{
				return false;
			}
			
			if (objects.Length != gameObjects.Count)
			{
				return false;
			}

			for (int i = 0; i < objects.Length; i++)
			{
				if (!gameObjects[i].TryGetComponent(out ILevelEditorObject obj))
				{
					return false;
				}

				if (objects[i] != obj.InstanceID)
				{
					return false;
				}
			}
			
			return true;
		}

		public bool Equals(ComponentDataWrapper other)
		{
			if (objects == null && other.objects == null)
			{
				return true;
			}

			if (objects == null || other.objects == null)
			{
				return false;
			}

			if (objects.Length != other.objects.Length)
			{
				return false;
			}

			for (int i = 0; i < objects.Length; i++)
			{
				if (objects[i] != other.objects[i])
				{
					return false;
				}
			}

			return true;
		}

		public override bool Equals(object obj)
		{
			return obj is ComponentDataWrapper other && Equals(other);
		}

		public override int GetHashCode()
		{
			if (objects == null || objects.Length == 0)
			{
				return 0;
			}
			
			unchecked
			{
				int hash = objects.Length.GetHashCode();
				for (int i = 0; i < objects.Length; i++)
				{
					hash = hash * 23 * objects[i].GetHashCode();
				}

				return hash;
			}
		}

		public static bool operator ==(ComponentDataWrapper left, ComponentDataWrapper right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ComponentDataWrapper left, ComponentDataWrapper right)
		{
			return !left.Equals(right);
		}
	}
}