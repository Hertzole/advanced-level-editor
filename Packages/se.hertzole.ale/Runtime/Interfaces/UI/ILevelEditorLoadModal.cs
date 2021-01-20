using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorLoadModal
    {
        event Action<string> OnClickLoadLevel;
        event Action OnClickClose;

        GameObject MyGameObject { get; }

        void Initialize();

        void PopulateLevels(string[] paths);

        void Close();
    }
}
