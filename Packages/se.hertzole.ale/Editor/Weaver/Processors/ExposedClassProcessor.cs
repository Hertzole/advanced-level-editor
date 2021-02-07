using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using EventAttributes = Mono.Cecil.EventAttributes;
using FieldAttributes = Mono.Cecil.FieldAttributes;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using ParameterAttributes = Mono.Cecil.ParameterAttributes;
using PropertyAttributes = Mono.Cecil.PropertyAttributes;

namespace Hertzole.ALE.Editor
{
    public class ExposedClassProcessor : BaseProcessor
    {
        internal struct FieldOrProperty
        {
            public FieldDefinition field;
            public PropertyDefinition property;

            public string customName;
            public bool visible;
            public int order;
            public int id;

            public string Name { get { if (field != null) { return field.Name; } else { return property.Name; } } }
            public TypeReference FieldType
            {
                get
                {
                    // Use ImportReference just in case to avoid any "X is in another module" errors.
                    if (field != null) { return field.Module.ImportReference(field.FieldType); }
                    else { return property.Module.ImportReference(property.PropertyType); }
                }
            }
            public TypeDefinition FieldTypeDefinition
            {
                get
                {
                    if (field != null) { return field.FieldType.Resolve(); }
                    else { return property.PropertyType.Resolve(); }
                }
            }
            public bool IsProperty { get { return field == null && property != null; } }
            public bool IsArray
            {
                get
                {
                    if (field != null)
                    {
                        return field.FieldType.IsArray;
                    }
                    else
                    {
                        return property.PropertyType.IsArray;
                    }
                }
            }

            public bool IsValueType
            {
                get
                {
                    if (field != null)
                    {
                        return field.FieldType.IsValueType;
                    }
                    else
                    {
                        return property.PropertyType.IsValueType;
                    }
                }
            }

            public FieldOrProperty(CustomAttribute attribute)
            {
                field = null;
                property = null;

                id = attribute.GetConstructorArgument(0, 0);
                customName = attribute.GetField<string>("customName", null);
                visible = attribute.GetField("visible", true);
                order = 0;
            }

            public bool TryGetAttributes<T>(out CustomAttribute[] attributes) where T : Attribute
            {
                if (field != null)
                {
                    return field.TryGetAttributes<T>(out attributes);
                }
                else
                {
                    return property.TryGetAttributes<T>(out attributes);
                }
            }
        }

        private static EventDefinition internalOnValueChanged;
        private static FieldDefinition lockField;
        private static FieldDefinition internalOnValueChangedField;

        private static MethodDefinition internalAddMethod;
        private static MethodDefinition internalRemoveMethod;

        private static MethodReference stringFormat;
        private static MethodReference stringEquality;
        private static MethodReference argumentException;
        private static MethodReference getType;

        private const string NO_EXPOSED_FIELDS = "There's no exposed property with the ID '{0}'.";

