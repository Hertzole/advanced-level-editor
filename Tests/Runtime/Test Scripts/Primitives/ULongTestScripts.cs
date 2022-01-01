// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class ULongField1 : MonoBehaviour, IValue<ulong>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong Value { get { return value; } set { this.value = value; } }
	}

	public class ULongField2 : MonoBehaviour, IValue<ulong>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong Value { get { return value; } set { this.value = value; } }
	}

	public class ULongFields1 : MonoBehaviour, IValues<ulong>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ulong value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ulong Value1 { get { return value1; } set { value1 = value; } }
		public ulong Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongFields2 : MonoBehaviour, IValues<ulong>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ulong value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ulong Value1 { get { return value1; } set { value1 = value; } }
		public ulong Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongProperty1 : MonoBehaviour, IValue<ulong>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong Value { get; set; }
	}

	public class ULongProperty2 : MonoBehaviour, IValue<ulong>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong Value { get; set; }
	}

	public class ULongProperties1 : MonoBehaviour, IValues<ulong>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong Value2 { get; set; }
	}

	public class ULongProperties2 : MonoBehaviour, IValues<ulong>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong Value2 { get; set; }
	}

	public class ULongArrayField1 : MonoBehaviour, IValue<ulong[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong[] Value { get { return value; } set { this.value = value; } }
	}

	public class ULongArrayField2 : MonoBehaviour, IValue<ulong[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong[] Value { get { return value; } set { this.value = value; } }
	}

	public class ULongArrayFields1 : MonoBehaviour, IValues<ulong[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ulong[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ulong[] Value1 { get { return value1; } set { value1 = value; } }
		public ulong[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongArrayFields2 : MonoBehaviour, IValues<ulong[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ulong[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ulong[] Value1 { get { return value1; } set { value1 = value; } }
		public ulong[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongArrayProperty1 : MonoBehaviour, IValue<ulong[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong[] Value { get; set; }
	}

	public class ULongArrayProperty2 : MonoBehaviour, IValue<ulong[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong[] Value { get; set; }
	}

	public class ULongArrayProperties1 : MonoBehaviour, IValues<ulong[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong[] Value2 { get; set; }
	}

	public class ULongArrayProperties2 : MonoBehaviour, IValues<ulong[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong[] Value2 { get; set; }
	}

	public class ULongListField1 : MonoBehaviour, IValue<List<ulong>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ulong> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ulong> Value { get { return value; } set { this.value = value; } }
	}

	public class ULongListField2 : MonoBehaviour, IValue<List<ulong>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ulong> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ulong> Value { get { return value; } set { this.value = value; } }
	}

	public class ULongListFields1 : MonoBehaviour, IValues<List<ulong>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ulong> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<ulong> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<ulong> Value1 { get { return value1; } set { value1 = value; } }
		public List<ulong> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongListFields2 : MonoBehaviour, IValues<List<ulong>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<ulong> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ulong> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<ulong> Value1 { get { return value1; } set { value1 = value; } }
		public List<ulong> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongListProperty1 : MonoBehaviour, IValue<List<ulong>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong> Value { get; set; }
	}

	public class ULongListProperty2 : MonoBehaviour, IValue<List<ulong>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong> Value { get; set; }
	}

	public class ULongListProperties1 : MonoBehaviour, IValues<List<ulong>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ulong> Value2 { get; set; }
	}

	public class ULongListProperties2 : MonoBehaviour, IValues<List<ulong>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ulong> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong> Value2 { get; set; }
	}

	public class ULongNullableField1 : MonoBehaviour, IValue<ulong?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong? Value { get { return value; } set { this.value = value; } }
	}

	public class ULongNullableField2 : MonoBehaviour, IValue<ulong?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong? Value { get { return value; } set { this.value = value; } }
	}

	public class ULongNullableFields1 : MonoBehaviour, IValues<ulong?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ulong? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ulong? Value1 { get { return value1; } set { value1 = value; } }
		public ulong? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongNullableFields2 : MonoBehaviour, IValues<ulong?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ulong? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ulong? Value1 { get { return value1; } set { value1 = value; } }
		public ulong? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongNullableProperty1 : MonoBehaviour, IValue<ulong?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong? Value { get; set; }
	}

	public class ULongNullableProperty2 : MonoBehaviour, IValue<ulong?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong? Value { get; set; }
	}

	public class ULongNullableProperties1 : MonoBehaviour, IValues<ulong?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong? Value2 { get; set; }
	}

	public class ULongNullableProperties2 : MonoBehaviour, IValues<ulong?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong? Value2 { get; set; }
	}

	public class ULongArrayNullableField1 : MonoBehaviour, IValue<ulong?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ULongArrayNullableField2 : MonoBehaviour, IValue<ulong?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ULongArrayNullableFields1 : MonoBehaviour, IValues<ulong?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ulong?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ulong?[] Value1 { get { return value1; } set { value1 = value; } }
		public ulong?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongArrayNullableFields2 : MonoBehaviour, IValues<ulong?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ulong?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ulong?[] Value1 { get { return value1; } set { value1 = value; } }
		public ulong?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongArrayNullableProperty1 : MonoBehaviour, IValue<ulong?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong?[] Value { get; set; }
	}

	public class ULongArrayNullableProperty2 : MonoBehaviour, IValue<ulong?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong?[] Value { get; set; }
	}

	public class ULongArrayNullableProperties1 : MonoBehaviour, IValues<ulong?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong?[] Value2 { get; set; }
	}

	public class ULongArrayNullableProperties2 : MonoBehaviour, IValues<ulong?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong?[] Value2 { get; set; }
	}

	public class ULongListNullableField1 : MonoBehaviour, IValue<List<ulong?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ulong?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ulong?> Value { get { return value; } set { this.value = value; } }
	}

	public class ULongListNullableField2 : MonoBehaviour, IValue<List<ulong?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ulong?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ulong?> Value { get { return value; } set { this.value = value; } }
	}

	public class ULongListNullableFields1 : MonoBehaviour, IValues<List<ulong?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ulong?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<ulong?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<ulong?> Value1 { get { return value1; } set { value1 = value; } }
		public List<ulong?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongListNullableFields2 : MonoBehaviour, IValues<List<ulong?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<ulong?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ulong?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<ulong?> Value1 { get { return value1; } set { value1 = value; } }
		public List<ulong?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ULongListNullableProperty1 : MonoBehaviour, IValue<List<ulong?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong?> Value { get; set; }
	}

	public class ULongListNullableProperty2 : MonoBehaviour, IValue<List<ulong?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong?> Value { get; set; }
	}

	public class ULongListNullableProperties1 : MonoBehaviour, IValues<List<ulong?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ulong?> Value2 { get; set; }
	}

	public class ULongListNullableProperties2 : MonoBehaviour, IValues<List<ulong?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ulong?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong?> Value2 { get; set; }
	}
}