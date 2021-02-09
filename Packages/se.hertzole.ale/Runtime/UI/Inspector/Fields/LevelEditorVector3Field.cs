#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using System;
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
        private enum VectorTypes { Vector2, Vector2Int, Vector3, Vector3Int, Vector4, Invalid }

        [SerializeField]
        private TMP_InputField xField = null;
        [SerializeField]
        private TMP_InputField yField = null;
        [SerializeField]
        private TMP_InputField zField = null;

        private VectorTypes type;

        private bool IsInt { get { return type == VectorTypes.Vector2Int || type == VectorTypes.Vector3Int; } }

        public event Action<Vector3Int> OnVector3IntValueChanged;
        public event Action<Vector3> OnVector3ValueChanged;

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

        public override bool SupportsType(Type type, bool isArray)
        {
            return !isArray && (type == typeof(Vector3) || type == typeof(Vector3Int));
        }

        protected override void OnBound(ExposedProperty property, IExposedToLevelEditor exposed)
        {
            if (property.Type == typeof(Vector2))
            {
                type = VectorTypes.Vector2;
            }
            else if (property.Type == typeof(Vector2Int))
            {
                type = VectorTypes.Vector2Int;
            }
            else if (property.Type == typeof(Vector3))
            {
                type = VectorTypes.Vector3;
            }
            else if (property.Type == typeof(Vector3Int))
            {
                type = VectorTypes.Vector3Int;
            }
            else if (property.Type == typeof(Vector4))
            {
                type = VectorTypes.Vector4;
            }
            else
            {
                type = VectorTypes.Invalid;
            }

            xField.contentType = IsInt ? TMP_InputField.ContentType.IntegerNumber : TMP_InputField.ContentType.DecimalNumber;
            yField.contentType = IsInt ? TMP_InputField.ContentType.IntegerNumber : TMP_InputField.ContentType.DecimalNumber;
            zField.contentType = IsInt ? TMP_InputField.ContentType.IntegerNumber : TMP_InputField.ContentType.DecimalNumber;
        }

        protected override void SetFieldValue(object value)
        {
            if (IsInt)
            {
                Vector3Int v = value is Vector2Int v2 ? new Vector3Int(v2.x, v2.y, 0) : (Vector3Int)value;
                xField.SetTextWithoutNotify(v.x.ToString());
                yField.SetTextWithoutNotify(v.y.ToString());
                zField.SetTextWithoutNotify(v.z.ToString());
            }
            else
            {
                Vector3 v;
                switch (value)
                {
                    case Vector2 v2:
                        v = new Vector3(v2.x, v2.y, 0);
                        break;
                    case Vector4 v4:
                        v = new Vector3(v4.x, v4.y, v4.z);
                        break;
                    default:
                        v = (Vector3)value;
                        break;
                }
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

            if (IsInt)
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

                Vector3Int value = new Vector3Int(x, y, z);
                switch (type)
                {
                    case VectorTypes.Vector2Int:
                        SetPropertyValue(new Vector2Int(value.x, value.y));
                        break;
                    default:
                        SetPropertyValue(value);
                        break;
                }
                OnVector3IntValueChanged?.Invoke(value);
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

                Vector3 value = new Vector3(x, y, z);
                switch (type)
                {
                    case VectorTypes.Vector2:
                        SetPropertyValue(new Vector2(value.x, value.y));
                        break;
                    case VectorTypes.Vector4:
                        SetPropertyValue(new Vector4(value.x, value.y, value.z, 0));
                        break;
                    default:
                        SetPropertyValue(value);
                        break;
                }
                OnVector3ValueChanged?.Invoke(value);
            }
        }
    }
}
#endif
