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
	public class Matrix4x4Field1 : MonoBehaviour, IValue<Matrix4x4>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4 value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Matrix4x4 Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4Field2 : MonoBehaviour, IValue<Matrix4x4>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4 value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Matrix4x4 Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4Fields1 : MonoBehaviour, IValues<Matrix4x4>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4 value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Matrix4x4 value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Matrix4x4 Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4Fields2 : MonoBehaviour, IValues<Matrix4x4>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Matrix4x4 value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4 value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Matrix4x4 Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4Property1 : MonoBehaviour, IValue<Matrix4x4>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4 Value { get; set; }
	}

	public class Matrix4x4Property2 : MonoBehaviour, IValue<Matrix4x4>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4 Value { get; set; }
	}

	public class Matrix4x4Properties1 : MonoBehaviour, IValues<Matrix4x4>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Matrix4x4 Value2 { get; set; }
	}

	public class Matrix4x4Properties2 : MonoBehaviour, IValues<Matrix4x4>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Matrix4x4 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4 Value2 { get; set; }
	}

	public class Matrix4x4ArrayField1 : MonoBehaviour, IValue<Matrix4x4[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Matrix4x4[] Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ArrayField2 : MonoBehaviour, IValue<Matrix4x4[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Matrix4x4[] Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ArrayFields1 : MonoBehaviour, IValues<Matrix4x4[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Matrix4x4[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Matrix4x4[] Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ArrayFields2 : MonoBehaviour, IValues<Matrix4x4[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Matrix4x4[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Matrix4x4[] Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ArrayProperty1 : MonoBehaviour, IValue<Matrix4x4[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4[] Value { get; set; }
	}

	public class Matrix4x4ArrayProperty2 : MonoBehaviour, IValue<Matrix4x4[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4[] Value { get; set; }
	}

	public class Matrix4x4ArrayProperties1 : MonoBehaviour, IValues<Matrix4x4[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Matrix4x4[] Value2 { get; set; }
	}

	public class Matrix4x4ArrayProperties2 : MonoBehaviour, IValues<Matrix4x4[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Matrix4x4[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4[] Value2 { get; set; }
	}

	public class Matrix4x4ListField1 : MonoBehaviour, IValue<List<Matrix4x4>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Matrix4x4> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Matrix4x4> Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ListField2 : MonoBehaviour, IValue<List<Matrix4x4>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Matrix4x4> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Matrix4x4> Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ListFields1 : MonoBehaviour, IValues<List<Matrix4x4>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Matrix4x4> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Matrix4x4> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Matrix4x4> Value1 { get { return value1; } set { value1 = value; } }
		public List<Matrix4x4> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ListFields2 : MonoBehaviour, IValues<List<Matrix4x4>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Matrix4x4> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Matrix4x4> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Matrix4x4> Value1 { get { return value1; } set { value1 = value; } }
		public List<Matrix4x4> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ListProperty1 : MonoBehaviour, IValue<List<Matrix4x4>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Matrix4x4> Value { get; set; }
	}

	public class Matrix4x4ListProperty2 : MonoBehaviour, IValue<List<Matrix4x4>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Matrix4x4> Value { get; set; }
	}

	public class Matrix4x4ListProperties1 : MonoBehaviour, IValues<List<Matrix4x4>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Matrix4x4> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Matrix4x4> Value2 { get; set; }
	}

	public class Matrix4x4ListProperties2 : MonoBehaviour, IValues<List<Matrix4x4>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Matrix4x4> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Matrix4x4> Value2 { get; set; }
	}

	public class Matrix4x4NullableField1 : MonoBehaviour, IValue<Matrix4x4?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Matrix4x4? Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4NullableField2 : MonoBehaviour, IValue<Matrix4x4?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Matrix4x4? Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4NullableFields1 : MonoBehaviour, IValues<Matrix4x4?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Matrix4x4? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Matrix4x4? Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4NullableFields2 : MonoBehaviour, IValues<Matrix4x4?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Matrix4x4? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Matrix4x4? Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4NullableProperty1 : MonoBehaviour, IValue<Matrix4x4?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4? Value { get; set; }
	}

	public class Matrix4x4NullableProperty2 : MonoBehaviour, IValue<Matrix4x4?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4? Value { get; set; }
	}

	public class Matrix4x4NullableProperties1 : MonoBehaviour, IValues<Matrix4x4?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Matrix4x4? Value2 { get; set; }
	}

	public class Matrix4x4NullableProperties2 : MonoBehaviour, IValues<Matrix4x4?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Matrix4x4? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4? Value2 { get; set; }
	}

	public class Matrix4x4ArrayNullableField1 : MonoBehaviour, IValue<Matrix4x4?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Matrix4x4?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ArrayNullableField2 : MonoBehaviour, IValue<Matrix4x4?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Matrix4x4?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ArrayNullableFields1 : MonoBehaviour, IValues<Matrix4x4?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Matrix4x4?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Matrix4x4?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Matrix4x4?[] Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ArrayNullableFields2 : MonoBehaviour, IValues<Matrix4x4?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Matrix4x4?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Matrix4x4?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Matrix4x4?[] Value1 { get { return value1; } set { value1 = value; } }
		public Matrix4x4?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ArrayNullableProperty1 : MonoBehaviour, IValue<Matrix4x4?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4?[] Value { get; set; }
	}

	public class Matrix4x4ArrayNullableProperty2 : MonoBehaviour, IValue<Matrix4x4?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4?[] Value { get; set; }
	}

	public class Matrix4x4ArrayNullableProperties1 : MonoBehaviour, IValues<Matrix4x4?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Matrix4x4?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Matrix4x4?[] Value2 { get; set; }
	}

	public class Matrix4x4ArrayNullableProperties2 : MonoBehaviour, IValues<Matrix4x4?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Matrix4x4?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Matrix4x4?[] Value2 { get; set; }
	}

	public class Matrix4x4ListNullableField1 : MonoBehaviour, IValue<List<Matrix4x4?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Matrix4x4?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Matrix4x4?> Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ListNullableField2 : MonoBehaviour, IValue<List<Matrix4x4?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Matrix4x4?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Matrix4x4?> Value { get { return value; } set { this.value = value; } }
	}

	public class Matrix4x4ListNullableFields1 : MonoBehaviour, IValues<List<Matrix4x4?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Matrix4x4?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Matrix4x4?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Matrix4x4?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Matrix4x4?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ListNullableFields2 : MonoBehaviour, IValues<List<Matrix4x4?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Matrix4x4?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Matrix4x4?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Matrix4x4?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Matrix4x4?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Matrix4x4ListNullableProperty1 : MonoBehaviour, IValue<List<Matrix4x4?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Matrix4x4?> Value { get; set; }
	}

	public class Matrix4x4ListNullableProperty2 : MonoBehaviour, IValue<List<Matrix4x4?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Matrix4x4?> Value { get; set; }
	}

	public class Matrix4x4ListNullableProperties1 : MonoBehaviour, IValues<List<Matrix4x4?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Matrix4x4?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Matrix4x4?> Value2 { get; set; }
	}

	public class Matrix4x4ListNullableProperties2 : MonoBehaviour, IValues<List<Matrix4x4?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Matrix4x4?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Matrix4x4?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618