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
	public class KeyframeField1 : MonoBehaviour, IValue<Keyframe>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Keyframe Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeField2 : MonoBehaviour, IValue<Keyframe>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Keyframe Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeFields1 : MonoBehaviour, IValues<Keyframe>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Keyframe value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Keyframe Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeFields2 : MonoBehaviour, IValues<Keyframe>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Keyframe value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Keyframe Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeProperty1 : MonoBehaviour, IValue<Keyframe>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe Value { get; set; }
	}

	public class KeyframeProperty2 : MonoBehaviour, IValue<Keyframe>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe Value { get; set; }
	}

	public class KeyframeProperties1 : MonoBehaviour, IValues<Keyframe>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Keyframe Value2 { get; set; }
	}

	public class KeyframeProperties2 : MonoBehaviour, IValues<Keyframe>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Keyframe Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe Value2 { get; set; }
	}

	public class KeyframeArrayField1 : MonoBehaviour, IValue<Keyframe[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Keyframe[] Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeArrayField2 : MonoBehaviour, IValue<Keyframe[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Keyframe[] Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeArrayFields1 : MonoBehaviour, IValues<Keyframe[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Keyframe[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Keyframe[] Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeArrayFields2 : MonoBehaviour, IValues<Keyframe[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Keyframe[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Keyframe[] Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeArrayProperty1 : MonoBehaviour, IValue<Keyframe[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe[] Value { get; set; }
	}

	public class KeyframeArrayProperty2 : MonoBehaviour, IValue<Keyframe[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe[] Value { get; set; }
	}

	public class KeyframeArrayProperties1 : MonoBehaviour, IValues<Keyframe[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Keyframe[] Value2 { get; set; }
	}

	public class KeyframeArrayProperties2 : MonoBehaviour, IValues<Keyframe[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Keyframe[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe[] Value2 { get; set; }
	}

	public class KeyframeListField1 : MonoBehaviour, IValue<List<Keyframe>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Keyframe> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Keyframe> Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeListField2 : MonoBehaviour, IValue<List<Keyframe>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Keyframe> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Keyframe> Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeListFields1 : MonoBehaviour, IValues<List<Keyframe>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Keyframe> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Keyframe> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Keyframe> Value1 { get { return value1; } set { value1 = value; } }
		public List<Keyframe> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeListFields2 : MonoBehaviour, IValues<List<Keyframe>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Keyframe> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Keyframe> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Keyframe> Value1 { get { return value1; } set { value1 = value; } }
		public List<Keyframe> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeListProperty1 : MonoBehaviour, IValue<List<Keyframe>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Keyframe> Value { get; set; }
	}

	public class KeyframeListProperty2 : MonoBehaviour, IValue<List<Keyframe>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Keyframe> Value { get; set; }
	}

	public class KeyframeListProperties1 : MonoBehaviour, IValues<List<Keyframe>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Keyframe> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Keyframe> Value2 { get; set; }
	}

	public class KeyframeListProperties2 : MonoBehaviour, IValues<List<Keyframe>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Keyframe> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Keyframe> Value2 { get; set; }
	}

	public class KeyframeNullableField1 : MonoBehaviour, IValue<Keyframe?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Keyframe? Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeNullableField2 : MonoBehaviour, IValue<Keyframe?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Keyframe? Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeNullableFields1 : MonoBehaviour, IValues<Keyframe?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Keyframe? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Keyframe? Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeNullableFields2 : MonoBehaviour, IValues<Keyframe?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Keyframe? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Keyframe? Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeNullableProperty1 : MonoBehaviour, IValue<Keyframe?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe? Value { get; set; }
	}

	public class KeyframeNullableProperty2 : MonoBehaviour, IValue<Keyframe?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe? Value { get; set; }
	}

	public class KeyframeNullableProperties1 : MonoBehaviour, IValues<Keyframe?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Keyframe? Value2 { get; set; }
	}

	public class KeyframeNullableProperties2 : MonoBehaviour, IValues<Keyframe?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Keyframe? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe? Value2 { get; set; }
	}

	public class KeyframeArrayNullableField1 : MonoBehaviour, IValue<Keyframe?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Keyframe?[] Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeArrayNullableField2 : MonoBehaviour, IValue<Keyframe?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Keyframe?[] Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeArrayNullableFields1 : MonoBehaviour, IValues<Keyframe?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Keyframe?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Keyframe?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Keyframe?[] Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeArrayNullableFields2 : MonoBehaviour, IValues<Keyframe?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Keyframe?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Keyframe?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Keyframe?[] Value1 { get { return value1; } set { value1 = value; } }
		public Keyframe?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeArrayNullableProperty1 : MonoBehaviour, IValue<Keyframe?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe?[] Value { get; set; }
	}

	public class KeyframeArrayNullableProperty2 : MonoBehaviour, IValue<Keyframe?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe?[] Value { get; set; }
	}

	public class KeyframeArrayNullableProperties1 : MonoBehaviour, IValues<Keyframe?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Keyframe?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Keyframe?[] Value2 { get; set; }
	}

	public class KeyframeArrayNullableProperties2 : MonoBehaviour, IValues<Keyframe?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Keyframe?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Keyframe?[] Value2 { get; set; }
	}

	public class KeyframeListNullableField1 : MonoBehaviour, IValue<List<Keyframe?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Keyframe?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Keyframe?> Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeListNullableField2 : MonoBehaviour, IValue<List<Keyframe?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Keyframe?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Keyframe?> Value { get { return value; } set { this.value = value; } }
	}

	public class KeyframeListNullableFields1 : MonoBehaviour, IValues<List<Keyframe?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Keyframe?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Keyframe?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Keyframe?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Keyframe?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeListNullableFields2 : MonoBehaviour, IValues<List<Keyframe?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Keyframe?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Keyframe?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Keyframe?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Keyframe?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class KeyframeListNullableProperty1 : MonoBehaviour, IValue<List<Keyframe?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Keyframe?> Value { get; set; }
	}

	public class KeyframeListNullableProperty2 : MonoBehaviour, IValue<List<Keyframe?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Keyframe?> Value { get; set; }
	}

	public class KeyframeListNullableProperties1 : MonoBehaviour, IValues<List<Keyframe?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Keyframe?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Keyframe?> Value2 { get; set; }
	}

	public class KeyframeListNullableProperties2 : MonoBehaviour, IValues<List<Keyframe?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Keyframe?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Keyframe?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618