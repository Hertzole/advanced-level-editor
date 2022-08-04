using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Hertzole.ALE.SourceGenerator.Extensions;
using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.SourceGenerator.Scopes
{
	public enum TypeAccessor
	{
		None = 0,
		Public = 1,
		Private = 2,
		Internal = 3
	}

	public enum TypeType
	{
		Class = 0,
		Struct = 1,
		Interface = 2
	}
	
	[Flags]
	public enum TypeModifier
	{
		None = 0,
		Abstract = 1,
		Sealed = 2,
		Static = 4,
		Partial = 8,
		ReadOnly = 16,
	}

	public sealed class TypeScope : IDisposable
	{
		private bool isPartial;
		private bool isStatic;
		private bool isSealed;
		private bool isReadOnly;

		private readonly TypeType type;

		private TypeAccessor accessor;

		private readonly string className;

		private string? nspace;

		private readonly List<string> methodWrites = new List<string>();
		private readonly List<string> baseTypes = new List<string>();
		private readonly List<FieldInfo> fields = new List<FieldInfo>();
		private readonly List<PropertyInfo> properties = new List<PropertyInfo>();

		private readonly List<string> writeCommands = new List<string>();
		private readonly List<(string, bool)> customWrites = new List<(string, bool)>();

		public SourceScope Source { get; }

		public TypeScope(SourceScope source, string name, TypeType type)
		{
			this.Source = source;
			this.type = type;

			className = name;
			nspace = null;
			accessor = TypeAccessor.Public;
		}

		public TypeScope WithNamespace(string value)
		{
			nspace = value;
			return this;
		}

		public TypeScope WithNamespace(INamespaceSymbol? namespaceSymbol)
		{
			nspace = namespaceSymbol.ToProperString();
			return this;
		}

		public TypeScope WithAccessor(TypeAccessor value)
		{
			accessor = value;
			return this;
		}

		public TypeScope Partial()
		{
			isPartial = true;
			return this;
		}

		public TypeScope Static()
		{
			isStatic = true;
			return this;
		}

		public TypeScope Sealed()
		{
			isSealed = true;
			return this;
		}

		public TypeScope ReadOnly()
		{
			isReadOnly = true;
			return this;
		}

		public TypeScope WithBaseType(string value)
		{
			baseTypes.Add(value);
			return this;
		}

		public void AddField(TypeAccessor fieldAccessor, string fieldType, string name, string? value = null, TypeModifier typeModifier = TypeModifier.None)
		{
			fields.Add(new FieldInfo(fieldAccessor, fieldType, name, value, typeModifier));
		}

		public void AddProperty(TypeAccessor propertyAccessor, string propertyType, string name, bool hasGetter, bool hasSetter, string? getter = null, string? setter = null)
		{
			properties.Add(new PropertyInfo(propertyAccessor, propertyType, name, getter, setter, hasGetter, hasSetter));
		}

		public MethodScope WithMethod(string methodName)
		{
			return new MethodScope(this, methodName);
		}

		public void AddMethodWrite(string methodWrite)
		{
			customWrites.Add((methodWrite, true));
		}
		
		public void Write(string? value = null, bool includeIndent = true)
		{
			customWrites.Add((Source.FormatWriteCommand(value, includeIndent, false), includeIndent));
		}

		public void WriteLine(string? value = null, bool includeIndent = true)
		{
			customWrites.Add((Source.FormatWriteCommand(value, includeIndent, true), includeIndent));
		}

		public void Dispose()
		{
			if (!string.IsNullOrEmpty(nspace))
			{
				writeCommands.Add(Source.GetIndent() + $"namespace {nspace}\n");
				writeCommands.Add(Source.GetIndent() + "{\n");
				Source.Indent++;
			}

			writeCommands.Add(Source.GetIndent());

			switch (accessor)
			{
				case TypeAccessor.Public:
					writeCommands.Add("public ");
					break;
				case TypeAccessor.Private:
					writeCommands.Add("private ");
					break;
				case TypeAccessor.Internal:
					writeCommands.Add("internal ");
					break;
			}

			if (isStatic)
			{
				writeCommands.Add("static ");
			}

			if (isPartial)
			{
				writeCommands.Add("partial ");
			}

			if (isSealed)
			{
				writeCommands.Add("sealed ");
			}

			if (isReadOnly)
			{
				writeCommands.Add("readonly ");
			}

			switch (type)
			{
				case TypeType.Class:
					writeCommands.Add("class");
					break;
				case TypeType.Struct:
					writeCommands.Add("struct");
					break;
				case TypeType.Interface:
					writeCommands.Add("interface");
					break;
			}

			writeCommands.Add($" {className}");

			if (baseTypes.Count > 0)
			{
				writeCommands.Add(" : ");

				for (int i = 0; i < baseTypes.Count; i++)
				{
					writeCommands.Add(baseTypes[i]);
					if (i < baseTypes.Count - 1)
					{
						writeCommands.Add(", ");
					}
				}
			}

			writeCommands.Add(Source.GetIndent() + "\n");

			writeCommands.Add(Source.GetIndent() + "{\n");

			Source.Indent++;

			WriteFields();
			WriteProperties();

			for (int i = 0; i < customWrites.Count; i++)
			{
				writeCommands.Add((customWrites[i].Item2 ? Source.GetIndent() : string.Empty) + customWrites[i].Item1);
			}

			Source.Indent--;

			writeCommands.Add(Source.GetIndent() + "}\n");

			if (!string.IsNullOrEmpty(nspace))
			{
				Source.Indent--;
				writeCommands.Add(Source.GetIndent() + "}\n");
			}

			for (int i = 0; i < writeCommands.Count; i++)
			{
				Source.Write(writeCommands[i], false);
			}
		}

		private void WriteFields()
		{
			if (fields.Count > 0)
			{
				for (int i = 0; i < fields.Count; i++)
				{
					writeCommands.Add(Source.GetIndent());
					
					switch (fields[i].accessor)
					{
						case TypeAccessor.Public:
							writeCommands.Add("public ");
							break;
						case TypeAccessor.Private:
							writeCommands.Add("private ");
							break;
						case TypeAccessor.Internal:
							writeCommands.Add("internal ");
							break;
					}

					if ((fields[i].modifiers & TypeModifier.Static) != 0)
					{
						writeCommands.Add("static ");
					}
					
					if((fields[i].modifiers & TypeModifier.Partial) != 0)
					{
						writeCommands.Add("partial ");
					}

					if ((fields[i].modifiers & TypeModifier.ReadOnly) != 0)
					{
						writeCommands.Add("readonly ");
					}
					
					writeCommands.Add($"{fields[i].type} {fields[i].name}");

					if (fields[i].value != null)
					{
						writeCommands.Add($" = {fields[i].value}");
					}
					
					writeCommands.Add(";\n");
				}
			}
		}

		private void WriteProperties()
		{
			if (properties.Count > 0)
			{
				for (int i = 0; i < properties.Count; i++)
				{
					writeCommands.Add(Source.GetIndent());
					
					switch (properties[i].accessor)
					{
						case TypeAccessor.Public:
							writeCommands.Add("public ");
							break;
						case TypeAccessor.Private:
							writeCommands.Add("private ");
							break;
						case TypeAccessor.Internal:
							writeCommands.Add("internal ");
							break;
					}

					writeCommands.Add($"{properties[i].type} {properties[i].name} {{");
					
					if (properties[i].hasGetter)
					{
						writeCommands.Add(string.IsNullOrEmpty(properties[i].getter) ? " get;" : $" {properties[i].getter}");
					}

					if (properties[i].hasSetter)
					{
						writeCommands.Add(string.IsNullOrEmpty(properties[i].setter) ? " set;" : $" {properties[i].setter}");
					}

					writeCommands.Add(" }\n");
				}
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private readonly struct FieldInfo
		{
			public readonly TypeAccessor accessor;
			public readonly string type;
			public readonly string name;
			public readonly string? value;
			public readonly TypeModifier modifiers;

			public FieldInfo(TypeAccessor accessor, string type, string name, string? value, TypeModifier modifiers)
			{
				this.accessor = accessor;
				this.type = type;
				this.name = name;
				this.value = value;
				this.modifiers = modifiers;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private readonly struct PropertyInfo
		{
			public readonly TypeAccessor accessor;
			public readonly string type;
			public readonly string name;
			public readonly string? getter;
			public readonly string? setter;
			public readonly bool hasGetter;
			public readonly bool hasSetter;

			public PropertyInfo(TypeAccessor accessor, string type, string name, string? getter, string? setter, bool hasGetter, bool hasSetter)
			{
				this.accessor = accessor;
				this.type = type;
				this.name = name;
				this.getter = getter;
				this.setter = setter;
				this.hasGetter = hasGetter;
				this.hasSetter = hasSetter;
			}
		}
	}
}