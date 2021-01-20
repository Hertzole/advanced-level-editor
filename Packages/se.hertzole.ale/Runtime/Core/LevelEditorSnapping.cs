using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    [Serializable]
    public class LevelEditorSnapping : ILevelEditorSnapping, IEquatable<LevelEditorSnapping>
    {
        [SerializeField]
        private bool moveSnap;
        [SerializeField]
        private float moveSnapX;
        [SerializeField]
        private float moveSnapY;
        [SerializeField]
        private float moveSnapZ;

        [Space]

        [SerializeField]
        private bool rotateSnap;
        [SerializeField]
        private float rotateSnapX;
        [SerializeField]
        private float rotateSnapY;
        [SerializeField]
        private float rotateSnapZ;

        [Space]

        [SerializeField]
        private bool scaleSnap;
        [SerializeField]
        private float scaleSnapX;
        [SerializeField]
        private float scaleSnapY;
        [SerializeField]
        private float scaleSnapZ;

        public LevelEditorSnapping(bool moveSnap, bool rotateSnap, bool scaleSnap)
        {
            this.moveSnap = moveSnap;
            moveSnapX = 1f;
            moveSnapY = 1f;
            moveSnapZ = 1f;

            this.rotateSnap = rotateSnap;
            rotateSnapX = 45f;
            rotateSnapY = 45f;
            rotateSnapZ = 45f;

            this.scaleSnap = scaleSnap;
            scaleSnapX = 0.1f;
            scaleSnapY = 0.1f;
            scaleSnapZ = 0.1f;
        }

        public bool EnableMoveSnap { get { return moveSnap; } set { moveSnap = value; } }
        public float MoveSnapX { get { return moveSnapX; } set { moveSnapX = value; } }
        public float MoveSnapY { get { return moveSnapY; } set { moveSnapY = value; } }
        public float MoveSnapZ { get { return moveSnapZ; } set { moveSnapZ = value; } }
        public bool EnableRotateSnap { get { return rotateSnap; } set { rotateSnap = value; } }
        public float RotateSnapX { get { return rotateSnapX; } set { rotateSnapX = value; } }
        public float RotateSnapY { get { return rotateSnapY; } set { rotateSnapY = value; } }
        public float RotateSnapZ { get { return rotateSnapZ; } set { rotateSnapZ = value; } }
        public bool EnableScaleSnap { get { return scaleSnap; } set { scaleSnap = value; } }
        public float ScaleSnapX { get { return scaleSnapX; } set { scaleSnapX = value; } }
        public float ScaleSnapY { get { return scaleSnapY; } set { scaleSnapY = value; } }
        public float ScaleSnapZ { get { return scaleSnapZ; } set { scaleSnapZ = value; } }

        public override bool Equals(object obj)
        {
            return Equals(obj as LevelEditorSnapping);
        }

        public bool Equals(LevelEditorSnapping other)
        {
            return other != null &&
                   moveSnap == other.moveSnap &&
                   rotateSnap == other.rotateSnap &&
                   scaleSnap == other.scaleSnap &&
                   moveSnapX == other.moveSnapX &&
                   moveSnapY == other.moveSnapY &&
                   moveSnapZ == other.moveSnapZ &&
                   rotateSnapX == other.rotateSnapX &&
                   rotateSnapY == other.rotateSnapY &&
                   rotateSnapZ == other.rotateSnapZ &&
                   scaleSnapX == other.scaleSnapX &&
                   scaleSnapY == other.scaleSnapY &&
                   scaleSnapZ == other.scaleSnapZ;
        }

        public override int GetHashCode()
        {
            int hashCode = 1785956103;
            hashCode = hashCode * -1521134295 + moveSnap.GetHashCode();
            hashCode = hashCode * -1521134295 + rotateSnap.GetHashCode();
            hashCode = hashCode * -1521134295 + scaleSnap.GetHashCode();
            hashCode = hashCode * -1521134295 + moveSnapX.GetHashCode();
            hashCode = hashCode * -1521134295 + moveSnapY.GetHashCode();
            hashCode = hashCode * -1521134295 + moveSnapZ.GetHashCode();
            hashCode = hashCode * -1521134295 + rotateSnapX.GetHashCode();
            hashCode = hashCode * -1521134295 + rotateSnapY.GetHashCode();
            hashCode = hashCode * -1521134295 + rotateSnapZ.GetHashCode();
            hashCode = hashCode * -1521134295 + scaleSnapX.GetHashCode();
            hashCode = hashCode * -1521134295 + scaleSnapY.GetHashCode();
            hashCode = hashCode * -1521134295 + scaleSnapZ.GetHashCode();
            return hashCode;
        }

        public float Snap(float value, float increment)
        {
            return Mathf.Round(value / increment) * increment;
        }

        public static bool operator ==(LevelEditorSnapping left, LevelEditorSnapping right)
        {
            return EqualityComparer<LevelEditorSnapping>.Default.Equals(left, right);
        }

        public static bool operator !=(LevelEditorSnapping left, LevelEditorSnapping right)
        {
            return !(left == right);
        }
    }
}
