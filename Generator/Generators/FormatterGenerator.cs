using Hertzole.ALE.Generator.Data;
using Hertzole.ALE.SourceGenerator.Extensions;
using Hertzole.ALE.SourceGenerator.Scopes;
using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.Generator.Generators;

public static class FormatterGenerator
{
	public static void GenerateFormatter(INamedTypeSymbol symbol, ref SourceProductionContext context, ExposedVar[] exposedVars)
	{
		string type = $"{symbol.GetNamespace()}.{symbol.Name}ExposedWrapper";

		using (SourceScope source = new SourceScope($"{symbol.Name}.Formatter", context))
		{
			source.WriteUsing("MessagePack");
			
			if (symbol.TryGetNamespace(out string namespaceString, true))
			{
				namespaceString += "ALE.Generated.Formatters";
			}
			else
			{
				namespaceString = "Hertzole.ALE.Generated.Formatters";
			}

			using (TypeScope formatter = source.WithClass($"{symbol.Name}Formatter").WithNamespace(namespaceString).WithAccessor(TypeAccessor.Public)
			                                   .Sealed().WithBaseType($"global::MessagePack.Formatters.IMessagePackFormatter<{type}>"))
			{
				using (MethodScope write = formatter.WithMethod("Serialize").WithAccessor(MethodAccessor.Public)
				                                    .WithParameter("ref global::MessagePack.MessagePackWriter", "writer")
				                                    .WithParameter(type, "value")
				                                    .WithParameter("global::MessagePack.MessagePackSerializerOptions", "options"))
				{
					write.WriteLine($"writer.WriteArrayHeader({(exposedVars.Length * 2).ToString()});");

					for (int i = 0; i < exposedVars.Length; i++)
					{
						GenerateWriteField(write, exposedVars[i].Symbol, exposedVars[i].Id);
					}
				}

				using (MethodScope read = formatter.WithMethod("Deserialize").WithAccessor(MethodAccessor.Public)
				                                   .WithParameter("ref global::MessagePack.MessagePackReader", "reader")
				                                   .WithParameter("global::MessagePack.MessagePackSerializerOptions", "options")
				                                   .WithReturnType(type))
				{
					read.WriteLine("if (reader.TryReadNil())");
					read.WriteLine("{");
					source.Indent++;
					read.WriteLine("return default;");
					source.Indent--;
					read.WriteLine("}");

					read.WriteLine();

					read.WriteLine("options.Security.DepthStep(ref reader);");

					for (int i = 0; i < exposedVars.Length; i++)
					{
						GenerateFormatterDefaultField(read, exposedVars[i].Symbol);
					}

					read.WriteLine("int count = reader.ReadArrayHeader() / 2;");
					read.WriteLine("for (int i = 0; i < count; i++)");
					read.WriteLine("{");
					source.Indent++;
					read.WriteLine("int id = reader.ReadInt32();");
					read.WriteLine("switch (id)");
					read.WriteLine("{");
					source.Indent++;
					for (int i = 0; i < exposedVars.Length; i++)
					{
						GenerateFormatterReadField(read, exposedVars[i].Symbol, exposedVars[i].Id);
					}

					read.WriteLine("default:");
					source.Indent++;
					read.WriteLine("reader.Skip();");
					read.WriteLine("break;");
					source.Indent--;
					source.Indent--;
					read.WriteLine("}");
					source.Indent--;
					read.WriteLine("}");

					read.WriteLine("reader.Depth--;");
					read.WriteLine();
					read.Write($"return new {type}(");

					for (int i = 0; i < exposedVars.Length; i++)
					{
						read.Write($"__{exposedVars[i].Symbol.Name}__", false);
						if (i < exposedVars.Length - 1)
						{
							read.Write(", ", false);
						}
					}

					read.WriteLine(");", false);
				}
			}
		}
	}

