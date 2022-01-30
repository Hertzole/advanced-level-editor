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
	public class Vector4Field1 : MonoBehaviour, IValue<Vector4>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4 value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector4 Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4Field2 : MonoBehaviour, IValue<Vector4>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4 value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector4 Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4Fields1 : MonoBehaviour, IValues<Vector4>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4 value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector4 value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector4 Value1 { get { return value1; } set { value1 = value; } }
		public Vector4 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4Fields2 : MonoBehaviour, IValues<Vector4>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector4 value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4 value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector4 Value1 { get { return value1; } set { value1 = value; } }
		public Vector4 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4Property1 : MonoBehaviour, IValue<Vector4>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4 Value { get; set; }
	}

	public class Vector4Property2 : MonoBehaviour, IValue<Vector4>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4 Value { get; set; }
	}

	public class Vector4Properties1 : MonoBehaviour, IValues<Vector4>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector4 Value2 { get; set; }
	}

	public class Vector4Properties2 : MonoBehaviour, IValues<Vector4>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector4 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4 Value2 { get; set; }
	}

	public class Vector4ArrayField1 : MonoBehaviour, IValue<Vector4[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector4[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ArrayField2 : MonoBehaviour, IValue<Vector4[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector4[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ArrayFields1 : MonoBehaviour, IValues<Vector4[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector4[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector4[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector4[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ArrayFields2 : MonoBehaviour, IValues<Vector4[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector4[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector4[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector4[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ArrayProperty1 : MonoBehaviour, IValue<Vector4[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4[] Value { get; set; }
	}

	public class Vector4ArrayProperty2 : MonoBehaviour, IValue<Vector4[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4[] Value { get; set; }
	}

	public class Vector4ArrayProperties1 : MonoBehaviour, IValues<Vector4[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector4[] Value2 { get; set; }
	}

	public class Vector4ArrayProperties2 : MonoBehaviour, IValues<Vector4[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector4[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4[] Value2 { get; set; }
	}

	public class Vector4ListField1 : MonoBehaviour, IValue<List<Vector4>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector4> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector4> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ListField2 : MonoBehaviour, IValue<List<Vector4>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector4> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector4> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ListFields1 : MonoBehaviour, IValues<List<Vector4>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector4> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector4> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector4> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector4> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ListFields2 : MonoBehaviour, IValues<List<Vector4>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector4> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector4> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector4> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector4> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ListProperty1 : MonoBehaviour, IValue<List<Vector4>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector4> Value { get; set; }
	}

	public class Vector4ListProperty2 : MonoBehaviour, IValue<List<Vector4>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector4> Value { get; set; }
	}

	public class Vector4ListProperties1 : MonoBehaviour, IValues<List<Vector4>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector4> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector4> Value2 { get; set; }
	}

	public class Vector4ListProperties2 : MonoBehaviour, IValues<List<Vector4>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector4> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector4> Value2 { get; set; }
	}

	public class Vector4NullableField1 : MonoBehaviour, IValue<Vector4?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector4? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4NullableField2 : MonoBehaviour, IValue<Vector4?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector4? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4NullableFields1 : MonoBehaviour, IValues<Vector4?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector4? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector4? Value1 { get { return value1; } set { value1 = value; } }
		public Vector4? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4NullableFields2 : MonoBehaviour, IValues<Vector4?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector4? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector4? Value1 { get { return value1; } set { value1 = value; } }
		public Vector4? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4NullableProperty1 : MonoBehaviour, IValue<Vector4?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4? Value { get; set; }
	}

	public class Vector4NullableProperty2 : MonoBehaviour, IValue<Vector4?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4? Value { get; set; }
	}

	public class Vector4NullableProperties1 : MonoBehaviour, IValues<Vector4?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector4? Value2 { get; set; }
	}

	public class Vector4NullableProperties2 : MonoBehaviour, IValues<Vector4?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector4? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4? Value2 { get; set; }
	}

	public class Vector4ArrayNullableField1 : MonoBehaviour, IValue<Vector4?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector4?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ArrayNullableField2 : MonoBehaviour, IValue<Vector4?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector4?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ArrayNullableFields1 : MonoBehaviour, IValues<Vector4?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector4?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector4?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector4?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector4?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ArrayNullableFields2 : MonoBehaviour, IValues<Vector4?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector4?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector4?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector4?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector4?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ArrayNullableProperty1 : MonoBehaviour, IValue<Vector4?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4?[] Value { get; set; }
	}

	public class Vector4ArrayNullableProperty2 : MonoBehaviour, IValue<Vector4?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4?[] Value { get; set; }
	}

	public class Vector4ArrayNullableProperties1 : MonoBehaviour, IValues<Vector4?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector4?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector4?[] Value2 { get; set; }
	}

	public class Vector4ArrayNullableProperties2 : MonoBehaviour, IValues<Vector4?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector4?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector4?[] Value2 { get; set; }
	}

	public class Vector4ListNullableField1 : MonoBehaviour, IValue<List<Vector4?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector4?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector4?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ListNullableField2 : MonoBehaviour, IValue<List<Vector4?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector4?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector4?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector4ListNullableFields1 : MonoBehaviour, IValues<List<Vector4?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector4?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector4?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector4?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector4?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ListNullableFields2 : MonoBehaviour, IValues<List<Vector4?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector4?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector4?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector4?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector4?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector4ListNullableProperty1 : MonoBehaviour, IValue<List<Vector4?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector4?> Value { get; set; }
	}

	public class Vector4ListNullableProperty2 : MonoBehaviour, IValue<List<Vector4?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector4?> Value { get; set; }
	}

	public class Vector4ListNullableProperties1 : MonoBehaviour, IValues<List<Vector4?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector4?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector4?> Value2 { get; set; }
	}

	public class Vector4ListNullableProperties2 : MonoBehaviour, IValues<List<Vector4?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector4?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector4?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618