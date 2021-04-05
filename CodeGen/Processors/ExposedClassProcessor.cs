using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hertzole.ALE.CodeGen
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
            public bool IsCollection { get { return FieldType.IsArray || IsList || IsDictionary; } }
            public bool IsArray { get { return FieldType.IsArray; } }
            public bool IsList { get { return FieldType.Is(typeof(List<>)); } }
            public bool IsDictionary { get { return FieldType.Is(typeof(Dictionary<,>)); } }
            public bool IsClass { get { return FieldTypeDefinition.IsClass; } }
            public bool IsValueType { get { return FieldTypeDefinition.IsValueType; } }

            public bool IsEnum
            {
                get { return FieldTypeDefinition.IsSubclassOf<Enum>(); }
            }

            public Instruction GetLoadInstruction()
            {
                if (IsProperty)
                {
                    return Instruction.Create(OpCodes.Call, property.GetMethod);
                }
                else
                {
                    return Instruction.Create((IsValueType && !IsCollection) ? OpCodes.Ldflda : OpCodes.Ldfld, field);
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

        public override void ProcessClass(TypeDefinition targetType)
        {
            List<FieldOrProperty> exposedFields = new List<FieldOrProperty>();
            List<int> usedIds = new List<int>();
            if (targetType.HasFields)
            {
                for (int i = 0; i < targetType.Fields.Count; i++)
                {
                    if (targetType.Fields[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out CustomAttribute attribute))
                    {
                        int id = attribute.GetConstructorArgument(0, 0);
                        if (usedIds.Contains(id))
                        {
                            Error($"{targetType.Name}.{targetType.Fields[i].Name} has a duplicate ID ({id}). IDs need to be unique.");
                        }

                        usedIds.Add(id);

                        int customOrder = attribute.GetField("order", 0);
                        if (customOrder > 0)
                        {
                            customOrder += targetType.Fields.Count + targetType.Properties.Count;
                        }
                        else if (customOrder < 0)
                        {
                            customOrder -= targetType.Fields.Count + targetType.Properties.Count;
                        }
                        else
                        {
                            customOrder = i;
                        }

                        exposedFields.Add(new FieldOrProperty(attribute) { field = targetType.Fields[i], order = customOrder });
                        TypeRegister.AddType(targetType.Fields[i].FieldType);
                    }
                }
            }

            if (targetType.HasProperties)
            {
                for (int i = 0; i < targetType.Properties.Count; i++)
                {
                    if (targetType.Properties[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out CustomAttribute attribute))
                    {
                        if (targetType.Properties[i].GetMethod == null)
                        {
                            Error($"{targetType.FullName}.{targetType.Properties[i].Name} does not have a get method. Exposed properties need to have both a getter and setter.");
                        }

                        if (targetType.Properties[i].SetMethod == null)
                        {
                            Error($"{targetType.FullName}.{targetType.Properties[i].Name} does not have a set method. Exposed properties need to have both a getter and setter.");
                        }

                        int id = attribute.GetConstructorArgument(0, 0);
                        if (usedIds.Contains(id))
                        {
                            Error($"{targetType.Name}.{targetType.Properties[i].Name} has a duplicate ID ({id}). IDs need to be unique.");
                        }

                        usedIds.Add(id);

                        int customOrder = attribute.GetField("order", 0);
                        if (customOrder > 0)
                        {
                            customOrder += targetType.Fields.Count + targetType.Properties.Count;
                        }
                        else if (customOrder < 0)
                        {
                            customOrder -= targetType.Fields.Count + targetType.Properties.Count;
                        }
                        else
                        {
                            customOrder = targetType.Fields.Count + i;
                        }

                        exposedFields.Add(new FieldOrProperty(attribute) { property = targetType.Properties[i], order = customOrder });
                        TypeRegister.AddType(targetType.Properties[i].PropertyType);
                    }
                }
            }

            // There were no exposed fields so there's no reason to continue.
            if (exposedFields.Count == 0)
            {
                return;
            }

            bool hasVisibleFields = false;
            for (int i = 0; i < exposedFields.Count; i++)
            {
                if (exposedFields[i].visible)
                {
                    hasVisibleFields = true;
                    break;
                }
            }

            stringFormat = Module.ImportReference(typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(object) }));
            stringEquality = Module.ImportReference(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }));
            argumentException = Module.ImportReference(typeof(ArgumentException).GetConstructor(new Type[] { typeof(string) }));
            getType = Module.ImportReference(typeof(Type).GetMethod("GetTypeFromHandle", new Type[] { typeof(RuntimeTypeHandle) }));

            exposedFields.Sort((x, y) => x.order.CompareTo(y.order));

            InterfaceImplementation exposedInterface = new InterfaceImplementation(Module.ImportReference(typeof(IExposedToLevelEditor)));

            // It already implements the interface.
            if (targetType.ImplementsInterface(exposedInterface))
            {
                return;
            }

            targetType.Interfaces.Add(exposedInterface);

            CreateLockObject(targetType);
            CreateValueChangedEvent(targetType);

            PropertyDefinition componentName = CreateProperty("ComponentName", targetType.Name, typeof(string), targetType);
            PropertyDefinition typeName = CreateProperty("TypeName", targetType.FullName, typeof(string), targetType);
            PropertyDefinition order = CreateProperty("Order", 0, typeof(int), targetType);
            PropertyDefinition componentType = CreateProperty("ComponentType", targetType, typeof(Type), targetType);
            PropertyDefinition hasVisibleFieldsProperty = CreateProperty("HasVisibleFields", hasVisibleFields, typeof(bool), targetType);

            targetType.Properties.Add(componentName);
            targetType.Properties.Add(typeName);
            targetType.Properties.Add(order);
            targetType.Properties.Add(componentType);
            targetType.Properties.Add(hasVisibleFieldsProperty);

            MethodDefinition getPropertiesMethod = CreateGetProperties(exposedFields);
            MethodDefinition getValueMethod = CreateGetValue(exposedFields);
            MethodDefinition setValueMethod = CreateSetValue(exposedFields);
            MethodDefinition getValueTypeMethod = CreateGetValueType(exposedFields);

            targetType.Methods.Add(getPropertiesMethod);
            targetType.Methods.Add(getValueMethod);
            targetType.Methods.Add(setValueMethod);
            targetType.Methods.Add(getValueTypeMethod);
        }

        private void CreateLockObject(TypeDefinition type)
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

        private void CreateValueChangedEvent(TypeDefinition type)
        {
            TypeReference action = type.Module.ImportReference(typeof(Action<int, object>));
            TypeReference voidType = type.Module.ImportReference(typeof(void));
            CustomAttribute compilerGenerated = new CustomAttribute(type.Module.ImportReference(typeof(CompilerGeneratedAttribute).GetConstructor(Array.Empty<Type>())));

            CreateInternalOnValueChanged(type, action, voidType, compilerGenerated);
            CreateOnValueChanged(type, action, voidType);
        }

        private void CreateInternalOnValueChanged(TypeDefinition type, TypeReference action, TypeReference voidType, CustomAttribute compilerGenerated)
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

        private MethodDefinition CreateInternalAddRemoveEventMethod(TypeDefinition type, FieldDefinition eventField, string name, bool combine,
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

        private void CreateOnValueChanged(TypeDefinition type, TypeReference action, TypeReference voidType)
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

        private MethodDefinition CreateOnValueChangeAddRemoveMethod(TypeDefinition type, FieldDefinition lockObject, string name, bool remove, MethodDefinition targetMethod,
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

        private FieldDefinition GetOrCreateField(string fieldName, TypeDefinition type, Type fieldType)
        {
            if (!type.TryGetField(fieldName, out FieldDefinition field))
            {
                return new FieldDefinition(fieldName, FieldAttributes.Private, Module.ImportReference(fieldType));
            }

            return field;
        }

        private PropertyDefinition CreateProperty(string name, object value, Type returnType, TypeDefinition type)
        {
            PropertyDefinition prop = new PropertyDefinition($"Hertzole.ALE.IExposedToLevelEditor.{name}", PropertyAttributes.None, Module.ImportReference(returnType));
            MethodDefinition propGet = new MethodDefinition($"Hertzole.ALE.IExposedToLevelEditor.get_{name}()",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                Module.ImportReference(returnType));

            propGet.Overrides.Add(Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("get_" + name, Array.Empty<Type>())));

            ILProcessor il = propGet.Body.GetILProcessor();

            if (returnType == typeof(string))
            {
                il.Emit(OpCodes.Ldstr, (string)value);
            }
            else if (returnType == typeof(int))
            {
                il.Append(GetIntInstruction((int)value));
            }
            else if (returnType == typeof(bool))
            {
                il.Emit(GetBoolOpCode((bool)value));
            }
            else if (returnType == typeof(Type))
            {
                il.Emit(OpCodes.Ldtoken, (TypeReference)value);
                il.Emit(OpCodes.Call, Module.ImportReference(typeof(Type).GetMethod("GetTypeFromHandle", new Type[] { typeof(RuntimeTypeHandle) })));
            }

            il.Emit(OpCodes.Ret);
            type.Methods.Add(propGet);

            prop.GetMethod = propGet;

            return prop;
        }

        private MethodDefinition CreateGetProperties(List<FieldOrProperty> exposedFields)
        {
            FieldDefinition cachedProperties = new FieldDefinition("ALE_ExposedToLevelEditor_cachedProperties", FieldAttributes.Private, Module.GetTypeReference<ReadOnlyCollection<ExposedProperty>>());
            Type.Fields.Add(cachedProperties);

            MethodDefinition constructor = Type.GetConstructor();
            ILProcessor cil = constructor.Body.GetILProcessor();

            MethodReference exposedPropertyCctr = Module.ImportReference(typeof(ExposedProperty).GetConstructor(new Type[]
            {
                typeof(int), typeof(Type), typeof(string), typeof(string), typeof(bool)
            }));
            MethodReference exposedArrayCctr = Module.ImportReference(typeof(ExposedArray).GetConstructor(new Type[]
            {
                typeof(int), typeof(Type), typeof(string), typeof(string), typeof(bool), typeof(Type)
            }));

            cil.InsertAfter(cil.Body.Instructions[0], WriteCachedProperties());

            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.GetProperties",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                Module.GetTypeReference<ReadOnlyCollection<ExposedProperty>>());

            method.Overrides.Add(Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("GetProperties", Array.Empty<Type>())));

            ILProcessor bodyIl = method.Body.GetILProcessor();

            bodyIl.Emit(OpCodes.Ldarg_0);
            bodyIl.Emit(OpCodes.Ldfld, cachedProperties);
            bodyIl.Emit(OpCodes.Ret);

            return method;

            Instruction[] WriteCachedProperties()
            {
                List<Instruction> i = new List<Instruction>
                {
                    Instruction.Create(OpCodes.Ldarg_0),
                    GetIntInstruction(exposedFields.Count),
                    Instruction.Create(OpCodes.Newarr, Module.ImportReference(typeof(ExposedProperty)))
                };

                for (int j = 0; j < exposedFields.Count; j++)
                {
                    FieldOrProperty field = exposedFields[j];
                    if (field.IsCollection)
                    {
                        i.AddRange(WriteExposedArray(field, j, exposedArrayCctr));
                    }
                    else
                    {
                        i.AddRange(WriteExposedProperty(field, j, exposedPropertyCctr));
                    }
                }

                i.Add(Instruction.Create(OpCodes.Newobj, Module.ImportReference(typeof(ReadOnlyCollection<ExposedProperty>).GetConstructor(new Type[] { typeof(IList<ExposedProperty>) }))));
                i.Add(Instruction.Create(OpCodes.Stfld, cachedProperties));

                return i.ToArray();
            }

            Instruction[] WriteExposedProperty(FieldOrProperty field, int index, MethodReference propertyConstructor)
            {
                List<Instruction> i = new List<Instruction>
                {
                    Instruction.Create(OpCodes.Dup),

                    GetIntInstruction(index), // Index
                    GetIntInstruction(field.id),

                    Instruction.Create(OpCodes.Ldtoken, Module.ImportReference(field.FieldType)),
                    Instruction.Create(OpCodes.Call, getType),

                    Instruction.Create(OpCodes.Ldstr, field.Name),
                    string.IsNullOrEmpty(field.customName) ? Instruction.Create(OpCodes.Ldnull) : Instruction.Create(OpCodes.Ldstr, field.customName),

                    Instruction.Create(GetBoolOpCode(field.visible)), // Is visible

                    Instruction.Create(OpCodes.Newobj, propertyConstructor), // Create the constructor.
                    Instruction.Create(OpCodes.Stelem_Ref)
                };

                return i.ToArray();
            }

            Instruction[] WriteExposedArray(FieldOrProperty field, int index, MethodReference propertyConstructor)
            {
                List<Instruction> i = new List<Instruction>
                {
                    Instruction.Create(OpCodes.Dup),

                    GetIntInstruction(index), // Index
                    GetIntInstruction(field.id),

                    Instruction.Create(OpCodes.Ldtoken, Module.ImportReference(field.FieldType)),
                    Instruction.Create(OpCodes.Call, getType),

                    Instruction.Create(OpCodes.Ldstr, field.Name),
                    string.IsNullOrEmpty(field.customName) ? Instruction.Create(OpCodes.Ldnull) : Instruction.Create(OpCodes.Ldstr, field.customName),

                    Instruction.Create(GetBoolOpCode(field.visible)) // Is visible
                };

                if (field.IsList)
                {
                    i.Add(Instruction.Create(OpCodes.Ldtoken, Module.ImportReference(((GenericInstanceType)field.FieldType).GenericArguments[0])));
                }
                else
                {
                    i.Add(Instruction.Create(OpCodes.Ldtoken, Module.ImportReference(field.FieldType.Resolve())));
                }

                i.Add(Instruction.Create(OpCodes.Call, getType));

                i.Add(Instruction.Create(OpCodes.Newobj, propertyConstructor)); // Create the constructor.
                i.Add(Instruction.Create(OpCodes.Stelem_Ref));

                return i.ToArray();
            }
        }

        private MethodDefinition CreateGetValue(List<FieldOrProperty> exposedFields)
        {
            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.GetValue",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                Module.ImportReference(typeof(object)));

            method.Parameters.Add(new ParameterDefinition("id", ParameterAttributes.None, Module.ImportReference(typeof(int))));
            method.Overrides.Add(Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("GetValue", new Type[] { typeof(int) })));

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
                il.Emit(OpCodes.Box, Module.ImportReference(typeof(int)));
                il.Emit(OpCodes.Call, stringFormat);
                il.Emit(OpCodes.Call, Module.GetMethod<Debug>("LogWarning", new Type[] { typeof(object) }));
                il.Emit(OpCodes.Ldnull);
                il.Emit(OpCodes.Ret);

                return noProperty;
            });

            method.Body.Optimize();

            return method;
        }

        private MethodDefinition CreateSetValue(List<FieldOrProperty> exposedFields)
        {
            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.SetValue",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                Module.ImportReference(typeof(void)));

            method.Parameters.Add(new ParameterDefinition("id", ParameterAttributes.None, Module.ImportReference(typeof(int))));
            method.Parameters.Add(new ParameterDefinition("value", ParameterAttributes.None, Module.ImportReference(typeof(object))));
            method.Parameters.Add(new ParameterDefinition("notify", ParameterAttributes.None, Module.ImportReference(typeof(bool))));
            method.Overrides.Add(Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("SetValue", new Type[] { typeof(int), typeof(object), typeof(bool) })));

            ILProcessor il = method.Body.GetILProcessor();

            Instruction last = Instruction.Create(OpCodes.Ldarg_3);

            VariableDefinition changedFlag = method.AddLocalVariable<bool>(Module, out int changedFlagIndex);
            // Set 'changed' flag to false.
            il.EmitBoolean(false, changedFlag, changedFlagIndex);

            Instruction ifElseLast = Instruction.Create(OpCodes.Ldstr, NO_EXPOSED_FIELDS);

            for (int i = 0; i < exposedFields.Count; i++)
            {
                VariableDefinition variable = method.AddLocalVariable(Module, exposedFields[i].FieldType, out int varIndex);
                Instruction[] instructions = WriteSetField(exposedFields[i], variable, varIndex);

                il.Append(instructions);
            }

            il.Append(ifElseLast);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Box, Module.ImportReference(typeof(int)));
            il.Emit(OpCodes.Call, Module.ImportReference(typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(object) })));
            il.Emit(OpCodes.Call, Module.ImportReference(typeof(Debug).GetMethod("LogWarning", new Type[] { typeof(object) })));

            for (int i = 0; i < il.Body.Instructions.Count; i++)
            {
                if (il.Body.Instructions[i].OpCode == OpCodes.Bne_Un_S)
                {
                    bool isLast = false;
                    for (int j = i + 1; j < il.Body.Instructions.Count; j++)
                    {
                        if (il.Body.Instructions[j].OpCode == OpCodes.Ldarg_1)
                        {
                            il.Body.Instructions[i].Operand = il.Body.Instructions[j];
                            break;
                        }
                        else if (il.Body.Instructions[j].OpCode == OpCodes.Ldstr)
                        {
                            isLast = true;
                            il.Body.Instructions[i].Operand = il.Body.Instructions[j];
                            break;
                        }
                    }
                    if (isLast)
                    {
                        break;
                    }
                }
            }

            Instruction ret = Instruction.Create(OpCodes.Ret);

            il.Append(last);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.And);
            il.Emit(OpCodes.Brfalse_S, ret);

            Instruction invokeEvent = Instruction.Create(OpCodes.Ldarg_1);

            // Invoke changed event.
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, internalOnValueChangedField);
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Brtrue_S, invokeEvent);

            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ret);

            il.Append(invokeEvent);
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Callvirt, Module.ImportReference(typeof(Action<int, object>).GetMethod("Invoke", new Type[] { typeof(int), typeof(object) })));

            il.Append(ret);

            method.Body.Optimize();

            return method;

            Instruction[] WriteSetField(FieldOrProperty field, VariableDefinition local, int localIndex)
            {
                // Write dummy 
                Instruction dummy = Instruction.Create(OpCodes.Ldarg_0);

                List<Instruction> i = new List<Instruction>
                {
                    Instruction.Create(OpCodes.Ldarg_1),
                    GetIntInstruction(field.id),
                    Instruction.Create(OpCodes.Bne_Un_S, dummy),
                };

                if (field.IsValueType && !field.IsCollection)
                {
                    i.Add(Instruction.Create(OpCodes.Ldarg_2));
                    i.Add(Instruction.Create(OpCodes.Isinst, field.FieldType));
                    i.Add(Instruction.Create(OpCodes.Brfalse, last));
                }

                // If check
                if (field.IsValueType && !field.IsCollection)
                {
                    i.Add(Instruction.Create(OpCodes.Ldarg_2));
                    i.Add(Instruction.Create(OpCodes.Unbox_Any, field.FieldType));
                    i.Add(GetStloc(localIndex, local));
                    i.Add(Instruction.Create(OpCodes.Ldarg_0));
                    i.Add(field.GetLoadInstruction());

                    if (field.IsProperty)
                    {
                        VariableDefinition v = new VariableDefinition(field.FieldType);
                        int vIndex = method.Body.Variables.Count;
                        method.Body.Variables.Add(v);

                        i.Add(GetStloc(vIndex, v));
                        i.Add(GetLdloc(vIndex, v, true));
                    }

                    i.Add(GetLdloc(localIndex, local));
                }

                // Equals check
                MethodReference equals;

                if (field.IsValueType && !field.IsCollection)
                {
                    equals = GetEqualsMethod(field.FieldTypeDefinition, out bool isSameEquals, out bool isInEquality);

                    if (isSameEquals)
                    {
                        i.Add(Instruction.Create(OpCodes.Call, Module.ImportReference(equals)));
                    }
                    else
                    {
                        // If it doesn't have a Equals method that take the type as parameter, it most likely needs to be boxed.
                        if (field.IsValueType)
                        {
                            i.Add(Instruction.Create(OpCodes.Box, field.FieldType));
                            i.Add(Instruction.Create(OpCodes.Constrained, field.FieldType));
                        }

                        i.Add(Instruction.Create(OpCodes.Callvirt, Module.ImportReference(equals)));
                    }

                    if (isInEquality)
                    {
                        i.Add(Instruction.Create(OpCodes.Brfalse, last));
                    }
                    else
                    {
                        i.Add(Instruction.Create(OpCodes.Brtrue, last));
                    }
                }
                else
                {
                    if (field.IsCollection)
                    {
                        equals = Module.GetMethod(typeof(LevelEditorExtensions), nameof(LevelEditorExtensions.CollectionEquals)).MakeGenericMethod(field.FieldType);
                    }
                    else
                    {
                        equals = Module.GetMethod(typeof(LevelEditorExtensions), nameof(LevelEditorExtensions.ClassEquals)).MakeGenericMethod(field.FieldType);
                    }

                    i.Add(Instruction.Create(OpCodes.Ldarg_0));
                    i.Add(Instruction.Create(OpCodes.Castclass, Module.GetTypeReference<IExposedToLevelEditor>()));
                    i.Add(Instruction.Create(OpCodes.Ldarg_2));
                    i.Add(Instruction.Create(OpCodes.Ldarg_0));
                    i.Add(field.GetLoadInstruction());
                    i.Add(GetLdloc(localIndex, local, true));
                    i.Add(Instruction.Create(OpCodes.Call, equals));
                    i.Add(Instruction.Create(OpCodes.Brtrue, last));
                }

                i.Add(Instruction.Create(OpCodes.Ldarg_0));
                i.Add(GetLdloc(localIndex, local));
                if (field.IsProperty)
                {
                    i.Add(Instruction.Create(OpCodes.Call, field.property.SetMethod));
                }
                else
                {
                    i.Add(Instruction.Create(OpCodes.Stfld, field.field));
                }

                i.Add(Instruction.Create(OpCodes.Ldc_I4_1));
                i.Add(Instruction.Create(OpCodes.Stloc_0));
                i.Add(Instruction.Create(OpCodes.Br, last));

                return i.ToArray();

                MethodReference GetEqualsMethod(TypeDefinition type, out bool isSameEquals, out bool isInEquality)
                {
                    isInEquality = false;
                    isSameEquals = false;

                    TypeReference fieldType = field.FieldType;
                    if (type.IsSubclassOf<UnityEngine.Object>())
                    {
                        fieldType = Module.ImportReference(typeof(UnityEngine.Object));
                    }

                    if (!type.TryGetMethodWithParameters("Equals", out MethodReference method, fieldType))
                    {
                        if (!type.TryGetMethodInBaseTypeWithParameters("Equals", out method, fieldType))
                        {
                            if (!type.TryGetMethodWithParameters("op_Inequality", out method, fieldType, fieldType))
                            {
                                if (!type.TryGetMethodInBaseTypeWithParameters("op_Inequality", out method, fieldType, fieldType))
                                {
                                    if (!type.TryGetMethodWithParameters("Equals", out method, Module.ImportReference(typeof(object))))
                                    {
                                        method = type.GetMethodInBaseType("Equals");
                                    }
                                }
                                else
                                {
                                    isInEquality = true;
                                    isSameEquals = true;
                                }
                            }
                            else
                            {
                                isInEquality = true;
                                isSameEquals = true;
                            }
                        }
                        else
                        {
                            isSameEquals = true;
                        }
                    }
                    else
                    {
                        isSameEquals = true;
                    }

                    if (method.DeclaringType.Is<ValueType>())
                    {
                        isSameEquals = false;
                        isInEquality = false;
                        method = Module.GetMethod<object>("Equals", new Type[] { typeof(object) });
                    }

                    return method;
                }
            }
        }

        private MethodDefinition CreateGetValueType(List<FieldOrProperty> exposedFields)
        {
            MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.GetValueType",
                MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                Module.ImportReference(typeof(Type)));
            method.Parameters.Add(new ParameterDefinition("id", ParameterAttributes.None, Module.ImportReference(typeof(int))));
            method.Overrides.Add(Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("GetValueType", new Type[] { typeof(int) })));

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
                il.Emit(OpCodes.Box, Module.GetTypeReference<int>());
                il.Emit(OpCodes.Call, stringFormat);
                il.Emit(OpCodes.Call, Module.GetMethod<Debug>("LogWarning", new Type[] { typeof(object) }));
                il.Emit(OpCodes.Ldnull);
                il.Emit(OpCodes.Ret);

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
    }
}
