using Mono.Cecil;
using System;

namespace Hertzole.ALE.Editor
{
    public static partial class WeaverExtensions
    {
        public static bool HasMethod(this TypeDefinition type, string methodName, params Type[] parameterTypes)
        {
            if (type.HasMethods)
            {
                return false;
            }

            for (int i = 0; i < type.Methods.Count; i++)
            {
                if (type.Methods[i].Name == methodName && type.Methods[i].Parameters.Count == parameterTypes.Length)
                {
                    bool validParameters = false;
                    for (int ii = 0; ii < type.Methods[i].Parameters.Count; ii++)
                    {
                        if (type.Methods[i].Parameters[ii].ParameterType.Is(parameterTypes[ii]))
                        {
                            validParameters = true;
                            break;
                        }
                    }

                    if (validParameters)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool TryGetMethod(this TypeDefinition type, string methodName, out MethodDefinition method)
        {
            method = null;
            if (!type.HasMethods)
            {
                return false;
            }

            for (int i = 0; i < type.Methods.Count; i++)
            {
                if (type.Methods[i].Name == methodName)
                {
                    method = type.Methods[i];
                    return true;
                }
            }

            return false;
        }

        public static bool TryGetMethodInBaseType(this TypeDefinition type, string methodName, out MethodDefinition method)
        {
            method = null;
            TypeDefinition typedef = type;
            while (typedef != null)
            {
                for (int i = 0; i < typedef.Methods.Count; i++)
                {
                    if (typedef.Methods[i].Name == methodName)
                    {
                        method = typedef.Methods[i];
                        return true;
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

            return false;
        }

        public static MethodDefinition GetMethod(this TypeDefinition type, string method, params Type[] parameters)
        {
            if (!type.HasMethods)
            {
                throw new NullReferenceException("There's no methods in " + type.FullName);
            }

            for (int i = 0; i < type.Methods.Count; i++)
            {
                if (type.Methods[i].Name == method && type.Methods[i].Parameters.Count == parameters.Length)
                {
                    bool validParameters = false;
                    for (int ii = 0; ii < type.Methods[i].Parameters.Count; ii++)
                    {
                        if (type.Methods[i].Parameters[ii].ParameterType.Is(parameters[ii]))
                        {
                            validParameters = true;
                            break;
                        }
                    }

                    if (validParameters)
                    {
                        return type.Methods[i];
                    }
                }
            }

            throw new ArgumentException("There's no method called " + method + " in " + type.FullName + " with those parameters.");
        }

        public static MethodDefinition GetMethod(this TypeDefinition type, string method, params TypeReference[] parameters)
        {
            if (!type.HasMethods)
            {
                throw new NullReferenceException("There's no methods in " + type.FullName);
            }

            for (int i = 0; i < type.Methods.Count; i++)
            {
                if (type.Methods[i].Name == method && type.Methods[i].Parameters.Count == parameters.Length)
                {
                    bool validParameters = true;
                    for (int ii = 0; ii < type.Methods[i].Parameters.Count; ii++)
                    {
                        if (type.Methods[i].Parameters[ii].ParameterType.FullName != parameters[ii].FullName)
                        {
                            validParameters = false;
                            break;
                        }
                    }

                    if (validParameters)
                    {
                        return type.Methods[i];
                    }
                }
            }

            throw new ArgumentException("There's no method called " + method + " in " + type.FullName + " with those parameters.");
        }

        public static MethodDefinition GetConstructor(this TypeDefinition type, params TypeReference[] parameters)
        {
            return type.GetMethod(".ctor", parameters);
        }

        public static MethodDefinition GetMethodInBaseType(this TypeDefinition type, string method)
        {
            TypeDefinition typedef = type;
            while (typedef != null)
            {
                for (int i = 0; i < typedef.Methods.Count; i++)
                {
                    if (typedef.Methods[i].Name == method)
                    {
                        return typedef.Methods[i];
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

            throw new ArgumentException($"There's no method called {method} in {type.FullName} or its base types.");
        }

        // Shamefully stolen from https://github.com/MirrorNG/MirrorNG/blob/master/Assets/Mirror/Weaver/Extensions.cs#L159
        /// <summary>
        /// Given a method of a generic class such as ArraySegment`T.get_Count,
        /// and a generic instance such as ArraySegment`int
        /// Creates a reference to the specialized method  ArraySegment`int`.get_Count
        /// <para> Note that calling ArraySegment`T.get_Count directly gives an invalid IL error </para>
        /// </summary>
        /// <param name="self"></param>
        /// <param name="instanceType"></param>
        /// <returns></returns>
        public static MethodReference MakeHostInstanceGeneric(this MethodReference self, GenericInstanceType instanceType)
        {
            MethodReference reference = new MethodReference(self.Name, self.ReturnType, instanceType)
            {
                CallingConvention = self.CallingConvention,
                HasThis = self.HasThis,
                ExplicitThis = self.ExplicitThis
            };

            foreach (ParameterDefinition parameter in self.Parameters)
            {
                reference.Parameters.Add(new ParameterDefinition(parameter.ParameterType));
            }

            foreach (GenericParameter generic_parameter in self.GenericParameters)
            {
                reference.GenericParameters.Add(new GenericParameter(generic_parameter.Name, reference));
            }

            return self.Module.ImportReference(reference);
        }
    }
}
