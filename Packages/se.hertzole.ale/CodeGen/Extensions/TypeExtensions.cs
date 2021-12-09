using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using UnityEngine;
using FieldAttributes = Mono.Cecil.FieldAttributes;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using Object = UnityEngine.Object;
using PropertyAttributes = Mono.Cecil.PropertyAttributes;
using TypeAttributes = Mono.Cecil.TypeAttributes;

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

			return tr.FullName == t.FullName;
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

		public static void GetParents(this TypeDefinition type, IList<TypeDefinition> parentsList, Predicate<TypeDefinition> predicate = null)
		{
			parentsList.Clear();
			
			// Go until we hit a null base type.
			TypeReference baseType = type.BaseType;
			while (baseType != null)
			{
				// Stop if it basically doesn't exist.
				if (!baseType.CanBeResolved())
				{
					break;
				}

				// Check if it's a valid type and doesn't implement IGetComponent.
				TypeDefinition resolved = baseType.Resolve();
				if (predicate != null)
				{
					if (predicate(resolved))
					{
						parentsList.Add(resolved);
					}
				}
				else
				{
					parentsList.Add(resolved);
				}

				// Go to the next base type.
				baseType = resolved.BaseType;
			}
		}

		public static bool TryResolve(this TypeReference td, out TypeDefinition type)
		{
			if (td.CanBeResolved())
			{
				type = td.Resolve();
				return true;
			}

			type = null;
			return false;
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
				return type.Module.ImportReference(resolved);
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
				throw new NullReferenceException($"There are no properties in type '{type.FullName}'.");
			}

			for (int i = 0; i < type.Properties.Count; i++)
			{
				if (type.Properties[i].Name == property)
				{
					return type.Properties[i];
				}
			}

			throw new ArgumentException($"There's no property called '{property}' in type '{type.FullName}'.");
		}

		public static FieldDefinition GetField(this TypeDefinition type, string field)
		{
			if (!type.HasFields)
			{
				throw new NullReferenceException($"There are no fields in type '{type.FullName}'");
			}

			for (int i = 0; i < type.Fields.Count; i++)
			{
				if (type.Fields[i].Name == field)
				{
					return type.Fields[i];
				}
			}

			throw new ArgumentException($"There's no field called '{field}' in type '{type.FullName}'.");
		}

		public static FieldDefinition GetFieldInBaseType(this TypeDefinition type, string field)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}
			
			TypeDefinition typedef = type;
			while (typedef != null)
			{
				for (int i = 0; i < typedef.Fields.Count; i++)
				{
					if (typedef.Fields[i].Name == field)
					{
						return typedef.Fields[i];
					}
				}

				try
				{
					TypeReference parent = typedef.BaseType;
					typedef = parent?.Resolve();
				}
				catch (AssemblyResolutionException)
				{
					break;
				}
			}

			throw new ArgumentException($"There's no field called {field} in {type.FullName} or its base types.");
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

		public static FieldDefinition AddField<T>(this TypeDefinition type, string name, FieldAttributes attributes)
		{
			return type.AddField(name, attributes, type.Module.GetTypeReference<T>());
		}

		public static FieldDefinition AddField(this TypeDefinition type, string name, FieldAttributes attributes, TypeReference fieldType)
		{
			FieldDefinition field = new FieldDefinition(name, attributes, fieldType);
			type.Fields.Add(field);
			return field;
		}

		public static MethodDefinition AddMethod<T>(this TypeDefinition type, string name, MethodAttributes attributes)
		{
			return type.AddMethod(name, attributes, type.Module.ImportReference(typeof(T)));
		}

		public static MethodDefinition AddMethod(this TypeDefinition type, string name, MethodAttributes attributes)
		{
			return type.AddMethod(name, attributes, type.Module.Void());
		}

		public static MethodDefinition AddMethod(this TypeDefinition type, string name, MethodAttributes attributes, TypeReference returnType)
		{
			MethodDefinition m = new MethodDefinition(name, attributes, returnType);
			type.Methods.Add(m);

			return m;
		}

		public static MethodDefinition AddMethodOverride<T>(this TypeDefinition type, string name, MethodAttributes attributes, params MethodReference[] overrides)
		{
			return type.AddMethodOverride(name, attributes, type.Module.ImportReference(typeof(T)), overrides);
		}

		public static MethodDefinition AddMethodOverride(this TypeDefinition type, string name, MethodAttributes attributes, params MethodReference[] overrides)
		{
			return type.AddMethodOverride(name, attributes, type.Module.Void(), overrides);
		}

		public static MethodDefinition AddMethodOverride(this TypeDefinition type, string name, MethodAttributes attributes, TypeReference returnType, params MethodReference[] overrides)
		{
			MethodDefinition m = new MethodDefinition(name, attributes, returnType);
			for (int i = 0; i < overrides.Length; i++)
			{
				m.Overrides.Add(overrides[i]);
			}

			type.Methods.Add(m);

			return m;
		}

		public static PropertyDefinition AddProperty<T>(this TypeDefinition type, string name, PropertyAttributes attributes)
		{
			return type.AddProperty(name, attributes, type.Module.GetTypeReference<T>());
		}
		
		public static PropertyDefinition AddProperty(this TypeDefinition type, string name, PropertyAttributes attributes, TypeReference propertyType)
		{
			PropertyDefinition p = new PropertyDefinition(name, attributes, propertyType);
			type.Properties.Add(p);

			return p;
		}

		public static TypeDefinition AddNestedType(this TypeDefinition type, string name, TypeAttributes attributes)
		{
			TypeDefinition newType = new TypeDefinition(type.Namespace, name, attributes);
			type.NestedTypes.Add(newType);

			return newType;
		}

		public static TypeDefinition AddNestedType(this TypeDefinition type, string name, TypeAttributes attributes, TypeReference baseType)
		{
			TypeDefinition newType = new TypeDefinition(type.Namespace, name, attributes, baseType);
			type.NestedTypes.Add(newType);

			return newType;
		}

		public static InterfaceImplementation AddInterface<T>(this TypeDefinition type)
		{
			InterfaceImplementation i = new InterfaceImplementation(type.Module.ImportReference(typeof(T)));
			type.Interfaces.Add(i);
			return i;
		}

		public static FieldDefinition CreateLockObject(this TypeDefinition type)
		{
			FieldDefinition field = type.AddField<object>($"ALE__GENERATED__{type.Name}__LOCK", FieldAttributes.Private);

			MethodDefinition ctor = type.GetConstructor();
			ILProcessor il = ctor.BeginEdit();

			Instruction newObj = Instruction.Create(OpCodes.Newobj, type.Module.ImportReference(typeof(object).GetConstructor(Array.Empty<Type>())));
			Instruction setField = Instruction.Create(OpCodes.Stfld, field);

			il.InsertAfter(il.Body.Instructions[0], newObj);
			il.InsertAfter(il.Body.Instructions[1], setField);
			il.InsertAfter(il.Body.Instructions[2], Instruction.Create(OpCodes.Ldarg_0));

			ctor.EndEdit();

			return field;
		}

		public static MethodReference GetEqualsMethod(this TypeDefinition type, out bool isInequality)
		{
			isInequality = false;

			if (!type.IsValueType)
			{
				if (type.IsCollection())
				{
					return type.Module.GetMethod(typeof(LevelEditorExtensions), nameof(LevelEditorExtensions.CollectionEquals)).MakeGenericMethod(type);
				}

				return type.Module.GetMethod(typeof(LevelEditorExtensions), nameof(LevelEditorExtensions.ClassEquals)).MakeGenericMethod(type);
			}

			TypeReference fieldType = type;
			if (type.IsSubclassOf<Object>())
			{
				fieldType = type.Module.ImportReference(typeof(Object));
				isInequality = true;
				return type.GetMethodWithParameters("op_Inequality", fieldType, fieldType);
			}

			if (type.TryGetMethodInBaseTypeWithParameters("Equals", out MethodReference equalsMethod, fieldType))
			{
				isInequality = false;
				return equalsMethod;
			}

			if (type.TryGetMethodInBaseTypeWithParameters("op_Inequality", out equalsMethod, fieldType, fieldType))
			{
				isInequality = true;
				return equalsMethod;
			}

			if (type.IsValueType)
			{
				isInequality = false;
				return type.Module.GetMethod<object>("Equals", typeof(object));
			}
			
			if (type.TryGetMethodInBaseTypeWithParameters("Equals", out equalsMethod, type.Module.GetTypeReference<object>()))
			{
				isInequality = false;
				return equalsMethod;
			}

			throw new NullReferenceException($"There's no suitable Equals method inside type {type.FullName}.");
		}
	}
}