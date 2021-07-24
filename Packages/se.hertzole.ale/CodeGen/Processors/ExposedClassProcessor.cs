using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Hertzole.ALE.CodeGen.Helpers;
using MessagePack;
using MessagePack.Formatters;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using UnityEngine;
using EventAttributes = Mono.Cecil.EventAttributes;
using FieldAttributes = Mono.Cecil.FieldAttributes;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using Object = UnityEngine.Object;
using ParameterAttributes = Mono.Cecil.ParameterAttributes;
using PropertyAttributes = Mono.Cecil.PropertyAttributes;
using TypeAttributes = Mono.Cecil.TypeAttributes;

namespace Hertzole.ALE.CodeGen
{
	public class ExposedClassProcessor : BaseProcessor
	{
		private const string NO_EXPOSED_FIELDS = "There's no exposed property with the ID '{0}'.";

		private static EventDefinition internalOnValueChanged;
		private static FieldDefinition lockField;
		private static FieldDefinition internalOnValueChangedField;

		private static MethodDefinition internalAddMethod;
		private static MethodDefinition internalRemoveMethod;

		private static MethodReference stringFormat;
		private static MethodReference stringEquality;
		private static MethodReference argumentException;
		private static MethodReference getType;

		private TypeDefinition wrapper;
		private MethodReference wrapperCtor;
		private TypeDefinition dirtyMaskType;
		private FieldDefinition dirtyMaskField;

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
							Error(attribute.Constructor.Resolve(), $"{targetType.Name}.{targetType.Fields[i].Name} has a duplicate ID ({id}). IDs need to be unique.");
							continue;
						}

						usedIds.Add(id);

						int customOrder = attribute.GetField(nameof(ExposeToLevelEditorAttribute.order), 0);
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
						Formatters.AddTypeToGenerate(targetType.Fields[i].FieldType.Resolve());
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

