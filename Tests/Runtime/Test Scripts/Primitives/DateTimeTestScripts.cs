// DO NOT MODIFY! THIS IS A GENERATED FILE!

#nullable enable

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

#pragma warning disable CS8618

namespace Hertzole.ALE.Tests.TestScripts
{
	public class DateTimeField1 : MonoBehaviour, IValue<DateTime>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime value;

		public int ValueID { get { return VALUE_0_ID; } }
		public DateTime Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeField2 : MonoBehaviour, IValue<DateTime>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime value;

		public int ValueID { get { return VALUE_100_ID; } }
		public DateTime Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeFields1 : MonoBehaviour, IValues<DateTime>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private DateTime value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public DateTime Value1 { get { return value1; } set { value1 = value; } }
		public DateTime Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeFields2 : MonoBehaviour, IValues<DateTime>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private DateTime value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public DateTime Value1 { get { return value1; } set { value1 = value; } }
		public DateTime Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeProperty1 : MonoBehaviour, IValue<DateTime>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime Value { get; set; }
	}

	public class DateTimeProperty2 : MonoBehaviour, IValue<DateTime>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime Value { get; set; }
	}

	public class DateTimeProperties1 : MonoBehaviour, IValues<DateTime>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public DateTime Value2 { get; set; }
	}

	public class DateTimeProperties2 : MonoBehaviour, IValues<DateTime>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public DateTime Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime Value2 { get; set; }
	}

	public class DateTimeArrayField1 : MonoBehaviour, IValue<DateTime[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public DateTime[] Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeArrayField2 : MonoBehaviour, IValue<DateTime[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public DateTime[] Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeArrayFields1 : MonoBehaviour, IValues<DateTime[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private DateTime[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public DateTime[] Value1 { get { return value1; } set { value1 = value; } }
		public DateTime[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeArrayFields2 : MonoBehaviour, IValues<DateTime[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private DateTime[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public DateTime[] Value1 { get { return value1; } set { value1 = value; } }
		public DateTime[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeArrayProperty1 : MonoBehaviour, IValue<DateTime[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime[] Value { get; set; }
	}

	public class DateTimeArrayProperty2 : MonoBehaviour, IValue<DateTime[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime[] Value { get; set; }
	}

	public class DateTimeArrayProperties1 : MonoBehaviour, IValues<DateTime[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public DateTime[] Value2 { get; set; }
	}

	public class DateTimeArrayProperties2 : MonoBehaviour, IValues<DateTime[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public DateTime[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime[] Value2 { get; set; }
	}

	public class DateTimeListField1 : MonoBehaviour, IValue<List<DateTime>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<DateTime> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<DateTime> Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeListField2 : MonoBehaviour, IValue<List<DateTime>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<DateTime> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<DateTime> Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeListFields1 : MonoBehaviour, IValues<List<DateTime>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<DateTime> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<DateTime> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<DateTime> Value1 { get { return value1; } set { value1 = value; } }
		public List<DateTime> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeListFields2 : MonoBehaviour, IValues<List<DateTime>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<DateTime> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<DateTime> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<DateTime> Value1 { get { return value1; } set { value1 = value; } }
		public List<DateTime> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeListProperty1 : MonoBehaviour, IValue<List<DateTime>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<DateTime> Value { get; set; }
	}

	public class DateTimeListProperty2 : MonoBehaviour, IValue<List<DateTime>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<DateTime> Value { get; set; }
	}

	public class DateTimeListProperties1 : MonoBehaviour, IValues<List<DateTime>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<DateTime> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<DateTime> Value2 { get; set; }
	}

	public class DateTimeListProperties2 : MonoBehaviour, IValues<List<DateTime>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<DateTime> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<DateTime> Value2 { get; set; }
	}

	public class DateTimeNullableField1 : MonoBehaviour, IValue<DateTime?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public DateTime? Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeNullableField2 : MonoBehaviour, IValue<DateTime?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public DateTime? Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeNullableFields1 : MonoBehaviour, IValues<DateTime?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private DateTime? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public DateTime? Value1 { get { return value1; } set { value1 = value; } }
		public DateTime? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeNullableFields2 : MonoBehaviour, IValues<DateTime?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private DateTime? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public DateTime? Value1 { get { return value1; } set { value1 = value; } }
		public DateTime? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeNullableProperty1 : MonoBehaviour, IValue<DateTime?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime? Value { get; set; }
	}

	public class DateTimeNullableProperty2 : MonoBehaviour, IValue<DateTime?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime? Value { get; set; }
	}

	public class DateTimeNullableProperties1 : MonoBehaviour, IValues<DateTime?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public DateTime? Value2 { get; set; }
	}

	public class DateTimeNullableProperties2 : MonoBehaviour, IValues<DateTime?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public DateTime? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime? Value2 { get; set; }
	}

	public class DateTimeArrayNullableField1 : MonoBehaviour, IValue<DateTime?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public DateTime?[] Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeArrayNullableField2 : MonoBehaviour, IValue<DateTime?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public DateTime?[] Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeArrayNullableFields1 : MonoBehaviour, IValues<DateTime?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private DateTime?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private DateTime?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public DateTime?[] Value1 { get { return value1; } set { value1 = value; } }
		public DateTime?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeArrayNullableFields2 : MonoBehaviour, IValues<DateTime?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private DateTime?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private DateTime?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public DateTime?[] Value1 { get { return value1; } set { value1 = value; } }
		public DateTime?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeArrayNullableProperty1 : MonoBehaviour, IValue<DateTime?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime?[] Value { get; set; }
	}

	public class DateTimeArrayNullableProperty2 : MonoBehaviour, IValue<DateTime?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime?[] Value { get; set; }
	}

	public class DateTimeArrayNullableProperties1 : MonoBehaviour, IValues<DateTime?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public DateTime?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public DateTime?[] Value2 { get; set; }
	}

	public class DateTimeArrayNullableProperties2 : MonoBehaviour, IValues<DateTime?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public DateTime?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public DateTime?[] Value2 { get; set; }
	}

	public class DateTimeListNullableField1 : MonoBehaviour, IValue<List<DateTime?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<DateTime?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<DateTime?> Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeListNullableField2 : MonoBehaviour, IValue<List<DateTime?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<DateTime?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<DateTime?> Value { get { return value; } set { this.value = value; } }
	}

	public class DateTimeListNullableFields1 : MonoBehaviour, IValues<List<DateTime?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<DateTime?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<DateTime?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<DateTime?> Value1 { get { return value1; } set { value1 = value; } }
		public List<DateTime?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeListNullableFields2 : MonoBehaviour, IValues<List<DateTime?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<DateTime?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<DateTime?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<DateTime?> Value1 { get { return value1; } set { value1 = value; } }
		public List<DateTime?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DateTimeListNullableProperty1 : MonoBehaviour, IValue<List<DateTime?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<DateTime?> Value { get; set; }
	}

	public class DateTimeListNullableProperty2 : MonoBehaviour, IValue<List<DateTime?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<DateTime?> Value { get; set; }
	}

	public class DateTimeListNullableProperties1 : MonoBehaviour, IValues<List<DateTime?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<DateTime?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<DateTime?> Value2 { get; set; }
	}

	public class DateTimeListNullableProperties2 : MonoBehaviour, IValues<List<DateTime?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<DateTime?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<DateTime?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618