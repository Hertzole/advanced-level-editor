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
	public class SbyteField1 : MonoBehaviour, IValue<sbyte>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteField2 : MonoBehaviour, IValue<sbyte>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteFields1 : MonoBehaviour, IValues<sbyte>
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

	public class SbyteFields2 : MonoBehaviour, IValues<sbyte>
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

	public class SbyteProperty1 : MonoBehaviour, IValue<sbyte>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte Value { get; set; }
	}

	public class SbyteProperty2 : MonoBehaviour, IValue<sbyte>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte Value { get; set; }
	}

	public class SbyteProperties1 : MonoBehaviour, IValues<sbyte>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte Value2 { get; set; }
	}

	public class SbyteProperties2 : MonoBehaviour, IValues<sbyte>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte Value2 { get; set; }
	}

	public class SbyteArrayField1 : MonoBehaviour, IValue<sbyte[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte[] Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteArrayField2 : MonoBehaviour, IValue<sbyte[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte[] Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteArrayFields1 : MonoBehaviour, IValues<sbyte[]>
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

	public class SbyteArrayFields2 : MonoBehaviour, IValues<sbyte[]>
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

	public class SbyteArrayProperty1 : MonoBehaviour, IValue<sbyte[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte[] Value { get; set; }
	}

	public class SbyteArrayProperty2 : MonoBehaviour, IValue<sbyte[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte[] Value { get; set; }
	}

	public class SbyteArrayProperties1 : MonoBehaviour, IValues<sbyte[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte[] Value2 { get; set; }
	}

	public class SbyteArrayProperties2 : MonoBehaviour, IValues<sbyte[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte[] Value2 { get; set; }
	}

	public class SbyteListField1 : MonoBehaviour, IValue<List<sbyte>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<sbyte> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<sbyte> Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteListField2 : MonoBehaviour, IValue<List<sbyte>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<sbyte> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<sbyte> Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteListFields1 : MonoBehaviour, IValues<List<sbyte>>
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

	public class SbyteListFields2 : MonoBehaviour, IValues<List<sbyte>>
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

	public class SbyteListProperty1 : MonoBehaviour, IValue<List<sbyte>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte> Value { get; set; }
	}

	public class SbyteListProperty2 : MonoBehaviour, IValue<List<sbyte>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte> Value { get; set; }
	}

	public class SbyteListProperties1 : MonoBehaviour, IValues<List<sbyte>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<sbyte> Value2 { get; set; }
	}

	public class SbyteListProperties2 : MonoBehaviour, IValues<List<sbyte>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<sbyte> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte> Value2 { get; set; }
	}

	public class SbyteNullableField1 : MonoBehaviour, IValue<sbyte?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte? Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteNullableField2 : MonoBehaviour, IValue<sbyte?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte? Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteNullableFields1 : MonoBehaviour, IValues<sbyte?>
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

	public class SbyteNullableFields2 : MonoBehaviour, IValues<sbyte?>
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

	public class SbyteNullableProperty1 : MonoBehaviour, IValue<sbyte?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte? Value { get; set; }
	}

	public class SbyteNullableProperty2 : MonoBehaviour, IValue<sbyte?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte? Value { get; set; }
	}

	public class SbyteNullableProperties1 : MonoBehaviour, IValues<sbyte?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte? Value2 { get; set; }
	}

	public class SbyteNullableProperties2 : MonoBehaviour, IValues<sbyte?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte? Value2 { get; set; }
	}

	public class SbyteArrayNullableField1 : MonoBehaviour, IValue<sbyte?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private sbyte?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public sbyte?[] Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteArrayNullableField2 : MonoBehaviour, IValue<sbyte?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private sbyte?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public sbyte?[] Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteArrayNullableFields1 : MonoBehaviour, IValues<sbyte?[]>
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

	public class SbyteArrayNullableFields2 : MonoBehaviour, IValues<sbyte?[]>
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

	public class SbyteArrayNullableProperty1 : MonoBehaviour, IValue<sbyte?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte?[] Value { get; set; }
	}

	public class SbyteArrayNullableProperty2 : MonoBehaviour, IValue<sbyte?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte?[] Value { get; set; }
	}

	public class SbyteArrayNullableProperties1 : MonoBehaviour, IValues<sbyte?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public sbyte?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public sbyte?[] Value2 { get; set; }
	}

	public class SbyteArrayNullableProperties2 : MonoBehaviour, IValues<sbyte?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public sbyte?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public sbyte?[] Value2 { get; set; }
	}

	public class SbyteListNullableField1 : MonoBehaviour, IValue<List<sbyte?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<sbyte?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<sbyte?> Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteListNullableField2 : MonoBehaviour, IValue<List<sbyte?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<sbyte?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<sbyte?> Value { get { return value; } set { this.value = value; } }
	}

	public class SbyteListNullableFields1 : MonoBehaviour, IValues<List<sbyte?>>
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

	public class SbyteListNullableFields2 : MonoBehaviour, IValues<List<sbyte?>>
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

	public class SbyteListNullableProperty1 : MonoBehaviour, IValue<List<sbyte?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte?> Value { get; set; }
	}

	public class SbyteListNullableProperty2 : MonoBehaviour, IValue<List<sbyte?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte?> Value { get; set; }
	}

	public class SbyteListNullableProperties1 : MonoBehaviour, IValues<List<sbyte?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<sbyte?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<sbyte?> Value2 { get; set; }
	}

	public class SbyteListNullableProperties2 : MonoBehaviour, IValues<List<sbyte?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<sbyte?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<sbyte?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618