						int customOrder = attribute.GetField(nameof(ExposeToLevelEditorAttribute.order), 0);
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
						Formatters.AddTypeToGenerate(targetType.Properties[i].PropertyType.Resolve());
					}
				}
			}

			// There were no exposed fields so there's no reason to continue.
			if (exposedFields.Count == 0)
			{
				return;
			}

			if (exposedFields.Count > 64)
			{
				Error("A single component can't have more than 64 exposed properties.");
				return;
			}

			TypeRegister.AddType(targetType);

			bool hasVisibleFields = false;
			for (int i = 0; i < exposedFields.Count; i++)
			{
				if (exposedFields[i].visible)
				{
					hasVisibleFields = true;
					break;
				}
			}

			stringFormat = Module.ImportReference(typeof(string).GetMethod("Format", new[] { typeof(string), typeof(object) }));
			stringEquality = Module.ImportReference(typeof(string).GetMethod("op_Equality", new[] { typeof(string), typeof(string) }));
			argumentException = Module.ImportReference(typeof(ArgumentException).GetConstructor(new[] { typeof(string) }));
			getType = Module.ImportReference(typeof(Type).GetMethod("GetTypeFromHandle", new[] { typeof(RuntimeTypeHandle) }));

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

			CreateWrapper(exposedFields);
			CreateFormatter(exposedFields);

			MethodDefinition getPropertiesMethod = CreateGetProperties(exposedFields);
			MethodDefinition getValueMethod = CreateGetValue(exposedFields);
			CreateSetValue(exposedFields);
			CreateGetWrapper(exposedFields);
			CreateApplyWrapper(exposedFields);
			// MethodDefinition getValueTypeMethod = CreateGetValueType(exposedFields);

			targetType.Methods.Add(getPropertiesMethod);
			targetType.Methods.Add(getValueMethod);
			// targetType.Methods.Add(getValueTypeMethod);
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

		private MethodDefinition CreateInternalAddRemoveEventMethod(TypeDefinition type,
			FieldDefinition eventField,
			string name,
			bool combine,
			TypeReference action,
			TypeReference voidType,
			CustomAttribute compilerGenerated)
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
				new[] { typeof(Delegate), typeof(Delegate) })));

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

		private MethodDefinition CreateOnValueChangeAddRemoveMethod(TypeDefinition type,
			FieldDefinition lockObject,
			string name,
			bool remove,
			MethodDefinition targetMethod,
			TypeReference action,
			TypeReference voidType)
		{
			MethodDefinition method = new MethodDefinition(name, MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName |
			                                                     MethodAttributes.NewSlot | MethodAttributes.Virtual, voidType);

			method.Overrides.Add(type.Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod(remove ? "remove_OnValueChanged" : "add_OnValueChanged",
				new[] { typeof(Action<int, object>) })));

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
			il.Emit(OpCodes.Call, type.Module.ImportReference(typeof(Monitor).GetMethod(nameof(Monitor.Enter), new[] { typeof(object), typeof(bool).MakeByRefType() })));
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldarg_1);
			il.Emit(OpCodes.Call, targetMethod);
			il.Emit(OpCodes.Leave_S, ret);

			Instruction finallyStart = Instruction.Create(OpCodes.Ldloc_1);
			il.Append(finallyStart);
			Instruction finallyEnd = Instruction.Create(OpCodes.Endfinally);
			il.Emit(OpCodes.Brfalse_S, finallyEnd);
			il.Emit(OpCodes.Ldloc_0);
			il.Emit(OpCodes.Call, type.Module.ImportReference(typeof(Monitor).GetMethod(nameof(Monitor.Exit), new[] { typeof(object) })));
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
				il.Emit(OpCodes.Ldstr, (string) value);
			}
			else if (returnType == typeof(int))
			{
				il.EmitInt((int) value);
			}
			else if (returnType == typeof(bool))
			{
				il.EmitBool((bool) value);
			}
			else if (returnType == typeof(Type))
			{
				il.Emit(OpCodes.Ldtoken, (TypeReference) value);
				il.Emit(OpCodes.Call, Module.ImportReference(typeof(Type).GetMethod("GetTypeFromHandle", new[] { typeof(RuntimeTypeHandle) })));
			}

			il.Emit(OpCodes.Ret);
			type.Methods.Add(propGet);

			prop.GetMethod = propGet;

			return prop;
		}

		//TODO: Box wrapper beforehand. 
		private void CreateWrapper(IReadOnlyList<FieldOrProperty> exposedFields)
		{
			const string WRAPPER_NAME = "ALE__GeneratedComponentWrapper";

			if (Type.HasNestedTypes)
			{
				for (int i = 0; i < Type.NestedTypes.Count; i++)
				{
					if (Type.NestedTypes[i].Name == WRAPPER_NAME)
					{
						Error($"{Type.FullName} already has a nested class called '{WRAPPER_NAME}'.");
						return;
					}
				}
			}

			wrapper = new TypeDefinition(Type.Namespace, WRAPPER_NAME, TypeAttributes.NestedPublic | TypeAttributes.SequentialLayout |
			                                                           TypeAttributes.AnsiClass | TypeAttributes.Sealed |
			                                                           TypeAttributes.BeforeFieldInit,
				Module.GetTypeReference<ValueType>());

			wrapper.Interfaces.Add(new InterfaceImplementation(Module.GetTypeReference<IExposedWrapper>()));
			dirtyMaskType = CreateDirtyMask();
			wrapper.NestedTypes.Add(dirtyMaskType);
			dirtyMaskField = new FieldDefinition("ALE__Generated__dirtyMaskField", FieldAttributes.Public, dirtyMaskType);
			wrapper.Fields.Add(dirtyMaskField);

			MethodDefinition ctor = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig |
			                                                      MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
				Module.GetTypeReference(typeof(void)));

			wrapper.Methods.Add(ctor);
			Type.NestedTypes.Add(wrapper);

			ILProcessor il = ctor.Body.GetILProcessor();

			ParameterDefinition dirtyMaskParameter = ctor.AddParameter(Module, dirtyMaskType);

			il.EmitLdarg();
			il.EmitLdarg(dirtyMaskParameter);
			il.Emit(OpCodes.Stfld, dirtyMaskField);

			for (int i = 0; i < exposedFields.Count; i++)
			{
				FieldDefinition field = CreateField(exposedFields[i]);
				wrapper.Fields.Add(field);

				ParameterDefinition p = ctor.AddParameter(exposedFields[i].FieldTypeComponentAware);
#if ALE_DEBUG
				p.Name = exposedFields[i].Name;
#else

#endif

#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, $"{Type.FullName} wrapper setting value for field {exposedFields[i].id} ({exposedFields[i].Name})");
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

				il.EmitLdarg();
				il.EmitInt(exposedFields[i].id);
				il.EmitLdarg(p);

				MethodReference fieldCtor = Module.ImportReference(typeof(ValueTuple<,>)
				                                                   .GetConstructors()
				                                                   .Single(c => c.GetParameters().Length == 2))
				                                  .MakeHostInstanceGeneric(Module.ImportReference(typeof(ValueTuple<,>))
				                                                                 .MakeGenericInstanceType(Module.GetTypeReference<int>(), Module.ImportReference(exposedFields[i].FieldTypeComponentAware)));

				il.Emit(OpCodes.Newobj, fieldCtor);
				il.Emit(OpCodes.Stfld, field);
			}

			il.Emit(OpCodes.Ret);

			ctor.Body.Optimize();
			wrapperCtor = ctor;

			TypeDefinition CreateDirtyMask()
			{
				TypeDefinition mask = new TypeDefinition(string.Empty, "DirtyMask", TypeAttributes.NestedPublic | TypeAttributes.AnsiClass | TypeAttributes.Sealed, Module.GetTypeReference<Enum>());

				mask.Fields.Add(new FieldDefinition("value__", FieldAttributes.Public | FieldAttributes.SpecialName | FieldAttributes.RTSpecialName, Module.GetTypeReference<long>()));
				FieldDefinition noneField = new FieldDefinition("None", FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal, mask)
				{
					Constant = 0L
				};

				mask.Fields.Add(noneField);
				
				for (int i = 0; i < exposedFields.Count; i++)
				{
					FieldDefinition field = new FieldDefinition(exposedFields[i].Name, FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal, mask)
					{
						Constant = 1L << i
					};

					mask.Fields.Add(field);
					
				}
				
				return mask;
			}

			FieldDefinition CreateField(FieldOrProperty field)
			{
				TypeReference tuple = Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(Module.GetTypeReference<int>(), field.FieldTypeComponentAware);

				FieldDefinition f = new FieldDefinition(field.Name, FieldAttributes.Public, tuple);
				return f;
			}
		}

		private void CreateFormatter(IReadOnlyList<FieldOrProperty> fields)
		{
			string name = $"{Type.Namespace.Replace('.', '_')}_{Type.Name}_Formatter";
			if (name.StartsWith("_"))
			{
				name = name.Substring(1);
			}

			TypeDefinition formatter = new TypeDefinition("Hertzole.ALE.Generated.Formatters", name,
				TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit, Module.GetTypeReference<object>());

			formatter.Interfaces.Add(new InterfaceImplementation(Module.GetTypeReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(wrapper)));
			formatter.Interfaces.Add(new InterfaceImplementation(Module.GetTypeReference(typeof(IMessagePackFormatter))));

			Module.Types.Add(formatter);

			MethodDefinition ctor = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig |
			                                                      MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
				Module.GetTypeReference(typeof(void)));

			ILProcessor ctorIl = ctor.Body.GetILProcessor();
			ctorIl.Emit(OpCodes.Ldarg_0);
			ctorIl.Emit(OpCodes.Call, Module.GetConstructor<object>());
			ctorIl.Emit(OpCodes.Ret);

			formatter.Methods.Add(ctor);

			formatter.Methods.Add(CreateSerializeMethod());
			formatter.Methods.Add(CreateDeserializeMethod());

			MethodDefinition CreateSerializeMethod()
			{
				MethodDefinition m = new MethodDefinition("Serialize", MethodAttributes.Public | MethodAttributes.Final |
				                                                       MethodAttributes.HideBySig | MethodAttributes.NewSlot |
				                                                       MethodAttributes.Virtual, Module.GetTypeReference(typeof(void)));

				ParameterDefinition writer = m.AddParameter(Module, Module.GetTypeReference(typeof(MessagePackWriter).MakeByRefType()), "writer");
				ParameterDefinition value = m.AddParameter(Module, wrapper, "value");
				ParameterDefinition options = m.AddParameter(Module, Module.GetTypeReference<MessagePackSerializerOptions>(), "options");

				ILProcessor il = m.Body.GetILProcessor();

				m.Body.InitLocals = true;

#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, $"Serializing component {Type.FullName}");
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

				il.EmitLdarg(writer);
				il.Emit(OpCodes.Ldc_I4, fields.Count * 2);
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(MessagePackWriter), "WriteArrayHeader", typeof(int)));

				MethodReference getResolver = Module.GetMethod<MessagePackSerializerOptions>("get_Resolver");

				for (int i = 0; i < fields.Count; i++)
				{
					il.EmitLdarg(writer);
					il.EmitLdarg(value);
					il.Emit(OpCodes.Ldfld, wrapper.GetField(fields[i].Name));
					FieldReference item1 = Module.ImportReference(typeof(ValueTuple<,>).GetField("Item1"));
					item1.DeclaringType = Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(Module.GetTypeReference<int>(), fields[i].FieldTypeComponentAware);
					il.Emit(OpCodes.Ldfld, Module.ImportReference(item1));
					il.Emit(OpCodes.Call, Module.GetMethod(typeof(MessagePackWriter), "WriteInt32", typeof(int)));
					
#if ALE_DEBUG
					// LevelEditorLogger.Log
					il.Emit(OpCodes.Ldstr, "Writing value | ID: {0} | Value: {1}");
					il.EmitLdarg(value);
					il.Emit(OpCodes.Ldfld, wrapper.GetField(fields[i].Name));
					il.Emit(OpCodes.Ldfld, item1);
					il.Emit(OpCodes.Box, Module.GetTypeReference<int>());
					il.EmitLdarg(value);
					FieldReference item2 = Module.ImportReference(typeof(ValueTuple<,>).GetField("Item2"));
					item2.DeclaringType = Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(Module.GetTypeReference<int>(), fields[i].FieldTypeComponentAware);
					il.Emit(OpCodes.Ldfld, wrapper.GetField(fields[i].Name));
					il.Emit(OpCodes.Ldfld, item2);
					if (fields[i].FieldTypeComponentAware.IsValueType)
					{
						il.Emit(OpCodes.Box, fields[i].FieldTypeComponentAware);
					}
					il.Emit(OpCodes.Call, Module.GetMethod<string>("Format", typeof(string), typeof(object), typeof(object)));
					il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
					
					il.Append(FormatterHelper.GetWriteValue(fields[i].FieldTypeComponentAware, wrapper.GetField(fields[i].Name), false, getResolver, true));
				}