	private static void GenerateWriteField(MethodScope method, ISymbol symbol, int id)
	{
		if (!symbol.TryGetTypeSymbol(out var type) || type == null)
		{
			method.WriteLine($"// {symbol.Name} is not a field or property.");
			return;
		}

		method.WriteLine($"writer.WriteInt32({id});");

		switch (type.SpecialType)
		{
			case SpecialType.System_Byte:
				method.WriteLine($"writer.WriteUInt8(value.{symbol.Name});");
				return;
			case SpecialType.System_SByte:
				method.WriteLine($"writer.WriteInt8(value.{symbol.Name});");
				return;
			case SpecialType.System_UInt16:
				method.WriteLine($"writer.WriteUInt16(value.{symbol.Name});");
				return;
			case SpecialType.System_Int16:
				method.WriteLine($"writer.WriteInt16(value.{symbol.Name});");
				return;
			case SpecialType.System_Int32:
				method.WriteLine($"writer.WriteInt32(value.{symbol.Name});");
				return;
			case SpecialType.System_UInt32:
				method.WriteLine($"writer.WriteUInt32(value.{symbol.Name});");
				return;
			case SpecialType.System_Int64:
				method.WriteLine($"writer.WriteInt64(value.{symbol.Name});");
				return;
			case SpecialType.System_UInt64:
				method.WriteLine($"writer.WriteUInt64(value.{symbol.Name});");
				return;
			case SpecialType.System_Boolean:
			case SpecialType.System_Char:
			case SpecialType.System_Double:
			case SpecialType.System_Single:
			case SpecialType.System_String:
			case SpecialType.System_DateTime:
				method.WriteLine($"writer.Write(value.{symbol.Name});");
				return;
			default:
				method.WriteLine($"options.Resolver.GetFormatterWithVerify<{type.GetFullType()}>().Serialize(ref writer, value.{symbol.Name}, options);");
				return;
		}
	}

	private static void GenerateFormatterDefaultField(MethodScope method, ISymbol symbol)
	{
		if (!symbol.TryGetTypeSymbol(out var type) || type == null)
		{
			method.WriteLine($"// {symbol.Name} is not a field or property.");
			return;
		}

		method.WriteLine($"{type.GetFullType()} __{symbol.Name}__ = default;");
	}

	private static void GenerateFormatterReadField(MethodScope method, ISymbol symbol, int id)
	{
		method.WriteLine($"case {id}:");
		method.parentType.Source.Indent++;

		if (symbol.TryGetTypeSymbol(out var type) || type == null)
		{
			method.WriteLine($"// {symbol.Name} is not a field or property.");
			method.WriteLine("break;");
			method.parentType.Source.Indent--;
			return;
		}

		string name = $"__{symbol.Name}__";

		switch (type.SpecialType)
		{
			case SpecialType.System_Boolean:
				method.WriteLine($"{name} = reader.ReadBoolean();");
				break;
			case SpecialType.System_Byte:
				method.WriteLine($"{name} = reader.ReadByte();");
				break;
			case SpecialType.System_SByte:
				method.WriteLine($"{name} = reader.ReadSByte();");
				break;
			case SpecialType.System_UInt16:
				method.WriteLine($"{name} = reader.ReadUInt16();");
				break;
			case SpecialType.System_Int16:
				method.WriteLine($"{name} = reader.ReadInt16();");
				break;
			case SpecialType.System_Int32:
				method.WriteLine($"{name} = reader.ReadInt32();");
				break;
			case SpecialType.System_UInt32:
				method.WriteLine($"{name} = reader.ReadUInt32();");
				break;
			case SpecialType.System_Int64:
				method.WriteLine($"{name} = reader.ReadInt64();");
				break;
			case SpecialType.System_UInt64:
				method.WriteLine($"{name} = reader.ReadUInt64();");
				break;
			case SpecialType.System_Char:
				method.WriteLine($"{name} = reader.ReadChar();");
				break;
			case SpecialType.System_Double:
				method.WriteLine($"{name} = reader.ReadDouble();");
				break;
			case SpecialType.System_Single:
				method.WriteLine($"{name} = reader.ReadSingle();");
				break;
			case SpecialType.System_String:
				method.WriteLine($"{name} = reader.ReadString();");
				break;
			case SpecialType.System_DateTime:
				method.WriteLine($"{name} = reader.ReadDateTime();");
				break;
			default:
				method.WriteLine($"{name} = options.Resolver.GetFormatterWithVerify<{type.GetFullType()}>().Deserialize(ref reader, options);");
				break;
		}

		method.WriteLine("break;");
		method.parentType.Source.Indent--;
	}
}