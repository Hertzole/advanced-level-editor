using Hertzole.ALE.Binary;
using Mono.Cecil;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public class ALEMessagePackProcessor : BaseProcessor
    {
        private TypeDefinition generatedType;

        public override bool IsValidClass(TypeDefinition type)
        {
            return type.Is<LevelEditorSaveData>() ||
                   type.Is<LevelEditorObjectData>() ||
                   type.Is<LevelEditorComponentData>() ||
                   type.Is<LevelEditorPropertyData>();
        }

        public override (bool success, bool dirty) ProcessClass(ModuleDefinition module, TypeDefinition type)
        {
            if (generatedType == null)
            {
                generatedType = module.ImportReference(typeof(LevelEditorResolver)).Resolve().GetNestedType(typeof(LevelEditorResolver.LevelEditorResolverGetFormatterHelper)).Resolve();
                Debug.Log(generatedType);
            }

            return (true, false);
        }
    }
}
