using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    public class LevelEditorColorField : LevelEditorInspectorField
    {
        [SerializeField]
        private Button colorButton = null;
        [SerializeField]
        private Image colorImage = null;
        [SerializeField]
        private Slider alphaSlider = null;

        private Color color;

        protected override void OnAwake()
        {
            colorButton.onClick.AddListener(() =>
            {
                UI.ColorPickerWindow.Show(true);
                UI.ColorPickerWindow.ColorPicker.Color = color;
                UI.ColorPickerWindow.ColorPicker.OnValueChanged.AddListener(OnColorChanged);
                UI.ColorPickerWindow.OnWindowClose.AddListener(OnCloseColorPicker);
            });
        }

        private void OnColorChanged(Color color)
        {
            this.color = color;

            colorImage.color = new Color(color.r, color.g, color.b, 1f);
            if (alphaSlider != null)
            {
                alphaSlider.value = color.a;
            }

            SetPropertyValue(color);
        }

        private void OnCloseColorPicker()
        {
            UI.ColorPickerWindow.ColorPicker.OnValueChanged.RemoveListener(OnColorChanged);
            UI.ColorPickerWindow.OnWindowClose.RemoveListener(OnCloseColorPicker);
        }

        public override bool SupportsType(ExposedProperty property)
        {
            return !property.IsArray && !property.Type.IsArray && (property.Type == typeof(Color) || property.Type == typeof(Color32));
        }

        protected override void SetFieldValue(object value)
        {
            if (value is Color color)
            {
                this.color = color;
                colorImage.color = new Color(color.r, color.g, color.b, 1);
                if (alphaSlider != null)
                {
                    alphaSlider.SetValueWithoutNotify(color.a);
                }
            }
            else if (value is Color32 color32)
            {
                this.color = color32;
                colorImage.color = new Color32(color32.r, color32.g, color32.b, 255);
                if (alphaSlider != null)
                {
                    alphaSlider.value = color32.a / 1f;
                }
            }
        }
    }
}
