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
	public class ColorField1 : MonoBehaviour, IValue<Color>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color Value { get { return value; } set { this.value = value; } }
	}

	public class ColorField2 : MonoBehaviour, IValue<Color>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color Value { get { return value; } set { this.value = value; } }
	}

	public class ColorFields1 : MonoBehaviour, IValues<Color>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color Value1 { get { return value1; } set { value1 = value; } }
		public Color Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorFields2 : MonoBehaviour, IValues<Color>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color Value1 { get { return value1; } set { value1 = value; } }
		public Color Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorProperty1 : MonoBehaviour, IValue<Color>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color Value { get; set; }
	}

	public class ColorProperty2 : MonoBehaviour, IValue<Color>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color Value { get; set; }
	}

	public class ColorProperties1 : MonoBehaviour, IValues<Color>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color Value2 { get; set; }
	}

	public class ColorProperties2 : MonoBehaviour, IValues<Color>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color Value2 { get; set; }
	}

	public class ColorArrayField1 : MonoBehaviour, IValue<Color[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color[] Value { get { return value; } set { this.value = value; } }
	}

	public class ColorArrayField2 : MonoBehaviour, IValue<Color[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color[] Value { get { return value; } set { this.value = value; } }
	}

	public class ColorArrayFields1 : MonoBehaviour, IValues<Color[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color[] Value1 { get { return value1; } set { value1 = value; } }
		public Color[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorArrayFields2 : MonoBehaviour, IValues<Color[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color[] Value1 { get { return value1; } set { value1 = value; } }
		public Color[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorArrayProperty1 : MonoBehaviour, IValue<Color[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color[] Value { get; set; }
	}

	public class ColorArrayProperty2 : MonoBehaviour, IValue<Color[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color[] Value { get; set; }
	}

	public class ColorArrayProperties1 : MonoBehaviour, IValues<Color[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color[] Value2 { get; set; }
	}

	public class ColorArrayProperties2 : MonoBehaviour, IValues<Color[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color[] Value2 { get; set; }
	}

	public class ColorListField1 : MonoBehaviour, IValue<List<Color>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Color> Value { get { return value; } set { this.value = value; } }
	}

	public class ColorListField2 : MonoBehaviour, IValue<List<Color>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Color> Value { get { return value; } set { this.value = value; } }
	}

	public class ColorListFields1 : MonoBehaviour, IValues<List<Color>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Color> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Color> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorListFields2 : MonoBehaviour, IValues<List<Color>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Color> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Color> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorListProperty1 : MonoBehaviour, IValue<List<Color>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color> Value { get; set; }
	}

	public class ColorListProperty2 : MonoBehaviour, IValue<List<Color>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color> Value { get; set; }
	}

	public class ColorListProperties1 : MonoBehaviour, IValues<List<Color>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Color> Value2 { get; set; }
	}

	public class ColorListProperties2 : MonoBehaviour, IValues<List<Color>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Color> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color> Value2 { get; set; }
	}

	public class ColorNullableField1 : MonoBehaviour, IValue<Color?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color? Value { get { return value; } set { this.value = value; } }
	}

	public class ColorNullableField2 : MonoBehaviour, IValue<Color?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color? Value { get { return value; } set { this.value = value; } }
	}

	public class ColorNullableFields1 : MonoBehaviour, IValues<Color?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color? Value1 { get { return value1; } set { value1 = value; } }
		public Color? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorNullableFields2 : MonoBehaviour, IValues<Color?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color? Value1 { get { return value1; } set { value1 = value; } }
		public Color? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorNullableProperty1 : MonoBehaviour, IValue<Color?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color? Value { get; set; }
	}

	public class ColorNullableProperty2 : MonoBehaviour, IValue<Color?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color? Value { get; set; }
	}

	public class ColorNullableProperties1 : MonoBehaviour, IValues<Color?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color? Value2 { get; set; }
	}

	public class ColorNullableProperties2 : MonoBehaviour, IValues<Color?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color? Value2 { get; set; }
	}

	public class ColorArrayNullableField1 : MonoBehaviour, IValue<Color?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Color?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ColorArrayNullableField2 : MonoBehaviour, IValue<Color?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Color?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ColorArrayNullableFields1 : MonoBehaviour, IValues<Color?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Color?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Color?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Color?[] Value1 { get { return value1; } set { value1 = value; } }
		public Color?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorArrayNullableFields2 : MonoBehaviour, IValues<Color?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Color?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Color?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Color?[] Value1 { get { return value1; } set { value1 = value; } }
		public Color?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorArrayNullableProperty1 : MonoBehaviour, IValue<Color?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color?[] Value { get; set; }
	}

	public class ColorArrayNullableProperty2 : MonoBehaviour, IValue<Color?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color?[] Value { get; set; }
	}

	public class ColorArrayNullableProperties1 : MonoBehaviour, IValues<Color?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Color?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Color?[] Value2 { get; set; }
	}

	public class ColorArrayNullableProperties2 : MonoBehaviour, IValues<Color?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Color?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Color?[] Value2 { get; set; }
	}

	public class ColorListNullableField1 : MonoBehaviour, IValue<List<Color?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Color?> Value { get { return value; } set { this.value = value; } }
	}

	public class ColorListNullableField2 : MonoBehaviour, IValue<List<Color?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Color?> Value { get { return value; } set { this.value = value; } }
	}

	public class ColorListNullableFields1 : MonoBehaviour, IValues<List<Color?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Color?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Color?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Color?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorListNullableFields2 : MonoBehaviour, IValues<List<Color?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Color?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Color?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Color?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Color?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ColorListNullableProperty1 : MonoBehaviour, IValue<List<Color?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color?> Value { get; set; }
	}

	public class ColorListNullableProperty2 : MonoBehaviour, IValue<List<Color?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color?> Value { get; set; }
	}

	public class ColorListNullableProperties1 : MonoBehaviour, IValues<List<Color?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Color?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Color?> Value2 { get; set; }
	}

	public class ColorListNullableProperties2 : MonoBehaviour, IValues<List<Color?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Color?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Color?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618