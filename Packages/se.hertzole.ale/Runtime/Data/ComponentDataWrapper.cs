using System;
using UnityEngine;

namespace Hertzole.ALE
{
	public readonly struct ComponentDataWrapper : IEquatable<ComponentDataWrapper>
	{
		public readonly uint instanceId;

		public ComponentDataWrapper(uint instanceId)
		{
			this.instanceId = instanceId;
		}

		public ComponentDataWrapper(Component component)
		{
			if (component == null)
			{
				instanceId = 0;
			}
			else
			{
				instanceId = component.TryGetComponent(out ILevelEditorObject obj) ? obj.InstanceID : 0;
			}
		}

		public ComponentDataWrapper(GameObject go)
		{
			if (go == null)
			{
				instanceId = 0;
			}
			else
			{
				instanceId = go.TryGetComponent(out ILevelEditorObject obj) ? obj.InstanceID : 0;
			}
		}

		public static bool IsComponent(Type type)
		{
			return type.IsSubclassOf(typeof(Component)) || type == typeof(GameObject);
		}

		public bool Equals(Component component)
		{
			if (instanceId == 0 && component == null)
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
			
			return instanceId == obj.InstanceID;
		}
		
		public bool Equals(GameObject go)
		{
			if (instanceId == 0 && go == null)
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

			return instanceId == obj.InstanceID;
		}

		public bool Equals(ComponentDataWrapper other)
		{
			return instanceId == other.instanceId;
		}

		public override bool Equals(object obj)
		{
			return obj is ComponentDataWrapper other && Equals(other);
		}

		public override int GetHashCode()
		{
			return instanceId.GetHashCode();
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