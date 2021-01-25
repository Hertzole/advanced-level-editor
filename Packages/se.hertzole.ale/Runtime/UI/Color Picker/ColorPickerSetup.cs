using UnityEngine;

namespace Hertzole.ALE
{
    [System.Serializable]
    public class ColorPickerSetup
    {
        public enum ColorHeaderShowing
        {
            Hide,
            ShowColor,
            ShowColorCode,
            ShowAll,
        }

        [System.Serializable]
        public class UiElements
        {
            [SerializeField]
            private RectTransform[] elements;

            public RectTransform[] Elements { get { return elements; } set { elements = value; } }

            public void Toggle(bool active)
            {
                for (int cnt = 0; cnt < Elements.Length; cnt++)
                {
                    Elements[cnt].gameObject.SetActive(active);
                }
            }

        }

        [SerializeField]
        private bool showRgb = true;
        [SerializeField]
        private bool showHsv = false;
        [SerializeField]
        private bool showAlpha = true;
        [SerializeField]
        private bool showColorBox = true;
        [SerializeField]
        private bool showColorSliderToggle = true;

        [SerializeField]
        private ColorHeaderShowing showHeader = ColorHeaderShowing.ShowAll;

        [SerializeField]
        private UiElements rgbSliders;
        [SerializeField]
        private UiElements hsvSliders;
        [SerializeField]
        private UiElements colorToggleElement;
        [SerializeField]
        private UiElements alphaSliders;


        [SerializeField]
        private UiElements colorHeader;
        [SerializeField]
        private UiElements colorCode;
        [SerializeField]
        private UiElements colorPreview;

        [SerializeField]
        private UiElements colorBox;

        public bool ShowRgb { get { return showRgb; } set { showRgb = value; } }
        public bool ShowHsv { get { return showHsv; } set { showHsv = value; } }
        public bool ShowAlpha { get { return showAlpha; } set { showAlpha = value; } }
        public bool ShowColorBox { get { return showColorBox; } set { showColorBox = value; } }
        public bool ShowColorSliderToggle { get { return showColorSliderToggle; } set { showColorSliderToggle = value; } }

        public ColorHeaderShowing ShowHeader { get { return showHeader; } set { showHeader = value; } }

        public UiElements RgbSliders { get { return rgbSliders; } set { rgbSliders = value; } }
        public UiElements HsvSliders { get { return hsvSliders; } set { hsvSliders = value; } }
        public UiElements ColorToggleElement { get { return colorToggleElement; } set { colorToggleElement = value; } }
        public UiElements AlphaSlider { get { return alphaSliders; } set { alphaSliders = value; } }

        public UiElements ColorHeader { get { return colorHeader; } set { colorHeader = value; } }
        public UiElements ColorCode { get { return colorCode; } set { colorCode = value; } }
        public UiElements ColorPreview { get { return colorPreview; } set { colorPreview = value; } }

        public UiElements ColorBox { get { return colorBox; } set { colorBox = value; } }
    }
}
