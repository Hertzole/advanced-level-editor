using System;
using NUnit.Framework;

namespace Hertzole.ALE.Tests
{
	public partial class ExposedTests
	{
		[Test]
		public void SetGet_Bool_Nullable([ValueSource(nameof(boolValuesNullable))] bool? value)
		{
			TestSetGetValue<BoolExposedNullable, bool?>(0, value);
		}
		
		[Test]
		public void SetGet_Byte_Nullable([ValueSource(nameof(byteValuesNullable))] byte? value)
		{
			TestSetGetValue<ByteExposedNullable, byte?>(0, value);
		}
		
		[Test]
		public void SetGet_SByte_Nullable([ValueSource(nameof(sbyteValuesNullable))] sbyte? value)
		{
			TestSetGetValue<SByteExposedNullable, sbyte?>(0, value);
		}
		
		[Test]
		public void SetGet_Short_Nullable([ValueSource(nameof(shortValuesNullable))] short? value)
		{
			TestSetGetValue<ShortExposedNullable, short?>(0, value);
		}
		
		[Test]
		public void SetGet_UShort_Nullable([ValueSource(nameof(ushortValuesNullable))] ushort? value)
		{
			TestSetGetValue<UShortExposedNullable, ushort?>(0, value);
		}
		
		[Test]
		public void SetGet_Int_Nullable([ValueSource(nameof(intValuesNullable))] int? value)
		{
			TestSetGetValue<IntExposedNullable, int?>(0, value);
		}
		
		[Test]
		public void SetGet_UInt_Nullable([ValueSource(nameof(uintValuesNullable))] uint? value)
		{
			TestSetGetValue<UIntExposedNullable, uint?>(0, value);
		}
		
		[Test]
		public void SetGet_Long_Nullable([ValueSource(nameof(longValuesNullable))] long? value)
		{
			TestSetGetValue<LongExposedNullable, long?>(0, value);
		}
		
		[Test]
		public void SetGet_ULong_Nullable([ValueSource(nameof(ulongValuesNullable))] ulong? value)
		{
			TestSetGetValue<ULongExposedNullable, ulong?>(0, value);
		}
		
		[Test]
		public void SetGet_Float_Nullable([ValueSource(nameof(floatValuesNullable))] float? value)
		{
			TestSetGetValue<FloatExposedNullable, float?>(0, value);
		}
		
		[Test]
		public void SetGet_Decimal_Nullable([ValueSource(nameof(decimalValuesNullable))] decimal? value)
		{
			TestSetGetValue<DecimalExposedNullable, decimal?>(0, value);
		}
		
		[Test]
		public void SetGet_Double_Nullable([ValueSource(nameof(doubleValuesNullable))] double? value)
		{
			TestSetGetValue<DoubleExposedNullable, double?>(0, value);
		}

		[Test]
		public void SetGet_Char_Nullable([ValueSource(nameof(charValuesNullable))] char? value)
		{
			TestSetGetValue<CharExposedNullable, char?>(0, value);
		}
		
		[Test]
		public void SetGet_Guid_Nullable([ValueSource(nameof(guidValuesNullable))] Guid? value)
		{
			TestSetGetValue<GuidExposedNullable, Guid?>(0, value);
		}
		
		[Test]
		public void SetGet_DateTime_Nullable([ValueSource(nameof(dateTimeValuesNullable))] DateTime? value)
		{
			TestSetGetValue<DateTimeExposedNullable, DateTime?>(0, value);
		}
		
		[Test]
		public void SetGet_TimeSpan_Nullable([ValueSource(nameof(timeSpanValuesNullable))] TimeSpan? value)
		{
			TestSetGetValue<TimeSpanExposedNullable, TimeSpan?>(0, value);
		}
	}
}