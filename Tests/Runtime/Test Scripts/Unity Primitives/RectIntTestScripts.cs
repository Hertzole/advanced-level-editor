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
	public class RectIntField1 : MonoBehaviour, IValue<RectInt>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectInt Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntField2 : MonoBehaviour, IValue<RectInt>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectInt Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntFields1 : MonoBehaviour, IValues<RectInt>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectInt value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectInt Value1 { get { return value1; } set { value1 = value; } }
		public RectInt Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntFields2 : MonoBehaviour, IValues<RectInt>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectInt value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectInt Value1 { get { return value1; } set { value1 = value; } }
		public RectInt Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntProperty1 : MonoBehaviour, IValue<RectInt>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt Value { get; set; }
	}

	public class RectIntProperty2 : MonoBehaviour, IValue<RectInt>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt Value { get; set; }
	}

	public class RectIntProperties1 : MonoBehaviour, IValues<RectInt>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectInt Value2 { get; set; }
	}

	public class RectIntProperties2 : MonoBehaviour, IValues<RectInt>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectInt Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt Value2 { get; set; }
	}

	public class RectIntArrayField1 : MonoBehaviour, IValue<RectInt[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectInt[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntArrayField2 : MonoBehaviour, IValue<RectInt[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectInt[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntArrayFields1 : MonoBehaviour, IValues<RectInt[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectInt[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectInt[] Value1 { get { return value1; } set { value1 = value; } }
		public RectInt[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntArrayFields2 : MonoBehaviour, IValues<RectInt[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectInt[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectInt[] Value1 { get { return value1; } set { value1 = value; } }
		public RectInt[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntArrayProperty1 : MonoBehaviour, IValue<RectInt[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt[] Value { get; set; }
	}

	public class RectIntArrayProperty2 : MonoBehaviour, IValue<RectInt[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt[] Value { get; set; }
	}

	public class RectIntArrayProperties1 : MonoBehaviour, IValues<RectInt[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectInt[] Value2 { get; set; }
	}

	public class RectIntArrayProperties2 : MonoBehaviour, IValues<RectInt[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectInt[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt[] Value2 { get; set; }
	}

	public class RectIntListField1 : MonoBehaviour, IValue<List<RectInt>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectInt> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<RectInt> Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntListField2 : MonoBehaviour, IValue<List<RectInt>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectInt> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<RectInt> Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntListFields1 : MonoBehaviour, IValues<List<RectInt>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectInt> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<RectInt> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<RectInt> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectInt> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntListFields2 : MonoBehaviour, IValues<List<RectInt>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<RectInt> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectInt> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<RectInt> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectInt> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntListProperty1 : MonoBehaviour, IValue<List<RectInt>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectInt> Value { get; set; }
	}

	public class RectIntListProperty2 : MonoBehaviour, IValue<List<RectInt>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectInt> Value { get; set; }
	}

	public class RectIntListProperties1 : MonoBehaviour, IValues<List<RectInt>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectInt> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<RectInt> Value2 { get; set; }
	}

	public class RectIntListProperties2 : MonoBehaviour, IValues<List<RectInt>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<RectInt> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectInt> Value2 { get; set; }
	}

	public class RectIntNullableField1 : MonoBehaviour, IValue<RectInt?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectInt? Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntNullableField2 : MonoBehaviour, IValue<RectInt?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectInt? Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntNullableFields1 : MonoBehaviour, IValues<RectInt?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectInt? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectInt? Value1 { get { return value1; } set { value1 = value; } }
		public RectInt? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntNullableFields2 : MonoBehaviour, IValues<RectInt?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectInt? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectInt? Value1 { get { return value1; } set { value1 = value; } }
		public RectInt? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntNullableProperty1 : MonoBehaviour, IValue<RectInt?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt? Value { get; set; }
	}

	public class RectIntNullableProperty2 : MonoBehaviour, IValue<RectInt?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt? Value { get; set; }
	}

	public class RectIntNullableProperties1 : MonoBehaviour, IValues<RectInt?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectInt? Value2 { get; set; }
	}

	public class RectIntNullableProperties2 : MonoBehaviour, IValues<RectInt?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectInt? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt? Value2 { get; set; }
	}

	public class RectIntArrayNullableField1 : MonoBehaviour, IValue<RectInt?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectInt?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntArrayNullableField2 : MonoBehaviour, IValue<RectInt?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectInt?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntArrayNullableFields1 : MonoBehaviour, IValues<RectInt?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectInt?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectInt?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectInt?[] Value1 { get { return value1; } set { value1 = value; } }
		public RectInt?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntArrayNullableFields2 : MonoBehaviour, IValues<RectInt?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectInt?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectInt?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectInt?[] Value1 { get { return value1; } set { value1 = value; } }
		public RectInt?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntArrayNullableProperty1 : MonoBehaviour, IValue<RectInt?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt?[] Value { get; set; }
	}

	public class RectIntArrayNullableProperty2 : MonoBehaviour, IValue<RectInt?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt?[] Value { get; set; }
	}

	public class RectIntArrayNullableProperties1 : MonoBehaviour, IValues<RectInt?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectInt?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectInt?[] Value2 { get; set; }
	}

	public class RectIntArrayNullableProperties2 : MonoBehaviour, IValues<RectInt?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectInt?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectInt?[] Value2 { get; set; }
	}

	public class RectIntListNullableField1 : MonoBehaviour, IValue<List<RectInt?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectInt?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<RectInt?> Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntListNullableField2 : MonoBehaviour, IValue<List<RectInt?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectInt?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<RectInt?> Value { get { return value; } set { this.value = value; } }
	}

	public class RectIntListNullableFields1 : MonoBehaviour, IValues<List<RectInt?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectInt?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<RectInt?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<RectInt?> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectInt?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntListNullableFields2 : MonoBehaviour, IValues<List<RectInt?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<RectInt?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectInt?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<RectInt?> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectInt?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectIntListNullableProperty1 : MonoBehaviour, IValue<List<RectInt?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectInt?> Value { get; set; }
	}

	public class RectIntListNullableProperty2 : MonoBehaviour, IValue<List<RectInt?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectInt?> Value { get; set; }
	}

	public class RectIntListNullableProperties1 : MonoBehaviour, IValues<List<RectInt?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectInt?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<RectInt?> Value2 { get; set; }
	}

	public class RectIntListNullableProperties2 : MonoBehaviour, IValues<List<RectInt?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<RectInt?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectInt?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618