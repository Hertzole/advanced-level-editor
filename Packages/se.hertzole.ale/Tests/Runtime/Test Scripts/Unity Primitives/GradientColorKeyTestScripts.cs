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
	public class GradientColorKeyField1 : MonoBehaviour, IValue<GradientColorKey>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GradientColorKey Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyField2 : MonoBehaviour, IValue<GradientColorKey>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GradientColorKey Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyFields1 : MonoBehaviour, IValues<GradientColorKey>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GradientColorKey value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GradientColorKey Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyFields2 : MonoBehaviour, IValues<GradientColorKey>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GradientColorKey value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GradientColorKey Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyProperty1 : MonoBehaviour, IValue<GradientColorKey>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey Value { get; set; }
	}

	public class GradientColorKeyProperty2 : MonoBehaviour, IValue<GradientColorKey>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey Value { get; set; }
	}

	public class GradientColorKeyProperties1 : MonoBehaviour, IValues<GradientColorKey>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GradientColorKey Value2 { get; set; }
	}

	public class GradientColorKeyProperties2 : MonoBehaviour, IValues<GradientColorKey>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GradientColorKey Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey Value2 { get; set; }
	}

	public class GradientColorKeyArrayField1 : MonoBehaviour, IValue<GradientColorKey[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GradientColorKey[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyArrayField2 : MonoBehaviour, IValue<GradientColorKey[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GradientColorKey[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyArrayFields1 : MonoBehaviour, IValues<GradientColorKey[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GradientColorKey[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GradientColorKey[] Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyArrayFields2 : MonoBehaviour, IValues<GradientColorKey[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GradientColorKey[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GradientColorKey[] Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyArrayProperty1 : MonoBehaviour, IValue<GradientColorKey[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey[] Value { get; set; }
	}

	public class GradientColorKeyArrayProperty2 : MonoBehaviour, IValue<GradientColorKey[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey[] Value { get; set; }
	}

	public class GradientColorKeyArrayProperties1 : MonoBehaviour, IValues<GradientColorKey[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GradientColorKey[] Value2 { get; set; }
	}

	public class GradientColorKeyArrayProperties2 : MonoBehaviour, IValues<GradientColorKey[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GradientColorKey[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey[] Value2 { get; set; }
	}

	public class GradientColorKeyListField1 : MonoBehaviour, IValue<List<GradientColorKey>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GradientColorKey> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<GradientColorKey> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyListField2 : MonoBehaviour, IValue<List<GradientColorKey>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GradientColorKey> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<GradientColorKey> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyListFields1 : MonoBehaviour, IValues<List<GradientColorKey>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GradientColorKey> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<GradientColorKey> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<GradientColorKey> Value1 { get { return value1; } set { value1 = value; } }
		public List<GradientColorKey> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyListFields2 : MonoBehaviour, IValues<List<GradientColorKey>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<GradientColorKey> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GradientColorKey> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<GradientColorKey> Value1 { get { return value1; } set { value1 = value; } }
		public List<GradientColorKey> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyListProperty1 : MonoBehaviour, IValue<List<GradientColorKey>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GradientColorKey> Value { get; set; }
	}

	public class GradientColorKeyListProperty2 : MonoBehaviour, IValue<List<GradientColorKey>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GradientColorKey> Value { get; set; }
	}

	public class GradientColorKeyListProperties1 : MonoBehaviour, IValues<List<GradientColorKey>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GradientColorKey> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<GradientColorKey> Value2 { get; set; }
	}

	public class GradientColorKeyListProperties2 : MonoBehaviour, IValues<List<GradientColorKey>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<GradientColorKey> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GradientColorKey> Value2 { get; set; }
	}

	public class GradientColorKeyNullableField1 : MonoBehaviour, IValue<GradientColorKey?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GradientColorKey? Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyNullableField2 : MonoBehaviour, IValue<GradientColorKey?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GradientColorKey? Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyNullableFields1 : MonoBehaviour, IValues<GradientColorKey?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GradientColorKey? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GradientColorKey? Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyNullableFields2 : MonoBehaviour, IValues<GradientColorKey?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GradientColorKey? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GradientColorKey? Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyNullableProperty1 : MonoBehaviour, IValue<GradientColorKey?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey? Value { get; set; }
	}

	public class GradientColorKeyNullableProperty2 : MonoBehaviour, IValue<GradientColorKey?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey? Value { get; set; }
	}

	public class GradientColorKeyNullableProperties1 : MonoBehaviour, IValues<GradientColorKey?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GradientColorKey? Value2 { get; set; }
	}

	public class GradientColorKeyNullableProperties2 : MonoBehaviour, IValues<GradientColorKey?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GradientColorKey? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey? Value2 { get; set; }
	}

	public class GradientColorKeyArrayNullableField1 : MonoBehaviour, IValue<GradientColorKey?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GradientColorKey?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyArrayNullableField2 : MonoBehaviour, IValue<GradientColorKey?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GradientColorKey?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyArrayNullableFields1 : MonoBehaviour, IValues<GradientColorKey?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GradientColorKey?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GradientColorKey?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GradientColorKey?[] Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyArrayNullableFields2 : MonoBehaviour, IValues<GradientColorKey?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GradientColorKey?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GradientColorKey?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GradientColorKey?[] Value1 { get { return value1; } set { value1 = value; } }
		public GradientColorKey?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyArrayNullableProperty1 : MonoBehaviour, IValue<GradientColorKey?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey?[] Value { get; set; }
	}

	public class GradientColorKeyArrayNullableProperty2 : MonoBehaviour, IValue<GradientColorKey?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey?[] Value { get; set; }
	}

	public class GradientColorKeyArrayNullableProperties1 : MonoBehaviour, IValues<GradientColorKey?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GradientColorKey?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GradientColorKey?[] Value2 { get; set; }
	}

	public class GradientColorKeyArrayNullableProperties2 : MonoBehaviour, IValues<GradientColorKey?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GradientColorKey?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GradientColorKey?[] Value2 { get; set; }
	}

	public class GradientColorKeyListNullableField1 : MonoBehaviour, IValue<List<GradientColorKey?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GradientColorKey?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<GradientColorKey?> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyListNullableField2 : MonoBehaviour, IValue<List<GradientColorKey?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GradientColorKey?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<GradientColorKey?> Value { get { return value; } set { this.value = value; } }
	}

	public class GradientColorKeyListNullableFields1 : MonoBehaviour, IValues<List<GradientColorKey?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GradientColorKey?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<GradientColorKey?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<GradientColorKey?> Value1 { get { return value1; } set { value1 = value; } }
		public List<GradientColorKey?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyListNullableFields2 : MonoBehaviour, IValues<List<GradientColorKey?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<GradientColorKey?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GradientColorKey?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<GradientColorKey?> Value1 { get { return value1; } set { value1 = value; } }
		public List<GradientColorKey?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GradientColorKeyListNullableProperty1 : MonoBehaviour, IValue<List<GradientColorKey?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GradientColorKey?> Value { get; set; }
	}

	public class GradientColorKeyListNullableProperty2 : MonoBehaviour, IValue<List<GradientColorKey?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GradientColorKey?> Value { get; set; }
	}

	public class GradientColorKeyListNullableProperties1 : MonoBehaviour, IValues<List<GradientColorKey?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GradientColorKey?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<GradientColorKey?> Value2 { get; set; }
	}

	public class GradientColorKeyListNullableProperties2 : MonoBehaviour, IValues<List<GradientColorKey?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<GradientColorKey?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GradientColorKey?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618