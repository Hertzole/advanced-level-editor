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
    [AddComponentMenu("ALE/UI/uGUI/Fields/Number Field", 200)]
#else
    [System.Obsolete("LevelEditorNumberField has been stripped and will be removed on build.", true)]
#endif
#endif
    public class LevelEditorNumberField : LevelEditorInspectorField
    {
        [SerializeField]
        private TMP_InputField textField = null;
        [SerializeField]
        private bool placeholderAsName = true;

        private enum NumberType : ushort { Sbyte, Byte, Short, UShort, Int, UInt, Long, ULong, Float, Double, Decimal }

        private NumberType currentType;

        public event Action<sbyte> OnSByteValueChanged;
        public event Action<byte> OnByteValueChanged;
        public event Action<short> OnShortValueChanged;
        public event Action<ushort> OnUShortValueChanged;
        public event Action<int> OnIntValueChanged;
        public event Action<uint> OnUIntValueChanged;
        public event Action<long> OnLongValueChanged;
        public event Action<ulong> OnULongValueChanged;
        public event Action<float> OnFloatValueChanged;
        public event Action<double> OnDoubleValueChanged;
        public event Action<decimal> OnDecimalValueChanged;

        protected override void OnAwake()
        {
            this.LogIfStripped();

            textField.contentType = TMP_InputField.ContentType.IntegerNumber;
            textField.onValueChanged.AddListener(x => OnValueChanged(x, false));
            textField.onEndEdit.AddListener(x => OnValueChanged(x, true));
        }

        public override bool SupportsType(Type type, bool isArray)
        {
            if (type.IsArray || isArray)
            {
                return false;
            }

            return type == typeof(sbyte) || type == typeof(byte) || type == typeof(short) || type == typeof(ushort) ||
                   type == typeof(int) || type == typeof(uint) || type == typeof(long) || type == typeof(ulong) ||
                   type == typeof(float) || type == typeof(double) || type == typeof(decimal);
        }

        protected override void OnBound(ExposedProperty property, IExposedToLevelEditor exposed)
        {
            if (property.Type == typeof(sbyte))
            {
                currentType = NumberType.Sbyte;
            }
            else if (property.Type == typeof(byte))
            {
                currentType = NumberType.Byte;
            }
            else if (property.Type == typeof(short))
            {
                currentType = NumberType.Short;
            }
            else if (property.Type == typeof(ushort))
            {
                currentType = NumberType.UShort;
            }
            else if (property.Type == typeof(int))
            {
                currentType = NumberType.Int;
            }
            else if (property.Type == typeof(uint))
            {
                currentType = NumberType.UInt;
            }
            else if (property.Type == typeof(long))
            {
                currentType = NumberType.Long;
            }
            else if (property.Type == typeof(ulong))
            {
                currentType = NumberType.ULong;
            }
            else if (property.Type == typeof(float))
            {
                currentType = NumberType.Float;
            }
            else if (property.Type == typeof(double))
            {
                currentType = NumberType.Double;
            }
            else
            {
                currentType = NumberType.Decimal;
            }

            switch (currentType)
            {
                case NumberType.Sbyte:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    textField.characterLimit = 4;
                    break;
                case NumberType.Byte:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    textField.characterLimit = 3;
                    break;
                case NumberType.Short:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    textField.characterLimit = 6;
                    break;
                case NumberType.UShort:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    textField.characterLimit = 5;
                    break;
                case NumberType.Int:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    textField.characterLimit = 11;
                    break;
                case NumberType.UInt:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    textField.characterLimit = 10;
                    break;
                case NumberType.Long:
                case NumberType.ULong:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    textField.characterLimit = 20;
                    break;
                case NumberType.Float:
                    textField.contentType = TMP_InputField.ContentType.DecimalNumber;
                    textField.characterLimit = 8;
                    break;
                case NumberType.Double:
                    textField.contentType = TMP_InputField.ContentType.DecimalNumber;
                    textField.characterLimit = 18;
                    break;
                case NumberType.Decimal:
                    textField.contentType = TMP_InputField.ContentType.DecimalNumber;
                    textField.characterLimit = 29;
                    break;
            }

            if (placeholderAsName && textField.placeholder is TextMeshProUGUI placeholder)
            {
                placeholder.text = property.Name;
            }
        }

        private void OnValueChanged(string stringValue, bool modifyField)
        {
            switch (currentType)
            {
                case NumberType.Sbyte:
                    ParseValue<sbyte>(stringValue, sbyte.MinValue, sbyte.MaxValue, modifyField);
                    break;
                case NumberType.Byte:
                    ParseValue<byte>(stringValue, byte.MinValue, byte.MaxValue, modifyField);
                    break;
                case NumberType.Short:
                    ParseValue<short>(stringValue, short.MinValue, short.MaxValue, modifyField);
                    break;
                case NumberType.UShort:
                    ParseValue<ushort>(stringValue, ushort.MinValue, ushort.MaxValue, modifyField);
                    break;
                case NumberType.Int:
                    ParseValue<int>(stringValue, int.MinValue, int.MaxValue, modifyField);
                    break;
                case NumberType.UInt:
                    ParseValue<uint>(stringValue, uint.MinValue, uint.MaxValue, modifyField);
                    break;
                case NumberType.Long:
                    ParseValue<long>(stringValue, long.MinValue, long.MaxValue, modifyField);
                    break;
                case NumberType.ULong:
                    ParseValue<ulong>(stringValue, ulong.MinValue, ulong.MaxValue, modifyField);
                    break;
                case NumberType.Float:
                    ParseValue<float>(stringValue, float.MinValue, float.MaxValue, modifyField);
                    break;
                case NumberType.Double:
                    ParseValue<double>(stringValue, double.MinValue, double.MaxValue, modifyField);
                    break;
                case NumberType.Decimal:
                    ParseValue<decimal>(stringValue, decimal.MinValue, decimal.MaxValue, modifyField);
                    break;
                default:
                    SetPropertyValue(0);
                    break;
            }
        }

        private void ParseValue<T>(string value, long min, long max, bool modifyField = false) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                }

                InvokeValueChanged(convertedValue);

                return;
            }

            if (long.TryParse(value, out long result))
            {
                if (result < min)
                {
                    result = min;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }
                else if (result > max)
                {
                    result = max;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }

                T convertedValue = (T)Convert.ChangeType(result, typeof(T));
                SetPropertyValue(convertedValue);
                InvokeValueChanged(convertedValue);
            }
            else
            {
                SetPropertyValue(0);
                InvokeValueChanged(0);
            }
        }

        private void ParseValue<T>(string value, ulong min, ulong max, bool modifyField) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                }

                InvokeValueChanged(convertedValue);

                return;
            }

            if (ulong.TryParse(value, out ulong result))
            {
                if (result < min)
                {
                    result = min;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }
                else if (result > max)
                {
                    result = max;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }

                T convertedValue = (T)Convert.ChangeType(result, typeof(T));
                SetPropertyValue(convertedValue);
                InvokeValueChanged(convertedValue);
            }
            else
            {
                SetPropertyValue(0);
                InvokeValueChanged(0);
            }
        }

        private void ParseValue<T>(string value, double min, double max, bool modifyField) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                }

                InvokeValueChanged(convertedValue);

                return;
            }

            if (double.TryParse(value, out double result))
            {
                if (result < min)
                {
                    result = min;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }
                else if (result > max)
                {
                    result = max;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }

                T convertedValue = (T)Convert.ChangeType(result, typeof(T));
                SetPropertyValue(convertedValue);
                InvokeValueChanged(convertedValue);
            }
            else
            {
                SetPropertyValue(0);
                InvokeValueChanged(0);
            }
        }

        private void ParseValue<T>(string value, decimal min, decimal max, bool modifyField) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                }

                InvokeValueChanged(convertedValue);

                return;
            }

            if (decimal.TryParse(value, out decimal result))
            {
                if (result < min)
                {
                    result = min;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }
                else if (result > max)
                {
                    result = max;
                    if (modifyField)
                    {
                        textField.SetTextWithoutNotify(result.ToString());
                    }
                }

                T convertedValue = (T)Convert.ChangeType(result, typeof(T));

                SetPropertyValue(convertedValue);
                InvokeValueChanged(convertedValue);
            }
            else
            {
                SetPropertyValue(0);
                InvokeValueChanged(0);
            }
        }

        private void InvokeValueChanged(object value)
        {
            switch (currentType)
            {
                case NumberType.Sbyte:
                    OnSByteValueChanged?.Invoke((sbyte)value);
                    break;
                case NumberType.Byte:
                    OnByteValueChanged?.Invoke((byte)value);
                    break;
                case NumberType.Short:
                    OnShortValueChanged?.Invoke((short)value);
                    break;
                case NumberType.UShort:
                    OnUShortValueChanged?.Invoke((ushort)value);
                    break;
                case NumberType.Int:
                    OnIntValueChanged?.Invoke((int)value);
                    break;
                case NumberType.UInt:
                    OnUIntValueChanged?.Invoke((uint)value);
                    break;
                case NumberType.Long:
                    OnLongValueChanged?.Invoke((long)value);
                    break;
                case NumberType.ULong:
                    OnULongValueChanged?.Invoke((ulong)value);
                    break;
                case NumberType.Float:
                    OnFloatValueChanged?.Invoke((float)value);
                    break;
                case NumberType.Double:
                    OnDoubleValueChanged?.Invoke((double)value);
                    break;
                case NumberType.Decimal:
                    OnDecimalValueChanged?.Invoke((decimal)value);
                    break;
                default:
                    break;
            }
        }

        protected override void SetFieldValue(object value)
        {
            textField.SetTextWithoutNotify(value.ToString());
        }
    }
}
#endif
