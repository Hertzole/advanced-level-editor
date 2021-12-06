using System.Collections.Generic;

namespace Hertzole.ALE
{
    public interface ILevelEditorResources
    {
        IReadOnlyList<ILevelEditorResource> GetResources();
    }
}
