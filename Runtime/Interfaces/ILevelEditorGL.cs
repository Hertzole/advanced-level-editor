using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorGL
    {
        float LineThickness { get; set; }

        Shader LineShader { get; }
    }
}
