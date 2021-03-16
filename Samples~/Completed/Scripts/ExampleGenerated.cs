using UnityEngine;

namespace Hertzole.ALE.Generated
{
    public static class ExampleGenerated
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RegisterTypes()
        {
            LevelEditorSerializer.RegisterType<decimal>();
            LevelEditorSerializer.RegisterType<float>();
        }
    }
}
