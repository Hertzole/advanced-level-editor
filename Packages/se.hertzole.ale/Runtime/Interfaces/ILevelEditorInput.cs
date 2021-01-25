using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorInput
    {
        Vector2 MousePosition { get; }

        bool GetButton(string action);

        bool GetButtonDown(string action);

        bool GetButtonUp(string action);

        float GetAxis(string action, bool raw);

        Vector2 GetVector2(string action, bool raw);

        bool IsMouseOverUI();
    }
}
