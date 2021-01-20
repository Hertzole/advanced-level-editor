#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using TMPro;
using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#if !OBSOLETE
    [AddComponentMenu("ALE/UI/uGUI/Fields/Vector3 Field", 200)]
#else
    [System.Obsolete("LevelEditorVector3Field has been stripped and will be removed on build.", true)]
#endif
#endif
    public class LevelEditorVector3Field : LevelEditorInspectorField
    {
        [SerializeField]
        private TMP_InputField xField = null;
        [SerializeField]
        private TMP_InputField yField = null;
        [SerializeField]
        private TMP_InputField zField = null;

        private bool isInt;

        protected override void OnAwake()
        {
            this.LogIfStripped();

            xField.onValueChanged.AddListener(x => SetPropValue());
            yField.onValueChanged.AddListener(x => SetPropValue());
            zField.onValueChanged.AddListener(x => SetPropValue());

            xField.onEndEdit.AddListener(x =>
            {
                if (string.IsNullOrWhiteSpace(x))
                {
                    xField.SetTextWithoutNotify("0");
                }
            });

            yField.onEndEdit.AddListener(x =>
            {
                if (string.IsNullOrWhiteSpace(x))
                {
                    yField.SetTextWithoutNotify("0");
                }
            });

            zField.onEndEdit.AddListener(x =>
            {
                if (string.IsNullOrWhiteSpace(x))
                {
                    zField.SetTextWithoutNotify("0");
                }
            });
        }

        public override bool SupportsType(ExposedProperty property)
        {
            return !property.isArray && (property.type == typeof(Vector3) || property.type == typeof(Vector3Int));
        }

        protected override void OnBound(ExposedProperty property, IExposedToLevelEditor exposed)
        {
            isInt = property.type == typeof(Vector3Int);

            xField.contentType = isInt ? TMP_InputField.ContentType.IntegerNumber : TMP_InputField.ContentType.DecimalNumber;
            yField.contentType = isInt ? TMP_InputField.ContentType.IntegerNumber : TMP_InputField.ContentType.DecimalNumber;
            zField.contentType = isInt ? TMP_InputField.ContentType.IntegerNumber : TMP_InputField.ContentType.DecimalNumber;
        }

        protected override void SetFieldValue(object value)
        {
            if (isInt)
            {
                Vector3Int v = (Vector3Int)value;
                xField.SetTextWithoutNotify(v.x.ToString());
                yField.SetTextWithoutNotify(v.y.ToString());
                zField.SetTextWithoutNotify(v.z.ToString());
            }
            else
            {
                Vector3 v = (Vector3)value;
                xField.SetTextWithoutNotify(v.x.ToString());
                yField.SetTextWithoutNotify(v.y.ToString());
                zField.SetTextWithoutNotify(v.z.ToString());
            }
        }

        private void SetPropValue()
        {
            string _x = string.IsNullOrWhiteSpace(xField.text) ? "0" : xField.text;
            string _y = string.IsNullOrWhiteSpace(yField.text) ? "0" : yField.text;
            string _z = string.IsNullOrWhiteSpace(zField.text) ? "0" : zField.text;

            if (isInt)
            {
                if (!int.TryParse(_x, out int x))
                {
                    x = 0;
                }

                if (!int.TryParse(_y, out int y))
                {
                    y = 0;
                }

                if (!int.TryParse(_z, out int z))
                {
                    z = 0;
                }

                SetPropertyValue(new Vector3Int(x, y, z));
            }
            else
            {
                if (!float.TryParse(_x, out float x))
                {
                    x = 0;
                }

                if (!float.TryParse(_y, out float y))
                {
                    y = 0;
                }

                if (!float.TryParse(_z, out float z))
                {
                    z = 0;
                }

                SetPropertyValue(new Vector3(x, y, z));
            }
        }
    }
}
#endif
