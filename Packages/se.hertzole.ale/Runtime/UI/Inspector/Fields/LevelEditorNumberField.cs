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
    [AddComponentMenu("ALE/UI/uGUI/Fields/Number Field", 200)]
#else
    [System.Obsolete("LevelEditorNumberField has been stripped and will be removed on build.", true)]
#endif
#endif
    public class LevelEditorNumberField : LevelEditorInspectorField
    {
        [Serializable]
        public class SByteEvent : UnityEvent<sbyte> { }
        [Serializable]
        public class ByteEvent : UnityEvent<byte> { }
        [Serializable]
        public class ShortEvent : UnityEvent<short> { }
        [Serializable]
        public class UShortEvent : UnityEvent<ushort> { }
        [Serializable]
        public class IntEvent : UnityEvent<int> { }
        [Serializable]
        public class UIntEvent : UnityEvent<uint> { }
        [Serializable]
        public class LongEvent : UnityEvent<long> { }
        [Serializable]
        public class ULongEvent : UnityEvent<ulong> { }
        [Serializable]
        public class FloatEvent : UnityEvent<float> { }
        [Serializable]
        public class DoubleEvent : UnityEvent<double> { }
        [Serializable]
        public class DecimalEvent : UnityEvent<decimal> { }

        [SerializeField]
        private TMP_InputField textField = null;
        [SerializeField]
        private bool placeholderAsName = true;
        [SerializeField]
        private SByteEvent onSByteValueChanged = new SByteEvent();
        [SerializeField]
        private SByteEvent onSByteEndEdit = new SByteEvent();
        [SerializeField]
        private ByteEvent onByteValueChanged = new ByteEvent();
        [SerializeField]
        private ByteEvent onByteEndEdit = new ByteEvent();
        [SerializeField]
        private ShortEvent onShortValueChanged = new ShortEvent();
        [SerializeField]
        private ShortEvent onShortEndEdit = new ShortEvent();
        [SerializeField]
        private UShortEvent onUShortValueChanged = new UShortEvent();
        [SerializeField]
        private UShortEvent onUShortEndEdit = new UShortEvent();
        [SerializeField]
        private IntEvent onIntValueChanged = new IntEvent();
        [SerializeField]
        private IntEvent onIntEndEdit = new IntEvent();
        [SerializeField]
        private UIntEvent onUIntValueChanged = new UIntEvent();
        [SerializeField]
        private UIntEvent onUIntEndEdit = new UIntEvent();
        [SerializeField]
        private LongEvent onLongValueChanged = new LongEvent();
        [SerializeField]
        private LongEvent onLongEndEdit = new LongEvent();
        [SerializeField]
        private ULongEvent onULongValueChanged = new ULongEvent();
        [SerializeField]
        private ULongEvent onULongEndEdit = new ULongEvent();
        [SerializeField]
        private FloatEvent onFloatValueChanged = new FloatEvent();
        [SerializeField]
        private FloatEvent onFloatEndEdit = new FloatEvent();
        [SerializeField]
        private DoubleEvent onDoubleValueChanged = new DoubleEvent();
        [SerializeField]
        private DoubleEvent onDoubleEndEdit = new DoubleEvent();
        [SerializeField]
        private DecimalEvent onDecimalValueChanged = new DecimalEvent();
        [SerializeField]
        private DecimalEvent onDecimalEndEdit = new DecimalEvent();

        private enum NumberType : ushort { Sbyte, Byte, Short, UShort, Int, UInt, Long, ULong, Float, Double, Decimal }

        private NumberType currentType;

        public SByteEvent OnSByteValueChanged { get { return onSByteValueChanged; } }
        public ByteEvent OnByteValueChanged { get { return onByteValueChanged; } }
        public ShortEvent OnShortValueChanged { get { return onShortValueChanged; } }
        public UShortEvent OnUShortValueChanged { get { return onUShortValueChanged; } }
        public IntEvent OnIntValueChanged { get { return onIntValueChanged; } }
        public UIntEvent OnUIntValueChanged { get { return onUIntValueChanged; } }
        public LongEvent OnLongValueChanged { get { return onLongValueChanged; } }
        public ULongEvent OnULongValueChanged { get { return onULongValueChanged; } }
        public FloatEvent OnFloatValueChanged { get { return onFloatValueChanged; } }
        public DoubleEvent OnDoubleValueChanged { get { return onDoubleValueChanged; } }
        public DecimalEvent OnDecimalValueChanged { get { return onDecimalValueChanged; } }

        public SByteEvent OnSByteEndEdit { get { return onSByteEndEdit; } }
        public ByteEvent OnByteEndEdit { get { return onByteEndEdit; } }
        public ShortEvent OnShortEndEdit { get { return onShortEndEdit; } }
        public UShortEvent OnUShortEndEdit { get { return onUShortEndEdit; } }
        public IntEvent OnIntEndEdit { get { return onIntEndEdit; } }
        public UIntEvent OnUIntEndEdit { get { return onUIntEndEdit; } }
        public LongEvent OnLongEndEdit { get { return onLongEndEdit; } }
        public ULongEvent OnULongEndEdit { get { return onULongEndEdit; } }
        public FloatEvent OnFloatEndEdit { get { return onFloatEndEdit; } }
        public DoubleEvent OnDoubleEndEdit { get { return onDoubleEndEdit; } }
        public DecimalEvent OnDecimalEndEdit { get { return onDecimalEndEdit; } }

        protected override void OnAwake()
        {
            this.LogIfStripped();

            textField.contentType = TMP_InputField.ContentType.IntegerNumber;
            textField.onSelect.AddListener(x => BeginEdit());
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
                    SetPropertyValue(0, true);
                    break;
            }
        }

        private void ParseValue<T>(string value, long min, long max, bool modifyField = false) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }

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
                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }
            }
            else
            {
                SetPropertyValue(0, modifyField);
                InvokeValueChanged(0);
            }
        }

        private void ParseValue<T>(string value, ulong min, ulong max, bool modifyField) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }

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
                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }
            }
            else
            {
                SetPropertyValue(0, modifyField);
                InvokeValueChanged(0);
            }
        }

        private void ParseValue<T>(string value, double min, double max, bool modifyField) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }

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
                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }
            }
            else
            {
                SetPropertyValue(0, modifyField);
                InvokeValueChanged(0);
            }
        }

        private void ParseValue<T>(string value, decimal min, decimal max, bool modifyField) where T : IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                T convertedValue = (T)Convert.ChangeType(0, typeof(T));
                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    textField.SetTextWithoutNotify("0");
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }

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

                SetPropertyValue(convertedValue, modifyField);
                if (modifyField)
                {
                    InvokeEndEdit(convertedValue);
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }
            }
            else
            {
                SetPropertyValue(0, modifyField);
                InvokeValueChanged(0);
            }
        }

        private void InvokeValueChanged(object value)
        {
            switch (currentType)
            {
                case NumberType.Sbyte:
                    onSByteValueChanged.Invoke((sbyte)value);
                    break;
                case NumberType.Byte:
                    onByteValueChanged.Invoke((byte)value);
                    break;
                case NumberType.Short:
                    onShortValueChanged.Invoke((short)value);
                    break;
                case NumberType.UShort:
                    onUShortValueChanged.Invoke((ushort)value);
                    break;
                case NumberType.Int:
                    onIntValueChanged.Invoke((int)value);
                    break;
                case NumberType.UInt:
                    onUIntValueChanged.Invoke((uint)value);
                    break;
                case NumberType.Long:
                    onLongValueChanged.Invoke((long)value);
                    break;
                case NumberType.ULong:
                    onULongValueChanged.Invoke((ulong)value);
                    break;
                case NumberType.Float:
                    onFloatValueChanged.Invoke((float)value);
                    break;
                case NumberType.Double:
                    onDoubleValueChanged.Invoke((double)value);
                    break;
                case NumberType.Decimal:
                    onDecimalValueChanged.Invoke((decimal)value);
                    break;
                default:
                    break;
            }
        }

        private void InvokeEndEdit(object value)
        {
            switch (currentType)
            {
                case NumberType.Sbyte:
                    onSByteEndEdit.Invoke((sbyte)value);
                    break;
                case NumberType.Byte:
                    onByteEndEdit.Invoke((byte)value);
                    break;
                case NumberType.Short:
                    onShortEndEdit.Invoke((short)value);
                    break;
                case NumberType.UShort:
                    onUShortEndEdit.Invoke((ushort)value);
                    break;
                case NumberType.Int:
                    onIntEndEdit.Invoke((int)value);
                    break;
                case NumberType.UInt:
                    onUIntEndEdit.Invoke((uint)value);
                    break;
                case NumberType.Long:
                    onLongEndEdit.Invoke((long)value);
                    break;
                case NumberType.ULong:
                    onULongEndEdit.Invoke((ulong)value);
                    break;
                case NumberType.Float:
                    onFloatEndEdit.Invoke((float)value);
                    break;
                case NumberType.Double:
                    onDoubleEndEdit.Invoke((double)value);
                    break;
                case NumberType.Decimal:
                    onDecimalEndEdit.Invoke((decimal)value);
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
