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
	public class ScriptReferenceField1 : MonoBehaviour, IValue<ScriptReference>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ScriptReference Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceField2 : MonoBehaviour, IValue<ScriptReference>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ScriptReference Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceFields1 : MonoBehaviour, IValues<ScriptReference>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ScriptReference value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ScriptReference Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceFields2 : MonoBehaviour, IValues<ScriptReference>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ScriptReference value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ScriptReference Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceProperty1 : MonoBehaviour, IValue<ScriptReference>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference Value { get; set; }
	}

	public class ScriptReferenceProperty2 : MonoBehaviour, IValue<ScriptReference>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference Value { get; set; }
	}

	public class ScriptReferenceProperties1 : MonoBehaviour, IValues<ScriptReference>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ScriptReference Value2 { get; set; }
	}

	public class ScriptReferenceProperties2 : MonoBehaviour, IValues<ScriptReference>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ScriptReference Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference Value2 { get; set; }
	}

	public class ScriptReferenceArrayField1 : MonoBehaviour, IValue<ScriptReference[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ScriptReference[] Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceArrayField2 : MonoBehaviour, IValue<ScriptReference[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ScriptReference[] Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceArrayFields1 : MonoBehaviour, IValues<ScriptReference[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ScriptReference[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ScriptReference[] Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceArrayFields2 : MonoBehaviour, IValues<ScriptReference[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ScriptReference[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ScriptReference[] Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceArrayProperty1 : MonoBehaviour, IValue<ScriptReference[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference[] Value { get; set; }
	}

	public class ScriptReferenceArrayProperty2 : MonoBehaviour, IValue<ScriptReference[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference[] Value { get; set; }
	}

	public class ScriptReferenceArrayProperties1 : MonoBehaviour, IValues<ScriptReference[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ScriptReference[] Value2 { get; set; }
	}

	public class ScriptReferenceArrayProperties2 : MonoBehaviour, IValues<ScriptReference[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ScriptReference[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference[] Value2 { get; set; }
	}

	public class ScriptReferenceListField1 : MonoBehaviour, IValue<List<ScriptReference>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ScriptReference> value = new List<ScriptReference>();

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ScriptReference> Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceListField2 : MonoBehaviour, IValue<List<ScriptReference>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ScriptReference> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ScriptReference> Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceListFields1 : MonoBehaviour, IValues<List<ScriptReference>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ScriptReference> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<ScriptReference> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<ScriptReference> Value1 { get { return value1; } set { value1 = value; } }
		public List<ScriptReference> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceListFields2 : MonoBehaviour, IValues<List<ScriptReference>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<ScriptReference> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ScriptReference> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<ScriptReference> Value1 { get { return value1; } set { value1 = value; } }
		public List<ScriptReference> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceListProperty1 : MonoBehaviour, IValue<List<ScriptReference>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ScriptReference> Value { get; set; }
	}

	public class ScriptReferenceListProperty2 : MonoBehaviour, IValue<List<ScriptReference>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ScriptReference> Value { get; set; }
	}

	public class ScriptReferenceListProperties1 : MonoBehaviour, IValues<List<ScriptReference>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ScriptReference> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ScriptReference> Value2 { get; set; }
	}

	public class ScriptReferenceListProperties2 : MonoBehaviour, IValues<List<ScriptReference>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ScriptReference> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ScriptReference> Value2 { get; set; }
	}

	public class ScriptReferenceNullableField1 : MonoBehaviour, IValue<ScriptReference?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ScriptReference? Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceNullableField2 : MonoBehaviour, IValue<ScriptReference?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ScriptReference? Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceNullableFields1 : MonoBehaviour, IValues<ScriptReference?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ScriptReference? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ScriptReference? Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceNullableFields2 : MonoBehaviour, IValues<ScriptReference?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ScriptReference? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ScriptReference? Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceNullableProperty1 : MonoBehaviour, IValue<ScriptReference?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference? Value { get; set; }
	}

	public class ScriptReferenceNullableProperty2 : MonoBehaviour, IValue<ScriptReference?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference? Value { get; set; }
	}

	public class ScriptReferenceNullableProperties1 : MonoBehaviour, IValues<ScriptReference?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ScriptReference? Value2 { get; set; }
	}

	public class ScriptReferenceNullableProperties2 : MonoBehaviour, IValues<ScriptReference?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ScriptReference? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference? Value2 { get; set; }
	}

	public class ScriptReferenceArrayNullableField1 : MonoBehaviour, IValue<ScriptReference?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ScriptReference?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceArrayNullableField2 : MonoBehaviour, IValue<ScriptReference?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ScriptReference?[] Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceArrayNullableFields1 : MonoBehaviour, IValues<ScriptReference?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ScriptReference?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ScriptReference?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ScriptReference?[] Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceArrayNullableFields2 : MonoBehaviour, IValues<ScriptReference?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ScriptReference?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ScriptReference?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ScriptReference?[] Value1 { get { return value1; } set { value1 = value; } }
		public ScriptReference?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceArrayNullableProperty1 : MonoBehaviour, IValue<ScriptReference?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference?[] Value { get; set; }
	}

	public class ScriptReferenceArrayNullableProperty2 : MonoBehaviour, IValue<ScriptReference?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference?[] Value { get; set; }
	}

	public class ScriptReferenceArrayNullableProperties1 : MonoBehaviour, IValues<ScriptReference?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ScriptReference?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ScriptReference?[] Value2 { get; set; }
	}

	public class ScriptReferenceArrayNullableProperties2 : MonoBehaviour, IValues<ScriptReference?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ScriptReference?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ScriptReference?[] Value2 { get; set; }
	}

	public class ScriptReferenceListNullableField1 : MonoBehaviour, IValue<List<ScriptReference?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ScriptReference?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ScriptReference?> Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceListNullableField2 : MonoBehaviour, IValue<List<ScriptReference?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ScriptReference?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ScriptReference?> Value { get { return value; } set { this.value = value; } }
	}

	public class ScriptReferenceListNullableFields1 : MonoBehaviour, IValues<List<ScriptReference?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ScriptReference?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<ScriptReference?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<ScriptReference?> Value1 { get { return value1; } set { value1 = value; } }
		public List<ScriptReference?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceListNullableFields2 : MonoBehaviour, IValues<List<ScriptReference?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<ScriptReference?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ScriptReference?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<ScriptReference?> Value1 { get { return value1; } set { value1 = value; } }
		public List<ScriptReference?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class ScriptReferenceListNullableProperty1 : MonoBehaviour, IValue<List<ScriptReference?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ScriptReference?> Value { get; set; }
	}

	public class ScriptReferenceListNullableProperty2 : MonoBehaviour, IValue<List<ScriptReference?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ScriptReference?> Value { get; set; }
	}

	public class ScriptReferenceListNullableProperties1 : MonoBehaviour, IValues<List<ScriptReference?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ScriptReference?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ScriptReference?> Value2 { get; set; }
	}

	public class ScriptReferenceListNullableProperties2 : MonoBehaviour, IValues<List<ScriptReference?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ScriptReference?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ScriptReference?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618