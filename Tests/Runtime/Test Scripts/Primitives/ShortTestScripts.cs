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
	public class ShortField1 : MonoBehaviour, IValue<short>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short value;

		public int ValueID { get { return VALUE_0_ID; } }
		public short Value { get { return value; } set { this.value = value; } }
	}

	public class ShortField2 : MonoBehaviour, IValue<short>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short value;

		public int ValueID { get { return VALUE_100_ID; } }
		public short Value { get { return value; } set { this.value = value; } }
	}

	public class ShortFields1 : MonoBehaviour, IValues<short>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private short value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public short Value1 { get { return value1; } set { value1 = value; } }
		public short Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortFields2 : MonoBehaviour, IValues<short>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private short value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public short Value1 { get { return value1; } set { value1 = value; } }
		public short Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortProperty1 : MonoBehaviour, IValue<short>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short Value { get; set; }
	}

	public class ShortProperty2 : MonoBehaviour, IValue<short>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public short Value { get; set; }
	}

	public class ShortProperties1 : MonoBehaviour, IValues<short>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public short Value2 { get; set; }
	}

	public class ShortProperties2 : MonoBehaviour, IValues<short>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public short Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public short Value2 { get; set; }
	}

	public class ShortArrayField1 : MonoBehaviour, IValue<short[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public short[] Value { get { return value; } set { this.value = value; } }
	}

	public class ShortArrayField2 : MonoBehaviour, IValue<short[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public short[] Value { get { return value; } set { this.value = value; } }
	}

	public class ShortArrayFields1 : MonoBehaviour, IValues<short[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private short[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public short[] Value1 { get { return value1; } set { value1 = value; } }
		public short[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortArrayFields2 : MonoBehaviour, IValues<short[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private short[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public short[] Value1 { get { return value1; } set { value1 = value; } }
		public short[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortArrayProperty1 : MonoBehaviour, IValue<short[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short[] Value { get; set; }
	}

	public class ShortArrayProperty2 : MonoBehaviour, IValue<short[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public short[] Value { get; set; }
	}

	public class ShortArrayProperties1 : MonoBehaviour, IValues<short[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public short[] Value2 { get; set; }
	}

	public class ShortArrayProperties2 : MonoBehaviour, IValues<short[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public short[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public short[] Value2 { get; set; }
	}

	public class ShortListField1 : MonoBehaviour, IValue<List<short>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<short> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<short> Value { get { return value; } set { this.value = value; } }
	}

	public class ShortListField2 : MonoBehaviour, IValue<List<short>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<short> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<short> Value { get { return value; } set { this.value = value; } }
	}

	public class ShortListFields1 : MonoBehaviour, IValues<List<short>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<short> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<short> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<short> Value1 { get { return value1; } set { value1 = value; } }
		public List<short> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortListFields2 : MonoBehaviour, IValues<List<short>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<short> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<short> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<short> Value1 { get { return value1; } set { value1 = value; } }
		public List<short> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortListProperty1 : MonoBehaviour, IValue<List<short>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<short> Value { get; set; }
	}

	public class ShortListProperty2 : MonoBehaviour, IValue<List<short>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<short> Value { get; set; }
	}

	public class ShortListProperties1 : MonoBehaviour, IValues<List<short>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<short> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<short> Value2 { get; set; }
	}

	public class ShortListProperties2 : MonoBehaviour, IValues<List<short>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<short> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<short> Value2 { get; set; }
	}

	public class ShortNullableField1 : MonoBehaviour, IValue<short?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public short? Value { get { return value; } set { this.value = value; } }
	}

	public class ShortNullableField2 : MonoBehaviour, IValue<short?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public short? Value { get { return value; } set { this.value = value; } }
	}

	public class ShortNullableFields1 : MonoBehaviour, IValues<short?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private short? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public short? Value1 { get { return value1; } set { value1 = value; } }
		public short? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortNullableFields2 : MonoBehaviour, IValues<short?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private short? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public short? Value1 { get { return value1; } set { value1 = value; } }
		public short? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortNullableProperty1 : MonoBehaviour, IValue<short?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short? Value { get; set; }
	}

	public class ShortNullableProperty2 : MonoBehaviour, IValue<short?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public short? Value { get; set; }
	}

	public class ShortNullableProperties1 : MonoBehaviour, IValues<short?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public short? Value2 { get; set; }
	}

	public class ShortNullableProperties2 : MonoBehaviour, IValues<short?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public short? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public short? Value2 { get; set; }
	}

	public class ShortArrayNullableField1 : MonoBehaviour, IValue<short?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public short?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ShortArrayNullableField2 : MonoBehaviour, IValue<short?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public short?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ShortArrayNullableFields1 : MonoBehaviour, IValues<short?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private short?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private short?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public short?[] Value1 { get { return value1; } set { value1 = value; } }
		public short?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortArrayNullableFields2 : MonoBehaviour, IValues<short?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private short?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private short?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public short?[] Value1 { get { return value1; } set { value1 = value; } }
		public short?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortArrayNullableProperty1 : MonoBehaviour, IValue<short?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short?[] Value { get; set; }
	}

	public class ShortArrayNullableProperty2 : MonoBehaviour, IValue<short?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public short?[] Value { get; set; }
	}

	public class ShortArrayNullableProperties1 : MonoBehaviour, IValues<short?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public short?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public short?[] Value2 { get; set; }
	}

	public class ShortArrayNullableProperties2 : MonoBehaviour, IValues<short?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public short?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public short?[] Value2 { get; set; }
	}

	public class ShortListNullableField1 : MonoBehaviour, IValue<List<short?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<short?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<short?> Value { get { return value; } set { this.value = value; } }
	}

	public class ShortListNullableField2 : MonoBehaviour, IValue<List<short?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<short?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<short?> Value { get { return value; } set { this.value = value; } }
	}

	public class ShortListNullableFields1 : MonoBehaviour, IValues<List<short?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<short?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<short?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<short?> Value1 { get { return value1; } set { value1 = value; } }
		public List<short?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortListNullableFields2 : MonoBehaviour, IValues<List<short?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<short?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<short?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<short?> Value1 { get { return value1; } set { value1 = value; } }
		public List<short?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ShortListNullableProperty1 : MonoBehaviour, IValue<List<short?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<short?> Value { get; set; }
	}

	public class ShortListNullableProperty2 : MonoBehaviour, IValue<List<short?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<short?> Value { get; set; }
	}

	public class ShortListNullableProperties1 : MonoBehaviour, IValues<List<short?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<short?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<short?> Value2 { get; set; }
	}

	public class ShortListNullableProperties2 : MonoBehaviour, IValues<List<short?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<short?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<short?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618