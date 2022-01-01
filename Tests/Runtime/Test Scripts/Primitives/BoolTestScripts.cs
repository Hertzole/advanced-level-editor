// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class BoolField1 : MonoBehaviour, IValue<bool>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool value;

		public int ValueID { get { return VALUE_0_ID; } }
		public bool Value { get { return value; } set { this.value = value; } }
	}

	public class BoolField2 : MonoBehaviour, IValue<bool>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool value;

		public int ValueID { get { return VALUE_100_ID; } }
		public bool Value { get { return value; } set { this.value = value; } }
	}

	public class BoolFields1 : MonoBehaviour, IValues<bool>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private bool value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public bool Value1 { get { return value1; } set { value1 = value; } }
		public bool Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolFields2 : MonoBehaviour, IValues<bool>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private bool value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public bool Value1 { get { return value1; } set { value1 = value; } }
		public bool Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolProperty1 : MonoBehaviour, IValue<bool>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool Value { get; set; }
	}

	public class BoolProperty2 : MonoBehaviour, IValue<bool>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool Value { get; set; }
	}

	public class BoolProperties1 : MonoBehaviour, IValues<bool>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public bool Value2 { get; set; }
	}

	public class BoolProperties2 : MonoBehaviour, IValues<bool>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public bool Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool Value2 { get; set; }
	}

	public class BoolArrayField1 : MonoBehaviour, IValue<bool[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public bool[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoolArrayField2 : MonoBehaviour, IValue<bool[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public bool[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoolArrayFields1 : MonoBehaviour, IValues<bool[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private bool[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public bool[] Value1 { get { return value1; } set { value1 = value; } }
		public bool[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolArrayFields2 : MonoBehaviour, IValues<bool[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private bool[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public bool[] Value1 { get { return value1; } set { value1 = value; } }
		public bool[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolArrayProperty1 : MonoBehaviour, IValue<bool[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool[] Value { get; set; }
	}

	public class BoolArrayProperty2 : MonoBehaviour, IValue<bool[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool[] Value { get; set; }
	}

	public class BoolArrayProperties1 : MonoBehaviour, IValues<bool[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public bool[] Value2 { get; set; }
	}

	public class BoolArrayProperties2 : MonoBehaviour, IValues<bool[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public bool[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool[] Value2 { get; set; }
	}

	public class BoolListField1 : MonoBehaviour, IValue<List<bool>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<bool> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<bool> Value { get { return value; } set { this.value = value; } }
	}

	public class BoolListField2 : MonoBehaviour, IValue<List<bool>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<bool> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<bool> Value { get { return value; } set { this.value = value; } }
	}

	public class BoolListFields1 : MonoBehaviour, IValues<List<bool>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<bool> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<bool> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<bool> Value1 { get { return value1; } set { value1 = value; } }
		public List<bool> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolListFields2 : MonoBehaviour, IValues<List<bool>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<bool> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<bool> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<bool> Value1 { get { return value1; } set { value1 = value; } }
		public List<bool> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolListProperty1 : MonoBehaviour, IValue<List<bool>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<bool> Value { get; set; }
	}

	public class BoolListProperty2 : MonoBehaviour, IValue<List<bool>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<bool> Value { get; set; }
	}

	public class BoolListProperties1 : MonoBehaviour, IValues<List<bool>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<bool> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<bool> Value2 { get; set; }
	}

	public class BoolListProperties2 : MonoBehaviour, IValues<List<bool>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<bool> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<bool> Value2 { get; set; }
	}

	public class BoolNullableField1 : MonoBehaviour, IValue<bool?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public bool? Value { get { return value; } set { this.value = value; } }
	}

	public class BoolNullableField2 : MonoBehaviour, IValue<bool?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public bool? Value { get { return value; } set { this.value = value; } }
	}

	public class BoolNullableFields1 : MonoBehaviour, IValues<bool?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private bool? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public bool? Value1 { get { return value1; } set { value1 = value; } }
		public bool? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolNullableFields2 : MonoBehaviour, IValues<bool?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private bool? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public bool? Value1 { get { return value1; } set { value1 = value; } }
		public bool? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolNullableProperty1 : MonoBehaviour, IValue<bool?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool? Value { get; set; }
	}

	public class BoolNullableProperty2 : MonoBehaviour, IValue<bool?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool? Value { get; set; }
	}

	public class BoolNullableProperties1 : MonoBehaviour, IValues<bool?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public bool? Value2 { get; set; }
	}

	public class BoolNullableProperties2 : MonoBehaviour, IValues<bool?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public bool? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool? Value2 { get; set; }
	}

	public class BoolArrayNullableField1 : MonoBehaviour, IValue<bool?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public bool?[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoolArrayNullableField2 : MonoBehaviour, IValue<bool?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public bool?[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoolArrayNullableFields1 : MonoBehaviour, IValues<bool?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private bool?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private bool?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public bool?[] Value1 { get { return value1; } set { value1 = value; } }
		public bool?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolArrayNullableFields2 : MonoBehaviour, IValues<bool?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private bool?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private bool?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public bool?[] Value1 { get { return value1; } set { value1 = value; } }
		public bool?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolArrayNullableProperty1 : MonoBehaviour, IValue<bool?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool?[] Value { get; set; }
	}

	public class BoolArrayNullableProperty2 : MonoBehaviour, IValue<bool?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool?[] Value { get; set; }
	}

	public class BoolArrayNullableProperties1 : MonoBehaviour, IValues<bool?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public bool?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public bool?[] Value2 { get; set; }
	}

	public class BoolArrayNullableProperties2 : MonoBehaviour, IValues<bool?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public bool?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public bool?[] Value2 { get; set; }
	}

	public class BoolListNullableField1 : MonoBehaviour, IValue<List<bool?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<bool?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<bool?> Value { get { return value; } set { this.value = value; } }
	}

	public class BoolListNullableField2 : MonoBehaviour, IValue<List<bool?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<bool?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<bool?> Value { get { return value; } set { this.value = value; } }
	}

	public class BoolListNullableFields1 : MonoBehaviour, IValues<List<bool?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<bool?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<bool?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<bool?> Value1 { get { return value1; } set { value1 = value; } }
		public List<bool?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolListNullableFields2 : MonoBehaviour, IValues<List<bool?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<bool?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<bool?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<bool?> Value1 { get { return value1; } set { value1 = value; } }
		public List<bool?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoolListNullableProperty1 : MonoBehaviour, IValue<List<bool?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<bool?> Value { get; set; }
	}

	public class BoolListNullableProperty2 : MonoBehaviour, IValue<List<bool?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<bool?> Value { get; set; }
	}

	public class BoolListNullableProperties1 : MonoBehaviour, IValues<List<bool?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<bool?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<bool?> Value2 { get; set; }
	}

	public class BoolListNullableProperties2 : MonoBehaviour, IValues<List<bool?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<bool?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<bool?> Value2 { get; set; }
	}
}