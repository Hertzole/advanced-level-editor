using Mono.Cecil;
using System;

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
    }
}
