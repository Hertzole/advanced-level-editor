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
	public class LayerMaskField1 : MonoBehaviour, IValue<LayerMask>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask value;

		public int ValueID { get { return VALUE_0_ID; } }
		public LayerMask Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskField2 : MonoBehaviour, IValue<LayerMask>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask value;

		public int ValueID { get { return VALUE_100_ID; } }
		public LayerMask Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskFields1 : MonoBehaviour, IValues<LayerMask>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private LayerMask value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public LayerMask Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskFields2 : MonoBehaviour, IValues<LayerMask>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private LayerMask value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public LayerMask Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskProperty1 : MonoBehaviour, IValue<LayerMask>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask Value { get; set; }
	}

	public class LayerMaskProperty2 : MonoBehaviour, IValue<LayerMask>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask Value { get; set; }
	}

	public class LayerMaskProperties1 : MonoBehaviour, IValues<LayerMask>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public LayerMask Value2 { get; set; }
	}

	public class LayerMaskProperties2 : MonoBehaviour, IValues<LayerMask>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public LayerMask Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask Value2 { get; set; }
	}

	public class LayerMaskArrayField1 : MonoBehaviour, IValue<LayerMask[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public LayerMask[] Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskArrayField2 : MonoBehaviour, IValue<LayerMask[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public LayerMask[] Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskArrayFields1 : MonoBehaviour, IValues<LayerMask[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private LayerMask[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public LayerMask[] Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskArrayFields2 : MonoBehaviour, IValues<LayerMask[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private LayerMask[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public LayerMask[] Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskArrayProperty1 : MonoBehaviour, IValue<LayerMask[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask[] Value { get; set; }
	}

	public class LayerMaskArrayProperty2 : MonoBehaviour, IValue<LayerMask[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask[] Value { get; set; }
	}

	public class LayerMaskArrayProperties1 : MonoBehaviour, IValues<LayerMask[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public LayerMask[] Value2 { get; set; }
	}

	public class LayerMaskArrayProperties2 : MonoBehaviour, IValues<LayerMask[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public LayerMask[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask[] Value2 { get; set; }
	}

	public class LayerMaskListField1 : MonoBehaviour, IValue<List<LayerMask>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<LayerMask> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<LayerMask> Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskListField2 : MonoBehaviour, IValue<List<LayerMask>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<LayerMask> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<LayerMask> Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskListFields1 : MonoBehaviour, IValues<List<LayerMask>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<LayerMask> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<LayerMask> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<LayerMask> Value1 { get { return value1; } set { value1 = value; } }
		public List<LayerMask> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskListFields2 : MonoBehaviour, IValues<List<LayerMask>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<LayerMask> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<LayerMask> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<LayerMask> Value1 { get { return value1; } set { value1 = value; } }
		public List<LayerMask> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskListProperty1 : MonoBehaviour, IValue<List<LayerMask>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<LayerMask> Value { get; set; }
	}

	public class LayerMaskListProperty2 : MonoBehaviour, IValue<List<LayerMask>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<LayerMask> Value { get; set; }
	}

	public class LayerMaskListProperties1 : MonoBehaviour, IValues<List<LayerMask>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<LayerMask> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<LayerMask> Value2 { get; set; }
	}

	public class LayerMaskListProperties2 : MonoBehaviour, IValues<List<LayerMask>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<LayerMask> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<LayerMask> Value2 { get; set; }
	}

	public class LayerMaskNullableField1 : MonoBehaviour, IValue<LayerMask?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public LayerMask? Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskNullableField2 : MonoBehaviour, IValue<LayerMask?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public LayerMask? Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskNullableFields1 : MonoBehaviour, IValues<LayerMask?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private LayerMask? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public LayerMask? Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskNullableFields2 : MonoBehaviour, IValues<LayerMask?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private LayerMask? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public LayerMask? Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskNullableProperty1 : MonoBehaviour, IValue<LayerMask?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask? Value { get; set; }
	}

	public class LayerMaskNullableProperty2 : MonoBehaviour, IValue<LayerMask?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask? Value { get; set; }
	}

	public class LayerMaskNullableProperties1 : MonoBehaviour, IValues<LayerMask?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public LayerMask? Value2 { get; set; }
	}

	public class LayerMaskNullableProperties2 : MonoBehaviour, IValues<LayerMask?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public LayerMask? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask? Value2 { get; set; }
	}

	public class LayerMaskArrayNullableField1 : MonoBehaviour, IValue<LayerMask?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public LayerMask?[] Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskArrayNullableField2 : MonoBehaviour, IValue<LayerMask?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public LayerMask?[] Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskArrayNullableFields1 : MonoBehaviour, IValues<LayerMask?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private LayerMask?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private LayerMask?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public LayerMask?[] Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskArrayNullableFields2 : MonoBehaviour, IValues<LayerMask?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private LayerMask?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private LayerMask?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public LayerMask?[] Value1 { get { return value1; } set { value1 = value; } }
		public LayerMask?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskArrayNullableProperty1 : MonoBehaviour, IValue<LayerMask?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask?[] Value { get; set; }
	}

	public class LayerMaskArrayNullableProperty2 : MonoBehaviour, IValue<LayerMask?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask?[] Value { get; set; }
	}

	public class LayerMaskArrayNullableProperties1 : MonoBehaviour, IValues<LayerMask?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public LayerMask?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public LayerMask?[] Value2 { get; set; }
	}

	public class LayerMaskArrayNullableProperties2 : MonoBehaviour, IValues<LayerMask?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public LayerMask?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public LayerMask?[] Value2 { get; set; }
	}

	public class LayerMaskListNullableField1 : MonoBehaviour, IValue<List<LayerMask?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<LayerMask?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<LayerMask?> Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskListNullableField2 : MonoBehaviour, IValue<List<LayerMask?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<LayerMask?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<LayerMask?> Value { get { return value; } set { this.value = value; } }
	}

	public class LayerMaskListNullableFields1 : MonoBehaviour, IValues<List<LayerMask?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<LayerMask?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<LayerMask?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<LayerMask?> Value1 { get { return value1; } set { value1 = value; } }
		public List<LayerMask?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskListNullableFields2 : MonoBehaviour, IValues<List<LayerMask?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<LayerMask?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<LayerMask?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<LayerMask?> Value1 { get { return value1; } set { value1 = value; } }
		public List<LayerMask?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class LayerMaskListNullableProperty1 : MonoBehaviour, IValue<List<LayerMask?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<LayerMask?> Value { get; set; }
	}

	public class LayerMaskListNullableProperty2 : MonoBehaviour, IValue<List<LayerMask?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<LayerMask?> Value { get; set; }
	}

	public class LayerMaskListNullableProperties1 : MonoBehaviour, IValues<List<LayerMask?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<LayerMask?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<LayerMask?> Value2 { get; set; }
	}

	public class LayerMaskListNullableProperties2 : MonoBehaviour, IValues<List<LayerMask?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<LayerMask?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<LayerMask?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618