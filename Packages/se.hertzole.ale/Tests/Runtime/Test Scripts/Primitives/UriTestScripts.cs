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
	public class UriField1 : MonoBehaviour, IValue<Uri>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Uri Value { get { return value; } set { this.value = value; } }
	}

	public class UriField2 : MonoBehaviour, IValue<Uri>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Uri Value { get { return value; } set { this.value = value; } }
	}

	public class UriFields1 : MonoBehaviour, IValues<Uri>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Uri value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Uri Value1 { get { return value1; } set { value1 = value; } }
		public Uri Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriFields2 : MonoBehaviour, IValues<Uri>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Uri value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Uri Value1 { get { return value1; } set { value1 = value; } }
		public Uri Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriProperty1 : MonoBehaviour, IValue<Uri>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri Value { get; set; }
	}

	public class UriProperty2 : MonoBehaviour, IValue<Uri>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri Value { get; set; }
	}

	public class UriProperties1 : MonoBehaviour, IValues<Uri>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Uri Value2 { get; set; }
	}

	public class UriProperties2 : MonoBehaviour, IValues<Uri>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Uri Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri Value2 { get; set; }
	}

	public class UriArrayField1 : MonoBehaviour, IValue<Uri[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Uri[] Value { get { return value; } set { this.value = value; } }
	}

	public class UriArrayField2 : MonoBehaviour, IValue<Uri[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Uri[] Value { get { return value; } set { this.value = value; } }
	}

	public class UriArrayFields1 : MonoBehaviour, IValues<Uri[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Uri[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Uri[] Value1 { get { return value1; } set { value1 = value; } }
		public Uri[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriArrayFields2 : MonoBehaviour, IValues<Uri[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Uri[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Uri[] Value1 { get { return value1; } set { value1 = value; } }
		public Uri[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriArrayProperty1 : MonoBehaviour, IValue<Uri[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri[] Value { get; set; }
	}

	public class UriArrayProperty2 : MonoBehaviour, IValue<Uri[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri[] Value { get; set; }
	}

	public class UriArrayProperties1 : MonoBehaviour, IValues<Uri[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Uri[] Value2 { get; set; }
	}

	public class UriArrayProperties2 : MonoBehaviour, IValues<Uri[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Uri[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri[] Value2 { get; set; }
	}

	public class UriListField1 : MonoBehaviour, IValue<List<Uri>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Uri> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Uri> Value { get { return value; } set { this.value = value; } }
	}

	public class UriListField2 : MonoBehaviour, IValue<List<Uri>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Uri> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Uri> Value { get { return value; } set { this.value = value; } }
	}

	public class UriListFields1 : MonoBehaviour, IValues<List<Uri>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Uri> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Uri> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Uri> Value1 { get { return value1; } set { value1 = value; } }
		public List<Uri> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriListFields2 : MonoBehaviour, IValues<List<Uri>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Uri> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Uri> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Uri> Value1 { get { return value1; } set { value1 = value; } }
		public List<Uri> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriListProperty1 : MonoBehaviour, IValue<List<Uri>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Uri> Value { get; set; }
	}

	public class UriListProperty2 : MonoBehaviour, IValue<List<Uri>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Uri> Value { get; set; }
	}

	public class UriListProperties1 : MonoBehaviour, IValues<List<Uri>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Uri> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Uri> Value2 { get; set; }
	}

	public class UriListProperties2 : MonoBehaviour, IValues<List<Uri>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Uri> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Uri> Value2 { get; set; }
	}

	public class UriNullableField1 : MonoBehaviour, IValue<Uri?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Uri? Value { get { return value; } set { this.value = value; } }
	}

	public class UriNullableField2 : MonoBehaviour, IValue<Uri?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Uri? Value { get { return value; } set { this.value = value; } }
	}

	public class UriNullableFields1 : MonoBehaviour, IValues<Uri?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Uri? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Uri? Value1 { get { return value1; } set { value1 = value; } }
		public Uri? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriNullableFields2 : MonoBehaviour, IValues<Uri?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Uri? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Uri? Value1 { get { return value1; } set { value1 = value; } }
		public Uri? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriNullableProperty1 : MonoBehaviour, IValue<Uri?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri? Value { get; set; }
	}

	public class UriNullableProperty2 : MonoBehaviour, IValue<Uri?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri? Value { get; set; }
	}

	public class UriNullableProperties1 : MonoBehaviour, IValues<Uri?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Uri? Value2 { get; set; }
	}

	public class UriNullableProperties2 : MonoBehaviour, IValues<Uri?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Uri? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri? Value2 { get; set; }
	}

	public class UriArrayNullableField1 : MonoBehaviour, IValue<Uri?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Uri?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UriArrayNullableField2 : MonoBehaviour, IValue<Uri?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Uri?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UriArrayNullableFields1 : MonoBehaviour, IValues<Uri?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Uri?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Uri?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Uri?[] Value1 { get { return value1; } set { value1 = value; } }
		public Uri?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriArrayNullableFields2 : MonoBehaviour, IValues<Uri?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Uri?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Uri?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Uri?[] Value1 { get { return value1; } set { value1 = value; } }
		public Uri?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriArrayNullableProperty1 : MonoBehaviour, IValue<Uri?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri?[] Value { get; set; }
	}

	public class UriArrayNullableProperty2 : MonoBehaviour, IValue<Uri?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri?[] Value { get; set; }
	}

	public class UriArrayNullableProperties1 : MonoBehaviour, IValues<Uri?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Uri?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Uri?[] Value2 { get; set; }
	}

	public class UriArrayNullableProperties2 : MonoBehaviour, IValues<Uri?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Uri?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Uri?[] Value2 { get; set; }
	}

	public class UriListNullableField1 : MonoBehaviour, IValue<List<Uri?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Uri?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Uri?> Value { get { return value; } set { this.value = value; } }
	}

	public class UriListNullableField2 : MonoBehaviour, IValue<List<Uri?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Uri?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Uri?> Value { get { return value; } set { this.value = value; } }
	}

	public class UriListNullableFields1 : MonoBehaviour, IValues<List<Uri?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Uri?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Uri?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Uri?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Uri?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriListNullableFields2 : MonoBehaviour, IValues<List<Uri?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Uri?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Uri?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Uri?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Uri?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UriListNullableProperty1 : MonoBehaviour, IValue<List<Uri?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Uri?> Value { get; set; }
	}

	public class UriListNullableProperty2 : MonoBehaviour, IValue<List<Uri?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Uri?> Value { get; set; }
	}

	public class UriListNullableProperties1 : MonoBehaviour, IValues<List<Uri?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Uri?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Uri?> Value2 { get; set; }
	}

	public class UriListNullableProperties2 : MonoBehaviour, IValues<List<Uri?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Uri?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Uri?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618