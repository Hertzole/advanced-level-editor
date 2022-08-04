using System;
using System.Collections.Generic;
using Hertzole.ALE.Generator.Data;
using Hertzole.ALE.Generator.Helper;
using Hertzole.ALE.SourceGenerator.Extensions;
using Hertzole.ALE.SourceGenerator.Scopes;
using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.Generator.Generators;

public static class ExposedTypeGenerator
{
	public static void GenerateExposedType(INamedTypeSymbol classSymbol, ref SourceProductionContext context, ReferenceSymbols referenceSymbols)
	{
		Result<ExposedVar[]> exposedMembers = GetExposedMembers(classSymbol, ref context, referenceSymbols);
		if (!exposedMembers.Success)
		{
			return;
		}

		ResolverGenerator.ResolveType(classSymbol, exposedMembers.Value);
		WrapperGenerator.GenerateWrapper(classSymbol, ref context, exposedMembers.Value);
		FormatterGenerator.GenerateFormatter(classSymbol, ref context, exposedMembers.Value);

		using (SourceScope source = new SourceScope($"{classSymbol.Name}.Exposed", context))
		{
			using (TypeScope type = source.WithClass(classSymbol.Name).WithAccessor(TypeAccessor.None).WithNamespace(classSymbol.ContainingNamespace).Partial()
			                              .WithBaseType("global::Hertzole.ALE.IExposedType")
			                              .WithBaseType($"global::Hertzole.ALE.IHasWrapper<global::{classSymbol.GetNamespace(true)}{classSymbol.Name}ExposedWrapper>"))
			{
				type.AddField(TypeAccessor.Private, "global::Hertzole.ALE.ExposedVars", "exposedVars");
				type.AddProperty(TypeAccessor.None, "global::Hertzole.ALE.ExposedVars", 
					"global::Hertzole.ALE.IExposedType.ExposedVars", true, false, "get { return exposedVars; }");

				WriteInitializeExposedVars(type, source, exposedMembers);
			}
		}
	}

	private static void WriteInitializeExposedVars(TypeScope type, SourceScope source, Result<ExposedVar[]> exposedMembers)
	{
		using (MethodScope initializeMethod = type.WithMethod("global::Hertzole.ALE.IExposedType.InitializeExposedVars").WithAccessor(MethodAccessor.None))
		{
			initializeMethod.WriteLine("exposedVars = new global::Hertzole.ALE.ExposedVars(");
			source.Indent++;
			
			Log.Print($"Write initialize exposed vars. Has {exposedMembers.Value.Length} exposed vars.");

			for (int i = 0; i < exposedMembers.Value.Length; i++)
			{
				Log.Print($"Writing {exposedMembers.Value[i].Symbol.Name}");
				if (exposedMembers.Value[i].Symbol.TryGetTypeSymbol(out INamedTypeSymbol? varType) && varType != null)
				{
					initializeMethod.Write($"new global::Hertzole.ALE.ExposedVar<{varType.GetFullType()}>(" +
					                       $"{exposedMembers.Value[i].Id.ToString()}, " +
					                       $"() => {exposedMembers.Value[i].Symbol.Name}," +
					                       $"x => {exposedMembers.Value[i].Symbol.Name} = x)");

					if (i != exposedMembers.Value.Length - 1)
					{
						initializeMethod.WriteLine(",", false);
					}
					Log.Print($"Successfully wrote {exposedMembers.Value[i].Symbol.Name}");
				}
				else
				{
					Log.Print($"{exposedMembers.Value[i].Symbol.Name} was invalid.");
				}
			}

			source.Indent--;
			initializeMethod.WriteLine(");");
		}
	}

	private static Result<ExposedVar[]> GetExposedMembers(INamedTypeSymbol classSymbol, ref SourceProductionContext context, ReferenceSymbols referenceSymbols)
	{
		List<ExposedVar> exposedMembers = new List<ExposedVar>();
		HashSet<int> exposedIds = new HashSet<int>();
		bool error = false;
		
		Log.Print($"GetExposedMembers for {classSymbol.Name}");

		foreach (ISymbol member in classSymbol.GetMembers())
		{
			Log.Print($"Checking {member.Name}");
			if (member is IFieldSymbol or IPropertySymbol && member.TryGetAttribute(referenceSymbols.exposedVarAttribute!, out AttributeData? attribute))
			{
				if (attribute == null)
				{
					Log.Print("Does not have attribute.");
					continue;
				}
				
				Log.Print($"{member.Name} is a valid field or property.");

				// Make sure the member is public and accessible.
				if (member.DeclaredAccessibility != Accessibility.Public)
				{
					context.ReportDiagnostic(Diagnostic.Create(Diagnostics.mustBePublicError, member.Locations[0], member.Name));
					error = true;
					continue;
				}

				// Get the ID from the attribute constructor.
				int id = attribute.ConstructorArguments[0].Value as int? ?? 0;
				// If the ID is already used, report an error.
				if (exposedIds.Contains(id))
				{
					SyntaxNode syntax = attribute.ApplicationSyntaxReference!.GetSyntax(context.CancellationToken);
					context.ReportDiagnostic(Diagnostic.Create(Diagnostics.duplicateIdError, syntax.GetLocation(), id.ToString()));
					error = true;
					continue;
				}

				exposedMembers.Add(new ExposedVar(member, id));
				exposedIds.Add(id);
				Log.Print($"Adding {member.Name}");
			}
		}

		return error ? default : new Result<ExposedVar[]>(exposedMembers.ToArray());
	}
}