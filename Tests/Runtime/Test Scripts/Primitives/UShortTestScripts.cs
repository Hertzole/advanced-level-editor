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
	public class UshortField1 : MonoBehaviour, IValue<ushort>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort Value { get { return value; } set { this.value = value; } }
	}

	public class UshortField2 : MonoBehaviour, IValue<ushort>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort Value { get { return value; } set { this.value = value; } }
	}

	public class UshortFields1 : MonoBehaviour, IValues<ushort>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ushort value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ushort Value1 { get { return value1; } set { value1 = value; } }
		public ushort Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortFields2 : MonoBehaviour, IValues<ushort>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ushort value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ushort Value1 { get { return value1; } set { value1 = value; } }
		public ushort Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortProperty1 : MonoBehaviour, IValue<ushort>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort Value { get; set; }
	}

	public class UshortProperty2 : MonoBehaviour, IValue<ushort>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort Value { get; set; }
	}

	public class UshortProperties1 : MonoBehaviour, IValues<ushort>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort Value2 { get; set; }
	}

	public class UshortProperties2 : MonoBehaviour, IValues<ushort>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort Value2 { get; set; }
	}

	public class UshortArrayField1 : MonoBehaviour, IValue<ushort[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort[] Value { get { return value; } set { this.value = value; } }
	}

	public class UshortArrayField2 : MonoBehaviour, IValue<ushort[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort[] Value { get { return value; } set { this.value = value; } }
	}

	public class UshortArrayFields1 : MonoBehaviour, IValues<ushort[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ushort[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ushort[] Value1 { get { return value1; } set { value1 = value; } }
		public ushort[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortArrayFields2 : MonoBehaviour, IValues<ushort[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ushort[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ushort[] Value1 { get { return value1; } set { value1 = value; } }
		public ushort[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortArrayProperty1 : MonoBehaviour, IValue<ushort[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort[] Value { get; set; }
	}

	public class UshortArrayProperty2 : MonoBehaviour, IValue<ushort[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort[] Value { get; set; }
	}

	public class UshortArrayProperties1 : MonoBehaviour, IValues<ushort[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort[] Value2 { get; set; }
	}

	public class UshortArrayProperties2 : MonoBehaviour, IValues<ushort[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort[] Value2 { get; set; }
	}

	public class UshortListField1 : MonoBehaviour, IValue<List<ushort>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ushort> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ushort> Value { get { return value; } set { this.value = value; } }
	}

	public class UshortListField2 : MonoBehaviour, IValue<List<ushort>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ushort> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ushort> Value { get { return value; } set { this.value = value; } }
	}

	public class UshortListFields1 : MonoBehaviour, IValues<List<ushort>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ushort> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<ushort> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<ushort> Value1 { get { return value1; } set { value1 = value; } }
		public List<ushort> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortListFields2 : MonoBehaviour, IValues<List<ushort>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<ushort> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ushort> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<ushort> Value1 { get { return value1; } set { value1 = value; } }
		public List<ushort> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortListProperty1 : MonoBehaviour, IValue<List<ushort>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort> Value { get; set; }
	}

	public class UshortListProperty2 : MonoBehaviour, IValue<List<ushort>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort> Value { get; set; }
	}

	public class UshortListProperties1 : MonoBehaviour, IValues<List<ushort>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ushort> Value2 { get; set; }
	}

	public class UshortListProperties2 : MonoBehaviour, IValues<List<ushort>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ushort> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort> Value2 { get; set; }
	}

	public class UshortNullableField1 : MonoBehaviour, IValue<ushort?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort? Value { get { return value; } set { this.value = value; } }
	}

	public class UshortNullableField2 : MonoBehaviour, IValue<ushort?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort? Value { get { return value; } set { this.value = value; } }
	}

	public class UshortNullableFields1 : MonoBehaviour, IValues<ushort?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ushort? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ushort? Value1 { get { return value1; } set { value1 = value; } }
		public ushort? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortNullableFields2 : MonoBehaviour, IValues<ushort?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ushort? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ushort? Value1 { get { return value1; } set { value1 = value; } }
		public ushort? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortNullableProperty1 : MonoBehaviour, IValue<ushort?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort? Value { get; set; }
	}

	public class UshortNullableProperty2 : MonoBehaviour, IValue<ushort?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort? Value { get; set; }
	}

	public class UshortNullableProperties1 : MonoBehaviour, IValues<ushort?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort? Value2 { get; set; }
	}

	public class UshortNullableProperties2 : MonoBehaviour, IValues<ushort?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort? Value2 { get; set; }
	}

	public class UshortArrayNullableField1 : MonoBehaviour, IValue<ushort?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UshortArrayNullableField2 : MonoBehaviour, IValue<ushort?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UshortArrayNullableFields1 : MonoBehaviour, IValues<ushort?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private ushort?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public ushort?[] Value1 { get { return value1; } set { value1 = value; } }
		public ushort?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortArrayNullableFields2 : MonoBehaviour, IValues<ushort?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private ushort?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public ushort?[] Value1 { get { return value1; } set { value1 = value; } }
		public ushort?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortArrayNullableProperty1 : MonoBehaviour, IValue<ushort?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort?[] Value { get; set; }
	}

	public class UshortArrayNullableProperty2 : MonoBehaviour, IValue<ushort?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort?[] Value { get; set; }
	}

	public class UshortArrayNullableProperties1 : MonoBehaviour, IValues<ushort?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort?[] Value2 { get; set; }
	}

	public class UshortArrayNullableProperties2 : MonoBehaviour, IValues<ushort?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort?[] Value2 { get; set; }
	}

	public class UshortListNullableField1 : MonoBehaviour, IValue<List<ushort?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ushort?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ushort?> Value { get { return value; } set { this.value = value; } }
	}

	public class UshortListNullableField2 : MonoBehaviour, IValue<List<ushort?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ushort?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ushort?> Value { get { return value; } set { this.value = value; } }
	}

	public class UshortListNullableFields1 : MonoBehaviour, IValues<List<ushort?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ushort?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<ushort?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<ushort?> Value1 { get { return value1; } set { value1 = value; } }
		public List<ushort?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortListNullableFields2 : MonoBehaviour, IValues<List<ushort?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<ushort?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ushort?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<ushort?> Value1 { get { return value1; } set { value1 = value; } }
		public List<ushort?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class UshortListNullableProperty1 : MonoBehaviour, IValue<List<ushort?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort?> Value { get; set; }
	}

	public class UshortListNullableProperty2 : MonoBehaviour, IValue<List<ushort?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort?> Value { get; set; }
	}

	public class UshortListNullableProperties1 : MonoBehaviour, IValues<List<ushort?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ushort?> Value2 { get; set; }
	}

	public class UshortListNullableProperties2 : MonoBehaviour, IValues<List<ushort?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ushort?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618