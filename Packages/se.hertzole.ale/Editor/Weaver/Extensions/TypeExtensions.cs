using Mono.Cecil;
using System;

namespace Hertzole.ALE.Editor
{
    public static partial class WeaverExtensions
    {
        // https://github.com/vis2k/Mirror/blob/master/Assets/Mirror/Editor/Weaver/Extensions.cs#L10
        public static bool Is(this TypeReference tr, Type t)
        {
            if (t.IsGenericType)
            {
                return tr.GetElementType().FullName == t.FullName;
            }
            else
            {
                return tr.FullName == t.FullName;
            }
        }

        public static bool Is<T>(this TypeReference tr)
        {
            return Is(tr, typeof(T));
        }

        // https://github.com/vis2k/Mirror/blob/master/Assets/Mirror/Editor/Weaver/Extensions.cs#L23
        public static bool IsSubclassOf(this TypeDefinition td, Type type)
        {
            if (!td.IsClass)
            {
                return false;
            }

            TypeReference parent = td.BaseType;

            if (parent == null)
            {
                return false;
            }

            if (parent.Is(type))
            {
                return true;
            }

            if (parent.CanBeResolved())
            {
                return IsSubclassOf(parent.Resolve(), type);
            }

            return false;
        }

        public static bool IsSubclassOf<T>(this TypeDefinition td)
        {
            return IsSubclassOf(td, typeof(T));
        }

        // https://github.com/vis2k/Mirror/blob/master/Assets/Mirror/Editor/Weaver/Extensions.cs#L87
        public static bool CanBeResolved(this TypeReference parent)
        {
            while (parent != null)
            {
                if (parent.Scope.Name == "Windows")
                {
                    return false;
                }

                if (parent.Scope.Name == "mscorlib")
                {
                    TypeDefinition resolved = parent.Resolve();
                    return resolved != null;
                }

                try
                {
                    parent = parent.Resolve().BaseType;
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public static PropertyDefinition GetProperty(this TypeDefinition type, string property)
        {
            if (!type.HasProperties)
            {
                return null;
            }

            for (int i = 0; i < type.Properties.Count; i++)
            {
                if (type.Properties[i].Name == property)
                {
                    return type.Properties[i];
                }
            }

            return null;
        }

        public static FieldDefinition GetField(this TypeDefinition type, string field)
        {
            if (!type.HasFields)
            {
                throw new NullReferenceException("There are no fields on " + type.FullName);
            }

            for (int i = 0; i < type.Fields.Count; i++)
            {
                if (type.Fields[i].Name == field)
                {
                    return type.Fields[i];
                }
            }

            throw new ArgumentException("There's no field called " + field + " on " + type.FullName);
        }

        public static bool TryGetField(this TypeDefinition type, string fieldName, out FieldDefinition field)
        {
            if (!type.HasFields)
            {
                field = null;
                return false;
            }

            for (int i = 0; i < type.Fields.Count; i++)
            {
                if (type.Fields[i].Name == fieldName)
                {
                    field = type.Fields[i];
                    return true;
                }
            }

            field = null;
            return false;
        }

        public static bool ImplementsInterface(this TypeDefinition type, InterfaceImplementation baseInterface)
        {
            if (!type.HasInterfaces)
            {
                return false;
            }

            for (int i = 0; i < type.Interfaces.Count; i++)
            {
                if (type.Interfaces[i].InterfaceType.FullName == baseInterface.InterfaceType.FullName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
