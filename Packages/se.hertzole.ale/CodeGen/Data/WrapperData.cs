using Mono.Cecil;

namespace Hertzole.ALE.CodeGen.Data
{
	public class WrapperData
	{
		public TypeDefinition wrapper;
		public MethodDefinition wrapperConstructor;
		public TypeDefinition dirtyMaskType;
		public FieldDefinition dirtyMaskField;

		public WrapperData(TypeDefinition wrapper, MethodDefinition wrapperConstructor, TypeDefinition dirtyMaskType, FieldDefinition dirtyMaskField)
		{
			this.wrapper = wrapper;
			this.wrapperConstructor = wrapperConstructor;
			this.dirtyMaskType = dirtyMaskType;
			this.dirtyMaskField = dirtyMaskField;
		}
	}
}