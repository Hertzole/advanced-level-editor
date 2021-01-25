using TMPro;
using UnityEngine;
namespace Hertzole.ALE
{
    [RequireComponent(typeof(TMP_InputField))]
    public class HexColorField : MonoBehaviour
    {
        [SerializeField]
        private ColorPicker colorPicker;

        [SerializeField]
        private bool displayAlpha;

        [SerializeField]
        [HideInInspector]
        private TMP_InputField hexInputField = null;

        private void Awake()
        {
            // Add listeners to keep text (and color) up to date
            hexInputField.onEndEdit.AddListener(UpdateColor);
            colorPicker.OnValueChanged.AddListener(UpdateHex);
        }

        private void OnDestroy()
        {
            hexInputField.onValueChanged.RemoveListener(UpdateColor);
            colorPicker.OnValueChanged.RemoveListener(UpdateHex);
        }

        private void UpdateHex(Color newColor)
        {
            hexInputField.text = ColorToHex(newColor);
        }

        private void UpdateColor(string newHex)
        {
            Color color;
            if (!newHex.StartsWith("#"))
            {
                newHex = "#" + newHex;
            }

            if (ColorUtility.TryParseHtmlString(newHex, out color))
            {
                colorPicker.Color = color;
            }
            else
            {
                hexInputField.SetTextWithoutNotify("#FFFFFF");
            }
        }

        private string ColorToHex(Color32 color)
        {
            return displayAlpha
                ? string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.r, color.g, color.b, color.a)
                : string.Format("#{0:X2}{1:X2}{2:X2}", color.r, color.g, color.b);
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
            if (hexInputField == null)
            {
                hexInputField = GetComponent<TMP_InputField>();
            }
        }
#endif
    }
}
