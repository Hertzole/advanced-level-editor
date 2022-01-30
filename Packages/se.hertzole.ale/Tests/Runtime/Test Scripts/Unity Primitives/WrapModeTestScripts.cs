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
	public class WrapModeField1 : MonoBehaviour, IValue<WrapMode>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode value;

		public int ValueID { get { return VALUE_0_ID; } }
		public WrapMode Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeField2 : MonoBehaviour, IValue<WrapMode>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode value;

		public int ValueID { get { return VALUE_100_ID; } }
		public WrapMode Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeFields1 : MonoBehaviour, IValues<WrapMode>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private WrapMode value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public WrapMode Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeFields2 : MonoBehaviour, IValues<WrapMode>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private WrapMode value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public WrapMode Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeProperty1 : MonoBehaviour, IValue<WrapMode>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode Value { get; set; }
	}

	public class WrapModeProperty2 : MonoBehaviour, IValue<WrapMode>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode Value { get; set; }
	}

	public class WrapModeProperties1 : MonoBehaviour, IValues<WrapMode>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public WrapMode Value2 { get; set; }
	}

	public class WrapModeProperties2 : MonoBehaviour, IValues<WrapMode>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public WrapMode Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode Value2 { get; set; }
	}

	public class WrapModeArrayField1 : MonoBehaviour, IValue<WrapMode[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public WrapMode[] Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeArrayField2 : MonoBehaviour, IValue<WrapMode[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public WrapMode[] Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeArrayFields1 : MonoBehaviour, IValues<WrapMode[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private WrapMode[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public WrapMode[] Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeArrayFields2 : MonoBehaviour, IValues<WrapMode[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private WrapMode[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public WrapMode[] Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeArrayProperty1 : MonoBehaviour, IValue<WrapMode[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode[] Value { get; set; }
	}

	public class WrapModeArrayProperty2 : MonoBehaviour, IValue<WrapMode[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode[] Value { get; set; }
	}

	public class WrapModeArrayProperties1 : MonoBehaviour, IValues<WrapMode[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public WrapMode[] Value2 { get; set; }
	}

	public class WrapModeArrayProperties2 : MonoBehaviour, IValues<WrapMode[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public WrapMode[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode[] Value2 { get; set; }
	}

	public class WrapModeListField1 : MonoBehaviour, IValue<List<WrapMode>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<WrapMode> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<WrapMode> Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeListField2 : MonoBehaviour, IValue<List<WrapMode>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<WrapMode> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<WrapMode> Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeListFields1 : MonoBehaviour, IValues<List<WrapMode>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<WrapMode> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<WrapMode> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<WrapMode> Value1 { get { return value1; } set { value1 = value; } }
		public List<WrapMode> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeListFields2 : MonoBehaviour, IValues<List<WrapMode>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<WrapMode> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<WrapMode> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<WrapMode> Value1 { get { return value1; } set { value1 = value; } }
		public List<WrapMode> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeListProperty1 : MonoBehaviour, IValue<List<WrapMode>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<WrapMode> Value { get; set; }
	}

	public class WrapModeListProperty2 : MonoBehaviour, IValue<List<WrapMode>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<WrapMode> Value { get; set; }
	}

	public class WrapModeListProperties1 : MonoBehaviour, IValues<List<WrapMode>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<WrapMode> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<WrapMode> Value2 { get; set; }
	}

	public class WrapModeListProperties2 : MonoBehaviour, IValues<List<WrapMode>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<WrapMode> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<WrapMode> Value2 { get; set; }
	}

	public class WrapModeNullableField1 : MonoBehaviour, IValue<WrapMode?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public WrapMode? Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeNullableField2 : MonoBehaviour, IValue<WrapMode?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public WrapMode? Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeNullableFields1 : MonoBehaviour, IValues<WrapMode?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private WrapMode? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public WrapMode? Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeNullableFields2 : MonoBehaviour, IValues<WrapMode?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private WrapMode? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public WrapMode? Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeNullableProperty1 : MonoBehaviour, IValue<WrapMode?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode? Value { get; set; }
	}

	public class WrapModeNullableProperty2 : MonoBehaviour, IValue<WrapMode?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode? Value { get; set; }
	}

	public class WrapModeNullableProperties1 : MonoBehaviour, IValues<WrapMode?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public WrapMode? Value2 { get; set; }
	}

	public class WrapModeNullableProperties2 : MonoBehaviour, IValues<WrapMode?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public WrapMode? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode? Value2 { get; set; }
	}

	public class WrapModeArrayNullableField1 : MonoBehaviour, IValue<WrapMode?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public WrapMode?[] Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeArrayNullableField2 : MonoBehaviour, IValue<WrapMode?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public WrapMode?[] Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeArrayNullableFields1 : MonoBehaviour, IValues<WrapMode?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private WrapMode?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private WrapMode?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public WrapMode?[] Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeArrayNullableFields2 : MonoBehaviour, IValues<WrapMode?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private WrapMode?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private WrapMode?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public WrapMode?[] Value1 { get { return value1; } set { value1 = value; } }
		public WrapMode?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeArrayNullableProperty1 : MonoBehaviour, IValue<WrapMode?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode?[] Value { get; set; }
	}

	public class WrapModeArrayNullableProperty2 : MonoBehaviour, IValue<WrapMode?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode?[] Value { get; set; }
	}

	public class WrapModeArrayNullableProperties1 : MonoBehaviour, IValues<WrapMode?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public WrapMode?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public WrapMode?[] Value2 { get; set; }
	}

	public class WrapModeArrayNullableProperties2 : MonoBehaviour, IValues<WrapMode?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public WrapMode?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public WrapMode?[] Value2 { get; set; }
	}

	public class WrapModeListNullableField1 : MonoBehaviour, IValue<List<WrapMode?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<WrapMode?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<WrapMode?> Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeListNullableField2 : MonoBehaviour, IValue<List<WrapMode?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<WrapMode?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<WrapMode?> Value { get { return value; } set { this.value = value; } }
	}

	public class WrapModeListNullableFields1 : MonoBehaviour, IValues<List<WrapMode?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<WrapMode?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<WrapMode?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<WrapMode?> Value1 { get { return value1; } set { value1 = value; } }
		public List<WrapMode?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeListNullableFields2 : MonoBehaviour, IValues<List<WrapMode?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<WrapMode?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<WrapMode?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<WrapMode?> Value1 { get { return value1; } set { value1 = value; } }
		public List<WrapMode?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class WrapModeListNullableProperty1 : MonoBehaviour, IValue<List<WrapMode?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<WrapMode?> Value { get; set; }
	}

	public class WrapModeListNullableProperty2 : MonoBehaviour, IValue<List<WrapMode?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<WrapMode?> Value { get; set; }
	}

	public class WrapModeListNullableProperties1 : MonoBehaviour, IValues<List<WrapMode?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<WrapMode?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<WrapMode?> Value2 { get; set; }
	}

	public class WrapModeListNullableProperties2 : MonoBehaviour, IValues<List<WrapMode?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<WrapMode?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<WrapMode?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618