using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Hertzole.ALE.CodeGen.Helpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using UnityEngine;

namespace Hertzole.ALE.CodeGen
{
	public class ExposedPropertyProcessor : BaseProcessor
	{
		private readonly List<IExposedProperty> resultExposedProperties = new List<IExposedProperty>();
		private readonly List<IExposedProperty> allExposedProperties = new List<IExposedProperty>();
		private readonly List<int> usedIds = new List<int>();
		private readonly List<int> allUsedIds = new List<int>();
		private readonly List<TypeDefinition> parents = new List<TypeDefinition>();
		private readonly HashSet<TypeDefinition> processedTypes = new HashSet<TypeDefinition>(new TypeDefinitionComparer());

		private const string BEGIN_EDIT_METHOD = "ALE__GENERATED__BeginEdit";
		private const string MODIFY_VALUE_METHOD = "ALE__GENERATED__ModifyValue";
		private const string GET_PROPERTIES_METHOD = "ALE__GENERATED__GetProperties";
		private const string GET_VALUE_METHOD = "ALE__GENERATED__GetValue";
		private const string GET_WRAPPER_METHOD = "ALE__GENERATED__GetWrapper";
		private const string APPLY_WRAPPER_METHOD = "ALE__GENERATED__ApplyWrapper";

		private MethodReference getPropertiesClear;
		private MethodReference getPropertiesAddRange;
		
#if ALE_DEBUG
		private readonly Stopwatch beginEditStopwatch = new Stopwatch();
		private readonly Stopwatch modifyValueStopwatch = new Stopwatch();
		private readonly Stopwatch createEndEditStopwatch = new Stopwatch();
		private readonly Stopwatch getPropertiesStopwatch = new Stopwatch();
		private readonly Stopwatch getValueStopwatch = new Stopwatch();
		private readonly Stopwatch getWrapperStopwatch = new Stopwatch();
		private readonly Stopwatch applyWrapperStopwatch = new Stopwatch();
#endif

		public override bool IsValidClass(TypeDefinition type)
		{
			if (type.ImplementsInterface<IExposedToLevelEditor>())
			{
				return false;
			}

			bool hasExposed = HasExposedProperties(type);

			return hasExposed;
		}

		public override void ProcessClass(TypeDefinition type)
		{
			ProcessType(type, true);
		}

		private void ProcessType(TypeDefinition type, bool checkParents)
		{
			if (processedTypes.Contains(type))
			{
				return;
			}

			SetInterface(checkParents, type, parents, out bool isChild);

			allExposedProperties.Clear();
			allUsedIds.Clear();

			GetExposedProperties(type, resultExposedProperties, usedIds);
			if (resultExposedProperties.Count == 0)
			{
				processedTypes.Add(type);
				return;
			}

			GetAllExposedProperties(type, allExposedProperties, allUsedIds);

			bool hasVisibleFields = false;
			for (int i = 0; i < resultExposedProperties.Count; i++)
			{
				if (resultExposedProperties[i].Visible)
				{
					hasVisibleFields = true;
					break;
				}
			}

			TypeDefinition wrapper = WrapperProcessor.CreateWrapper(type, Module, allExposedProperties);
			Formatters.CreateExposedFormatter(type, allExposedProperties, wrapper);

			CreateProperty<string>(type, Module, "ComponentName", type.Name, isChild);
			CreateProperty<string>(type, Module, "TypeName", type.FullName, isChild);
			CreateProperty<int>(type, Module, "Order", 0, isChild);
			CreateProperty<Type>(type, Module, "ComponentType", type, isChild);
			CreateProperty<bool>(type, Module, "HasVisibleFields", hasVisibleFields, isChild);

#if ALE_DEBUG
			beginEditStopwatch.Start();
#endif
			CreateBeginEdit(type, Module, resultExposedProperties, isChild, out FieldDefinition editingIdField, out FieldDefinition beginEditValueField);
#if ALE_DEBUG
			beginEditStopwatch.Stop();
#endif

#if ALE_DEBUG
			modifyValueStopwatch.Start();
#endif
			CreateModifyValue(type, Module, resultExposedProperties, isChild, out FieldDefinition lastModifyValueField, editingIdField);
#if ALE_DEBUG
			modifyValueStopwatch.Stop();
#endif
			
			if (!isChild)
			{
#if ALE_DEBUG
				createEndEditStopwatch.Start();
#endif
				CreateEndEdit(type, Module, editingIdField, lastModifyValueField, beginEditValueField);
#if ALE_DEBUG
				createEndEditStopwatch.Stop();
#endif
			}

#if ALE_DEBUG
			getPropertiesStopwatch.Start();
#endif
			CreateGetProperties(type, Module, resultExposedProperties, isChild);
#if ALE_DEBUG
			getPropertiesStopwatch.Stop();
#endif

#if ALE_DEBUG
			getValueStopwatch.Start();
#endif
			CreateGetValue(type, Module, resultExposedProperties, isChild);
#if ALE_DEBUG
			getValueStopwatch.Stop();
#endif

#if ALE_DEBUG
			getWrapperStopwatch.Start();
#endif
			CreateGetWrapper(type, Module, allExposedProperties, isChild, wrapper);
#if ALE_DEBUG
			getWrapperStopwatch.Stop();
#endif

#if ALE_DEBUG
			applyWrapperStopwatch.Start();
#endif
			CreateApplyWrapper(type, Module, resultExposedProperties, isChild);
#if ALE_DEBUG
			applyWrapperStopwatch.Stop();
#endif
		
			processedTypes.Add(type);
		}

#if ALE_DEBUG
		public override void EndEdit()
		{
			string timings = "ExposedPropertyProcessor timings: " +
			                 $"Begin edit: {beginEditStopwatch.ElapsedMilliseconds}ms " +
			                 $"Modify value: {modifyValueStopwatch.ElapsedMilliseconds}ms " +
			                 $"End edit: {createEndEditStopwatch.ElapsedMilliseconds}ms " +
			                 $"Get properties: {getPropertiesStopwatch.ElapsedMilliseconds}ms " +
			                 $"Get value: {getValueStopwatch.ElapsedMilliseconds}ms " +
			                 $"Get wrapper: {getWrapperStopwatch.ElapsedMilliseconds}ms " +
			                 $"Apply wrapper: {applyWrapperStopwatch.ElapsedMilliseconds}ms";

			Warning(timings);
		}
#endif

		private void SetInterface(bool checkParents, TypeDefinition type, IList<TypeDefinition> parentList, out bool isChild)
		{
			if (checkParents)
			{
				CheckParents(type, parentList);
			}

			isChild = false;

			for (int i = 0; i < parentList.Count; i++)
			{
				if (processedTypes.Contains(parentList[i]))
				{
					isChild = true;
					break;
				}
			}

			if (!isChild)
			{
				type.Interfaces.Add(new InterfaceImplementation(Module.GetTypeReference<IExposedToLevelEditor>()));
			}
		}

		private void CheckParents(TypeDefinition type, IList<TypeDefinition> parentsList)
		{
			type.GetParents(parentsList, HasExposedProperties);

			// Go through in reverse because we want the top most class.
			for (int i = parentsList.Count - 1; i >= 0; i--)
			{
				ProcessType(parentsList[i], false);
			}
		}

