using UnityEngine;

namespace Hertzole.ALE
{
    public class ALESettings : RuntimeProjectSettings<ALESettings>
    {
        #region Wrappers
        [SerializeField]
        private bool applyTransformWrapper;
        [SerializeField]
        private bool applyRigidbodyWrapper;
        #endregion

        public bool ApplyTransformWrapper { get { return applyTransformWrapper; } set { applyTransformWrapper = value; } }
        public bool ApplyRigidbodyWrapper { get { return applyRigidbodyWrapper; } set { applyRigidbodyWrapper = value; } }
    }
}
