using Mono.Cecil;

namespace Hertzole.ALE.CodeGen
{
	public class ResolverProcessor
	{
		private ModuleDefinition module;

		public ResolverProcessor(ModuleDefinition moduleDefinition)
		{
			module = moduleDefinition;
		}

		public void EndEdit()
		{
			
		}
	}
}