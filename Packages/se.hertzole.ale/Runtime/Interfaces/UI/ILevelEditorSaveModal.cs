using System;

namespace Hertzole.ALE
{
    public interface ILevelEditorSaveModal : ILevelEditorModal
    {
        bool ApplyLevelNameOnLoad { get; }
        string LevelName { get; set; }

        event Action<string> OnSave;
    }
}
