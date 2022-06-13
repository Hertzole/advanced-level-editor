using System;
using System.Collections.Generic;
using Hertzole.ALE.CodeGen.Helpers;
using MessagePack;
using MessagePack.Formatters;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.CodeGen
{
	public class ResolverProcessor
	{
		private bool isBuildingPlayer;
		
		private readonly List<(TypeReference formatter, TypeReference type)> allFormatters = new List<(TypeReference, TypeReference)>();
		private readonly List<TypeReference> customDataTypes = new List<TypeReference>();
		private readonly List<TypeDefinition> enums = new List<TypeDefinition>();
		private readonly ModuleDefinition module;
		private readonly List<(TypeReference, TypeReference)> typeFormatters = new List<(TypeReference, TypeReference)>();
		private readonly List<(TypeDefinition, TypeDefinition, TypeDefinition)> wrapperFormatters = new List<(TypeDefinition, TypeDefinition, TypeDefinition)>();

		private readonly HashSet<TypeReference> addedTypes = new HashSet<TypeReference>(new TypeReferencerComparer());

		private FieldDefinition formatterField;
		private MethodDefinition getFormatterHelperMethod;
		private MethodDefinition getFormatterMethod;
		private FieldDefinition instanceField;

		private TypeDefinition resolver;

		public ResolverProcessor(ModuleDefinition moduleDefinition)
		{
			module = moduleDefinition;
		}

		public void AddWrapperFormatter(TypeDefinition formatter, TypeDefinition wrapperType, TypeDefinition baseClass)
		{
			wrapperFormatters.Add((formatter, wrapperType, baseClass));
		}

		public void AddTypeFormatter(TypeReference formatter, TypeReference type)
		{
			for (int i = 0; i < typeFormatters.Count; i++)
			{
				if (typeFormatters[i].Item1.FullName == formatter.FullName && typeFormatters[i].Item2.FullName == type.FullName)
				{
					return;
				}
			}
			
			typeFormatters.Add((module.ImportReference(formatter), module.ImportReference(type)));
		}

		public void AddCustomDataType(TypeReference type)
		{
			if (customDataTypes.Contains(type) || addedTypes.Contains(type))
			{
				return;
			}
			
			if (type is GenericInstanceType genericType)
			{
				for (int i = 0; i < genericType.GenericArguments.Count; i++)
				{
					AddCustomDataType(genericType.GenericArguments[i]);
				}
				
				customDataTypes.Add(genericType);
				addedTypes.Add(genericType);
				AddTypeWithoutFormatter(genericType);

				return;
			}
			
			if (type.IsArray())
			{
				customDataTypes.Add(type);
				addedTypes.Add(type);
				AddCustomDataType(type.GetCollectionType());
				return;
			}
			
			TypeDefinition resolved = type.Resolve();
			if (resolved == null || customDataTypes.Contains(resolved) || resolved.IsCollection() || resolved.IsComponent())
			{
				return;
			}

			if (resolved.IsEnum())
			{
				customDataTypes.Add(resolved);
				allFormatters.Add((null, resolved));
				addedTypes.Add(resolved);
				return;
			}

			customDataTypes.Add(type);
			addedTypes.Add(type);
		}

		public void AddEnum(TypeDefinition type)
		{
			if (addedTypes.Contains(type))
			{
				return;
			}
			
			enums.Add(type);
			addedTypes.Add(type);
		}

		public void AddTypeWithoutFormatter(TypeReference type)
		{
			if (addedTypes.Contains(type))
			{
				return;
			}
			
			allFormatters.Add((null, type));
			addedTypes.Add(type);
		}

		public void EndEditing(bool isBuilding)
		{
			isBuildingPlayer = isBuilding;
			
			for (int i = 0; i < wrapperFormatters.Count; i++)
			{
				allFormatters.Add((wrapperFormatters[i].Item1, wrapperFormatters[i].Item2));
			}

			for (int i = 0; i < typeFormatters.Count; i++)
			{
				allFormatters.Add((typeFormatters[i].Item1, typeFormatters[i].Item2));
			}

			for (int i = 0; i < enums.Count; i++)
			{
				allFormatters.Add((null, enums[i]));
			}

			if (allFormatters == null || allFormatters.Count == 0)
			{
				return;
			}

			resolver = CreateResolverClass();
			module.Types.Add(resolver);

			resolver.NestedTypes.Add(CreateFormatterHelper());
			resolver.Methods.Add(CreateRegisterMethod());
			resolver.NestedTypes.Add(CreateFormatterCache());
			resolver.Methods.Add(CreateGetFormatter());
			resolver.Methods.Add(CreateSerializeWrapperMethod());
			resolver.Methods.Add(CreateDeserializeWrapperMethod());
			resolver.Methods.Add(CreateSerializeDynamicMethod());
			resolver.Methods.Add(CreateDeserializeDynamicMethod());
		}

		private TypeDefinition CreateResolverClass()
		{
			TypeDefinition t = new TypeDefinition("Hertzole.ALE.Generated", $"{module.Name.Substring(0, module.Name.Length - 4).Replace('-', '_').Replace('.', '_')}__ALE__Generated__Resolver",
				TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit, module.GetTypeReference<object>());

			t.Interfaces.Add(new InterfaceImplementation(module.ImportReference(typeof(IFormatterResolver))));
			t.Interfaces.Add(new InterfaceImplementation(module.ImportReference(typeof(IWrapperSerializer))));
			t.Interfaces.Add(new InterfaceImplementation(module.ImportReference(typeof(IDynamicResolver))));

			instanceField = new FieldDefinition("instance", FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.InitOnly, module.GetTypeReference<IFormatterResolver>());
			t.Fields.Add(instanceField);

			MethodDefinition ctor = new MethodDefinition(".ctor", MethodAttributes.Private | MethodAttributes.HideBySig |
			                                                      MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
				module.ImportReference(typeof(void)));

			t.Methods.Add(ctor);

			ILProcessor il = ctor.Body.GetILProcessor();
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Call, module.GetConstructor<object>());
			il.Emit(OpCodes.Ret);

			il.Body.Optimize();

			MethodDefinition cctor = new MethodDefinition(".cctor", MethodAttributes.Private | MethodAttributes.HideBySig |
			                                                        MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Static,
				module.GetTypeReference(typeof(void)));

			t.Methods.Add(cctor);

			il = cctor.Body.GetILProcessor();
			il.Emit(OpCodes.Newobj, ctor);
			il.Emit(OpCodes.Stsfld, instanceField);
			il.Emit(OpCodes.Ret);

			return t;
		}

		private MethodDefinition CreateRegisterMethod()
		{
			MethodDefinition m = new MethodDefinition("RegisterResolver", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static,
				module.GetTypeReference(typeof(void)));

			CustomAttribute a;

			if (isBuildingPlayer)
			{
				a = new CustomAttribute(module.GetConstructor<RuntimeInitializeOnLoadMethodAttribute>(typeof(RuntimeInitializeLoadType)));
				a.ConstructorArguments.Add(new CustomAttributeArgument(module.GetTypeReference<RuntimeInitializeLoadType>(), RuntimeInitializeLoadType.BeforeSceneLoad));
			}
			else
			{
				a = new CustomAttribute(module.GetConstructor<InitializeOnLoadMethodAttribute>());
			}
			m.CustomAttributes.Add(a);

			MethodReference cctor = resolver.GetMethod(".cctor");

			FieldDefinition registeredField = new FieldDefinition("registeredResolver", FieldAttributes.Private | FieldAttributes.Static,
				module.GetTypeReference<bool>());

			resolver.Fields.Add(registeredField);

			ILProcessor il = cctor.Resolve().Body.GetILProcessor();

			il.InsertBefore(il.Body.Instructions[0], Instruction.Create(OpCodes.Ldc_I4_0));
			il.InsertBefore(il.Body.Instructions[1], Instruction.Create(OpCodes.Stsfld, registeredField));

			cctor.Resolve().Body.Optimize();

			il = m.Body.GetILProcessor();

			il.Emit(OpCodes.Ldsfld, registeredField);
			il.Emit(OpCodes.Ret);

			Instruction start = Instruction.Create(OpCodes.Ldc_I4_1);
			il.Append(start);
			il.InsertAfter(il.Body.Instructions[0], Instruction.Create(OpCodes.Brfalse, start));
			il.Emit(OpCodes.Stsfld, registeredField);

			il.Emit(OpCodes.Ldsfld, instanceField);
			il.Emit(OpCodes.Call, module.GetMethod<LevelEditorResolver>("RegisterResolver", typeof(IFormatterResolver)));
			il.Emit(OpCodes.Ldsfld, instanceField);
			il.Emit(OpCodes.Castclass, module.GetTypeReference<IWrapperSerializer>());
			il.Emit(OpCodes.Call, module.GetMethod<LevelEditorResolver>("RegisterWrapperSerializer", typeof(IWrapperSerializer)));
			il.Emit(OpCodes.Ldsfld, instanceField);
			il.Emit(OpCodes.Castclass, module.GetTypeReference<IDynamicResolver>());
			il.Emit(OpCodes.Call, module.GetMethod<LevelEditorResolver>("RegisterDynamicResolver", typeof(IDynamicResolver)));

			for (int i = 0; i < wrapperFormatters.Count; i++)
			{
#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, "Registering wrapper formatter: " + wrapperFormatters[i].Item3.FullName + " with hash " + wrapperFormatters[i].Item3.FullName.GetStableHashCode());
				il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
				
				il.EmitInt(wrapperFormatters[i].Item3.FullName.GetStableHashCode());
				il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorSerializer), "RegisterType", typeof(int)).MakeGenericMethod(wrapperFormatters[i].Item3));

				if (wrapperFormatters[i].Item3.TryGetAttributes<FormerlyHashedAsAttribute>(out CustomAttribute[] formerHashedAttributes))
				{
					for (int j = 0; j < formerHashedAttributes.Length; j++)
					{
						il.EmitInt(formerHashedAttributes[j].GetConstructorArgument(0, string.Empty).GetStableHashCode());
						il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorSerializer), "RegisterType", typeof(int)).MakeGenericMethod(wrapperFormatters[i].Item3));
					}
				}
			}

			for (int i = 0; i < customDataTypes.Count; i++)
			{
#if ALE_DEBUG
				il.Emit(OpCodes.Ldstr, "Registering custom type: " + customDataTypes[i].GetFullName() + " with hash " + customDataTypes[i].GetFullName().GetStableHashCode());
				il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
				
				il.EmitInt(customDataTypes[i].GetFullName().GetStableHashCode());
				il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorSerializer), "RegisterType", typeof(int)).MakeGenericMethod(customDataTypes[i]));

				var resolved = customDataTypes[i].Resolve();
				if (resolved != null && resolved.TryGetAttributes<FormerlyHashedAsAttribute>(out CustomAttribute[] formerHashedAttributes))
				{
					for (int j = 0; j < formerHashedAttributes.Length; j++)
					{
						il.EmitInt(formerHashedAttributes[j].GetConstructorArgument(0, string.Empty).GetStableHashCode());
						il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorSerializer), "RegisterType", typeof(int)).MakeGenericMethod(customDataTypes[i]));
					}
				}
			}

			il.Emit(OpCodes.Ret);

			m.Body.Optimize();

			return m;
		}

		private TypeDefinition CreateFormatterHelper()
		{
			TypeDefinition t = new TypeDefinition(string.Empty, "GetFormatterHelper", TypeAttributes.NestedAssembly | TypeAttributes.AnsiClass | TypeAttributes.Abstract | TypeAttributes.Sealed,
				module.GetTypeReference<object>());

			FieldDefinition lookup = new FieldDefinition("lookup", FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.InitOnly,
				module.GetTypeReference<Dictionary<Type, int>>());

			t.Fields.Add(lookup);

			MethodDefinition cctor = new MethodDefinition(".cctor", MethodAttributes.Private | MethodAttributes.HideBySig |
			                                                        MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Static,
				module.Void());

			t.Methods.Add(cctor);

			ILProcessor il = cctor.Body.GetILProcessor();
			il.Emit(OpCodes.Newobj, module.GetConstructor<Dictionary<Type, int>>());

			MethodReference getType = module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle));

			for (int i = 0; i < allFormatters.Count; i++)
			{
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Ldtoken, module.ImportReference(allFormatters[i].Item2));
				il.Emit(OpCodes.Call, getType);
				il.Emit(OpCodes.Ldc_I4, i);
				il.Emit(OpCodes.Callvirt, module.GetMethod(typeof(Dictionary<Type, int>), "Add"));
			}

			il.Emit(OpCodes.Stsfld, lookup);
			il.Emit(OpCodes.Ret);

			cctor.Body.Optimize();

			getFormatterHelperMethod = new MethodDefinition("GetFormatter", MethodAttributes.Assembly | MethodAttributes.HideBySig | MethodAttributes.Static,
				module.GetTypeReference<object>());

			t.Methods.Add(getFormatterHelperMethod);

			getFormatterHelperMethod.AddParameter<Type>(module);
			VariableDefinition keyVar = getFormatterHelperMethod.AddLocalVariable<int>(module);

			il = getFormatterHelperMethod.Body.GetILProcessor();
			