        public override bool IsValidClass(TypeDefinition type)
        {
            if (type.HasFields)
            {
                for (int i = 0; i < type.Fields.Count; i++)
                {
                    if (type.Fields[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out _))
                    {
                        return true;
                    }
                }
            }

            if (type.HasProperties)
            {
                for (int i = 0; i < type.Properties.Count; i++)
                {
                    if (type.Properties[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out _))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override (bool success, bool dirty) ProcessClass(ModuleDefinition module, TypeDefinition type)
        {
            List<FieldOrProperty> exposedFields = new List<FieldOrProperty>();
            List<int> usedIds = new List<int>();
            if (type.HasFields)
            {
                for (int i = 0; i < type.Fields.Count; i++)
                {
                    if (type.Fields[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out CustomAttribute attribute))
                    {
                        int id = attribute.GetConstructorArgument(0, 0);
                        if (usedIds.Contains(id))
                        {
                            Debug.LogError($"The ID {id} is already in use in {type.FullName}. The IDs need to be unique!");
                            return (false, false);
                        }
                        else
                        {
                            usedIds.Add(id);
                        }

                        int customOrder = attribute.GetField("order", 0);
                        if (customOrder > 0)
                        {
                            customOrder += type.Fields.Count + type.Properties.Count;
                        }
                        else if (customOrder < 0)
                        {
                            customOrder -= type.Fields.Count + type.Properties.Count;
                        }
                        else
                        {
                            customOrder = i;
                        }

                        exposedFields.Add(new FieldOrProperty(attribute) { field = type.Fields[i], order = customOrder });
                    }
                }
            }

            if (type.HasProperties)
            {
                for (int i = 0; i < type.Properties.Count; i++)
                {
                    if (type.Properties[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out CustomAttribute attribute))
                    {
                        if (type.Properties[i].GetMethod == null)
                        {
                            Debug.LogError(type.FullName + "." + type.Properties[i].Name + " does not have a get method. Exposed properties need to have both a getter and setter.");
                            return (false, false);
                        }

                        if (type.Properties[i].SetMethod == null)
                        {
                            Debug.LogError(type.FullName + "." + type.Properties[i].Name + " does not have a set method. Exposed properties need to have both a getter and setter.");
                            return (false, false);
                        }

                        int id = attribute.GetConstructorArgument(0, 0);
                        if (usedIds.Contains(id))
                        {
                            Debug.LogError($"The ID {id} is already in use in {type.FullName}. The IDs need to be unique!");
                            return (false, false);
                        }
                        else
                        {
                            usedIds.Add(id);
                        }

                        int customOrder = attribute.GetField("order", 0);
                        if (customOrder > 0)
                        {
                            customOrder += type.Fields.Count + type.Properties.Count;
                        }
                        else if (customOrder < 0)
                        {
                            customOrder -= type.Fields.Count + type.Properties.Count;
                        }
                        else
                        {
                            customOrder = type.Fields.Count + i;
                        }

                        exposedFields.Add(new FieldOrProperty(attribute) { property = type.Properties[i], order = customOrder });
                    }
                }
            }

            // There were no exposed fields so there's no reason to continue.
            if (exposedFields.Count == 0)
            {
                return (true, false);
            }

            stringFormat = module.ImportReference(typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(object) }));
            stringEquality = module.ImportReference(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }));
            argumentException = module.ImportReference(typeof(ArgumentException).GetConstructor(new Type[] { typeof(string) }));
            getType = module.ImportReference(typeof(Type).GetMethod("GetTypeFromHandle", new Type[] { typeof(RuntimeTypeHandle) }));

            exposedFields.Sort((x, y) => x.order.CompareTo(y.order));

            InterfaceImplementation exposedInterface = new InterfaceImplementation(module.ImportReference(typeof(IExposedToLevelEditor)));

            // It already implements the interface.
            if (type.ImplementsInterface(exposedInterface))
            {
                return (true, false);
            }

            type.Interfaces.Add(exposedInterface);

            CreateLockObject(type);
            CreateValueChangedEvent(type);

            PropertyDefinition componentName = CreateProperty("ComponentName", type.Name, typeof(string), module, type);
            PropertyDefinition typeName = CreateProperty("TypeName", type.FullName, typeof(string), module, type);
            PropertyDefinition order = CreateProperty("Order", 0, typeof(int), module, type);

            type.Properties.Add(componentName);
            type.Properties.Add(typeName);
            type.Properties.Add(order);

            MethodDefinition getPropertiesMethod = CreateGetProperties(module, exposedFields);
            MethodDefinition getValueMethod = CreateGetValue(module, exposedFields);
            MethodDefinition setValueMethod = CreateSetValue(type, module, exposedFields);
            MethodDefinition getValueTypeMethod = CreateGetValueType(module, exposedFields);

            type.Methods.Add(getPropertiesMethod);
            type.Methods.Add(getValueMethod);
            type.Methods.Add(setValueMethod);
            type.Methods.Add(getValueTypeMethod);

            return (true, true);
        }

        private static void CreateLockObject(TypeDefinition type)
        {
            lockField = GetOrCreateField("ALE_ExposedToLevelEditor_lockObject", type, typeof(object));
            type.Fields.Add(lockField);

            MethodDefinition typeConstructor = type.GetConstructor();
            ILProcessor il = typeConstructor.Body.GetILProcessor();

            Instruction newObj = Instruction.Create(OpCodes.Newobj, type.Module.ImportReference(typeof(object).GetConstructor(Array.Empty<Type>())));
            Instruction setField = Instruction.Create(OpCodes.Stfld, lockField);

            il.InsertAfter(il.Body.Instructions[0], newObj);
            il.InsertAfter(il.Body.Instructions[1], setField);
            il.InsertAfter(il.Body.Instructions[2], Instruction.Create(OpCodes.Ldarg_0));
        }

        private static void CreateValueChangedEvent(TypeDefinition type)
        {
            TypeReference action = type.Module.ImportReference(typeof(Action<int, object>));
            TypeReference voidType = type.Module.ImportReference(typeof(void));
            CustomAttribute compilerGenerated = new CustomAttribute(type.Module.ImportReference(typeof(CompilerGeneratedAttribute).GetConstructor(Array.Empty<Type>())));

            CreateInternalOnValueChanged(type, action, voidType, compilerGenerated);
            CreateOnValueChanged(type, action, voidType);
        }

