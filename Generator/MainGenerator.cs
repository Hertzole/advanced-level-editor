using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Hertzole.ALE.Generator.Generators;
using Hertzole.ALE.Generator.Helper;
using Hertzole.ALE.SourceGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Hertzole.ALE.Generator;

[Generator]
public class MainGenerator : IIncrementalGenerator
{
	private static ReferenceSymbols? referenceSymbols;
	
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		IncrementalValuesProvider<ClassDeclarationSyntax> classDeclarations = context.SyntaxProvider
		                                                                             .CreateSyntaxProvider(
			                                                                             predicate: static (s, _) => IsSyntaxTargetForGeneration(s),
			                                                                             transform: static (ctx, _) => GetSemanticTargetForGeneration(ctx))
		                                                                             .Where(static m => m is not null);
		
		
		// Combine the selected enums with the `Compilation`
		IncrementalValueProvider<(Compilation, ImmutableArray<ClassDeclarationSyntax>)> compilationAndEnums
			= context.CompilationProvider.Combine(classDeclarations.Collect());

		// Generate the source using the compilation and enums
		context.RegisterSourceOutput(compilationAndEnums,
			static (spc, source) => Execute(source.Item1, source.Item2, spc));
	}

	private static bool IsSyntaxTargetForGeneration(SyntaxNode node)
	{
		return node is ClassDeclarationSyntax c && c.AttributeLists.Count > 0;
	}

	private static ClassDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
	{
		ClassDeclarationSyntax? classSyntax = context.Node as ClassDeclarationSyntax;
		if (classSyntax == null)
		{
			return null;
		}

		INamedTypeSymbol? classSymbol = context.SemanticModel.GetDeclaredSymbol(classSyntax);

		if (classSymbol == null)
		{
			return null;
		}

		if (!classSyntax.HasAttribute(context, "Hertzole.ALE.ExposedTypeAttribute"))
		{
			return null;
		}

		foreach (MemberDeclarationSyntax member in classSyntax.Members)
		{
			if (member is FieldDeclarationSyntax or PropertyDeclarationSyntax && member.HasAttribute(context, "Hertzole.ALE.ExposedVarAttribute"))
			{
				return classSyntax;
			}
		}

		return null;
	}

	private static void Execute(Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes, SourceProductionContext context)
	{
		if (classes.IsDefaultOrEmpty)
		{
			return;
		}
		
		referenceSymbols ??= new ReferenceSymbols(compilation);
		if (!referenceSymbols.IsValid)
		{
			return;
		}

		bool dirty = false;
		ResolverGenerator.Reset();

		foreach (ClassDeclarationSyntax c in classes)
		{
			if (c == null)
			{
				continue;
			}
			
			// Get the symbol for the class
			INamedTypeSymbol? classSymbol = compilation.GetSemanticModel(c.SyntaxTree).GetDeclaredSymbol(c);
			if (classSymbol == null)
			{
				continue;
			}

			ExposedTypeGenerator.GenerateExposedType(classSymbol, ref context, referenceSymbols);
			dirty = true;
		}

		if (dirty)
		{
			ResolverGenerator.GenerateResolver(compilation, ref context);
		}

		Log.FlushLogs();
	}

}