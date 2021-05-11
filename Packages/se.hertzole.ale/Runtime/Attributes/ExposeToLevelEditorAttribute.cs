using System;

namespace Hertzole.ALE
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ExposeToLevelEditorAttribute : Attribute
    {
        public int ID { get; }

        public string customName;
        public int order;
        public bool visible;

        public ExposeToLevelEditorAttribute(int id)
        {
            ID = id;
        }
    }
}
