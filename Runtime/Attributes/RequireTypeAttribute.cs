using System;
using UnityEngine;

namespace Hertzole.ALE
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class RequireTypeAttribute : PropertyAttribute
    {
        public Type Type { get; private set; }

        public RequireTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
