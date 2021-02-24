using System.Collections.Generic;
using System.Linq;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static Dictionary<TValue, TKey> Invert<TKey, TValue>(this Dictionary<TKey, TValue> x)
        {
            Dictionary<TValue, TKey> inverted = new Dictionary<TValue, TKey>();
            foreach (KeyValuePair<TKey, TValue> i in x)
            {
                inverted.Add(i.Value, i.Key);
            }

            return inverted;
        }

        // https://stackoverflow.com/a/5899291
        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key + ": " + kv.Value).ToArray()) + "}";
        }

        public static bool DictionaryEquals<TKey, TValue>(this IDictionary<TKey, TValue> a, IDictionary<TKey, TValue> b)
        {
            if (b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            TKey[] aKeys = a.Keys.ToArray();
            TKey[] bKeys = b.Keys.ToArray();
            for (int i = 0; i < aKeys.Length; i++)
            {
                if (!aKeys[i].Equals(bKeys[i]))
                {
                    return false;
                }
            }

            TValue[] aValues = a.Values.ToArray();
            TValue[] bValues = b.Values.ToArray();
            for (int i = 0; i < aValues.Length; i++)
            {
                if (!aValues[i].Equals(bValues[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
