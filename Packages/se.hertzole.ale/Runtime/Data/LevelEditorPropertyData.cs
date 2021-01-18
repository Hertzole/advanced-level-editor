using System;
using UnityEngine;

namespace Hertzole.ALE
{
    //TODO: IEquatable
    public struct LevelEditorPropertyData
    {
        public string name;
        public string typeName;
        public object value;
        public Type type;
        public bool isArray;

        public LevelEditorPropertyData(ExposedProperty property, IExposedToLevelEditor exposedComponent)
        {
            name = property.name;
            value = exposedComponent.GetValue(property.name);
            type = property.type;
            isArray = property.isArray;
            // Used for Unity references. They need to be converted to a simple component.
            typeName = type.IsSubclassOf(typeof(Component)) ? typeof(Component).FullName : property.type.FullName;
        }
    }
}
