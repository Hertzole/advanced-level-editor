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
	public class Vector2Field1 : MonoBehaviour, IValue<Vector2>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2 value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2 Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2Field2 : MonoBehaviour, IValue<Vector2>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2 value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2 Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2Fields1 : MonoBehaviour, IValues<Vector2>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2 value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2 value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2 Value1 { get { return value1; } set { value1 = value; } }
		public Vector2 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2Fields2 : MonoBehaviour, IValues<Vector2>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2 value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2 value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2 Value1 { get { return value1; } set { value1 = value; } }
		public Vector2 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2Property1 : MonoBehaviour, IValue<Vector2>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2 Value { get; set; }
	}

	public class Vector2Property2 : MonoBehaviour, IValue<Vector2>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2 Value { get; set; }
	}

	public class Vector2Properties1 : MonoBehaviour, IValues<Vector2>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2 Value2 { get; set; }
	}

	public class Vector2Properties2 : MonoBehaviour, IValues<Vector2>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2 Value2 { get; set; }
	}

	public class Vector2ArrayField1 : MonoBehaviour, IValue<Vector2[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ArrayField2 : MonoBehaviour, IValue<Vector2[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ArrayFields1 : MonoBehaviour, IValues<Vector2[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ArrayFields2 : MonoBehaviour, IValues<Vector2[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ArrayProperty1 : MonoBehaviour, IValue<Vector2[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2[] Value { get; set; }
	}

	public class Vector2ArrayProperty2 : MonoBehaviour, IValue<Vector2[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2[] Value { get; set; }
	}

	public class Vector2ArrayProperties1 : MonoBehaviour, IValues<Vector2[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2[] Value2 { get; set; }
	}

	public class Vector2ArrayProperties2 : MonoBehaviour, IValues<Vector2[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2[] Value2 { get; set; }
	}

	public class Vector2ListField1 : MonoBehaviour, IValue<List<Vector2>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector2> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ListField2 : MonoBehaviour, IValue<List<Vector2>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector2> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ListFields1 : MonoBehaviour, IValues<List<Vector2>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector2> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector2> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ListFields2 : MonoBehaviour, IValues<List<Vector2>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector2> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector2> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ListProperty1 : MonoBehaviour, IValue<List<Vector2>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2> Value { get; set; }
	}

	public class Vector2ListProperty2 : MonoBehaviour, IValue<List<Vector2>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2> Value { get; set; }
	}

	public class Vector2ListProperties1 : MonoBehaviour, IValues<List<Vector2>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector2> Value2 { get; set; }
	}

	public class Vector2ListProperties2 : MonoBehaviour, IValues<List<Vector2>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector2> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2> Value2 { get; set; }
	}

	public class Vector2NullableField1 : MonoBehaviour, IValue<Vector2?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2NullableField2 : MonoBehaviour, IValue<Vector2?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2? Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2NullableFields1 : MonoBehaviour, IValues<Vector2?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2? Value1 { get { return value1; } set { value1 = value; } }
		public Vector2? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2NullableFields2 : MonoBehaviour, IValues<Vector2?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2? Value1 { get { return value1; } set { value1 = value; } }
		public Vector2? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2NullableProperty1 : MonoBehaviour, IValue<Vector2?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2? Value { get; set; }
	}

	public class Vector2NullableProperty2 : MonoBehaviour, IValue<Vector2?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2? Value { get; set; }
	}

	public class Vector2NullableProperties1 : MonoBehaviour, IValues<Vector2?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2? Value2 { get; set; }
	}

	public class Vector2NullableProperties2 : MonoBehaviour, IValues<Vector2?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2? Value2 { get; set; }
	}

	public class Vector2ArrayNullableField1 : MonoBehaviour, IValue<Vector2?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Vector2?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ArrayNullableField2 : MonoBehaviour, IValue<Vector2?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Vector2?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ArrayNullableFields1 : MonoBehaviour, IValues<Vector2?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Vector2?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Vector2?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Vector2?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ArrayNullableFields2 : MonoBehaviour, IValues<Vector2?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Vector2?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Vector2?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Vector2?[] Value1 { get { return value1; } set { value1 = value; } }
		public Vector2?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ArrayNullableProperty1 : MonoBehaviour, IValue<Vector2?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2?[] Value { get; set; }
	}

	public class Vector2ArrayNullableProperty2 : MonoBehaviour, IValue<Vector2?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2?[] Value { get; set; }
	}

	public class Vector2ArrayNullableProperties1 : MonoBehaviour, IValues<Vector2?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Vector2?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Vector2?[] Value2 { get; set; }
	}

	public class Vector2ArrayNullableProperties2 : MonoBehaviour, IValues<Vector2?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Vector2?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Vector2?[] Value2 { get; set; }
	}

	public class Vector2ListNullableField1 : MonoBehaviour, IValue<List<Vector2?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Vector2?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ListNullableField2 : MonoBehaviour, IValue<List<Vector2?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Vector2?> Value { get { return value; } set { this.value = value; } }
	}

	public class Vector2ListNullableFields1 : MonoBehaviour, IValues<List<Vector2?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Vector2?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Vector2?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Vector2?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ListNullableFields2 : MonoBehaviour, IValues<List<Vector2?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Vector2?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Vector2?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Vector2?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Vector2?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Vector2ListNullableProperty1 : MonoBehaviour, IValue<List<Vector2?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2?> Value { get; set; }
	}

	public class Vector2ListNullableProperty2 : MonoBehaviour, IValue<List<Vector2?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2?> Value { get; set; }
	}

	public class Vector2ListNullableProperties1 : MonoBehaviour, IValues<List<Vector2?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Vector2?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Vector2?> Value2 { get; set; }
	}

	public class Vector2ListNullableProperties2 : MonoBehaviour, IValues<List<Vector2?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Vector2?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Vector2?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618