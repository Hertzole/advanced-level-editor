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
	public class Color32Field1 : MonoBehaviour, IValue<Color32>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32 value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color32 Value { get { return value; } set { this.value = value; } }
	}

	public class Color32Field2 : MonoBehaviour, IValue<Color32>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32 value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color32 Value { get { return value; } set { this.value = value; } }
	}

	public class Color32Fields1 : MonoBehaviour, IValues<Color32>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32 value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color32 value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color32 Value1 { get { return value1; } set { value1 = value; } }
		public Color32 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32Fields2 : MonoBehaviour, IValues<Color32>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color32 value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32 value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color32 Value1 { get { return value1; } set { value1 = value; } }
		public Color32 Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32Property1 : MonoBehaviour, IValue<Color32>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32 Value { get; set; }
	}

	public class Color32Property2 : MonoBehaviour, IValue<Color32>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32 Value { get; set; }
	}

	public class Color32Properties1 : MonoBehaviour, IValues<Color32>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color32 Value2 { get; set; }
	}

	public class Color32Properties2 : MonoBehaviour, IValues<Color32>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color32 Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32 Value2 { get; set; }
	}

	public class Color32ArrayField1 : MonoBehaviour, IValue<Color32[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color32[] Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ArrayField2 : MonoBehaviour, IValue<Color32[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color32[] Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ArrayFields1 : MonoBehaviour, IValues<Color32[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color32[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color32[] Value1 { get { return value1; } set { value1 = value; } }
		public Color32[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ArrayFields2 : MonoBehaviour, IValues<Color32[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color32[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color32[] Value1 { get { return value1; } set { value1 = value; } }
		public Color32[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ArrayProperty1 : MonoBehaviour, IValue<Color32[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32[] Value { get; set; }
	}

	public class Color32ArrayProperty2 : MonoBehaviour, IValue<Color32[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32[] Value { get; set; }
	}

	public class Color32ArrayProperties1 : MonoBehaviour, IValues<Color32[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color32[] Value2 { get; set; }
	}

	public class Color32ArrayProperties2 : MonoBehaviour, IValues<Color32[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color32[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32[] Value2 { get; set; }
	}

	public class Color32ListField1 : MonoBehaviour, IValue<List<Color32>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color32> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Color32> Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ListField2 : MonoBehaviour, IValue<List<Color32>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color32> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Color32> Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ListFields1 : MonoBehaviour, IValues<List<Color32>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color32> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Color32> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Color32> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color32> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ListFields2 : MonoBehaviour, IValues<List<Color32>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Color32> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color32> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Color32> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color32> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ListProperty1 : MonoBehaviour, IValue<List<Color32>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color32> Value { get; set; }
	}

	public class Color32ListProperty2 : MonoBehaviour, IValue<List<Color32>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color32> Value { get; set; }
	}

	public class Color32ListProperties1 : MonoBehaviour, IValues<List<Color32>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color32> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Color32> Value2 { get; set; }
	}

	public class Color32ListProperties2 : MonoBehaviour, IValues<List<Color32>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Color32> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color32> Value2 { get; set; }
	}

	public class Color32NullableField1 : MonoBehaviour, IValue<Color32?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color32? Value { get { return value; } set { this.value = value; } }
	}

	public class Color32NullableField2 : MonoBehaviour, IValue<Color32?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color32? Value { get { return value; } set { this.value = value; } }
	}

	public class Color32NullableFields1 : MonoBehaviour, IValues<Color32?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color32? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color32? Value1 { get { return value1; } set { value1 = value; } }
		public Color32? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32NullableFields2 : MonoBehaviour, IValues<Color32?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color32? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color32? Value1 { get { return value1; } set { value1 = value; } }
		public Color32? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32NullableProperty1 : MonoBehaviour, IValue<Color32?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32? Value { get; set; }
	}

	public class Color32NullableProperty2 : MonoBehaviour, IValue<Color32?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32? Value { get; set; }
	}

	public class Color32NullableProperties1 : MonoBehaviour, IValues<Color32?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color32? Value2 { get; set; }
	}

	public class Color32NullableProperties2 : MonoBehaviour, IValues<Color32?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color32? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32? Value2 { get; set; }
	}

	public class Color32ArrayNullableField1 : MonoBehaviour, IValue<Color32?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color32?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ArrayNullableField2 : MonoBehaviour, IValue<Color32?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color32?[] Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ArrayNullableFields1 : MonoBehaviour, IValues<Color32?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color32?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color32?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color32?[] Value1 { get { return value1; } set { value1 = value; } }
		public Color32?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ArrayNullableFields2 : MonoBehaviour, IValues<Color32?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color32?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color32?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color32?[] Value1 { get { return value1; } set { value1 = value; } }
		public Color32?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ArrayNullableProperty1 : MonoBehaviour, IValue<Color32?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32?[] Value { get; set; }
	}

	public class Color32ArrayNullableProperty2 : MonoBehaviour, IValue<Color32?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32?[] Value { get; set; }
	}

	public class Color32ArrayNullableProperties1 : MonoBehaviour, IValues<Color32?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color32?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color32?[] Value2 { get; set; }
	}

	public class Color32ArrayNullableProperties2 : MonoBehaviour, IValues<Color32?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color32?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color32?[] Value2 { get; set; }
	}

	public class Color32ListNullableField1 : MonoBehaviour, IValue<List<Color32?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color32?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Color32?> Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ListNullableField2 : MonoBehaviour, IValue<List<Color32?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color32?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Color32?> Value { get { return value; } set { this.value = value; } }
	}

	public class Color32ListNullableFields1 : MonoBehaviour, IValues<List<Color32?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color32?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Color32?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Color32?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color32?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ListNullableFields2 : MonoBehaviour, IValues<List<Color32?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Color32?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color32?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Color32?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color32?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class Color32ListNullableProperty1 : MonoBehaviour, IValue<List<Color32?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color32?> Value { get; set; }
	}

	public class Color32ListNullableProperty2 : MonoBehaviour, IValue<List<Color32?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color32?> Value { get; set; }
	}

	public class Color32ListNullableProperties1 : MonoBehaviour, IValues<List<Color32?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color32?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Color32?> Value2 { get; set; }
	}

	public class Color32ListNullableProperties2 : MonoBehaviour, IValues<List<Color32?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Color32?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color32?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618