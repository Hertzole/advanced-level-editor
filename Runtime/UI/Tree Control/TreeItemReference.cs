using TMPro;
using UnityEngine;

namespace Hertzole.ALE
{
    public class TreeItemReference : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI label = null;

        public TextMeshProUGUI Label { get { return label; } }
    }
}
