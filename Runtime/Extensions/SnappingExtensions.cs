using UnityEngine;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static Vector2 SnapVector2(this ILevelEditorSnapping snapping, Vector2 value, float increment)
        {
            return snapping.SnapVector2(value, increment, increment);
        }

        public static Vector2 SnapVector2(this ILevelEditorSnapping snapping, Vector2 value, Vector2 increment)
        {
            return snapping.SnapVector2(value, increment.x, increment.y);
        }

        public static Vector2 SnapVector2(this ILevelEditorSnapping snapping, Vector2 value, float incrementX, float incrementY)
        {
            value.x = snapping.Snap(value.x, incrementX);
            value.y = snapping.Snap(value.y, incrementY);

            return value;
        }

        public static Vector3 SnapVector3(this ILevelEditorSnapping snapping, Vector3 value, float increment)
        {
            return snapping.SnapVector3(value, increment, increment, increment);
        }

        public static Vector3 SnapVector3(this ILevelEditorSnapping snapping, Vector3 value, Vector3 increment)
        {
            return snapping.SnapVector3(value, increment.x, increment.y, increment.z);
        }

        public static Vector3 SnapVector3(this ILevelEditorSnapping snapping, Vector3 value, float incrementX, float incrementY, float incrementZ)
        {
            value.x = snapping.Snap(value.x, incrementX);
            value.y = snapping.Snap(value.y, incrementY);
            value.z = snapping.Snap(value.z, incrementZ);

            return value;
        }

        public static Quaternion SnapQuaternion(this ILevelEditorSnapping snapping, Quaternion value, float increment)
        {
            return Quaternion.Euler(snapping.SnapVector3(value.eulerAngles, increment, increment, increment));
        }

        public static Quaternion SnapQuaternion(this ILevelEditorSnapping snapping, Quaternion value, Vector3 increment)
        {
            return Quaternion.Euler(snapping.SnapVector3(value.eulerAngles, increment.x, increment.y, increment.z));
        }

        public static Quaternion SnapQuaternion(this ILevelEditorSnapping snapping, Quaternion value, float incrementX, float incrementY, float incrementZ)
        {
            return Quaternion.Euler(snapping.SnapVector3(value.eulerAngles, incrementX, incrementY, incrementZ));
        }

        public static Vector2 SnapPosition(this ILevelEditorSnapping snapping, Vector2 value)
        {
            return snapping.EnableMoveSnap ? snapping.SnapVector2(value, snapping.MoveSnapX, snapping.MoveSnapY) : value;
        }

        public static Vector3 SnapPosition(this ILevelEditorSnapping snapping, Vector3 value)
        {
            return snapping.EnableMoveSnap ? snapping.SnapVector3(value, snapping.MoveSnapX, snapping.MoveSnapY, snapping.MoveSnapZ) : value;
        }

        public static Vector3 SnapRotation(this ILevelEditorSnapping snapping, Vector3 value)
        {
            return snapping.EnableRotateSnap ? snapping.SnapVector3(value, snapping.RotateSnapX, snapping.RotateSnapY, snapping.RotateSnapZ) : value;
        }

        public static Quaternion SnapRotation(this ILevelEditorSnapping snapping, Quaternion value)
        {
            return snapping.EnableRotateSnap ? snapping.SnapQuaternion(value, snapping.RotateSnapX, snapping.RotateSnapY, snapping.RotateSnapZ) : value;
        }

        public static Vector3 SnapScale(this ILevelEditorSnapping snapping, Vector3 value)
        {
            return snapping.EnableScaleSnap ? snapping.SnapVector3(value, snapping.ScaleSnapX, snapping.ScaleSnapY, snapping.ScaleSnapZ) : value;
        }
    }
}
