using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Hertzole.ALE.CodeGen.Data;
using Hertzole.ALE.CodeGen.Helpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using UnityEngine;
using Object = System.Object;

namespace Hertzole.ALE.CodeGen
{
	public class ExposedPropertyProcessor : BaseProcessor
	{
		private readonly List<IExposedProperty> resultExposedProperties = new List<IExposedProperty>();
		private readonly List<int> usedIds = new List<int>();
		private readonly List<Instruction> instructions = new List<Instruction>();

		private FieldDefinition editingIdField;
		private FieldDefinition beginEditValueField;
		private FieldDefinition lastModifyValueField;

		private FieldDefinition valueChangingField;
		private FieldDefinition valueChangedField;

		private FieldDefinition propertiesListField;
		private FieldDefinition cachedPropertiesField;

		private MethodDefinition beginEditMethod;
		private MethodDefinition modifyValueMethod;
		private MethodDefinition getPropertiesMethod;

		private WrapperData wrapperData;

		public override bool IsValidClass(TypeDefinition type)
		{
			if (type.ImplementsInterface<IExposedToLevelEditor>())
			{
				return false;
			}

			return HasExposedProperties(type);
		}

		public override void ProcessClass(TypeDefinition type)
		{
			editingIdField = null;
			beginEditValueField = null;
			lastModifyValueField = null;

			beginEditMethod = null;
			modifyValueMethod = null;
			getPropertiesMethod = null;

			wrapperData = null;

			if (type.ImplementsInterface<IExposedToLevelEditor>())
			{
				return;
			}

			IReadOnlyList<IExposedProperty> properties = GetExposedProperties(type);
			if (properties == null)
			{
				return;
			}

			bool hasVisibleFields = false;
			for (int i = 0; i < properties.Count; i++)
			{
				if (properties[i].Visible)
				{
					hasVisibleFields = true;
					break;
				}
			}

			Type.Interfaces.Add(new InterfaceImplementation(Module.GetTypeReference<IExposedToLevelEditor>()));

			wrapperData = WrapperProcessor.CreateWrapper(Type, properties);
			Formatters.CreateExposedFormatter(Type, properties, wrapperData);

			valueChangingField = CreateEvent(nameof(IExposedToLevelEditor.OnValueChanging));
			valueChangedField = CreateEvent(nameof(IExposedToLevelEditor.OnValueChanged));

			CreateProperty<string>("ComponentName", Type.Name);
			CreateProperty<string>("TypeName", Type.FullName);
			CreateProperty<int>("Order", 0);
			CreateProperty<Type>("ComponentType", Type);
			CreateProperty<bool>("HasVisibleFields", hasVisibleFields);

			CreateBeginEdit(properties);
			CreateModifyValue(properties);
			CreateEndEdit();
			CreateGetProperties(properties);
			CreateGetValue(properties);
			CreateGetWrapper(properties);
			CreateApplyWrapper(properties);
		}

		private FieldDefinition CreateEvent(string eventName)
		{
			TypeReference action = Module.ImportReference(typeof(Action<int, object>));
			CustomAttribute compilerGenerated = new CustomAttribute(Module.ImportReference(typeof(CompilerGeneratedAttribute).GetConstructor(Array.Empty<Type>())));

			FieldDefinition eventField;
			MethodDefinition addMethod;
			MethodDefinition removeMethod;

			CreateInternalEvent();
			CreateOverrideEvent();

			return eventField;

			void CreateInternalEvent()
			{
				EventDefinition resultEvent = new EventDefinition($"ALE__GENERATED__EVENT__{eventName}", EventAttributes.None, action);
				eventField = Type.AddField($"ALE__GENERATED__EVENT__{eventName}", FieldAttributes.Private, action);
				eventField.CustomAttributes.Add(compilerGenerated);

				addMethod = CreateAddRemoveMethod($"add_ALE__GENERATED__EVENT__{eventName}", false);
				removeMethod = CreateAddRemoveMethod($"remove_ALE__GENERATED__EVENT__{eventName}", true);

				resultEvent.AddMethod = addMethod;
				resultEvent.RemoveMethod = removeMethod;

				Type.Events.Add(resultEvent);
			}

			MethodDefinition CreateAddRemoveMethod(string name, bool remove)
			{
				MethodDefinition method = Type.AddMethod(name, MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName);
				method.CustomAttributes.Add(compilerGenerated);

				// method.Parameters.Add(new ParameterDefinition("value", ParameterAttributes.None, action));
				ParameterDefinition paraValue = method.AddParameter(action, "value");

				ILProcessor il = method.BeginEdit();
				il.Body.InitLocals = true;

				VariableDefinition varLocal1 = method.AddLocalVariable(action);
				VariableDefinition varLocal2 = method.AddLocalVariable(action);
				VariableDefinition varLocal3 = method.AddLocalVariable(action);

				// Action<int, object> action = this.GENERATED__EVENT;
				il.EmitLdarg();
				il.Emit(OpCodes.Ldfld, eventField);
				il.EmitStloc(varLocal1);

				// Loop start
				// Action<int, object> action2 = action;
				Instruction loopStart = il.EmitLdloc(varLocal1);
				il.EmitStloc(varLocal2);
				// Action<int, object> value2 = (Action<int, object>) Delegate.Combine/Remove(action2, value);
				il.EmitLdloc(varLocal2);
				il.EmitLdarg(paraValue);
				il.Emit(OpCodes.Call, Module.GetMethod<Delegate>(remove ? nameof(Delegate.Remove) : nameof(Delegate.Combine), typeof(Delegate), typeof(Delegate)));
				il.Emit(OpCodes.Castclass, action);
				il.EmitStloc(varLocal3);
				// action = Interlocked.CompareExchange(ref this.GENERATED__EVENT, value2, action2);
				il.EmitLdarg();
				il.Emit(OpCodes.Ldflda, eventField);
				il.EmitLdloc(varLocal3);
				il.EmitLdloc(varLocal2);
				il.Emit(OpCodes.Call, Module.GetGenericMethod(typeof(Interlocked), nameof(Interlocked.CompareExchange), action));
				il.EmitStloc(varLocal1);
				// if ((object) action == action2)
				il.EmitLdloc(varLocal1);
				il.EmitLdloc(varLocal2);
				il.Emit(OpCodes.Bne_Un, loopStart);

				// End loop
				// End method
				il.Emit(OpCodes.Ret);

				method.EndEdit();

				return method;
			}

			void CreateOverrideEvent()
			{
				EventDefinition e = new EventDefinition($"IExposedToLevelEditor.{eventName}", EventAttributes.None, action);

				MethodDefinition eAdd = CreateOverrideEventAddRemoveMethod(false, addMethod);
				MethodDefinition eRemove = CreateOverrideEventAddRemoveMethod(true, removeMethod);

				e.AddMethod = eAdd;
				e.RemoveMethod = eRemove;

				Type.Events.Add(e);
			}

			MethodDefinition CreateOverrideEventAddRemoveMethod(bool remove, MethodReference targetMethod)
			{
				MethodDefinition m = Type.AddMethodOverride($"Hertzole.ALE.IExposedToLevelEditor.{(remove ? "remove" : "add")}_{eventName}",
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					Module.GetMethod<IExposedToLevelEditor>($"{(remove ? "remove" : "add")}_{eventName}", typeof(Action<int, object>)));

				ParameterDefinition paraValue = m.AddParameter<Action<int, object>>("value");

				ILProcessor il = m.BeginEdit();

				// GENERATED__EVENT +-= value;
				il.EmitLdarg();
				il.EmitLdarg(paraValue);
				il.Emit(OpCodes.Call, targetMethod);
				il.Emit(OpCodes.Ret);

				m.EndEdit();

				return m;
			}
		}

