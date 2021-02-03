using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorObjectSettings : MonoBehaviour
    {
        [SerializeField]
        private bool canReparent = true;

        public bool CanReparent { get { return canReparent; } set { canReparent = value; } }
    }
}