#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, $"Finished serializing component {Type.FullName}");
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

				il.Emit(OpCodes.Ret);

				Resolver.AddWrapperFormatter(formatter, wrapper, Type);

				m.Body.Optimize();

				return m;
			}

			MethodDefinition CreateDeserializeMethod()
			{
				MethodDefinition m = new MethodDefinition("Deserialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig |
				                                                         MethodAttributes.NewSlot | MethodAttributes.Virtual, wrapper);

				ParameterDefinition reader = m.AddParameter(Module, Module.GetTypeReference(typeof(MessagePackReader).MakeByRefType()), "reader");
				m.AddParameter(Module, Module.GetTypeReference<MessagePackSerializerOptions>(), "options");

				MethodReference getResolver = Module.GetMethod<MessagePackSerializerOptions>("get_Resolver");

				VariableDefinition lengthVar = m.AddLocalVariable<int>(Module);

				ILProcessor il = m.Body.GetILProcessor();
				Instruction dummy = Instruction.Create(OpCodes.Ret);

				m.Body.InitLocals = true;

				il.Emit(OpCodes.Ldarg_2);
				il.Emit(OpCodes.Callvirt, Module.GetMethod<MessagePackSerializerOptions>("get_Security"));
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Callvirt, Module.GetMethod<MessagePackSecurity>("DepthStep", typeof(MessagePackReader).MakeByRefType()));
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(MessagePackReader), "ReadArrayHeader"));
				il.EmitStloc(lengthVar);

				VariableDefinition maskVar = m.AddLocalVariable(Module, dirtyMaskType);
				il.EmitInt(0);
				il.Emit(OpCodes.Conv_I8);
				il.EmitStloc(maskVar);

				List<VariableDefinition> localFields = new List<VariableDefinition>();

				for (int i = 0; i < fields.Count; i++)
				{
					VariableDefinition v = m.AddLocalVariable(Module, fields[i].FieldTypeComponentAware);
					localFields.Add(v);

					if (fields[i].IsValueType && !fields[i].IsPrimitive && !fields[i].IsEnum)
					{
						il.EmitLdloc(v, true);
					}

					il.EmitDefaultValue(fields[i].FieldTypeComponentAware);

					if (!fields[i].IsValueType || fields[i].IsPrimitive || fields[i].IsEnum)
					{
						il.EmitStloc(v);
					}
				}

				VariableDefinition loopIndex = m.AddLocalVariable<int>(Module);
				VariableDefinition idVar = m.AddLocalVariable<int>(Module);

				il.EmitInt(0);
				Instruction beforeLoop = il.EmitStloc(loopIndex);

				List<Instruction> readFinishes = new List<Instruction>();

				Instruction loopStart = il.EmitLdloc(loopIndex);
				il.EmitInt(2);
				Instruction remainder = Instruction.Create(OpCodes.Rem);
				il.Append(remainder);

				Instruction previous;
				Instruction[] idRead = FormatterHelper.GetReadValue(idVar.VariableType, getResolver);

				il.Append(idRead);

				if (fields.Count > 1)
				{
					il.EmitStloc(idVar);
					if (fields[0].id == 0)
					{
						previous = il.EmitLdloc(idVar);
					}
					else
					{
						il.EmitLdloc(idVar);
						previous = il.EmitInt(fields[0].id);
					}
				}
				else
				{
					if (fields[0].id == 0)
					{
						previous = idRead[idRead.Length - 1];
					}
					else
					{
						previous = il.EmitInt(fields[0].id);
					}
				}

				if (fields.Count == 1)
				{
					il.Append(FormatterHelper.GetReadValue(fields[0].FieldTypeComponentAware, getResolver));
					il.EmitStloc(localFields[0]);
					
					// dirtyMask |= Wrapper.DirtyMask.Value;
					il.EmitLdloc(maskVar);
					il.EmitInt(1 << 0);
					il.Emit(OpCodes.Conv_I8);
					il.Emit(OpCodes.Or);
					Instruction finish = il.EmitStloc(maskVar);
					readFinishes.Add(finish);
				}
				else
				{
					for (int i = 0; i < fields.Count; i++)
					{
						if (i != 0)
						{
							Instruction ifStart = il.EmitLdloc(idVar);
							il.InsertAfter(previous, Instruction.Create(fields[i - 1].id == 0 ? OpCodes.Brtrue : OpCodes.Bne_Un, ifStart));

							previous = fields[i].id != 0 ? il.EmitInt(fields[i].id) : ifStart;
						}

						il.Append(FormatterHelper.GetReadValue(fields[i].FieldTypeComponentAware, getResolver));
						il.EmitStloc(localFields[i]);
						
						// dirtyMask |= Wrapper.DirtyMask.Value;
						il.EmitLdloc(maskVar);
						il.EmitInt(1 << i);
						il.Emit(OpCodes.Conv_I8);
						il.Emit(OpCodes.Or);
						Instruction finish = il.EmitStloc(maskVar);
						
						readFinishes.Add(finish);
					}
				}

				Instruction skipStart = il.EmitLdarg(reader);
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(MessagePackReader), "Skip"));

				// Insert jump to skip on last if check.
				il.InsertAfter(previous, Instruction.Create(fields[fields.Count - 1].id == 0 ? OpCodes.Brtrue : OpCodes.Bne_Un, skipStart));

				Instruction loopFinish = il.EmitLdloc(loopIndex);
				il.EmitInt(1);
				il.Emit(OpCodes.Add);
				il.EmitStloc(loopIndex);

				Instruction loopEnd = il.EmitLdloc(loopIndex);
				il.EmitLdloc(lengthVar);
				il.Emit(OpCodes.Blt, loopStart);

				il.InsertAfter(beforeLoop, Instruction.Create(OpCodes.Br, loopEnd));
				il.InsertAfter(remainder, Instruction.Create(OpCodes.Brtrue, loopFinish));

				for (int i = 0; i < readFinishes.Count; i++)
				{
					il.InsertAfter(readFinishes[i], Instruction.Create(OpCodes.Br, loopFinish));
				}

				VariableDefinition depthVar = m.AddLocalVariable<int>(Module);

				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(MessagePackReader), "get_Depth"));
				il.EmitStloc(depthVar);
				il.EmitLdloc(depthVar);
				il.EmitInt(1);
				il.Emit(OpCodes.Sub);
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(MessagePackReader), "set_Depth", typeof(int)));
				il.EmitLdloc(maskVar);
				for (int i = 0; i < fields.Count; i++)
				{
					il.EmitLdloc(localFields[i]);
				}

				il.Emit(OpCodes.Newobj, wrapperCtor);

				il.Emit(OpCodes.Ret);

				m.SetVariableName(maskVar, "dirtyMask");
				m.SetVariableName(lengthVar, "length");
				m.SetVariableName(loopIndex, "i");
				m.SetVariableName(idVar, "id");
				m.SetVariableName(depthVar, "depth");

				for (int i = 0; i < fields.Count; i++)
				{
					m.SetVariableName(localFields[i], $"__{fields[i].Name}__");
				}

				m.Body.Optimize();

				return m;
			}
		}

		private MethodDefinition CreateGetProperties(List<FieldOrProperty> exposedFields)
		{
			FieldDefinition cachedProperties = new FieldDefinition("ALE_ExposedToLevelEditor_cachedProperties", FieldAttributes.Private, Module.GetTypeReference<ReadOnlyCollection<ExposedProperty>>());
			Type.Fields.Add(cachedProperties);

			MethodDefinition constructor = Type.GetConstructor();
			ILProcessor cil = constructor.Body.GetILProcessor();

			MethodReference exposedPropertyCctr = Module.ImportReference(typeof(ExposedProperty).GetConstructor(new[]
			{
				typeof(int), typeof(Type), typeof(string), typeof(string), typeof(bool)
			}));

			MethodReference exposedArrayCctr = Module.ImportReference(typeof(ExposedArray).GetConstructor(new[]
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
					ILHelper.Int(exposedFields.Count),
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

				i.Add(Instruction.Create(OpCodes.Newobj, Module.ImportReference(typeof(ReadOnlyCollection<ExposedProperty>).GetConstructor(new[] { typeof(IList<ExposedProperty>) }))));
				i.Add(Instruction.Create(OpCodes.Stfld, cachedProperties));

				return i.ToArray();
			}

			Instruction[] WriteExposedProperty(FieldOrProperty field, int index, MethodReference propertyConstructor)
			{
				List<Instruction> i = new List<Instruction>
				{
					Instruction.Create(OpCodes.Dup),

					ILHelper.Int(index), // Index
					ILHelper.Int(field.id),

					Instruction.Create(OpCodes.Ldtoken, Module.ImportReference(field.FieldType)),
					Instruction.Create(OpCodes.Call, getType),

					Instruction.Create(OpCodes.Ldstr, field.Name),
					string.IsNullOrEmpty(field.customName) ? Instruction.Create(OpCodes.Ldnull) : Instruction.Create(OpCodes.Ldstr, field.customName),

					ILHelper.Bool(field.visible), // Is visible

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

					ILHelper.Int(index), // Index
					ILHelper.Int(field.id),

					Instruction.Create(OpCodes.Ldtoken, Module.ImportReference(field.FieldType)),
					Instruction.Create(OpCodes.Call, getType),

					Instruction.Create(OpCodes.Ldstr, field.Name),
					string.IsNullOrEmpty(field.customName) ? Instruction.Create(OpCodes.Ldnull) : Instruction.Create(OpCodes.Ldstr, field.customName),

					ILHelper.Bool(field.visible) // Is visible
				};

				if (field.IsList)
				{
					i.Add(Instruction.Create(OpCodes.Ldtoken, Module.ImportReference(((GenericInstanceType) field.FieldType).GenericArguments[0])));
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
			method.Overrides.Add(Module.ImportReference(typeof(IExposedToLevelEditor).GetMethod("GetValue", new[] { typeof(int) })));

			CreateIfContainer(exposedFields, method, (i, il) =>
			{
				Instruction first = Instruction.Create(OpCodes.Ldarg_1);
				il.Append(first);
				if (exposedFields[i].id != 0)
				{
					il.EmitInt(exposedFields[i].id);
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

				if (exposedFields[i].IsComponent)
				{
					il.Append(CreateNewComponentWrapper(exposedFields[i].FieldType));
					il.Emit(OpCodes.Box, Module.GetTypeReference<ComponentDataWrapper>());
				}
				else
				{
					il.Emit(OpCodes.Box, exposedFields[i].FieldType);
				}

				il.Emit(OpCodes.Ret);

				return first;
			}, il =>
			{
				Instruction noProperty = Instruction.Create(OpCodes.Ldstr, NO_EXPOSED_FIELDS);
				il.Append(noProperty);
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Box, Module.ImportReference(typeof(int)));
				il.Emit(OpCodes.Call, stringFormat);
				il.Emit(OpCodes.Call, Module.GetMethod<Debug>("LogWarning", typeof(object)));
				il.Emit(OpCodes.Ldnull);
				il.Emit(OpCodes.Ret);

				return noProperty;
			});

			method.Body.Optimize();

			return method;

			Instruction CreateNewComponentWrapper(TypeReference typeReference)
			{
				MethodReference ctor;
				
				if (typeReference.IsArray())
				{
					ctor = Module.GetConstructor<ComponentDataWrapper>(typeof(IReadOnlyList<>).MakeGenericType(typeReference.Resolve().Is<GameObject>() ? typeof(GameObject) : typeof(Component)));
				}
				else if (typeReference.IsList())
				{
					ctor = Module.GetConstructor<ComponentDataWrapper>(typeof(IReadOnlyList<>).MakeGenericType(typeReference.GetCollectionType().Is<GameObject>() ? typeof(GameObject) : typeof(Component)));
				}
				else
				{
					ctor = Module.GetConstructor<ComponentDataWrapper>(typeReference.Is<GameObject>() ? typeof(GameObject) : typeof(Component));
				}
				return Instruction.Create(OpCodes.Newobj, ctor);
			}
		}

		private void CreateSetValue(IReadOnlyList<FieldOrProperty> exposedFields)
		{
			MethodDefinition method = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.SetValue",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.ImportReference(typeof(void)));

			method.AddParameter<int>(Module, "id");
			method.AddParameter<object>(Module, "value");
			method.AddParameter<bool>(Module, "notify");
			method.Overrides.Add(Module.GetMethod<IExposedToLevelEditor>("SetValue", typeof(int), typeof(object), typeof(bool)));

			Type.Methods.Add(method);

			ILProcessor il = method.Body.GetILProcessor();

			Instruction last = Instruction.Create(OpCodes.Ldarg_3);

#if ALE_DEBUG
			il.Emit(OpCodes.Ldstr, Type.Name + " SetValue(Id: {0}, Value: {1}, Notify: {2})");
			il.Emit(OpCodes.Ldarg_1);
			il.Emit(OpCodes.Box, Module.GetTypeReference<int>());
			il.Emit(OpCodes.Ldarg_2);
			il.Emit(OpCodes.Ldarg_3);
			il.Emit(OpCodes.Box, Module.GetTypeReference<bool>());
			il.Emit(OpCodes.Call, Module.GetMethod<string>("Format", typeof(string), typeof(object), typeof(object), typeof(object)));
			il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

			VariableDefinition changedFlag = method.AddLocalVariable<bool>(Module);
			// Set 'changed' flag to false.
			il.EmitBool(false, changedFlag);

			Instruction ifElseLast = Instruction.Create(OpCodes.Ldstr, NO_EXPOSED_FIELDS);

			for (int i = 0; i < exposedFields.Count; i++)
			{
				VariableDefinition variable = method.AddLocalVariable(Module, exposedFields[i].FieldType);
				Instruction[] instructions = WriteSetField(exposedFields[i], variable);

				il.Append(instructions);
			}

			il.Append(ifElseLast);
			il.Emit(OpCodes.Ldarg_1);
			il.Emit(OpCodes.Box, Module.GetTypeReference<int>());
			il.Emit(OpCodes.Call, Module.GetMethod<string>("Format", typeof(string), typeof(object)));
			il.Emit(OpCodes.Call, Module.GetMethod(typeof(Debug), "LogWarning", typeof(object)));

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

						if (il.Body.Instructions[j].OpCode == OpCodes.Ldstr && il.Body.Instructions[j].Operand == ifElseLast.Operand)
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
			il.Emit(OpCodes.Callvirt, Module.ImportReference(typeof(Action<int, object>).GetMethod("Invoke", new[] { typeof(int), typeof(object) })));

			il.Append(ret);

			method.Body.Optimize();

			Instruction[] WriteSetField(FieldOrProperty field, VariableDefinition local)
			{
				// Write dummy 
				Instruction dummy = Instruction.Create(OpCodes.Ldarg_0);

				List<Instruction> i = new List<Instruction>
				{
					Instruction.Create(OpCodes.Ldarg_1),
					ILHelper.Int(field.id),
					Instruction.Create(OpCodes.Bne_Un_S, dummy)
				};

				if (field.IsComponent)
				{
					WriteComponent();
					return i.ToArray();
				}

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
					i.Add(ILHelper.Stloc(local));
					i.Add(Instruction.Create(OpCodes.Ldarg_0));
					i.Add(field.GetLoadInstruction());

					if (field.IsProperty)
					{
						VariableDefinition v = method.AddLocalVariable(Module, field.FieldType);

						i.Add(ILHelper.Stloc(v));
						i.Add(ILHelper.Ldloc(v, true));
					}

					i.Add(ILHelper.Ldloc(local));
				}

				// Equals check
				MethodReference equals;

				if (field.IsValueType && !field.IsCollection)
				{
					equals = GetEqualsMethod(field.FieldTypeResolved, out bool isSameEquals, out bool isInEquality);

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
					i.Add(ILHelper.Ldloc(local, true));
					i.Add(Instruction.Create(OpCodes.Call, equals));
					i.Add(Instruction.Create(OpCodes.Brtrue, last));
				}

#if ALE_DEBUG
				i.Add(Instruction.Create(OpCodes.Ldstr, field.Name + " changed from {0} to {1}."));
				i.Add(Instruction.Create(OpCodes.Ldarg_0));
				if (field.IsProperty)
				{
					i.Add(Instruction.Create(OpCodes.Call, field.property.GetMethod));
				}
				else
				{
					i.Add(Instruction.Create(OpCodes.Ldfld, field.field));
				}

				if (field.IsValueType)
				{
					i.Add(Instruction.Create(OpCodes.Box, field.FieldType));
				}

				i.Add(ILHelper.Ldloc(local));
				if (field.IsValueType)
				{
					i.Add(Instruction.Create(OpCodes.Box, field.FieldType));
				}

				i.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<string>("Format", typeof(string), typeof(object), typeof(object))));
				i.Add(Instruction.Create(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object))));
