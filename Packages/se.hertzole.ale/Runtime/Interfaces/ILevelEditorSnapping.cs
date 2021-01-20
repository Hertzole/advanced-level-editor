using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorSnapping
    {
        bool EnableMoveSnap { get; set; }
        float MoveSnapX { get; set; }
        float MoveSnapY { get; set; }
        float MoveSnapZ { get; set; }

        bool EnableRotateSnap { get; set; }
        float RotateSnapX { get; set; }
        float RotateSnapY { get; set; }
        float RotateSnapZ { get; set; }

        bool EnableScaleSnap { get; set; }
        float ScaleSnapX { get; set; }
        float ScaleSnapY { get; set; }
        float ScaleSnapZ { get; set; }

        Vector3 SnapVector3(Vector3 value, Vector3 increment);

        float Snap(float value, float increment);
    }
}
