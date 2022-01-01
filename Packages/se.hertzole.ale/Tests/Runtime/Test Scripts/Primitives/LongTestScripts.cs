// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class LongField1 : MonoBehaviour, IValue<long>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long value;

		public int ValueID { get { return VALUE_0_ID; } }
		public long Value { get { return value; } set { this.value = value; } }
	}

	public class LongField2 : MonoBehaviour, IValue<long>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long value;

		public int ValueID { get { return VALUE_100_ID; } }
		public long Value { get { return value; } set { this.value = value; } }
	}

	public class LongFields1 : MonoBehaviour, IValues<long>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private long value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public long Value1 { get { return value1; } set { value1 = value; } }
		public long Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongFields2 : MonoBehaviour, IValues<long>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private long value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public long Value1 { get { return value1; } set { value1 = value; } }
		public long Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongProperty1 : MonoBehaviour, IValue<long>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long Value { get; set; }
	}

	public class LongProperty2 : MonoBehaviour, IValue<long>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public long Value { get; set; }
	}

	public class LongProperties1 : MonoBehaviour, IValues<long>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public long Value2 { get; set; }
	}

	public class LongProperties2 : MonoBehaviour, IValues<long>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public long Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public long Value2 { get; set; }
	}

	public class LongArrayField1 : MonoBehaviour, IValue<long[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public long[] Value { get { return value; } set { this.value = value; } }
	}

	public class LongArrayField2 : MonoBehaviour, IValue<long[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public long[] Value { get { return value; } set { this.value = value; } }
	}

	public class LongArrayFields1 : MonoBehaviour, IValues<long[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private long[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public long[] Value1 { get { return value1; } set { value1 = value; } }
		public long[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongArrayFields2 : MonoBehaviour, IValues<long[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private long[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public long[] Value1 { get { return value1; } set { value1 = value; } }
		public long[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongArrayProperty1 : MonoBehaviour, IValue<long[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long[] Value { get; set; }
	}

	public class LongArrayProperty2 : MonoBehaviour, IValue<long[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public long[] Value { get; set; }
	}

	public class LongArrayProperties1 : MonoBehaviour, IValues<long[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public long[] Value2 { get; set; }
	}

	public class LongArrayProperties2 : MonoBehaviour, IValues<long[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public long[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public long[] Value2 { get; set; }
	}

	public class LongListField1 : MonoBehaviour, IValue<List<long>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<long> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<long> Value { get { return value; } set { this.value = value; } }
	}

	public class LongListField2 : MonoBehaviour, IValue<List<long>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<long> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<long> Value { get { return value; } set { this.value = value; } }
	}

	public class LongListFields1 : MonoBehaviour, IValues<List<long>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<long> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<long> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<long> Value1 { get { return value1; } set { value1 = value; } }
		public List<long> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongListFields2 : MonoBehaviour, IValues<List<long>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<long> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<long> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<long> Value1 { get { return value1; } set { value1 = value; } }
		public List<long> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongListProperty1 : MonoBehaviour, IValue<List<long>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<long> Value { get; set; }
	}

	public class LongListProperty2 : MonoBehaviour, IValue<List<long>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<long> Value { get; set; }
	}

	public class LongListProperties1 : MonoBehaviour, IValues<List<long>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<long> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<long> Value2 { get; set; }
	}

	public class LongListProperties2 : MonoBehaviour, IValues<List<long>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<long> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<long> Value2 { get; set; }
	}

	public class LongNullableField1 : MonoBehaviour, IValue<long?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public long? Value { get { return value; } set { this.value = value; } }
	}

	public class LongNullableField2 : MonoBehaviour, IValue<long?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public long? Value { get { return value; } set { this.value = value; } }
	}

	public class LongNullableFields1 : MonoBehaviour, IValues<long?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private long? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public long? Value1 { get { return value1; } set { value1 = value; } }
		public long? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongNullableFields2 : MonoBehaviour, IValues<long?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private long? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public long? Value1 { get { return value1; } set { value1 = value; } }
		public long? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongNullableProperty1 : MonoBehaviour, IValue<long?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long? Value { get; set; }
	}

	public class LongNullableProperty2 : MonoBehaviour, IValue<long?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public long? Value { get; set; }
	}

	public class LongNullableProperties1 : MonoBehaviour, IValues<long?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public long? Value2 { get; set; }
	}

	public class LongNullableProperties2 : MonoBehaviour, IValues<long?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public long? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public long? Value2 { get; set; }
	}

	public class LongArrayNullableField1 : MonoBehaviour, IValue<long?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public long?[] Value { get { return value; } set { this.value = value; } }
	}

	public class LongArrayNullableField2 : MonoBehaviour, IValue<long?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public long?[] Value { get { return value; } set { this.value = value; } }
	}

	public class LongArrayNullableFields1 : MonoBehaviour, IValues<long?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private long?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private long?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public long?[] Value1 { get { return value1; } set { value1 = value; } }
		public long?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongArrayNullableFields2 : MonoBehaviour, IValues<long?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private long?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private long?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public long?[] Value1 { get { return value1; } set { value1 = value; } }
		public long?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongArrayNullableProperty1 : MonoBehaviour, IValue<long?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long?[] Value { get; set; }
	}

	public class LongArrayNullableProperty2 : MonoBehaviour, IValue<long?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public long?[] Value { get; set; }
	}

	public class LongArrayNullableProperties1 : MonoBehaviour, IValues<long?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public long?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public long?[] Value2 { get; set; }
	}

	public class LongArrayNullableProperties2 : MonoBehaviour, IValues<long?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public long?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public long?[] Value2 { get; set; }
	}

	public class LongListNullableField1 : MonoBehaviour, IValue<List<long?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<long?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<long?> Value { get { return value; } set { this.value = value; } }
	}

	public class LongListNullableField2 : MonoBehaviour, IValue<List<long?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<long?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<long?> Value { get { return value; } set { this.value = value; } }
	}

	public class LongListNullableFields1 : MonoBehaviour, IValues<List<long?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<long?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<long?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<long?> Value1 { get { return value1; } set { value1 = value; } }
		public List<long?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongListNullableFields2 : MonoBehaviour, IValues<List<long?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<long?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<long?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<long?> Value1 { get { return value1; } set { value1 = value; } }
		public List<long?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LongListNullableProperty1 : MonoBehaviour, IValue<List<long?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<long?> Value { get; set; }
	}

	public class LongListNullableProperty2 : MonoBehaviour, IValue<List<long?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<long?> Value { get; set; }
	}

	public class LongListNullableProperties1 : MonoBehaviour, IValues<List<long?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<long?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<long?> Value2 { get; set; }
	}

	public class LongListNullableProperties2 : MonoBehaviour, IValues<List<long?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<long?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<long?> Value2 { get; set; }
	}
}