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
	public class Vector3Field1 : MonoBehaviour, IValue<Vector3>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3 value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3 Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3Field2 : MonoBehaviour, IValue<Vector3>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3 value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3 Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3Fields1 : MonoBehaviour, IValues<Vector3>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3 value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3 value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3 Value1 { get { return value1; } set { value1 = value; } }
		public Vector3 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3Fields2 : MonoBehaviour, IValues<Vector3>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3 value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3 value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3 Value1 { get { return value1; } set { value1 = value; } }
		public Vector3 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3Property1 : MonoBehaviour, IValue<Vector3>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3 Value { get; set; }
	}

	public class Vector3Property2 : MonoBehaviour, IValue<Vector3>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3 Value { get; set; }
	}

	public class Vector3Properties1 : MonoBehaviour, IValues<Vector3>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3 Value2 { get; set; }
	}

	public class Vector3Properties2 : MonoBehaviour, IValues<Vector3>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3 Value2 { get; set; }
	}

	public class Vector3ArrayField1 : MonoBehaviour, IValue<Vector3[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ArrayField2 : MonoBehaviour, IValue<Vector3[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ArrayFields1 : MonoBehaviour, IValues<Vector3[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ArrayFields2 : MonoBehaviour, IValues<Vector3[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ArrayProperty1 : MonoBehaviour, IValue<Vector3[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3[] Value { get; set; }
	}

	public class Vector3ArrayProperty2 : MonoBehaviour, IValue<Vector3[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3[] Value { get; set; }
	}

	public class Vector3ArrayProperties1 : MonoBehaviour, IValues<Vector3[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3[] Value2 { get; set; }
	}

	public class Vector3ArrayProperties2 : MonoBehaviour, IValues<Vector3[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3[] Value2 { get; set; }
	}

	public class Vector3ListField1 : MonoBehaviour, IValue<List<Vector3>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector3> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ListField2 : MonoBehaviour, IValue<List<Vector3>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector3> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ListFields1 : MonoBehaviour, IValues<List<Vector3>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector3> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector3> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ListFields2 : MonoBehaviour, IValues<List<Vector3>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector3> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector3> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ListProperty1 : MonoBehaviour, IValue<List<Vector3>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3> Value { get; set; }
	}

	public class Vector3ListProperty2 : MonoBehaviour, IValue<List<Vector3>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3> Value { get; set; }
	}

	public class Vector3ListProperties1 : MonoBehaviour, IValues<List<Vector3>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector3> Value2 { get; set; }
	}

	public class Vector3ListProperties2 : MonoBehaviour, IValues<List<Vector3>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector3> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3> Value2 { get; set; }
	}

	public class Vector3NullableField1 : MonoBehaviour, IValue<Vector3?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3NullableField2 : MonoBehaviour, IValue<Vector3?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3NullableFields1 : MonoBehaviour, IValues<Vector3?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3? Value1 { get { return value1; } set { value1 = value; } }
		public Vector3? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3NullableFields2 : MonoBehaviour, IValues<Vector3?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3? Value1 { get { return value1; } set { value1 = value; } }
		public Vector3? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3NullableProperty1 : MonoBehaviour, IValue<Vector3?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3? Value { get; set; }
	}

	public class Vector3NullableProperty2 : MonoBehaviour, IValue<Vector3?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3? Value { get; set; }
	}

	public class Vector3NullableProperties1 : MonoBehaviour, IValues<Vector3?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3? Value2 { get; set; }
	}

	public class Vector3NullableProperties2 : MonoBehaviour, IValues<Vector3?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3? Value2 { get; set; }
	}

	public class Vector3ArrayNullableField1 : MonoBehaviour, IValue<Vector3?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector3?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ArrayNullableField2 : MonoBehaviour, IValue<Vector3?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector3?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ArrayNullableFields1 : MonoBehaviour, IValues<Vector3?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector3?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector3?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector3?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ArrayNullableFields2 : MonoBehaviour, IValues<Vector3?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector3?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector3?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector3?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector3?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ArrayNullableProperty1 : MonoBehaviour, IValue<Vector3?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3?[] Value { get; set; }
	}

	public class Vector3ArrayNullableProperty2 : MonoBehaviour, IValue<Vector3?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3?[] Value { get; set; }
	}

	public class Vector3ArrayNullableProperties1 : MonoBehaviour, IValues<Vector3?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector3?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector3?[] Value2 { get; set; }
	}

	public class Vector3ArrayNullableProperties2 : MonoBehaviour, IValues<Vector3?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector3?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector3?[] Value2 { get; set; }
	}

	public class Vector3ListNullableField1 : MonoBehaviour, IValue<List<Vector3?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector3?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ListNullableField2 : MonoBehaviour, IValue<List<Vector3?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector3?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector3ListNullableFields1 : MonoBehaviour, IValues<List<Vector3?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector3?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector3?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector3?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ListNullableFields2 : MonoBehaviour, IValues<List<Vector3?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector3?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector3?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector3?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector3?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector3ListNullableProperty1 : MonoBehaviour, IValue<List<Vector3?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3?> Value { get; set; }
	}

	public class Vector3ListNullableProperty2 : MonoBehaviour, IValue<List<Vector3?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3?> Value { get; set; }
	}

	public class Vector3ListNullableProperties1 : MonoBehaviour, IValues<List<Vector3?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector3?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector3?> Value2 { get; set; }
	}

	public class Vector3ListNullableProperties2 : MonoBehaviour, IValues<List<Vector3?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector3?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector3?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618