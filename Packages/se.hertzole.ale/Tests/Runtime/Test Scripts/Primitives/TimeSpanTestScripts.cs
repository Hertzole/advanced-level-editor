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
	public class TimeSpanField1 : MonoBehaviour, IValue<TimeSpan>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan value;

		public int ValueID { get { return VALUE_0_ID; } }
		public TimeSpan Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanField2 : MonoBehaviour, IValue<TimeSpan>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan value;

		public int ValueID { get { return VALUE_100_ID; } }
		public TimeSpan Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanFields1 : MonoBehaviour, IValues<TimeSpan>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private TimeSpan value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public TimeSpan Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanFields2 : MonoBehaviour, IValues<TimeSpan>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private TimeSpan value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public TimeSpan Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanProperty1 : MonoBehaviour, IValue<TimeSpan>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan Value { get; set; }
	}

	public class TimeSpanProperty2 : MonoBehaviour, IValue<TimeSpan>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan Value { get; set; }
	}

	public class TimeSpanProperties1 : MonoBehaviour, IValues<TimeSpan>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public TimeSpan Value2 { get; set; }
	}

	public class TimeSpanProperties2 : MonoBehaviour, IValues<TimeSpan>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public TimeSpan Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan Value2 { get; set; }
	}

	public class TimeSpanArrayField1 : MonoBehaviour, IValue<TimeSpan[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public TimeSpan[] Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanArrayField2 : MonoBehaviour, IValue<TimeSpan[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public TimeSpan[] Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanArrayFields1 : MonoBehaviour, IValues<TimeSpan[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private TimeSpan[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public TimeSpan[] Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanArrayFields2 : MonoBehaviour, IValues<TimeSpan[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private TimeSpan[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public TimeSpan[] Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanArrayProperty1 : MonoBehaviour, IValue<TimeSpan[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan[] Value { get; set; }
	}

	public class TimeSpanArrayProperty2 : MonoBehaviour, IValue<TimeSpan[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan[] Value { get; set; }
	}

	public class TimeSpanArrayProperties1 : MonoBehaviour, IValues<TimeSpan[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public TimeSpan[] Value2 { get; set; }
	}

	public class TimeSpanArrayProperties2 : MonoBehaviour, IValues<TimeSpan[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public TimeSpan[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan[] Value2 { get; set; }
	}

	public class TimeSpanListField1 : MonoBehaviour, IValue<List<TimeSpan>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<TimeSpan> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<TimeSpan> Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanListField2 : MonoBehaviour, IValue<List<TimeSpan>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<TimeSpan> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<TimeSpan> Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanListFields1 : MonoBehaviour, IValues<List<TimeSpan>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<TimeSpan> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<TimeSpan> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<TimeSpan> Value1 { get { return value1; } set { value1 = value; } }
		public List<TimeSpan> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanListFields2 : MonoBehaviour, IValues<List<TimeSpan>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<TimeSpan> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<TimeSpan> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<TimeSpan> Value1 { get { return value1; } set { value1 = value; } }
		public List<TimeSpan> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanListProperty1 : MonoBehaviour, IValue<List<TimeSpan>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<TimeSpan> Value { get; set; }
	}

	public class TimeSpanListProperty2 : MonoBehaviour, IValue<List<TimeSpan>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<TimeSpan> Value { get; set; }
	}

	public class TimeSpanListProperties1 : MonoBehaviour, IValues<List<TimeSpan>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<TimeSpan> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<TimeSpan> Value2 { get; set; }
	}

	public class TimeSpanListProperties2 : MonoBehaviour, IValues<List<TimeSpan>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<TimeSpan> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<TimeSpan> Value2 { get; set; }
	}

	public class TimeSpanNullableField1 : MonoBehaviour, IValue<TimeSpan?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public TimeSpan? Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanNullableField2 : MonoBehaviour, IValue<TimeSpan?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public TimeSpan? Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanNullableFields1 : MonoBehaviour, IValues<TimeSpan?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private TimeSpan? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public TimeSpan? Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanNullableFields2 : MonoBehaviour, IValues<TimeSpan?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private TimeSpan? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public TimeSpan? Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanNullableProperty1 : MonoBehaviour, IValue<TimeSpan?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan? Value { get; set; }
	}

	public class TimeSpanNullableProperty2 : MonoBehaviour, IValue<TimeSpan?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan? Value { get; set; }
	}

	public class TimeSpanNullableProperties1 : MonoBehaviour, IValues<TimeSpan?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public TimeSpan? Value2 { get; set; }
	}

	public class TimeSpanNullableProperties2 : MonoBehaviour, IValues<TimeSpan?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public TimeSpan? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan? Value2 { get; set; }
	}

	public class TimeSpanArrayNullableField1 : MonoBehaviour, IValue<TimeSpan?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public TimeSpan?[] Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanArrayNullableField2 : MonoBehaviour, IValue<TimeSpan?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public TimeSpan?[] Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanArrayNullableFields1 : MonoBehaviour, IValues<TimeSpan?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private TimeSpan?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private TimeSpan?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public TimeSpan?[] Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanArrayNullableFields2 : MonoBehaviour, IValues<TimeSpan?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private TimeSpan?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private TimeSpan?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public TimeSpan?[] Value1 { get { return value1; } set { value1 = value; } }
		public TimeSpan?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanArrayNullableProperty1 : MonoBehaviour, IValue<TimeSpan?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan?[] Value { get; set; }
	}

	public class TimeSpanArrayNullableProperty2 : MonoBehaviour, IValue<TimeSpan?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan?[] Value { get; set; }
	}

	public class TimeSpanArrayNullableProperties1 : MonoBehaviour, IValues<TimeSpan?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public TimeSpan?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public TimeSpan?[] Value2 { get; set; }
	}

	public class TimeSpanArrayNullableProperties2 : MonoBehaviour, IValues<TimeSpan?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public TimeSpan?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public TimeSpan?[] Value2 { get; set; }
	}

	public class TimeSpanListNullableField1 : MonoBehaviour, IValue<List<TimeSpan?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<TimeSpan?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<TimeSpan?> Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanListNullableField2 : MonoBehaviour, IValue<List<TimeSpan?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<TimeSpan?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<TimeSpan?> Value { get { return value; } set { this.value = value; } }
	}

	public class TimeSpanListNullableFields1 : MonoBehaviour, IValues<List<TimeSpan?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<TimeSpan?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<TimeSpan?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<TimeSpan?> Value1 { get { return value1; } set { value1 = value; } }
		public List<TimeSpan?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanListNullableFields2 : MonoBehaviour, IValues<List<TimeSpan?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<TimeSpan?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<TimeSpan?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<TimeSpan?> Value1 { get { return value1; } set { value1 = value; } }
		public List<TimeSpan?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TimeSpanListNullableProperty1 : MonoBehaviour, IValue<List<TimeSpan?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<TimeSpan?> Value { get; set; }
	}

	public class TimeSpanListNullableProperty2 : MonoBehaviour, IValue<List<TimeSpan?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<TimeSpan?> Value { get; set; }
	}

	public class TimeSpanListNullableProperties1 : MonoBehaviour, IValues<List<TimeSpan?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<TimeSpan?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<TimeSpan?> Value2 { get; set; }
	}

	public class TimeSpanListNullableProperties2 : MonoBehaviour, IValues<List<TimeSpan?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<TimeSpan?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<TimeSpan?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618