using System;

namespace Hertzole.ALE.Tests
{
	public partial class BaseTest
	{
		protected static readonly bool[] boolValues = { true, false };
		protected static readonly byte[] byteValues =
		{
			byte.MinValue,
			byte.MaxValue,
			1,
			10,
			20,
			42,
			69,
			100,
			200,
			254
		};
		protected static readonly sbyte[] sbyteValues =
		{
			sbyte.MinValue,
			sbyte.MaxValue,
			1,
			-1,
			10,
			-10,
			20,
			-20,
			42,
			-42,
			69,
			-69,
			100,
			-100
		};
		protected static readonly short[] shortValues =
		{
			short.MinValue,
			short.MaxValue,
			0,
			1,
			-1,
			10,
			-10,
			20,
			-20,
			42,
			-42,
			69,
			-69,
			100,
			-100,
			1000,
			-1000,
			10000,
			-10000
		};
		protected static readonly ushort[] ushortValues =
		{
			ushort.MinValue,
			ushort.MaxValue,
			1,
			10,
			20,
			42,
			69,
			100,
			1000,
			10000
		};

		protected static readonly int[] intValues =
		{
			int.MinValue,
			int.MaxValue,
			0,
			1,
			-1,
			10,
			-10,
			20,
			-20,
			42,
			-42,
			69,
			-69,
			100,
			-100,
			1000,
			-1000,
			10000,
			-10000,
			10_000_000,
			-10_000_000,
			100_000_000,
			-100_000_000,
			1_000_000_000,
			-1_000_000_000
		};
		protected static readonly uint[] uintValues =
		{
			uint.MinValue,
			uint.MaxValue,
			1,
			10,
			20,
			42,
			69,
			100,
			1000,
			10000,
			10_000_000,
			100_000_000,
			1_000_000_000
		};

		protected static readonly long[] longValues =
		{
			long.MinValue,
			long.MaxValue,
			0,
			1,
			-1,
			10,
			-10,
			20,
			-20,
			42,
			-42,
			69,
			-69,
			100,
			-100,
			1000,
			-1000,
			10000,
			-10000,
			10_000_000,
			-10_000_000,
			100_000_000,
			-100_000_000,
			1_000_000_000,
			-1_000_000_000,
			10_000_000_000,
			-10_000_000_000,
			100_000_000_000,
			-100_000_000_000
		};
		protected static readonly ulong[] ulongValues =
		{
			ulong.MinValue,
			ulong.MaxValue,
			1,
			10,
			20,
			42,
			69,
			100,
			1000,
			10000,
			10_000_000,
			100_000_000,
			1_000_000_000,
			10_000_000_000,
			100_000_000_000,
			1_000_000_000_000,
			10_000_000_000_000,
			100_000_000_000_000,
			1_000_000_000_000_000
		};
		protected static readonly float[] floatValues =
		{
			float.MinValue,
			float.MaxValue,
			0,
			1.1f,
			-1.1f,
			10.1f,
			-10.1f,
			20.1f,
			-20.1f,
			42.1f,
			-42.1f,
			69.42f,
			-69.42f,
			100.69f,
			-100.69f,
			1000.100f,
			-1000.100f
		};
		protected static readonly decimal[] decimalValues =
		{
			decimal.MinValue,
			decimal.MaxValue,
			0,
			1.1m,
			-1.1m,
			10.1m,
			-10.1m,
			20.1m,
			-20.1m,
			42.1m,
			-42.1m,
			69.42m,
			-69.42m,
			100.69m,
			-100.69m,
			1000.100m,
			-1000.100m
		};
		protected static readonly double[] doubleValues =
		{
			double.MinValue,
			double.MaxValue,
			0,
			1.1,
			-1.1,
			10.1,
			-10.1,
			20.1,
			-20.1,
			42.1,
			-42.1,
			69.42,
			-69.42,
			100.69,
			-100.69,
			1000.100,
			-1000.100
		};

		protected static readonly string[] stringValues =
		{
			string.Empty,
			"Velit elitr nibh lorem at eu ipsum",
			null
		};

		protected static readonly char[] charValues =
		{
			char.MinValue,
			char.MaxValue,
			'a',
			'b',
			'c',
			'1',
			'2',
			'3'
		};

		protected static readonly Guid[] guidValues =
		{
			Guid.Empty,
			Guid.Parse("788bfb5e-edcc-4311-aef3-44ee0b78a4b5")
		};

		protected static readonly DateTime[] dateTimeValues =
		{
			DateTime.MinValue,
			DateTime.MaxValue,
			DateTime.Now
		};

		protected static readonly TimeSpan[] timeSpanValues =
		{
			TimeSpan.MinValue,
			TimeSpan.MaxValue,
			TimeSpan.Zero
		};

		protected static readonly Uri[] uriValues =
		{
			new Uri("http://www.google.com"),
			new Uri("http://www.microsoft.com"),
			new Uri("https://www.hertzole.se"),
			null
		};

		protected static readonly bool?[] boolValuesNullable = { null, true, false };
		protected static readonly byte?[] byteValuesNullable = { null, byte.MinValue, byte.MaxValue };
		protected static readonly sbyte?[] sbyteValuesNullable = { null, sbyte.MinValue, sbyte.MaxValue };
		protected static readonly short?[] shortValuesNullable = { null, short.MinValue, short.MaxValue };
		protected static readonly ushort?[] ushortValuesNullable = { null, ushort.MinValue, ushort.MaxValue };
		protected static readonly int?[] intValuesNullable = { null, int.MinValue, int.MaxValue };
		protected static readonly uint?[] uintValuesNullable = { null, uint.MinValue, uint.MaxValue };
		protected static readonly long?[] longValuesNullable = { null, long.MinValue, long.MaxValue };
		protected static readonly ulong?[] ulongValuesNullable = { null, ulong.MinValue, ulong.MaxValue };
		protected static readonly float?[] floatValuesNullable = { null, float.MinValue, float.MaxValue };
		protected static readonly decimal?[] decimalValuesNullable = { null, decimal.MinValue, decimal.MaxValue };
		protected static readonly double?[] doubleValuesNullable = { null, double.MinValue, double.MaxValue };
		protected static readonly char?[] charValuesNullable = { null, char.MinValue, char.MaxValue };
		protected static readonly Guid?[] guidValuesNullable = { null, Guid.Empty, Guid.Parse("788bfb5e-edcc-4311-aef3-44ee0b78a4b5") };
		protected static readonly DateTime?[] dateTimeValuesNullable = { null, DateTime.MinValue, DateTime.MaxValue };
		protected static readonly TimeSpan?[] timeSpanValuesNullable = { null, TimeSpan.MinValue, TimeSpan.MaxValue };
	}
}