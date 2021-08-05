using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using UnityEngine;

namespace Hertzole.ALE.CodeGen
{
	public readonly struct ExposedFieldProperty : IExposedProperty
	{
		private readonly FieldDefinition field;

		public string Name { get { return field.Name; } }
		public string CustomName { get; }
		public bool Visible { get; }
		public int Id { get; }
		public int Order { get; }
		public bool IsProperty { get { return false; } }
		public bool IsValueType { get { return FieldTypeComponentAware.IsValueType; } }
		public bool IsPrimitive { get { return FieldType.IsPrimitive; } }
		public bool IsEnum { get { return FieldType.IsEnum(); } }
		public bool IsGameObject { get { return FieldType.IsGameObject(); } }
		public bool IsComponent { get { return FieldType.IsComponent(); } }
		public bool IsArray { get { return FieldType.IsArray(); } }
		public bool IsList { get { return FieldType.IsList(); } }
		public bool IsDictionary { get { return FieldType.IsDictionary(); } }
		public bool IsCollection { get { return FieldType.IsCollection(); } }
		public TypeReference FieldType { get { return field.Module.ImportReference(field.FieldType); } }
		public TypeDefinition FieldTypeResolved
		{
			get
			{
				TypeDefinition resolved = field.FieldType.Resolve();
				if (resolved == null)
				{
					throw new InvalidOperationException($"Cannot resolve field type {field.FieldType}.");
				}

				return resolved;
			}
		}
		public TypeReference FieldTypeComponentAware
		{
			get
			{
				TypeReference fieldType = FieldType.GetCollectionType();

				if (fieldType.Is<GameObject>())
				{
					return field.Module.GetTypeReference<ComponentDataWrapper>();
				}

				TypeDefinition resolved = fieldType.Resolve();
				if (resolved != null && resolved.IsSubclassOf<Component>())
				{
					return field.Module.GetTypeReference<ComponentDataWrapper>();
				}

				return FieldType;
			}
		}
		public TypeDefinition FieldTypeComponentAwareResolved
		{
			get
			{
				TypeDefinition resolved = FieldTypeComponentAware.Resolve();
				if (resolved == null)
				{
					throw new InvalidOperationException($"Cannot resolve component aware field type {field.FieldType}.");
				}

				return resolved;
			}
		}

		public Instruction GetLoadInstruction(bool ldflda = false)
		{
			return Instruction.Create(ldflda ? OpCodes.Ldflda : OpCodes.Ldfld, field);
		}

		public Instruction GetSetInstruction()
		{
			return Instruction.Create(OpCodes.Stfld, field);
		}

		public ExposedFieldProperty(FieldDefinition field, int order)
		{
			this.field = field;
			if (field.TryGetAttribute<ExposeToLevelEditorAttribute>(out CustomAttribute attribute))
			{
				Id = attribute.GetConstructorArgument(0, 0);
				CustomName = attribute.GetField<string>(nameof(ExposeToLevelEditorAttribute.customName), null);
				Visible = attribute.GetField(nameof(ExposeToLevelEditorAttribute.visible), true);
				Order = order;
			}
			else
			{
				throw new NotSupportedException($"{field.FullName} doesn't have a ExposeToLevelEditor attribute. It can not be used in a ExposedFieldProperty.");
			}
		}
	}
}