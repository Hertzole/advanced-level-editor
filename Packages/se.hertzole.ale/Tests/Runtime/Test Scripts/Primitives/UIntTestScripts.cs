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
	public class UintField1 : MonoBehaviour, IValue<uint>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint Value { get { return value; } set { this.value = value; } }
	}

	public class UintField2 : MonoBehaviour, IValue<uint>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint Value { get { return value; } set { this.value = value; } }
	}

	public class UintFields1 : MonoBehaviour, IValues<uint>
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

	public class UintFields2 : MonoBehaviour, IValues<uint>
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

	public class UintProperty1 : MonoBehaviour, IValue<uint>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint Value { get; set; }
	}

	public class UintProperty2 : MonoBehaviour, IValue<uint>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint Value { get; set; }
	}

	public class UintProperties1 : MonoBehaviour, IValues<uint>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint Value2 { get; set; }
	}

	public class UintProperties2 : MonoBehaviour, IValues<uint>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint Value2 { get; set; }
	}

	public class UintArrayField1 : MonoBehaviour, IValue<uint[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint[] Value { get { return value; } set { this.value = value; } }
	}

	public class UintArrayField2 : MonoBehaviour, IValue<uint[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint[] Value { get { return value; } set { this.value = value; } }
	}

	public class UintArrayFields1 : MonoBehaviour, IValues<uint[]>
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

	public class UintArrayFields2 : MonoBehaviour, IValues<uint[]>
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

	public class UintArrayProperty1 : MonoBehaviour, IValue<uint[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint[] Value { get; set; }
	}

	public class UintArrayProperty2 : MonoBehaviour, IValue<uint[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint[] Value { get; set; }
	}

	public class UintArrayProperties1 : MonoBehaviour, IValues<uint[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint[] Value2 { get; set; }
	}

	public class UintArrayProperties2 : MonoBehaviour, IValues<uint[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint[] Value2 { get; set; }
	}

	public class UintListField1 : MonoBehaviour, IValue<List<uint>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<uint> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<uint> Value { get { return value; } set { this.value = value; } }
	}

	public class UintListField2 : MonoBehaviour, IValue<List<uint>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<uint> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<uint> Value { get { return value; } set { this.value = value; } }
	}

	public class UintListFields1 : MonoBehaviour, IValues<List<uint>>
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

	public class UintListFields2 : MonoBehaviour, IValues<List<uint>>
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

	public class UintListProperty1 : MonoBehaviour, IValue<List<uint>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint> Value { get; set; }
	}

	public class UintListProperty2 : MonoBehaviour, IValue<List<uint>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint> Value { get; set; }
	}

	public class UintListProperties1 : MonoBehaviour, IValues<List<uint>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<uint> Value2 { get; set; }
	}

	public class UintListProperties2 : MonoBehaviour, IValues<List<uint>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<uint> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint> Value2 { get; set; }
	}

	public class UintNullableField1 : MonoBehaviour, IValue<uint?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint? Value { get { return value; } set { this.value = value; } }
	}

	public class UintNullableField2 : MonoBehaviour, IValue<uint?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint? Value { get { return value; } set { this.value = value; } }
	}

	public class UintNullableFields1 : MonoBehaviour, IValues<uint?>
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

	public class UintNullableFields2 : MonoBehaviour, IValues<uint?>
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

	public class UintNullableProperty1 : MonoBehaviour, IValue<uint?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint? Value { get; set; }
	}

	public class UintNullableProperty2 : MonoBehaviour, IValue<uint?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint? Value { get; set; }
	}

	public class UintNullableProperties1 : MonoBehaviour, IValues<uint?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint? Value2 { get; set; }
	}

	public class UintNullableProperties2 : MonoBehaviour, IValues<uint?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint? Value2 { get; set; }
	}

	public class UintArrayNullableField1 : MonoBehaviour, IValue<uint?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private uint?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public uint?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UintArrayNullableField2 : MonoBehaviour, IValue<uint?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private uint?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public uint?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UintArrayNullableFields1 : MonoBehaviour, IValues<uint?[]>
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

	public class UintArrayNullableFields2 : MonoBehaviour, IValues<uint?[]>
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

	public class UintArrayNullableProperty1 : MonoBehaviour, IValue<uint?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint?[] Value { get; set; }
	}

	public class UintArrayNullableProperty2 : MonoBehaviour, IValue<uint?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint?[] Value { get; set; }
	}

	public class UintArrayNullableProperties1 : MonoBehaviour, IValues<uint?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public uint?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public uint?[] Value2 { get; set; }
	}

	public class UintArrayNullableProperties2 : MonoBehaviour, IValues<uint?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public uint?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public uint?[] Value2 { get; set; }
	}

	public class UintListNullableField1 : MonoBehaviour, IValue<List<uint?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<uint?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<uint?> Value { get { return value; } set { this.value = value; } }
	}

	public class UintListNullableField2 : MonoBehaviour, IValue<List<uint?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<uint?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<uint?> Value { get { return value; } set { this.value = value; } }
	}

	public class UintListNullableFields1 : MonoBehaviour, IValues<List<uint?>>
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

	public class UintListNullableFields2 : MonoBehaviour, IValues<List<uint?>>
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

	public class UintListNullableProperty1 : MonoBehaviour, IValue<List<uint?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint?> Value { get; set; }
	}

	public class UintListNullableProperty2 : MonoBehaviour, IValue<List<uint?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint?> Value { get; set; }
	}

	public class UintListNullableProperties1 : MonoBehaviour, IValues<List<uint?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<uint?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<uint?> Value2 { get; set; }
	}

	public class UintListNullableProperties2 : MonoBehaviour, IValues<List<uint?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<uint?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<uint?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618