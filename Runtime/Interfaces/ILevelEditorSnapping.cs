using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorSnapping
    {
        bool EnableMoveSnap { get; set; }
        Vector3 MoveSnap { get; set; }

        bool EnableRotateSnap { get; set; }
        Vector3 RotateSnap { get; set; }

        bool EnableScaleSnap { get; set; }
        Vector3 ScaleSnap { get; set; }

        float Snap(float value, float increment);
    }
}
