using System;

namespace Hertzole.ALE
{
    public class ExposedArray : ExposedProperty
    {
        public Type ElementType { get; private set; }

        public ExposedArray(int id, Type type, string name, string customName, bool isVisible, Type elementType) : base(id, type, name, customName, isVisible)
        {
            ElementType = elementType;
        }
    }
}
