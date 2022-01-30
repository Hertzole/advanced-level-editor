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
	public class StringField1 : MonoBehaviour, IValue<string>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string value;

		public int ValueID { get { return VALUE_0_ID; } }
		public string Value { get { return value; } set { this.value = value; } }
	}

	public class StringField2 : MonoBehaviour, IValue<string>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string value;

		public int ValueID { get { return VALUE_100_ID; } }
		public string Value { get { return value; } set { this.value = value; } }
	}

	public class StringFields1 : MonoBehaviour, IValues<string>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private string value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public string Value1 { get { return value1; } set { value1 = value; } }
		public string Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringFields2 : MonoBehaviour, IValues<string>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private string value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public string Value1 { get { return value1; } set { value1 = value; } }
		public string Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringProperty1 : MonoBehaviour, IValue<string>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string Value { get; set; }
	}

	public class StringProperty2 : MonoBehaviour, IValue<string>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public string Value { get; set; }
	}

	public class StringProperties1 : MonoBehaviour, IValues<string>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public string Value2 { get; set; }
	}

	public class StringProperties2 : MonoBehaviour, IValues<string>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public string Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public string Value2 { get; set; }
	}

	public class StringArrayField1 : MonoBehaviour, IValue<string[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public string[] Value { get { return value; } set { this.value = value; } }
	}

	public class StringArrayField2 : MonoBehaviour, IValue<string[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public string[] Value { get { return value; } set { this.value = value; } }
	}

	public class StringArrayFields1 : MonoBehaviour, IValues<string[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private string[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public string[] Value1 { get { return value1; } set { value1 = value; } }
		public string[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringArrayFields2 : MonoBehaviour, IValues<string[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private string[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public string[] Value1 { get { return value1; } set { value1 = value; } }
		public string[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringArrayProperty1 : MonoBehaviour, IValue<string[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string[] Value { get; set; }
	}

	public class StringArrayProperty2 : MonoBehaviour, IValue<string[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public string[] Value { get; set; }
	}

	public class StringArrayProperties1 : MonoBehaviour, IValues<string[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public string[] Value2 { get; set; }
	}

	public class StringArrayProperties2 : MonoBehaviour, IValues<string[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public string[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public string[] Value2 { get; set; }
	}

	public class StringListField1 : MonoBehaviour, IValue<List<string>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<string> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<string> Value { get { return value; } set { this.value = value; } }
	}

	public class StringListField2 : MonoBehaviour, IValue<List<string>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<string> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<string> Value { get { return value; } set { this.value = value; } }
	}

	public class StringListFields1 : MonoBehaviour, IValues<List<string>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<string> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<string> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<string> Value1 { get { return value1; } set { value1 = value; } }
		public List<string> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringListFields2 : MonoBehaviour, IValues<List<string>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<string> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<string> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<string> Value1 { get { return value1; } set { value1 = value; } }
		public List<string> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringListProperty1 : MonoBehaviour, IValue<List<string>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<string> Value { get; set; }
	}

	public class StringListProperty2 : MonoBehaviour, IValue<List<string>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<string> Value { get; set; }
	}

	public class StringListProperties1 : MonoBehaviour, IValues<List<string>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<string> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<string> Value2 { get; set; }
	}

	public class StringListProperties2 : MonoBehaviour, IValues<List<string>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<string> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<string> Value2 { get; set; }
	}

	public class StringNullableField1 : MonoBehaviour, IValue<string?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public string? Value { get { return value; } set { this.value = value; } }
	}

	public class StringNullableField2 : MonoBehaviour, IValue<string?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public string? Value { get { return value; } set { this.value = value; } }
	}

	public class StringNullableFields1 : MonoBehaviour, IValues<string?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private string? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public string? Value1 { get { return value1; } set { value1 = value; } }
		public string? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringNullableFields2 : MonoBehaviour, IValues<string?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private string? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public string? Value1 { get { return value1; } set { value1 = value; } }
		public string? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringNullableProperty1 : MonoBehaviour, IValue<string?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string? Value { get; set; }
	}

	public class StringNullableProperty2 : MonoBehaviour, IValue<string?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public string? Value { get; set; }
	}

	public class StringNullableProperties1 : MonoBehaviour, IValues<string?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public string? Value2 { get; set; }
	}

	public class StringNullableProperties2 : MonoBehaviour, IValues<string?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public string? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public string? Value2 { get; set; }
	}

	public class StringArrayNullableField1 : MonoBehaviour, IValue<string?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public string?[] Value { get { return value; } set { this.value = value; } }
	}

	public class StringArrayNullableField2 : MonoBehaviour, IValue<string?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public string?[] Value { get { return value; } set { this.value = value; } }
	}

	public class StringArrayNullableFields1 : MonoBehaviour, IValues<string?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private string?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private string?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public string?[] Value1 { get { return value1; } set { value1 = value; } }
		public string?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringArrayNullableFields2 : MonoBehaviour, IValues<string?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private string?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private string?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public string?[] Value1 { get { return value1; } set { value1 = value; } }
		public string?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringArrayNullableProperty1 : MonoBehaviour, IValue<string?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string?[] Value { get; set; }
	}

	public class StringArrayNullableProperty2 : MonoBehaviour, IValue<string?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public string?[] Value { get; set; }
	}

	public class StringArrayNullableProperties1 : MonoBehaviour, IValues<string?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public string?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public string?[] Value2 { get; set; }
	}

	public class StringArrayNullableProperties2 : MonoBehaviour, IValues<string?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public string?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public string?[] Value2 { get; set; }
	}

	public class StringListNullableField1 : MonoBehaviour, IValue<List<string?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<string?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<string?> Value { get { return value; } set { this.value = value; } }
	}

	public class StringListNullableField2 : MonoBehaviour, IValue<List<string?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<string?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<string?> Value { get { return value; } set { this.value = value; } }
	}

	public class StringListNullableFields1 : MonoBehaviour, IValues<List<string?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<string?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<string?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<string?> Value1 { get { return value1; } set { value1 = value; } }
		public List<string?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringListNullableFields2 : MonoBehaviour, IValues<List<string?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<string?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<string?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<string?> Value1 { get { return value1; } set { value1 = value; } }
		public List<string?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class StringListNullableProperty1 : MonoBehaviour, IValue<List<string?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<string?> Value { get; set; }
	}

	public class StringListNullableProperty2 : MonoBehaviour, IValue<List<string?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<string?> Value { get; set; }
	}

	public class StringListNullableProperties1 : MonoBehaviour, IValues<List<string?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<string?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<string?> Value2 { get; set; }
	}

	public class StringListNullableProperties2 : MonoBehaviour, IValues<List<string?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<string?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<string?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618