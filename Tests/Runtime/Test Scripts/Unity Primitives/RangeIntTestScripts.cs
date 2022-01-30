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
	public class RangeIntField1 : MonoBehaviour, IValue<RangeInt>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RangeInt Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntField2 : MonoBehaviour, IValue<RangeInt>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RangeInt Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntFields1 : MonoBehaviour, IValues<RangeInt>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RangeInt value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RangeInt Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntFields2 : MonoBehaviour, IValues<RangeInt>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RangeInt value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RangeInt Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntProperty1 : MonoBehaviour, IValue<RangeInt>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt Value { get; set; }
	}

	public class RangeIntProperty2 : MonoBehaviour, IValue<RangeInt>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt Value { get; set; }
	}

	public class RangeIntProperties1 : MonoBehaviour, IValues<RangeInt>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RangeInt Value2 { get; set; }
	}

	public class RangeIntProperties2 : MonoBehaviour, IValues<RangeInt>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RangeInt Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt Value2 { get; set; }
	}

	public class RangeIntArrayField1 : MonoBehaviour, IValue<RangeInt[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RangeInt[] Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntArrayField2 : MonoBehaviour, IValue<RangeInt[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RangeInt[] Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntArrayFields1 : MonoBehaviour, IValues<RangeInt[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RangeInt[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RangeInt[] Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntArrayFields2 : MonoBehaviour, IValues<RangeInt[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RangeInt[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RangeInt[] Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntArrayProperty1 : MonoBehaviour, IValue<RangeInt[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt[] Value { get; set; }
	}

	public class RangeIntArrayProperty2 : MonoBehaviour, IValue<RangeInt[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt[] Value { get; set; }
	}

	public class RangeIntArrayProperties1 : MonoBehaviour, IValues<RangeInt[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RangeInt[] Value2 { get; set; }
	}

	public class RangeIntArrayProperties2 : MonoBehaviour, IValues<RangeInt[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RangeInt[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt[] Value2 { get; set; }
	}

	public class RangeIntListField1 : MonoBehaviour, IValue<List<RangeInt>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RangeInt> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<RangeInt> Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntListField2 : MonoBehaviour, IValue<List<RangeInt>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RangeInt> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<RangeInt> Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntListFields1 : MonoBehaviour, IValues<List<RangeInt>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RangeInt> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<RangeInt> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<RangeInt> Value1 { get { return value1; } set { value1 = value; } }
		public List<RangeInt> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntListFields2 : MonoBehaviour, IValues<List<RangeInt>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<RangeInt> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RangeInt> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<RangeInt> Value1 { get { return value1; } set { value1 = value; } }
		public List<RangeInt> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntListProperty1 : MonoBehaviour, IValue<List<RangeInt>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RangeInt> Value { get; set; }
	}

	public class RangeIntListProperty2 : MonoBehaviour, IValue<List<RangeInt>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RangeInt> Value { get; set; }
	}

	public class RangeIntListProperties1 : MonoBehaviour, IValues<List<RangeInt>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RangeInt> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<RangeInt> Value2 { get; set; }
	}

	public class RangeIntListProperties2 : MonoBehaviour, IValues<List<RangeInt>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<RangeInt> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RangeInt> Value2 { get; set; }
	}

	public class RangeIntNullableField1 : MonoBehaviour, IValue<RangeInt?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RangeInt? Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntNullableField2 : MonoBehaviour, IValue<RangeInt?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RangeInt? Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntNullableFields1 : MonoBehaviour, IValues<RangeInt?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RangeInt? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RangeInt? Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntNullableFields2 : MonoBehaviour, IValues<RangeInt?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RangeInt? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RangeInt? Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntNullableProperty1 : MonoBehaviour, IValue<RangeInt?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt? Value { get; set; }
	}

	public class RangeIntNullableProperty2 : MonoBehaviour, IValue<RangeInt?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt? Value { get; set; }
	}

	public class RangeIntNullableProperties1 : MonoBehaviour, IValues<RangeInt?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RangeInt? Value2 { get; set; }
	}

	public class RangeIntNullableProperties2 : MonoBehaviour, IValues<RangeInt?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RangeInt? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt? Value2 { get; set; }
	}

	public class RangeIntArrayNullableField1 : MonoBehaviour, IValue<RangeInt?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RangeInt?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntArrayNullableField2 : MonoBehaviour, IValue<RangeInt?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RangeInt?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntArrayNullableFields1 : MonoBehaviour, IValues<RangeInt?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RangeInt?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RangeInt?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RangeInt?[] Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntArrayNullableFields2 : MonoBehaviour, IValues<RangeInt?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RangeInt?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RangeInt?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RangeInt?[] Value1 { get { return value1; } set { value1 = value; } }
		public RangeInt?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntArrayNullableProperty1 : MonoBehaviour, IValue<RangeInt?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt?[] Value { get; set; }
	}

	public class RangeIntArrayNullableProperty2 : MonoBehaviour, IValue<RangeInt?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt?[] Value { get; set; }
	}

	public class RangeIntArrayNullableProperties1 : MonoBehaviour, IValues<RangeInt?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RangeInt?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RangeInt?[] Value2 { get; set; }
	}

	public class RangeIntArrayNullableProperties2 : MonoBehaviour, IValues<RangeInt?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RangeInt?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RangeInt?[] Value2 { get; set; }
	}

	public class RangeIntListNullableField1 : MonoBehaviour, IValue<List<RangeInt?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RangeInt?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<RangeInt?> Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntListNullableField2 : MonoBehaviour, IValue<List<RangeInt?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RangeInt?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<RangeInt?> Value { get { return value; } set { this.value = value; } }
	}

	public class RangeIntListNullableFields1 : MonoBehaviour, IValues<List<RangeInt?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RangeInt?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<RangeInt?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<RangeInt?> Value1 { get { return value1; } set { value1 = value; } }
		public List<RangeInt?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntListNullableFields2 : MonoBehaviour, IValues<List<RangeInt?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<RangeInt?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RangeInt?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<RangeInt?> Value1 { get { return value1; } set { value1 = value; } }
		public List<RangeInt?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RangeIntListNullableProperty1 : MonoBehaviour, IValue<List<RangeInt?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RangeInt?> Value { get; set; }
	}

	public class RangeIntListNullableProperty2 : MonoBehaviour, IValue<List<RangeInt?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RangeInt?> Value { get; set; }
	}

	public class RangeIntListNullableProperties1 : MonoBehaviour, IValues<List<RangeInt?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RangeInt?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<RangeInt?> Value2 { get; set; }
	}

	public class RangeIntListNullableProperties2 : MonoBehaviour, IValues<List<RangeInt?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<RangeInt?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RangeInt?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618