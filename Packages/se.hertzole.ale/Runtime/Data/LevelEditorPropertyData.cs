using System;
using UnityEngine;

namespace Hertzole.ALE
{
    //TODO: IEquatable
    public struct LevelEditorPropertyData
    {
        public int id;
        public string typeName;
        public object value;
        public Type type;
        public bool isArray;

        public LevelEditorPropertyData(ExposedProperty property, IExposedToLevelEditor exposedComponent)
        {
            id = property.ID;
            value = exposedComponent.GetValue(property.ID);
            type = property.Type;
            isArray = property.IsArray;
            // Used for Unity references. They need to be converted to a simple component.
            typeName = type.IsSubclassOf(typeof(Component)) ? typeof(Component).FullName : property.Type.FullName;
        }
    }
}
