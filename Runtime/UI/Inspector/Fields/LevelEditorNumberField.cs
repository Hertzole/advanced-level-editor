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

        private bool editing;
        
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

        private const int CHARACTER_LIMIT_BYTE = 3;
        private const int CHARACTER_LIMIT_SHORT = 5;
        private const int CHARACTER_LIMIT_INT = 10;
        private const int CHARACTER_LIMIT_LONG = 18;
        private const int CHARACTER_LIMIT_FLOAT = 8;
        private const int CHARACTER_LIMIT_DOUBLE = 18;
        private const int CHARACTER_LIMIT_DECIMAL = 29;

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

        protected override void OnBound(ExposedField property, IExposedToLevelEditor exposed)
        {
            editing = false;
            
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
                    break;
                case NumberType.Byte:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    break;
                case NumberType.Short:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    break;
                case NumberType.UShort:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    break;
                case NumberType.Int:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    break;
                case NumberType.UInt:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    break;
                case NumberType.Long:
                case NumberType.ULong:
                    textField.contentType = TMP_InputField.ContentType.IntegerNumber;
                    break;
                case NumberType.Float:
                    textField.contentType = TMP_InputField.ContentType.DecimalNumber;
                    break;
                case NumberType.Double:
                    textField.contentType = TMP_InputField.ContentType.DecimalNumber;
                    break;
                case NumberType.Decimal:
                    textField.contentType = TMP_InputField.ContentType.DecimalNumber;
                    break;
            }

            if (placeholderAsName && textField.placeholder is TextMeshProUGUI placeholder)
            {
                placeholder.text = property.Name;
            }
        }

        private void OnValueChanged(string stringValue, bool endEdit)
        {
            editing = !endEdit;

            switch (currentType)
            {
                case NumberType.Sbyte:
                    ParseValue<sbyte, long>(stringValue, sbyte.MinValue, sbyte.MaxValue, CHARACTER_LIMIT_BYTE, endEdit, LongParse);
                    break;
                case NumberType.Byte:
                    ParseValue<byte, ulong>(stringValue, byte.MinValue, byte.MaxValue, CHARACTER_LIMIT_BYTE, endEdit, ULongParse);
                    break;
                case NumberType.Short:
                    ParseValue<short, long>(stringValue, short.MinValue, short.MaxValue, CHARACTER_LIMIT_SHORT, endEdit, LongParse);
                    break;
                case NumberType.UShort:
                    ParseValue<ushort, ulong>(stringValue, ushort.MinValue, ushort.MaxValue, CHARACTER_LIMIT_SHORT, endEdit, ULongParse);
                    break;
                case NumberType.Int:
                    ParseValue<int, long>(stringValue, int.MinValue, int.MaxValue, CHARACTER_LIMIT_INT, endEdit, LongParse);
                    break;
                case NumberType.UInt:
                    ParseValue<uint, ulong>(stringValue, uint.MinValue, uint.MaxValue, CHARACTER_LIMIT_INT, endEdit, ULongParse);
                    break;
                case NumberType.Long:
                    ParseValue<long, long>(stringValue, long.MinValue, long.MaxValue, CHARACTER_LIMIT_LONG, endEdit, LongParse);
                    break;
                case NumberType.ULong:
                    ParseValue<ulong, ulong>(stringValue, ulong.MinValue, ulong.MaxValue, CHARACTER_LIMIT_LONG, endEdit, ULongParse);
                    break;
                case NumberType.Float:
                    ParseValue<float, float>(stringValue, float.MinValue, float.MaxValue, CHARACTER_LIMIT_FLOAT, endEdit, x =>
                    {
                        bool canParse = float.TryParse(x, out float result);
                        return (canParse, result);
                    });
                    break;
                case NumberType.Double:
                    ParseValue<double, double>(stringValue, double.MinValue, double.MaxValue, CHARACTER_LIMIT_DOUBLE, endEdit, x =>
                    {
                        bool canParse = double.TryParse(x, out double result);
                        return (canParse, result);
                    });
                    break;
                case NumberType.Decimal:
                    ParseValue<decimal, decimal>(stringValue, decimal.MinValue, decimal.MaxValue, CHARACTER_LIMIT_DECIMAL, endEdit, x =>
                    {
                        bool canParse = decimal.TryParse(x, out decimal result);
                        return (canParse, result);
                    });
                    break;
                default:
                    ModifyPropertyValue(0, true);
                    break;
            }

            static (bool, long) LongParse(string x)
            {
                bool canParse = long.TryParse(x, out long result);
                return (canParse, result);
            }

            static (bool, ulong) ULongParse(string x)
            {
                bool canParse = ulong.TryParse(x, out ulong result);
                return (canParse, result);
            }
        }

        private void ParseValue<TValue, TConverter>(string value, TConverter min, TConverter max, int maxCharacters, bool endEdit, Func<string, ValueTuple<bool, TConverter>> parse) 
            where TValue : IConvertible, IComparable<TValue> where TConverter : IConvertible, IComparable<TConverter>
        {
            // If the value starts with - add one extra to the max characters to fit that in.
            textField.characterLimit = !string.IsNullOrWhiteSpace(value) && value.StartsWith("-") ? maxCharacters + 1 : maxCharacters;
            
            TValue convertedValue;
            
            if (string.IsNullOrWhiteSpace(value))
            {
                convertedValue = (TValue)Convert.ChangeType(0, typeof(TValue));
                ModifyPropertyValue(0, true);
                if (endEdit)
                {
                    textField.SetTextWithoutNotify("0");
                    InvokeEndEdit(convertedValue);
                    EndEdit();
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }

                return;
            }

            (bool canParse, TConverter result) = parse.Invoke(value);
            LevelEditorLogger.Log($"Can Parse: {canParse} | Result: {result} | Min: {min} | Max: {max} | Compare min: {result.CompareTo(min)} | Compare max: {result.CompareTo(max)}");
            if (canParse)
            {
                // Make sure the result is within the ranges.
                if (result.CompareTo(min) < 0)
                {
                    result = min;
                }
                else if (result.CompareTo(max) > 0)
                {
                    result = max;
                }

                // Convert the value to what we want and set the property value.
                convertedValue = (TValue) Convert.ChangeType(result, typeof(TValue));
                ModifyPropertyValue(convertedValue, true);

                // If the user is leaving the text field, it's safe to update the text field to the actual result.
                // Otherwise we just leave it be and invoke the value changed event.
                if (endEdit)
                {
                    textField.SetTextWithoutNotify(result.ToString());
                    InvokeEndEdit(convertedValue);
                    EndEdit();
                }
                else
                {
                    InvokeValueChanged(convertedValue);
                }
            }
            else if (endEdit)
            {
                convertedValue = (TValue) Convert.ChangeType(0, typeof(TValue));
                textField.SetTextWithoutNotify(convertedValue.ToString());
                ModifyPropertyValue(convertedValue, true);
                InvokeEndEdit(convertedValue);
                EndEdit();
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
            // If the field is currently being edited, we don't want to update it.
            if (editing)
            {
                return;
            }
            
            textField.SetTextWithoutNotify(value.ToString());
        }
    }
}
#endif
