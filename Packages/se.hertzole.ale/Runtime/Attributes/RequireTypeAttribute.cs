using System;
using UnityEngine;

namespace Hertzole.ALE
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class RequireTypeAttribute : PropertyAttribute
    {
        public Type Type { get; }

        public RequireTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
