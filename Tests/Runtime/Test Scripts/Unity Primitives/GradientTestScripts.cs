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
	public class GradientField1 : MonoBehaviour, IValue<Gradient>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Gradient Value { get { return value; } set { this.value = value; } }
	}

	public class GradientField2 : MonoBehaviour, IValue<Gradient>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Gradient Value { get { return value; } set { this.value = value; } }
	}

	public class GradientFields1 : MonoBehaviour, IValues<Gradient>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Gradient value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Gradient Value1 { get { return value1; } set { value1 = value; } }
		public Gradient Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientFields2 : MonoBehaviour, IValues<Gradient>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Gradient value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Gradient Value1 { get { return value1; } set { value1 = value; } }
		public Gradient Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientProperty1 : MonoBehaviour, IValue<Gradient>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient Value { get; set; }
	}

	public class GradientProperty2 : MonoBehaviour, IValue<Gradient>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient Value { get; set; }
	}

	public class GradientProperties1 : MonoBehaviour, IValues<Gradient>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Gradient Value2 { get; set; }
	}

	public class GradientProperties2 : MonoBehaviour, IValues<Gradient>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Gradient Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient Value2 { get; set; }
	}

	public class GradientArrayField1 : MonoBehaviour, IValue<Gradient[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Gradient[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientArrayField2 : MonoBehaviour, IValue<Gradient[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Gradient[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientArrayFields1 : MonoBehaviour, IValues<Gradient[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Gradient[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Gradient[] Value1 { get { return value1; } set { value1 = value; } }
		public Gradient[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientArrayFields2 : MonoBehaviour, IValues<Gradient[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Gradient[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Gradient[] Value1 { get { return value1; } set { value1 = value; } }
		public Gradient[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientArrayProperty1 : MonoBehaviour, IValue<Gradient[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient[] Value { get; set; }
	}

	public class GradientArrayProperty2 : MonoBehaviour, IValue<Gradient[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient[] Value { get; set; }
	}

	public class GradientArrayProperties1 : MonoBehaviour, IValues<Gradient[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Gradient[] Value2 { get; set; }
	}

	public class GradientArrayProperties2 : MonoBehaviour, IValues<Gradient[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Gradient[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient[] Value2 { get; set; }
	}

	public class GradientListField1 : MonoBehaviour, IValue<List<Gradient>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Gradient> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Gradient> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientListField2 : MonoBehaviour, IValue<List<Gradient>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Gradient> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Gradient> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientListFields1 : MonoBehaviour, IValues<List<Gradient>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Gradient> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Gradient> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Gradient> Value1 { get { return value1; } set { value1 = value; } }
		public List<Gradient> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientListFields2 : MonoBehaviour, IValues<List<Gradient>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Gradient> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Gradient> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Gradient> Value1 { get { return value1; } set { value1 = value; } }
		public List<Gradient> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientListProperty1 : MonoBehaviour, IValue<List<Gradient>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Gradient> Value { get; set; }
	}

	public class GradientListProperty2 : MonoBehaviour, IValue<List<Gradient>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Gradient> Value { get; set; }
	}

	public class GradientListProperties1 : MonoBehaviour, IValues<List<Gradient>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Gradient> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Gradient> Value2 { get; set; }
	}

	public class GradientListProperties2 : MonoBehaviour, IValues<List<Gradient>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Gradient> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Gradient> Value2 { get; set; }
	}

	public class GradientNullableField1 : MonoBehaviour, IValue<Gradient?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Gradient? Value { get { return value; } set { this.value = value; } }
	}

	public class GradientNullableField2 : MonoBehaviour, IValue<Gradient?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Gradient? Value { get { return value; } set { this.value = value; } }
	}

	public class GradientNullableFields1 : MonoBehaviour, IValues<Gradient?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Gradient? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Gradient? Value1 { get { return value1; } set { value1 = value; } }
		public Gradient? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientNullableFields2 : MonoBehaviour, IValues<Gradient?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Gradient? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Gradient? Value1 { get { return value1; } set { value1 = value; } }
		public Gradient? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientNullableProperty1 : MonoBehaviour, IValue<Gradient?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient? Value { get; set; }
	}

	public class GradientNullableProperty2 : MonoBehaviour, IValue<Gradient?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient? Value { get; set; }
	}

	public class GradientNullableProperties1 : MonoBehaviour, IValues<Gradient?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Gradient? Value2 { get; set; }
	}

	public class GradientNullableProperties2 : MonoBehaviour, IValues<Gradient?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Gradient? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient? Value2 { get; set; }
	}

	public class GradientArrayNullableField1 : MonoBehaviour, IValue<Gradient?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Gradient?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientArrayNullableField2 : MonoBehaviour, IValue<Gradient?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Gradient?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientArrayNullableFields1 : MonoBehaviour, IValues<Gradient?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Gradient?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Gradient?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Gradient?[] Value1 { get { return value1; } set { value1 = value; } }
		public Gradient?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientArrayNullableFields2 : MonoBehaviour, IValues<Gradient?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Gradient?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Gradient?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Gradient?[] Value1 { get { return value1; } set { value1 = value; } }
		public Gradient?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientArrayNullableProperty1 : MonoBehaviour, IValue<Gradient?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient?[] Value { get; set; }
	}

	public class GradientArrayNullableProperty2 : MonoBehaviour, IValue<Gradient?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient?[] Value { get; set; }
	}

	public class GradientArrayNullableProperties1 : MonoBehaviour, IValues<Gradient?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Gradient?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Gradient?[] Value2 { get; set; }
	}

	public class GradientArrayNullableProperties2 : MonoBehaviour, IValues<Gradient?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Gradient?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Gradient?[] Value2 { get; set; }
	}

	public class GradientListNullableField1 : MonoBehaviour, IValue<List<Gradient?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Gradient?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Gradient?> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientListNullableField2 : MonoBehaviour, IValue<List<Gradient?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Gradient?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Gradient?> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientListNullableFields1 : MonoBehaviour, IValues<List<Gradient?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Gradient?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Gradient?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Gradient?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Gradient?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientListNullableFields2 : MonoBehaviour, IValues<List<Gradient?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Gradient?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Gradient?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Gradient?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Gradient?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientListNullableProperty1 : MonoBehaviour, IValue<List<Gradient?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Gradient?> Value { get; set; }
	}

	public class GradientListNullableProperty2 : MonoBehaviour, IValue<List<Gradient?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Gradient?> Value { get; set; }
	}

	public class GradientListNullableProperties1 : MonoBehaviour, IValues<List<Gradient?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Gradient?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Gradient?> Value2 { get; set; }
	}

	public class GradientListNullableProperties2 : MonoBehaviour, IValues<List<Gradient?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Gradient?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Gradient?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618