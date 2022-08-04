using System;
using NUnit.Framework;

namespace Hertzole.ALE.Tests
{
	public partial class SerializerTest
	{
		// Bool
		[Test]
		public void SerializeDeserialize_BoolNullable([ValueSource(nameof(boolValues))] bool? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Byte
		[Test]
		public void SerializeDeserialize_ByteNullable([ValueSource(nameof(byteValues))] byte? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// SByte
		[Test]
		public void SerializeDeserialize_SByteNullable([ValueSource(nameof(sbyteValues))] sbyte? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Short
		[Test]
		public void SerializeDeserialize_ShortNullable([ValueSource(nameof(shortValues))] short? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// UShort
		[Test]
		public void SerializeDeserialize_UShortNullable([ValueSource(nameof(ushortValues))] ushort? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Int
		[Test]
		public void SerializeDeserialize_IntNullable([ValueSource(nameof(intValues))] int? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// UInt
		[Test]
		public void SerializeDeserialize_UIntNullable([ValueSource(nameof(uintValues))] uint? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Long
		[Test]
		public void SerializeDeserialize_LongNullable([ValueSource(nameof(longValues))] long? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// ULong
		[Test]
		public void SerializeDeserialize_ULongNullable([ValueSource(nameof(ulongValues))] ulong? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Float
		[Test]
		public void SerializeDeserialize_FloatNullable([ValueSource(nameof(floatValues))] float? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Decimal
		[Test]
		public void SerializeDeserialize_DecimalNullable([ValueSource(nameof(decimalValues))] decimal? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Double
		[Test]
		public void SerializeDeserialize_DoubleNullable([ValueSource(nameof(doubleValues))] double? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Char
		[Test]
		public void SerializeDeserialize_CharNullable([ValueSource(nameof(charValues))] char? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// DateTime
		[Test]
		public void SerializeDeserialize_DateTimeNullable([ValueSource(nameof(dateTimeValues))] DateTime? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// TimeSpan
		[Test]
		public void SerializeDeserialize_TimeSpanNullable([ValueSource(nameof(timeSpanValues))] TimeSpan? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Guid
		[Test]
		public void SerializeDeserialize_GuidNullable([ValueSource(nameof(guidValues))] Guid? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
	}
}