using UnityEngine;

namespace Hertzole.ALE
{
    public class ALESettings : RuntimeProjectSettings<ALESettings>
    {
        #region Wrappers
        [SerializeField]
        private bool applyTransformWrapper = true;
        [SerializeField]
        private bool applyRigidbodyWrapper = true;
        #endregion

        public bool ApplyTransformWrapper { get { return applyTransformWrapper; } set { applyTransformWrapper = value; } }
        public bool ApplyRigidbodyWrapper { get { return applyRigidbodyWrapper; } set { applyRigidbodyWrapper = value; } }
    }
}
