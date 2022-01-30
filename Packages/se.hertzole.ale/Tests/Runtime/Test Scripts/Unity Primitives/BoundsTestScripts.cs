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
	public class BoundsField1 : MonoBehaviour, IValue<Bounds>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Bounds Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsField2 : MonoBehaviour, IValue<Bounds>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Bounds Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsFields1 : MonoBehaviour, IValues<Bounds>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Bounds value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Bounds Value1 { get { return value1; } set { value1 = value; } }
		public Bounds Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsFields2 : MonoBehaviour, IValues<Bounds>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Bounds value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Bounds Value1 { get { return value1; } set { value1 = value; } }
		public Bounds Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsProperty1 : MonoBehaviour, IValue<Bounds>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds Value { get; set; }
	}

	public class BoundsProperty2 : MonoBehaviour, IValue<Bounds>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds Value { get; set; }
	}

	public class BoundsProperties1 : MonoBehaviour, IValues<Bounds>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Bounds Value2 { get; set; }
	}

	public class BoundsProperties2 : MonoBehaviour, IValues<Bounds>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Bounds Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds Value2 { get; set; }
	}

	public class BoundsArrayField1 : MonoBehaviour, IValue<Bounds[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Bounds[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsArrayField2 : MonoBehaviour, IValue<Bounds[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Bounds[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsArrayFields1 : MonoBehaviour, IValues<Bounds[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Bounds[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Bounds[] Value1 { get { return value1; } set { value1 = value; } }
		public Bounds[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsArrayFields2 : MonoBehaviour, IValues<Bounds[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Bounds[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Bounds[] Value1 { get { return value1; } set { value1 = value; } }
		public Bounds[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsArrayProperty1 : MonoBehaviour, IValue<Bounds[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds[] Value { get; set; }
	}

	public class BoundsArrayProperty2 : MonoBehaviour, IValue<Bounds[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds[] Value { get; set; }
	}

	public class BoundsArrayProperties1 : MonoBehaviour, IValues<Bounds[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Bounds[] Value2 { get; set; }
	}

	public class BoundsArrayProperties2 : MonoBehaviour, IValues<Bounds[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Bounds[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds[] Value2 { get; set; }
	}

	public class BoundsListField1 : MonoBehaviour, IValue<List<Bounds>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Bounds> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Bounds> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsListField2 : MonoBehaviour, IValue<List<Bounds>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Bounds> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Bounds> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsListFields1 : MonoBehaviour, IValues<List<Bounds>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Bounds> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Bounds> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Bounds> Value1 { get { return value1; } set { value1 = value; } }
		public List<Bounds> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsListFields2 : MonoBehaviour, IValues<List<Bounds>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Bounds> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Bounds> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Bounds> Value1 { get { return value1; } set { value1 = value; } }
		public List<Bounds> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsListProperty1 : MonoBehaviour, IValue<List<Bounds>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Bounds> Value { get; set; }
	}

	public class BoundsListProperty2 : MonoBehaviour, IValue<List<Bounds>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Bounds> Value { get; set; }
	}

	public class BoundsListProperties1 : MonoBehaviour, IValues<List<Bounds>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Bounds> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Bounds> Value2 { get; set; }
	}

	public class BoundsListProperties2 : MonoBehaviour, IValues<List<Bounds>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Bounds> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Bounds> Value2 { get; set; }
	}

	public class BoundsNullableField1 : MonoBehaviour, IValue<Bounds?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Bounds? Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsNullableField2 : MonoBehaviour, IValue<Bounds?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Bounds? Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsNullableFields1 : MonoBehaviour, IValues<Bounds?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Bounds? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Bounds? Value1 { get { return value1; } set { value1 = value; } }
		public Bounds? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsNullableFields2 : MonoBehaviour, IValues<Bounds?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Bounds? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Bounds? Value1 { get { return value1; } set { value1 = value; } }
		public Bounds? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsNullableProperty1 : MonoBehaviour, IValue<Bounds?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds? Value { get; set; }
	}

	public class BoundsNullableProperty2 : MonoBehaviour, IValue<Bounds?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds? Value { get; set; }
	}

	public class BoundsNullableProperties1 : MonoBehaviour, IValues<Bounds?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Bounds? Value2 { get; set; }
	}

	public class BoundsNullableProperties2 : MonoBehaviour, IValues<Bounds?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Bounds? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds? Value2 { get; set; }
	}

	public class BoundsArrayNullableField1 : MonoBehaviour, IValue<Bounds?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Bounds?[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsArrayNullableField2 : MonoBehaviour, IValue<Bounds?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Bounds?[] Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsArrayNullableFields1 : MonoBehaviour, IValues<Bounds?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Bounds?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Bounds?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Bounds?[] Value1 { get { return value1; } set { value1 = value; } }
		public Bounds?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsArrayNullableFields2 : MonoBehaviour, IValues<Bounds?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Bounds?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Bounds?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Bounds?[] Value1 { get { return value1; } set { value1 = value; } }
		public Bounds?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsArrayNullableProperty1 : MonoBehaviour, IValue<Bounds?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds?[] Value { get; set; }
	}

	public class BoundsArrayNullableProperty2 : MonoBehaviour, IValue<Bounds?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds?[] Value { get; set; }
	}

	public class BoundsArrayNullableProperties1 : MonoBehaviour, IValues<Bounds?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Bounds?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Bounds?[] Value2 { get; set; }
	}

	public class BoundsArrayNullableProperties2 : MonoBehaviour, IValues<Bounds?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Bounds?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Bounds?[] Value2 { get; set; }
	}

	public class BoundsListNullableField1 : MonoBehaviour, IValue<List<Bounds?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Bounds?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Bounds?> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsListNullableField2 : MonoBehaviour, IValue<List<Bounds?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Bounds?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Bounds?> Value { get { return value; } set { this.value = value; } }
	}

	public class BoundsListNullableFields1 : MonoBehaviour, IValues<List<Bounds?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Bounds?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Bounds?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Bounds?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Bounds?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsListNullableFields2 : MonoBehaviour, IValues<List<Bounds?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Bounds?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Bounds?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Bounds?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Bounds?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class BoundsListNullableProperty1 : MonoBehaviour, IValue<List<Bounds?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Bounds?> Value { get; set; }
	}

	public class BoundsListNullableProperty2 : MonoBehaviour, IValue<List<Bounds?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Bounds?> Value { get; set; }
	}

	public class BoundsListNullableProperties1 : MonoBehaviour, IValues<List<Bounds?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Bounds?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Bounds?> Value2 { get; set; }
	}

	public class BoundsListNullableProperties2 : MonoBehaviour, IValues<List<Bounds?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Bounds?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Bounds?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618