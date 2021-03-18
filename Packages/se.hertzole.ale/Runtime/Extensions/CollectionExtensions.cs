using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

        public static string ToDebugString<T>(this T[] array)
        {
            return "{" + string.Join(", ", array) + "}";
        }

        public static string ToDebugString<T>(this IList<T> list)
        {
            return "{" + string.Join(", ", list) + "}";
        }

        public static bool DictionaryEquals(this IDictionary a, IDictionary b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            //Array aKeys = Array.CreateInstance(typeof(object), a.Count);
            object[] aKeys = new object[a.Count];
            object[] bKeys = new object[a.Count];

            a.Keys.CopyTo(aKeys, 0);
            b.Keys.CopyTo(bKeys, 0);

            for (int i = 0; i < aKeys.Length; i++)
            {
                if (!aKeys[i].Equals(bKeys[i]))
                {
                    return false;
                }
            }

            object[] aValues = new object[a.Count];
            object[] bValues = new object[a.Count];

            a.Values.CopyTo(aValues, 0);
            b.Values.CopyTo(bValues, 0);

            for (int i = 0; i < aValues.Length; i++)
            {
                if (!aValues[i].Equals(bValues[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ListEquals(this IList a, IList b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsSameAs(this ICollection a, ICollection b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            if (a is IDictionary da && b is IDictionary db)
            {
                return da.DictionaryEquals(db);
            }

            if (a is IList al && b is IList bl)
            {
                return ListEquals(al, bl);
            }

            if (a is Array aa && b is Array ba)
            {
                return ListEquals(aa, ba);
            }

            Debug.LogError("Couldn't match the collection " + a.GetType());

            return false;
        }
    }
}