#if ALE_DEBUG
			il.Emit(OpCodes.Ldstr, "GetFormatterHelper :: GetFormatter {0}");
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Call, module.GetMethod<string>("Format", typeof(string), typeof(object)));
			il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif

			il.Emit(OpCodes.Ldsfld, lookup);
			il.Emit(OpCodes.Ldarg_0);
			il.EmitLdloc(keyVar, true);
			il.Emit(OpCodes.Callvirt, module.GetMethod(typeof(Dictionary<Type, int>), "TryGetValue"));

			il.Emit(OpCodes.Ldnull);
			il.Emit(OpCodes.Ret);

			il.Emit(OpCodes.Ldloc_0);
			il.InsertAfter(il.Body.Instructions[il.Body.Instructions.Count - 4], Instruction.Create(OpCodes.Brtrue, il.Body.Instructions[il.Body.Instructions.Count - 1]));

			il.EmitSwitch(allFormatters, (formatter, i) => // Case
			{
				MethodReference ctor;
				
				if (formatter.type.IsArray())
				{
					ctor = module.GetGenericConstructor(typeof(ArrayFormatter<>), formatter.type.GetCollectionType());
				}
				else if (formatter.type.IsList())
				{
					ctor = module.GetGenericConstructor(typeof(ListFormatter<>), formatter.type.GetCollectionType());
				}
				else if (formatter.type.IsEnum())
				{
					ctor = module.GetGenericConstructor(typeof(GenericEnumFormatter<>), formatter.type);
				}
				else if (formatter.type.IsDictionary() && formatter.type is GenericInstanceType dictionaryType)
				{
					ctor = module.GetGenericConstructor(typeof(DictionaryFormatter<,>), dictionaryType.GenericArguments[0], dictionaryType.GenericArguments[1]);
				}
				else if (formatter.type.IsNullable(out TypeReference nullableType))
				{
					ctor = module.GetGenericConstructor(typeof(NullableFormatter<>), nullableType);
				}
				else
				{
					ctor = module.ImportReference(formatter.formatter).Resolve().GetConstructor();

					if (formatter.Item1 is GenericInstanceType genericType)
					{
						TypeReference[] genericTypes = new TypeReference[genericType.GenericArguments.Count];
						for (int j = 0; j < genericTypes.Length; j++)
						{
							genericTypes[j] = GetGenericParameterType(module.ImportReference(genericType.GenericArguments[j]));
						}
						
						ctor = ctor.MakeHostInstanceGeneric(formatter.Item1.Resolve().MakeGenericInstanceType(genericTypes));
					}

					TypeReference GetGenericParameterType(TypeReference targetType)
					{
						if (targetType.HasGenericParameters)
						{
							TypeReference[] gTypes = new TypeReference[targetType.GenericParameters.Count];
							for (int j = 0; j < gTypes.Length; j++)
							{
								gTypes[j] = GetGenericParameterType(targetType.GenericParameters[j]);
							}
					
							targetType = targetType.MakeGenericInstanceType(gTypes);
						}
					
						return module.ImportReference(targetType);
					}
				}
				
				i.Emit(OpCodes.Newobj, module.ImportReference(ctor));
				i.Emit(OpCodes.Ret);
			}, i => // Default
			{
				i.Emit(OpCodes.Ldnull);
				i.Emit(OpCodes.Ret);
			});

			getFormatterHelperMethod.SetVariableName(keyVar, "key");

			getFormatterHelperMethod.Body.Optimize();

			return t;
		}

		private TypeDefinition CreateFormatterCache()
		{
			TypeDefinition t = new TypeDefinition(string.Empty, "FormatterCache`1", TypeAttributes.NestedPrivate |
			                                                                        TypeAttributes.AnsiClass | TypeAttributes.Abstract | TypeAttributes.Sealed,
				module.GetTypeReference<object>());

			t.GenericParameters.Add(new GenericParameter("T", t));

			GenericInstanceType fieldType = module.GetTypeReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(t.GenericParameters[0].GetElementType());

			formatterField = new FieldDefinition("formatter", FieldAttributes.Assembly | FieldAttributes.Static | FieldAttributes.InitOnly, fieldType);

			t.Fields.Add(formatterField);

			MethodDefinition cctor = new MethodDefinition(".cctor", MethodAttributes.Private | MethodAttributes.HideBySig |
			                                                        MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.Static,
				module.GetTypeReference(typeof(void)));

			t.Methods.Add(cctor);

			VariableDefinition formatterVar = cctor.AddLocalVariable(module, module.GetTypeReference<object>());

			cctor.Body.InitLocals = true;

			ILProcessor il = cctor.Body.GetILProcessor();

#if ALE_DEBUG
			// LevelEditorLogger.Log((object)$"FormatterCache :: {typeof(T)}");
			il.Emit(OpCodes.Ldstr, "FormatterCache :: {0}");
			il.Emit(OpCodes.Ldtoken, t.GenericParameters[0].GetElementType());
			il.Emit(OpCodes.Call, module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle)));
			il.Emit(OpCodes.Call, module.GetMethod<string>("Format", typeof(string), typeof(object)));
			il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorLogger), "Log", typeof(object)));
