// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class DoubleField1 : MonoBehaviour, IValue<double>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double value;

		public int ValueID { get { return VALUE_0_ID; } }
		public double Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleField2 : MonoBehaviour, IValue<double>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double value;

		public int ValueID { get { return VALUE_100_ID; } }
		public double Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleFields1 : MonoBehaviour, IValues<double>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private double value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public double Value1 { get { return value1; } set { value1 = value; } }
		public double Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleFields2 : MonoBehaviour, IValues<double>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private double value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public double Value1 { get { return value1; } set { value1 = value; } }
		public double Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleProperty1 : MonoBehaviour, IValue<double>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double Value { get; set; }
	}

	public class DoubleProperty2 : MonoBehaviour, IValue<double>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public double Value { get; set; }
	}

	public class DoubleProperties1 : MonoBehaviour, IValues<double>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public double Value2 { get; set; }
	}

	public class DoubleProperties2 : MonoBehaviour, IValues<double>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public double Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public double Value2 { get; set; }
	}

	public class DoubleArrayField1 : MonoBehaviour, IValue<double[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public double[] Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleArrayField2 : MonoBehaviour, IValue<double[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public double[] Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleArrayFields1 : MonoBehaviour, IValues<double[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private double[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public double[] Value1 { get { return value1; } set { value1 = value; } }
		public double[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleArrayFields2 : MonoBehaviour, IValues<double[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private double[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public double[] Value1 { get { return value1; } set { value1 = value; } }
		public double[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleArrayProperty1 : MonoBehaviour, IValue<double[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double[] Value { get; set; }
	}

	public class DoubleArrayProperty2 : MonoBehaviour, IValue<double[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public double[] Value { get; set; }
	}

	public class DoubleArrayProperties1 : MonoBehaviour, IValues<double[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public double[] Value2 { get; set; }
	}

	public class DoubleArrayProperties2 : MonoBehaviour, IValues<double[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public double[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public double[] Value2 { get; set; }
	}

	public class DoubleListField1 : MonoBehaviour, IValue<List<double>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<double> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<double> Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleListField2 : MonoBehaviour, IValue<List<double>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<double> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<double> Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleListFields1 : MonoBehaviour, IValues<List<double>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<double> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<double> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<double> Value1 { get { return value1; } set { value1 = value; } }
		public List<double> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleListFields2 : MonoBehaviour, IValues<List<double>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<double> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<double> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<double> Value1 { get { return value1; } set { value1 = value; } }
		public List<double> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleListProperty1 : MonoBehaviour, IValue<List<double>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<double> Value { get; set; }
	}

	public class DoubleListProperty2 : MonoBehaviour, IValue<List<double>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<double> Value { get; set; }
	}

	public class DoubleListProperties1 : MonoBehaviour, IValues<List<double>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<double> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<double> Value2 { get; set; }
	}

	public class DoubleListProperties2 : MonoBehaviour, IValues<List<double>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<double> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<double> Value2 { get; set; }
	}

	public class DoubleNullableField1 : MonoBehaviour, IValue<double?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public double? Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleNullableField2 : MonoBehaviour, IValue<double?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public double? Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleNullableFields1 : MonoBehaviour, IValues<double?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private double? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public double? Value1 { get { return value1; } set { value1 = value; } }
		public double? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleNullableFields2 : MonoBehaviour, IValues<double?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private double? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public double? Value1 { get { return value1; } set { value1 = value; } }
		public double? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleNullableProperty1 : MonoBehaviour, IValue<double?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double? Value { get; set; }
	}

	public class DoubleNullableProperty2 : MonoBehaviour, IValue<double?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public double? Value { get; set; }
	}

	public class DoubleNullableProperties1 : MonoBehaviour, IValues<double?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public double? Value2 { get; set; }
	}

	public class DoubleNullableProperties2 : MonoBehaviour, IValues<double?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public double? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public double? Value2 { get; set; }
	}

	public class DoubleArrayNullableField1 : MonoBehaviour, IValue<double?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public double?[] Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleArrayNullableField2 : MonoBehaviour, IValue<double?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public double?[] Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleArrayNullableFields1 : MonoBehaviour, IValues<double?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private double?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private double?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public double?[] Value1 { get { return value1; } set { value1 = value; } }
		public double?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleArrayNullableFields2 : MonoBehaviour, IValues<double?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private double?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private double?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public double?[] Value1 { get { return value1; } set { value1 = value; } }
		public double?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleArrayNullableProperty1 : MonoBehaviour, IValue<double?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double?[] Value { get; set; }
	}

	public class DoubleArrayNullableProperty2 : MonoBehaviour, IValue<double?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public double?[] Value { get; set; }
	}

	public class DoubleArrayNullableProperties1 : MonoBehaviour, IValues<double?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public double?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public double?[] Value2 { get; set; }
	}

	public class DoubleArrayNullableProperties2 : MonoBehaviour, IValues<double?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public double?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public double?[] Value2 { get; set; }
	}

	public class DoubleListNullableField1 : MonoBehaviour, IValue<List<double?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<double?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<double?> Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleListNullableField2 : MonoBehaviour, IValue<List<double?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<double?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<double?> Value { get { return value; } set { this.value = value; } }
	}

	public class DoubleListNullableFields1 : MonoBehaviour, IValues<List<double?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<double?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<double?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<double?> Value1 { get { return value1; } set { value1 = value; } }
		public List<double?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleListNullableFields2 : MonoBehaviour, IValues<List<double?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<double?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<double?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<double?> Value1 { get { return value1; } set { value1 = value; } }
		public List<double?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DoubleListNullableProperty1 : MonoBehaviour, IValue<List<double?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<double?> Value { get; set; }
	}

	public class DoubleListNullableProperty2 : MonoBehaviour, IValue<List<double?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<double?> Value { get; set; }
	}

	public class DoubleListNullableProperties1 : MonoBehaviour, IValues<List<double?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<double?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<double?> Value2 { get; set; }
	}

	public class DoubleListNullableProperties2 : MonoBehaviour, IValues<List<double?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<double?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<double?> Value2 { get; set; }
	}
}