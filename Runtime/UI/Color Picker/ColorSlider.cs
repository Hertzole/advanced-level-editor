using UnityEngine;
using UnityEngine.UI;
namespace Hertzole.ALE
{
    /// <summary>
    /// Displays one of the color values of aColorPicker
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class ColorSlider : MonoBehaviour
    {
        [SerializeField]
        private ColorPicker colorPicker;

        /// <summary>
        /// Which value this slider can edit.
        /// </summary>
        [SerializeField]
        private ColorValues type;

        [SerializeField]
        [HideInInspector]
        private Slider slider;

        private bool listen = true;

        private void Awake()
        {
            colorPicker.OnValueChanged.AddListener(ColorChanged);
            colorPicker.OnHSVChanged.AddListener(HSVChanged);
            slider.onValueChanged.AddListener(SliderChanged);
        }

        private void OnDestroy()
        {
            colorPicker.OnValueChanged.RemoveListener(ColorChanged);
            colorPicker.OnHSVChanged.RemoveListener(HSVChanged);
            slider.onValueChanged.RemoveListener(SliderChanged);
        }

        private void ColorChanged(Color newColor)
        {
            listen = false;
            switch (type)
            {
                case ColorValues.R:
                    slider.normalizedValue = newColor.r;
                    break;
                case ColorValues.G:
                    slider.normalizedValue = newColor.g;
                    break;
                case ColorValues.B:
                    slider.normalizedValue = newColor.b;
                    break;
                case ColorValues.A:
                    slider.normalizedValue = newColor.a;
                    break;
                default:
                    break;
            }
        }

        private void HSVChanged(float hue, float saturation, float value)
        {
            listen = false;
            switch (type)
            {
                case ColorValues.Hue:
                    slider.normalizedValue = hue; //1 - hue;
                    break;
                case ColorValues.Saturation:
                    slider.normalizedValue = saturation;
                    break;
                case ColorValues.Value:
                    slider.normalizedValue = value;
                    break;
                default:
                    break;
            }
        }

        private void SliderChanged(float newValue)
        {
            if (listen)
            {
                newValue = slider.normalizedValue;
                //if (type == ColorValues.Hue)
                //    newValue = 1 - newValue;

                colorPicker.AssignColor(type, newValue);
            }
            listen = true;
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
            if (slider == null)
            {
                slider = GetComponent<Slider>();
            }
        }
#endif
    }
}
