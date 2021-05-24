using Mono.Cecil;
using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.CodeGen
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
        
        public static TypeReference GetCollectionType(this TypeReference type)
        {
            if (!type.IsCollection())
            {
                return type;
            }

            if (type.IsArray())
            {
                return type.Module.ImportReference(type.Resolve());
            }
            
            if (type.IsList() && type is GenericInstanceType generic && generic.GenericArguments.Count == 1)
            {
                TypeDefinition resolved = generic.GenericArguments[0].GetElementType().Resolve();
                if (resolved.Is<GameObject>() || resolved.IsSubclassOf<Component>())
                {
                    return type.Module.ImportReference(resolved);
                }
            }

            return type;
        }

        public static bool IsCollection(this TypeReference type)
        {
            return type.IsArray() || type.IsList() || type.IsDictionary();
        }

        public static bool IsArray(this TypeReference type)
        {
            return type.IsArray;
        }

        public static bool IsList(this TypeReference type)
        {
            return type.Is(typeof(List<>));
        }

        public static bool IsDictionary(this TypeReference type)
        {
            return type.Is(typeof(Dictionary<,>));
        }

        public static bool IsGameObject(this TypeReference type)
        {
            return type.GetCollectionType().Is<GameObject>();
        }

        public static bool IsComponent(this TypeReference type)
        {
            if (type.IsGameObject())
            {
                return true;
            }

            TypeDefinition resolved = type.Resolve();
            if (resolved != null && resolved.IsSubclassOf<Component>())
            {
                return true;
            }

            if (type.IsList() && type is GenericInstanceType generic && generic.GenericArguments.Count == 1)
            {
                resolved = generic.GenericArguments[0].GetElementType().Resolve();
                if (resolved.Is<GameObject>() || resolved.IsSubclassOf<Component>())
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsEnum(this TypeReference type)
        {
            TypeDefinition resolved = type.Resolve();
            if (resolved == null)
            {
                return false;
            }

            return resolved.IsEnum || resolved.Is<Enum>() || resolved.IsSubclassOf<Enum>();
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

        public static bool ImplementsInterface<T>(this TypeDefinition type)
        {
            if (!type.HasInterfaces)
            {
                return false;
            }

            for (int i = 0; i < type.Interfaces.Count; i++)
            {
                if (type.Interfaces[i].InterfaceType.FullName == typeof(T).FullName)
                {
                    return true;
                }
            }

            return false;
        }

        public static TypeReference GetNestedType<T>(this TypeDefinition type)
        {
            return type.GetNestedType(typeof(T));
        }

        public static TypeReference GetNestedType(this TypeDefinition t, Type type)
        {
            if (!t.HasNestedTypes)
            {
                return null;
            }

            for (int i = 0; i < t.NestedTypes.Count; i++)
            {
                if (t.NestedTypes[i].FullName == type.FullName)
                {
                    return t.NestedTypes[i];
                }
            }

            return null;
        }

        public static MethodDefinition CreateConstructor(this TypeDefinition type)
        {
            if (type.IsValueType)
            {
                throw new NotSupportedException($"Can't add a constructor to {type.FullName} because it's a value type.");
            }
            
            MethodDefinition m = new MethodDefinition(".ctor",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
                type.Module.Void());

            type.Methods.Add(m);

            ILProcessor il = m.Body.GetILProcessor();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, type.Module.GetConstructor<object>());
            il.Emit(OpCodes.Ret);
				
            m.Body.Optimize();

            return m;
        }
    }
}
