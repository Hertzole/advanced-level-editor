using Mono.Cecil;
using Mono.Cecil.Cil;
using System;

namespace Hertzole.ALE.Editor
{
    public static partial class WeaverExtensions
    {
        public static MethodDefinition Duplicate(this MethodDefinition m)
        {
            MethodDefinition method = new MethodDefinition(m.Name, m.Attributes, m.ReturnType);
            if (m.HasParameters)
            {
                for (int i = 0; i < m.Parameters.Count; i++)
                {
                    method.Parameters.Add(new ParameterDefinition(m.Parameters[i].Name, m.Parameters[i].Attributes, m.Parameters[i].ParameterType));
                }
            }
            if (m.HasBody)
            {
                for (int i = 0; i < m.Body.Instructions.Count; i++)
                {
                    method.Body.Instructions.Add(m.Body.Instructions[i].Duplicate());
                }
            }

            return method;
        }

        public static Instruction Duplicate(this Instruction i)
        {
            if (i.Operand is byte b)
            {
                return Instruction.Create(i.OpCode, b);
            }
            else if (i.Operand is CallSite callSite)
            {
                return Instruction.Create(i.OpCode, callSite);
            }
            else if (i.Operand is double d)
            {
                return Instruction.Create(i.OpCode, d);
            }
            else if (i.Operand is TypeReference type)
            {
                return Instruction.Create(i.OpCode, type);
            }
            else if (i.Operand is MethodReference method)
            {
                return Instruction.Create(i.OpCode, method);
            }
            else if (i.Operand is FieldReference field)
            {
                return Instruction.Create(i.OpCode, field);
            }
            else if (i.Operand is string s)
            {
                return Instruction.Create(i.OpCode, s);
            }
            else if (i.Operand is sbyte sb)
            {
                return Instruction.Create(i.OpCode, sb);
            }
            else if (i.Operand is int _i)
            {
                return Instruction.Create(i.OpCode, _i);
            }
            else if (i.Operand is long l)
            {
                return Instruction.Create(i.OpCode, l);
            }
            else if (i.Operand is float f)
            {
                return Instruction.Create(i.OpCode, f);
            }
            else if (i.Operand is Instruction target)
            {
                return Instruction.Create(i.OpCode, target);
            }
            else if (i.Operand is Instruction[] targets)
            {
                return Instruction.Create(i.OpCode, targets);
            }
            else if (i.Operand is VariableDefinition variable)
            {
                return Instruction.Create(i.OpCode, variable);
            }
            else if (i.Operand is ParameterDefinition parameter)
            {
                return Instruction.Create(i.OpCode, parameter);
            }
            else
            {
                return Instruction.Create(i.OpCode);
            }
        }

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