#endif
			
			il.Emit(OpCodes.Ldtoken, t.GenericParameters[0].GetElementType());
			il.Emit(OpCodes.Call, module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle)));
			il.Emit(OpCodes.Call, getFormatterHelperMethod);
			il.EmitStloc(formatterVar);
			il.EmitLdloc(formatterVar);

			il.EmitLdloc(formatterVar);
			il.Emit(OpCodes.Castclass, fieldType);

			FieldReference formatterFieldRef = new FieldReference(formatterField.Name, formatterField.FieldType, formatterField.DeclaringType.MakeGenericInstanceType(t.GenericParameters[0].GetElementType()));
			il.Emit(OpCodes.Stsfld, formatterFieldRef);

			Instruction end = Instruction.Create(OpCodes.Ret);
			il.Append(end);
			il.InsertAfter(il.Body.Instructions[il.Body.Instructions.Count - 5], Instruction.Create(OpCodes.Brfalse, end));

			cctor.Body.Optimize();

			return t;
		}

		private MethodDefinition CreateGetFormatter()
		{
			getFormatterMethod = new MethodDefinition("GetFormatter", MethodAttributes.Public | MethodAttributes.Final |
			                                                          MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				module.ImportReference(typeof(void)));

			getFormatterMethod.GenericParameters.Add(new GenericParameter("T", getFormatterMethod));
			GenericInstanceType returnType = module.GetTypeReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(getFormatterMethod.GenericParameters[0].GetElementType());

			getFormatterMethod.ReturnType = returnType;

			ILProcessor il = getFormatterMethod.Body.GetILProcessor();

			FieldReference formatterFieldRef = new FieldReference(formatterField.Name, formatterField.FieldType, formatterField.DeclaringType.MakeGenericInstanceType(getFormatterMethod.GenericParameters[0].GetElementType()));

			il.Emit(OpCodes.Ldsfld, formatterFieldRef);
			il.Emit(OpCodes.Ret);

			return getFormatterMethod;
		}

		private MethodDefinition CreateSerializeWrapperMethod()
		{
			MethodDefinition m = new MethodDefinition("SerializeWrapper", MethodAttributes.Public | MethodAttributes.Final |
			                                                              MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				module.GetTypeReference<bool>());

			ParameterDefinition writer = m.AddParameter(module, module.ImportReference(typeof(MessagePackWriter).MakeByRefType()));
			ParameterDefinition wrapper = m.AddParameter<IExposedWrapper>(module);
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>(module);

			m.Body.InitLocals = true;

			ILProcessor il = m.Body.GetILProcessor();
			
			if (wrapperFormatters.Count == 0)
			{
				il.EmitBool(false);
				il.Emit(OpCodes.Ret);
				m.Body.Optimize();
				return m;
			}

			CreateSerializeBlock(il, wrapperFormatters, (x, i) => // If check
			{
				i.Emit(OpCodes.Ldarg, wrapper);
				i.Emit(OpCodes.Isinst, x.Item2);
			}, (x, i) => // Block
			{
				VariableDefinition wrapperVar = m.AddLocalVariable(module, x.Item2);

				i.EmitLdarg(wrapper);
				i.Emit(OpCodes.Unbox_Any, x.Item2);
				i.EmitStloc(wrapperVar);
				i.EmitLdarg();
				i.Emit(OpCodes.Call, getFormatterMethod.MakeGenericMethod(x.Item2));
				i.EmitLdarg(writer);
				i.EmitLdloc(wrapperVar);
				il.EmitLdarg(options);
				i.Emit(OpCodes.Callvirt, module.GetMethod(typeof(IMessagePackFormatter<>), "Serialize").MakeHostInstanceGeneric(module.ImportReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(x.Item2)));
				i.EmitBool(true);
				i.Emit(OpCodes.Ret);
			}, i => // Last
			{
				i.EmitBool(false);
				i.Emit(OpCodes.Ret);
			});

			m.Body.Optimize();

			return m;
		}

		private MethodDefinition CreateDeserializeWrapperMethod()
		{
			MethodDefinition m = new MethodDefinition("DeserializeWrapper", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig |
			                                                                MethodAttributes.NewSlot | MethodAttributes.Virtual,
				module.GetTypeReference<bool>());

			ParameterDefinition type = m.AddParameter<Type>(module);
			ParameterDefinition reader = m.AddParameter(module, module.ImportReference(typeof(MessagePackReader).MakeByRefType()));
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>(module);
			ParameterDefinition wrapper = m.AddParameter(module, module.ImportReference(typeof(IExposedWrapper).MakeByRefType()));
			wrapper.IsOut = true;

			ILProcessor il = m.Body.GetILProcessor();

			if (wrapperFormatters.Count == 0)
			{
				il.EmitLdarg(wrapper);
				il.Emit(OpCodes.Ldnull);
				il.Emit(OpCodes.Stind_Ref);
				il.EmitBool(false);
				il.Emit(OpCodes.Ret);
				m.Body.Optimize();
				return m;
			}

			MethodReference getType = module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle));
			MethodReference equality = module.GetMethod<Type>("op_Equality", typeof(Type), typeof(Type));

			CreateSerializeBlock(il, wrapperFormatters, (x, i) => // If check
			{
				i.Emit(OpCodes.Ldarg_1);
				i.Emit(OpCodes.Ldtoken, x.Item3);
				i.Emit(OpCodes.Call, getType);
				i.Emit(OpCodes.Call, equality);
			}, (x, i) => // Block
			{
				i.Emit(OpCodes.Ldarg_S, wrapper);
				i.Emit(OpCodes.Ldarg_0);
				i.Emit(OpCodes.Call, getFormatterMethod.MakeGenericMethod(x.Item2));
				i.Emit(OpCodes.Ldarg_2);
				i.Emit(OpCodes.Ldarg_3);
				i.Emit(OpCodes.Callvirt, module.GetMethod(typeof(IMessagePackFormatter<>), "Deserialize").MakeHostInstanceGeneric(module.ImportReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(x.Item2)));
				i.Emit(OpCodes.Box, x.Item2);
				i.Emit(OpCodes.Stind_Ref);
				i.EmitBool(true);
				i.Emit(OpCodes.Ret);
			}, i => // Last
			{
				i.Emit(OpCodes.Ldarg_S, wrapper);
				i.Emit(OpCodes.Ldnull);
				i.Emit(OpCodes.Stind_Ref);
				i.EmitBool(false);
				i.Emit(OpCodes.Ret);
			});

			m.Body.Optimize();

			return m;
		}

		private MethodDefinition CreateSerializeDynamicMethod()
		{
			MethodDefinition m = new MethodDefinition("SerializeDynamic", MethodAttributes.Public | MethodAttributes.Final |
			                                                              MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				module.GetTypeReference<bool>());

			ParameterDefinition type = m.AddParameter<Type>(module, "type");
			ParameterDefinition writer = m.AddParameter(module, module.ImportReference(typeof(MessagePackWriter).MakeByRefType()), "writer");
			ParameterDefinition value = m.AddParameter<object>(module, "value");
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>(module, "options");

			ILProcessor il = m.Body.GetILProcessor();

			MethodReference getTypeHandle = module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle));
			MethodReference typeEquals = module.GetMethod<Type>("op_Equality", typeof(Type), typeof(Type));

			if (customDataTypes.Count > 0)
			{
				CreateSerializeBlock(il, customDataTypes, (t, i) => // If check
				{
					i.EmitLdarg(type);
					i.Emit(OpCodes.Ldtoken, module.ImportReference(t));
					i.Emit(OpCodes.Call, getTypeHandle);
					i.Emit(OpCodes.Call, typeEquals);
				}, (t, i) => // Block
				{
					if (FormatterHelper.IsStandardWriteType(t))
					{
						i.EmitLdarg(writer);
						i.EmitLdarg(value);
						i.Emit(OpCodes.Unbox_Any, module.ImportReference(t));
						i.Append(FormatterHelper.GetWriteStandardValue(t, module));
						i.EmitBool(true);
						i.Emit(OpCodes.Ret);
					}
					else
					{
						i.EmitLdarg(options);
						i.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Resolver"));
						i.Emit(OpCodes.Call, module.ImportReference(module.ImportReference(typeof(FormatterResolverExtensions).GetMethod("GetFormatterWithVerify")).MakeGenericMethod(t)));
						i.EmitLdarg(writer);
						i.EmitLdarg(value);
						i.Emit(OpCodes.Unbox_Any, module.ImportReference(t));
						i.EmitLdarg(options);
						i.Emit(OpCodes.Callvirt, module.ImportReference(typeof(IMessagePackFormatter<>).GetMethod("Serialize")).MakeHostInstanceGeneric(module.ImportReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(t)));
						i.EmitBool(true);
						i.Emit(OpCodes.Ret);
					}
				}, i =>
				{
					i.EmitBool(false);
					i.Emit(OpCodes.Ret);
				});
			}
			else
			{
				il.EmitBool(false);
				il.Emit(OpCodes.Ret);
			}

			m.Body.Optimize();

			return m;
		}

		private MethodDefinition CreateDeserializeDynamicMethod()
		{
			MethodDefinition m = new MethodDefinition("DeserializeDynamic", MethodAttributes.Public | MethodAttributes.Final |
			                                                                MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				module.GetTypeReference<bool>());

			ParameterDefinition type = m.AddParameter<Type>(module, "type");
			ParameterDefinition reader = m.AddParameter(module, module.ImportReference(typeof(MessagePackReader).MakeByRefType()), "writer");
			ParameterDefinition value = m.AddParameter(module, module.ImportReference(typeof(object).MakeByRefType()), "value");
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>(module, "options");

			value.IsOut = true;

			ILProcessor il = m.Body.GetILProcessor();

			MethodReference getTypeHandle = module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle));
			MethodReference typeEquals = module.GetMethod<Type>("op_Equality", typeof(Type), typeof(Type));

			if (customDataTypes.Count > 0)
			{
				CreateSerializeBlock(il, customDataTypes, (t, i) => // If check
				{
					i.EmitLdarg(type);
					i.Emit(OpCodes.Ldtoken, module.ImportReference(t));
					i.Emit(OpCodes.Call, getTypeHandle);
					i.Emit(OpCodes.Call, typeEquals);
				}, (t, i) => // Block
				{
					if (FormatterHelper.IsStandardWriteType(t))
					{
						// value = reader.ReadX();
						i.EmitLdarg(value);
						i.EmitLdarg(reader);
						i.Append(FormatterHelper.GetReadStandardValue(t, module));
						if (t.IsValueType)
						{
							i.Emit(OpCodes.Box, module.ImportReference(t));
						}

						i.Emit(OpCodes.Stind_Ref);
						// return true;
						i.EmitBool(true);
						i.Emit(OpCodes.Ret);
					}
					else
					{
						i.EmitLdarg(value);
						i.EmitLdarg(options);
						i.Emit(OpCodes.Callvirt, module.GetMethod<MessagePackSerializerOptions>("get_Resolver"));
						i.Emit(OpCodes.Call, module.ImportReference(module.ImportReference(typeof(FormatterResolverExtensions).GetMethod("GetFormatterWithVerify")).MakeGenericMethod(t)));
						i.EmitLdarg(reader);
						i.EmitLdarg(options);
						i.Emit(OpCodes.Callvirt, module.ImportReference(typeof(IMessagePackFormatter<>).GetMethod("Deserialize")).MakeHostInstanceGeneric(module.ImportReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(t)));
						i.Emit(OpCodes.Box, module.ImportReference(t));
						i.Emit(OpCodes.Stind_Ref);
						// return true;
						i.EmitBool(true);
						i.Emit(OpCodes.Ret);
					}
				}, i =>
				{
					// value = null;
					i.EmitLdarg(value);
					i.Emit(OpCodes.Ldnull);
					i.Emit(OpCodes.Stind_Ref);
					// return false;
					i.EmitBool(false);
					i.Emit(OpCodes.Ret);
				});
			}
			else
			{
				// value = null;
				il.EmitLdarg(value);
				il.Emit(OpCodes.Ldnull);
				il.Emit(OpCodes.Stind_Ref);
				// return false;
				il.EmitBool(false);
				il.Emit(OpCodes.Ret);
			}

			m.Body.Optimize();

			return m;
		}

		private static void CreateSerializeBlock<T>(ILProcessor il, IList<T> items, Action<T, ILProcessor> ifCheck, Action<T, ILProcessor> block, Action<ILProcessor> last)
		{
			int ifEnd = 0;

			for (int i = 0; i < items.Count; i++)
			{
				int ifStart = il.Body.Instructions.Count;
				ifCheck(items[i], il);

				if (i > 0)
				{
					il.InsertAfter(il.Body.Instructions[ifEnd], Instruction.Create(OpCodes.Brfalse, il.Body.Instructions[ifStart]));
				}

				ifEnd = il.Body.Instructions.Count - 1;

				block(items[i], il);
			}

			if (last != null)
			{
				int lastStart = il.Body.Instructions.Count;
				last(il);
				il.InsertAfter(il.Body.Instructions[ifEnd], Instruction.Create(OpCodes.Brfalse, il.Body.Instructions[lastStart]));
			}
		}
	}
}