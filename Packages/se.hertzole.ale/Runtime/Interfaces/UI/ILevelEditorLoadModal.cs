using System;

namespace Hertzole.ALE
{
    public interface ILevelEditorLoadModal : ILevelEditorModal
    {
        event Action<string> OnLoadLevel;

        void PopulateLevels(string[] paths);
    }
}
