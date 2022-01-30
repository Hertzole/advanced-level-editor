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
	public class GuidField1 : MonoBehaviour, IValue<Guid>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Guid Value { get { return value; } set { this.value = value; } }
	}

	public class GuidField2 : MonoBehaviour, IValue<Guid>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Guid Value { get { return value; } set { this.value = value; } }
	}

	public class GuidFields1 : MonoBehaviour, IValues<Guid>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Guid value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Guid Value1 { get { return value1; } set { value1 = value; } }
		public Guid Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidFields2 : MonoBehaviour, IValues<Guid>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Guid value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Guid Value1 { get { return value1; } set { value1 = value; } }
		public Guid Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidProperty1 : MonoBehaviour, IValue<Guid>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid Value { get; set; }
	}

	public class GuidProperty2 : MonoBehaviour, IValue<Guid>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid Value { get; set; }
	}

	public class GuidProperties1 : MonoBehaviour, IValues<Guid>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Guid Value2 { get; set; }
	}

	public class GuidProperties2 : MonoBehaviour, IValues<Guid>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Guid Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid Value2 { get; set; }
	}

	public class GuidArrayField1 : MonoBehaviour, IValue<Guid[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Guid[] Value { get { return value; } set { this.value = value; } }
	}

	public class GuidArrayField2 : MonoBehaviour, IValue<Guid[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Guid[] Value { get { return value; } set { this.value = value; } }
	}

	public class GuidArrayFields1 : MonoBehaviour, IValues<Guid[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Guid[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Guid[] Value1 { get { return value1; } set { value1 = value; } }
		public Guid[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidArrayFields2 : MonoBehaviour, IValues<Guid[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Guid[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Guid[] Value1 { get { return value1; } set { value1 = value; } }
		public Guid[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidArrayProperty1 : MonoBehaviour, IValue<Guid[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid[] Value { get; set; }
	}

	public class GuidArrayProperty2 : MonoBehaviour, IValue<Guid[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid[] Value { get; set; }
	}

	public class GuidArrayProperties1 : MonoBehaviour, IValues<Guid[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Guid[] Value2 { get; set; }
	}

	public class GuidArrayProperties2 : MonoBehaviour, IValues<Guid[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Guid[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid[] Value2 { get; set; }
	}

	public class GuidListField1 : MonoBehaviour, IValue<List<Guid>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Guid> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Guid> Value { get { return value; } set { this.value = value; } }
	}

	public class GuidListField2 : MonoBehaviour, IValue<List<Guid>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Guid> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Guid> Value { get { return value; } set { this.value = value; } }
	}

	public class GuidListFields1 : MonoBehaviour, IValues<List<Guid>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Guid> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Guid> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Guid> Value1 { get { return value1; } set { value1 = value; } }
		public List<Guid> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidListFields2 : MonoBehaviour, IValues<List<Guid>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Guid> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Guid> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Guid> Value1 { get { return value1; } set { value1 = value; } }
		public List<Guid> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidListProperty1 : MonoBehaviour, IValue<List<Guid>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Guid> Value { get; set; }
	}

	public class GuidListProperty2 : MonoBehaviour, IValue<List<Guid>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Guid> Value { get; set; }
	}

	public class GuidListProperties1 : MonoBehaviour, IValues<List<Guid>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Guid> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Guid> Value2 { get; set; }
	}

	public class GuidListProperties2 : MonoBehaviour, IValues<List<Guid>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Guid> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Guid> Value2 { get; set; }
	}

	public class GuidNullableField1 : MonoBehaviour, IValue<Guid?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Guid? Value { get { return value; } set { this.value = value; } }
	}

	public class GuidNullableField2 : MonoBehaviour, IValue<Guid?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Guid? Value { get { return value; } set { this.value = value; } }
	}

	public class GuidNullableFields1 : MonoBehaviour, IValues<Guid?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Guid? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Guid? Value1 { get { return value1; } set { value1 = value; } }
		public Guid? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidNullableFields2 : MonoBehaviour, IValues<Guid?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Guid? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Guid? Value1 { get { return value1; } set { value1 = value; } }
		public Guid? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidNullableProperty1 : MonoBehaviour, IValue<Guid?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid? Value { get; set; }
	}

	public class GuidNullableProperty2 : MonoBehaviour, IValue<Guid?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid? Value { get; set; }
	}

	public class GuidNullableProperties1 : MonoBehaviour, IValues<Guid?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Guid? Value2 { get; set; }
	}

	public class GuidNullableProperties2 : MonoBehaviour, IValues<Guid?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Guid? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid? Value2 { get; set; }
	}

	public class GuidArrayNullableField1 : MonoBehaviour, IValue<Guid?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public Guid?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GuidArrayNullableField2 : MonoBehaviour, IValue<Guid?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public Guid?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GuidArrayNullableFields1 : MonoBehaviour, IValues<Guid?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private Guid?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private Guid?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public Guid?[] Value1 { get { return value1; } set { value1 = value; } }
		public Guid?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidArrayNullableFields2 : MonoBehaviour, IValues<Guid?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private Guid?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private Guid?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public Guid?[] Value1 { get { return value1; } set { value1 = value; } }
		public Guid?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidArrayNullableProperty1 : MonoBehaviour, IValue<Guid?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid?[] Value { get; set; }
	}

	public class GuidArrayNullableProperty2 : MonoBehaviour, IValue<Guid?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid?[] Value { get; set; }
	}

	public class GuidArrayNullableProperties1 : MonoBehaviour, IValues<Guid?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public Guid?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public Guid?[] Value2 { get; set; }
	}

	public class GuidArrayNullableProperties2 : MonoBehaviour, IValues<Guid?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public Guid?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public Guid?[] Value2 { get; set; }
	}

	public class GuidListNullableField1 : MonoBehaviour, IValue<List<Guid?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Guid?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<Guid?> Value { get { return value; } set { this.value = value; } }
	}

	public class GuidListNullableField2 : MonoBehaviour, IValue<List<Guid?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Guid?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<Guid?> Value { get { return value; } set { this.value = value; } }
	}

	public class GuidListNullableFields1 : MonoBehaviour, IValues<List<Guid?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<Guid?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<Guid?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<Guid?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Guid?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidListNullableFields2 : MonoBehaviour, IValues<List<Guid?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<Guid?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<Guid?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<Guid?> Value1 { get { return value1; } set { value1 = value; } }
		public List<Guid?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GuidListNullableProperty1 : MonoBehaviour, IValue<List<Guid?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Guid?> Value { get; set; }
	}

	public class GuidListNullableProperty2 : MonoBehaviour, IValue<List<Guid?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Guid?> Value { get; set; }
	}

	public class GuidListNullableProperties1 : MonoBehaviour, IValues<List<Guid?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<Guid?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<Guid?> Value2 { get; set; }
	}

	public class GuidListNullableProperties2 : MonoBehaviour, IValues<List<Guid?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<Guid?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<Guid?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618