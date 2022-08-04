using System;
using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.Generator;

public class ReferenceSymbols
{
	internal readonly INamedTypeSymbol? exposedTypeAttribute;
	internal readonly INamedTypeSymbol? exposedVarAttribute;
	
	public bool IsValid { get; }

	public ReferenceSymbols(Compilation compilation)
	{
		exposedTypeAttribute = compilation.GetTypeByMetadataName("Hertzole.ALE.ExposedTypeAttribute");
		exposedVarAttribute = compilation.GetTypeByMetadataName("Hertzole.ALE.ExposedVarAttribute");

		IsValid = exposedTypeAttribute != null && exposedVarAttribute != null;
	}
}