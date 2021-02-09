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
using UnityEngine.Events;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#if !OBSOLETE
    [AddComponentMenu("ALE/UI/uGUI/Fields/Vector2 Field", 200)]
#else
    [System.Obsolete("LevelEditorVector2Field has been stripped and will be removed on build.", true)]
#endif
#endif
    public class LevelEditorVector2Field : LevelEditorInspectorField
    {
        [Serializable]
        public class Vector2Event : UnityEvent<Vector2> { }
        [Serializable]
        public class Vector2IntEvent : UnityEvent<Vector2Int> { }

        private enum VectorTypes { Vector2, Vector2Int, Vector3, Vector3Int, Vector4, Invalid }

        [SerializeField]
        private TMP_InputField xField = null;
        [SerializeField]
        private TMP_InputField yField = null;
        [SerializeField]
        private Vector2Event onValueChanged = new Vector2Event();
        [SerializeField]
        private Vector2Event onValueEndEdit = new Vector2Event();
        [SerializeField]
        private Vector2IntEvent onIntValueChanged = new Vector2IntEvent();
        [SerializeField]
        private Vector2IntEvent onIntEndEdit = new Vector2IntEvent();

        private VectorTypes type;

        private bool IsInt { get { return type == VectorTypes.Vector2Int || type == VectorTypes.Vector3Int; } }

        public Vector2Event OnValueChanged { get { return onValueChanged; } }
        public Vector2IntEvent OnIntValueChanged { get { return onIntValueChanged; } }

        public Vector2Event OnValueEndEdit { get { return onValueEndEdit; } }
        public Vector2IntEvent OnIntEndEdit { get { return onIntEndEdit; } }

        protected override void OnAwake()
        {
            this.LogIfStripped();

            xField.onValueChanged.AddListener(x => SetPropValue(false));
            yField.onValueChanged.AddListener(x => SetPropValue(false));

            xField.onEndEdit.AddListener(x =>
            {
                if (string.IsNullOrWhiteSpace(x))
                {
                    xField.SetTextWithoutNotify("0");
                }

                SetPropValue(true);
            });

            yField.onEndEdit.AddListener(x =>
            {
                if (string.IsNullOrWhiteSpace(x))
                {
                    yField.SetTextWithoutNotify("0");
                }

                SetPropValue(true);
            });
        }

        public override bool SupportsType(Type type, bool isArray)
        {
            return !isArray && (type == typeof(Vector2) || type == typeof(Vector2Int));
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
        }

        protected override void SetFieldValue(object value)
        {
            if (IsInt)
            {
                Vector2Int v = value is Vector3Int v3 ? new Vector2Int(v3.x, v3.y) : (Vector2Int)value;
                xField.SetTextWithoutNotify(v.x.ToString());
                yField.SetTextWithoutNotify(v.y.ToString());
            }
            else
            {
                Vector2 v;
                switch (value)
                {
                    case Vector3 v3:
                        v = new Vector2(v3.x, v3.y);
                        break;
                    case Vector4 v4:
                        v = new Vector2(v4.x, v4.y);
                        break;
                    default:
                        v = (Vector2)value;
                        break;
                }

                xField.SetTextWithoutNotify(v.x.ToString());
                yField.SetTextWithoutNotify(v.y.ToString());
            }
        }

        private void SetPropValue(bool endEdit)
        {
            string _x = string.IsNullOrWhiteSpace(xField.text) ? "0" : xField.text;
            string _y = string.IsNullOrWhiteSpace(yField.text) ? "0" : yField.text;

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

                Vector2Int value = new Vector2Int(x, y);
                switch (type)
                {
                    case VectorTypes.Vector3Int:
                        SetPropertyValue(new Vector3Int(value.x, value.y, 0));
                        break;
                    default:
                        SetPropertyValue(value);
                        break;
                }

                if (endEdit)
                {
                    onIntEndEdit.Invoke(value);
                }
                else
                {
                    onIntValueChanged.Invoke(value);
                }
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

                Vector2 value = new Vector2(x, y);
                switch (type)
                {
                    case VectorTypes.Vector3:
                        SetPropertyValue(new Vector3(value.x, value.y, 0));
                        break;
                    case VectorTypes.Vector4:
                        SetPropertyValue(new Vector4(value.x, value.y, 0, 0));
                        break;
                    default:
                        SetPropertyValue(value);
                        break;
                }

                if (endEdit)
                {
                    onValueEndEdit.Invoke(value);
                }
                else
                {
                    onValueChanged.Invoke(value);
                }
            }
        }
    }
}
#endif
