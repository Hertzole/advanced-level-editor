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
    }
}
