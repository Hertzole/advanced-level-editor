using System;
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

        [Obsolete("Use 'RequireTypeAttribute' and 'NeedComponent<T>' instead.")]
        public static bool ExistsAndHasComponent<T>(this GameObject go, string propertyName, GameObject myGameObject, bool mustExist = true)
        {
            if (go == null)
            {
                if (mustExist)
                {
                    Debug.LogError($"Field {propertyName} on {myGameObject.name} needs to be assigned.", myGameObject);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (go.GetComponent<T>() == null)
            {
                Debug.LogError($"Field {propertyName} on {go.name} needs to have a script attached that implements {typeof(T).Name}.", go);
                return false;
            }

            return true;
        }

        public static bool ExistsAndImplements<T>(this ScriptableObject obj, string propertyName, MonoBehaviour myBehaviour, bool mustExist = true)
        {
            if (obj == null)
            {
                if (mustExist)
                {
                    Debug.LogError($"Field {propertyName} on {myBehaviour.gameObject.name} needs to be assigned.", myBehaviour.gameObject);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (!(obj is T))
            {
                Debug.LogError($"{obj.name} needs to implement {typeof(T).Name} in order to be used in {myBehaviour.GetType().Name} ({myBehaviour.gameObject.name}).");
                return false;
            }

            return true;
        }

        public static bool IfElse<T>(this T t, Func<T, bool> exists, Func<bool> isNull)
        {
            if (t == null)
            {
                return isNull.Invoke();
            }
            else
            {
                return exists.Invoke(t);
            }
        }

        public static void IfExists<T>(this T t, Action<T> exists)
        {
            if (t != null)
            {
                exists?.Invoke(t);
            }
        }
    }
}
