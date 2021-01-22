using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorSaveModal
    {
        string LevelName { get; }

        event Action<string> OnClickSave;
        event Action OnClickClose;

        GameObject MyGameObject { get; }

        void Initialize();

        void Close();
    }
}
