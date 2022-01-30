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
	public class AnimationCurveField1 : MonoBehaviour, IValue<AnimationCurve>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve value;

		public int ValueID { get { return VALUE_0_ID; } }
		public AnimationCurve Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveField2 : MonoBehaviour, IValue<AnimationCurve>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve value;

		public int ValueID { get { return VALUE_100_ID; } }
		public AnimationCurve Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveFields1 : MonoBehaviour, IValues<AnimationCurve>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private AnimationCurve value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public AnimationCurve Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveFields2 : MonoBehaviour, IValues<AnimationCurve>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private AnimationCurve value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public AnimationCurve Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveProperty1 : MonoBehaviour, IValue<AnimationCurve>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve Value { get; set; }
	}

	public class AnimationCurveProperty2 : MonoBehaviour, IValue<AnimationCurve>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve Value { get; set; }
	}

	public class AnimationCurveProperties1 : MonoBehaviour, IValues<AnimationCurve>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public AnimationCurve Value2 { get; set; }
	}

	public class AnimationCurveProperties2 : MonoBehaviour, IValues<AnimationCurve>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public AnimationCurve Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve Value2 { get; set; }
	}

	public class AnimationCurveArrayField1 : MonoBehaviour, IValue<AnimationCurve[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public AnimationCurve[] Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveArrayField2 : MonoBehaviour, IValue<AnimationCurve[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public AnimationCurve[] Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveArrayFields1 : MonoBehaviour, IValues<AnimationCurve[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private AnimationCurve[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public AnimationCurve[] Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveArrayFields2 : MonoBehaviour, IValues<AnimationCurve[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private AnimationCurve[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public AnimationCurve[] Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveArrayProperty1 : MonoBehaviour, IValue<AnimationCurve[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve[] Value { get; set; }
	}

	public class AnimationCurveArrayProperty2 : MonoBehaviour, IValue<AnimationCurve[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve[] Value { get; set; }
	}

	public class AnimationCurveArrayProperties1 : MonoBehaviour, IValues<AnimationCurve[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public AnimationCurve[] Value2 { get; set; }
	}

	public class AnimationCurveArrayProperties2 : MonoBehaviour, IValues<AnimationCurve[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public AnimationCurve[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve[] Value2 { get; set; }
	}

	public class AnimationCurveListField1 : MonoBehaviour, IValue<List<AnimationCurve>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<AnimationCurve> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<AnimationCurve> Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveListField2 : MonoBehaviour, IValue<List<AnimationCurve>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<AnimationCurve> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<AnimationCurve> Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveListFields1 : MonoBehaviour, IValues<List<AnimationCurve>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<AnimationCurve> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<AnimationCurve> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<AnimationCurve> Value1 { get { return value1; } set { value1 = value; } }
		public List<AnimationCurve> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveListFields2 : MonoBehaviour, IValues<List<AnimationCurve>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<AnimationCurve> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<AnimationCurve> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<AnimationCurve> Value1 { get { return value1; } set { value1 = value; } }
		public List<AnimationCurve> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveListProperty1 : MonoBehaviour, IValue<List<AnimationCurve>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<AnimationCurve> Value { get; set; }
	}

	public class AnimationCurveListProperty2 : MonoBehaviour, IValue<List<AnimationCurve>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<AnimationCurve> Value { get; set; }
	}

	public class AnimationCurveListProperties1 : MonoBehaviour, IValues<List<AnimationCurve>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<AnimationCurve> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<AnimationCurve> Value2 { get; set; }
	}

	public class AnimationCurveListProperties2 : MonoBehaviour, IValues<List<AnimationCurve>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<AnimationCurve> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<AnimationCurve> Value2 { get; set; }
	}

	public class AnimationCurveNullableField1 : MonoBehaviour, IValue<AnimationCurve?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public AnimationCurve? Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveNullableField2 : MonoBehaviour, IValue<AnimationCurve?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public AnimationCurve? Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveNullableFields1 : MonoBehaviour, IValues<AnimationCurve?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private AnimationCurve? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public AnimationCurve? Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveNullableFields2 : MonoBehaviour, IValues<AnimationCurve?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private AnimationCurve? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public AnimationCurve? Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveNullableProperty1 : MonoBehaviour, IValue<AnimationCurve?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve? Value { get; set; }
	}

	public class AnimationCurveNullableProperty2 : MonoBehaviour, IValue<AnimationCurve?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve? Value { get; set; }
	}

	public class AnimationCurveNullableProperties1 : MonoBehaviour, IValues<AnimationCurve?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public AnimationCurve? Value2 { get; set; }
	}

	public class AnimationCurveNullableProperties2 : MonoBehaviour, IValues<AnimationCurve?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public AnimationCurve? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve? Value2 { get; set; }
	}

	public class AnimationCurveArrayNullableField1 : MonoBehaviour, IValue<AnimationCurve?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public AnimationCurve?[] Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveArrayNullableField2 : MonoBehaviour, IValue<AnimationCurve?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public AnimationCurve?[] Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveArrayNullableFields1 : MonoBehaviour, IValues<AnimationCurve?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private AnimationCurve?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private AnimationCurve?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public AnimationCurve?[] Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveArrayNullableFields2 : MonoBehaviour, IValues<AnimationCurve?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private AnimationCurve?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private AnimationCurve?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public AnimationCurve?[] Value1 { get { return value1; } set { value1 = value; } }
		public AnimationCurve?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveArrayNullableProperty1 : MonoBehaviour, IValue<AnimationCurve?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve?[] Value { get; set; }
	}

	public class AnimationCurveArrayNullableProperty2 : MonoBehaviour, IValue<AnimationCurve?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve?[] Value { get; set; }
	}

	public class AnimationCurveArrayNullableProperties1 : MonoBehaviour, IValues<AnimationCurve?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public AnimationCurve?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public AnimationCurve?[] Value2 { get; set; }
	}

	public class AnimationCurveArrayNullableProperties2 : MonoBehaviour, IValues<AnimationCurve?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public AnimationCurve?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public AnimationCurve?[] Value2 { get; set; }
	}

	public class AnimationCurveListNullableField1 : MonoBehaviour, IValue<List<AnimationCurve?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<AnimationCurve?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<AnimationCurve?> Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveListNullableField2 : MonoBehaviour, IValue<List<AnimationCurve?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<AnimationCurve?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<AnimationCurve?> Value { get { return value; } set { this.value = value; } }
	}

	public class AnimationCurveListNullableFields1 : MonoBehaviour, IValues<List<AnimationCurve?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<AnimationCurve?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<AnimationCurve?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<AnimationCurve?> Value1 { get { return value1; } set { value1 = value; } }
		public List<AnimationCurve?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveListNullableFields2 : MonoBehaviour, IValues<List<AnimationCurve?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<AnimationCurve?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<AnimationCurve?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<AnimationCurve?> Value1 { get { return value1; } set { value1 = value; } }
		public List<AnimationCurve?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class AnimationCurveListNullableProperty1 : MonoBehaviour, IValue<List<AnimationCurve?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<AnimationCurve?> Value { get; set; }
	}

	public class AnimationCurveListNullableProperty2 : MonoBehaviour, IValue<List<AnimationCurve?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<AnimationCurve?> Value { get; set; }
	}

	public class AnimationCurveListNullableProperties1 : MonoBehaviour, IValues<List<AnimationCurve?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<AnimationCurve?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<AnimationCurve?> Value2 { get; set; }
	}

	public class AnimationCurveListNullableProperties2 : MonoBehaviour, IValues<List<AnimationCurve?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<AnimationCurve?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<AnimationCurve?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618