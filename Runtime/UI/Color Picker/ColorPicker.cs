using UnityEngine;
using UnityEngine.Events;

namespace Hertzole.ALE
{
    public enum ColorValues { R, G, B, A, Hue, Saturation, Value }

    [System.Serializable]
    public class ColorChangedEvent : UnityEvent<Color> { }
    [System.Serializable]
    public class HSVChangedEvent : UnityEvent<float, float, float> { }

    public class ColorPicker : MonoBehaviour
    {
        [SerializeField]
        private Color color = Color.white;

        [Header("Setup")]
        [SerializeField]
        private ColorPickerSetup setup = null;

        [Header("Event")]
        [SerializeField]
        private ColorChangedEvent onValueChanged = new ColorChangedEvent();
        [SerializeField]
        private HSVChangedEvent onHSVChanged = new HSVChangedEvent();
        [SerializeField]
        private ColorChangedEvent onValueEndEdit = new ColorChangedEvent();
        [SerializeField]
        private HSVChangedEvent onHSVEndEdit = new HSVChangedEvent();

        private float hue = 0;
        private float saturation = 0;
        private float brightness = 0;

        public ColorChangedEvent OnValueChanged { get { return onValueChanged; } }
        public HSVChangedEvent OnHSVChanged { get { return onHSVChanged; } }
        public ColorChangedEvent OnValueEndEdit { get { return onValueEndEdit; } }
        public HSVChangedEvent OnHSVEndEdit { get { return onHSVEndEdit; } }

        public Color Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    RGBChanged();
                    SendChangedEvent(false);
                }
            }
        }

        public float H
        {
            get { return hue; }
            set
            {
                AssignColor(ColorValues.Hue, value);
            }
        }

        public float S
        {
            get { return saturation; }
            set
            {
                AssignColor(ColorValues.Saturation, value);
            }
        }

        public float V
        {
            get { return brightness; }
            set
            {
                AssignColor(ColorValues.Value, value);
            }
        }

        public float R
        {
            get { return color.r; }
            set
            {
                AssignColor(ColorValues.R, value);
            }
        }

        public float G
        {
            get { return color.g; }
            set
            {
                AssignColor(ColorValues.G, value);
            }
        }

        public float B
        {
            get { return color.b; }
            set
            {
                AssignColor(ColorValues.B, value);
            }
        }

        private float A
        {
            get { return color.a; }
            set
            {
                AssignColor(ColorValues.A, value);
            }
        }

        private void Start()
        {
            setup.AlphaSlider.Toggle(setup.ShowAlpha);
            setup.ColorToggleElement.Toggle(setup.ShowColorSliderToggle);
            setup.RgbSliders.Toggle(setup.ShowRgb);
            setup.HsvSliders.Toggle(setup.ShowHsv);
            setup.ColorBox.Toggle(setup.ShowColorBox);

            HandleHeaderSetting(setup.ShowHeader);

            RGBChanged();
            SendChangedEvent(false);
        }

        private void RGBChanged()
        {
            HsvColor color = HSVUtil.ConvertRgbToHsv(Color);

            hue = color.normalizedH;
            saturation = color.normalizedS;
            brightness = color.normalizedV;
        }

        private void HSVChanged()
        {
            Color color = HSVUtil.ConvertHsvToRgb(hue * 360, saturation, brightness, this.color.a);

            this.color = color;
        }

        private void SendChangedEvent(bool endEdit)
        {
            if (endEdit)
            {
                onValueEndEdit.Invoke(Color);
                onHSVEndEdit.Invoke(hue, saturation, brightness);
            }
            else
            {
                onValueChanged.Invoke(Color);
                onHSVChanged.Invoke(hue, saturation, brightness);
            }
        }

        public void AssignColor(ColorValues type, float value, bool endEdit = false)
        {
            switch (type)
            {
                case ColorValues.R:
                    if (color.r != value)
                    {
                        color.r = value;
                        RGBChanged();
                        SendChangedEvent(endEdit);
                    }
                    break;
                case ColorValues.G:
                    if (color.g != value)
                    {
                        color.g = value;
                        RGBChanged();
                        SendChangedEvent(endEdit);
                    }
                    break;
                case ColorValues.B:
                    if (color.b != value)
                    {
                        color.b = value;
                        RGBChanged();
                        SendChangedEvent(endEdit);
                    }
                    break;
                case ColorValues.A:
                    if (color.a != value)
                    {
                        color.a = value;
                        SendChangedEvent(endEdit);
                    }
                    break;
                case ColorValues.Hue:
                    if (hue != value)
                    {
                        hue = value;
                        HSVChanged();
                        SendChangedEvent(endEdit);
                    }
                    break;
                case ColorValues.Saturation:
                    if (saturation != value)
                    {
                        saturation = value;
                        HSVChanged();
                        SendChangedEvent(endEdit);
                    }
                    break;
                case ColorValues.Value:
                    if (brightness != value)
                    {
                        brightness = value;
                        HSVChanged();
                        SendChangedEvent(endEdit);
                    }
                    break;
                default:
                    break;
            }
        }

        public float GetValue(ColorValues type)
        {
            switch (type)
            {
                case ColorValues.R:
                    return R;
                case ColorValues.G:
                    return G;
                case ColorValues.B:
                    return B;
                case ColorValues.A:
                    return A;
                case ColorValues.Hue:
                    return H;
                case ColorValues.Saturation:
                    return S;
                case ColorValues.Value:
                    return V;
                default:
                    throw new System.NotImplementedException("");
            }
        }

        public void ToggleColorSliders()
        {
            setup.ShowHsv = !setup.ShowHsv;
            setup.ShowRgb = !setup.ShowRgb;
            setup.HsvSliders.Toggle(setup.ShowHsv);
            setup.RgbSliders.Toggle(setup.ShowRgb);

            onHSVChanged.Invoke(hue, saturation, brightness);
        }

        private void HandleHeaderSetting(ColorPickerSetup.ColorHeaderShowing setupShowHeader)
        {
            if (setupShowHeader == ColorPickerSetup.ColorHeaderShowing.Hide)
            {
                setup.ColorHeader.Toggle(false);
                return;
            }

            setup.ColorHeader.Toggle(true);

            setup.ColorPreview.Toggle(setupShowHeader != ColorPickerSetup.ColorHeaderShowing.ShowColorCode);
            setup.ColorCode.Toggle(setupShowHeader != ColorPickerSetup.ColorHeaderShowing.ShowColor);

        }
    }
}