		private PropertyDefinition CreateProperty<T>(string name, object value)
		{
			PropertyDefinition p = Type.AddProperty<T>(name, PropertyAttributes.None);
			MethodDefinition getMethod = Type.AddMethodOverride<T>($"Hertzole.ALE.IExposedToLevelEditor.get_{name}",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetMethod<IExposedToLevelEditor>($"get_{name}"));

			p.GetMethod = getMethod;

			ILProcessor il = getMethod.BeginEdit();

			if (typeof(T) == typeof(string))
			{
				il.Emit(OpCodes.Ldstr, (string) value);
			}
			else if (typeof(T) == typeof(int))
			{
				il.EmitInt((int) value);
			}
			else if (typeof(T) == typeof(bool))
			{
				il.EmitBool((bool) value);
			}
			else if (typeof(T) == typeof(Type))
			{
				il.Emit(OpCodes.Ldtoken, (TypeReference) value);
				il.Emit(OpCodes.Call, Module.ImportReference(typeof(Type).GetMethod("GetTypeFromHandle", new[] { typeof(RuntimeTypeHandle) })));
			}
			else
			{
				throw new NotSupportedException($"No support for creating a property of type {typeof(T)}.");
			}

			il.Emit(OpCodes.Ret);

			getMethod.EndEdit();

			return p;
		}

