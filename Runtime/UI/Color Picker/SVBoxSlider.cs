using UnityEngine;
using UnityEngine.UI;

namespace Hertzole.ALE
{
    [RequireComponent(typeof(BoxSlider), typeof(RawImage)), ExecuteInEditMode()]
    public class SVBoxSlider : MonoBehaviour
    {
        [SerializeField]
        private ColorPicker colorPicker = null;

        [SerializeField]
        [HideInInspector]
        private BoxSlider slider = null;
        [SerializeField]
        [HideInInspector]
        private RawImage image = null;

        private int textureWidth = 128;
        private int textureHeight = 128;

        private float lastH = -1;
        private bool listen = true;

        public RectTransform rectTransform
        {
            get
            {
                return transform as RectTransform;
            }
        }

        private void Awake()
        {
            if (Application.isPlaying)
            {
                RegenerateSVTexture();
            }
        }

        private void OnEnable()
        {
            if (Application.isPlaying && colorPicker != null)
            {
                slider.OnValueChanged.AddListener(SliderChanged);
                colorPicker.OnHSVChanged.AddListener(HSVChanged);
            }
        }

        private void OnDisable()
        {
            if (colorPicker != null)
            {
                slider.OnValueChanged.RemoveListener(SliderChanged);
                colorPicker.OnHSVChanged.RemoveListener(HSVChanged);
            }
        }

        private void OnDestroy()
        {
            if (image.texture != null)
            {
                DestroyImmediate(image.texture);
            }
        }

        private void SliderChanged(float saturation, float value)
        {
            if (listen)
            {
                colorPicker.AssignColor(ColorValues.Saturation, saturation);
                colorPicker.AssignColor(ColorValues.Value, value);
            }
            listen = true;
        }

        private void HSVChanged(float h, float s, float v)
        {
            if (!lastH.Equals(h))
            {
                lastH = h;
                RegenerateSVTexture();
            }

            if (!s.Equals(slider.NormalizedValue))
            {
                listen = false;
                slider.NormalizedValue = s;
            }

            if (!v.Equals(slider.NormalizedValueY))
            {
                listen = false;
                slider.NormalizedValueY = v;
            }
        }

        private void RegenerateSVTexture()
        {
            double h = colorPicker != null ? colorPicker.H * 360 : 0;

            if (image.texture != null)
            {
                DestroyImmediate(image.texture);
            }

            Texture2D texture = new Texture2D(textureWidth, textureHeight)
            {
                wrapMode = TextureWrapMode.Clamp,
                hideFlags = HideFlags.DontSave
            };

            for (int s = 0; s < textureWidth; s++)
            {
                Color[] colors = new Color[textureHeight];
                for (int v = 0; v < textureHeight; v++)
                {
                    colors[v] = HSVUtil.ConvertHsvToRgb(h, (float)s / textureWidth, (float)v / textureHeight, 1);
                }
                texture.SetPixels(s, 0, 1, textureHeight, colors);
            }
            texture.Apply();

            image.texture = texture;

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
                slider = GetComponent<BoxSlider>();
            }

            if (image == null)
            {
                image = GetComponent<RawImage>();
            }
        }
#endif
    }
}
