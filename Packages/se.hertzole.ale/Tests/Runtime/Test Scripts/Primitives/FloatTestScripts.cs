// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class FloatField1 : MonoBehaviour, IValue<float>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float value;

		public int ValueID { get { return VALUE_0_ID; } }
		public float Value { get { return value; } set { this.value = value; } }
	}

	public class FloatField2 : MonoBehaviour, IValue<float>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float value;

		public int ValueID { get { return VALUE_100_ID; } }
		public float Value { get { return value; } set { this.value = value; } }
	}

	public class FloatFields1 : MonoBehaviour, IValues<float>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private float value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public float Value1 { get { return value1; } set { value1 = value; } }
		public float Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatFields2 : MonoBehaviour, IValues<float>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private float value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public float Value1 { get { return value1; } set { value1 = value; } }
		public float Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatProperty1 : MonoBehaviour, IValue<float>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float Value { get; set; }
	}

	public class FloatProperty2 : MonoBehaviour, IValue<float>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public float Value { get; set; }
	}

	public class FloatProperties1 : MonoBehaviour, IValues<float>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public float Value2 { get; set; }
	}

	public class FloatProperties2 : MonoBehaviour, IValues<float>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public float Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public float Value2 { get; set; }
	}

	public class FloatArrayField1 : MonoBehaviour, IValue<float[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public float[] Value { get { return value; } set { this.value = value; } }
	}

	public class FloatArrayField2 : MonoBehaviour, IValue<float[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public float[] Value { get { return value; } set { this.value = value; } }
	}

	public class FloatArrayFields1 : MonoBehaviour, IValues<float[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private float[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public float[] Value1 { get { return value1; } set { value1 = value; } }
		public float[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatArrayFields2 : MonoBehaviour, IValues<float[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private float[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public float[] Value1 { get { return value1; } set { value1 = value; } }
		public float[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatArrayProperty1 : MonoBehaviour, IValue<float[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float[] Value { get; set; }
	}

	public class FloatArrayProperty2 : MonoBehaviour, IValue<float[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public float[] Value { get; set; }
	}

	public class FloatArrayProperties1 : MonoBehaviour, IValues<float[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public float[] Value2 { get; set; }
	}

	public class FloatArrayProperties2 : MonoBehaviour, IValues<float[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public float[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public float[] Value2 { get; set; }
	}

	public class FloatListField1 : MonoBehaviour, IValue<List<float>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<float> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<float> Value { get { return value; } set { this.value = value; } }
	}

	public class FloatListField2 : MonoBehaviour, IValue<List<float>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<float> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<float> Value { get { return value; } set { this.value = value; } }
	}

	public class FloatListFields1 : MonoBehaviour, IValues<List<float>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<float> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<float> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<float> Value1 { get { return value1; } set { value1 = value; } }
		public List<float> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatListFields2 : MonoBehaviour, IValues<List<float>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<float> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<float> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<float> Value1 { get { return value1; } set { value1 = value; } }
		public List<float> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatListProperty1 : MonoBehaviour, IValue<List<float>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<float> Value { get; set; }
	}

	public class FloatListProperty2 : MonoBehaviour, IValue<List<float>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<float> Value { get; set; }
	}

	public class FloatListProperties1 : MonoBehaviour, IValues<List<float>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<float> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<float> Value2 { get; set; }
	}

	public class FloatListProperties2 : MonoBehaviour, IValues<List<float>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<float> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<float> Value2 { get; set; }
	}

	public class FloatNullableField1 : MonoBehaviour, IValue<float?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public float? Value { get { return value; } set { this.value = value; } }
	}

	public class FloatNullableField2 : MonoBehaviour, IValue<float?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public float? Value { get { return value; } set { this.value = value; } }
	}

	public class FloatNullableFields1 : MonoBehaviour, IValues<float?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private float? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public float? Value1 { get { return value1; } set { value1 = value; } }
		public float? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatNullableFields2 : MonoBehaviour, IValues<float?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private float? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public float? Value1 { get { return value1; } set { value1 = value; } }
		public float? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatNullableProperty1 : MonoBehaviour, IValue<float?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float? Value { get; set; }
	}

	public class FloatNullableProperty2 : MonoBehaviour, IValue<float?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public float? Value { get; set; }
	}

	public class FloatNullableProperties1 : MonoBehaviour, IValues<float?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public float? Value2 { get; set; }
	}

	public class FloatNullableProperties2 : MonoBehaviour, IValues<float?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public float? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public float? Value2 { get; set; }
	}

	public class FloatArrayNullableField1 : MonoBehaviour, IValue<float?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public float?[] Value { get { return value; } set { this.value = value; } }
	}

	public class FloatArrayNullableField2 : MonoBehaviour, IValue<float?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public float?[] Value { get { return value; } set { this.value = value; } }
	}

	public class FloatArrayNullableFields1 : MonoBehaviour, IValues<float?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private float?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private float?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public float?[] Value1 { get { return value1; } set { value1 = value; } }
		public float?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatArrayNullableFields2 : MonoBehaviour, IValues<float?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private float?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private float?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public float?[] Value1 { get { return value1; } set { value1 = value; } }
		public float?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatArrayNullableProperty1 : MonoBehaviour, IValue<float?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float?[] Value { get; set; }
	}

	public class FloatArrayNullableProperty2 : MonoBehaviour, IValue<float?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public float?[] Value { get; set; }
	}

	public class FloatArrayNullableProperties1 : MonoBehaviour, IValues<float?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public float?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public float?[] Value2 { get; set; }
	}

	public class FloatArrayNullableProperties2 : MonoBehaviour, IValues<float?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public float?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public float?[] Value2 { get; set; }
	}

	public class FloatListNullableField1 : MonoBehaviour, IValue<List<float?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<float?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<float?> Value { get { return value; } set { this.value = value; } }
	}

	public class FloatListNullableField2 : MonoBehaviour, IValue<List<float?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<float?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<float?> Value { get { return value; } set { this.value = value; } }
	}

	public class FloatListNullableFields1 : MonoBehaviour, IValues<List<float?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<float?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<float?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<float?> Value1 { get { return value1; } set { value1 = value; } }
		public List<float?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatListNullableFields2 : MonoBehaviour, IValues<List<float?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<float?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<float?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<float?> Value1 { get { return value1; } set { value1 = value; } }
		public List<float?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class FloatListNullableProperty1 : MonoBehaviour, IValue<List<float?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<float?> Value { get; set; }
	}

	public class FloatListNullableProperty2 : MonoBehaviour, IValue<List<float?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<float?> Value { get; set; }
	}

	public class FloatListNullableProperties1 : MonoBehaviour, IValues<List<float?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<float?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<float?> Value2 { get; set; }
	}

	public class FloatListNullableProperties2 : MonoBehaviour, IValues<List<float?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<float?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<float?> Value2 { get; set; }
	}
}