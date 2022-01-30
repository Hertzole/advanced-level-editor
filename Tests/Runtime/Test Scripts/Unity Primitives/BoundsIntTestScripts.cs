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
	public class BoundsIntField1 : MonoBehaviour, IValue<BoundsInt>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt value;

		public int ValueID { get { return VALUE_0_ID; } }
		public BoundsInt Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntField2 : MonoBehaviour, IValue<BoundsInt>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt value;

		public int ValueID { get { return VALUE_100_ID; } }
		public BoundsInt Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntFields1 : MonoBehaviour, IValues<BoundsInt>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private BoundsInt value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public BoundsInt Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntFields2 : MonoBehaviour, IValues<BoundsInt>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private BoundsInt value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public BoundsInt Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntProperty1 : MonoBehaviour, IValue<BoundsInt>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt Value { get; set; }
	}

	public class BoundsIntProperty2 : MonoBehaviour, IValue<BoundsInt>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt Value { get; set; }
	}

	public class BoundsIntProperties1 : MonoBehaviour, IValues<BoundsInt>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public BoundsInt Value2 { get; set; }
	}

	public class BoundsIntProperties2 : MonoBehaviour, IValues<BoundsInt>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public BoundsInt Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt Value2 { get; set; }
	}

	public class BoundsIntArrayField1 : MonoBehaviour, IValue<BoundsInt[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public BoundsInt[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntArrayField2 : MonoBehaviour, IValue<BoundsInt[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public BoundsInt[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntArrayFields1 : MonoBehaviour, IValues<BoundsInt[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private BoundsInt[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public BoundsInt[] Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntArrayFields2 : MonoBehaviour, IValues<BoundsInt[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private BoundsInt[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public BoundsInt[] Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntArrayProperty1 : MonoBehaviour, IValue<BoundsInt[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt[] Value { get; set; }
	}

	public class BoundsIntArrayProperty2 : MonoBehaviour, IValue<BoundsInt[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt[] Value { get; set; }
	}

	public class BoundsIntArrayProperties1 : MonoBehaviour, IValues<BoundsInt[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public BoundsInt[] Value2 { get; set; }
	}

	public class BoundsIntArrayProperties2 : MonoBehaviour, IValues<BoundsInt[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public BoundsInt[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt[] Value2 { get; set; }
	}

	public class BoundsIntListField1 : MonoBehaviour, IValue<List<BoundsInt>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<BoundsInt> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<BoundsInt> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntListField2 : MonoBehaviour, IValue<List<BoundsInt>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<BoundsInt> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<BoundsInt> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntListFields1 : MonoBehaviour, IValues<List<BoundsInt>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<BoundsInt> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<BoundsInt> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<BoundsInt> Value1 { get { return value1; } set { value1 = value; } }
		public List<BoundsInt> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntListFields2 : MonoBehaviour, IValues<List<BoundsInt>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<BoundsInt> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<BoundsInt> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<BoundsInt> Value1 { get { return value1; } set { value1 = value; } }
		public List<BoundsInt> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntListProperty1 : MonoBehaviour, IValue<List<BoundsInt>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<BoundsInt> Value { get; set; }
	}

	public class BoundsIntListProperty2 : MonoBehaviour, IValue<List<BoundsInt>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<BoundsInt> Value { get; set; }
	}

	public class BoundsIntListProperties1 : MonoBehaviour, IValues<List<BoundsInt>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<BoundsInt> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<BoundsInt> Value2 { get; set; }
	}

	public class BoundsIntListProperties2 : MonoBehaviour, IValues<List<BoundsInt>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<BoundsInt> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<BoundsInt> Value2 { get; set; }
	}

	public class BoundsIntNullableField1 : MonoBehaviour, IValue<BoundsInt?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public BoundsInt? Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntNullableField2 : MonoBehaviour, IValue<BoundsInt?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public BoundsInt? Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntNullableFields1 : MonoBehaviour, IValues<BoundsInt?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private BoundsInt? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public BoundsInt? Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntNullableFields2 : MonoBehaviour, IValues<BoundsInt?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private BoundsInt? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public BoundsInt? Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntNullableProperty1 : MonoBehaviour, IValue<BoundsInt?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt? Value { get; set; }
	}

	public class BoundsIntNullableProperty2 : MonoBehaviour, IValue<BoundsInt?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt? Value { get; set; }
	}

	public class BoundsIntNullableProperties1 : MonoBehaviour, IValues<BoundsInt?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public BoundsInt? Value2 { get; set; }
	}

	public class BoundsIntNullableProperties2 : MonoBehaviour, IValues<BoundsInt?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public BoundsInt? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt? Value2 { get; set; }
	}

	public class BoundsIntArrayNullableField1 : MonoBehaviour, IValue<BoundsInt?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public BoundsInt?[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntArrayNullableField2 : MonoBehaviour, IValue<BoundsInt?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public BoundsInt?[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntArrayNullableFields1 : MonoBehaviour, IValues<BoundsInt?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private BoundsInt?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private BoundsInt?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public BoundsInt?[] Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntArrayNullableFields2 : MonoBehaviour, IValues<BoundsInt?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private BoundsInt?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private BoundsInt?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public BoundsInt?[] Value1 { get { return value1; } set { value1 = value; } }
		public BoundsInt?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntArrayNullableProperty1 : MonoBehaviour, IValue<BoundsInt?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt?[] Value { get; set; }
	}

	public class BoundsIntArrayNullableProperty2 : MonoBehaviour, IValue<BoundsInt?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt?[] Value { get; set; }
	}

	public class BoundsIntArrayNullableProperties1 : MonoBehaviour, IValues<BoundsInt?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public BoundsInt?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public BoundsInt?[] Value2 { get; set; }
	}

	public class BoundsIntArrayNullableProperties2 : MonoBehaviour, IValues<BoundsInt?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public BoundsInt?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public BoundsInt?[] Value2 { get; set; }
	}

	public class BoundsIntListNullableField1 : MonoBehaviour, IValue<List<BoundsInt?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<BoundsInt?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<BoundsInt?> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntListNullableField2 : MonoBehaviour, IValue<List<BoundsInt?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<BoundsInt?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<BoundsInt?> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsIntListNullableFields1 : MonoBehaviour, IValues<List<BoundsInt?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<BoundsInt?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<BoundsInt?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<BoundsInt?> Value1 { get { return value1; } set { value1 = value; } }
		public List<BoundsInt?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntListNullableFields2 : MonoBehaviour, IValues<List<BoundsInt?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<BoundsInt?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<BoundsInt?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<BoundsInt?> Value1 { get { return value1; } set { value1 = value; } }
		public List<BoundsInt?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsIntListNullableProperty1 : MonoBehaviour, IValue<List<BoundsInt?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<BoundsInt?> Value { get; set; }
	}

	public class BoundsIntListNullableProperty2 : MonoBehaviour, IValue<List<BoundsInt?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<BoundsInt?> Value { get; set; }
	}

	public class BoundsIntListNullableProperties1 : MonoBehaviour, IValues<List<BoundsInt?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<BoundsInt?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<BoundsInt?> Value2 { get; set; }
	}

	public class BoundsIntListNullableProperties2 : MonoBehaviour, IValues<List<BoundsInt?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<BoundsInt?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<BoundsInt?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618