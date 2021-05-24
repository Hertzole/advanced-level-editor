using Mono.Cecil;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Hertzole.ALE.CodeGen
{
    public static partial class WeaverExtensions
    {
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
            return module.ImportReference(type.GetMethod(methodName));
        }

        public static MethodReference GetMethod<T>(this ModuleDefinition module, string methodName, params Type[] parameters)
        {
            return module.GetMethod(typeof(T), methodName, parameters);
        }

        public static MethodReference GetMethod(this ModuleDefinition module, Type type, string methodName, params Type[] parameters)
        {
            return module.ImportReference(type.GetMethod(methodName, parameters));
        }

        public static MethodReference GetGenericMethod(this ModuleDefinition module, Type type, string methodName, Type[] parameters, TypeReference[] genericParameters)
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

            return module.ImportReference(resultMethod).MakeGenericMethod(genericParameters);
        }

        public static MethodReference GetConstructor<T>(this ModuleDefinition module, params Type[] parameters)
        {
            return module.GetConstructor(typeof(T), parameters);
        }

        public static MethodReference GetConstructor(this ModuleDefinition module, Type type, params Type[] parameters)
        {
            return module.ImportReference(type.GetConstructor(parameters));
        }
    }
}
