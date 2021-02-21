using Mono.Cecil;

namespace Hertzole.ALE.CodeGen
{
    public abstract class BaseProcessor
    {
        protected readonly WeaverLogger logger;

        public BaseProcessor(WeaverLogger logger)
        {
            this.logger = logger;
        }

        public abstract bool IsValidClass(TypeDefinition type);

        public abstract void ProcessClass(ModuleDefinition module, TypeDefinition type);
    }
}
