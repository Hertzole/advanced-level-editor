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
	public class RectOffsetField1 : MonoBehaviour, IValue<RectOffset>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectOffset Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetField2 : MonoBehaviour, IValue<RectOffset>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectOffset Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetFields1 : MonoBehaviour, IValues<RectOffset>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectOffset value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectOffset Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetFields2 : MonoBehaviour, IValues<RectOffset>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectOffset value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectOffset Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetProperty1 : MonoBehaviour, IValue<RectOffset>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset Value { get; set; }
	}

	public class RectOffsetProperty2 : MonoBehaviour, IValue<RectOffset>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset Value { get; set; }
	}

	public class RectOffsetProperties1 : MonoBehaviour, IValues<RectOffset>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectOffset Value2 { get; set; }
	}

	public class RectOffsetProperties2 : MonoBehaviour, IValues<RectOffset>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectOffset Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset Value2 { get; set; }
	}

	public class RectOffsetArrayField1 : MonoBehaviour, IValue<RectOffset[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectOffset[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetArrayField2 : MonoBehaviour, IValue<RectOffset[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectOffset[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetArrayFields1 : MonoBehaviour, IValues<RectOffset[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectOffset[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectOffset[] Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetArrayFields2 : MonoBehaviour, IValues<RectOffset[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectOffset[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectOffset[] Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetArrayProperty1 : MonoBehaviour, IValue<RectOffset[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset[] Value { get; set; }
	}

	public class RectOffsetArrayProperty2 : MonoBehaviour, IValue<RectOffset[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset[] Value { get; set; }
	}

	public class RectOffsetArrayProperties1 : MonoBehaviour, IValues<RectOffset[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectOffset[] Value2 { get; set; }
	}

	public class RectOffsetArrayProperties2 : MonoBehaviour, IValues<RectOffset[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectOffset[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset[] Value2 { get; set; }
	}

	public class RectOffsetListField1 : MonoBehaviour, IValue<List<RectOffset>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectOffset> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<RectOffset> Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetListField2 : MonoBehaviour, IValue<List<RectOffset>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectOffset> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<RectOffset> Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetListFields1 : MonoBehaviour, IValues<List<RectOffset>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectOffset> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<RectOffset> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<RectOffset> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectOffset> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetListFields2 : MonoBehaviour, IValues<List<RectOffset>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<RectOffset> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectOffset> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<RectOffset> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectOffset> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetListProperty1 : MonoBehaviour, IValue<List<RectOffset>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectOffset> Value { get; set; }
	}

	public class RectOffsetListProperty2 : MonoBehaviour, IValue<List<RectOffset>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectOffset> Value { get; set; }
	}

	public class RectOffsetListProperties1 : MonoBehaviour, IValues<List<RectOffset>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectOffset> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<RectOffset> Value2 { get; set; }
	}

	public class RectOffsetListProperties2 : MonoBehaviour, IValues<List<RectOffset>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<RectOffset> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectOffset> Value2 { get; set; }
	}

	public class RectOffsetNullableField1 : MonoBehaviour, IValue<RectOffset?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectOffset? Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetNullableField2 : MonoBehaviour, IValue<RectOffset?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectOffset? Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetNullableFields1 : MonoBehaviour, IValues<RectOffset?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectOffset? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectOffset? Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetNullableFields2 : MonoBehaviour, IValues<RectOffset?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectOffset? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectOffset? Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetNullableProperty1 : MonoBehaviour, IValue<RectOffset?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset? Value { get; set; }
	}

	public class RectOffsetNullableProperty2 : MonoBehaviour, IValue<RectOffset?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset? Value { get; set; }
	}

	public class RectOffsetNullableProperties1 : MonoBehaviour, IValues<RectOffset?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectOffset? Value2 { get; set; }
	}

	public class RectOffsetNullableProperties2 : MonoBehaviour, IValues<RectOffset?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectOffset? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset? Value2 { get; set; }
	}

	public class RectOffsetArrayNullableField1 : MonoBehaviour, IValue<RectOffset?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public RectOffset?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetArrayNullableField2 : MonoBehaviour, IValue<RectOffset?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public RectOffset?[] Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetArrayNullableFields1 : MonoBehaviour, IValues<RectOffset?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private RectOffset?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private RectOffset?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public RectOffset?[] Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetArrayNullableFields2 : MonoBehaviour, IValues<RectOffset?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private RectOffset?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private RectOffset?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public RectOffset?[] Value1 { get { return value1; } set { value1 = value; } }
		public RectOffset?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetArrayNullableProperty1 : MonoBehaviour, IValue<RectOffset?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset?[] Value { get; set; }
	}

	public class RectOffsetArrayNullableProperty2 : MonoBehaviour, IValue<RectOffset?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset?[] Value { get; set; }
	}

	public class RectOffsetArrayNullableProperties1 : MonoBehaviour, IValues<RectOffset?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public RectOffset?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public RectOffset?[] Value2 { get; set; }
	}

	public class RectOffsetArrayNullableProperties2 : MonoBehaviour, IValues<RectOffset?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public RectOffset?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public RectOffset?[] Value2 { get; set; }
	}

	public class RectOffsetListNullableField1 : MonoBehaviour, IValue<List<RectOffset?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectOffset?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<RectOffset?> Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetListNullableField2 : MonoBehaviour, IValue<List<RectOffset?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectOffset?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<RectOffset?> Value { get { return value; } set { this.value = value; } }
	}

	public class RectOffsetListNullableFields1 : MonoBehaviour, IValues<List<RectOffset?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<RectOffset?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<RectOffset?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<RectOffset?> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectOffset?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetListNullableFields2 : MonoBehaviour, IValues<List<RectOffset?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<RectOffset?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<RectOffset?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<RectOffset?> Value1 { get { return value1; } set { value1 = value; } }
		public List<RectOffset?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class RectOffsetListNullableProperty1 : MonoBehaviour, IValue<List<RectOffset?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectOffset?> Value { get; set; }
	}

	public class RectOffsetListNullableProperty2 : MonoBehaviour, IValue<List<RectOffset?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectOffset?> Value { get; set; }
	}

	public class RectOffsetListNullableProperties1 : MonoBehaviour, IValues<List<RectOffset?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<RectOffset?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<RectOffset?> Value2 { get; set; }
	}

	public class RectOffsetListNullableProperties2 : MonoBehaviour, IValues<List<RectOffset?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<RectOffset?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<RectOffset?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618