#endif

				i.Add(Instruction.Create(OpCodes.Ldarg_0));
				i.Add(ILHelper.Ldloc(local));
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
					if (type.IsSubclassOf<Object>())
					{
						fieldType = Module.ImportReference(typeof(Object));
					}

					if (!type.TryGetMethodWithParameters("Equals", out MethodReference equalsMethod, fieldType))
					{
						if (!type.TryGetMethodInBaseTypeWithParameters("Equals", out equalsMethod, fieldType))
						{
							if (!type.TryGetMethodWithParameters("op_Inequality", out equalsMethod, fieldType, fieldType))
							{
								if (!type.TryGetMethodInBaseTypeWithParameters("op_Inequality", out equalsMethod, fieldType, fieldType))
								{
									if (!type.TryGetMethodWithParameters("Equals", out equalsMethod, Module.ImportReference(typeof(object))))
									{
										equalsMethod = type.GetMethodInBaseType("Equals");
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

					if (equalsMethod.DeclaringType.Is<ValueType>())
					{
						isSameEquals = false;
						isInEquality = false;
						equalsMethod = Module.GetMethod<object>("Equals", typeof(object));
					}

					return equalsMethod;
				}

				void WriteComponent()
				{
					VariableDefinition localWrapper = method.AddLocalVariable<ComponentDataWrapper>();
					VariableDefinition value = method.AddLocalVariable(field.FieldType);

					i.Add(Instruction.Create(OpCodes.Ldarg_2));
					i.Add(Instruction.Create(OpCodes.Isinst, Module.GetTypeReference<ComponentDataWrapper>()));
					i.Add(Instruction.Create(OpCodes.Brfalse, last));

					i.Add(Instruction.Create(OpCodes.Ldarg_2));
					i.Add(Instruction.Create(OpCodes.Unbox_Any, Module.GetTypeReference<ComponentDataWrapper>()));

					i.Add(ILHelper.Stloc(localWrapper));
					i.Add(ILHelper.Ldloc(localWrapper, true));
					i.Add(Instruction.Create(OpCodes.Ldarg_0));
					i.Add(field.IsProperty ? Instruction.Create(OpCodes.Call, field.property.GetMethod) : Instruction.Create(OpCodes.Ldfld, field.field));
					if (field.IsCollection)
					{
						if (field.IsDictionary)
						{
							Error("You can't have a dictionary.");
						}

						i.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("Equals", field.CollectionType.Is<GameObject>() ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>))));
					}
					else
					{
						i.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("Equals", field.FieldType.Is<GameObject>() ? typeof(GameObject) : typeof(Component))));
					}

					i.Add(Instruction.Create(OpCodes.Brtrue, last));

					i.Add(Instruction.Create(OpCodes.Ldarg_0));

					if (field.IsCollection)
					{
						if (field.IsList)
						{
							i.Add(field.IsProperty ? Instruction.Create(OpCodes.Call, field.property.GetMethod) : Instruction.Create(OpCodes.Ldfld, field.field));
							MethodReference clear = Module.GetMethod(typeof(List<>), "Clear").MakeHostInstanceGeneric(Module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(field.CollectionType));
							i.Add(Instruction.Create(OpCodes.Callvirt, clear));
							i.Add(Instruction.Create(OpCodes.Ldarg_0));
							i.Add(field.IsProperty ? Instruction.Create(OpCodes.Call, field.property.GetMethod) : Instruction.Create(OpCodes.Ldfld, field.field));
							i.Add(ILHelper.Ldloc(localWrapper, true));
							i.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(field.CollectionType)));
							i.Add(Instruction.Create(OpCodes.Callvirt, Module.ImportReference(typeof(List<>).GetMethod("AddRange"))
							                                                 .MakeGenericMethod(Module.GetTypeReference(typeof(IEnumerable<>))
							                                                                          .MakeGenericInstanceType(field.CollectionType))
							                                                 .MakeHostInstanceGeneric(Module.GetTypeReference(typeof(List<>))
							                                                                                .MakeGenericInstanceType(field.CollectionType))));
						}
						else
						{
							i.Add(ILHelper.Ldloc(localWrapper, true));
							i.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(field.CollectionType)));
							i.Add(field.GetSetInstruction());
						}
					}
					else
					{
						i.Add(ILHelper.Ldloc(localWrapper, true));
						i.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObject", Array.Empty<Type>()).MakeGenericMethod(field.FieldType)));
						i.Add(field.GetSetInstruction());
					}

					i.Add(Instruction.Create(OpCodes.Ldc_I4_1));
					i.Add(ILHelper.Stloc(changedFlag));
					i.Add(Instruction.Create(OpCodes.Br, last));
				}
			}
		}

		private void CreateGetWrapper(IReadOnlyList<FieldOrProperty> fields)
		{
			MethodDefinition m = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.GetWrapper", MethodAttributes.Private | MethodAttributes.Final |
			                                                                                           MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetTypeReference<IExposedWrapper>());

			m.Overrides.Add(Module.GetMethod<IExposedToLevelEditor>("GetWrapper"));
			Type.Methods.Add(m);

			ILProcessor il = m.Body.GetILProcessor();

