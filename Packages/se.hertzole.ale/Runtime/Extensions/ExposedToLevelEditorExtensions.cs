using System.Collections;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static bool ClassEquals<T>(this IExposedToLevelEditor exposed, object value, T existing, out T returnValue) where T : class
        {
            if (value == null && existing != null)
            {
                returnValue = default;
                return false;
            }

            if (value is UnityEngine.Object unityObj && existing is UnityEngine.Object eUnity && unityObj != eUnity)
            {
                returnValue = (T)value;
                return false;
            }

            if (value is T val && !val.Equals(existing))
            {
                returnValue = (T)value;
                return false;
            }

            returnValue = default;
            return true;
        }

        public static bool CollectionEquals<T>(this IExposedToLevelEditor exposed, object value, T existing, out T returnValue) where T : ICollection
        {
            if (value == null && existing != null)
            {
                returnValue = default;
                return false;
            }

            if (value is T a && !a.IsSameAs(existing))
            {
                returnValue = a;
                return false;
            }

            returnValue = default;
            return true;
        }
    }
}
