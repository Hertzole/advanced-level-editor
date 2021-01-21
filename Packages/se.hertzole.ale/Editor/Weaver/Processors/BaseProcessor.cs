using Mono.Cecil;

namespace Hertzole.ALE.Editor
{
    public abstract class BaseProcessor
    {
        public abstract bool IsValidClass(TypeDefinition type);

        public abstract (bool success, bool dirty) ProcessClass(ModuleDefinition module, TypeDefinition type);
    }
}
