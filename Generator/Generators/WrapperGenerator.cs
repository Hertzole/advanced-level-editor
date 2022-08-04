using Hertzole.ALE.Generator.Data;
using Hertzole.ALE.Generator.Helper;
using Hertzole.ALE.SourceGenerator.Extensions;
using Hertzole.ALE.SourceGenerator.Scopes;
using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.Generator.Generators;

public static class WrapperGenerator
{
	public static void GenerateWrapper(INamedTypeSymbol classSymbol, ref SourceProductionContext context, ExposedVar[] exposedVars)
	{
		string wrapperName = $"{classSymbol.Name}ExposedWrapper";
		
		using (SourceScope source = new SourceScope($"{classSymbol.Name}.Wrapper", context))
		{
			using (TypeScope wrapper = source.WithStruct(wrapperName).ReadOnly().WithNamespace(classSymbol.ContainingNamespace)
			                                 .WithAccessor(TypeAccessor.Public).WithBaseType("global::Hertzole.ALE.IWrapper"))
			{
				Log.Print($"Write {exposedVars.Length} exposed vars for wrapper {wrapperName}");
				
				for (int i = 0; i < exposedVars.Length; i++)
				{
					GenerateMemberProperty(wrapper, exposedVars[i].Symbol, TypeAccessor.Public);
				}

				wrapper.WriteLine();

				using (MethodScope constructor = wrapper.WithMethod(wrapperName).WithAccessor(MethodAccessor.Public).WithReturnType(string.Empty))
				{
					for (int i = 0; i < exposedVars.Length; i++)
					{
						if (exposedVars[i].Symbol.TryGetTypeSymbol(out INamedTypeSymbol? type) && type != null)
						{
							constructor.WithParameter(type.GetFullType(), exposedVars[i].Symbol.Name);
							constructor.WriteLine($"this.{exposedVars[i].Symbol.Name} = {exposedVars[i].Symbol.Name};");
						}
						else
						{
							constructor.WriteLine($"// Type not found for {exposedVars[i].Symbol.Name}");
						}
					}
				}
			}
		}
	}
	
	private static void GenerateMemberProperty(TypeScope scope, ISymbol symbol, TypeAccessor accessor)
	{
		if (!symbol.TryGetTypeSymbol(out INamedTypeSymbol? type) || type == null)
		{
			Log.Print($"Couldn't get type for {symbol.Name} ({symbol.GetType()})");
			scope.Source.WriteLine($"// {symbol.Name} is not a field or property.");
			return;
		}

		Log.Print($"Add wrapper field {symbol.Name} of type {type.GetFullType()}");
		scope.AddField(accessor, type.GetFullType(), symbol.Name, null, TypeModifier.ReadOnly);
	}
}