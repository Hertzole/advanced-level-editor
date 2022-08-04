using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Hertzole.ALE.SourceGenerator.Extensions;

public static class MemberDeclarationExtensions
{
	public static bool HasAttribute(this MemberDeclarationSyntax member, GeneratorSyntaxContext context, string attributeName)
	{
		if (member.AttributeLists.Count == 0)
		{
			return false;
		}

		foreach (AttributeListSyntax attributeList in member.AttributeLists)
		{
			foreach (AttributeSyntax attributeSyntax in attributeList.Attributes)
			{
				if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
				{
					// weird, we couldn't get the symbol, ignore it
					continue;
				}

				INamedTypeSymbol attributeContainingTypeSymbol = attributeSymbol.ContainingType;
				string fullName = attributeContainingTypeSymbol.ToDisplayString();

				// Is the attribute name correct?
				if (fullName == attributeName)
				{
					return true;
				}
			}
		}

		return false;
	}

	public static bool TryGetAttribute(this MemberDeclarationSyntax member, string attributeName, Compilation compilation, out AttributeSyntax? result)
	{
		if (member.AttributeLists.Count == 0)
		{
			result = null;
			return false;
		}
		
		foreach (AttributeListSyntax attributeList in member.AttributeLists)
		{
			foreach (AttributeSyntax attributeSyntax in attributeList.Attributes)
			{
				if (compilation.GetSemanticModel(member.SyntaxTree).GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
				{
					// weird, we couldn't get the symbol, ignore it
					continue;
				}
				
				INamedTypeSymbol attributeContainingTypeSymbol = attributeSymbol.ContainingType;
				string fullName = attributeContainingTypeSymbol.ToDisplayString();

				// Is the attribute name correct?
				if (fullName == attributeName)
				{
					result = attributeSyntax;
					return true;
				}
			}
		}

		result = null;
		return false;
	}
}