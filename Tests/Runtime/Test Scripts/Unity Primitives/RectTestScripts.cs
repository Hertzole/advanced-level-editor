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
	public class RectField1 : MonoBehaviour, IValue<Rect>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Rect Value { get { return value; } set { this.value = value; } }
	}

	public class RectField2 : MonoBehaviour, IValue<Rect>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Rect Value { get { return value; } set { this.value = value; } }
	}

	public class RectFields1 : MonoBehaviour, IValues<Rect>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Rect value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Rect Value1 { get { return value1; } set { value1 = value; } }
		public Rect Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectFields2 : MonoBehaviour, IValues<Rect>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Rect value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Rect Value1 { get { return value1; } set { value1 = value; } }
		public Rect Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectProperty1 : MonoBehaviour, IValue<Rect>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect Value { get; set; }
	}

	public class RectProperty2 : MonoBehaviour, IValue<Rect>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect Value { get; set; }
	}

	public class RectProperties1 : MonoBehaviour, IValues<Rect>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Rect Value2 { get; set; }
	}

	public class RectProperties2 : MonoBehaviour, IValues<Rect>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Rect Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect Value2 { get; set; }
	}

	public class RectArrayField1 : MonoBehaviour, IValue<Rect[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Rect[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectArrayField2 : MonoBehaviour, IValue<Rect[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Rect[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectArrayFields1 : MonoBehaviour, IValues<Rect[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Rect[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Rect[] Value1 { get { return value1; } set { value1 = value; } }
		public Rect[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectArrayFields2 : MonoBehaviour, IValues<Rect[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Rect[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Rect[] Value1 { get { return value1; } set { value1 = value; } }
		public Rect[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectArrayProperty1 : MonoBehaviour, IValue<Rect[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect[] Value { get; set; }
	}

	public class RectArrayProperty2 : MonoBehaviour, IValue<Rect[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect[] Value { get; set; }
	}

	public class RectArrayProperties1 : MonoBehaviour, IValues<Rect[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Rect[] Value2 { get; set; }
	}

	public class RectArrayProperties2 : MonoBehaviour, IValues<Rect[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Rect[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect[] Value2 { get; set; }
	}

	public class RectListField1 : MonoBehaviour, IValue<List<Rect>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Rect> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Rect> Value { get { return value; } set { this.value = value; } }
	}

	public class RectListField2 : MonoBehaviour, IValue<List<Rect>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Rect> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Rect> Value { get { return value; } set { this.value = value; } }
	}

	public class RectListFields1 : MonoBehaviour, IValues<List<Rect>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Rect> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Rect> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Rect> Value1 { get { return value1; } set { value1 = value; } }
		public List<Rect> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectListFields2 : MonoBehaviour, IValues<List<Rect>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Rect> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Rect> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Rect> Value1 { get { return value1; } set { value1 = value; } }
		public List<Rect> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectListProperty1 : MonoBehaviour, IValue<List<Rect>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Rect> Value { get; set; }
	}

	public class RectListProperty2 : MonoBehaviour, IValue<List<Rect>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Rect> Value { get; set; }
	}

	public class RectListProperties1 : MonoBehaviour, IValues<List<Rect>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Rect> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Rect> Value2 { get; set; }
	}

	public class RectListProperties2 : MonoBehaviour, IValues<List<Rect>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Rect> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Rect> Value2 { get; set; }
	}

	public class RectNullableField1 : MonoBehaviour, IValue<Rect?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Rect? Value { get { return value; } set { this.value = value; } }
	}

	public class RectNullableField2 : MonoBehaviour, IValue<Rect?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Rect? Value { get { return value; } set { this.value = value; } }
	}

	public class RectNullableFields1 : MonoBehaviour, IValues<Rect?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Rect? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Rect? Value1 { get { return value1; } set { value1 = value; } }
		public Rect? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectNullableFields2 : MonoBehaviour, IValues<Rect?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Rect? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Rect? Value1 { get { return value1; } set { value1 = value; } }
		public Rect? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectNullableProperty1 : MonoBehaviour, IValue<Rect?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect? Value { get; set; }
	}

	public class RectNullableProperty2 : MonoBehaviour, IValue<Rect?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect? Value { get; set; }
	}

	public class RectNullableProperties1 : MonoBehaviour, IValues<Rect?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Rect? Value2 { get; set; }
	}

	public class RectNullableProperties2 : MonoBehaviour, IValues<Rect?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Rect? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect? Value2 { get; set; }
	}

	public class RectArrayNullableField1 : MonoBehaviour, IValue<Rect?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Rect?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectArrayNullableField2 : MonoBehaviour, IValue<Rect?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Rect?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectArrayNullableFields1 : MonoBehaviour, IValues<Rect?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Rect?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Rect?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Rect?[] Value1 { get { return value1; } set { value1 = value; } }
		public Rect?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectArrayNullableFields2 : MonoBehaviour, IValues<Rect?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Rect?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Rect?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Rect?[] Value1 { get { return value1; } set { value1 = value; } }
		public Rect?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectArrayNullableProperty1 : MonoBehaviour, IValue<Rect?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect?[] Value { get; set; }
	}

	public class RectArrayNullableProperty2 : MonoBehaviour, IValue<Rect?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect?[] Value { get; set; }
	}

	public class RectArrayNullableProperties1 : MonoBehaviour, IValues<Rect?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Rect?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Rect?[] Value2 { get; set; }
	}

	public class RectArrayNullableProperties2 : MonoBehaviour, IValues<Rect?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Rect?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Rect?[] Value2 { get; set; }
	}

	public class RectListNullableField1 : MonoBehaviour, IValue<List<Rect?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Rect?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Rect?> Value { get { return value; } set { this.value = value; } }
	}

	public class RectListNullableField2 : MonoBehaviour, IValue<List<Rect?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Rect?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Rect?> Value { get { return value; } set { this.value = value; } }
	}

	public class RectListNullableFields1 : MonoBehaviour, IValues<List<Rect?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Rect?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Rect?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Rect?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Rect?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectListNullableFields2 : MonoBehaviour, IValues<List<Rect?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Rect?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Rect?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Rect?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Rect?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectListNullableProperty1 : MonoBehaviour, IValue<List<Rect?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Rect?> Value { get; set; }
	}

	public class RectListNullableProperty2 : MonoBehaviour, IValue<List<Rect?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Rect?> Value { get; set; }
	}

	public class RectListNullableProperties1 : MonoBehaviour, IValues<List<Rect?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Rect?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Rect?> Value2 { get; set; }
	}

	public class RectListNullableProperties2 : MonoBehaviour, IValues<List<Rect?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Rect?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Rect?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618