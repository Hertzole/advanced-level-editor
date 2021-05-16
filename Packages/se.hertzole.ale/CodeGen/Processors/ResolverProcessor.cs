using System;
using System.Collections.Generic;
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
		private readonly ModuleDefinition module;

		private TypeDefinition resolver;
		private FieldDefinition instanceField;
		private FieldDefinition formatterField;
		private MethodDefinition getFormatterHelperMethod;
		private MethodDefinition getFormatterMethod;

		private readonly List<(TypeDefinition, TypeDefinition, TypeDefinition)> wrapperFormatters = new List<(TypeDefinition, TypeDefinition, TypeDefinition)>();

		public ResolverProcessor(ModuleDefinition moduleDefinition)
		{
			module = moduleDefinition;
		}

		public void AddWrapperFormatter(TypeDefinition formatter, TypeDefinition wrapperType, TypeDefinition baseClass)
		{
			wrapperFormatters.Add((formatter, wrapperType, baseClass));
		}

		public void EndEditing()
		{
			if (wrapperFormatters == null || wrapperFormatters.Count == 0)
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
		}
		
		private TypeDefinition CreateResolverClass()
		{
			TypeDefinition t = new TypeDefinition("Hertzole.ALE.Generated", $"{module.Name.Substring(0, module.Name.Length - 4)}_Resolver",
				TypeAttributes.Public | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit, module.GetTypeReference<object>());
			
			t.Interfaces.Add(new InterfaceImplementation(module.ImportReference(typeof(IFormatterResolver))));
			t.Interfaces.Add(new InterfaceImplementation(module.ImportReference(typeof(IWrapperSerializer))));

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

			CustomAttribute a = new CustomAttribute(module.GetConstructor<RuntimeInitializeOnLoadMethodAttribute>(typeof(RuntimeInitializeLoadType)));
			a.ConstructorArguments.Add(new CustomAttributeArgument(module.GetTypeReference<RuntimeInitializeLoadType>(), RuntimeInitializeLoadType.BeforeSceneLoad));
			m.CustomAttributes.Add(a);

			ILProcessor il = m.Body.GetILProcessor();
			
			il.Emit(OpCodes.Ldsfld, instanceField);
			il.Emit(OpCodes.Call, module.GetMethod<LevelEditorResolver>("RegisterResolver", typeof(IFormatterResolver)));
			il.Emit(OpCodes.Ldsfld, instanceField);
			il.Emit(OpCodes.Call, module.GetMethod<LevelEditorResolver>("RegisterWrapperSerializer", typeof(IWrapperSerializer)));

			for (int i = 0; i < wrapperFormatters.Count; i++)
			{
				il.Emit(OpCodes.Call, module.GetMethod(typeof(LevelEditorSerializer), "RegisterType").MakeGenericMethod(wrapperFormatters[i].Item3));
			}

			il.Emit(OpCodes.Ret);
			
			il.Body.Optimize();

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
				module.GetTypeReference(typeof(void)));

			t.Methods.Add(cctor);

			ILProcessor il = cctor.Body.GetILProcessor();
			il.Emit(OpCodes.Newobj, module.GetConstructor<Dictionary<Type, int>>());

			MethodReference getType = module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle));
			
			for (int i = 0; i < wrapperFormatters.Count; i++)
			{
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Ldtoken, wrapperFormatters[i].Item2); 
				il.Emit(OpCodes.Call, getType);
				il.Emit(OpCodes.Ldc_I4, i);
				il.Emit(OpCodes.Callvirt, module.ImportReference(typeof(Dictionary<Type, int>).GetMethod("Add")));
			}
			
			il.Emit(OpCodes.Stsfld, lookup);
			il.Emit(OpCodes.Ret);
			
			cctor.Body.Optimize();

			getFormatterHelperMethod = new MethodDefinition("GetFormatter", MethodAttributes.Assembly | MethodAttributes.HideBySig | MethodAttributes.Static,
				module.GetTypeReference<object>());
			
			t.Methods.Add(getFormatterHelperMethod);

			getFormatterHelperMethod.AddParameter<Type>(module, out _);
			VariableDefinition keyVar = getFormatterHelperMethod.AddLocalVariable<int>(module, out int keyIndex);
			
			il = getFormatterHelperMethod.Body.GetILProcessor();
			
			il.Emit(OpCodes.Ldsfld, lookup);
			il.Emit(OpCodes.Ldarg_0);
			il.EmitLdloc(keyIndex, keyVar, true);
			il.Emit(OpCodes.Callvirt, module.ImportReference(typeof(Dictionary<Type, int>).GetMethod("TryGetValue")));
			
			il.Emit(OpCodes.Ldnull);
			il.Emit(OpCodes.Ret);

			il.Emit(OpCodes.Ldloc_0);
			il.InsertAfter(il.Body.Instructions[il.Body.Instructions.Count - 4], Instruction.Create(OpCodes.Brtrue, il.Body.Instructions[il.Body.Instructions.Count - 1]));

			il.EmitSwitch(wrapperFormatters, (formatter, i) => // Case
			{
				i.Emit(OpCodes.Newobj, formatter.Item1.GetConstructor());
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

			VariableDefinition formatterVar = cctor.AddLocalVariable(module, module.GetTypeReference<object>(), out int formatterIndex);

			cctor.Body.InitLocals = true;

			ILProcessor il = cctor.Body.GetILProcessor();
			
			il.Emit(OpCodes.Ldtoken, t.GenericParameters[0].GetElementType());
			il.Emit(OpCodes.Call, module.GetMethod<Type>("GetTypeFromHandle", typeof(RuntimeTypeHandle)));
			il.Emit(OpCodes.Call, getFormatterHelperMethod);
			il.EmitStloc(formatterIndex, formatterVar);
			il.EmitLdloc(formatterIndex, formatterVar);
			
			il.EmitLdloc(formatterIndex, formatterVar);
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

			ParameterDefinition type = m.AddParameter<Type>(module, out int typeIndex);
			ParameterDefinition writer = m.AddParameter(module, module.ImportReference(typeof(MessagePackWriter).MakeByRefType()), out int writerIndex);
			ParameterDefinition wrapper = m.AddParameter<IExposedWrapper>(module, out int wrapperIndex);
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>(module, out int optionsIndex);

			m.Body.InitLocals = true;

			ILProcessor il = m.Body.GetILProcessor();

			CreateSerializeBlock(il, wrapperFormatters, (x, i) => // If check
			{
				i.Emit(OpCodes.Ldarg, wrapper);
				i.Emit(OpCodes.Isinst, x.Item2);
			}, (x, i) => // Block
			{
				VariableDefinition wrapperVar = m.AddLocalVariable(module, x.Item2, out int wrapperVarIndex);
				
				i.Emit(OpCodes.Ldarg_3);
				i.Emit(OpCodes.Unbox_Any, x.Item2);
				i.EmitStloc(wrapperVarIndex, wrapperVar);
				i.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Call, getFormatterMethod.MakeGenericMethod(x.Item2));
				il.Emit(OpCodes.Ldarg_2);
				il.EmitLdloc(wrapperVarIndex, wrapperVar);
				il.Emit(OpCodes.Ldarg_S, options);
				il.Emit(OpCodes.Callvirt, module.GetMethod(typeof(IMessagePackFormatter<>), "Serialize").MakeHostInstanceGeneric(module.ImportReference(typeof(IMessagePackFormatter<>)).MakeGenericInstanceType(x.Item2)));
				il.EmitBoolean(true);
				il.Emit(OpCodes.Ret);
			}, i => // Last
			{
				il.EmitBoolean(false);
				il.Emit(OpCodes.Ret);
			});
			
			m.Body.Optimize();
			
			return m;
		}

		private MethodDefinition CreateDeserializeWrapperMethod()
		{
			MethodDefinition m = new MethodDefinition("DeserializeWrapper", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig |
			                                                                MethodAttributes.NewSlot | MethodAttributes.Virtual,
				module.GetTypeReference<bool>());

			ParameterDefinition type = m.AddParameter<Type>(module, out int typeIndex);
			ParameterDefinition reader = m.AddParameter(module, module.ImportReference(typeof(MessagePackReader).MakeByRefType()), out int readerIndex);
			ParameterDefinition options = m.AddParameter<MessagePackSerializerOptions>(module, out int optionsIndex);
			ParameterDefinition wrapper = m.AddParameter(module, module.ImportReference(typeof(IExposedWrapper).MakeByRefType()), out int wrapperIndex);
			wrapper.IsOut = true;

			ILProcessor il = m.Body.GetILProcessor();

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
				i.EmitBoolean(true);
				i.Emit(OpCodes.Ret);
			}, i => // Last
			{
				i.Emit(OpCodes.Ldarg_S, wrapper);
				i.Emit(OpCodes.Ldnull);
				i.Emit(OpCodes.Stind_Ref);
				i.EmitBoolean(false);
				i.Emit(OpCodes.Ret);
			});
			
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

			int lastStart = il.Body.Instructions.Count;
			last(il);
			il.InsertAfter(il.Body.Instructions[ifEnd], Instruction.Create(OpCodes.Brfalse, il.Body.Instructions[lastStart]));
		}
	}
}