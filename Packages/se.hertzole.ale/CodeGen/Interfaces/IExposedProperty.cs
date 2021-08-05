using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Hertzole.ALE.CodeGen
{
	public interface IExposedProperty
	{
		string Name { get; }
		string CustomName { get; }
		bool Visible { get; }
		int Id { get; }
		int Order { get; }
		
		bool IsProperty { get; }
		bool IsValueType { get; }
		bool IsPrimitive { get; }
		
		bool IsEnum { get; }
		bool IsGameObject { get; }
		bool IsComponent { get; }
		bool IsArray { get; }
		bool IsList { get; }
		bool IsDictionary { get; }
		bool IsCollection { get; }
		
		TypeReference FieldType { get; }
		TypeDefinition FieldTypeResolved { get; }
		TypeReference FieldTypeComponentAware { get; }
		TypeDefinition FieldTypeComponentAwareResolved { get; }

		Instruction GetLoadInstruction(bool ldflda = false);

		Instruction GetSetInstruction();
	}
}