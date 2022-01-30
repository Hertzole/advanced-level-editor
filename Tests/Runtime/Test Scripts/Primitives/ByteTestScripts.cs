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
	public class ByteField1 : MonoBehaviour, IValue<byte>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte value;

		public int ValueID { get { return VALUE_0_ID; } }
		public byte Value { get { return value; } set { this.value = value; } }
	}

	public class ByteField2 : MonoBehaviour, IValue<byte>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte value;

		public int ValueID { get { return VALUE_100_ID; } }
		public byte Value { get { return value; } set { this.value = value; } }
	}

	public class ByteFields1 : MonoBehaviour, IValues<byte>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private byte value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public byte Value1 { get { return value1; } set { value1 = value; } }
		public byte Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteFields2 : MonoBehaviour, IValues<byte>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private byte value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public byte Value1 { get { return value1; } set { value1 = value; } }
		public byte Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteProperty1 : MonoBehaviour, IValue<byte>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte Value { get; set; }
	}

	public class ByteProperty2 : MonoBehaviour, IValue<byte>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte Value { get; set; }
	}

	public class ByteProperties1 : MonoBehaviour, IValues<byte>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public byte Value2 { get; set; }
	}

	public class ByteProperties2 : MonoBehaviour, IValues<byte>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public byte Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte Value2 { get; set; }
	}

	public class ByteArrayField1 : MonoBehaviour, IValue<byte[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public byte[] Value { get { return value; } set { this.value = value; } }
	}

	public class ByteArrayField2 : MonoBehaviour, IValue<byte[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public byte[] Value { get { return value; } set { this.value = value; } }
	}

	public class ByteArrayFields1 : MonoBehaviour, IValues<byte[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private byte[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public byte[] Value1 { get { return value1; } set { value1 = value; } }
		public byte[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteArrayFields2 : MonoBehaviour, IValues<byte[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private byte[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public byte[] Value1 { get { return value1; } set { value1 = value; } }
		public byte[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteArrayProperty1 : MonoBehaviour, IValue<byte[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte[] Value { get; set; }
	}

	public class ByteArrayProperty2 : MonoBehaviour, IValue<byte[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte[] Value { get; set; }
	}

	public class ByteArrayProperties1 : MonoBehaviour, IValues<byte[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public byte[] Value2 { get; set; }
	}

	public class ByteArrayProperties2 : MonoBehaviour, IValues<byte[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public byte[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte[] Value2 { get; set; }
	}

	public class ByteListField1 : MonoBehaviour, IValue<List<byte>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<byte> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<byte> Value { get { return value; } set { this.value = value; } }
	}

	public class ByteListField2 : MonoBehaviour, IValue<List<byte>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<byte> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<byte> Value { get { return value; } set { this.value = value; } }
	}

	public class ByteListFields1 : MonoBehaviour, IValues<List<byte>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<byte> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<byte> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<byte> Value1 { get { return value1; } set { value1 = value; } }
		public List<byte> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteListFields2 : MonoBehaviour, IValues<List<byte>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<byte> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<byte> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<byte> Value1 { get { return value1; } set { value1 = value; } }
		public List<byte> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteListProperty1 : MonoBehaviour, IValue<List<byte>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<byte> Value { get; set; }
	}

	public class ByteListProperty2 : MonoBehaviour, IValue<List<byte>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<byte> Value { get; set; }
	}

	public class ByteListProperties1 : MonoBehaviour, IValues<List<byte>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<byte> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<byte> Value2 { get; set; }
	}

	public class ByteListProperties2 : MonoBehaviour, IValues<List<byte>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<byte> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<byte> Value2 { get; set; }
	}

	public class ByteNullableField1 : MonoBehaviour, IValue<byte?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public byte? Value { get { return value; } set { this.value = value; } }
	}

	public class ByteNullableField2 : MonoBehaviour, IValue<byte?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public byte? Value { get { return value; } set { this.value = value; } }
	}

	public class ByteNullableFields1 : MonoBehaviour, IValues<byte?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private byte? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public byte? Value1 { get { return value1; } set { value1 = value; } }
		public byte? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteNullableFields2 : MonoBehaviour, IValues<byte?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private byte? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public byte? Value1 { get { return value1; } set { value1 = value; } }
		public byte? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteNullableProperty1 : MonoBehaviour, IValue<byte?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte? Value { get; set; }
	}

	public class ByteNullableProperty2 : MonoBehaviour, IValue<byte?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte? Value { get; set; }
	}

	public class ByteNullableProperties1 : MonoBehaviour, IValues<byte?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public byte? Value2 { get; set; }
	}

	public class ByteNullableProperties2 : MonoBehaviour, IValues<byte?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public byte? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte? Value2 { get; set; }
	}

	public class ByteArrayNullableField1 : MonoBehaviour, IValue<byte?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public byte?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ByteArrayNullableField2 : MonoBehaviour, IValue<byte?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public byte?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ByteArrayNullableFields1 : MonoBehaviour, IValues<byte?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private byte?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private byte?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public byte?[] Value1 { get { return value1; } set { value1 = value; } }
		public byte?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteArrayNullableFields2 : MonoBehaviour, IValues<byte?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private byte?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private byte?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public byte?[] Value1 { get { return value1; } set { value1 = value; } }
		public byte?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteArrayNullableProperty1 : MonoBehaviour, IValue<byte?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte?[] Value { get; set; }
	}

	public class ByteArrayNullableProperty2 : MonoBehaviour, IValue<byte?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte?[] Value { get; set; }
	}

	public class ByteArrayNullableProperties1 : MonoBehaviour, IValues<byte?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public byte?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public byte?[] Value2 { get; set; }
	}

	public class ByteArrayNullableProperties2 : MonoBehaviour, IValues<byte?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public byte?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public byte?[] Value2 { get; set; }
	}

	public class ByteListNullableField1 : MonoBehaviour, IValue<List<byte?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<byte?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<byte?> Value { get { return value; } set { this.value = value; } }
	}

	public class ByteListNullableField2 : MonoBehaviour, IValue<List<byte?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<byte?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<byte?> Value { get { return value; } set { this.value = value; } }
	}

	public class ByteListNullableFields1 : MonoBehaviour, IValues<List<byte?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<byte?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<byte?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<byte?> Value1 { get { return value1; } set { value1 = value; } }
		public List<byte?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteListNullableFields2 : MonoBehaviour, IValues<List<byte?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<byte?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<byte?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<byte?> Value1 { get { return value1; } set { value1 = value; } }
		public List<byte?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ByteListNullableProperty1 : MonoBehaviour, IValue<List<byte?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<byte?> Value { get; set; }
	}

	public class ByteListNullableProperty2 : MonoBehaviour, IValue<List<byte?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<byte?> Value { get; set; }
	}

	public class ByteListNullableProperties1 : MonoBehaviour, IValues<List<byte?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<byte?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<byte?> Value2 { get; set; }
	}

	public class ByteListNullableProperties2 : MonoBehaviour, IValues<List<byte?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<byte?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<byte?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618