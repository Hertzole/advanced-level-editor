using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Hertzole.ALE.CodeGen
{
    public abstract class BaseProcessor
    {
        public Weaver Weaver { get; set; }
        public ModuleDefinition Module { get; set; }
        public TypeDefinition Type { get; set; }
        public RegisterTypeProcessor TypeRegister { get; set; }
        public ResolverProcessor Resolver { get; set; }
        public FormatterProcessor Formatters { get; set; }
        
        public bool IsBuildingPlayer { get; set; }

        public abstract bool IsValidClass(TypeDefinition type);

        public abstract void ProcessClass(TypeDefinition type);

        protected void Error(string message)
        {
            Weaver.Error(message);
        }

        protected void Error(MethodDefinition methodDefinition, string message)
        {
            Weaver.Error(methodDefinition, message);
        }

        protected void Error(SequencePoint sequencePoint, string message)
        {
            Weaver.Error(sequencePoint, message);
        }
    }
}
