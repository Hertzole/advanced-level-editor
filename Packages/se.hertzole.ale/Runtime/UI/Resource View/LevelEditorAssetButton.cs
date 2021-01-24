using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class AssetButtonClickArgs : EventArgs
    {
        public object Item { get; private set; }

        public AssetButtonClickArgs(object item)
        {
            Item = item;
        }
    }

    [RequireComponent(typeof(Button))]
    public class LevelEditorAssetButton : MonoBehaviour
    {
        [SerializeField]
        private Image icon = null;
        [SerializeField]
        private TextMeshProUGUI label = null;

        [SerializeField]
        [HideInInspector]
        private Button button = null;

        public object Item { get; set; }

        public Image Icon { get { return icon; } set { icon = value; } }
        public TextMeshProUGUI Label { get { return label; } set { label = value; } }

        public event EventHandler<AssetButtonClickArgs> OnClick;

        private void Awake()
        {
            button.onClick.AddListener(() => OnClick?.Invoke(this, new AssetButtonClickArgs(Item)));
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }
        }
#endif
    }
}
