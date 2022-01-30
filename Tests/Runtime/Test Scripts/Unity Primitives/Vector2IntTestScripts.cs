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
	public class Vector2IntField1 : MonoBehaviour, IValue<Vector2Int>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2Int Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntField2 : MonoBehaviour, IValue<Vector2Int>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2Int Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntFields1 : MonoBehaviour, IValues<Vector2Int>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2Int value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2Int Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntFields2 : MonoBehaviour, IValues<Vector2Int>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2Int value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2Int Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntProperty1 : MonoBehaviour, IValue<Vector2Int>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int Value { get; set; }
	}

	public class Vector2IntProperty2 : MonoBehaviour, IValue<Vector2Int>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int Value { get; set; }
	}

	public class Vector2IntProperties1 : MonoBehaviour, IValues<Vector2Int>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2Int Value2 { get; set; }
	}

	public class Vector2IntProperties2 : MonoBehaviour, IValues<Vector2Int>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2Int Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int Value2 { get; set; }
	}

	public class Vector2IntArrayField1 : MonoBehaviour, IValue<Vector2Int[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2Int[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntArrayField2 : MonoBehaviour, IValue<Vector2Int[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2Int[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntArrayFields1 : MonoBehaviour, IValues<Vector2Int[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2Int[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2Int[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntArrayFields2 : MonoBehaviour, IValues<Vector2Int[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2Int[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2Int[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntArrayProperty1 : MonoBehaviour, IValue<Vector2Int[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int[] Value { get; set; }
	}

	public class Vector2IntArrayProperty2 : MonoBehaviour, IValue<Vector2Int[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int[] Value { get; set; }
	}

	public class Vector2IntArrayProperties1 : MonoBehaviour, IValues<Vector2Int[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2Int[] Value2 { get; set; }
	}

	public class Vector2IntArrayProperties2 : MonoBehaviour, IValues<Vector2Int[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2Int[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int[] Value2 { get; set; }
	}

	public class Vector2IntListField1 : MonoBehaviour, IValue<List<Vector2Int>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2Int> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector2Int> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntListField2 : MonoBehaviour, IValue<List<Vector2Int>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2Int> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector2Int> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntListFields1 : MonoBehaviour, IValues<List<Vector2Int>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2Int> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector2Int> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector2Int> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2Int> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntListFields2 : MonoBehaviour, IValues<List<Vector2Int>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector2Int> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2Int> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector2Int> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2Int> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntListProperty1 : MonoBehaviour, IValue<List<Vector2Int>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2Int> Value { get; set; }
	}

	public class Vector2IntListProperty2 : MonoBehaviour, IValue<List<Vector2Int>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2Int> Value { get; set; }
	}

	public class Vector2IntListProperties1 : MonoBehaviour, IValues<List<Vector2Int>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2Int> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector2Int> Value2 { get; set; }
	}

	public class Vector2IntListProperties2 : MonoBehaviour, IValues<List<Vector2Int>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector2Int> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2Int> Value2 { get; set; }
	}

	public class Vector2IntNullableField1 : MonoBehaviour, IValue<Vector2Int?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2Int? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntNullableField2 : MonoBehaviour, IValue<Vector2Int?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2Int? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntNullableFields1 : MonoBehaviour, IValues<Vector2Int?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2Int? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2Int? Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntNullableFields2 : MonoBehaviour, IValues<Vector2Int?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2Int? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2Int? Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntNullableProperty1 : MonoBehaviour, IValue<Vector2Int?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int? Value { get; set; }
	}

	public class Vector2IntNullableProperty2 : MonoBehaviour, IValue<Vector2Int?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int? Value { get; set; }
	}

	public class Vector2IntNullableProperties1 : MonoBehaviour, IValues<Vector2Int?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2Int? Value2 { get; set; }
	}

	public class Vector2IntNullableProperties2 : MonoBehaviour, IValues<Vector2Int?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2Int? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int? Value2 { get; set; }
	}

	public class Vector2IntArrayNullableField1 : MonoBehaviour, IValue<Vector2Int?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2Int?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntArrayNullableField2 : MonoBehaviour, IValue<Vector2Int?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2Int?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntArrayNullableFields1 : MonoBehaviour, IValues<Vector2Int?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2Int?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2Int?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2Int?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntArrayNullableFields2 : MonoBehaviour, IValues<Vector2Int?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2Int?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2Int?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2Int?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2Int?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntArrayNullableProperty1 : MonoBehaviour, IValue<Vector2Int?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int?[] Value { get; set; }
	}

	public class Vector2IntArrayNullableProperty2 : MonoBehaviour, IValue<Vector2Int?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int?[] Value { get; set; }
	}

	public class Vector2IntArrayNullableProperties1 : MonoBehaviour, IValues<Vector2Int?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2Int?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2Int?[] Value2 { get; set; }
	}

	public class Vector2IntArrayNullableProperties2 : MonoBehaviour, IValues<Vector2Int?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2Int?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2Int?[] Value2 { get; set; }
	}

	public class Vector2IntListNullableField1 : MonoBehaviour, IValue<List<Vector2Int?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2Int?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector2Int?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntListNullableField2 : MonoBehaviour, IValue<List<Vector2Int?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2Int?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector2Int?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2IntListNullableFields1 : MonoBehaviour, IValues<List<Vector2Int?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2Int?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector2Int?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector2Int?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2Int?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntListNullableFields2 : MonoBehaviour, IValues<List<Vector2Int?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector2Int?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2Int?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector2Int?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2Int?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2IntListNullableProperty1 : MonoBehaviour, IValue<List<Vector2Int?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2Int?> Value { get; set; }
	}

	public class Vector2IntListNullableProperty2 : MonoBehaviour, IValue<List<Vector2Int?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2Int?> Value { get; set; }
	}

	public class Vector2IntListNullableProperties1 : MonoBehaviour, IValues<List<Vector2Int?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2Int?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector2Int?> Value2 { get; set; }
	}

	public class Vector2IntListNullableProperties2 : MonoBehaviour, IValues<List<Vector2Int?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector2Int?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2Int?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618