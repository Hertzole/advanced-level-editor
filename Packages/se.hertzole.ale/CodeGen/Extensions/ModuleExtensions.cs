using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace Hertzole.ALE.CodeGen
{
	public static partial class WeaverExtensions
	{
		private class CachedMethodsComparer : IEqualityComparer<(Type type, string methodName)>
		{
			public bool Equals((Type type, string methodName) x, (Type type, string methodName) y)
			{
				if (x.methodName != y.methodName)
				{
					return false;
				}

				if (x.type != y.type)
				{
					return false;
				}

				return true;
			}

			public int GetHashCode((Type type, string methodName) obj)
			{
				unchecked
				{
					return (obj.type.GetHashCode() * 397) ^ obj.methodName.GetHashCode();
				}
			}
		}
		
		private class CachedParametersMethodsComparer : IEqualityComparer<(Type type, string methodName, Type[] parameters)>
		{
			public bool Equals((Type type, string methodName, Type[] parameters) x, (Type type, string methodName, Type[] parameters) y)
			{
				if (x.methodName != y.methodName)
				{
					return false;
				}

				if (x.type != y.type)
				{
					return false;
				}

				if (x.parameters.Length != y.parameters.Length)
				{
					return false;
				}

				return x.parameters.IsSameAs(y.parameters);
			}

			public int GetHashCode((Type type, string methodName, Type[] parameters) obj)
			{
				unchecked
				{
					int hashCode = obj.Item1.GetHashCode();
					hashCode = (hashCode * 397) ^ obj.Item2.GetHashCode();
					hashCode = (hashCode * 397) ^ obj.Item3.GetHashCode();
					return hashCode;
				}
			}
		}

		public static TypeReference GetTypeReference<T>(this ModuleDefinition module)
		{
			return module.ImportReference(typeof(T));
		}

		public static TypeReference GetTypeReference(this ModuleDefinition module, Type type)
		{
			return module.ImportReference(type);
		}

		public static TypeReference Void(this ModuleDefinition module)
		{
			return module.ImportReference(typeof(void));
		}

		public static MethodReference GetMethod<T>(this ModuleDefinition module, string methodName)
		{
			return module.GetMethod(typeof(T), methodName);
		}

		public static MethodReference GetMethod(this ModuleDefinition module, Type type, string methodName)
		{
			try
			{
				MethodInfo method = type.GetMethod(methodName);
				if (method == null)
				{
					throw new ArgumentException($"There's no method called '{methodName}' in type '{type}'");
				}

				MethodReference result = module.ImportReference(method);

				return result;
			}
			catch (AmbiguousMatchException)
			{
				throw new AmbiguousMatchException($"There's multiple methods called {methodName} in type {type}.");
			}
		}

		public static MethodReference GetMethod<T>(this ModuleDefinition module, string methodName, params Type[] parameters)
		{
			return module.GetMethod(typeof(T), methodName, parameters);
		}

		public static MethodReference GetMethod(this ModuleDefinition module, Type type, string methodName, params Type[] parameters)
		{
			MethodInfo method = type.GetMethod(methodName, parameters);
			if (method == null)
			{
				throw new ArgumentException($"There's no method called {methodName} in {type}.");
			}

			MethodReference result = module.ImportReference(method);

			return result;
		}

		public static MethodReference GetGenericMethod(this ModuleDefinition module, Type type, string methodName, Type[] parameters, params TypeReference[] genericParameters)
		{
			MethodInfo[] methods = type.GetMethods();
			MethodInfo resultMethod = null;
			for (int i = 0; i < methods.Length; i++)
			{
				if (methods[i].Name == methodName && methods[i].IsGenericMethod && parameters.Length == methods[i].GetParameters().Length - methods[i].GetGenericArguments().Length)
				{
					resultMethod = methods[i];
					break;
				}
			}

			if (resultMethod == null)
			{
				throw new ArgumentException($"There's no method called {methodName} in {type.FullName}.", nameof(methodName));
			}

			return module.ImportReference(module.ImportReference(resultMethod).MakeGenericMethod(genericParameters));
		}

		public static MethodReference GetGenericMethod(this ModuleDefinition module, Type type, string methodName, params TypeReference[] genericParameters)
		{
			MethodInfo[] methods = type.GetMethods();
			MethodInfo resultMethod = null;
			for (int i = 0; i < methods.Length; i++)
			{
				if (methods[i].Name == methodName && methods[i].IsGenericMethod)
				{
					resultMethod = methods[i];
					break;
				}
			}

			if (resultMethod == null)
			{
				throw new ArgumentException($"There's no method called {methodName} in {type.FullName}.", nameof(methodName));
			}

			return module.ImportReference(module.ImportReference(resultMethod).MakeGenericMethod(genericParameters));
		}

		public static MethodReference GetConstructor<T>(this ModuleDefinition module, params Type[] parameters)
		{
			return module.GetConstructor(typeof(T), parameters);
		}

		public static MethodReference GetConstructor(this ModuleDefinition module, Type type, params Type[] parameters)
		{
			MethodReference result = module.ImportReference(type.GetConstructor(parameters));

			if (result == null)
			{
				throw new ArgumentException($"There's no constructor with those parameters in type {type.FullName}");
			}
			
			return result;
		}

		public static MethodReference GetGenericConstructor(this ModuleDefinition module, Type type, params TypeReference[] genericParameters)
		{
			return module.GetConstructor(type).MakeHostInstanceGeneric(module.GetTypeReference(type).MakeGenericInstanceType(genericParameters));
		}
	}
}