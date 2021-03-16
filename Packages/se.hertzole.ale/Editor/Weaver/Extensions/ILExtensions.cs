using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using System.Collections.Generic;
using System.Linq;

namespace Hertzole.ALE.Editor
{
    public static partial class WeaverExtensions
    {
        public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                collection.Add(item);
            }
        }

        public static void InsertAfter(this ILProcessor il, Instruction target, IEnumerable<Instruction> instructions)
        {
            Instruction previous = target;

            foreach (Instruction i in instructions)
            {
                il.InsertAfter(previous, i);
                previous = i;
            }
        }

        public static void InsertBefore(this ILProcessor il, Instruction target, IEnumerable<Instruction> instructions)
        {
            Instruction previous = target;

            Instruction[] a = instructions.ToArray();

            for (int i = a.Length - 1; i >= 0; i--)
            {
                il.InsertBefore(previous, a[i]);
                previous = a[i];
            }
        }

        public static void Append(this ILProcessor il, IEnumerable<Instruction> instructions)
        {
            foreach (Instruction i in instructions)
            {
                il.Append(i);
            }
        }
    }
}
