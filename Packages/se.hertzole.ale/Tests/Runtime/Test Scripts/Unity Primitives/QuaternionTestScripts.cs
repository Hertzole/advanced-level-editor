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
	public class QuaternionField1 : MonoBehaviour, IValue<Quaternion>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Quaternion Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionField2 : MonoBehaviour, IValue<Quaternion>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Quaternion Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionFields1 : MonoBehaviour, IValues<Quaternion>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Quaternion value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Quaternion Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionFields2 : MonoBehaviour, IValues<Quaternion>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Quaternion value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Quaternion Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionProperty1 : MonoBehaviour, IValue<Quaternion>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion Value { get; set; }
	}

	public class QuaternionProperty2 : MonoBehaviour, IValue<Quaternion>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion Value { get; set; }
	}

	public class QuaternionProperties1 : MonoBehaviour, IValues<Quaternion>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Quaternion Value2 { get; set; }
	}

	public class QuaternionProperties2 : MonoBehaviour, IValues<Quaternion>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Quaternion Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion Value2 { get; set; }
	}

	public class QuaternionArrayField1 : MonoBehaviour, IValue<Quaternion[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Quaternion[] Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionArrayField2 : MonoBehaviour, IValue<Quaternion[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Quaternion[] Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionArrayFields1 : MonoBehaviour, IValues<Quaternion[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Quaternion[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Quaternion[] Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionArrayFields2 : MonoBehaviour, IValues<Quaternion[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Quaternion[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Quaternion[] Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionArrayProperty1 : MonoBehaviour, IValue<Quaternion[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion[] Value { get; set; }
	}

	public class QuaternionArrayProperty2 : MonoBehaviour, IValue<Quaternion[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion[] Value { get; set; }
	}

	public class QuaternionArrayProperties1 : MonoBehaviour, IValues<Quaternion[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Quaternion[] Value2 { get; set; }
	}

	public class QuaternionArrayProperties2 : MonoBehaviour, IValues<Quaternion[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Quaternion[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion[] Value2 { get; set; }
	}

	public class QuaternionListField1 : MonoBehaviour, IValue<List<Quaternion>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Quaternion> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Quaternion> Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionListField2 : MonoBehaviour, IValue<List<Quaternion>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Quaternion> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Quaternion> Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionListFields1 : MonoBehaviour, IValues<List<Quaternion>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Quaternion> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Quaternion> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Quaternion> Value1 { get { return value1; } set { value1 = value; } }
		public List<Quaternion> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionListFields2 : MonoBehaviour, IValues<List<Quaternion>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Quaternion> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Quaternion> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Quaternion> Value1 { get { return value1; } set { value1 = value; } }
		public List<Quaternion> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionListProperty1 : MonoBehaviour, IValue<List<Quaternion>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Quaternion> Value { get; set; }
	}

	public class QuaternionListProperty2 : MonoBehaviour, IValue<List<Quaternion>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Quaternion> Value { get; set; }
	}

	public class QuaternionListProperties1 : MonoBehaviour, IValues<List<Quaternion>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Quaternion> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Quaternion> Value2 { get; set; }
	}

	public class QuaternionListProperties2 : MonoBehaviour, IValues<List<Quaternion>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Quaternion> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Quaternion> Value2 { get; set; }
	}

	public class QuaternionNullableField1 : MonoBehaviour, IValue<Quaternion?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Quaternion? Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionNullableField2 : MonoBehaviour, IValue<Quaternion?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Quaternion? Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionNullableFields1 : MonoBehaviour, IValues<Quaternion?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Quaternion? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Quaternion? Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionNullableFields2 : MonoBehaviour, IValues<Quaternion?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Quaternion? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Quaternion? Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionNullableProperty1 : MonoBehaviour, IValue<Quaternion?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion? Value { get; set; }
	}

	public class QuaternionNullableProperty2 : MonoBehaviour, IValue<Quaternion?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion? Value { get; set; }
	}

	public class QuaternionNullableProperties1 : MonoBehaviour, IValues<Quaternion?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Quaternion? Value2 { get; set; }
	}

	public class QuaternionNullableProperties2 : MonoBehaviour, IValues<Quaternion?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Quaternion? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion? Value2 { get; set; }
	}

	public class QuaternionArrayNullableField1 : MonoBehaviour, IValue<Quaternion?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Quaternion?[] Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionArrayNullableField2 : MonoBehaviour, IValue<Quaternion?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Quaternion?[] Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionArrayNullableFields1 : MonoBehaviour, IValues<Quaternion?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Quaternion?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Quaternion?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Quaternion?[] Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionArrayNullableFields2 : MonoBehaviour, IValues<Quaternion?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Quaternion?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Quaternion?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Quaternion?[] Value1 { get { return value1; } set { value1 = value; } }
		public Quaternion?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionArrayNullableProperty1 : MonoBehaviour, IValue<Quaternion?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion?[] Value { get; set; }
	}

	public class QuaternionArrayNullableProperty2 : MonoBehaviour, IValue<Quaternion?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion?[] Value { get; set; }
	}

	public class QuaternionArrayNullableProperties1 : MonoBehaviour, IValues<Quaternion?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Quaternion?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Quaternion?[] Value2 { get; set; }
	}

	public class QuaternionArrayNullableProperties2 : MonoBehaviour, IValues<Quaternion?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Quaternion?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Quaternion?[] Value2 { get; set; }
	}

	public class QuaternionListNullableField1 : MonoBehaviour, IValue<List<Quaternion?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Quaternion?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Quaternion?> Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionListNullableField2 : MonoBehaviour, IValue<List<Quaternion?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Quaternion?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Quaternion?> Value { get { return value; } set { this.value = value; } }
	}

	public class QuaternionListNullableFields1 : MonoBehaviour, IValues<List<Quaternion?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Quaternion?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Quaternion?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Quaternion?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Quaternion?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionListNullableFields2 : MonoBehaviour, IValues<List<Quaternion?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Quaternion?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Quaternion?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Quaternion?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Quaternion?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class QuaternionListNullableProperty1 : MonoBehaviour, IValue<List<Quaternion?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Quaternion?> Value { get; set; }
	}

	public class QuaternionListNullableProperty2 : MonoBehaviour, IValue<List<Quaternion?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Quaternion?> Value { get; set; }
	}

	public class QuaternionListNullableProperties1 : MonoBehaviour, IValues<List<Quaternion?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Quaternion?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Quaternion?> Value2 { get; set; }
	}

	public class QuaternionListNullableProperties2 : MonoBehaviour, IValues<List<Quaternion?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Quaternion?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Quaternion?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618