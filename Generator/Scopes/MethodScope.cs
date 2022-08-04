using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.SourceGenerator.Scopes
{
	public enum MethodAccessor
	{
		None = 0,
		Public = 1,
		Private = 2,
		Protected = 3,
		Internal = 4
	}

	public sealed class MethodScope : IDisposable
	{
		private bool isStatic;
		
		public readonly TypeScope parentType;

		private readonly string methodName;

		private MethodAccessor accessor;
		private string returnType;

		private readonly StringBuilder sb = new StringBuilder();
		private readonly List<string> writes = new List<string>();
		private readonly List<string> lineWrites = new List<string>();
		private readonly List<string> parameters = new List<string>();

		public MethodScope(TypeScope parentType, string name)
		{
			this.parentType = parentType;

			methodName = name;
			accessor = MethodAccessor.Private;
			returnType = "void";
		}

		public MethodScope WithAccessor(MethodAccessor value)
		{
			accessor = value;

			return this;
		}

		public MethodScope WithReturnType(string value)
		{
			returnType = value;
			return this;
		}

		public MethodScope WithParameter(string type, string name)
		{
			parameters.Add($"{type} {name}");
			return this;
		}

		public MethodScope Static()
		{
			isStatic = true;
			return this;
		}

		public void Write(string? value = null, bool includeIndent = true)
		{
			string indent = parentType.Source.GetIndent(includeIndent ? parentType.Source.Indent + 1 : 0);
			writes.Add(string.IsNullOrEmpty(value) ? string.Empty : indent + value!);
		}

		public void WriteLine(string? value = null, bool includeIndent = true)
		{
			string prefix;

			if (writes.Count > 0)
			{
				prefix = string.Concat(writes);
				writes.Clear();
			}
			else
			{
				prefix = parentType.Source.GetIndent(includeIndent ? parentType.Source.Indent + 1 : 0);
			}
			
			lineWrites.Add(string.IsNullOrEmpty(value) ? "\n" : prefix + value! + "\n");
		}

		public void Dispose()
		{
			sb.Append(parentType.Source.GetIndent());

			switch (accessor)
			{
				case MethodAccessor.Public:
					sb.Append("public ");
					break;
				case MethodAccessor.Private:
					sb.Append("private ");
					break;
				case MethodAccessor.Protected:
					sb.Append("protected ");
					break;
				case MethodAccessor.Internal:
					sb.Append("internal ");
					break;
			}

			if (isStatic)
			{
				sb.Append("static ");
			}

			if (!string.IsNullOrEmpty(returnType))
			{
				sb.Append($"{returnType} ");
			}

			sb.Append(methodName);

			sb.Append("(");

			sb.Append(string.Join(", ", parameters));

			sb.AppendLine(")");
			parentType.AddMethodWrite(sb.ToString());

			sb.Clear();
			sb.AppendLine(parentType.Source.GetIndent() + "{");
			parentType.AddMethodWrite(sb.ToString());

			sb.Clear();

			if (lineWrites.Count > 0)
			{
				for (int i = 0; i < lineWrites.Count; i++)
				{
					parentType.AddMethodWrite(lineWrites[i]);
				}
			}

			sb.AppendLine(parentType.Source.GetIndent() + "}");
			parentType.AddMethodWrite(sb.ToString());
		}
	}
}