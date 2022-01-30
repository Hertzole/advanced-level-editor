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
	public class TransformField1 : MonoBehaviour, IValue<Transform>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Transform Value { get { return value; } set { this.value = value; } }
	}

	public class TransformField2 : MonoBehaviour, IValue<Transform>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Transform Value { get { return value; } set { this.value = value; } }
	}

	public class TransformFields1 : MonoBehaviour, IValues<Transform>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Transform value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Transform Value1 { get { return value1; } set { value1 = value; } }
		public Transform Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformFields2 : MonoBehaviour, IValues<Transform>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Transform value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Transform Value1 { get { return value1; } set { value1 = value; } }
		public Transform Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformProperty1 : MonoBehaviour, IValue<Transform>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform Value { get; set; }
	}

	public class TransformProperty2 : MonoBehaviour, IValue<Transform>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform Value { get; set; }
	}

	public class TransformProperties1 : MonoBehaviour, IValues<Transform>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Transform Value2 { get; set; }
	}

	public class TransformProperties2 : MonoBehaviour, IValues<Transform>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Transform Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform Value2 { get; set; }
	}

	public class TransformArrayField1 : MonoBehaviour, IValue<Transform[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Transform[] Value { get { return value; } set { this.value = value; } }
	}

	public class TransformArrayField2 : MonoBehaviour, IValue<Transform[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Transform[] Value { get { return value; } set { this.value = value; } }
	}

	public class TransformArrayFields1 : MonoBehaviour, IValues<Transform[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Transform[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Transform[] Value1 { get { return value1; } set { value1 = value; } }
		public Transform[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformArrayFields2 : MonoBehaviour, IValues<Transform[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Transform[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Transform[] Value1 { get { return value1; } set { value1 = value; } }
		public Transform[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformArrayProperty1 : MonoBehaviour, IValue<Transform[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform[] Value { get; set; }
	}

	public class TransformArrayProperty2 : MonoBehaviour, IValue<Transform[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform[] Value { get; set; }
	}

	public class TransformArrayProperties1 : MonoBehaviour, IValues<Transform[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Transform[] Value2 { get; set; }
	}

	public class TransformArrayProperties2 : MonoBehaviour, IValues<Transform[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Transform[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform[] Value2 { get; set; }
	}

	public class TransformListField1 : MonoBehaviour, IValue<List<Transform>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Transform> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Transform> Value { get { return value; } set { this.value = value; } }
	}

	public class TransformListField2 : MonoBehaviour, IValue<List<Transform>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Transform> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Transform> Value { get { return value; } set { this.value = value; } }
	}

	public class TransformListFields1 : MonoBehaviour, IValues<List<Transform>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Transform> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Transform> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Transform> Value1 { get { return value1; } set { value1 = value; } }
		public List<Transform> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformListFields2 : MonoBehaviour, IValues<List<Transform>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Transform> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Transform> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Transform> Value1 { get { return value1; } set { value1 = value; } }
		public List<Transform> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformListProperty1 : MonoBehaviour, IValue<List<Transform>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Transform> Value { get; set; }
	}

	public class TransformListProperty2 : MonoBehaviour, IValue<List<Transform>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Transform> Value { get; set; }
	}

	public class TransformListProperties1 : MonoBehaviour, IValues<List<Transform>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Transform> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Transform> Value2 { get; set; }
	}

	public class TransformListProperties2 : MonoBehaviour, IValues<List<Transform>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Transform> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Transform> Value2 { get; set; }
	}

	public class TransformNullableField1 : MonoBehaviour, IValue<Transform?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Transform? Value { get { return value; } set { this.value = value; } }
	}

	public class TransformNullableField2 : MonoBehaviour, IValue<Transform?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Transform? Value { get { return value; } set { this.value = value; } }
	}

	public class TransformNullableFields1 : MonoBehaviour, IValues<Transform?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Transform? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Transform? Value1 { get { return value1; } set { value1 = value; } }
		public Transform? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformNullableFields2 : MonoBehaviour, IValues<Transform?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Transform? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Transform? Value1 { get { return value1; } set { value1 = value; } }
		public Transform? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformNullableProperty1 : MonoBehaviour, IValue<Transform?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform? Value { get; set; }
	}

	public class TransformNullableProperty2 : MonoBehaviour, IValue<Transform?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform? Value { get; set; }
	}

	public class TransformNullableProperties1 : MonoBehaviour, IValues<Transform?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Transform? Value2 { get; set; }
	}

	public class TransformNullableProperties2 : MonoBehaviour, IValues<Transform?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Transform? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform? Value2 { get; set; }
	}

	public class TransformArrayNullableField1 : MonoBehaviour, IValue<Transform?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Transform?[] Value { get { return value; } set { this.value = value; } }
	}

	public class TransformArrayNullableField2 : MonoBehaviour, IValue<Transform?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Transform?[] Value { get { return value; } set { this.value = value; } }
	}

	public class TransformArrayNullableFields1 : MonoBehaviour, IValues<Transform?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Transform?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Transform?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Transform?[] Value1 { get { return value1; } set { value1 = value; } }
		public Transform?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformArrayNullableFields2 : MonoBehaviour, IValues<Transform?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Transform?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Transform?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Transform?[] Value1 { get { return value1; } set { value1 = value; } }
		public Transform?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformArrayNullableProperty1 : MonoBehaviour, IValue<Transform?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform?[] Value { get; set; }
	}

	public class TransformArrayNullableProperty2 : MonoBehaviour, IValue<Transform?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform?[] Value { get; set; }
	}

	public class TransformArrayNullableProperties1 : MonoBehaviour, IValues<Transform?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Transform?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Transform?[] Value2 { get; set; }
	}

	public class TransformArrayNullableProperties2 : MonoBehaviour, IValues<Transform?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Transform?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Transform?[] Value2 { get; set; }
	}

	public class TransformListNullableField1 : MonoBehaviour, IValue<List<Transform?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Transform?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Transform?> Value { get { return value; } set { this.value = value; } }
	}

	public class TransformListNullableField2 : MonoBehaviour, IValue<List<Transform?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Transform?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Transform?> Value { get { return value; } set { this.value = value; } }
	}

	public class TransformListNullableFields1 : MonoBehaviour, IValues<List<Transform?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Transform?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Transform?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Transform?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Transform?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformListNullableFields2 : MonoBehaviour, IValues<List<Transform?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Transform?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Transform?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Transform?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Transform?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class TransformListNullableProperty1 : MonoBehaviour, IValue<List<Transform?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Transform?> Value { get; set; }
	}

	public class TransformListNullableProperty2 : MonoBehaviour, IValue<List<Transform?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Transform?> Value { get; set; }
	}

	public class TransformListNullableProperties1 : MonoBehaviour, IValues<List<Transform?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Transform?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Transform?> Value2 { get; set; }
	}

	public class TransformListNullableProperties2 : MonoBehaviour, IValues<List<Transform?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Transform?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Transform?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618