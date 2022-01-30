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
	public class Vector3IntField1 : MonoBehaviour, IValue<Vector3Int>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3Int Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntField2 : MonoBehaviour, IValue<Vector3Int>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3Int Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntFields1 : MonoBehaviour, IValues<Vector3Int>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3Int value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3Int Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntFields2 : MonoBehaviour, IValues<Vector3Int>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3Int value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3Int Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntProperty1 : MonoBehaviour, IValue<Vector3Int>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int Value { get; set; }
	}

	public class Vector3IntProperty2 : MonoBehaviour, IValue<Vector3Int>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int Value { get; set; }
	}

	public class Vector3IntProperties1 : MonoBehaviour, IValues<Vector3Int>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3Int Value2 { get; set; }
	}

	public class Vector3IntProperties2 : MonoBehaviour, IValues<Vector3Int>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3Int Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int Value2 { get; set; }
	}

	public class Vector3IntArrayField1 : MonoBehaviour, IValue<Vector3Int[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3Int[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntArrayField2 : MonoBehaviour, IValue<Vector3Int[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3Int[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntArrayFields1 : MonoBehaviour, IValues<Vector3Int[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3Int[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3Int[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntArrayFields2 : MonoBehaviour, IValues<Vector3Int[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3Int[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3Int[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntArrayProperty1 : MonoBehaviour, IValue<Vector3Int[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int[] Value { get; set; }
	}

	public class Vector3IntArrayProperty2 : MonoBehaviour, IValue<Vector3Int[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int[] Value { get; set; }
	}

	public class Vector3IntArrayProperties1 : MonoBehaviour, IValues<Vector3Int[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3Int[] Value2 { get; set; }
	}

	public class Vector3IntArrayProperties2 : MonoBehaviour, IValues<Vector3Int[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3Int[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int[] Value2 { get; set; }
	}

	public class Vector3IntListField1 : MonoBehaviour, IValue<List<Vector3Int>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3Int> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector3Int> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntListField2 : MonoBehaviour, IValue<List<Vector3Int>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3Int> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector3Int> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntListFields1 : MonoBehaviour, IValues<List<Vector3Int>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3Int> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector3Int> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector3Int> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3Int> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntListFields2 : MonoBehaviour, IValues<List<Vector3Int>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector3Int> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3Int> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector3Int> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3Int> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntListProperty1 : MonoBehaviour, IValue<List<Vector3Int>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3Int> Value { get; set; }
	}

	public class Vector3IntListProperty2 : MonoBehaviour, IValue<List<Vector3Int>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3Int> Value { get; set; }
	}

	public class Vector3IntListProperties1 : MonoBehaviour, IValues<List<Vector3Int>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3Int> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector3Int> Value2 { get; set; }
	}

	public class Vector3IntListProperties2 : MonoBehaviour, IValues<List<Vector3Int>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector3Int> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3Int> Value2 { get; set; }
	}

	public class Vector3IntNullableField1 : MonoBehaviour, IValue<Vector3Int?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3Int? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntNullableField2 : MonoBehaviour, IValue<Vector3Int?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3Int? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntNullableFields1 : MonoBehaviour, IValues<Vector3Int?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3Int? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3Int? Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntNullableFields2 : MonoBehaviour, IValues<Vector3Int?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3Int? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3Int? Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntNullableProperty1 : MonoBehaviour, IValue<Vector3Int?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int? Value { get; set; }
	}

	public class Vector3IntNullableProperty2 : MonoBehaviour, IValue<Vector3Int?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int? Value { get; set; }
	}

	public class Vector3IntNullableProperties1 : MonoBehaviour, IValues<Vector3Int?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3Int? Value2 { get; set; }
	}

	public class Vector3IntNullableProperties2 : MonoBehaviour, IValues<Vector3Int?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3Int? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int? Value2 { get; set; }
	}

	public class Vector3IntArrayNullableField1 : MonoBehaviour, IValue<Vector3Int?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3Int?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntArrayNullableField2 : MonoBehaviour, IValue<Vector3Int?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3Int?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntArrayNullableFields1 : MonoBehaviour, IValues<Vector3Int?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3Int?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3Int?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3Int?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntArrayNullableFields2 : MonoBehaviour, IValues<Vector3Int?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3Int?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3Int?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3Int?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3Int?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntArrayNullableProperty1 : MonoBehaviour, IValue<Vector3Int?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int?[] Value { get; set; }
	}

	public class Vector3IntArrayNullableProperty2 : MonoBehaviour, IValue<Vector3Int?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int?[] Value { get; set; }
	}

	public class Vector3IntArrayNullableProperties1 : MonoBehaviour, IValues<Vector3Int?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3Int?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3Int?[] Value2 { get; set; }
	}

	public class Vector3IntArrayNullableProperties2 : MonoBehaviour, IValues<Vector3Int?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3Int?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3Int?[] Value2 { get; set; }
	}

	public class Vector3IntListNullableField1 : MonoBehaviour, IValue<List<Vector3Int?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3Int?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector3Int?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntListNullableField2 : MonoBehaviour, IValue<List<Vector3Int?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3Int?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector3Int?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3IntListNullableFields1 : MonoBehaviour, IValues<List<Vector3Int?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3Int?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector3Int?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector3Int?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3Int?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntListNullableFields2 : MonoBehaviour, IValues<List<Vector3Int?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector3Int?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3Int?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector3Int?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3Int?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3IntListNullableProperty1 : MonoBehaviour, IValue<List<Vector3Int?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3Int?> Value { get; set; }
	}

	public class Vector3IntListNullableProperty2 : MonoBehaviour, IValue<List<Vector3Int?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3Int?> Value { get; set; }
	}

	public class Vector3IntListNullableProperties1 : MonoBehaviour, IValues<List<Vector3Int?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3Int?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector3Int?> Value2 { get; set; }
	}

	public class Vector3IntListNullableProperties2 : MonoBehaviour, IValues<List<Vector3Int?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector3Int?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3Int?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618