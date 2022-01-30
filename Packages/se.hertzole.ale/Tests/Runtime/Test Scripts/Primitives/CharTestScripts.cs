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
	public class CharField1 : MonoBehaviour, IValue<char>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char value;

		public int ValueID { get { return VALUE_0_ID; } }
		public char Value { get { return value; } set { this.value = value; } }
	}

	public class CharField2 : MonoBehaviour, IValue<char>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char value;

		public int ValueID { get { return VALUE_100_ID; } }
		public char Value { get { return value; } set { this.value = value; } }
	}

	public class CharFields1 : MonoBehaviour, IValues<char>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private char value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public char Value1 { get { return value1; } set { value1 = value; } }
		public char Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharFields2 : MonoBehaviour, IValues<char>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private char value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public char Value1 { get { return value1; } set { value1 = value; } }
		public char Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharProperty1 : MonoBehaviour, IValue<char>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char Value { get; set; }
	}

	public class CharProperty2 : MonoBehaviour, IValue<char>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public char Value { get; set; }
	}

	public class CharProperties1 : MonoBehaviour, IValues<char>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public char Value2 { get; set; }
	}

	public class CharProperties2 : MonoBehaviour, IValues<char>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public char Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public char Value2 { get; set; }
	}

	public class CharArrayField1 : MonoBehaviour, IValue<char[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public char[] Value { get { return value; } set { this.value = value; } }
	}

	public class CharArrayField2 : MonoBehaviour, IValue<char[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public char[] Value { get { return value; } set { this.value = value; } }
	}

	public class CharArrayFields1 : MonoBehaviour, IValues<char[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private char[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public char[] Value1 { get { return value1; } set { value1 = value; } }
		public char[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharArrayFields2 : MonoBehaviour, IValues<char[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private char[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public char[] Value1 { get { return value1; } set { value1 = value; } }
		public char[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharArrayProperty1 : MonoBehaviour, IValue<char[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char[] Value { get; set; }
	}

	public class CharArrayProperty2 : MonoBehaviour, IValue<char[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public char[] Value { get; set; }
	}

	public class CharArrayProperties1 : MonoBehaviour, IValues<char[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public char[] Value2 { get; set; }
	}

	public class CharArrayProperties2 : MonoBehaviour, IValues<char[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public char[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public char[] Value2 { get; set; }
	}

	public class CharListField1 : MonoBehaviour, IValue<List<char>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<char> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<char> Value { get { return value; } set { this.value = value; } }
	}

	public class CharListField2 : MonoBehaviour, IValue<List<char>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<char> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<char> Value { get { return value; } set { this.value = value; } }
	}

	public class CharListFields1 : MonoBehaviour, IValues<List<char>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<char> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<char> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<char> Value1 { get { return value1; } set { value1 = value; } }
		public List<char> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharListFields2 : MonoBehaviour, IValues<List<char>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<char> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<char> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<char> Value1 { get { return value1; } set { value1 = value; } }
		public List<char> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharListProperty1 : MonoBehaviour, IValue<List<char>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<char> Value { get; set; }
	}

	public class CharListProperty2 : MonoBehaviour, IValue<List<char>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<char> Value { get; set; }
	}

	public class CharListProperties1 : MonoBehaviour, IValues<List<char>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<char> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<char> Value2 { get; set; }
	}

	public class CharListProperties2 : MonoBehaviour, IValues<List<char>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<char> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<char> Value2 { get; set; }
	}

	public class CharNullableField1 : MonoBehaviour, IValue<char?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public char? Value { get { return value; } set { this.value = value; } }
	}

	public class CharNullableField2 : MonoBehaviour, IValue<char?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public char? Value { get { return value; } set { this.value = value; } }
	}

	public class CharNullableFields1 : MonoBehaviour, IValues<char?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private char? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public char? Value1 { get { return value1; } set { value1 = value; } }
		public char? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharNullableFields2 : MonoBehaviour, IValues<char?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private char? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public char? Value1 { get { return value1; } set { value1 = value; } }
		public char? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharNullableProperty1 : MonoBehaviour, IValue<char?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char? Value { get; set; }
	}

	public class CharNullableProperty2 : MonoBehaviour, IValue<char?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public char? Value { get; set; }
	}

	public class CharNullableProperties1 : MonoBehaviour, IValues<char?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public char? Value2 { get; set; }
	}

	public class CharNullableProperties2 : MonoBehaviour, IValues<char?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public char? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public char? Value2 { get; set; }
	}

	public class CharArrayNullableField1 : MonoBehaviour, IValue<char?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public char?[] Value { get { return value; } set { this.value = value; } }
	}

	public class CharArrayNullableField2 : MonoBehaviour, IValue<char?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public char?[] Value { get { return value; } set { this.value = value; } }
	}

	public class CharArrayNullableFields1 : MonoBehaviour, IValues<char?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private char?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private char?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public char?[] Value1 { get { return value1; } set { value1 = value; } }
		public char?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharArrayNullableFields2 : MonoBehaviour, IValues<char?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private char?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private char?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public char?[] Value1 { get { return value1; } set { value1 = value; } }
		public char?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharArrayNullableProperty1 : MonoBehaviour, IValue<char?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char?[] Value { get; set; }
	}

	public class CharArrayNullableProperty2 : MonoBehaviour, IValue<char?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public char?[] Value { get; set; }
	}

	public class CharArrayNullableProperties1 : MonoBehaviour, IValues<char?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public char?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public char?[] Value2 { get; set; }
	}

	public class CharArrayNullableProperties2 : MonoBehaviour, IValues<char?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public char?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public char?[] Value2 { get; set; }
	}

	public class CharListNullableField1 : MonoBehaviour, IValue<List<char?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<char?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<char?> Value { get { return value; } set { this.value = value; } }
	}

	public class CharListNullableField2 : MonoBehaviour, IValue<List<char?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<char?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<char?> Value { get { return value; } set { this.value = value; } }
	}

	public class CharListNullableFields1 : MonoBehaviour, IValues<List<char?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<char?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<char?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<char?> Value1 { get { return value1; } set { value1 = value; } }
		public List<char?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharListNullableFields2 : MonoBehaviour, IValues<List<char?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<char?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<char?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<char?> Value1 { get { return value1; } set { value1 = value; } }
		public List<char?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class CharListNullableProperty1 : MonoBehaviour, IValue<List<char?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<char?> Value { get; set; }
	}

	public class CharListNullableProperty2 : MonoBehaviour, IValue<List<char?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<char?> Value { get; set; }
	}

	public class CharListNullableProperties1 : MonoBehaviour, IValues<List<char?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<char?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<char?> Value2 { get; set; }
	}

	public class CharListNullableProperties2 : MonoBehaviour, IValues<List<char?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<char?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<char?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618