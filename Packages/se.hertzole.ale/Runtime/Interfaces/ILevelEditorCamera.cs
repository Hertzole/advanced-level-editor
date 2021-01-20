using UnityEngine;

namespace Hertzole.ALE
{
    public enum ViewTool { None, Orbit, Pan, Dolly, Look };

    public interface ILevelEditorCamera
    {
        Camera CameraComponent { get; }

        ViewTool CameraState { get; }
    }
}