#if ALE_DEBUG
			il.Emit(OpCodes.Ldstr, $"{Type.FullName} Getting wrapper...");
			il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
			
			il.EmitLong(~(-1L << fields.Count));
			il.Emit(OpCodes.Conv_I8);

			for (int i = 0; i < fields.Count; i++)
			{
				il.Emit(OpCodes.Ldarg_0);
				if (fields[i].IsProperty)
				{
					il.Emit(OpCodes.Call, fields[i].property.GetMethod);
				}
				else
				{
					il.Emit(OpCodes.Ldfld, fields[i].field);
				}

				if (fields[i].IsComponent)
				{
					if (fields[i].IsCollection)
					{
						il.Emit(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(fields[i].IsGameObject ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>)));
					}
					else
					{
						il.Emit(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(fields[i].IsGameObject ? typeof(GameObject) : typeof(Component)));
					}
				}
			}

			il.Emit(OpCodes.Newobj, wrapperCtor);
#if ALE_DEBUG
			il.Emit(OpCodes.Ldstr, $"{Type.FullName} Returning wrapper");
			il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
			il.Emit(OpCodes.Box, wrapper);
			il.Emit(OpCodes.Ret);

			m.Body.Optimize();
		}

		private void CreateApplyWrapper(IReadOnlyList<FieldOrProperty> fields)
		{
			MethodDefinition m = new MethodDefinition("Hertzole.ALE.IExposedToLevelEditor.ApplyWrapper",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetTypeReference(typeof(void)));

			Type.Methods.Add(m);
			m.Overrides.Add(Module.GetMethod<IExposedToLevelEditor>("ApplyWrapper", typeof(IExposedWrapper), typeof(bool)));
			ParameterDefinition wrapperPar = m.AddParameter<IExposedWrapper>("wrapper");
			ParameterDefinition ignoreDirtyMaskPar = m.AddParameter<bool>("ignoreDirtyMask");
			VariableDefinition wrapperVar = m.AddLocalVariable(wrapper);

			ignoreDirtyMaskPar.IsOptional = true;
			ignoreDirtyMaskPar.HasDefault = true;
			ignoreDirtyMaskPar.Constant = false;
			
			ILProcessor il = m.Body.GetILProcessor();

			m.Body.InitLocals = true;

			il.EmitLdarg(wrapperPar);
			il.Emit(OpCodes.Isinst, wrapper);

			il.EmitLdarg(wrapperPar);
			il.Emit(OpCodes.Unbox_Any, wrapper);
			il.EmitStloc(wrapperVar);

			Instruction previous = null;

			for (int i = 0; i < fields.Count; i++)
			{
				Instruction start = il.EmitLdarg(ignoreDirtyMaskPar);

				il.EmitLdloc(wrapperVar);
				il.Emit(OpCodes.Ldfld, dirtyMaskField);
				il.EmitLong(1L << i);
				il.Emit(OpCodes.Conv_I8);
				Instruction and = Instruction.Create(OpCodes.And);
				il.Append(and);
				if (previous != null)
				{
					il.InsertAfter(previous, Instruction.Create(OpCodes.Brfalse, start));
				}

				previous = and;
				
				// field = wrapper.field.Item2;
				FieldReference item2 = Module.ImportReference(typeof(ValueTuple<,>).GetField("Item2"));
				item2.DeclaringType = Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(Module.GetTypeReference<int>(), fields[i].FieldTypeComponentAware);

				bool setField = true;
				
#if ALE_DEBUG
				Instruction setFieldStart;
				if (fields[i].FieldType.Is<string>())
				{
					setFieldStart = Instruction.Create(OpCodes.Ldstr, "Apply value on stringTest: ");
					il.Append(setFieldStart);
					il.EmitLdloc(wrapperVar);
					FieldReference valueField = wrapper.GetField(fields[i].Name);
					il.Emit(OpCodes.Ldfld, valueField);
					il.Emit(OpCodes.Ldfld, item2);
					il.Emit(OpCodes.Call, Module.GetMethod<string>("Concat", typeof(string), typeof(string)));
				}
				else
				{
					setFieldStart = Instruction.Create(OpCodes.Ldstr, $"Apply value on {fields[i].Name}: {{0}}");
					il.Append(setFieldStart);
					il.EmitLdloc(wrapperVar);
					il.Emit(OpCodes.Ldfld, wrapper.GetField(fields[i].Name));
					il.Emit(OpCodes.Ldfld, item2);
					il.Emit(OpCodes.Box, fields[i].IsComponent ? Module.GetTypeReference<ComponentDataWrapper>() : fields[i].FieldType);
					il.Emit(OpCodes.Call, Module.GetMethod<string>("Format", typeof(string), typeof(object)));
				}
				
				il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
				il.EmitLdarg();
#else
				Instruction setFieldStart = il.EmitLdarg();
#endif
				
				il.InsertAfter(start, Instruction.Create(OpCodes.Brtrue, setFieldStart));

				if (fields[i].IsComponent)
				{
					if (fields[i].IsCollection)
					{
						if (fields[i].IsList)
						{
							setField = false;
							
							// field.Clear();
							if (fields[i].IsProperty)
							{
								il.Emit(OpCodes.Call, fields[i].property.GetMethod);
							}
							else
							{
								il.Emit(OpCodes.Ldfld, fields[i].field);
							}
							MethodReference clear = Module.GetMethod(typeof(List<>), "Clear").MakeHostInstanceGeneric(Module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(fields[i].CollectionType));
							il.Emit(OpCodes.Callvirt, clear);
							
							// field.AddRange(wrapper.field.Item2.GetObjects<Type>());
							il.EmitLdarg();
							if (fields[i].IsProperty)
							{
								il.Emit(OpCodes.Call, fields[i].property.GetMethod);
							}
							else
							{
								il.Emit(OpCodes.Ldfld, fields[i].field);
							}

							il.EmitLdloc(wrapperVar, true);
							il.Emit(OpCodes.Ldflda, wrapper.GetField(fields[i].Name));
							il.Emit(OpCodes.Ldflda, item2);
							il.Emit(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(fields[i].CollectionType));
							il.Emit(OpCodes.Callvirt, Module.ImportReference(typeof(List<>).GetMethod("AddRange"))
		                                                     .MakeGenericMethod(Module.GetTypeReference(typeof(IEnumerable<>))
		                                                     .MakeGenericInstanceType(fields[i].CollectionType))
		                                                     .MakeHostInstanceGeneric(Module.GetTypeReference(typeof(List<>))
		                                                     .MakeGenericInstanceType(fields[i].CollectionType)));
						}
						else
						{
							il.EmitLdloc(wrapperVar, true);
							il.Emit(OpCodes.Ldflda, wrapper.GetField(fields[i].Name));
							il.Emit(OpCodes.Ldflda, item2);
							il.Emit(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(fields[i].CollectionType));
						}
					}
					else
					{
						il.EmitLdloc(wrapperVar, true);
						il.Emit(OpCodes.Ldflda, wrapper.GetField(fields[i].Name));
						il.Emit(OpCodes.Ldflda, item2);
						il.Emit(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObject", Array.Empty<Type>()).MakeGenericMethod(fields[i].FieldType));
					}
				}
				else
				{
					il.EmitLdloc(wrapperVar);
					il.Emit(OpCodes.Ldfld, wrapper.GetField(fields[i].Name));
					il.Emit(OpCodes.Ldfld, item2);
				}

				if (setField)
				{
					if (fields[i].IsProperty)
					{
						il.Emit(OpCodes.Call, fields[i].property.SetMethod);
					}
					else
					{
						il.Emit(OpCodes.Stfld, fields[i].field);
					}	
				}
			}

			Instruction ret = Instruction.Create(OpCodes.Ret);
			il.Append(ret);
			il.InsertAfter(il.Body.Instructions[1], Instruction.Create(OpCodes.Brfalse, ret));

			if (previous != null)
			{
				il.InsertAfter(previous, Instruction.Create(OpCodes.Brfalse, ret));
			}

			m.Body.Optimize();
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

		internal struct FieldOrProperty
		{
			public FieldDefinition field;
			public PropertyDefinition property;

			public string customName;
			public bool visible;
			public int order;
			public int id;

			public string Name
			{
				get
				{
					if (field != null)
					{
						return field.Name;
					}

					return property.Name;
				}
			}
			public TypeReference FieldType
			{
				get
				{
					// Use ImportReference just in case to avoid any "X is in another module" errors.
					if (field != null)
					{
						return field.Module.ImportReference(field.FieldType);
					}

					return property.Module.ImportReference(property.PropertyType);
				}
			}

			public TypeDefinition FieldTypeResolved { get { return field != null ? field.FieldType.Resolve() : property.PropertyType.Resolve(); } }

			public TypeDefinition FieldTypeResolvedComponentAware { get { return FieldTypeComponentAware.Resolve(); } }

			public TypeReference FieldTypeComponentAware
			{
				get
				{
					TypeReference fieldType = FieldType.GetCollectionType();

					if (fieldType.Is<GameObject>())
					{
						return (IsProperty ? property.Module : field.Module).GetTypeReference<ComponentDataWrapper>();
					}
					else
					{
						TypeDefinition resolved = fieldType.Resolve();
						if (resolved != null && resolved.IsSubclassOf<Component>())
						{
							return (IsProperty ? property.Module : field.Module).GetTypeReference<ComponentDataWrapper>();
						}
					}

					return FieldType;
				}
			}
			public bool IsProperty { get { return field == null && property != null; } }
			public bool IsClass { get { return FieldTypeResolvedComponentAware.IsClass; } }
			public bool IsValueType { get { return FieldTypeComponentAware.IsValueType; } }
			public bool IsPrimitive { get { return FieldTypeComponentAware.IsPrimitive; } }

			public bool IsEnum { get { return FieldType.IsEnum(); } }
			public bool IsGameObject { get { return FieldType.IsGameObject(); } }
			public bool IsComponent { get { return FieldType.IsComponent(); } }
			public bool IsArray { get { return FieldType.IsArray(); } }
			public bool IsList { get { return FieldType.IsList(); } }
			public bool IsDictionary { get { return FieldType.IsDictionary(); } }
			public bool IsCollection { get { return FieldType.IsCollection(); } }

			public TypeReference CollectionType { get { return FieldType.GetCollectionType(); } }

			public Instruction GetLoadInstruction()
			{
				if (IsProperty)
				{
					return Instruction.Create(OpCodes.Call, property.GetMethod);
				}

				return Instruction.Create(IsValueType && !FieldType.IsCollection() ? OpCodes.Ldflda : OpCodes.Ldfld, field);
			}

			public Instruction GetSetInstruction()
			{
				if (IsProperty)
				{
					return Instruction.Create(OpCodes.Call, property.SetMethod);
				}

				return Instruction.Create(OpCodes.Stfld, field);
			}

			public FieldOrProperty(CustomAttribute attribute)
			{
				field = null;
				property = null;

				id = attribute.GetConstructorArgument(0, 0);
				customName = attribute.GetField<string>(nameof(ExposeToLevelEditorAttribute.customName), null);
				visible = attribute.GetField(nameof(ExposeToLevelEditorAttribute.visible), true);
				order = 0;
			}

			public bool TryGetAttributes<T>(out CustomAttribute[] attributes) where T : Attribute
			{
				if (field != null)
				{
					return field.TryGetAttributes<T>(out attributes);
				}

				return property.TryGetAttributes<T>(out attributes);
			}
		}
	}
}