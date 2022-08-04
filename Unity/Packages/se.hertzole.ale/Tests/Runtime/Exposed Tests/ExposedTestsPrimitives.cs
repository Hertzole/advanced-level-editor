using System;
using NUnit.Framework;

namespace Hertzole.ALE.Tests
{
	public partial class ExposedTests
	{
		[Test]
		public void SetGet_Bool([ValueSource(nameof(boolValues))] bool value)
		{
			TestSetGetValue<BoolExposed, bool>(0, value);
		}
		
		[Test]
		public void SetGet_Byte([ValueSource(nameof(byteValues))] byte value)
		{
			TestSetGetValue<ByteExposed, byte>(0, value);
		}
		
		[Test]
		public void SetGet_SByte([ValueSource(nameof(sbyteValues))] sbyte value)
		{
			TestSetGetValue<SByteExposed, sbyte>(0, value);
		}
		
		[Test]
		public void SetGet_Short([ValueSource(nameof(shortValues))] short value)
		{
			TestSetGetValue<ShortExposed, short>(0, value);
		}
		
		[Test]
		public void SetGet_UShort([ValueSource(nameof(ushortValues))] ushort value)
		{
			TestSetGetValue<UShortExposed, ushort>(0, value);
		}
		
		[Test]
		public void SetGet_Int([ValueSource(nameof(intValues))] int value)
		{
			TestSetGetValue<IntExposed, int>(0, value);
		}
		
		[Test]
		public void SetGet_UInt([ValueSource(nameof(uintValues))] uint value)
		{
			TestSetGetValue<UIntExposed, uint>(0, value);
		}
		
		[Test]
		public void SetGet_Long([ValueSource(nameof(longValues))] long value)
		{
			TestSetGetValue<LongExposed, long>(0, value);
		}
		
		[Test]
		public void SetGet_ULong([ValueSource(nameof(ulongValues))] ulong value)
		{
			TestSetGetValue<ULongExposed, ulong>(0, value);
		}
		
		[Test]
		public void SetGet_Float([ValueSource(nameof(floatValues))] float value)
		{
			TestSetGetValue<FloatExposed, float>(0, value);
		}
		
		[Test]
		public void SetGet_Decimal([ValueSource(nameof(decimalValues))] decimal value)
		{
			TestSetGetValue<DecimalExposed, decimal>(0, value);
		}
		
		[Test]
		public void SetGet_Double([ValueSource(nameof(doubleValues))] double value)
		{
			TestSetGetValue<DoubleExposed, double>(0, value);
		}
		
		[Test]
		public void SetGet_String([ValueSource(nameof(stringValues))] string value)
		{
			TestSetGetValue<StringExposed, string>(0, value);
		}
		
		[Test]
		public void SetGet_Char([ValueSource(nameof(charValues))] char value)
		{
			TestSetGetValue<CharExposed, char>(0, value);
		}
		
		[Test]
		public void SetGet_Guid([ValueSource(nameof(guidValues))] Guid value)
		{
			TestSetGetValue<GuidExposed, Guid>(0, value);
		}
		
		[Test]
		public void SetGet_DateTime([ValueSource(nameof(dateTimeValues))] DateTime value)
		{
			TestSetGetValue<DateTimeExposed, DateTime>(0, value);
		}
		
		[Test]
		public void SetGet_TimeSpan([ValueSource(nameof(timeSpanValues))] TimeSpan value)
		{
			TestSetGetValue<TimeSpanExposed, TimeSpan>(0, value);
		}
		
		[Test]
		public void SetGet_Uri([ValueSource(nameof(uriValues))] Uri value)
		{
			TestSetGetValue<UriExposed, Uri>(0, value);
		}
	}
}