		private void CreateBeginEdit(IReadOnlyList<IExposedProperty> properties)
		{
			MethodDefinition m = Type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.BeginEdit", // Name
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual, // Attributes
				Module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.BeginEdit), typeof(int))); // Override methods

			editingIdField = Type.AddField<int>("ALE__GENERATED_editingId", FieldAttributes.Private);
			beginEditValueField = Type.AddField<object>("ALE__GENERATED__beginEditValue", FieldAttributes.Private);

			ParameterDefinition paraId = m.AddParameter<int>("id");

			CreateBeginEditHelperMethod();

			ILProcessor il = m.BeginEdit();

			// ALE__GENERATED__editingId = id;
			il.EmitLdarg();
			il.EmitLdarg(paraId);
			il.Emit(OpCodes.Stfld, editingIdField);

			il.EmitIfElse((last, list) =>
			{
				// if (!ALE__GENERATED__BeginEdit(id))
				list.Add(ILHelper.Ldarg(il));
				list.Add(ILHelper.Ldarg(il, paraId));
				list.Add(Instruction.Create(OpCodes.Callvirt, beginEditMethod));
				list.Add(Instruction.Create(OpCodes.Brtrue, last));
			}, (last, list) =>
			{
				// throw new InvalidExposedPropertyException(id);
				list.Add(ILHelper.Ldarg(il, paraId));
				list.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<InvalidExposedPropertyException>(typeof(int))));
				list.Add(Instruction.Create(OpCodes.Throw));
			}, list =>
			{
				// End method
				list.Add(Instruction.Create(OpCodes.Ret));
			});

			m.EndEdit();

			void CreateBeginEditHelperMethod()
			{
				beginEditMethod = Type.AddMethod<bool>("ALE__GENERATED__BeginEdit", MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);
				ParameterDefinition localParaId = beginEditMethod.AddParameter<int>("id");

				ILProcessor localIl = beginEditMethod.BeginEdit();

				localIl.EmitIfElse(properties, (item, index, target, fill) =>
				{
					// if (id == something)
					fill.Add(ILHelper.Ldarg(localIl, localParaId));
					if (item.Id == 0)
					{
						fill.Add(Instruction.Create(OpCodes.Brtrue, target));
					}
					else
					{
						fill.Add(ILHelper.Int(item.Id));
						fill.Add(Instruction.Create(OpCodes.Bne_Un, target));
					}
				}, (item, index, last, fill) =>
				{
					// ALE__GENERATED__beginEditValue = value;
					fill.Add(ILHelper.Ldarg(localIl));
					fill.Add(ILHelper.Ldarg(localIl)); // Not a typo
					fill.Add(item.GetLoadInstruction());
					if (item.IsComponent)
					{
						if (item.IsCollection)
						{
							fill.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>))));
						}
						else
						{
							fill.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(GameObject) : typeof(Component))));
						}
					}
					if (item.IsValueType)
					{
						fill.Add(Instruction.Create(OpCodes.Box, item.FieldTypeComponentAware));
					}

					fill.Add(Instruction.Create(OpCodes.Stfld, beginEditValueField));
					// return true;
					fill.Add(ILHelper.Bool(true));
					fill.Add(Instruction.Create(OpCodes.Ret));
				}, fill =>
				{
					// return false;
					fill.Add(ILHelper.Bool(false));
					fill.Add(Instruction.Create(OpCodes.Ret));
				});

				beginEditMethod.EndEdit();
			}
		}

		private void CreateModifyValue(IReadOnlyList<IExposedProperty> properties)
		{
			MethodDefinition m = Type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.ModifyValue", // Name
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual, // Attributes
				Module.GetMethod<IExposedToLevelEditor>("ModifyValue", typeof(object), typeof(bool))); // Overrides

			lastModifyValueField = Type.AddField<object>("ALE__GENERATED__lastModifyValue", FieldAttributes.Private);

			ParameterDefinition paraValue = m.AddParameter<object>("value");
			ParameterDefinition paraNotify = m.AddParameter<bool>("notify");

			CreateModifyValueHelperMethod();

			ILProcessor il = m.BeginEdit();

			VariableDefinition varChanged = m.AddLocalVariable<bool>("changed");

			// changed = false;
			il.EmitBool(false, varChanged);

			Instruction methodEnd = null;

			il.EmitIfElse((target, list) =>
			{
				// if (ALE__GENERATED__ModifyValue(value, ref changed)
				list.Add(ILHelper.Ldarg(il));
				list.Add(ILHelper.Ldarg(il, paraValue));
				list.Add(ILHelper.Ldloc(varChanged, true));
				list.Add(Instruction.Create(OpCodes.Callvirt, modifyValueMethod));
				list.Add(Instruction.Create(OpCodes.Brfalse, target));
			}, (last, list) =>
			{
				// if (notify && changed)
				list.Add(ILHelper.Ldarg(il, paraNotify));
				list.Add(ILHelper.Ldloc(varChanged));
				list.Add(Instruction.Create(OpCodes.And));
				list.Add(Instruction.Create(OpCodes.Brfalse, methodEnd));

				list.AddRange(ILHelper.IfElse((target, fill) =>
				{
					// OnValueChanging = this.ALE__GENERATED__OnValueChanging;
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(Instruction.Create(OpCodes.Ldfld, valueChangingField));

					// if (OnValueChanging != null)
					fill.Add(Instruction.Create(OpCodes.Dup));
					fill.Add(Instruction.Create(OpCodes.Brtrue, target));
				}, (target, fill) =>
				{
					// return;
					fill.Add(Instruction.Create(OpCodes.Pop));
					fill.Add(Instruction.Create(OpCodes.Ret));
				}, fill =>
				{
					// OnValueChanging(ALE__GENERATED_editingId, value);
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
					fill.Add(ILHelper.Ldarg(il, paraValue));
					fill.Add(Instruction.Create(OpCodes.Callvirt, Module.GetMethod<Action<int, object>>("Invoke", typeof(int), typeof(object))));
					fill.Add(Instruction.Create(OpCodes.Ret));
				}));
			}, list =>
			{
				// throw new Hertzole.ALE.InvalidExposedPropertyException(ALE__GENERATED__editingId);
				list.Add(ILHelper.Ldarg(il));
				list.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
				list.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<InvalidExposedPropertyException>(typeof(int))));
				list.Add(Instruction.Create(OpCodes.Throw));

				methodEnd = Instruction.Create(OpCodes.Ret);
				list.Add(methodEnd);
			});

			m.EndEdit();

			void CreateModifyValueHelperMethod()
			{
				modifyValueMethod = Type.AddMethod<bool>("ALE__GENERATED__ModifyValue", MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);
				ParameterDefinition localParaValue = modifyValueMethod.AddParameter<object>("value");
				ParameterDefinition localParaChanged = modifyValueMethod.AddParameter(Module.ImportReference(typeof(bool).MakeByRefType()), "changed");

				ILProcessor localIl = modifyValueMethod.BeginEdit();

				modifyValueMethod.Body.InitLocals = true;

				VariableDefinition[] localVariables = new VariableDefinition[properties.Count];
				for (int i = 0; i < localVariables.Length; i++)
				{
					localVariables[i] = modifyValueMethod.AddLocalVariable(properties[i].FieldTypeComponentAware);
				}

				localIl.EmitIfElse(properties, (item, index, target, fill) =>
				{
					// if (ALE__GENERATED__editingID == id)
					fill.Add(ILHelper.Ldarg(localIl));
					fill.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
					if (item.Id == 0)
					{
						fill.Add(Instruction.Create(OpCodes.Brtrue, target));
					}
					else
					{
						fill.Add(ILHelper.Int(item.Id));
						fill.Add(Instruction.Create(OpCodes.Bne_Un, target));
					}
				}, (item, index, last, fill) =>
				{
					MethodReference equals = Module.ImportReference(item.FieldTypeResolved.GetEqualsMethod(out bool isInEquality));

					if (item.IsComponent)
					{
						// ComponentDataWrapper wrapper = (ComponentDataWrapper) value;
						fill.Add(ILHelper.Ldarg(localIl, localParaValue));
						fill.Add(Instruction.Create(OpCodes.Isinst, Module.GetTypeReference<ComponentDataWrapper>()));
						fill.Add(Instruction.Create(OpCodes.Brfalse, last));

						fill.Add(ILHelper.Ldarg(localIl, localParaValue));
						fill.Add(Instruction.Create(OpCodes.Unbox_Any, Module.GetTypeReference<ComponentDataWrapper>()));
						fill.Add(ILHelper.Stloc(localVariables[index]));
						
						// if (!wrapper.Equals(value))
						fill.Add(ILHelper.Ldloc(localVariables[index], true));
						fill.Add(ILHelper.Ldarg(localIl));
						fill.Add(item.GetLoadInstruction());
						if (item.IsCollection)
						{
							if (item.IsDictionary)
							{
								Error("You can't have a dictionary.");
								return;
							}

							fill.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("Equals", item.FieldType.GetCollectionType().Is<GameObject>() ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>))));
						}
						else
						{
							fill.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("Equals", item.FieldType.Is<GameObject>() ? typeof(GameObject) : typeof(Component))));
						}

						fill.Add(Instruction.Create(OpCodes.Brtrue, last));
						fill.Add(ILHelper.Ldarg(localIl));

						if (item.IsCollection)
						{
							if (item.IsList)
							{
								Instruction addStart = ILHelper.Ldarg(localIl);
								
								fill.AddRange(ILHelper.IfElse((last, list) =>
								{
									// if (value == null)
									list.Add(item.GetLoadInstruction());
									list.Add(Instruction.Create(OpCodes.Brtrue, last));
								}, (last, list) =>
								{
									// value = new List<Type>();
									list.Add(ILHelper.Ldarg(localIl));
									list.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor(typeof(List<>)).MakeHostInstanceGeneric(
										Module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(item.FieldType.GetCollectionType()))));
									list.Add(item.GetSetInstruction());
									list.Add(Instruction.Create(OpCodes.Br, addStart));
								}, list =>
								{
									// value.Clear();	
									list.Add(ILHelper.Ldarg(localIl));
									list.Add(item.GetLoadInstruction());
									list.Add(Instruction.Create(OpCodes.Callvirt, Module.GetMethod(typeof(List<>), "Clear").MakeHostInstanceGeneric(
										Module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(item.FieldType.GetCollectionType()))));
								}));
								
								// value.AddRange(wrapper.GetObjects<Type>());
								fill.Add(addStart);
								fill.Add(item.GetLoadInstruction());
								fill.Add(ILHelper.Ldloc(localVariables[index], true));
								fill.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(item.FieldType.GetCollectionType())));
								fill.Add(Instruction.Create(OpCodes.Callvirt, Module.GetMethod(typeof(List<>), "AddRange").MakeHostInstanceGeneric(
									Module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(item.FieldType.GetCollectionType()))));
							}
							else
							{
								// valueArray = wrapper.GetObjects<Type>();
								fill.Add(ILHelper.Ldloc(localVariables[index], true));
								fill.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(item.FieldType.GetCollectionType())));
								fill.Add(item.GetSetInstruction());
							}
							
							// ALE__GENERATED__lastModifyValue = wrapper;
                            fill.Add(ILHelper.Ldarg(localIl));
                            fill.Add(ILHelper.Ldloc(localVariables[index]));
                            fill.Add(Instruction.Create(OpCodes.Box, Module.GetTypeReference<ComponentDataWrapper>()));
                            fill.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));
						}
						else
						{
							fill.Add(ILHelper.Ldloc(localVariables[index], true));
							fill.Add(Instruction.Create(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObject", Array.Empty<Type>()).MakeGenericMethod(item.FieldType.GetCollectionType())));
							fill.Add(item.GetSetInstruction());
						}
					}
					else if (!item.IsValueType && !item.IsCollection)
					{
						// Type var = value as Type;
						fill.Add(ILHelper.Ldarg(localIl, localParaValue));
						fill.Add(Instruction.Create(OpCodes.Isinst, item.FieldTypeComponentAware));
						fill.Add(ILHelper.Stloc(localVariables[index]));
						
						// if (var != null)
						fill.Add(ILHelper.Ldloc(localVariables[index]));
						fill.Add(Instruction.Create(OpCodes.Brfalse, last));
						
						// value = var;
						fill.Add(ILHelper.Ldarg(localIl));
						fill.Add(ILHelper.Ldloc(localVariables[index]));
						fill.Add(item.GetSetInstruction());
						
						// ALE__GENERATED__lastModifyValue = var;
						fill.Add(ILHelper.Ldarg(localIl));
						fill.Add(ILHelper.Ldloc(localVariables[index]));
						fill.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));
					}
					else if (item.IsValueType && !item.IsCollection)
					{
						// if (value is Type)
						fill.Add(ILHelper.Ldarg(localIl, localParaValue));
						fill.Add(Instruction.Create(OpCodes.Isinst, item.FieldTypeComponentAware));
						fill.Add(Instruction.Create(OpCodes.Brfalse, last));

						// int var = (Type) value;
						fill.Add(ILHelper.Ldarg(localIl, localParaValue));
						fill.Add(Instruction.Create(OpCodes.Unbox_Any, item.FieldTypeComponentAware));
						fill.Add(ILHelper.Stloc(localVariables[index]));

						bool objectEquals = equals.DeclaringType.FullName == Module.GetTypeReference<object>().FullName;
						
						// if (localVar != var)
						fill.Add(ILHelper.Ldarg(localIl));
						fill.Add(item.GetLoadInstruction(!item.FieldType.IsPrimitive && !isInEquality));
						// If we're not doing inequality check and it's a property that is also a value type but is not a primitive,
						// create a new local variable for some reason and set it and load it, then never talk about it again.
						if (!isInEquality && item.IsProperty && item.IsValueType && !item.IsPrimitive)
						{
							VariableDefinition propertyVar = modifyValueMethod.AddLocalVariable(item.FieldTypeComponentAware);
							fill.Add(ILHelper.Stloc(propertyVar));
							fill.Add(ILHelper.Ldloc(propertyVar, true));
						}
						fill.Add(ILHelper.Ldloc(localVariables[index]));
						if (!item.FieldType.IsPrimitive)
						{
							// If it's a value type and it's using the generic Equals(object), it needs to be boxed.
							if (item.IsValueType && objectEquals)
                            {
                            	fill.Add(Instruction.Create(OpCodes.Box, item.FieldTypeComponentAware));
                            }

							// If it's using Equals(object), it need to be constrained and whatnot.
							// Else just call equals method.
							if (objectEquals)
							{
								fill.Add(Instruction.Create(OpCodes.Constrained, item.FieldTypeComponentAware));
								fill.Add(Instruction.Create(OpCodes.Callvirt, equals));
							}
							else
							{
								fill.Add(Instruction.Create(OpCodes.Call, equals));
							}
							
							fill.Add(Instruction.Create(isInEquality ? OpCodes.Brfalse : OpCodes.Brtrue, last));
						}
						else
						{
							fill.Add(Instruction.Create(OpCodes.Beq, last));
						}

						// localVar = var;
						fill.Add(ILHelper.Ldarg(localIl));
						fill.Add(ILHelper.Ldloc(localVariables[index]));
						fill.Add(item.GetSetInstruction());
					}
					
					// ALE__GENERATED__lastModifyValue = var;
                    fill.Add(ILHelper.Ldarg(localIl));
                    fill.Add(ILHelper.Ldloc(localVariables[index]));
                    fill.Add(Instruction.Create(OpCodes.Box, item.FieldTypeComponentAware));
                    fill.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));
					
					// changed = true;
					fill.Add(ILHelper.Ldarg(localIl, localParaChanged));
					fill.Add(ILHelper.Bool(true));
					fill.Add(Instruction.Create(OpCodes.Stind_I1));

					// return true;
					fill.Add(ILHelper.Bool(true));
					fill.Add(Instruction.Create(OpCodes.Ret));
				}, fill =>
				{
					fill.Add(ILHelper.Bool(false));
					fill.Add(Instruction.Create(OpCodes.Ret));
				});

				modifyValueMethod.EndEdit();
			}
		}

		private void CreateEndEdit()
		{
			MethodDefinition m = Type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.EndEdit",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.EndEdit), typeof(bool), typeof(ILevelEditorUndo)));

			ParameterDefinition paraNotify = m.AddParameter<bool>("notify");
			ParameterDefinition paraUndo = m.AddParameter<ILevelEditorUndo>("undo");

			ILProcessor il = m.BeginEdit();

			il.EmitIfElse((last, list) =>
			{
				// if (notify)
				list.Add(ILHelper.Ldarg(il, paraNotify));
				list.Add(Instruction.Create(OpCodes.Brfalse, last));
			}, (last, list) =>
			{
				// OnValueChanged = this.ALE__GENERATED__OnValueChanged;
				list.Add(ILHelper.Ldarg(il));
				list.Add(Instruction.Create(OpCodes.Ldfld, valueChangedField));
				list.AddRange(ILHelper.IfElse((localLast, localList) =>
				{
					// if (OnValueChanged != null)
					localList.Add(Instruction.Create(OpCodes.Dup));
					localList.Add(Instruction.Create(OpCodes.Brtrue, localLast));
				}, (localLast, localList) =>
				{
					localList.Add(Instruction.Create(OpCodes.Pop));
					localList.Add(Instruction.Create(OpCodes.Br, last));
				}, localList =>
				{
					// OnValueChanged.Invoke(ALE__GENERATED__editingId, ALE__GENERATED__lastModifyValue);
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, lastModifyValueField));
					localList.Add(Instruction.Create(OpCodes.Callvirt, Module.GetMethod<Action<int, object>>("Invoke", typeof(int), typeof(object))));
				}));
			}, list =>
			{
				// if (undo != null)
				list.AddRange(ILHelper.IfElse((localLast, localList) =>
				{
					localList.Add(ILHelper.Ldarg(il, paraUndo));
					localList.Add(Instruction.Create(OpCodes.Brfalse, localLast));
				}, (localLast, localList) =>
				{
					// undo.AddAction(new SetValueUndoAction(this, ALE__GENERATED__editingId, ALE__GENERATED__beginEditValue, ALE__GENERATED__lastModifyValue);
					localList.Add(ILHelper.Ldarg(il, paraUndo));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, beginEditValueField));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, lastModifyValueField));
					localList.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<SetValueUndoAction>(typeof(IExposedToLevelEditor), typeof(int), typeof(object), typeof(object))));
					localList.Add(Instruction.Create(OpCodes.Callvirt, Module.GetMethod<ILevelEditorUndo>(nameof(ILevelEditorUndo.AddAction), typeof(IUndoAction))));
				}, localList =>
				{
					// End method
					localList.Add(Instruction.Create(OpCodes.Ret));
				}));
			});

			m.EndEdit();
		}

		private void CreateGetProperties(IReadOnlyList<IExposedProperty> properties)
		{
			propertiesListField = Type.AddField<List<ExposedField>>("ALE__GENERATED__propertiesList", FieldAttributes.Private | FieldAttributes.InitOnly);
			cachedPropertiesField = Type.AddField<ExposedField[]>("ALE__GENERATED__cachedProperties", FieldAttributes.Private | FieldAttributes.InitOnly);

			CreateCachedProperties();

			MethodDefinition m = Type.AddMethodOverride<IReadOnlyList<ExposedField>>("Hertzole.ALE.IExposedToLevelEditor.GetProperties",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.GetProperties)));

			CreateGetPropertiesMethod();

			ILProcessor il = m.BeginEdit();

			// ALE__GENERATED__propertiesList.Clear();
			il.EmitLdarg();
			il.Emit(OpCodes.Ldfld, propertiesListField);
			il.Emit(OpCodes.Callvirt, Module.GetMethod<List<ExposedField>>(nameof(List<ExposedField>.Clear)));
			// ALE__GENERATED__GetProperties(ALE__GENERATED_propertiesLisT);
			il.EmitLdarg();
			il.EmitLdarg();
			il.Emit(OpCodes.Ldfld, propertiesListField);
			il.Emit(OpCodes.Callvirt, getPropertiesMethod);

			// return ALE__GENERATED__propertiesList;
			il.EmitLdarg();
			il.Emit(OpCodes.Ldfld, propertiesListField);
			il.Emit(OpCodes.Ret);

			m.EndEdit();

			void CreateCachedProperties()
			{
				instructions.Clear();

				MethodDefinition ctor = Type.GetConstructor();

				ILProcessor localIl = ctor.BeginEdit();

				// Cache it here so it doesn't need to be found for every item.
				MethodReference getTypeFromHandle = Module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle));
				MethodReference exposedProperty = Module.GetConstructor<ExposedProperty>(typeof(int), typeof(Type), typeof(string), typeof(string), typeof(bool));

				// ALE__GENERATED__propertiesList = new List<ExposedField>();
				instructions.Add(ILHelper.Ldarg(localIl));
				// Prepare the list with the same amount of properties that we know of.
				instructions.Add(ILHelper.Int(properties.Count));
				instructions.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<List<ExposedField>>(typeof(int))));
				instructions.Add(Instruction.Create(OpCodes.Stfld, propertiesListField));

				// ALE__GENERATED__cachedProperties = array;
				instructions.Add(ILHelper.Ldarg(localIl));
				// ExposedField[] array = new ExposedField[count];
				instructions.Add(ILHelper.Int(properties.Count));
				instructions.Add(Instruction.Create(OpCodes.Newarr, Module.GetTypeReference<ExposedField>()));
				for (int i = 0; i < properties.Count; i++)
				{
					// array[i] = new ExposedProperty(id, type, name, customName, visible);
					instructions.Add(Instruction.Create(OpCodes.Dup));
					instructions.Add(ILHelper.Int(i)); // Index
					instructions.Add(ILHelper.Int(properties[i].Id)); // Id
					instructions.Add(Instruction.Create(OpCodes.Ldtoken, properties[i].FieldType)); // Type
					instructions.Add(Instruction.Create(OpCodes.Call, getTypeFromHandle));
					instructions.Add(Instruction.Create(OpCodes.Ldstr, properties[i].Name));
					// If there's a custom name, load it. Otherwise just put a null.
					if (string.IsNullOrWhiteSpace(properties[i].CustomName))
					{
						instructions.Add(Instruction.Create(OpCodes.Ldnull));
					}
					else
					{
						instructions.Add(Instruction.Create(OpCodes.Ldstr, properties[i].CustomName));
					}

					instructions.Add(ILHelper.Bool(properties[i].Visible)); // Visible
					instructions.Add(Instruction.Create(OpCodes.Newobj, exposedProperty));
					instructions.Add(Instruction.Create(OpCodes.Stelem_Ref));
				}

				instructions.Add(Instruction.Create(OpCodes.Stfld, cachedPropertiesField));

				localIl.InsertAt(0, instructions);

				ctor.EndEdit();
			}

			void CreateGetPropertiesMethod()
			{
				getPropertiesMethod = Type.AddMethod("ALE__GENERATED__GetProperties",
					MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

				ParameterDefinition paraList = getPropertiesMethod.AddParameter<List<ExposedField>>("list");

				ILProcessor localIl = getPropertiesMethod.BeginEdit();

				localIl.EmitLdarg(paraList);
				localIl.EmitLdarg();
				localIl.Emit(OpCodes.Ldfld, cachedPropertiesField);
				localIl.Emit(OpCodes.Callvirt, Module.GetMethod<List<ExposedField>>(nameof(List<ExposedField>.AddRange)));
				localIl.Emit(OpCodes.Ret);

				getPropertiesMethod.EndEdit();
			}
		}

		private void CreateGetValue(IReadOnlyList<IExposedProperty> properties)
		{
			MethodDefinition m = Type.AddMethodOverride<object>("Hertzole.ALE.IExposedToLevelEditor.GetValue",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.GetValue), typeof(int)));

			ParameterDefinition paraId = m.AddParameter<int>("id");

			MethodDefinition helperMethod = CreateGetValueHelper();

			ILProcessor il = m.BeginEdit();
			il.Body.InitLocals = true;

			VariableDefinition varValue = m.AddLocalVariable<object>("value");

			il.EmitIfElse((last, list) =>
			{
				// if (ALE__GENERATED__GetValue(id, out value))
				list.Add(ILHelper.Ldarg(il));
				list.Add(ILHelper.Ldarg(il, paraId));
				list.Add(ILHelper.Ldloc(varValue, true));
				list.Add(Instruction.Create(OpCodes.Callvirt, helperMethod));
				list.Add(Instruction.Create(OpCodes.Brfalse, last));
			}, (last, list) =>
			{
				// return value;
				list.Add(ILHelper.Ldloc(varValue));
				list.Add(Instruction.Create(OpCodes.Ret));
			}, list =>
			{
				// throw new InvalidExposedPropertyException(id);
				list.Add(ILHelper.Ldarg(il, paraId));
				list.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<InvalidExposedPropertyException>(typeof(int))));
				list.Add(Instruction.Create(OpCodes.Throw));
			});

			m.EndEdit();

			MethodDefinition CreateGetValueHelper()
			{
				MethodDefinition localM = Type.AddMethod<bool>("ALE__GENERATED__GetValue",
					MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);

				ParameterDefinition localParaId = localM.AddParameter<int>("id");
				ParameterDefinition localParaValue = localM.AddParameter(Module.GetTypeReference(typeof(object).MakeByRefType()), "value");

				localParaValue.IsOut = true;

				ILProcessor localIl = localM.BeginEdit();

				localIl.EmitIfElse(properties, (item, i, target, list) =>
				{
					// if (id == i)
					list.Add(ILHelper.Ldarg(localIl, localParaId));
					if (item.Id == 0)
					{
						list.Add(Instruction.Create(OpCodes.Brtrue, target));
					}
					else
					{
						list.Add(ILHelper.Int(item.Id));
						list.Add(Instruction.Create(OpCodes.Bne_Un, target));
					}
				}, (item, i, last, list) =>
				{
					// value = this.value;
					list.Add(ILHelper.Ldarg(localIl, localParaValue));
					list.Add(ILHelper.Ldarg(localIl));
					list.Add(item.GetLoadInstruction());
					if (item.IsComponent)
					{
						if (item.IsCollection)
						{
							list.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>))));
						}
						else
						{
							list.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(GameObject) : typeof(Transform))));
						}
					}
					if (item.IsValueType)
					{
						list.Add(Instruction.Create(OpCodes.Box, item.FieldTypeComponentAware));
					}

					list.Add(Instruction.Create(OpCodes.Stind_Ref));
					// return true;
					list.Add(ILHelper.Bool(true));
					list.Add(Instruction.Create(OpCodes.Ret));
				}, list =>
				{
					// value = null;
					list.Add(ILHelper.Ldarg(localIl, localParaValue));
					list.Add(Instruction.Create(OpCodes.Ldnull));
					list.Add(Instruction.Create(OpCodes.Stind_Ref));
					// return false;
					list.Add(ILHelper.Bool(false));
					list.Add(Instruction.Create(OpCodes.Ret));
				});

				localM.EndEdit();

				return localM;
			}
		}

		private void CreateGetWrapper(IReadOnlyList<IExposedProperty> properties)
		{
			MethodDefinition m = Type.AddMethodOverride<IExposedWrapper>("Hertzole.ALE.IExposedToLevelEditor.GetWrapper",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.GetWrapper)));

			ILProcessor il = m.BeginEdit();