		private static FieldDefinition CreateEvent(string eventName, TypeDefinition type, ModuleDefinition module)
		{
			TypeReference action = module.GetTypeReference<Action<int, object>>();
			CustomAttribute compilerGenerated = new CustomAttribute(module.GetConstructor<CompilerGeneratedAttribute>());

			FieldDefinition eventField;
			MethodDefinition addMethod;
			MethodDefinition removeMethod;

			CreateInternalEvent();
			CreateOverrideEvent();

			return eventField;

			void CreateInternalEvent()
			{
				EventDefinition resultEvent = new EventDefinition($"ALE__GENERATED__EVENT__{eventName}", EventAttributes.None, action);
				eventField = type.AddField($"ALE__GENERATED__EVENT__{eventName}", FieldAttributes.Private, action);
				eventField.CustomAttributes.Add(compilerGenerated);

				addMethod = CreateAddRemoveMethod($"add_ALE__GENERATED__EVENT__{eventName}", false);
				removeMethod = CreateAddRemoveMethod($"remove_ALE__GENERATED__EVENT__{eventName}", true);

				resultEvent.AddMethod = addMethod;
				resultEvent.RemoveMethod = removeMethod;

				type.Events.Add(resultEvent);
			}

			MethodDefinition CreateAddRemoveMethod(string name, bool remove)
			{
				MethodDefinition method = type.AddMethod(name, MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName);
				method.CustomAttributes.Add(compilerGenerated);

				// method.Parameters.Add(new ParameterDefinition("value", ParameterAttributes.None, action))
				ParameterDefinition paraValue = method.AddParameter(action, "value");

				ILProcessor il = method.BeginEdit();
				il.Body.InitLocals = true;

				VariableDefinition varLocal1 = method.AddLocalVariable(action);
				VariableDefinition varLocal2 = method.AddLocalVariable(action);
				VariableDefinition varLocal3 = method.AddLocalVariable(action);

				// Action<int, object> action = this.GENERATED__EVENT
				il.EmitLdarg();
				il.Emit(OpCodes.Ldfld, eventField);
				il.EmitStloc(varLocal1);

				// Loop start
				// Action<int, object> action2 = action
				Instruction[] loopStart = il.EmitLdloc(varLocal1);
				il.EmitStloc(varLocal2);
				// Action<int, object> value2 = (Action<int, object>) Delegate.Combine/Remove(action2, value)
				il.EmitLdloc(varLocal2);
				il.EmitLdarg(paraValue);
				il.Emit(OpCodes.Call, module.GetMethod<Delegate>(remove ? nameof(Delegate.Remove) : nameof(Delegate.Combine), typeof(Delegate), typeof(Delegate)));
				il.Emit(OpCodes.Castclass, action);
				il.EmitStloc(varLocal3);
				// action = Interlocked.CompareExchange(ref this.GENERATED__EVENT, value2, action2)
				il.EmitLdarg();
				il.Emit(OpCodes.Ldflda, eventField);
				il.EmitLdloc(varLocal3);
				il.EmitLdloc(varLocal2);
				il.Emit(OpCodes.Call, module.GetGenericMethod(typeof(Interlocked), nameof(Interlocked.CompareExchange), action));
				il.EmitStloc(varLocal1);
				// if ((object) action == action2)
				il.EmitLdloc(varLocal1);
				il.EmitLdloc(varLocal2);
				il.Emit(OpCodes.Bne_Un, loopStart[0]);

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

				type.Events.Add(e);
			}

			MethodDefinition CreateOverrideEventAddRemoveMethod(bool remove, MethodReference targetMethod)
			{
				MethodDefinition m = type.AddMethodOverride($"Hertzole.ALE.IExposedToLevelEditor.{(remove ? "remove" : "add")}_{eventName}",
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.GetMethod<IExposedToLevelEditor>($"{(remove ? "remove" : "add")}_{eventName}", typeof(Action<int, object>)));

				ParameterDefinition paraValue = m.AddParameter<Action<int, object>>("value");

				ILProcessor il = m.BeginEdit();

				// GENERATED__EVENT +-= value
				il.EmitLdarg();
				il.EmitLdarg(paraValue);
				il.Emit(OpCodes.Call, targetMethod);
				il.Emit(OpCodes.Ret);

				m.EndEdit();

				return m;
			}
		}

		private static void CreateProperty<T>(TypeDefinition type, ModuleDefinition module, string name, object value, bool isChild)
		{
			MethodDefinition getVirtualMethod;
			if (!isChild)
			{
				getVirtualMethod = type.AddMethod<T>($"ALE__GENERATED__Get{name}",
					MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);
			}
			else
			{
				getVirtualMethod = type.AddMethod<T>($"ALE__GENERATED__Get{name}",
					MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual);
			}

			ILProcessor virtualIl = getVirtualMethod.BeginEdit();

			if (typeof(T) == typeof(string))
			{
				virtualIl.Emit(OpCodes.Ldstr, (string) value);
			}
			else if (typeof(T) == typeof(bool))
			{
				virtualIl.EmitBool((bool) value);
			}
			else if (typeof(T) == typeof(int))
			{
				virtualIl.EmitInt((int) value);
			}
			else if (typeof(T) == typeof(Type))
			{
				virtualIl.Emit(OpCodes.Ldtoken, (TypeReference) value);
				virtualIl.Emit(OpCodes.Call, module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle)));
			}

			virtualIl.Emit(OpCodes.Ret);
			getVirtualMethod.EndEdit();

