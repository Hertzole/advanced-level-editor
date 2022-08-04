using System;
using NUnit.Framework;

namespace Hertzole.ALE.Tests
{
	public partial class SerializerTest
	{
		// Bool
		[Test]
		public void SerializeDeserialize_Bool([ValueSource(nameof(boolValues))] bool value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Byte
		[Test]
		public void SerializeDeserialize_Byte([ValueSource(nameof(byteValues))] byte value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// SByte
		[Test]
		public void SerializeDeserialize_SByte([ValueSource(nameof(sbyteValues))] sbyte value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Short
		[Test]
		public void SerializeDeserialize_Short([ValueSource(nameof(shortValues))] short value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// UShort
		[Test]
		public void SerializeDeserialize_UShort([ValueSource(nameof(ushortValues))] ushort value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Int
		[Test]
		public void SerializeDeserialize_Int([ValueSource(nameof(intValues))] int value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// UInt
		[Test]
		public void SerializeDeserialize_UInt([ValueSource(nameof(uintValues))] uint value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Long
		[Test]
		public void SerializeDeserialize_Long([ValueSource(nameof(longValues))] long value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// ULong
		[Test]
		public void SerializeDeserialize_ULong([ValueSource(nameof(ulongValues))] ulong value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Float
		[Test]
		public void SerializeDeserialize_Float([ValueSource(nameof(floatValues))] float value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Decimal
		[Test]
		public void SerializeDeserialize_Decimal([ValueSource(nameof(decimalValues))] decimal value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Double
		[Test]
		public void SerializeDeserialize_Double([ValueSource(nameof(doubleValues))] double value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// String
		[Test]
		public void SerializeDeserialize_String([ValueSource(nameof(stringValues))] string value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Char
		[Test]
		public void SerializeDeserialize_Char([ValueSource(nameof(charValues))] char value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// DateTime
		[Test]
		public void SerializeDeserialize_DateTime([ValueSource(nameof(dateTimeValues))] DateTime value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// TimeSpan
		[Test]
		public void SerializeDeserialize_TimeSpan([ValueSource(nameof(timeSpanValues))] TimeSpan value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Guid
		[Test]
		public void SerializeDeserialize_Guid([ValueSource(nameof(guidValues))] Guid value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
		
		// Uri
		[Test]
		public void SerializeDeserialize_Uri([ValueSource(nameof(uriValues))] Uri value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
	}
}