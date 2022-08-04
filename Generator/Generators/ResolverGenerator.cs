using System.Collections.Generic;
using Hertzole.ALE.Generator.Data;
using Hertzole.ALE.SourceGenerator.Extensions;
using Hertzole.ALE.SourceGenerator.Scopes;
using Microsoft.CodeAnalysis;

namespace Hertzole.ALE.Generator.Generators;

public static class ResolverGenerator
{
	private static readonly List<(INamedTypeSymbol type, ExposedVar[] vars)> resolvedTypes = new List<(INamedTypeSymbol type, ExposedVar[] vars)>();

	public static void Reset()
	{
		resolvedTypes.Clear();
	}
	
	public static void GenerateResolver(Compilation compilation, ref SourceProductionContext context)
	{
		string name = $"{compilation.Assembly.Name}Resolver".Replace('-', '_').Replace('.', '_');
		
		using (var source = new SourceScope(name, context))
		{
			using (var resolver = source.WithClass(name).Sealed().WithNamespace("Hertzole.ALE.Generated")
			                        .WithBaseType("global::Hertzole.ALE.ILevelEditorResolver"))
			{
				resolver.AddField(TypeAccessor.Private, name, "instance", $"new {name}()", TypeModifier.Static | TypeModifier.ReadOnly);
					resolver.AddField(TypeAccessor.Private, "bool", "hasRegisteredResolver", "false", TypeModifier.Static);

					resolver.WriteLine($"private {name}() {{ }}");
					resolver.WriteLine();
					resolver.WriteLine("#if UNITY_EDITOR", false);
					resolver.WriteLine("[global::UnityEditor.InitializeOnLoadMethod]");
					resolver.WriteLine("#else", false);
					resolver.WriteLine("[global::UnityEngine.RuntimeInitializeOnLoadMethod(global::UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]");
					resolver.WriteLine("#endif", false);
					using (MethodScope register = resolver.WithMethod("RegisterResolver").Static())
					{
						register.WriteLine("if (!hasRegisteredResolver)");
						register.WriteLine("{");
						source.Indent++;
						register.WriteLine("hasRegisteredResolver = true;");
						register.WriteLine("global::Hertzole.ALE.LevelEditorResolver.RegisterResolver(instance);");
						for (int i = 0; i < resolvedTypes.Count; i++)
						{
							register.WriteLine($"global::Hertzole.ALE.LevelEditorTypeResolver.RegisterType<" +
							                   $"{resolvedTypes[i].type.GetFullType()}>" +
							                   $"({(resolvedTypes[i].type.GetNamespace(true) + resolvedTypes[i].type.Name).GetStableHashCode().ToString()});");
						}
						source.Indent--;
						register.WriteLine("}");
					}

					using (MethodScope getFormatter = resolver.WithMethod("global::MessagePack.IFormatterResolver.GetFormatter<T>").WithReturnType("global::MessagePack.Formatters.IMessagePackFormatter<T>").WithAccessor(MethodAccessor.None))
					{
						getFormatter.WriteLine("return FormatterCache<T>.formatter;");
					}

					using (var serializeWrapper = resolver.WithMethod("global::Hertzole.ALE.IWrapperResolver.SerializeWrapper")
					                                .WithReturnType("bool")
					                                .WithParameter("ref global::MessagePack.MessagePackWriter", "writer")
					                                .WithParameter("global::Hertzole.ALE.IWrapper", "wrapper")
					                                .WithParameter("global::MessagePack.MessagePackSerializerOptions", "options")
					                                .WithAccessor(MethodAccessor.None))
					{
						for (int i = 0; i < resolvedTypes.Count; i++)
						{
							var typeName = resolvedTypes[i].type.Name;
							string wrapperName = $"global::{resolvedTypes[i].type.GetNamespace(true)}{typeName}ExposedWrapper";
							serializeWrapper.WriteLine($"if (wrapper is {wrapperName} {typeName}WrapperValue)");
							serializeWrapper.WriteLine("{");
							source.Indent++;
							serializeWrapper.WriteLine($"((global::MessagePack.IFormatterResolver) this).GetFormatter<{wrapperName}>().Serialize(ref writer, {typeName}WrapperValue, options);");
							serializeWrapper.WriteLine("return true;");
							source.Indent--;
							serializeWrapper.WriteLine("}");
						}
						
						serializeWrapper.WriteLine("return false;");
					}
					
					using(var deserializeWrapper = resolver.WithMethod("global::Hertzole.ALE.IWrapperResolver.DeserializeWrapper")
					                                .WithReturnType("bool")
					                                .WithParameter("ref global::MessagePack.MessagePackReader", "reader")
					                                .WithParameter("global::MessagePack.MessagePackSerializerOptions", "options")
					                                .WithParameter("global::System.Type", "type")
					                                .WithParameter("out global::Hertzole.ALE.IWrapper", "value")
					                                .WithAccessor(MethodAccessor.None))
					{
						for (int i = 0; i < resolvedTypes.Count; i++)
						{
							var typeName = resolvedTypes[i].type.Name;
							string wrapperName = $"global::{resolvedTypes[i].type.GetNamespace(true)}{typeName}ExposedWrapper";
							deserializeWrapper.WriteLine($"if (type == typeof({resolvedTypes[i].type.GetFullType()}))");
							deserializeWrapper.WriteLine("{");
							source.Indent++;
							deserializeWrapper.WriteLine($"value = ((global::MessagePack.IFormatterResolver) this).GetFormatter<{wrapperName}>().Deserialize(ref reader, options);");
							deserializeWrapper.WriteLine("return true;");
							source.Indent--;
							deserializeWrapper.WriteLine("}");
						}
						deserializeWrapper.WriteLine("value = default;");
						deserializeWrapper.WriteLine("return false;");
					}
					
					using(var serializeDynamic = resolver.WithMethod("global::Hertzole.ALE.IDynamicResolver.SerializeDynamic")
					                                .WithReturnType("bool")
					                                .WithParameter("ref global::MessagePack.MessagePackWriter", "writer")
					                                .WithParameter("object", "value")
					                                .WithParameter("global::MessagePack.MessagePackSerializerOptions", "options")
					                                .WithAccessor(MethodAccessor.None))
					{
						serializeDynamic.WriteLine("return false;");
					}
					
					using(var deserializeDynamic = resolver.WithMethod("global::Hertzole.ALE.IDynamicResolver.DeserializeDynamic")
					                                .WithReturnType("bool")
					                                .WithParameter("ref global::MessagePack.MessagePackReader", "reader")
					                                .WithParameter("global::MessagePack.MessagePackSerializerOptions", "options")
					                                .WithParameter("out object", "value")
					                                .WithAccessor(MethodAccessor.None))
					{
						deserializeDynamic.WriteLine("value = default;");
						deserializeDynamic.WriteLine("return false;");
					}

					resolver.WriteLine();
					resolver.WriteLine("private static class FormatterCache<T>");
					resolver.WriteLine("{");
					source.Indent++;

					resolver.WriteLine("public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter = GetFormatter();");
					resolver.WriteLine();
					resolver.WriteLine("private static global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter()");
					resolver.WriteLine("{");
					source.Indent++;
					resolver.WriteLine($"return (global::MessagePack.Formatters.IMessagePackFormatter<T>){name}FormatterHelper.GetFormatter(typeof(T));");
					source.Indent--;
					resolver.WriteLine("}");

					source.Indent--;
					resolver.WriteLine("}");
			}
			
			using (TypeScope cache = source.WithClass($"{name}FormatterHelper").Static().WithAccessor(TypeAccessor.Internal).WithNamespace("Hertzole.ALE.Generated"))
			{
				cache.WriteLine("private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, " +
				                "global::MessagePack.Formatters.IMessagePackFormatter> formatterMap = " +
				                "new global::System.Collections.Generic.Dictionary<global::System.Type, " +
				                "global::MessagePack.Formatters.IMessagePackFormatter>()");

				cache.WriteLine("{");
				source.Indent++;
				for (int i = 0; i < resolvedTypes.Count; i++)
				{
					string typePrefix = (string.IsNullOrEmpty(resolvedTypes[i].type.GetNamespace(false)) ? "Hertzole" : resolvedTypes[i].type.GetNamespace(false));
					
					string wrapperName = $"global::{resolvedTypes[i].type.GetNamespace(true)}{resolvedTypes[i].type.Name}ExposedWrapper";
					cache.Write($"{{ typeof({wrapperName}), new {typePrefix}.ALE.Generated.Formatters.{resolvedTypes[i].type.Name}Formatter() }}");
					// Add comma if it isn't the last element and always a line break
					if (i < resolvedTypes.Count - 1)
					{
						cache.WriteLine(",", false);
					}
					else
					{
						cache.WriteLine(includeIndent: false);
					}
				}

				source.Indent--;
				cache.WriteLine("};");

				using (MethodScope get = cache.WithMethod("GetFormatter").Static().WithReturnType("global::MessagePack.Formatters.IMessagePackFormatter").WithAccessor(MethodAccessor.Internal).WithParameter("global::System.Type", "type"))
				{
					get.WriteLine("if (formatterMap.TryGetValue(type, out var formatter))");
					get.WriteLine("{");
					source.Indent++;
					get.WriteLine("return formatter;");
					source.Indent--;
					get.WriteLine("}");
					get.WriteLine("else");
					get.WriteLine("{");
					source.Indent++;
					get.WriteLine("return null;");
					source.Indent--;
					get.WriteLine("}");
				}
			}
		}
	}

	public static void ResolveType(INamedTypeSymbol classSymbol, ExposedVar[] exposedVars)
	{
		resolvedTypes.Add((classSymbol, exposedVars));
	}
}