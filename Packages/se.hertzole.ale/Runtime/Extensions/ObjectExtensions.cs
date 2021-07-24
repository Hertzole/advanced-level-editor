using System.Collections;
using UnityEngine;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            if (!go.TryGetComponent(out T comp))
            {
                comp = go.AddComponent<T>();
            }

            return comp;
        }

        public static void AddComponentIfNull<T>(this GameObject go) where T : Component
        {
            if (!go.TryGetComponent<T>(out _))
            {
                go.AddComponent<T>();
            }
        }

        public static T NeedComponent<T>(this GameObject go) where T : class
        {
            if (go.TryGetComponent<T>(out T result))
            {
                return result;
            }
            else
            {
                Debug.LogError($"'{go.name}' needs to have '{typeof(T).Name}' attached.");
                return null;
            }
        }

        public static bool AdvancedEquals(this object a, object b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null)
            {
                return false;
            }

            if (a.Equals(b))
            {
                return true;
            }

            if (a is ICollection ac && b is ICollection bc && ac.IsSameAs(bc))
            {
                return true;
            }

            return false;
        }
    }
}
