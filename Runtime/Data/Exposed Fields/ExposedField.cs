using System;

namespace Hertzole.ALE
{
    public class ExposedField
    {
        public string Name { get; }
        public int ID { get; }
        public bool IsVisible { get; }
        public Type Type { get; }
        public string CustomName { get; }

        public ExposedField(int id, Type type, string name, string customName, bool isVisible)
        {
            Name = name;
            ID = id;
            IsVisible = isVisible;
            Type = type;
            CustomName = customName;
        }
    }
}
