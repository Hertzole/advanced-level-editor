using System;
using UnityEngine;

namespace Hertzole.ALE
{
    [Serializable]
    public class LevelEditorSnapping : ILevelEditorSnapping
    {
        [SerializeField]
        private bool enableMoveSnap = true;
        [SerializeField]
        private Vector3 moveSnap = new Vector3(1, 1, 1);

        [Space]

        [SerializeField]
        private bool enableRotateSnap = true;
        [SerializeField]
        private Vector3 rotateSnap = new Vector3(10, 10, 10);

        [Space]

        [SerializeField]
        private bool enableScaleSnap;
        [SerializeField]
        private Vector3 scaleSnap = new Vector3(0.1f, 0.1f, 0.1f);

        public bool EnableMoveSnap { get { return enableMoveSnap; } set { enableMoveSnap = value; } }
        public Vector3 MoveSnap { get { return moveSnap; } set { moveSnap = value; } }

        public bool EnableRotateSnap { get { return enableRotateSnap; } set { enableRotateSnap = value; } }
        public Vector3 RotateSnap { get { return rotateSnap; } set { rotateSnap = value; } }

        public bool EnableScaleSnap { get { return enableScaleSnap; } set { enableScaleSnap = value; } }
        public Vector3 ScaleSnap { get { return scaleSnap; } set { scaleSnap = value; } }

        public float Snap(float value, float increment)
        {
            return Mathf.Round(value / increment) * increment;
        }
    }
}
