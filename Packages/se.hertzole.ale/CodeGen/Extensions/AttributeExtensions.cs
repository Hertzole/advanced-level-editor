using Mono.Cecil;
using Mono.Collections.Generic;
using System;
using System.Collections.Generic;

namespace Hertzole.ALE.CodeGen
{
    public static partial class WeaverExtensions
    {
        public static bool HasAttribute<T>(this ICustomAttributeProvider type) where T : Attribute
        {
            if (!type.HasCustomAttributes)
            {
                return false;
            }

            return HasAttribute<T>(type.CustomAttributes);
        }

        private static bool HasAttribute<T>(Collection<CustomAttribute> attributes)
        {
            string myName = typeof(T).FullName;

            for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Constructor.DeclaringType.ToString() == myName)
                {
                    return true;
                }
            }

            return false;
        }

        public static CustomAttribute GetAttribute<T>(this ICustomAttributeProvider type) where T : Attribute
        {
            if (!type.HasCustomAttributes)
            {
                //throw new NullReferenceException(type. + " does not have any attributes.");
                return null;
            }

            return GetAttribute<T>(type.CustomAttributes);
        }

        private static CustomAttribute GetAttribute<T>(Collection<CustomAttribute> attributes) where T : Attribute
        {
            string myName = typeof(T).FullName;

            for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Constructor.DeclaringType.ToString() == myName)
                {
                    return attributes[i];
                }
            }

            throw new ArgumentException("There's no " + myName + " argument on this type.");
        }

        public static bool TryGetAttribute<T>(this ICustomAttributeProvider type, out CustomAttribute attribute) where T : Attribute
        {
            if (!type.HasCustomAttributes)
            {
                attribute = null;
                return false;
            }

            return TryGetAttribute<T>(type.CustomAttributes, out attribute);
        }

        private static bool TryGetAttribute<T>(Collection<CustomAttribute> attributes, out CustomAttribute attribute) where T : Attribute
        {
            string myName = typeof(T).FullName;

            for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Constructor.DeclaringType.ToString() == myName)
                {
                    attribute = attributes[i];
                    return true;
                }
            }

            attribute = null;
            return false;
        }

        public static bool TryGetAttributes<T>(this ICustomAttributeProvider property, out CustomAttribute[] attributes) where T : Attribute
        {
            if (!property.HasCustomAttributes)
            {
                attributes = Array.Empty<CustomAttribute>();
                return false;
            }

            return TryGetAttributes<T>(property.CustomAttributes, out attributes);
        }

        private static bool TryGetAttributes<T>(Collection<CustomAttribute> attributes, out CustomAttribute[] result) where T : Attribute
        {
            string myName = typeof(T).FullName;

            List<CustomAttribute> list = new List<CustomAttribute>();

            for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Constructor.DeclaringType.ToString() == myName)
                {
                    list.Add(attributes[i]);
                }
            }

            result = list.ToArray();
            return result.Length > 0;
        }

        public static T GetField<T>(this CustomAttribute attribute, string field, T defaultValue)
        {
            if (!attribute.HasFields)
            {
                return defaultValue;
            }

            for (int i = 0; i < attribute.Fields.Count; i++)
            {
                if (attribute.Fields[i].Name == field)
                {
                    return (T)attribute.Fields[i].Argument.Value;
                }
            }

            return defaultValue;
        }

        public static T GetConstructorArgument<T>(this CustomAttribute attribute, int index, T defaultValue)
        {
            if (!attribute.HasConstructorArguments)
            {
                return defaultValue;
            }

            return (T)attribute.ConstructorArguments[index].Value;
        }
    }
}