        private static void CreateInternalOnValueChanged(TypeDefinition type, TypeReference action, TypeReference voidType, CustomAttribute compilerGenerated)
        {
            internalOnValueChanged = new EventDefinition("ALE_ExposedToLevelEditor_OnValueChanged", EventAttributes.None, action);
            internalOnValueChangedField = new FieldDefinition("ALE_ExposedToLevelEditor_OnValueChanged", FieldAttributes.Private, action);
            internalOnValueChangedField.CustomAttributes.Add(compilerGenerated);

            type.Fields.Add(internalOnValueChangedField);

            internalAddMethod = CreateInternalAddRemoveEventMethod(type, internalOnValueChangedField, "add_ALE_ExposedToLevelEditor_OnValueChanged", true, action, voidType, compilerGenerated);
            internalRemoveMethod = CreateInternalAddRemoveEventMethod(type, internalOnValueChangedField, "remove_ALE_ExposedToLevelEditor_OnValueChanged", false, action, voidType, compilerGenerated);

            type.Methods.Add(internalAddMethod);
            type.Methods.Add(internalRemoveMethod);

            internalOnValueChanged.AddMethod = internalAddMethod;
            internalOnValueChanged.RemoveMethod = internalRemoveMethod;

            type.Events.Add(internalOnValueChanged);
        }

        private static MethodDefinition CreateInternalAddRemoveEventMethod(TypeDefinition type, FieldDefinition eventField, string name, bool combine,
            TypeReference action, TypeReference voidType, CustomAttribute compilerGenerated)
        {
            MethodDefinition method = new MethodDefinition(name, MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName, voidType);
            method.Parameters.Add(new ParameterDefinition("value", ParameterAttributes.None, action));
            method.CustomAttributes.Add(compilerGenerated);

            method.Body.Variables.Add(new VariableDefinition(action));
            method.Body.Variables.Add(new VariableDefinition(action));
            method.Body.Variables.Add(new VariableDefinition(action));

            ILProcessor il = method.Body.GetILProcessor();
            il.Body.InitLocals = true;

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, eventField);
            il.Emit(OpCodes.Stloc_0);

