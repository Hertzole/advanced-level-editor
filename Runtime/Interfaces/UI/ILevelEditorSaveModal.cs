using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorSaveModal
    {
        event Action<string> OnClickSave;
        event Action OnClickClose;

        GameObject MyGameObject { get; }

        void Initialize();

        void Close();
    }
}
