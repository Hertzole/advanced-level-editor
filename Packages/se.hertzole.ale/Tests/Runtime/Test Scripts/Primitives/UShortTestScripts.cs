// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

namespace Hertzole.ALE.Tests.TestScripts
{
	public class UShortField1 : MonoBehaviour, IValue<ushort>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort Value { get { return value; } set { this.value = value; } }
	}

	public class UShortField2 : MonoBehaviour, IValue<ushort>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort Value { get { return value; } set { this.value = value; } }
	}

	public class UShortFields1 : MonoBehaviour, IValues<ushort>
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

	public class UShortFields2 : MonoBehaviour, IValues<ushort>
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

	public class UShortProperty1 : MonoBehaviour, IValue<ushort>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort Value { get; set; }
	}

	public class UShortProperty2 : MonoBehaviour, IValue<ushort>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort Value { get; set; }
	}

	public class UShortProperties1 : MonoBehaviour, IValues<ushort>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort Value2 { get; set; }
	}

	public class UShortProperties2 : MonoBehaviour, IValues<ushort>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort Value2 { get; set; }
	}

	public class UShortArrayField1 : MonoBehaviour, IValue<ushort[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort[] Value { get { return value; } set { this.value = value; } }
	}

	public class UShortArrayField2 : MonoBehaviour, IValue<ushort[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort[] Value { get { return value; } set { this.value = value; } }
	}

	public class UShortArrayFields1 : MonoBehaviour, IValues<ushort[]>
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

	public class UShortArrayFields2 : MonoBehaviour, IValues<ushort[]>
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

	public class UShortArrayProperty1 : MonoBehaviour, IValue<ushort[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort[] Value { get; set; }
	}

	public class UShortArrayProperty2 : MonoBehaviour, IValue<ushort[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort[] Value { get; set; }
	}

	public class UShortArrayProperties1 : MonoBehaviour, IValues<ushort[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort[] Value2 { get; set; }
	}

	public class UShortArrayProperties2 : MonoBehaviour, IValues<ushort[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort[] Value2 { get; set; }
	}

	public class UShortListField1 : MonoBehaviour, IValue<List<ushort>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ushort> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ushort> Value { get { return value; } set { this.value = value; } }
	}

	public class UShortListField2 : MonoBehaviour, IValue<List<ushort>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ushort> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ushort> Value { get { return value; } set { this.value = value; } }
	}

	public class UShortListFields1 : MonoBehaviour, IValues<List<ushort>>
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

	public class UShortListFields2 : MonoBehaviour, IValues<List<ushort>>
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

	public class UShortListProperty1 : MonoBehaviour, IValue<List<ushort>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort> Value { get; set; }
	}

	public class UShortListProperty2 : MonoBehaviour, IValue<List<ushort>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort> Value { get; set; }
	}

	public class UShortListProperties1 : MonoBehaviour, IValues<List<ushort>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ushort> Value2 { get; set; }
	}

	public class UShortListProperties2 : MonoBehaviour, IValues<List<ushort>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ushort> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort> Value2 { get; set; }
	}

	public class UShortNullableField1 : MonoBehaviour, IValue<ushort?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort? Value { get { return value; } set { this.value = value; } }
	}

	public class UShortNullableField2 : MonoBehaviour, IValue<ushort?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort? Value { get { return value; } set { this.value = value; } }
	}

	public class UShortNullableFields1 : MonoBehaviour, IValues<ushort?>
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

	public class UShortNullableFields2 : MonoBehaviour, IValues<ushort?>
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

	public class UShortNullableProperty1 : MonoBehaviour, IValue<ushort?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort? Value { get; set; }
	}

	public class UShortNullableProperty2 : MonoBehaviour, IValue<ushort?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort? Value { get; set; }
	}

	public class UShortNullableProperties1 : MonoBehaviour, IValues<ushort?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort? Value2 { get; set; }
	}

	public class UShortNullableProperties2 : MonoBehaviour, IValues<ushort?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort? Value2 { get; set; }
	}

	public class UShortArrayNullableField1 : MonoBehaviour, IValue<ushort?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private ushort?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public ushort?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UShortArrayNullableField2 : MonoBehaviour, IValue<ushort?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private ushort?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public ushort?[] Value { get { return value; } set { this.value = value; } }
	}

	public class UShortArrayNullableFields1 : MonoBehaviour, IValues<ushort?[]>
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

	public class UShortArrayNullableFields2 : MonoBehaviour, IValues<ushort?[]>
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

	public class UShortArrayNullableProperty1 : MonoBehaviour, IValue<ushort?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort?[] Value { get; set; }
	}

	public class UShortArrayNullableProperty2 : MonoBehaviour, IValue<ushort?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort?[] Value { get; set; }
	}

	public class UShortArrayNullableProperties1 : MonoBehaviour, IValues<ushort?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public ushort?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public ushort?[] Value2 { get; set; }
	}

	public class UShortArrayNullableProperties2 : MonoBehaviour, IValues<ushort?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public ushort?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public ushort?[] Value2 { get; set; }
	}

	public class UShortListNullableField1 : MonoBehaviour, IValue<List<ushort?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<ushort?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<ushort?> Value { get { return value; } set { this.value = value; } }
	}

	public class UShortListNullableField2 : MonoBehaviour, IValue<List<ushort?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<ushort?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<ushort?> Value { get { return value; } set { this.value = value; } }
	}

	public class UShortListNullableFields1 : MonoBehaviour, IValues<List<ushort?>>
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

	public class UShortListNullableFields2 : MonoBehaviour, IValues<List<ushort?>>
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

	public class UShortListNullableProperty1 : MonoBehaviour, IValue<List<ushort?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort?> Value { get; set; }
	}

	public class UShortListNullableProperty2 : MonoBehaviour, IValue<List<ushort?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort?> Value { get; set; }
	}

	public class UShortListNullableProperties1 : MonoBehaviour, IValues<List<ushort?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<ushort?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<ushort?> Value2 { get; set; }
	}

	public class UShortListNullableProperties2 : MonoBehaviour, IValues<List<ushort?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<ushort?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<ushort?> Value2 { get; set; }
	}
}