using System.Text;
using Hertzole.ALE.Generator.Helper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Hertzole.ALE.SourceGenerator.Extensions
{
	public static class SymbolExtensions
	{
		public static bool TryGetAttribute(this ISymbol symbol, INamedTypeSymbol attributeSymbol, out AttributeData? attribute)
		{
			attribute = null;
			foreach (AttributeData attributeData in symbol.GetAttributes())
			{
				if (attributeData.AttributeClass == null)
				{
					continue;
				}

				if (attributeData.AttributeClass.Equals(attributeSymbol, SymbolEqualityComparer.Default))
				{
					attribute = attributeData;
					return true;
				}
			}

			return false;
		}

		public static string GetFullType<T>(this T symbol) where T : ITypeSymbol
		{
			switch (symbol.SpecialType)
			{
				case SpecialType.System_Object:
					return "object";
				case SpecialType.System_Boolean:
					return "bool";
				case SpecialType.System_Char:
					return "char";
				case SpecialType.System_SByte:
					return "sbyte";
				case SpecialType.System_Byte:
					return "byte";
				case SpecialType.System_Int16:
					return "short";
				case SpecialType.System_UInt16:
					return "ushort";
				case SpecialType.System_Int32:
					return "int";
				case SpecialType.System_UInt32:
					return "uint";
				case SpecialType.System_Int64:
					return "long";
				case SpecialType.System_UInt64:
					return "ulong";
				case SpecialType.System_Decimal:
					return "decimal";
				case SpecialType.System_Single:
					return "float";
				case SpecialType.System_Double:
					return "double";
				case SpecialType.System_String:
					return "string";
				case SpecialType.System_DateTime:
					return "global::System.DateTime";
				case SpecialType.System_IDisposable:
					return "global::System.IDisposable";
			}

			StringBuilder sb = new StringBuilder();

			if (symbol.NullableAnnotation == NullableAnnotation.Annotated && symbol is INamedTypeSymbol namedSymbol && namedSymbol.TypeArguments.Length == 1)
			{
				Log.Print($"Get nullable value: {namedSymbol.TypeArguments[0].GetFullType()}");
				sb.Append(namedSymbol.TypeArguments[0].GetFullType());
				sb.Append("?");
				Log.Print($"Returning {sb.ToString()}");
				return sb.ToString();
			}

			if (symbol.ContainingNamespace != null)
			{
				if (symbol.ContainingNamespace.IsGlobalNamespace)
				{
					sb.Append("global::");
				}
				else
				{
					sb.Append("global::" + string.Join(".", symbol.ContainingNamespace.ConstituentNamespaces) + ".");
				}
			}
			else
			{
				sb.Append("global::");
			}

			sb.Append(symbol.Name);

			return sb.ToString();
		}

		public static string ToProperString(this INamespaceSymbol? symbol, bool includeDot = false)
		{
			if (symbol != null && !string.IsNullOrEmpty(symbol.Name))
			{
				return string.Join(".", symbol.ConstituentNamespaces) + (includeDot ? "." : string.Empty);
			}

			return string.Empty;
		}
		
		public static string GetNamespace(this INamedTypeSymbol symbol, bool includeDot = false)
		{
			if (symbol.ContainingNamespace != null && !string.IsNullOrEmpty(symbol.ContainingNamespace.Name))
			{
				return string.Join(".", symbol.ContainingNamespace.ConstituentNamespaces) + (includeDot ? "." : string.Empty);
			}

			return string.Empty;
		}

		public static bool TryGetNamespace(this INamedTypeSymbol? symbol, out string namespaceString, bool includeDot = false)
		{
			if (symbol != null && symbol.ContainingNamespace != null && !string.IsNullOrEmpty(symbol.ContainingNamespace.Name))
			{
				namespaceString = string.Join(".", symbol.ContainingNamespace.ConstituentNamespaces) + (includeDot ? "." : string.Empty);
				return true;
			}

			namespaceString = string.Empty;
			return false;
		}

		public static bool TryGetTypeSymbol(this ISymbol symbol, out INamedTypeSymbol? typeSymbol)
		{
			typeSymbol = null;
			switch (symbol)
			{
				case IFieldSymbol fieldSymbol:
					typeSymbol = fieldSymbol.Type as INamedTypeSymbol;
					Log.Print($"Field type: {fieldSymbol.Type.GetType()} | {fieldSymbol.Type is INamedTypeSymbol} | {typeSymbol}");
					return true;
				case IPropertySymbol propertySymbol:
					typeSymbol = propertySymbol.Type as INamedTypeSymbol;
					return true;
			}
			
			return false;
		}
	}
}