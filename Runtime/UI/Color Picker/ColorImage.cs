using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [RequireComponent(typeof(Image))]
    public class ColorImage : MonoBehaviour
    {
        [SerializeField]
        private ColorPicker colorPicker = null;

        [SerializeField]
        [HideInInspector]
        private Image image = null;

        private void Awake()
        {
            colorPicker.OnValueChanged.AddListener(ColorChanged);
        }

        private void OnDestroy()
        {
            colorPicker.OnValueChanged.RemoveListener(ColorChanged);
        }

        private void ColorChanged(Color newColor)
        {
            image.color = newColor;
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
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }
#endif
    }

}
