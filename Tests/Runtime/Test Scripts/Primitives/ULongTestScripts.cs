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
	public class UlongField1 : MonoBehaviour, IValue<ulong>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong Value { get { return value; } set { this.value = value; } }
	}

	public class UlongField2 : MonoBehaviour, IValue<ulong>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong Value { get { return value; } set { this.value = value; } }
	}

	public class UlongFields1 : MonoBehaviour, IValues<ulong>
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

	public class UlongFields2 : MonoBehaviour, IValues<ulong>
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

	public class UlongProperty1 : MonoBehaviour, IValue<ulong>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong Value { get; set; }
	}

	public class UlongProperty2 : MonoBehaviour, IValue<ulong>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong Value { get; set; }
	}

	public class UlongProperties1 : MonoBehaviour, IValues<ulong>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong Value2 { get; set; }
	}

	public class UlongProperties2 : MonoBehaviour, IValues<ulong>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong Value2 { get; set; }
	}

	public class UlongArrayField1 : MonoBehaviour, IValue<ulong[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong[] Value { get { return value; } set { this.value = value; } }
	}

	public class UlongArrayField2 : MonoBehaviour, IValue<ulong[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong[] Value { get { return value; } set { this.value = value; } }
	}

	public class UlongArrayFields1 : MonoBehaviour, IValues<ulong[]>
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

	public class UlongArrayFields2 : MonoBehaviour, IValues<ulong[]>
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

	public class UlongArrayProperty1 : MonoBehaviour, IValue<ulong[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong[] Value { get; set; }
	}

	public class UlongArrayProperty2 : MonoBehaviour, IValue<ulong[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong[] Value { get; set; }
	}

	public class UlongArrayProperties1 : MonoBehaviour, IValues<ulong[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong[] Value2 { get; set; }
	}

	public class UlongArrayProperties2 : MonoBehaviour, IValues<ulong[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong[] Value2 { get; set; }
	}

	public class UlongListField1 : MonoBehaviour, IValue<List<ulong>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ulong> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ulong> Value { get { return value; } set { this.value = value; } }
	}

	public class UlongListField2 : MonoBehaviour, IValue<List<ulong>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ulong> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ulong> Value { get { return value; } set { this.value = value; } }
	}

	public class UlongListFields1 : MonoBehaviour, IValues<List<ulong>>
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

	public class UlongListFields2 : MonoBehaviour, IValues<List<ulong>>
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

	public class UlongListProperty1 : MonoBehaviour, IValue<List<ulong>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong> Value { get; set; }
	}

	public class UlongListProperty2 : MonoBehaviour, IValue<List<ulong>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong> Value { get; set; }
	}

	public class UlongListProperties1 : MonoBehaviour, IValues<List<ulong>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ulong> Value2 { get; set; }
	}

	public class UlongListProperties2 : MonoBehaviour, IValues<List<ulong>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ulong> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong> Value2 { get; set; }
	}

	public class UlongNullableField1 : MonoBehaviour, IValue<ulong?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong? Value { get { return value; } set { this.value = value; } }
	}

	public class UlongNullableField2 : MonoBehaviour, IValue<ulong?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong? Value { get { return value; } set { this.value = value; } }
	}

	public class UlongNullableFields1 : MonoBehaviour, IValues<ulong?>
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

	public class UlongNullableFields2 : MonoBehaviour, IValues<ulong?>
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

	public class UlongNullableProperty1 : MonoBehaviour, IValue<ulong?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong? Value { get; set; }
	}

	public class UlongNullableProperty2 : MonoBehaviour, IValue<ulong?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong? Value { get; set; }
	}

	public class UlongNullableProperties1 : MonoBehaviour, IValues<ulong?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong? Value2 { get; set; }
	}

	public class UlongNullableProperties2 : MonoBehaviour, IValues<ulong?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong? Value2 { get; set; }
	}

	public class UlongArrayNullableField1 : MonoBehaviour, IValue<ulong?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ulong?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ulong?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UlongArrayNullableField2 : MonoBehaviour, IValue<ulong?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ulong?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ulong?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UlongArrayNullableFields1 : MonoBehaviour, IValues<ulong?[]>
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

	public class UlongArrayNullableFields2 : MonoBehaviour, IValues<ulong?[]>
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

	public class UlongArrayNullableProperty1 : MonoBehaviour, IValue<ulong?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong?[] Value { get; set; }
	}

	public class UlongArrayNullableProperty2 : MonoBehaviour, IValue<ulong?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong?[] Value { get; set; }
	}

	public class UlongArrayNullableProperties1 : MonoBehaviour, IValues<ulong?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ulong?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ulong?[] Value2 { get; set; }
	}

	public class UlongArrayNullableProperties2 : MonoBehaviour, IValues<ulong?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ulong?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ulong?[] Value2 { get; set; }
	}

	public class UlongListNullableField1 : MonoBehaviour, IValue<List<ulong?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ulong?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ulong?> Value { get { return value; } set { this.value = value; } }
	}

	public class UlongListNullableField2 : MonoBehaviour, IValue<List<ulong?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ulong?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ulong?> Value { get { return value; } set { this.value = value; } }
	}

	public class UlongListNullableFields1 : MonoBehaviour, IValues<List<ulong?>>
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

	public class UlongListNullableFields2 : MonoBehaviour, IValues<List<ulong?>>
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

	public class UlongListNullableProperty1 : MonoBehaviour, IValue<List<ulong?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong?> Value { get; set; }
	}

	public class UlongListNullableProperty2 : MonoBehaviour, IValue<List<ulong?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong?> Value { get; set; }
	}

	public class UlongListNullableProperties1 : MonoBehaviour, IValues<List<ulong?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ulong?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ulong?> Value2 { get; set; }
	}

	public class UlongListNullableProperties2 : MonoBehaviour, IValues<List<ulong?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ulong?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ulong?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618