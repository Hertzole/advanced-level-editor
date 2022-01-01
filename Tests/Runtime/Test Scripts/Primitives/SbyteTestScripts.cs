// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class SByteField1 : MonoBehaviour, IValue<sbyte>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte Value { get { return value; } set { this.value = value; } }
	}

	public class SByteField2 : MonoBehaviour, IValue<sbyte>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte Value { get { return value; } set { this.value = value; } }
	}

	public class SByteFields1 : MonoBehaviour, IValues<sbyte>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private sbyte value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public sbyte Value1 { get { return value1; } set { value1 = value; } }
		public sbyte Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteFields2 : MonoBehaviour, IValues<sbyte>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private sbyte value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public sbyte Value1 { get { return value1; } set { value1 = value; } }
		public sbyte Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteProperty1 : MonoBehaviour, IValue<sbyte>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte Value { get; set; }
	}

	public class SByteProperty2 : MonoBehaviour, IValue<sbyte>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte Value { get; set; }
	}

	public class SByteProperties1 : MonoBehaviour, IValues<sbyte>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte Value2 { get; set; }
	}

	public class SByteProperties2 : MonoBehaviour, IValues<sbyte>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte Value2 { get; set; }
	}

	public class SByteArrayField1 : MonoBehaviour, IValue<sbyte[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte[] Value { get { return value; } set { this.value = value; } }
	}

	public class SByteArrayField2 : MonoBehaviour, IValue<sbyte[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte[] Value { get { return value; } set { this.value = value; } }
	}

	public class SByteArrayFields1 : MonoBehaviour, IValues<sbyte[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private sbyte[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public sbyte[] Value1 { get { return value1; } set { value1 = value; } }
		public sbyte[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteArrayFields2 : MonoBehaviour, IValues<sbyte[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private sbyte[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public sbyte[] Value1 { get { return value1; } set { value1 = value; } }
		public sbyte[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteArrayProperty1 : MonoBehaviour, IValue<sbyte[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte[] Value { get; set; }
	}

	public class SByteArrayProperty2 : MonoBehaviour, IValue<sbyte[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte[] Value { get; set; }
	}

	public class SByteArrayProperties1 : MonoBehaviour, IValues<sbyte[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte[] Value2 { get; set; }
	}

	public class SByteArrayProperties2 : MonoBehaviour, IValues<sbyte[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte[] Value2 { get; set; }
	}

	public class SByteListField1 : MonoBehaviour, IValue<List<sbyte>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<sbyte> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<sbyte> Value { get { return value; } set { this.value = value; } }
	}

	public class SByteListField2 : MonoBehaviour, IValue<List<sbyte>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<sbyte> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<sbyte> Value { get { return value; } set { this.value = value; } }
	}

	public class SByteListFields1 : MonoBehaviour, IValues<List<sbyte>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<sbyte> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<sbyte> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<sbyte> Value1 { get { return value1; } set { value1 = value; } }
		public List<sbyte> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteListFields2 : MonoBehaviour, IValues<List<sbyte>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<sbyte> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<sbyte> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<sbyte> Value1 { get { return value1; } set { value1 = value; } }
		public List<sbyte> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteListProperty1 : MonoBehaviour, IValue<List<sbyte>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte> Value { get; set; }
	}

	public class SByteListProperty2 : MonoBehaviour, IValue<List<sbyte>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte> Value { get; set; }
	}

	public class SByteListProperties1 : MonoBehaviour, IValues<List<sbyte>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<sbyte> Value2 { get; set; }
	}

	public class SByteListProperties2 : MonoBehaviour, IValues<List<sbyte>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<sbyte> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte> Value2 { get; set; }
	}

	public class SByteNullableField1 : MonoBehaviour, IValue<sbyte?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte? Value { get { return value; } set { this.value = value; } }
	}

	public class SByteNullableField2 : MonoBehaviour, IValue<sbyte?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte? Value { get { return value; } set { this.value = value; } }
	}

	public class SByteNullableFields1 : MonoBehaviour, IValues<sbyte?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private sbyte? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public sbyte? Value1 { get { return value1; } set { value1 = value; } }
		public sbyte? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteNullableFields2 : MonoBehaviour, IValues<sbyte?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private sbyte? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public sbyte? Value1 { get { return value1; } set { value1 = value; } }
		public sbyte? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteNullableProperty1 : MonoBehaviour, IValue<sbyte?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte? Value { get; set; }
	}

	public class SByteNullableProperty2 : MonoBehaviour, IValue<sbyte?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte? Value { get; set; }
	}

	public class SByteNullableProperties1 : MonoBehaviour, IValues<sbyte?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte? Value2 { get; set; }
	}

	public class SByteNullableProperties2 : MonoBehaviour, IValues<sbyte?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte? Value2 { get; set; }
	}

	public class SByteArrayNullableField1 : MonoBehaviour, IValue<sbyte?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte?[] Value { get { return value; } set { this.value = value; } }
	}

	public class SByteArrayNullableField2 : MonoBehaviour, IValue<sbyte?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte?[] Value { get { return value; } set { this.value = value; } }
	}

	public class SByteArrayNullableFields1 : MonoBehaviour, IValues<sbyte?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private sbyte?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public sbyte?[] Value1 { get { return value1; } set { value1 = value; } }
		public sbyte?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteArrayNullableFields2 : MonoBehaviour, IValues<sbyte?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private sbyte?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public sbyte?[] Value1 { get { return value1; } set { value1 = value; } }
		public sbyte?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteArrayNullableProperty1 : MonoBehaviour, IValue<sbyte?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte?[] Value { get; set; }
	}

	public class SByteArrayNullableProperty2 : MonoBehaviour, IValue<sbyte?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte?[] Value { get; set; }
	}

	public class SByteArrayNullableProperties1 : MonoBehaviour, IValues<sbyte?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte?[] Value2 { get; set; }
	}

	public class SByteArrayNullableProperties2 : MonoBehaviour, IValues<sbyte?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte?[] Value2 { get; set; }
	}

	public class SByteListNullableField1 : MonoBehaviour, IValue<List<sbyte?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<sbyte?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<sbyte?> Value { get { return value; } set { this.value = value; } }
	}

	public class SByteListNullableField2 : MonoBehaviour, IValue<List<sbyte?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<sbyte?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<sbyte?> Value { get { return value; } set { this.value = value; } }
	}

	public class SByteListNullableFields1 : MonoBehaviour, IValues<List<sbyte?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<sbyte?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<sbyte?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<sbyte?> Value1 { get { return value1; } set { value1 = value; } }
		public List<sbyte?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteListNullableFields2 : MonoBehaviour, IValues<List<sbyte?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<sbyte?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<sbyte?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<sbyte?> Value1 { get { return value1; } set { value1 = value; } }
		public List<sbyte?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class SByteListNullableProperty1 : MonoBehaviour, IValue<List<sbyte?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte?> Value { get; set; }
	}

	public class SByteListNullableProperty2 : MonoBehaviour, IValue<List<sbyte?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte?> Value { get; set; }
	}

	public class SByteListNullableProperties1 : MonoBehaviour, IValues<List<sbyte?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<sbyte?> Value2 { get; set; }
	}

	public class SByteListNullableProperties2 : MonoBehaviour, IValues<List<sbyte?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<sbyte?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte?> Value2 { get; set; }
	}
}