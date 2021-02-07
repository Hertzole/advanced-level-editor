using System;

namespace Hertzole.ALE
{
    public class ExposedEnum : ExposedProperty
    {
        public ExposedEnum(int id, Type type, string name, string customName, bool isVisible, bool isArray) : base(id, type, name, customName, isVisible, isArray)
        {
        }
    }
}