			if (!isChild)
			{
				PropertyDefinition p = type.AddProperty<T>(name, PropertyAttributes.None);
				MethodDefinition getMethod = type.AddMethodOverride<T>($"Hertzole.ALE.IExposedToLevelEditor.get_{name}",
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.GetMethod<IExposedToLevelEditor>($"get_{name}"));

				p.GetMethod = getMethod;

				ILProcessor il = getMethod.BeginEdit();

				il.EmitLdarg();
				il.Emit(OpCodes.Callvirt, getVirtualMethod);
				il.Emit(OpCodes.Ret);

				getMethod.EndEdit();
			}
		}

		private static void CreateBeginEdit(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild, out FieldDefinition editingIdField, out FieldDefinition beginEditValueField)
		{
			const string editing_id = "ALE__GENERATED_editingId";
			const string begin_edit_value = "ALE__GENERATED__beginEditValue";

			if (isChild)
			{
				editingIdField = type.GetFieldInBaseType(editing_id);
				beginEditValueField = type.GetFieldInBaseType(begin_edit_value);
			}
			else
			{
				editingIdField = type.AddField<int>(editing_id, FieldAttributes.Family);
				beginEditValueField = type.AddField<object>(begin_edit_value, FieldAttributes.Family);
			}

			MethodDefinition beginEditMethod = CreateBeginEditHelperMethod(type, module, properties, beginEditValueField, isChild);

			if (!isChild)
			{
				MethodDefinition m = type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.BeginEdit", // Name
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual, // Attributes
					module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.BeginEdit), typeof(int))); // Override methods

				ParameterDefinition paraId = m.AddParameter<int>("id");

				ILProcessor il = m.BeginEdit();

				// ALE__GENERATED__editingId = id
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
					// throw new InvalidExposedPropertyException(id)
					list.Add(ILHelper.Ldarg(il, paraId));
					list.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<InvalidExposedPropertyException>(typeof(int))));
					list.Add(Instruction.Create(OpCodes.Throw));
				}, list =>
				{
					// End method
					list.Add(Instruction.Create(OpCodes.Ret));
				});

				m.EndEdit();
			}
		}

		private static MethodDefinition CreateBeginEditHelperMethod(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, FieldReference beginEditValueField, bool isChild)
		{
			MethodDefinition m = type.AddMethod<bool>(BEGIN_EDIT_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual);
			if (!isChild)
			{
				m.Attributes |= MethodAttributes.NewSlot;
			}

			ParameterDefinition idPara = m.AddParameter<int>("id");

			ILProcessor il = m.BeginEdit();
			
			MethodDefinition baseMethod = isChild ? type.GetMethodInBaseType(BEGIN_EDIT_METHOD, false) : null;

			il.EmitIfElse(properties, (item, index, target, body, fill) =>
			{
				// if (id == something)
				fill.Add(ILHelper.Ldarg(il, idPara));
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
				// ALE__GENERATED__beginEditValue = value
				fill.Add(ILHelper.Ldarg(il));
				fill.Add(ILHelper.Ldarg(il)); // Not a typo
				fill.Add(item.GetLoadInstruction());
				if (item.IsComponent)
				{
					if (item.IsCollection)
					{
						fill.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>))));
					}
					else
					{
						fill.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(GameObject) : typeof(Component))));
					}
				}

				if (item.IsValueType)
				{
					fill.Add(Instruction.Create(OpCodes.Box, item.FieldTypeComponentAware));
				}

				fill.Add(Instruction.Create(OpCodes.Stfld, beginEditValueField));
				// return true
				fill.Add(ILHelper.Bool(true));
				fill.Add(Instruction.Create(OpCodes.Ret));
			}, fill =>
			{
				if (isChild)
				{
					// return base.ALE__GENERATED__BeginEdit(id)
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(ILHelper.Ldarg(il, idPara));
					fill.Add(Instruction.Create(OpCodes.Call, baseMethod));
				}
				else
				{
					// return false
					fill.Add(ILHelper.Bool(false));
				}

				fill.Add(Instruction.Create(OpCodes.Ret));
			});

			m.EndEdit();

			return m;
		}

		private void CreateModifyValue(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild, out FieldDefinition lastModifyValueField, FieldReference editingIdField)
		{
			const string last_modify_value = "ALE__GENERATED__lastModifyValue";

			lastModifyValueField = isChild ? type.GetFieldInBaseType(last_modify_value) : type.AddField<object>(last_modify_value, FieldAttributes.Family);

			MethodDefinition modifyValueMethod = CreateModifyValueHelperMethod(type, module, properties, isChild, editingIdField, lastModifyValueField);

			if (!isChild)
			{
				FieldDefinition valueChangingField = CreateEvent(nameof(IExposedToLevelEditor.OnValueChanging), type, module);
				
				MethodDefinition m = type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.ModifyValue", // Name
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual, // Attributes
					module.GetMethod<IExposedToLevelEditor>("ModifyValue", typeof(object), typeof(bool))); // Overrides

				ParameterDefinition paraValue = m.AddParameter<object>("value");
				ParameterDefinition paraNotify = m.AddParameter<bool>("notify");

				ILProcessor il = m.BeginEdit();

				VariableDefinition varChanged = m.AddLocalVariable<bool>("changed");

				// changed = false
				il.EmitBool(false, varChanged);

				Instruction methodEnd = null;

				il.EmitIfElse((target, list) =>
				{
					// if (ALE__GENERATED__ModifyValue(value, ref changed))
					list.Add(ILHelper.Ldarg(il));
					list.Add(ILHelper.Ldarg(il, paraValue));
					list.AddRange(ILHelper.Ldloc(varChanged, true));
					list.Add(Instruction.Create(OpCodes.Callvirt, modifyValueMethod));
					list.Add(Instruction.Create(OpCodes.Brfalse, target));
				}, (last, list) =>
				{
					// if (notify && changed)
					list.Add(ILHelper.Ldarg(il, paraNotify));
					list.AddRange(ILHelper.Ldloc(varChanged));
					list.Add(Instruction.Create(OpCodes.And));
					list.Add(Instruction.Create(OpCodes.Brfalse, methodEnd));

					list.AddRange(ILHelper.IfElse((target, fill) =>
					{
						// OnValueChanging = this.ALE__GENERATED__OnValueChanging
						fill.Add(ILHelper.Ldarg(il));
						fill.Add(Instruction.Create(OpCodes.Ldfld, valueChangingField));

						// if (OnValueChanging != null)
						fill.Add(Instruction.Create(OpCodes.Dup));
						fill.Add(Instruction.Create(OpCodes.Brtrue, target));
					}, (target, fill) =>
					{
						// return
						fill.Add(Instruction.Create(OpCodes.Pop));
						fill.Add(Instruction.Create(OpCodes.Ret));
					}, fill =>
					{
						// OnValueChanging(ALE__GENERATED_editingId, value)
						fill.Add(ILHelper.Ldarg(il));
						fill.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
						fill.Add(ILHelper.Ldarg(il, paraValue));
						fill.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod<Action<int, object>>("Invoke", typeof(int), typeof(object))));
						fill.Add(Instruction.Create(OpCodes.Ret));
					}));
				}, list =>
				{
					// throw new Hertzole.ALE.InvalidExposedPropertyException(ALE__GENERATED__editingId)
					list.Add(ILHelper.Ldarg(il));
					list.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
					list.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<InvalidExposedPropertyException>(typeof(int))));
					list.Add(Instruction.Create(OpCodes.Throw));

					methodEnd = Instruction.Create(OpCodes.Ret);
					list.Add(methodEnd);
				});

				m.EndEdit();
			}
		}

		private MethodDefinition CreateModifyValueHelperMethod(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild, FieldReference editingIdField, FieldReference lastModifyValueField)
		{
			MethodDefinition m = type.AddMethod<bool>(MODIFY_VALUE_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual);
			if (!isChild)
			{
				m.Attributes |= MethodAttributes.NewSlot;
			}

			ParameterDefinition paraValue = m.AddParameter<object>("value");
			ParameterDefinition paraChanged = m.AddParameter(module.ImportReference(typeof(bool).MakeByRefType()), "changed");

			ILProcessor il = m.BeginEdit();

			m.Body.InitLocals = true;

			VariableDefinition[] localVariables = new VariableDefinition[properties.Count];
			for (int i = 0; i < localVariables.Length; i++)
			{
				localVariables[i] = m.AddLocalVariable(properties[i].FieldType.IsNullable(out TypeReference nullableType) ? nullableType : properties[i].FieldTypeComponentAware);
			}

			TypeReference componentDataWrapper = module.GetTypeReference<ComponentDataWrapper>();
			MethodDefinition baseMethod = isChild ? type.GetMethodInBaseType(MODIFY_VALUE_METHOD, false) : null;
			MethodReference componentEqualsGameObject = module.GetMethod<ComponentDataWrapper>("Equals", typeof(GameObject));
			MethodReference componentEqualsComponent = module.GetMethod<ComponentDataWrapper>("Equals", typeof(Component));

			il.EmitIfElse(properties, (item, index, target, body, fill) =>
			{
				// if (ALE__GENERATED__editingID == id)
				fill.Add(ILHelper.Ldarg(il));
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
				MethodReference equals = module.ImportReference(item.FieldTypeResolved.GetEqualsMethod(out bool isInEquality));
				bool skipAssignValue = false;
				
				if (item.IsComponent)
				{
					// ComponentDataWrapper wrapper = (ComponentDataWrapper) value
					fill.Add(ILHelper.Ldarg(il, paraValue));
					fill.Add(Instruction.Create(OpCodes.Isinst, componentDataWrapper));
					fill.Add(Instruction.Create(OpCodes.Brfalse, last));

					fill.Add(ILHelper.Ldarg(il, paraValue));
					fill.Add(Instruction.Create(OpCodes.Unbox_Any, componentDataWrapper));
					fill.AddRange(ILHelper.Stloc(localVariables[index]));

					// if (!wrapper.Equals(value))
					fill.AddRange(ILHelper.Ldloc(localVariables[index], true));
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(item.GetLoadInstruction());
					if (item.IsCollection)
					{
						if (item.IsDictionary)
						{
							Error("You can't have a dictionary.");
							return;
						}

						fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod<ComponentDataWrapper>("Equals", item.FieldType.GetCollectionType().Is<GameObject>() ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>))));
					}
					else
					{
						fill.Add(Instruction.Create(OpCodes.Call, item.FieldType.Is<GameObject>() ? componentEqualsGameObject : componentEqualsComponent));
					}

					fill.Add(Instruction.Create(OpCodes.Brtrue, last));
					fill.Add(ILHelper.Ldarg(il));

					if (item.IsCollection)
					{
						if (item.IsList)
						{
							Instruction addStart = ILHelper.Ldarg(il);

							fill.AddRange(ILHelper.IfElse((last, list) =>
							{
								// if (value == null)
								list.Add(item.GetLoadInstruction());
								list.Add(Instruction.Create(OpCodes.Brtrue, last));
							}, (last, list) =>
							{
								// value = new List<Type>()
								list.Add(ILHelper.Ldarg(il));
								list.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor(typeof(List<>)).MakeHostInstanceGeneric(
									module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(item.FieldType.GetCollectionType()))));

								list.Add(item.GetSetInstruction());
								list.Add(Instruction.Create(OpCodes.Br, addStart));
							}, list =>
							{
								// value.Clear()
								list.Add(ILHelper.Ldarg(il));
								list.Add(item.GetLoadInstruction());
								list.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod(typeof(List<>), "Clear").MakeHostInstanceGeneric(
									module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(item.FieldType.GetCollectionType()))));
							}));

							// value.AddRange(wrapper.GetObjects<Type>())
							fill.Add(addStart);
							fill.Add(item.GetLoadInstruction());
							fill.AddRange(ILHelper.Ldloc(localVariables[index], true));
							fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(item.FieldType.GetCollectionType())));
							fill.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod(typeof(List<>), "AddRange").MakeHostInstanceGeneric(
								module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(item.FieldType.GetCollectionType()))));
						}
						else
						{
							// valueArray = wrapper.GetObjects<Type>()
							fill.AddRange(ILHelper.Ldloc(localVariables[index], true));
							fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod<ComponentDataWrapper>("GetObjects", Array.Empty<Type>()).MakeGenericMethod(item.FieldType.GetCollectionType())));
							fill.Add(item.GetSetInstruction());
						}

						// ALE__GENERATED__lastModifyValue = wrapper
						fill.Add(ILHelper.Ldarg(il));
						fill.AddRange(ILHelper.Ldloc(localVariables[index]));
						fill.Add(Instruction.Create(OpCodes.Box, componentDataWrapper));
						fill.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));
					}
					else
					{
						fill.AddRange(ILHelper.Ldloc(localVariables[index], true));
						fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod<ComponentDataWrapper>("GetObject", Array.Empty<Type>()).MakeGenericMethod(item.FieldType.GetCollectionType())));
						fill.Add(item.GetSetInstruction());
					}
				}
				else if (item.FieldType.IsNullable(out TypeReference nullableType))
				{
					// We want to handle the value assignment ourselves.
					skipAssignValue = true;

					var nullInt1 = m.AddLocalVariable<int?>(); // 5
					var tempInt = m.AddLocalVariable<int>(); // 6
					var tempNullable = m.AddLocalVariable(item.FieldType); // 7
					var nullInt2 = m.AddLocalVariable<int?>(); // 8

					GenericInstanceType nullableContainer = module.GetTypeReference(typeof(Nullable<>)).MakeGenericInstanceType(nullableType);
					GenericInstanceType nullableInt = module.GetTypeReference(typeof(Nullable<>)).MakeGenericInstanceType(module.GetTypeReference<int>());

					fill.AddRange(ILHelper.IfElse((elseCheck, list) =>
					{
						// if (value is Type)
						list.Add(ILHelper.Ldarg(il, paraValue));
						list.Add(Instruction.Create(OpCodes.Isinst, nullableType));
						list.Add(Instruction.Create(OpCodes.Brfalse, elseCheck));

					}, (next, list) =>
					{
						Instruction[] temp = ILHelper.Ldloc(tempNullable, true);
						Instruction[] temp2 = ILHelper.Stloc(nullInt1);

						// var val = (Type) value
						list.Add(ILHelper.Ldarg(il, paraValue));
						list.Add(Instruction.Create(OpCodes.Unbox_Any, nullableType));
						list.AddRange(ILHelper.Stloc(localVariables[index]));

						// if (field != val)
						list.Add(ILHelper.Ldarg(il));
						list.Add(item.GetLoadInstruction());
						list.AddRange(ILHelper.Stloc(tempNullable));

						list.AddRange(ILHelper.Ldloc(tempNullable, true));
						list.Add(Instruction.Create(OpCodes.Call, nullableContainer.GetMethod("get_HasValue")));
						list.Add(Instruction.Create(OpCodes.Brtrue, temp[0]));

						list.AddRange(ILHelper.Ldloc(nullInt2, true));
						list.Add(Instruction.Create(OpCodes.Initobj, module.GetTypeReference<int?>()));
						list.AddRange(ILHelper.Ldloc(nullInt2));
						list.Add(Instruction.Create(OpCodes.Br, temp2[0]));

						list.AddRange(temp);
						list.Add(Instruction.Create(OpCodes.Call, nullableContainer.GetMethod("GetValueOrDefault")));
						list.Add(Instruction.Create(OpCodes.Newobj, nullableInt.GetMethod(".ctor")));

						list.AddRange(temp2);
						list.AddRange(ILHelper.Ldloc(localVariables[index]));
						list.AddRange(ILHelper.Stloc(tempInt));
						
						// field = val
						list.AddRange(ILHelper.Ldloc(nullInt1, true));
						list.Add(Instruction.Create(OpCodes.Call, module.GetMethod<int?>("GetValueOrDefault", Array.Empty<Type>())));
						list.AddRange(ILHelper.Ldloc(tempInt));
						list.Add(Instruction.Create(OpCodes.Ceq));
						list.AddRange(ILHelper.Ldloc(nullInt1, true));
						list.Add(Instruction.Create(OpCodes.Call, module.GetMethod<int?>("get_HasValue")));
						list.Add(Instruction.Create(OpCodes.And));
						list.Add(Instruction.Create(OpCodes.Brtrue, next));

						list.Add(ILHelper.Ldarg(il));
						list.AddRange(ILHelper.Ldloc(localVariables[index]));
						list.Add(Instruction.Create(OpCodes.Newobj, nullableContainer.GetMethod(".ctor")));
						list.Add(item.GetSetInstruction());
						
						// ALE__GENERATED__lastModifyValue = var
						list.Add(ILHelper.Ldarg(il));
						list.AddRange(ILHelper.Ldloc(localVariables[index]));
						list.Add(Instruction.Create(OpCodes.Box, nullableType));
						list.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));

						// changed = true
						list.Add(ILHelper.Ldarg(il, paraChanged));
						list.Add(ILHelper.Bool(true));
						list.Add(Instruction.Create(OpCodes.Stind_I1));

						// return true
						list.Add(ILHelper.Bool(true));
						list.Add(Instruction.Create(OpCodes.Ret));
					}, list =>
					{
						// if (value == null && field.HasValue)
						list.Add(ILHelper.Ldarg(il, paraValue));
						list.Add(Instruction.Create(OpCodes.Brtrue, last));

						list.Add(ILHelper.Ldarg(il));
						list.Add(item.GetLoadInstruction(true));
						list.Add(Instruction.Create(OpCodes.Call, module.GetMethod(typeof(Nullable<>), "get_HasValue").MakeHostInstanceGeneric(module.GetTypeReference(typeof(Nullable<>)).MakeGenericInstanceType(nullableType))));
						list.Add(Instruction.Create(OpCodes.Brfalse, last));
						
						// field = null
						list.Add(ILHelper.Ldarg(il));
						list.Add(item.GetLoadInstruction(true));
						list.Add(Instruction.Create(OpCodes.Initobj, item.FieldType));
					
						// ALE__GENERATED__lastModifyValue = null
						list.Add(ILHelper.Ldarg(il));
						list.Add(Instruction.Create(OpCodes.Ldnull));
						list.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));
						
						// changed = true
						list.Add(ILHelper.Ldarg(il, paraChanged));
						list.Add(ILHelper.Bool(true));
						list.Add(Instruction.Create(OpCodes.Stind_I1));

						// return true
						list.Add(ILHelper.Bool(true));
						list.Add(Instruction.Create(OpCodes.Ret));
					}));
				}
				else if (!item.IsValueType && !item.IsCollection)
				{
					// Type var = value as Type
					fill.Add(ILHelper.Ldarg(il, paraValue));
					fill.Add(Instruction.Create(OpCodes.Isinst, item.FieldTypeComponentAware));
					fill.AddRange(ILHelper.Stloc(localVariables[index]));

					// if (var != null)
					fill.AddRange(ILHelper.Ldloc(localVariables[index]));
					fill.Add(Instruction.Create(OpCodes.Brfalse, last));

					// value = var
					fill.Add(ILHelper.Ldarg(il));
					fill.AddRange(ILHelper.Ldloc(localVariables[index]));
					fill.Add(item.GetSetInstruction());

					// ALE__GENERATED__lastModifyValue = var
					fill.Add(ILHelper.Ldarg(il));
					fill.AddRange(ILHelper.Ldloc(localVariables[index]));
					fill.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));
				}
				else if (item.IsValueType && !item.IsCollection)
				{
					// if (value is Type)
					fill.Add(ILHelper.Ldarg(il, paraValue));
					fill.Add(Instruction.Create(OpCodes.Isinst, item.FieldTypeComponentAware));
					fill.Add(Instruction.Create(OpCodes.Brfalse, last));

					// int var = (Type) value
					fill.Add(ILHelper.Ldarg(il, paraValue));
					fill.Add(Instruction.Create(OpCodes.Unbox_Any, item.FieldTypeComponentAware));
					fill.AddRange(ILHelper.Stloc(localVariables[index]));

					bool objectEquals = equals.DeclaringType.FullName == module.GetTypeReference<object>().FullName;

					// if (localVar != var)
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(item.GetLoadInstruction(!item.FieldType.IsPrimitive && !isInEquality));
					// If we're not doing inequality check and it's a property that is also a value type but is not a primitive,
					// create a new local variable for some reason and set it and load it, then never talk about it again.
					if (!isInEquality && item.IsProperty && item.IsValueType && !item.IsPrimitive)
					{
						VariableDefinition propertyVar = m.AddLocalVariable(item.FieldTypeComponentAware);
						fill.AddRange(ILHelper.Stloc(propertyVar));
						fill.AddRange(ILHelper.Ldloc(propertyVar, true));
					}

					fill.AddRange(ILHelper.Ldloc(localVariables[index]));
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

					// localVar = var
					fill.Add(ILHelper.Ldarg(il));
					fill.AddRange(ILHelper.Ldloc(localVariables[index]));
					fill.Add(item.GetSetInstruction());
				}

				if (!skipAssignValue)
				{
					// ALE__GENERATED__lastModifyValue = var
					fill.Add(ILHelper.Ldarg(il));
					fill.AddRange(ILHelper.Ldloc(localVariables[index]));
					fill.Add(Instruction.Create(OpCodes.Box, item.FieldTypeComponentAware));
					fill.Add(Instruction.Create(OpCodes.Stfld, lastModifyValueField));
					
					// changed = true
					fill.Add(ILHelper.Ldarg(il, paraChanged));
					fill.Add(ILHelper.Bool(true));
					fill.Add(Instruction.Create(OpCodes.Stind_I1));

					// return true
					fill.Add(ILHelper.Bool(true));
					fill.Add(Instruction.Create(OpCodes.Ret));
				}
			}, fill =>
			{
				if (isChild)
				{
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(ILHelper.Ldarg(il, paraValue));
					fill.Add(ILHelper.Ldarg(il, paraChanged));
					fill.Add(Instruction.Create(OpCodes.Call, baseMethod));
				}
				else
				{
					fill.Add(ILHelper.Bool(false));
				}

				fill.Add(Instruction.Create(OpCodes.Ret));
			});

			m.EndEdit();

			return m;
		}

		private static void CreateEndEdit(TypeDefinition type, ModuleDefinition module,  FieldReference editingIdField, FieldReference lastModifyValueField, FieldReference beginEditValueField)
		{
			MethodDefinition m = type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.EndEdit",
				MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.EndEdit), typeof(bool), typeof(ILevelEditorUndo)));

			ParameterDefinition paraNotify = m.AddParameter<bool>("notify");
			ParameterDefinition paraUndo = m.AddParameter<ILevelEditorUndo>("undo");

			FieldDefinition valueChangedField = CreateEvent(nameof(IExposedToLevelEditor.OnValueChanged), type, module);

			ILProcessor il = m.BeginEdit();

			il.EmitIfElse((last, list) =>
			{
				// if (notify)
				list.Add(ILHelper.Ldarg(il, paraNotify));
				list.Add(Instruction.Create(OpCodes.Brfalse, last));
			}, (last, list) =>
			{
				// OnValueChanged = this.ALE__GENERATED__OnValueChanged
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
					// OnValueChanged.Invoke(ALE__GENERATED__editingId, ALE__GENERATED__lastModifyValue)
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, lastModifyValueField));
					localList.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod<Action<int, object>>("Invoke", typeof(int), typeof(object))));
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
					// undo.AddAction(new SetValueUndoAction(this, ALE__GENERATED__editingId, ALE__GENERATED__beginEditValue, ALE__GENERATED__lastModifyValue)
					localList.Add(ILHelper.Ldarg(il, paraUndo));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, editingIdField));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, beginEditValueField));
					localList.Add(ILHelper.Ldarg(il));
					localList.Add(Instruction.Create(OpCodes.Ldfld, lastModifyValueField));
					localList.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<SetValueUndoAction>(typeof(IExposedToLevelEditor), typeof(int), typeof(object), typeof(object))));
					localList.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod<ILevelEditorUndo>(nameof(ILevelEditorUndo.AddAction), typeof(IUndoAction))));
				}, localList =>
				{
					// End method
					localList.Add(Instruction.Create(OpCodes.Ret));
				}));
			});

			m.EndEdit();
		}

		private void CreateGetProperties(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild)
		{
			const string properties_list_field = "ALE__GENERATED__propertiesList";
			FieldDefinition propertiesListField;

			if (isChild)
			{
				propertiesListField = type.GetFieldInBaseType(properties_list_field);
			}
			else
			{
				propertiesListField = type.AddField<List<ExposedField>>(properties_list_field, FieldAttributes.Private | FieldAttributes.InitOnly);
			}

			FieldDefinition cachedPropertiesField = type.AddField<ExposedField[]>($"ALE__GENERATED__{type.Name}__cachedProperties", FieldAttributes.Private | FieldAttributes.InitOnly);

			CreateCachedProperties(type, module, properties, isChild, propertiesListField, cachedPropertiesField);
			MethodDefinition getPropertiesMethod = CreateGetPropertiesMethod(type, module, isChild, cachedPropertiesField);

			if (!isChild)
			{
				getPropertiesClear ??= module.GetMethod<List<ExposedField>>(nameof(List<ExposedField>.Clear));
				
				MethodDefinition m = type.AddMethodOverride<IReadOnlyList<ExposedField>>("Hertzole.ALE.IExposedToLevelEditor.GetProperties",
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.GetProperties)));

				ILProcessor il = m.BeginEdit();

				// ALE__GENERATED__propertiesList.Clear()
				il.EmitLdarg();
				il.Emit(OpCodes.Ldfld, propertiesListField);
				il.Emit(OpCodes.Callvirt, getPropertiesClear);
				// ALE__GENERATED__GetProperties(ALE__GENERATED_propertiesList)
				il.EmitLdarg();
				il.EmitLdarg();
				il.Emit(OpCodes.Ldfld, propertiesListField);
				il.Emit(OpCodes.Callvirt, getPropertiesMethod);

				// return ALE__GENERATED__propertiesList
				il.EmitLdarg();
				il.Emit(OpCodes.Ldfld, propertiesListField);
				il.Emit(OpCodes.Ret);

				m.EndEdit();
			}
		}

		private static void CreateCachedProperties(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild, FieldReference propertiesListField, FieldReference cachedPropertiesField)
		{
			List<Instruction> instructionsList = new List<Instruction>();

			MethodDefinition ctor = type.GetConstructor();

			ILProcessor il = ctor.BeginEdit();

			// Cache it here so it doesn't need to be found for every item.
			MethodReference getTypeFromHandle = module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle));
			MethodReference exposedProperty = module.GetConstructor<ExposedProperty>(typeof(int), typeof(Type), typeof(string), typeof(string), typeof(bool));

			if (!isChild)
			{
				// ALE__GENERATED__propertiesList = new List<ExposedField>()
				instructionsList.Add(ILHelper.Ldarg(il));
				// Prepare the list with the same amount of properties that we know of.
				instructionsList.Add(ILHelper.Int(properties.Count));
				instructionsList.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<List<ExposedField>>(typeof(int))));
				instructionsList.Add(Instruction.Create(OpCodes.Stfld, propertiesListField));
			}

			// ALE__GENERATED__cachedProperties = array
			instructionsList.Add(ILHelper.Ldarg(il));
			// ExposedField[] array = new ExposedField[count]
			instructionsList.Add(ILHelper.Int(properties.Count));
			instructionsList.Add(Instruction.Create(OpCodes.Newarr, module.GetTypeReference<ExposedField>()));
			for (int i = 0; i < properties.Count; i++)
			{
				// array[i] = new ExposedProperty(id, type, name, customName, visible)
				instructionsList.Add(Instruction.Create(OpCodes.Dup));
				instructionsList.Add(ILHelper.Int(i)); // Index
				instructionsList.Add(ILHelper.Int(properties[i].Id)); // Id
				instructionsList.Add(Instruction.Create(OpCodes.Ldtoken, properties[i].FieldType)); // Type
				instructionsList.Add(Instruction.Create(OpCodes.Call, getTypeFromHandle));
				instructionsList.Add(Instruction.Create(OpCodes.Ldstr, properties[i].Name));
				// If there's a custom name, load it. Otherwise just put a null.
				if (string.IsNullOrWhiteSpace(properties[i].CustomName))
				{
					instructionsList.Add(Instruction.Create(OpCodes.Ldnull));
				}
				else
				{
					instructionsList.Add(Instruction.Create(OpCodes.Ldstr, properties[i].CustomName));
				}

				instructionsList.Add(ILHelper.Bool(properties[i].Visible)); // Visible
				instructionsList.Add(Instruction.Create(OpCodes.Newobj, exposedProperty));
				instructionsList.Add(Instruction.Create(OpCodes.Stelem_Ref));
			}

			instructionsList.Add(Instruction.Create(OpCodes.Stfld, cachedPropertiesField));

			il.InsertAt(0, instructionsList);

			ctor.EndEdit();
		}

		private MethodDefinition CreateGetPropertiesMethod(TypeDefinition type, ModuleDefinition module, bool isChild, FieldReference cachedPropertiesField)
		{
			MethodDefinition m;
			if (isChild)
			{
				m = type.AddMethod(GET_PROPERTIES_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual);
			}
			else
			{
				m = type.AddMethod(GET_PROPERTIES_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);
			}

			ParameterDefinition paraList = m.AddParameter<List<ExposedField>>("list");

			ILProcessor il = m.BeginEdit();

			getPropertiesAddRange ??= module.GetMethod<List<ExposedField>>(nameof(List<ExposedField>.AddRange));
			
			if (isChild)
			{
				MethodDefinition baseMethod = type.GetMethodInBaseType(GET_PROPERTIES_METHOD, false);

				// base.ALE__GENERATED__GetProperties(properties)
				il.EmitLdarg();
				il.EmitLdarg(paraList);
				il.Emit(OpCodes.Call, baseMethod);
			}

			// properties.AddRange(cachedProperties)
			il.EmitLdarg(paraList);
			il.EmitLdarg();
			il.Emit(OpCodes.Ldfld, cachedPropertiesField);
			il.Emit(OpCodes.Callvirt, getPropertiesAddRange);
			il.Emit(OpCodes.Ret);

			m.EndEdit();

			return m;
		}

		private static void CreateGetValue(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild)
		{
			MethodDefinition helperMethod = CreateGetValueHelper(type, module, properties, isChild);

			if (!isChild)
			{
				MethodDefinition m = type.AddMethodOverride<object>("Hertzole.ALE.IExposedToLevelEditor.GetValue",
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.GetValue), typeof(int)));

				ParameterDefinition paraId = m.AddParameter<int>("id");

				ILProcessor il = m.BeginEdit();
				il.Body.InitLocals = true;

				VariableDefinition varValue = m.AddLocalVariable<object>("value");

				il.EmitIfElse((last, list) =>
				{
					// if (ALE__GENERATED__GetValue(id, out value))
					list.Add(ILHelper.Ldarg(il));
					list.Add(ILHelper.Ldarg(il, paraId));
					list.AddRange(ILHelper.Ldloc(varValue, true));
					list.Add(Instruction.Create(OpCodes.Callvirt, helperMethod));
					list.Add(Instruction.Create(OpCodes.Brfalse, last));
				}, (last, list) =>
				{
					// return value
					list.AddRange(ILHelper.Ldloc(varValue));
					list.Add(Instruction.Create(OpCodes.Ret));
				}, list =>
				{
					// throw new InvalidExposedPropertyException(id)
					list.Add(ILHelper.Ldarg(il, paraId));
					list.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<InvalidExposedPropertyException>(typeof(int))));
					list.Add(Instruction.Create(OpCodes.Throw));
				});

				m.EndEdit();
			}
		}

		private static MethodDefinition CreateGetValueHelper(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild)
		{
			MethodDefinition m;
			if (isChild)
			{
				m = type.AddMethod<bool>(GET_VALUE_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual);
			}
			else
			{
				m = type.AddMethod<bool>(GET_VALUE_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);
			}

			ParameterDefinition paraId = m.AddParameter<int>("id");
			ParameterDefinition paraValue = m.AddParameter(module.GetTypeReference(typeof(object).MakeByRefType()), "value");

			paraValue.IsOut = true;

			ILProcessor il = m.BeginEdit();

			il.EmitIfElse(properties, (item, i, target, body, list) =>
			{
				// if (id == i)
				list.Add(ILHelper.Ldarg(il, paraId));
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
				// value = this.value
				list.Add(ILHelper.Ldarg(il, paraValue));
				list.Add(ILHelper.Ldarg(il));
				list.Add(item.GetLoadInstruction());
				if (item.IsComponent)
				{
					if (item.IsCollection)
					{
						list.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(IReadOnlyList<GameObject>) : typeof(IReadOnlyList<Component>))));
					}
					else
					{
						list.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor<ComponentDataWrapper>(item.IsGameObject ? typeof(GameObject) : typeof(Component))));
					}
				}

				if (item.IsValueType)
				{
					list.Add(Instruction.Create(OpCodes.Box, item.FieldTypeComponentAware));
				}

				list.Add(Instruction.Create(OpCodes.Stind_Ref));
				// return true
				list.Add(ILHelper.Bool(true));
				list.Add(Instruction.Create(OpCodes.Ret));
			}, list =>
			{
				if (!isChild)
				{
					// value = null
					list.Add(ILHelper.Ldarg(il, paraValue));
					list.Add(Instruction.Create(OpCodes.Ldnull));
					list.Add(Instruction.Create(OpCodes.Stind_Ref));
					// return false
					list.Add(ILHelper.Bool(false));
				}
				else
				{
					MethodDefinition baseMethod = type.GetMethodInBaseType(GET_VALUE_METHOD, false);

					// return base.ALE__GENERATED__GetValue(id, out value)
					list.Add(ILHelper.Ldarg(il));
					list.Add(ILHelper.Ldarg(il, paraId));
					list.Add(ILHelper.Ldarg(il, paraValue));
					list.Add(Instruction.Create(OpCodes.Call, baseMethod));
				}

				list.Add(Instruction.Create(OpCodes.Ret));
			});

			m.EndEdit();

			return m;
		}

		private static void CreateGetWrapper(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> allProperties, bool isChild, TypeDefinition wrapper)
		{
			MethodDefinition getWrapperMethod = CreateGetWrapperHelper(type, module, allProperties, isChild, wrapper);

			if (!isChild)
			{
				MethodDefinition m = type.AddMethodOverride<IExposedWrapper>("Hertzole.ALE.IExposedToLevelEditor.GetWrapper",
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.GetWrapper)));

				ILProcessor il = m.BeginEdit();

				// return ALE__GENERATED__GetWrapper()
				il.EmitLdarg();
				il.Emit(OpCodes.Callvirt, getWrapperMethod);
				il.Emit(OpCodes.Ret);

				m.EndEdit();
			}
		}

		private static MethodDefinition CreateGetWrapperHelper(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild, TypeDefinition wrapper)
		{
			MethodDefinition m;
			if (isChild)
			{
				m = type.AddMethod<IExposedWrapper>(GET_WRAPPER_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual);
			}
			else
			{
				m = type.AddMethod<IExposedWrapper>(GET_WRAPPER_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual);
			}

			VariableDefinition varWrapper = m.AddLocalVariable(wrapper);

			ILProcessor il = m.BeginEdit();
			il.Body.InitLocals = true;

			// Wrapper wrapper = default(Wrapper)
			il.EmitLdloc(varWrapper, true);
			il.Emit(OpCodes.Initobj, wrapper);

			// wrapper.values = new Dictionary<int, object>(1) { { id, value } }
			MethodReference addValueMethod = module.GetMethod<Dictionary<int, object>>("Add").MakeHostInstanceGeneric(module.GetTypeReference(typeof(Dictionary<,>)).MakeGenericInstanceType(module.GetTypeReference<int>(), module.GetTypeReference<object>()));
			il.EmitLdloc(varWrapper, true);
			il.EmitInt(properties.Count);
			il.Emit(OpCodes.Newobj, module.GetConstructor<Dictionary<int, object>>(typeof(int)));
			for (int i = 0; i < properties.Count; i++)
			{
				properties[i].MakeProtected();
				
				il.Emit(OpCodes.Dup);
				il.EmitInt(properties[i].Id);
				il.EmitLdarg();
				il.Append(properties[i].GetLoadInstruction());
				if (properties[i].IsComponent)
				{
					MethodReference componentConstructor;
					
					if (properties[i].IsGameObject)
					{
						componentConstructor = module.GetConstructor<ComponentDataWrapper>(properties[i].IsCollection ? typeof(IReadOnlyList<GameObject>) : typeof(GameObject));
					}
					else
					{
						componentConstructor = module.GetConstructor<ComponentDataWrapper>(properties[i].IsCollection ? typeof(IReadOnlyList<Component>) : typeof(Component));
					}

					il.Emit(OpCodes.Newobj, componentConstructor);
				}
				
				if (properties[i].IsValueType)
				{
					il.Emit(OpCodes.Box, properties[i].FieldTypeComponentAware);
				}

				il.Emit(OpCodes.Callvirt, addValueMethod);
			}

			il.Emit(OpCodes.Call, wrapper.GetProperty(nameof(IExposedWrapper.Values)).SetMethod);

			// wrapper.dirty = new Dictionary<int, bool>(1) { { id, false } }
			MethodReference addDirtyMethod = module.GetMethod<Dictionary<int, bool>>("Add").MakeHostInstanceGeneric(module.GetTypeReference(typeof(Dictionary<,>)).MakeGenericInstanceType(module.GetTypeReference<int>(), module.GetTypeReference<bool>()));
			il.EmitLdloc(varWrapper, true);
			il.EmitInt(properties.Count);
			il.Emit(OpCodes.Newobj, module.GetConstructor<Dictionary<int, bool>>(typeof(int)));
			for (int i = 0; i < properties.Count; i++)
			{
				il.Emit(OpCodes.Dup);
				il.EmitInt(properties[i].Id);
				il.EmitBool(false);
				il.Emit(OpCodes.Callvirt, addDirtyMethod);
			}

			il.Emit(OpCodes.Call, wrapper.GetProperty(nameof(IExposedWrapper.Dirty)).SetMethod);

			// return wrapper
			il.EmitLdloc(varWrapper);
			il.Emit(OpCodes.Box, wrapper);
			il.Emit(OpCodes.Ret);

			m.EndEdit();

			return m;
		}

		private static void CreateApplyWrapper(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> allProperties, bool isChild)
		{
			MethodDefinition helperMethod = CreateApplyWrapperHelper(type, module, allProperties, isChild);

			if (!isChild)
			{
				MethodDefinition m = type.AddMethodOverride("Hertzole.ALE.IExposedToLevelEditor.ApplyWrapper",
					MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
					module.GetMethod<IExposedToLevelEditor>(nameof(IExposedToLevelEditor.ApplyWrapper)));

				ParameterDefinition paraWrapper = m.AddParameter<IExposedWrapper>("wrapper");
				ParameterDefinition paraIgnoreDirtyCheck = m.AddParameter<bool>("ignoreDirtyCheck");

				ILProcessor il = m.BeginEdit();

				// ALE__GENERATED__ApplyWrapper(wrapper)
				il.EmitLdarg();
				il.EmitLdarg(paraWrapper);
				il.EmitLdarg(paraIgnoreDirtyCheck);
				il.Emit(OpCodes.Callvirt, helperMethod);
				il.Emit(OpCodes.Ret);

				m.EndEdit();
			}
		}

		private static MethodDefinition CreateApplyWrapperHelper(TypeDefinition type, ModuleDefinition module, IReadOnlyList<IExposedProperty> properties, bool isChild)
		{
			MethodDefinition m = type.AddMethod(APPLY_WRAPPER_METHOD, MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.Virtual);
			if (!isChild)
			{
				m.Attributes |= MethodAttributes.NewSlot;
			}

			ParameterDefinition paraWrapper = m.AddParameter<IExposedWrapper>("wrapper");
			ParameterDefinition paraIgnoreDirtyCheck = m.AddParameter<bool>("ignoreDirtyCheck");

			ILProcessor il = m.BeginEdit();

			if (isChild)
			{
				// base.ALE__GENERATED_ApplyWrapper(wrapper, ignoreDirtyCheck)
				var baseMethod = type.GetMethodInBaseType(APPLY_WRAPPER_METHOD, false);
				il.EmitLdarg();
				il.EmitLdarg(paraWrapper);
				il.EmitLdarg(paraIgnoreDirtyCheck);
				il.Emit(OpCodes.Call, baseMethod);
			}

			il.EmitIfElse(properties, (property, index, next, body, fill) =>
			{
				// if (ignoreDirtyCheck || wrapper.IsDirty(id))
				fill.Add(ILHelper.Ldarg(il, paraIgnoreDirtyCheck));
				fill.Add(Instruction.Create(OpCodes.Brtrue, body));
				
				fill.Add(ILHelper.Ldarg(il, paraWrapper));
				fill.Add(ILHelper.Int(property.Id));
				fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod(typeof(LevelEditorExtensions), nameof(LevelEditorExtensions.IsDirty))));
				fill.Add(Instruction.Create(OpCodes.Brfalse, next));
			}, (property, index, next, fill) =>
			{
				Instruction startSetValue = ILHelper.Ldarg(il, property.IsList ? paraWrapper : null);
				
				if (property.IsList)
				{
					bool component = false;
					VariableDefinition tempComponent = null;
					VariableDefinition tempList;
					if (property.FieldType.GetCollectionType().IsComponent())
					{
						component = true;
						tempComponent = m.AddLocalVariable<ComponentDataWrapper>();
						tempList = m.AddLocalVariable(property.FieldType.GetCollectionType().MakeArrayType());
					}
					else
					{
						tempList = m.AddLocalVariable(property.FieldType);
					}

					Instruction clearList = ILHelper.Ldarg(il);

					// if (list == null)
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(property.GetLoadInstruction());
					fill.Add(Instruction.Create(OpCodes.Brtrue, clearList));
					
					// list = new List<Type>()
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(Instruction.Create(OpCodes.Newobj, module.GetConstructor(typeof(List<>)).MakeHostInstanceGeneric(
						module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(property.FieldType.GetCollectionType()))));

					fill.Add(property.GetSetInstruction());
					fill.Add(Instruction.Create(OpCodes.Br, startSetValue));

					// list.Clear()
					fill.Add(clearList);
					fill.Add(property.GetLoadInstruction());
					fill.Add(Instruction.Create(OpCodes.Callvirt, module.GetMethod(typeof(List<>), "Clear").MakeHostInstanceGeneric(
						module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(property.FieldType.GetCollectionType()))));

					// value = wrapper.GetValue<Type>(id) || Type[] tempValue = wrapper.GetValue<Type>(id)
					fill.Add(startSetValue);
					fill.Add(ILHelper.Int(property.Id));
					fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod(typeof(LevelEditorExtensions), nameof(LevelEditorExtensions.GetValue)).MakeGenericMethod(property.FieldTypeComponentAware)));
					fill.AddRange(ILHelper.Stloc(component ? tempComponent : tempList));
						
					// if (tempValue != null)
					fill.AddRange(ILHelper.Ldloc(component ? tempComponent : tempList, property.IsComponent));
					if (component)
					{
						fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod<ComponentDataWrapper>("GetObjects", System.Type.EmptyTypes).MakeGenericMethod(property.FieldType.GetCollectionType())));
						fill.AddRange(ILHelper.Stloc(tempList));
						fill.AddRange(ILHelper.Ldloc(tempList));
					}
					
					fill.Add(Instruction.Create(OpCodes.Brfalse, next));
						
					fill.Add(ILHelper.Ldarg(il));
					fill.Add(property.GetLoadInstruction());
					fill.AddRange(ILHelper.Ldloc(tempList));
					if (component)
					{
						fill.Add(Instruction.Create(OpCodes.Callvirt, module.ImportReference(typeof(List<>).GetMethod("AddRange"))
                                                                            .MakeGenericMethod(module.GetTypeReference(typeof(IEnumerable<>))
                                                                                                     .MakeGenericInstanceType(property.FieldType.GetCollectionType()))
                                                                            .MakeHostInstanceGeneric(module.GetTypeReference(typeof(List<>))
                                                                                                           .MakeGenericInstanceType(property.FieldType.GetCollectionType()))));
					}
				}
				else
				{
					// value = wrapper.GetValue<Type>(id)
					fill.Add(startSetValue);
					fill.Add(ILHelper.Ldarg(il, paraWrapper));
					fill.Add(ILHelper.Int(property.Id));
					fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod(typeof(LevelEditorExtensions), nameof(LevelEditorExtensions.GetValue)).MakeGenericMethod(property.FieldTypeComponentAware)));
				}

				if (property.IsComponent && !property.IsList)
				{
					VariableDefinition localVar = m.AddLocalVariable<ComponentDataWrapper>();
					fill.AddRange(ILHelper.Stloc(localVar));
					fill.AddRange(ILHelper.Ldloc(localVar, true));
					if (property.IsCollection && !property.IsList)
					{
						fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod<ComponentDataWrapper>("GetObjects", System.Type.EmptyTypes).MakeGenericMethod(property.FieldType.GetCollectionType())));
						if (property.IsList)
						{
							fill.Add(Instruction.Create(OpCodes.Callvirt, module.ImportReference(typeof(List<>).GetMethod("AddRange"))
							                                                    .MakeGenericMethod(module.GetTypeReference(typeof(IEnumerable<>))
							                                                                             .MakeGenericInstanceType(property.FieldType.GetCollectionType()))
							                                                    .MakeHostInstanceGeneric(module.GetTypeReference(typeof(List<>))
							                                                                                   .MakeGenericInstanceType(property.FieldType.GetCollectionType()))));
						}
					}
					else if(!property.IsList)
					{
						fill.Add(Instruction.Create(OpCodes.Call, module.GetMethod<ComponentDataWrapper>("GetObject", System.Type.EmptyTypes).MakeGenericMethod(property.FieldType)));
					}
				}
				else if (!property.IsComponent && property.IsList)
				{
					MethodReference addRange = module.GetMethod(typeof(List<>), "AddRange").MakeGenericMethod(property.FieldType.GetCollectionType())
					                                 .MakeHostInstanceGeneric(module.GetTypeReference(typeof(List<>)).MakeGenericInstanceType(property.FieldType.GetCollectionType()));
					
					fill.Add(Instruction.Create(OpCodes.Callvirt, addRange));
				}

				if (!property.IsList)
				{
					fill.Add(property.GetSetInstruction());
				}
			}, fill => { fill.Add(Instruction.Create(OpCodes.Ret)); });

			m.EndEdit();

			return m;
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

		private void GetExposedProperties(TypeDefinition type, List<IExposedProperty> properties, ICollection<int> usedPropertyIds)
		{
			properties.Clear();
			usedPropertyIds.Clear();

			FindExposedFields(type, properties);
			FindExposedProperties(type, properties);

			if (properties.Count == 0)
			{
				return;
			}

			FindDuplicateExposedProperties(properties, usedPropertyIds, 0);

			properties.Sort((x, y) => x.Order.CompareTo(y.Order));
		}

		private void GetAllExposedProperties(TypeDefinition type, List<IExposedProperty> properties, ICollection<int> usedPropertyIds)
		{
			if (type.BaseType != null && type.BaseType.CanBeResolved())
			{
				GetAllExposedProperties(type.BaseType.Resolve(), properties, usedPropertyIds);
			}

			bool start = properties.Count == 0;
			int myPropertyStart = properties.Count;

			FindExposedFields(type, properties);
			FindExposedProperties(type, properties);

			if (properties.Count == 0)
			{
				return;
			}

			FindDuplicateExposedProperties(properties, usedPropertyIds, myPropertyStart);

			if (start)
			{
				properties.Sort((x, y) => x.Order.CompareTo(y.Order));
			}
		}

		private static void FindExposedFields(TypeDefinition type, List<IExposedProperty> properties)
		{
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

						properties.Add(new ExposedFieldProperty(type.Fields[i], customOrder));
					}
				}
			}
		}

		private static void FindExposedProperties(TypeDefinition type, List<IExposedProperty> properties)
		{
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

						properties.Add(new ExposedPropertyProperty(type.Properties[i], customOrder));
					}
				}
			}
		}
		
		private void FindDuplicateExposedProperties(List<IExposedProperty> properties, ICollection<int> usedPropertyIds, int myPropertyStart)
		{
			for (int i = myPropertyStart; i < properties.Count; i++)
			{
				if (usedPropertyIds.Contains(properties[i].Id))
				{
					throw new DuplicateIDException($"{properties[i].Name} has a duplicate ID {properties[i].Id}. IDs need to be unique.");
				}

				usedPropertyIds.Add(properties[i].Id);
				// Must generate a formatter for this type.
				Formatters.AddTypeToGenerate(properties[i].FieldType);
			}
		}
	}
}