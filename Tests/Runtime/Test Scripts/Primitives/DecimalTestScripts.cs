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
	public class DecimalField1 : MonoBehaviour, IValue<decimal>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal value;

		public int ValueID { get { return VALUE_0_ID; } }
		public decimal Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalField2 : MonoBehaviour, IValue<decimal>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal value;

		public int ValueID { get { return VALUE_100_ID; } }
		public decimal Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalFields1 : MonoBehaviour, IValues<decimal>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private decimal value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public decimal Value1 { get { return value1; } set { value1 = value; } }
		public decimal Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalFields2 : MonoBehaviour, IValues<decimal>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private decimal value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public decimal Value1 { get { return value1; } set { value1 = value; } }
		public decimal Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalProperty1 : MonoBehaviour, IValue<decimal>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal Value { get; set; }
	}

	public class DecimalProperty2 : MonoBehaviour, IValue<decimal>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal Value { get; set; }
	}

	public class DecimalProperties1 : MonoBehaviour, IValues<decimal>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public decimal Value2 { get; set; }
	}

	public class DecimalProperties2 : MonoBehaviour, IValues<decimal>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public decimal Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal Value2 { get; set; }
	}

	public class DecimalArrayField1 : MonoBehaviour, IValue<decimal[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public decimal[] Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalArrayField2 : MonoBehaviour, IValue<decimal[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public decimal[] Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalArrayFields1 : MonoBehaviour, IValues<decimal[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private decimal[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public decimal[] Value1 { get { return value1; } set { value1 = value; } }
		public decimal[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalArrayFields2 : MonoBehaviour, IValues<decimal[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private decimal[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public decimal[] Value1 { get { return value1; } set { value1 = value; } }
		public decimal[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalArrayProperty1 : MonoBehaviour, IValue<decimal[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal[] Value { get; set; }
	}

	public class DecimalArrayProperty2 : MonoBehaviour, IValue<decimal[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal[] Value { get; set; }
	}

	public class DecimalArrayProperties1 : MonoBehaviour, IValues<decimal[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public decimal[] Value2 { get; set; }
	}

	public class DecimalArrayProperties2 : MonoBehaviour, IValues<decimal[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public decimal[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal[] Value2 { get; set; }
	}

	public class DecimalListField1 : MonoBehaviour, IValue<List<decimal>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<decimal> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<decimal> Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalListField2 : MonoBehaviour, IValue<List<decimal>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<decimal> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<decimal> Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalListFields1 : MonoBehaviour, IValues<List<decimal>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<decimal> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<decimal> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<decimal> Value1 { get { return value1; } set { value1 = value; } }
		public List<decimal> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalListFields2 : MonoBehaviour, IValues<List<decimal>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<decimal> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<decimal> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<decimal> Value1 { get { return value1; } set { value1 = value; } }
		public List<decimal> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalListProperty1 : MonoBehaviour, IValue<List<decimal>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<decimal> Value { get; set; }
	}

	public class DecimalListProperty2 : MonoBehaviour, IValue<List<decimal>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<decimal> Value { get; set; }
	}

	public class DecimalListProperties1 : MonoBehaviour, IValues<List<decimal>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<decimal> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<decimal> Value2 { get; set; }
	}

	public class DecimalListProperties2 : MonoBehaviour, IValues<List<decimal>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<decimal> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<decimal> Value2 { get; set; }
	}

	public class DecimalNullableField1 : MonoBehaviour, IValue<decimal?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public decimal? Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalNullableField2 : MonoBehaviour, IValue<decimal?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public decimal? Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalNullableFields1 : MonoBehaviour, IValues<decimal?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private decimal? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public decimal? Value1 { get { return value1; } set { value1 = value; } }
		public decimal? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalNullableFields2 : MonoBehaviour, IValues<decimal?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private decimal? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public decimal? Value1 { get { return value1; } set { value1 = value; } }
		public decimal? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalNullableProperty1 : MonoBehaviour, IValue<decimal?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal? Value { get; set; }
	}

	public class DecimalNullableProperty2 : MonoBehaviour, IValue<decimal?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal? Value { get; set; }
	}

	public class DecimalNullableProperties1 : MonoBehaviour, IValues<decimal?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public decimal? Value2 { get; set; }
	}

	public class DecimalNullableProperties2 : MonoBehaviour, IValues<decimal?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public decimal? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal? Value2 { get; set; }
	}

	public class DecimalArrayNullableField1 : MonoBehaviour, IValue<decimal?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public decimal?[] Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalArrayNullableField2 : MonoBehaviour, IValue<decimal?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public decimal?[] Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalArrayNullableFields1 : MonoBehaviour, IValues<decimal?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private decimal?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private decimal?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public decimal?[] Value1 { get { return value1; } set { value1 = value; } }
		public decimal?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalArrayNullableFields2 : MonoBehaviour, IValues<decimal?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private decimal?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private decimal?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public decimal?[] Value1 { get { return value1; } set { value1 = value; } }
		public decimal?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalArrayNullableProperty1 : MonoBehaviour, IValue<decimal?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal?[] Value { get; set; }
	}

	public class DecimalArrayNullableProperty2 : MonoBehaviour, IValue<decimal?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal?[] Value { get; set; }
	}

	public class DecimalArrayNullableProperties1 : MonoBehaviour, IValues<decimal?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public decimal?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public decimal?[] Value2 { get; set; }
	}

	public class DecimalArrayNullableProperties2 : MonoBehaviour, IValues<decimal?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public decimal?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public decimal?[] Value2 { get; set; }
	}

	public class DecimalListNullableField1 : MonoBehaviour, IValue<List<decimal?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<decimal?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<decimal?> Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalListNullableField2 : MonoBehaviour, IValue<List<decimal?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<decimal?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<decimal?> Value { get { return value; } set { this.value = value; } }
	}

	public class DecimalListNullableFields1 : MonoBehaviour, IValues<List<decimal?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<decimal?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<decimal?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<decimal?> Value1 { get { return value1; } set { value1 = value; } }
		public List<decimal?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalListNullableFields2 : MonoBehaviour, IValues<List<decimal?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<decimal?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<decimal?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<decimal?> Value1 { get { return value1; } set { value1 = value; } }
		public List<decimal?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class DecimalListNullableProperty1 : MonoBehaviour, IValue<List<decimal?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<decimal?> Value { get; set; }
	}

	public class DecimalListNullableProperty2 : MonoBehaviour, IValue<List<decimal?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<decimal?> Value { get; set; }
	}

	public class DecimalListNullableProperties1 : MonoBehaviour, IValues<List<decimal?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<decimal?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<decimal?> Value2 { get; set; }
	}

	public class DecimalListNullableProperties2 : MonoBehaviour, IValues<List<decimal?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<decimal?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<decimal?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618