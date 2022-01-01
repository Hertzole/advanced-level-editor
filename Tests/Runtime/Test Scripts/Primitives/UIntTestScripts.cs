// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class UIntField1 : MonoBehaviour, IValue<uint>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint Value { get { return value; } set { this.value = value; } }
	}

	public class UIntField2 : MonoBehaviour, IValue<uint>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint Value { get { return value; } set { this.value = value; } }
	}

	public class UIntFields1 : MonoBehaviour, IValues<uint>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private uint value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public uint Value1 { get { return value1; } set { value1 = value; } }
		public uint Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntFields2 : MonoBehaviour, IValues<uint>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private uint value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public uint Value1 { get { return value1; } set { value1 = value; } }
		public uint Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntProperty1 : MonoBehaviour, IValue<uint>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint Value { get; set; }
	}

	public class UIntProperty2 : MonoBehaviour, IValue<uint>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint Value { get; set; }
	}

	public class UIntProperties1 : MonoBehaviour, IValues<uint>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint Value2 { get; set; }
	}

	public class UIntProperties2 : MonoBehaviour, IValues<uint>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint Value2 { get; set; }
	}

	public class UIntArrayField1 : MonoBehaviour, IValue<uint[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint[] Value { get { return value; } set { this.value = value; } }
	}

	public class UIntArrayField2 : MonoBehaviour, IValue<uint[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint[] Value { get { return value; } set { this.value = value; } }
	}

	public class UIntArrayFields1 : MonoBehaviour, IValues<uint[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private uint[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public uint[] Value1 { get { return value1; } set { value1 = value; } }
		public uint[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntArrayFields2 : MonoBehaviour, IValues<uint[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private uint[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public uint[] Value1 { get { return value1; } set { value1 = value; } }
		public uint[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntArrayProperty1 : MonoBehaviour, IValue<uint[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint[] Value { get; set; }
	}

	public class UIntArrayProperty2 : MonoBehaviour, IValue<uint[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint[] Value { get; set; }
	}

	public class UIntArrayProperties1 : MonoBehaviour, IValues<uint[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint[] Value2 { get; set; }
	}

	public class UIntArrayProperties2 : MonoBehaviour, IValues<uint[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint[] Value2 { get; set; }
	}

	public class UIntListField1 : MonoBehaviour, IValue<List<uint>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<uint> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<uint> Value { get { return value; } set { this.value = value; } }
	}

	public class UIntListField2 : MonoBehaviour, IValue<List<uint>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<uint> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<uint> Value { get { return value; } set { this.value = value; } }
	}

	public class UIntListFields1 : MonoBehaviour, IValues<List<uint>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<uint> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<uint> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<uint> Value1 { get { return value1; } set { value1 = value; } }
		public List<uint> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntListFields2 : MonoBehaviour, IValues<List<uint>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<uint> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<uint> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<uint> Value1 { get { return value1; } set { value1 = value; } }
		public List<uint> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntListProperty1 : MonoBehaviour, IValue<List<uint>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint> Value { get; set; }
	}

	public class UIntListProperty2 : MonoBehaviour, IValue<List<uint>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint> Value { get; set; }
	}

	public class UIntListProperties1 : MonoBehaviour, IValues<List<uint>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<uint> Value2 { get; set; }
	}

	public class UIntListProperties2 : MonoBehaviour, IValues<List<uint>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<uint> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint> Value2 { get; set; }
	}

	public class UIntNullableField1 : MonoBehaviour, IValue<uint?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint? Value { get { return value; } set { this.value = value; } }
	}

	public class UIntNullableField2 : MonoBehaviour, IValue<uint?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint? Value { get { return value; } set { this.value = value; } }
	}

	public class UIntNullableFields1 : MonoBehaviour, IValues<uint?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private uint? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public uint? Value1 { get { return value1; } set { value1 = value; } }
		public uint? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntNullableFields2 : MonoBehaviour, IValues<uint?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private uint? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public uint? Value1 { get { return value1; } set { value1 = value; } }
		public uint? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntNullableProperty1 : MonoBehaviour, IValue<uint?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint? Value { get; set; }
	}

	public class UIntNullableProperty2 : MonoBehaviour, IValue<uint?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint? Value { get; set; }
	}

	public class UIntNullableProperties1 : MonoBehaviour, IValues<uint?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint? Value2 { get; set; }
	}

	public class UIntNullableProperties2 : MonoBehaviour, IValues<uint?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint? Value2 { get; set; }
	}

	public class UIntArrayNullableField1 : MonoBehaviour, IValue<uint?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UIntArrayNullableField2 : MonoBehaviour, IValue<uint?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UIntArrayNullableFields1 : MonoBehaviour, IValues<uint?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private uint?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public uint?[] Value1 { get { return value1; } set { value1 = value; } }
		public uint?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntArrayNullableFields2 : MonoBehaviour, IValues<uint?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private uint?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public uint?[] Value1 { get { return value1; } set { value1 = value; } }
		public uint?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntArrayNullableProperty1 : MonoBehaviour, IValue<uint?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint?[] Value { get; set; }
	}

	public class UIntArrayNullableProperty2 : MonoBehaviour, IValue<uint?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint?[] Value { get; set; }
	}

	public class UIntArrayNullableProperties1 : MonoBehaviour, IValues<uint?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint?[] Value2 { get; set; }
	}

	public class UIntArrayNullableProperties2 : MonoBehaviour, IValues<uint?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint?[] Value2 { get; set; }
	}

	public class UIntListNullableField1 : MonoBehaviour, IValue<List<uint?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<uint?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<uint?> Value { get { return value; } set { this.value = value; } }
	}

	public class UIntListNullableField2 : MonoBehaviour, IValue<List<uint?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<uint?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<uint?> Value { get { return value; } set { this.value = value; } }
	}

	public class UIntListNullableFields1 : MonoBehaviour, IValues<List<uint?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<uint?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<uint?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<uint?> Value1 { get { return value1; } set { value1 = value; } }
		public List<uint?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntListNullableFields2 : MonoBehaviour, IValues<List<uint?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<uint?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<uint?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<uint?> Value1 { get { return value1; } set { value1 = value; } }
		public List<uint?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UIntListNullableProperty1 : MonoBehaviour, IValue<List<uint?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint?> Value { get; set; }
	}

	public class UIntListNullableProperty2 : MonoBehaviour, IValue<List<uint?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint?> Value { get; set; }
	}

	public class UIntListNullableProperties1 : MonoBehaviour, IValues<List<uint?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<uint?> Value2 { get; set; }
	}

	public class UIntListNullableProperties2 : MonoBehaviour, IValues<List<uint?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<uint?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint?> Value2 { get; set; }
	}
}