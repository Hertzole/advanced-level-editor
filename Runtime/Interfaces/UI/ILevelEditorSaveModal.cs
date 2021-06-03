using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorSaveModal
    {
        bool ApplyLevelNameOnLoad { get; }
        string LevelName { get; set; }

        event Action<string> OnClickSave;
        event Action OnClickClose;

        GameObject MyGameObject { get; }

        void Initialize();

        void Close();
    }
}
