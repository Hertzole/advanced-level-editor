using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.Generator;

public static class Diagnostics
{
	public static readonly DiagnosticDescriptor duplicateIdError = new DiagnosticDescriptor(
		"ALE001",
		"Duplicate exposed ID", "Duplicate ID {0}. Ids for exposed vars need to be unique.",
		"Hertzole.ALE.CodeGen",
		DiagnosticSeverity.Error,
		true);
	
	public static readonly DiagnosticDescriptor mustBePublicError = new DiagnosticDescriptor(
		"ALE002",
		"Exposed type must be public", "Exposed type {0} must be public.",
		"Hertzole.ALE.CodeGen",
		DiagnosticSeverity.Error,
		true);
}