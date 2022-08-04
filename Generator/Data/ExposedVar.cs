using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Hertzole.ALE.Generator.Data;

public record struct ExposedVar(ISymbol Symbol, int Id);