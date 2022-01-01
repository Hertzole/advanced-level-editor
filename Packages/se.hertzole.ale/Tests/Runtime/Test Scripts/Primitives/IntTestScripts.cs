// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class IntField1 : MonoBehaviour, IValue<int>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int value;

		public int ValueID { get { return VALUE_0_ID; } }
		public int Value { get { return value; } set { this.value = value; } }
	}

	public class IntField2 : MonoBehaviour, IValue<int>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int value;

		public int ValueID { get { return VALUE_100_ID; } }
		public int Value { get { return value; } set { this.value = value; } }
	}

	public class IntFields1 : MonoBehaviour, IValues<int>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private int value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public int Value1 { get { return value1; } set { value1 = value; } }
		public int Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntFields2 : MonoBehaviour, IValues<int>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private int value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public int Value1 { get { return value1; } set { value1 = value; } }
		public int Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntProperty1 : MonoBehaviour, IValue<int>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int Value { get; set; }
	}

	public class IntProperty2 : MonoBehaviour, IValue<int>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public int Value { get; set; }
	}

	public class IntProperties1 : MonoBehaviour, IValues<int>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public int Value2 { get; set; }
	}

	public class IntProperties2 : MonoBehaviour, IValues<int>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public int Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public int Value2 { get; set; }
	}

	public class IntArrayField1 : MonoBehaviour, IValue<int[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public int[] Value { get { return value; } set { this.value = value; } }
	}

	public class IntArrayField2 : MonoBehaviour, IValue<int[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public int[] Value { get { return value; } set { this.value = value; } }
	}

	public class IntArrayFields1 : MonoBehaviour, IValues<int[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private int[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public int[] Value1 { get { return value1; } set { value1 = value; } }
		public int[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntArrayFields2 : MonoBehaviour, IValues<int[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private int[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public int[] Value1 { get { return value1; } set { value1 = value; } }
		public int[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntArrayProperty1 : MonoBehaviour, IValue<int[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int[] Value { get; set; }
	}

	public class IntArrayProperty2 : MonoBehaviour, IValue<int[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public int[] Value { get; set; }
	}

	public class IntArrayProperties1 : MonoBehaviour, IValues<int[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public int[] Value2 { get; set; }
	}

	public class IntArrayProperties2 : MonoBehaviour, IValues<int[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public int[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public int[] Value2 { get; set; }
	}

	public class IntListField1 : MonoBehaviour, IValue<List<int>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<int> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<int> Value { get { return value; } set { this.value = value; } }
	}

	public class IntListField2 : MonoBehaviour, IValue<List<int>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<int> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<int> Value { get { return value; } set { this.value = value; } }
	}

	public class IntListFields1 : MonoBehaviour, IValues<List<int>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<int> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<int> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<int> Value1 { get { return value1; } set { value1 = value; } }
		public List<int> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntListFields2 : MonoBehaviour, IValues<List<int>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<int> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<int> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<int> Value1 { get { return value1; } set { value1 = value; } }
		public List<int> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntListProperty1 : MonoBehaviour, IValue<List<int>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<int> Value { get; set; }
	}

	public class IntListProperty2 : MonoBehaviour, IValue<List<int>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<int> Value { get; set; }
	}

	public class IntListProperties1 : MonoBehaviour, IValues<List<int>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<int> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<int> Value2 { get; set; }
	}

	public class IntListProperties2 : MonoBehaviour, IValues<List<int>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<int> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<int> Value2 { get; set; }
	}

	public class IntNullableField1 : MonoBehaviour, IValue<int?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public int? Value { get { return value; } set { this.value = value; } }
	}

	public class IntNullableField2 : MonoBehaviour, IValue<int?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public int? Value { get { return value; } set { this.value = value; } }
	}

	public class IntNullableFields1 : MonoBehaviour, IValues<int?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private int? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public int? Value1 { get { return value1; } set { value1 = value; } }
		public int? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntNullableFields2 : MonoBehaviour, IValues<int?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private int? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public int? Value1 { get { return value1; } set { value1 = value; } }
		public int? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntNullableProperty1 : MonoBehaviour, IValue<int?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int? Value { get; set; }
	}

	public class IntNullableProperty2 : MonoBehaviour, IValue<int?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public int? Value { get; set; }
	}

	public class IntNullableProperties1 : MonoBehaviour, IValues<int?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public int? Value2 { get; set; }
	}

	public class IntNullableProperties2 : MonoBehaviour, IValues<int?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public int? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public int? Value2 { get; set; }
	}

	public class IntArrayNullableField1 : MonoBehaviour, IValue<int?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public int?[] Value { get { return value; } set { this.value = value; } }
	}

	public class IntArrayNullableField2 : MonoBehaviour, IValue<int?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public int?[] Value { get { return value; } set { this.value = value; } }
	}

	public class IntArrayNullableFields1 : MonoBehaviour, IValues<int?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private int?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private int?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public int?[] Value1 { get { return value1; } set { value1 = value; } }
		public int?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntArrayNullableFields2 : MonoBehaviour, IValues<int?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private int?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private int?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public int?[] Value1 { get { return value1; } set { value1 = value; } }
		public int?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntArrayNullableProperty1 : MonoBehaviour, IValue<int?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int?[] Value { get; set; }
	}

	public class IntArrayNullableProperty2 : MonoBehaviour, IValue<int?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public int?[] Value { get; set; }
	}

	public class IntArrayNullableProperties1 : MonoBehaviour, IValues<int?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public int?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public int?[] Value2 { get; set; }
	}

	public class IntArrayNullableProperties2 : MonoBehaviour, IValues<int?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public int?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public int?[] Value2 { get; set; }
	}

	public class IntListNullableField1 : MonoBehaviour, IValue<List<int?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<int?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<int?> Value { get { return value; } set { this.value = value; } }
	}

	public class IntListNullableField2 : MonoBehaviour, IValue<List<int?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<int?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<int?> Value { get { return value; } set { this.value = value; } }
	}

	public class IntListNullableFields1 : MonoBehaviour, IValues<List<int?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<int?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<int?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<int?> Value1 { get { return value1; } set { value1 = value; } }
		public List<int?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntListNullableFields2 : MonoBehaviour, IValues<List<int?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<int?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<int?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<int?> Value1 { get { return value1; } set { value1 = value; } }
		public List<int?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class IntListNullableProperty1 : MonoBehaviour, IValue<List<int?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<int?> Value { get; set; }
	}

	public class IntListNullableProperty2 : MonoBehaviour, IValue<List<int?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<int?> Value { get; set; }
	}

	public class IntListNullableProperties1 : MonoBehaviour, IValues<List<int?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<int?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<int?> Value2 { get; set; }
	}

	public class IntListNullableProperties2 : MonoBehaviour, IValues<List<int?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<int?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<int?> Value2 { get; set; }
	}
}