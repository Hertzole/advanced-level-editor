﻿using System;
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
            return $"[{dictionary.Count}] {{{string.Join(", ", dictionary.Select(kv => $"{kv.Key}: {kv.Value}"))}}}";
        }

        public static string ToDebugString<T>(this IEnumerable<T> array)
        {
            T[] a = array as T[] ?? array.ToArray();
            return $"[{a.Length}] {{{string.Join(", ", a)}}}";
        }

        public static string ToDebugString<T>(this ReadOnlySpan<T> span)
        {
            return $"[{span.Length}] {{{string.Join(", ", span.ToArray())}}}";
        }

        public static T[] ToArrayFast<T>(this IReadOnlyList<T> collection)
        {
            if (collection == null)
            {
                return null;
            }

            if (collection.Count == 0)
            {
                return Array.Empty<T>();
            }
            
            T[] array = new T[collection.Count];
            for (int i = 0; i < collection.Count; i++)
            {
                array[i] = collection[i];
            }

            return array;
        }

        public static bool DictionaryEquals(this IDictionary a, IDictionary b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

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

        public static bool DictionaryEquals(this IDictionary a, IDictionary b, IEqualityComparer equalityComparer)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            object[] aKeys = new object[a.Count];
            object[] bKeys = new object[a.Count];

            a.Keys.CopyTo(aKeys, 0);
            b.Keys.CopyTo(bKeys, 0);

            for (int i = 0; i < aKeys.Length; i++)
            {
                if (!equalityComparer.Equals(aKeys[i], bKeys[i]))
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
                if (!equalityComparer.Equals(aValues[i], aValues[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool DictionaryEquals<TValue, TKey>(this IDictionary<TKey, TValue> a, IDictionary<TKey, TValue> b, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            TKey[] aKeys = new TKey[a.Count];
            TKey[] bKeys = new TKey[a.Count];

            a.Keys.CopyTo(aKeys, 0);
            b.Keys.CopyTo(bKeys, 0);

            for (int i = 0; i < aKeys.Length; i++)
            {
                if (!keyComparer.Equals(aKeys[i], bKeys[i]))
                {
                    return false;
                }
            }

            TValue[] aValues = new TValue[a.Count];
            TValue[] bValues = new TValue[a.Count];

            a.Values.CopyTo(aValues, 0);
            b.Values.CopyTo(bValues, 0);

            for (int i = 0; i < aValues.Length; i++)
            {
                if (!valueComparer.Equals(aValues[i], aValues[i]))
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

            if (a == null || b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == null && b[i] == null)
                {
                    continue;
                }

                if (a[i] == null && b[i] != null)
                {
                    return false;
                }
                
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ListEquals(this IList a, IList b, IEqualityComparer equalityComparer)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }

            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                Debug.Log($"{a[i]} == {b[i]}");
                
                if (a[i] == null && b[i] == null)
                {
                    continue;
                }

                if (a[i] == null || b[i] == null)
                {
                    Debug.Log("One item is null");
                    return false;
                }

                if (!equalityComparer.Equals(a[i], b[i]))
                {
                    Debug.Log("Equality said no");
                    return false;
                }
            }

            return true;
        }

        public static bool ListEquals<T>(this IList<T> a, IList<T> b, IEqualityComparer<T> equalityComparer)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                Debug.Log("One is null");
                return false;
            }

            if (a.Count != b.Count)
            {
                Debug.Log("Not good count");
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == null && b[i] == null)
                {
                    continue;
                }

                if (a[i] == null || b[i] == null)
                {
                    Debug.Log("One item is null");
                    return false;
                }

                if (!equalityComparer.Equals(a[i], b[i]))
                {
                    Debug.Log("Equality comparer said no");
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

            if (a == null || b == null)
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

            Debug.LogError("Couldn't match the collection " + a.GetType());

            return false;
        }

        public static bool IsSameAs(this ICollection a, ICollection b, IEqualityComparer equalityComparer)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                Debug.Log("One is null");
                return false;
            }

            if (a.Count != b.Count)
            {
                Debug.Log("Bad count");
                return false;
            }

            if (a is IDictionary da && b is IDictionary db)
            {
                return da.DictionaryEquals(db, equalityComparer);
            }

            if (a is IList al && b is IList bl)
            {
                return ListEquals(al, bl, equalityComparer);
            }

            Debug.LogError("Couldn't match the collection " + a.GetType());

            return false;
        }

        public static bool IsSameAs<T>(this ICollection<T> a, ICollection<T> b, IEqualityComparer<T> equalityComparer)
        {
            if (a == null && b == null)
            {
                Debug.Log("Both are null");
                return true;
            }
            
            if (a == null || b == null)
            {
                Debug.Log("One is null");
                return false;
            }
            
            if (a.Count != b.Count)
            {
                Debug.Log("Count does not match.");
                return false;
            }

            if (a is IList<T> al && b is IList<T> bl)
            {
                return ListEquals(al, bl, equalityComparer);
            }

            Debug.LogError("Couldn't match the collection " + a.GetType());

            return false;
        }
    }
}
