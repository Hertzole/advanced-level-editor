using TMPro;
using UnityEngine;

namespace Hertzole.ALE
{
    [RequireComponent(typeof(TMP_Text))]
    public class ColorLabel : MonoBehaviour
    {
        [SerializeField]
        private ColorPicker colorPicker = null;

        [SerializeField]
        private ColorValues type = ColorValues.R;

        [SerializeField]
        private string prefix = "R: ";
        [SerializeField]
        private float minValue = 0;
        [SerializeField]
        private float maxValue = 255;

        [SerializeField]
        private int precision = 0;

        [SerializeField]
        [HideInInspector]
        private TMP_Text label = null;

        private void Awake()
        {
            label = GetComponent<TMP_Text>();

        }

        private void OnEnable()
        {
            if (Application.isPlaying && colorPicker != null)
            {
                colorPicker.OnValueChanged.AddListener(ColorChanged);
                colorPicker.OnHSVChanged.AddListener(HSVChanged);
            }
        }

        private void OnDestroy()
        {
            if (colorPicker != null)
            {
                colorPicker.OnValueChanged.RemoveListener(ColorChanged);
                colorPicker.OnHSVChanged.RemoveListener(HSVChanged);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            label = GetComponent<TMP_Text>();
            UpdateValue();
        }
#endif

        private void ColorChanged(Color color)
        {
            UpdateValue();
        }

        private void HSVChanged(float hue, float sateration, float value)
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            if (label == null)
            {
                return;
            }

            if (colorPicker == null)
            {
                label.text = prefix + "-";
            }
            else
            {
                float value = minValue + (colorPicker.GetValue(type) * (maxValue - minValue));

                label.text = prefix + ConvertToDisplayString(value);
            }
        }

        private string ConvertToDisplayString(float value)
        {
            if (precision > 0)
            {
                return value.ToString("f " + precision);
            }
            else
            {
                return Mathf.FloorToInt(value).ToString();
            }
        }
    }

}
