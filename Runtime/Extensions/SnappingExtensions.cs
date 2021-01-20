using UnityEngine;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static Vector3 SnapVector3(this ILevelEditorSnapping snapping, Vector3 value, float increment)
        {
            return snapping.SnapVector3(value, new Vector3(increment, increment, increment));
        }

        public static Vector3 SnapPosition(this ILevelEditorSnapping snapping, Vector3 value)
        {
            return snapping.EnableMoveSnap ? snapping.SnapVector3(value, new Vector3(snapping.MoveSnapX, snapping.MoveSnapY, snapping.MoveSnapZ)) : value;
        }

        public static Vector3 SnapRotation(this ILevelEditorSnapping snapping, Vector3 value)
        {
            return snapping.EnableRotateSnap ? snapping.SnapVector3(value, new Vector3(snapping.RotateSnapX, snapping.RotateSnapY, snapping.RotateSnapZ)) : value;
        }

        public static Vector3 SnapScale(this ILevelEditorSnapping snapping, Vector3 value)
        {
            return snapping.EnableScaleSnap ? snapping.SnapVector3(value, new Vector3(snapping.ScaleSnapX, snapping.ScaleSnapY, snapping.ScaleSnapZ)) : value;
        }
    }
}