#if ALE_DEBUG
			il.Emit(OpCodes.Ldstr, $"{Type.FullName} Getting wrapper...");
			il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

			il.EmitLong(~(-1L << properties.Count));
			il.Emit(OpCodes.Conv_I8);

			for (int i = 0; i < properties.Count; i++)
			{
				il.Emit(OpCodes.Ldarg_0);
				il.Append(properties[i].GetLoadInstruction());

				if (properties[i].IsComponent)
				{
					if (properties[i].IsCollection)
					{
						il.Emit(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(properties[i].IsGameObject ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>)));
					}
					else
					{
						il.Emit(OpCodes.Newobj, Module.GetConstructor<ComponentDataWrapper>(properties[i].IsGameObject ? typeof(GameObject) : typeof(Component)));
					}
				}
			}

			il.Emit(OpCodes.Newobj, wrapperData.wrapperConstructor);
#if ALE_DEBUG
			il.Emit(OpCodes.Ldstr, $"{Type.FullName} Returning wrapper");
			il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
			il.Emit(OpCodes.Box, wrapperData.wrapper);
			il.Emit(OpCodes.Ret);

			m.EndEdit();
		}

		private void CreateApplyWrapper(IReadOnlyList<IExposedProperty> properties)
		{
			MethodDefinition m = Type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.ApplyWrapper",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				Module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.ApplyWrapper), typeof(IExposedWrapper), typeof(bool)));

			ParameterDefinition wrapperPar = m.AddParameter<IExposedWrapper>("wrapper");
			ParameterDefinition ignoreDirtyMaskPar = m.AddParameter<bool>("ignoreDirtyMask");
			VariableDefinition wrapperVar = m.AddLocalVariable(wrapperData.wrapper);

			ignoreDirtyMaskPar.IsOptional = true;
			ignoreDirtyMaskPar.HasDefault = true;
			ignoreDirtyMaskPar.Constant = false;

			ILProcessor il = m.Body.GetILProcessor();

			m.Body.InitLocals = true;

			il.EmitLdarg(wrapperPar);
			il.Emit(OpCodes.Isinst, wrapperData.wrapper);

			il.EmitLdarg(wrapperPar);
			il.Emit(OpCodes.Unbox_Any, wrapperData.wrapper);
			il.EmitStloc(wrapperVar);

			Instruction previous = null;

			for (int i = 0; i < properties.Count; i++)
			{
				Instruction start = il.EmitLdarg(ignoreDirtyMaskPar);

				il.EmitLdloc(wrapperVar);
				il.Emit(OpCodes.Ldfld, wrapperData.dirtyMaskField);
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
				item2.DeclaringType = Module.ImportReference(typeof(ValueTuple<,>)).MakeGenericInstanceType(Module.GetTypeReference<int>(), properties[i].FieldTypeComponentAware);

				bool setField = true;

#if ALE_DEBUG
				Instruction setFieldStart;
				if (properties[i].FieldType.Is<string>())
				{
					setFieldStart = Instruction.Create(OpCodes.Ldstr, "Apply value on stringTest: ");
					il.Append(setFieldStart);
					il.EmitLdloc(wrapperVar);
					FieldReference valueField = wrapperData.wrapper.GetField(properties[i].Name);
					il.Emit(OpCodes.Ldfld, valueField);
					il.Emit(OpCodes.Ldfld, item2);
					il.Emit(OpCodes.Call, Module.GetMethod<string>("Concat", typeof(string), typeof(string)));
				}
				else
				{
					setFieldStart = Instruction.Create(OpCodes.Ldstr, $"Apply value on {properties[i].Name}: {{0}}");
					il.Append(setFieldStart);
					il.EmitLdloc(wrapperVar);
					il.Emit(OpCodes.Ldfld, wrapperData.wrapper.GetField(properties[i].Name));
					il.Emit(OpCodes.Ldfld, item2);
					il.Emit(OpCodes.Box, properties[i].IsComponent ? Module.GetTypeReference<ComponentDataWrapper>() : properties[i].FieldType);
					il.Emit(OpCodes.Call, Module.GetMethod<string>("Format", typeof(string), typeof(object)));
				}

				il.Emit(OpCodes.Call, Module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
				il.EmitLdarg();
#else
				Instruction setFieldStart = il.EmitLdarg();
#endif

				il.InsertAfter(start, Instruction.Create(OpCodes.Brtrue, setFieldStart));

				if (properties[i].IsComponent)
				{
					if (properties[i].IsCollection)
					{
						if (properties[i].IsList)
						{
							setField = false;

							Instruction addStart = ILHelper.Ldarg(il);

							int index = i;
							il.EmitIfElse((last, list) =>
							{
								// if (value == null)
								list.Add(properties[index].GetLoadInstruction());
								list.Add(Instruction.Create(OpCodes.Brtrue, last));
							}, (last, list) =>
							{
								// value = new List<Type>();
								list.Add(ILHelper.Ldarg(il));
								list.Add(Instruction.Create(OpCodes.Newobj, Module.GetConstructor(typeof(List<>)).MakeHostInstanceGeneric(
									Module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(properties[index].FieldType.GetCollectionType()))));
								list.Add(properties[index].GetSetInstruction());
								list.Add(Instruction.Create(OpCodes.Br, addStart));
							}, list =>
							{
								// value.Clear();	
								list.Add(ILHelper.Ldarg(il));
								list.Add(properties[index].GetLoadInstruction());
								list.Add(Instruction.Create(OpCodes.Callvirt, Module.GetMethod(typeof(List<>), "Clear").MakeHostInstanceGeneric(
									Module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(properties[index].FieldType.GetCollectionType()))));
							});

							// field.AddRange(wrapper.field.Item2.GetObjects<Type>());
							il.Append(addStart);
							il.Append(properties[i].GetLoadInstruction());

							il.EmitLdloc(wrapperVar, true);
							il.Emit(OpCodes.Ldflda, wrapperData.wrapper.GetField(properties[i].Name));
							il.Emit(OpCodes.Ldflda, item2);
							il.Emit(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(properties[i].FieldType.GetCollectionType()));
							il.Emit(OpCodes.Callvirt, Module.ImportReference(typeof(List<>).GetMethod("AddRange"))
							                                .MakeGenericMethod(Module.GetTypeReference(typeof(IEnumerable<>))
							                                                         .MakeGenericInstanceType(properties[i].FieldType.GetCollectionType()))
							                                .MakeHostInstanceGeneric(Module.GetTypeReference(typeof(List<>))
							                                                               .MakeGenericInstanceType(properties[i].FieldType.GetCollectionType())));
						}
						else
						{
							il.EmitLdloc(wrapperVar, true);
							il.Emit(OpCodes.Ldflda, wrapperData.wrapper.GetField(properties[i].Name));
							il.Emit(OpCodes.Ldflda, item2);
							il.Emit(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(properties[i].FieldType.GetCollectionType()));
						}
					}
					else
					{
						il.EmitLdloc(wrapperVar, true);
						il.Emit(OpCodes.Ldflda, wrapperData.wrapper.GetField(properties[i].Name));
						il.Emit(OpCodes.Ldflda, item2);
						il.Emit(OpCodes.Call, Module.GetMethod<ComponentDataWrapper>("GetObject", Array.Empty<Type>()).MakeGenericMethod(properties[i].FieldType));
					}
				}
				else
				{
					il.EmitLdloc(wrapperVar);
					il.Emit(OpCodes.Ldfld, wrapperData.wrapper.GetField(properties[i].Name));
					il.Emit(OpCodes.Ldfld, item2);
				}

				if (setField)
				{
					il.Append(properties[i].GetSetInstruction());
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

		private static bool HasExposedProperties(TypeDefinition type)
		{
			if (type.HasFields)
			{
				for (int i = 0; i < type.Fields.Count; i++)
				{
					if (type.Fields[i].HasAttribute<ExposeToLevelEditorAttribute>())
					{
						return true;
					}
				}
			}

			if (type.HasProperties)
			{
				for (int i = 0; i < type.Properties.Count; i++)
				{
					if (type.Properties[i].HasAttribute<ExposeToLevelEditorAttribute>())
					{
						return true;
					}
				}
			}

			return false;
		}

		private IReadOnlyList<IExposedProperty> GetExposedProperties(TypeDefinition type)
		{
			resultExposedProperties.Clear();
			usedIds.Clear();

			if (type.HasFields)
			{
				for (int i = 0; i < type.Fields.Count; i++)
				{
					if (type.Fields[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out CustomAttribute attribute))
					{
						int customOrder = attribute.GetField(nameof(ExposeToLevelEditorAttribute.order), 0);
						if (customOrder > 0)
						{
							// Add this after all the fields and properties.
							customOrder += type.Fields.Count + type.Properties.Count;
						}
						else if (customOrder < 0)
						{
							// Add this before all the fields and properties.
							customOrder -= type.Fields.Count + type.Properties.Count;
						}
						else
						{
							// Just the index it is in the file.
							customOrder = i;
						}

						resultExposedProperties.Add(new ExposedFieldProperty(type.Fields[i], customOrder));
					}
				}
			}

			if (type.HasProperties)
			{
				for (int i = 0; i < type.Properties.Count; i++)
				{
					if (type.Properties[i].TryGetAttribute<ExposeToLevelEditorAttribute>(out CustomAttribute attribute))
					{
						int customOrder = attribute.GetField(nameof(ExposeToLevelEditorAttribute.order), 0);
						if (customOrder > 0)
						{
							// Add this after all the fields and properties.
							customOrder += type.Fields.Count + type.Properties.Count;
						}
						else if (customOrder < 0)
						{
							// Add this before all the fields and properties.
							customOrder -= type.Fields.Count + type.Properties.Count;
						}
						else
						{
							// Just the index it is in the file and after all the fields.
							customOrder = type.Fields.Count + i;
						}

						resultExposedProperties.Add(new ExposedPropertyProperty(type.Properties[i], customOrder));
					}
				}
			}

			if (resultExposedProperties.Count == 0)
			{
				return null;
			}

			for (int i = 0; i < resultExposedProperties.Count; i++)
			{
				if (usedIds.Contains(resultExposedProperties[i].Id))
				{
					Error($"{resultExposedProperties[i].Name} has a duplicate ID {resultExposedProperties[i].Id}. IDs need to be unique.");
					return null;
				}

				usedIds.Add(resultExposedProperties[i].Id);
				// Must generate a formatter for this type.
				Formatters.AddTypeToGenerate(resultExposedProperties[i].FieldTypeResolved);
			}

			resultExposedProperties.Sort((x, y) => x.Order.CompareTo(y.Order));

			// Limit is 64 because of long bit limit.
			// A long is used for the dirty mask and it changes bits.
			if (resultExposedProperties.Count > 64)
			{
				Error("You can't have more than 64 exposed properties.");
				return null;
			}

			return resultExposedProperties;
		}
	}
}