            Instruction loopStart = Instruction.Create(OpCodes.Ldloc_0);
            il.Append(loopStart);
            il.Emit(OpCodes.Stloc_1);
            il.Emit(OpCodes.Ldloc_1);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, type.Module.ImportReference(typeof(Delegate).GetMethod(combine ? nameof(Delegate.Combine) : nameof(Delegate.Remove),
                                                                                            new Type[] { typeof(Delegate), typeof(Delegate) })));
            il.Emit(OpCodes.Castclass, action);
            il.Emit(OpCodes.Stloc_2);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldflda, eventField);
            il.Emit(OpCodes.Ldloc_2);
            il.Emit(OpCodes.Ldloc_1);

            MethodInfo compareMethod = typeof(Interlocked).GetMethods()
                                                          .Single(m => m.Name == nameof(Interlocked.CompareExchange) && m.IsGenericMethodDefinition)
                                                          .MakeGenericMethod(typeof(Action<string, bool>));

            il.Emit(OpCodes.Call, type.Module.ImportReference(compareMethod));
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ldloc_1);
            il.Emit(OpCodes.Bne_Un_S, loopStart);

            il.Emit(OpCodes.Ret);

            return method;
        }

        private static void CreateOnValueChanged(TypeDefinition type, TypeReference action, TypeReference voidType)
        {
            EventDefinition valueChanged = new EventDefinition("IExposedToLevelEditor.OnValueChanged", EventAttributes.None, action);

            MethodDefinition addMethod = CreateOnValueChangeAddRemoveMethod(type, lockField, "Hertzole.ALE.IExposedToLevelEditor.add_OnValueChanged", false, internalAddMethod, action, voidType);
            MethodDefinition removeMethod = CreateOnValueChangeAddRemoveMethod(type, lockField, "Hertzole.ALE.IExposedToLevelEditor.remove_OnValueChanged", true, internalRemoveMethod, action, voidType);

            type.Methods.Add(addMethod);
            type.Methods.Add(removeMethod);

            valueChanged.AddMethod = addMethod;
            valueChanged.RemoveMethod = removeMethod;

            type.Events.Add(valueChanged);
        }

        private static MethodDefinition CreateOnValueChangeAddRemoveMethod(TypeDefinition type, FieldDefinition lockObject, string name, bool remove, MethodDefinition targetMethod,
            TypeReference action, TypeReference voidType)
        {
            MethodDefinition method = new MethodDefinition(name, MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName |
                                                                 MethodAttributes.NewSlot | MethodAttributes.Virtual, voidType);

            method.Overrides.Add(type.Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod(remove ? "remove_OnValueChanged" : "add_OnValueChanged",
                                                                                                    new Type[] { typeof(Action<int, object>) })));
            method.Parameters.Add(new ParameterDefinition("value", ParameterAttributes.None, action));

            method.Body.Variables.Add(new VariableDefinition(type.Module.ImportReference(typeof(object))));
            method.Body.Variables.Add(new VariableDefinition(type.Module.ImportReference(typeof(bool))));
            method.Body.InitLocals = true;

            ILProcessor il = method.Body.GetILProcessor();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, lockField);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Stloc_1);

            Instruction ret = Instruction.Create(OpCodes.Ret);

            Instruction tryStart = Instruction.Create(OpCodes.Ldloc_0);
            il.Append(tryStart);
            il.Emit(OpCodes.Ldloca_S, method.Body.Variables[1]);
            il.Emit(OpCodes.Call, type.Module.ImportReference(typeof(Monitor).GetMethod(nameof(Monitor.Enter), new Type[] { typeof(object), typeof(bool).MakeByRefType() })));
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, targetMethod);
            il.Emit(OpCodes.Leave_S, ret);

            Instruction finallyStart = Instruction.Create(OpCodes.Ldloc_1);
            il.Append(finallyStart);
            Instruction finallyEnd = Instruction.Create(OpCodes.Endfinally);
            il.Emit(OpCodes.Brfalse_S, finallyEnd);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Call, type.Module.ImportReference(typeof(Monitor).GetMethod(nameof(Monitor.Exit), new Type[] { typeof(object) })));
            il.Append(finallyEnd);
            il.Append(ret);

            ExceptionHandler handler = new ExceptionHandler(ExceptionHandlerType.Finally)
            {
                TryStart = tryStart,
                TryEnd = finallyStart,
                HandlerStart = finallyStart,
                HandlerEnd = ret
            };

            method.Body.ExceptionHandlers.Add(handler);

            return method;
        }

        private static FieldDefinition GetOrCreateField(string fieldName, TypeDefinition type, Type fieldType)
        {
            if (!type.TryGetField(fieldName, out FieldDefinition field))
            {
                return new FieldDefinition(fieldName, FieldAttributes.Private, type.Module.ImportReference(fieldType));
            }
            else
            {
                return field;
            }
        }

        private static PropertyDefinition CreateProperty(string name, object value, Type returnType, ModuleDefinition module, TypeDefinition type)
        {
            PropertyDefinition prop = new PropertyDefinition($"Hertzole.ALE.IExposedToLevelEditor.{name}", PropertyAttributes.None, module.ImportReference(returnType));
            MethodDefinition propGet = new MethodDefinition($"Hertzole.ALE.IExposedToLevelEditor.get_{name}()",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                module.ImportReference(returnType));

            propGet.Overrides.Add(module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("get_" + name, Array.Empty<Type>())));

            ILProcessor il = propGet.Body.GetILProcessor();

            if (returnType == typeof(string))
            {
                il.Emit(OpCodes.Ldstr, (string)value);
            }
            else if (returnType == typeof(int))
            {
                il.Append(GetIntInstruction((int)value));
            }
            il.Emit(OpCodes.Ret);
            type.Methods.Add(propGet);

            prop.GetMethod = propGet;

            return prop;
        }

        private static MethodDefinition CreateGetProperties(ModuleDefinition module, List<FieldOrProperty> exposedFields)
        {
            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.GetProperties",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                module.ImportReference(typeof(ExposedProperty[])));
            method.Overrides.Add(module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("GetProperties", Array.Empty<Type>())));

            ILProcessor il = method.Body.GetILProcessor();

            il.Append(GetIntInstruction(exposedFields.Count));
            il.Emit(OpCodes.Newarr, module.ImportReference(typeof(ExposedProperty)));

            MethodReference propertyConstructor = module.ImportReference(typeof(ExposedProperty).GetConstructor(new Type[]
            {
                typeof(int), typeof(Type), typeof(string), typeof(string), typeof(bool), typeof(bool)
            }));
            int index = 0;

            foreach (FieldOrProperty field in exposedFields)
            {
                il.Emit(OpCodes.Dup);
                il.Append(GetIntInstruction(index)); // Index
                il.Append(GetIntInstruction(field.id));
                // If it's an array, only return the base type. The level editor will handle arrays by itself using the IsArray property.
                il.Emit(OpCodes.Ldtoken, field.IsArray ? module.ImportReference(field.FieldType.Resolve()) : field.FieldType);
                il.Emit(OpCodes.Call, getType);

                //TODO: Implement custom names.
                il.Emit(OpCodes.Ldstr, field.Name); // Field name
                if (string.IsNullOrEmpty(field.customName))
                {
                    il.Emit(OpCodes.Ldnull);
                }
                else
                {
                    il.Emit(OpCodes.Ldstr, field.customName);
                }
                il.Emit(GetBoolOpCode(field.visible)); // Is visible
                il.Emit(GetBoolOpCode(field.IsArray)); // Is array

                il.Emit(OpCodes.Newobj, propertyConstructor); // Create the constructor.
                il.Emit(OpCodes.Stelem_Any, module.ImportReference(typeof(ExposedProperty)));

                index++;
            }

            il.Emit(OpCodes.Ret);
            return method;
        }

        private static MethodDefinition CreateGetValue(ModuleDefinition module, List<FieldOrProperty> exposedFields)
        {
            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.GetValue",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                module.ImportReference(typeof(object)));
            method.Parameters.Add(new ParameterDefinition("id", ParameterAttributes.None, module.ImportReference(typeof(int))));
            method.Overrides.Add(module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("GetValue", new Type[] { typeof(int) })));

            CreateIfContainer(exposedFields, method, (i, il) =>
            {
                Instruction first = Instruction.Create(OpCodes.Ldarg_1);
                il.Append(first);
                if (exposedFields[i].id != 0)
                {
                    il.Append(GetIntInstruction(exposedFields[i].id));
                }

                return first;
            }, (i, il) =>
            {
                Instruction first = Instruction.Create(OpCodes.Ldarg_0);
                il.Append(first);
                if (exposedFields[i].IsProperty)
                {
                    il.Emit(OpCodes.Call, exposedFields[i].property.GetMethod);
                }
                else
                {
                    il.Emit(OpCodes.Ldfld, exposedFields[i].field);
                }
                il.Emit(OpCodes.Box, exposedFields[i].FieldType);
                il.Emit(OpCodes.Ret);

                return first;
            }, (il) =>
            {
                Instruction noProperty = Instruction.Create(OpCodes.Ldstr, NO_EXPOSED_FIELDS);
                il.Append(noProperty);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Box, module.ImportReference(typeof(int)));
                il.Emit(OpCodes.Call, stringFormat);
                il.Emit(OpCodes.Newobj, argumentException);
                il.Emit(OpCodes.Throw);

                return noProperty;
            });

            method.Body.Optimize();

            return method;
        }

        private static MethodDefinition CreateSetValue(TypeDefinition baseType, ModuleDefinition module, List<FieldOrProperty> exposedFields)
        {
            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.SetValue",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                module.ImportReference(typeof(void)));
            method.Parameters.Add(new ParameterDefinition("id", ParameterAttributes.None, module.ImportReference(typeof(int))));
            method.Parameters.Add(new ParameterDefinition("value", ParameterAttributes.None, module.ImportReference(typeof(object))));
            method.Parameters.Add(new ParameterDefinition("notify", ParameterAttributes.None, module.ImportReference(typeof(bool))));
            method.Overrides.Add(module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("SetValue", new Type[] { typeof(int), typeof(object), typeof(bool) })));

            method.Body.Variables.Add(new VariableDefinition(module.ImportReference(typeof(bool))));
            method.Body.InitLocals = true;

            ILProcessor il = method.Body.GetILProcessor();

            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Stloc_0);

            List<Instruction> nameCheckFalse = new List<Instruction>();
            List<Instruction> firsts = new List<Instruction>();
            Instruction checkChanged = Instruction.Create(OpCodes.Ldarg_3);
            Instruction ret = Instruction.Create(OpCodes.Ret);

            TypeDefinition converterType = null;
            FieldDefinition converterInstanceField = null;

            for (int i = 0; i < exposedFields.Count; i++)
            {
                FieldOrProperty field = exposedFields[i];

                Instruction first = Instruction.Create(OpCodes.Ldarg_1);
                il.Append(first);
                if (field.id > 0)
                {
                    Instruction intInstruction = GetIntInstruction(field.id);
                    il.Append(intInstruction);
                    nameCheckFalse.Add(intInstruction);
                }
                else
                {
                    nameCheckFalse.Add(first);
                }

                if (i != 0)
                {
                    firsts.Add(first);
                }

                TypeReference type = field.FieldType;
                il.Emit(field.IsArray ? OpCodes.Ldarg_2 : OpCodes.Ldarg_0);

                if (!field.IsArray)
                {
                    bool isInequalityCheck = true;
                    bool isObjectEquals = false;
                    MethodDefinition equalityMethod = null;
                    if (field.FieldType.Is<Color32>())
                    {
                        equalityMethod = module.ImportReference(typeof(Color).GetMethod("op_Inequality", new Type[] { typeof(Color), typeof(Color) })).Resolve();
                    }
                    else if (field.FieldType.Resolve().IsSubclassOf<UnityEngine.Object>())
                    {
                        equalityMethod = module.ImportReference(typeof(UnityEngine.Object).GetMethod("op_Inequality", new Type[] { typeof(UnityEngine.Object), typeof(UnityEngine.Object) })).Resolve();
                    }
                    else
                    {
                        if (!field.FieldTypeDefinition.TryGetMethodInBaseType("op_Inequality", out equalityMethod, field.FieldType, field.FieldType))
                        {
                            if (field.FieldTypeDefinition.TryGetMethodInBaseType("Equals", out equalityMethod, field.FieldType))
                            {
                                isInequalityCheck = false;
                            }
                            else
                            {
                                equalityMethod = module.ImportReference(typeof(object).GetMethod("Equals", new Type[] { typeof(object) })).Resolve();
                                isObjectEquals = false;
                            }
                        }
                    }

                    if (field.IsProperty)
                    {
                        il.Emit(OpCodes.Call, field.property.GetMethod);
                    }
                    else
                    {
                        if (!isInequalityCheck)
                        {
                            il.Emit(field.IsValueType ? OpCodes.Ldflda : OpCodes.Ldfld, field.field);
                        }
                        else
                        {
                            il.Emit(OpCodes.Ldfld, field.field);
                        }
                    }

                    int varLoc = method.Body.Variables.Count;

                    if (field.IsProperty && field.IsValueType && !isInequalityCheck)
                    {
                        if (field.property.TryGetReturnField(out FieldDefinition propertyReturnField))
                        {
                            VariableDefinition propertyVar = new VariableDefinition(propertyReturnField.FieldType);
                            method.Body.Variables.Add(propertyVar);
                            il.Append(GetStloc(varLoc));
                            il.Emit(OpCodes.Ldloca_S, propertyVar);
                        }
                    }

                    if (type.Is<Color32>())
                    {
                        il.Emit(OpCodes.Call, module.ImportReference(typeof(Color32).GetMethod("op_Implicit", new Type[] { typeof(Color32) })));
                    }

                    il.Emit(OpCodes.Ldarg_2);

                    if (type.Is<Color32>())
                    {
                        type = module.ImportReference(typeof(Color)); // Needs to convert to color because Color32 is being stupid with equals check.
                    }

                    if (field.IsValueType)
                    {
                        il.Emit(OpCodes.Unbox_Any, type);
                    }
                    else
                    {
                        il.Emit(OpCodes.Castclass, type);
                    }

                    if (isObjectEquals && field.IsValueType)
                    {
                        il.Emit(OpCodes.Box, field.FieldType);
                        il.Emit(OpCodes.Constrained, field.FieldType);
                    }

                    if (equalityMethod != null)
                    {
                        il.Emit(isObjectEquals ? OpCodes.Callvirt : OpCodes.Call, module.ImportReference(equalityMethod));
                        if (isInequalityCheck)
                        {
                            il.Emit(OpCodes.Brfalse, checkChanged);
                        }
                        else
                        {
                            il.Emit(OpCodes.Brtrue, checkChanged);
                        }
                    }
                    else
                    {
                        il.Emit(OpCodes.Beq, checkChanged);
                    }

                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldarg_2);
                    il.Emit(field.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);

                    if (field.FieldType.Is<Color32>())
                    {
                        il.Emit(OpCodes.Call, module.ImportReference(typeof(Color32).GetMethod("op_Implicit", new Type[] { typeof(Color) })));
                    }
                }
                else
                {
                    if (converterType == null)
                    {
                        converterType = WeaverHelpers.LoadOrCreateConverterType(baseType, out converterInstanceField);
                    }

                    WeaverHelpers.CreateConverterField(true, typeof(Converter<,>), new TypeReference[] { baseType.Module.ImportReference(typeof(object)), baseType.Module.ImportReference(field.FieldType.Resolve()) },
                    baseType, converterType, field.FieldType.Resolve(), field.Name, "SetValue", out FieldDefinition converterField, out MethodDefinition converterMethod, (cIl) =>
                    {
                        cIl.Emit(OpCodes.Ldarg_1);
                        cIl.Emit(field.FieldType.Resolve().IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, baseType.Module.ImportReference(field.FieldType.Resolve()));
                        cIl.Emit(OpCodes.Ret);
                    }, field.FieldType.Resolve(), module.ImportReference(typeof(object)));

                    int localIndex = method.Body.Variables.Count;
                    method.Body.Variables.Add(new VariableDefinition(type));

                    MethodReference convertMethod = module.ImportReference(typeof(Array).GetMethod("ConvertAll"));

                    GenericInstanceMethod genericConvert = new GenericInstanceMethod(convertMethod);
                    genericConvert.GenericArguments.Add(module.ImportReference(typeof(object)));
                    genericConvert.GenericArguments.Add(module.ImportReference(type.Resolve()));

                    Instruction callConvert = Instruction.Create(OpCodes.Call, genericConvert);

                    il.Emit(OpCodes.Castclass, module.ImportReference(typeof(object[])));
                    il.Emit(OpCodes.Ldsfld, converterField);
                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Brtrue_S, callConvert);

                    il.Emit(OpCodes.Pop);
                    il.Emit(OpCodes.Ldsfld, converterInstanceField);
                    il.Emit(OpCodes.Ldftn, converterMethod);

                    TypeReference conv = module.ImportReference(typeof(Converter<,>));
                    GenericInstanceType genericConv = conv.MakeGenericInstanceType(module.ImportReference(typeof(object)), module.ImportReference(type.Resolve()));
                    MethodReference convCctor = module.ImportReference(genericConv.Resolve().GetConstructor(module.ImportReference(typeof(object)), module.ImportReference(typeof(IntPtr)))).MakeHostInstanceGeneric(genericConv);

                    il.Emit(OpCodes.Newobj, convCctor);
                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Stsfld, converterField);
                    il.Append(callConvert);
                    il.Append(GetStloc(localIndex));
                    il.Emit(OpCodes.Ldarg_0);
                    if (field.IsProperty)
                    {
                        il.Emit(OpCodes.Call, field.property.GetMethod);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldfld, field.field);
                    }
                    il.Append(GetLdloc(localIndex));
                    //il.Emit(OpCodes.Beq_S, checkChanged);
                    il.Append(Instruction.Create(OpCodes.Beq, checkChanged));

                    il.Emit(OpCodes.Ldarg_0);
                    il.Append(GetLdloc(localIndex));
                }

                if (field.IsProperty)
                {
                    il.Emit(OpCodes.Call, field.property.SetMethod);
                }
                else
                {
                    il.Emit(OpCodes.Stfld, field.field);
                }

                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Stloc_0);

                il.Emit(OpCodes.Br, checkChanged);
            }

            Instruction noExposedFields = Instruction.Create(OpCodes.Ldstr, NO_EXPOSED_FIELDS);
            il.Append(noExposedFields);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Box, module.ImportReference(typeof(int)));
            il.Emit(OpCodes.Call, stringFormat);
            il.Emit(OpCodes.Newobj, argumentException);
            il.Emit(OpCodes.Throw);

            firsts.Add(noExposedFields);

            il.Append(checkChanged);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.And);
            il.Emit(OpCodes.Brfalse_S, ret);

            Instruction invokeEvent = Instruction.Create(OpCodes.Ldarg_1);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, internalOnValueChangedField);
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Brtrue_S, invokeEvent);

            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ret);

            il.Append(invokeEvent);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Callvirt, module.ImportReference(typeof(Action<int, object>).GetMethod("Invoke", new Type[] { typeof(int), typeof(object) })));
            il.Append(ret);

            for (int i = 0; i < nameCheckFalse.Count; i++)
            {
                il.InsertAfter(nameCheckFalse[i], Instruction.Create(exposedFields[i].id == 0 ? OpCodes.Brtrue_S : OpCodes.Bne_Un_S, firsts[i]));
            }

            method.Body.Optimize();

            return method;
        }

        private static MethodDefinition CreateGetValueType(ModuleDefinition module, List<FieldOrProperty> exposedFields)
        {
            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.GetValueType",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                module.ImportReference(typeof(Type)));
            method.Parameters.Add(new ParameterDefinition("id", ParameterAttributes.None, module.ImportReference(typeof(int))));
            method.Overrides.Add(module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("GetValueType", new Type[] { typeof(int) })));

            CreateIfContainer(exposedFields, method, (i, il) =>
            {
                Instruction first = Instruction.Create(OpCodes.Ldarg_1);
                il.Append(first);
                if (exposedFields[i].id != 0)
                {
                    il.Append(GetIntInstruction(exposedFields[i].id));
                }

                return first;
            }, (i, il) =>
            {
                Instruction first = Instruction.Create(OpCodes.Ldtoken, exposedFields[i].FieldType);

                il.Append(first);
                il.Emit(OpCodes.Call, getType);
                il.Emit(OpCodes.Ret);

                return first;
            }, (il) =>
            {
                Instruction noProperty = Instruction.Create(OpCodes.Ldstr, NO_EXPOSED_FIELDS);
                il.Append(noProperty);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Box, module.ImportReference(typeof(int)));
                il.Emit(OpCodes.Call, stringFormat);
                il.Emit(OpCodes.Newobj, argumentException);
                il.Emit(OpCodes.Throw);

                return noProperty;
            });

            method.Body.Optimize();

            return method;
        }

        private static void CreateIfContainer(List<FieldOrProperty> fields, MethodDefinition method, Func<int, ILProcessor, Instruction> ifCheck, Func<int, ILProcessor, Instruction> body, Func<ILProcessor, Instruction> end)
        {
            ILProcessor il = method.Body.GetILProcessor();
            Instruction[] preIfInstructions = new Instruction[fields.Count];
            Instruction[] ifInstructions = new Instruction[fields.Count];

            for (int i = 0; i < fields.Count; i++)
            {
                Instruction first = ifCheck(i, il);
                if (i != 0)
                {
                    ifInstructions[i - 1] = first;
                }

                Instruction ifBody = body(i, il);
                preIfInstructions[i] = il.Body.Instructions[il.Body.Instructions.IndexOf(ifBody) - 1];
            }

            Instruction endProperty = end(il);
            ifInstructions[ifInstructions.Length - 1] = endProperty;

            for (int i = 0; i < ifInstructions.Length; i++)
            {
                il.InsertAfter(preIfInstructions[i], Instruction.Create(fields[i].id == 0 ? OpCodes.Brtrue_S : OpCodes.Bne_Un_S, ifInstructions[i]));
            }
        }

        private static OpCode GetBoolOpCode(bool value)
        {
            return value == true ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0;
        }

        private static Instruction GetStloc(int index)
        {
            switch (index)
            {
                case 0:
                    return Instruction.Create(OpCodes.Stloc_0);
                case 1:
                    return Instruction.Create(OpCodes.Stloc_1);
                case 2:
                    return Instruction.Create(OpCodes.Stloc_2);
                case 3:
                    return Instruction.Create(OpCodes.Stloc_3);
                default:
                    return Instruction.Create(OpCodes.Stloc_S, index);
            }
        }

        private static Instruction GetLdloc(int index)
        {
            switch (index)
            {
                case 0:
                    return Instruction.Create(OpCodes.Ldloc_0);
                case 1:
                    return Instruction.Create(OpCodes.Ldloc_1);
                case 2:
                    return Instruction.Create(OpCodes.Ldloc_2);
                case 3:
                    return Instruction.Create(OpCodes.Ldloc_3);
                default:
                    return Instruction.Create(OpCodes.Ldloc_S, index);
            }
        }

        private static Instruction GetIntInstruction(int value)
        {
            if (value == 0)
            {
                return Instruction.Create(OpCodes.Ldc_I4_0);
            }
            else if (value == 1)
            {
                return Instruction.Create(OpCodes.Ldc_I4_1);
            }
            else if (value == 2)
            {
                return Instruction.Create(OpCodes.Ldc_I4_2);
            }
            else if (value == 3)
            {
                return Instruction.Create(OpCodes.Ldc_I4_3);
            }
            else if (value == 4)
            {
                return Instruction.Create(OpCodes.Ldc_I4_4);
            }
            else if (value == 5)
            {
                return Instruction.Create(OpCodes.Ldc_I4_5);
            }
            else if (value == 6)
            {
                return Instruction.Create(OpCodes.Ldc_I4_6);
            }
            else if (value == 7)
            {
                return Instruction.Create(OpCodes.Ldc_I4_7);
            }
            else if (value == 8)
            {
                return Instruction.Create(OpCodes.Ldc_I4_8);
            }
            else if (value > 8 && value < 127)
            {
                return Instruction.Create(OpCodes.Ldc_I4_S, (sbyte)value);
            }
            else
            {
                return Instruction.Create(OpCodes.Ldc_I4, value);
            }
        }
    }
}
