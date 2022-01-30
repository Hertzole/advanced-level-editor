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
	public class GameObjectField1 : MonoBehaviour, IValue<GameObject>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GameObject Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectField2 : MonoBehaviour, IValue<GameObject>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GameObject Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectFields1 : MonoBehaviour, IValues<GameObject>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GameObject value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GameObject Value1 { get { return value1; } set { value1 = value; } }
		public GameObject Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectFields2 : MonoBehaviour, IValues<GameObject>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GameObject value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GameObject Value1 { get { return value1; } set { value1 = value; } }
		public GameObject Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectProperty1 : MonoBehaviour, IValue<GameObject>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject Value { get; set; }
	}

	public class GameObjectProperty2 : MonoBehaviour, IValue<GameObject>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject Value { get; set; }
	}

	public class GameObjectProperties1 : MonoBehaviour, IValues<GameObject>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GameObject Value2 { get; set; }
	}

	public class GameObjectProperties2 : MonoBehaviour, IValues<GameObject>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GameObject Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject Value2 { get; set; }
	}

	public class GameObjectArrayField1 : MonoBehaviour, IValue<GameObject[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GameObject[] Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectArrayField2 : MonoBehaviour, IValue<GameObject[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GameObject[] Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectArrayFields1 : MonoBehaviour, IValues<GameObject[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GameObject[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GameObject[] Value1 { get { return value1; } set { value1 = value; } }
		public GameObject[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectArrayFields2 : MonoBehaviour, IValues<GameObject[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GameObject[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GameObject[] Value1 { get { return value1; } set { value1 = value; } }
		public GameObject[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectArrayProperty1 : MonoBehaviour, IValue<GameObject[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject[] Value { get; set; }
	}

	public class GameObjectArrayProperty2 : MonoBehaviour, IValue<GameObject[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject[] Value { get; set; }
	}

	public class GameObjectArrayProperties1 : MonoBehaviour, IValues<GameObject[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GameObject[] Value2 { get; set; }
	}

	public class GameObjectArrayProperties2 : MonoBehaviour, IValues<GameObject[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GameObject[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject[] Value2 { get; set; }
	}

	public class GameObjectListField1 : MonoBehaviour, IValue<List<GameObject>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GameObject> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<GameObject> Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectListField2 : MonoBehaviour, IValue<List<GameObject>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GameObject> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<GameObject> Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectListFields1 : MonoBehaviour, IValues<List<GameObject>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GameObject> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<GameObject> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<GameObject> Value1 { get { return value1; } set { value1 = value; } }
		public List<GameObject> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectListFields2 : MonoBehaviour, IValues<List<GameObject>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<GameObject> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GameObject> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<GameObject> Value1 { get { return value1; } set { value1 = value; } }
		public List<GameObject> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectListProperty1 : MonoBehaviour, IValue<List<GameObject>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GameObject> Value { get; set; }
	}

	public class GameObjectListProperty2 : MonoBehaviour, IValue<List<GameObject>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GameObject> Value { get; set; }
	}

	public class GameObjectListProperties1 : MonoBehaviour, IValues<List<GameObject>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GameObject> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<GameObject> Value2 { get; set; }
	}

	public class GameObjectListProperties2 : MonoBehaviour, IValues<List<GameObject>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<GameObject> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GameObject> Value2 { get; set; }
	}

	public class GameObjectNullableField1 : MonoBehaviour, IValue<GameObject?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GameObject? Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectNullableField2 : MonoBehaviour, IValue<GameObject?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GameObject? Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectNullableFields1 : MonoBehaviour, IValues<GameObject?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GameObject? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GameObject? Value1 { get { return value1; } set { value1 = value; } }
		public GameObject? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectNullableFields2 : MonoBehaviour, IValues<GameObject?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GameObject? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GameObject? Value1 { get { return value1; } set { value1 = value; } }
		public GameObject? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectNullableProperty1 : MonoBehaviour, IValue<GameObject?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject? Value { get; set; }
	}

	public class GameObjectNullableProperty2 : MonoBehaviour, IValue<GameObject?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject? Value { get; set; }
	}

	public class GameObjectNullableProperties1 : MonoBehaviour, IValues<GameObject?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GameObject? Value2 { get; set; }
	}

	public class GameObjectNullableProperties2 : MonoBehaviour, IValues<GameObject?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GameObject? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject? Value2 { get; set; }
	}

	public class GameObjectArrayNullableField1 : MonoBehaviour, IValue<GameObject?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public GameObject?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectArrayNullableField2 : MonoBehaviour, IValue<GameObject?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public GameObject?[] Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectArrayNullableFields1 : MonoBehaviour, IValues<GameObject?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private GameObject?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private GameObject?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public GameObject?[] Value1 { get { return value1; } set { value1 = value; } }
		public GameObject?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectArrayNullableFields2 : MonoBehaviour, IValues<GameObject?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private GameObject?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private GameObject?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public GameObject?[] Value1 { get { return value1; } set { value1 = value; } }
		public GameObject?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectArrayNullableProperty1 : MonoBehaviour, IValue<GameObject?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject?[] Value { get; set; }
	}

	public class GameObjectArrayNullableProperty2 : MonoBehaviour, IValue<GameObject?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject?[] Value { get; set; }
	}

	public class GameObjectArrayNullableProperties1 : MonoBehaviour, IValues<GameObject?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public GameObject?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public GameObject?[] Value2 { get; set; }
	}

	public class GameObjectArrayNullableProperties2 : MonoBehaviour, IValues<GameObject?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public GameObject?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public GameObject?[] Value2 { get; set; }
	}

	public class GameObjectListNullableField1 : MonoBehaviour, IValue<List<GameObject?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GameObject?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<GameObject?> Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectListNullableField2 : MonoBehaviour, IValue<List<GameObject?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GameObject?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<GameObject?> Value { get { return value; } set { this.value = value; } }
	}

	public class GameObjectListNullableFields1 : MonoBehaviour, IValues<List<GameObject?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<GameObject?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<GameObject?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<GameObject?> Value1 { get { return value1; } set { value1 = value; } }
		public List<GameObject?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectListNullableFields2 : MonoBehaviour, IValues<List<GameObject?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<GameObject?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<GameObject?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<GameObject?> Value1 { get { return value1; } set { value1 = value; } }
		public List<GameObject?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class GameObjectListNullableProperty1 : MonoBehaviour, IValue<List<GameObject?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GameObject?> Value { get; set; }
	}

	public class GameObjectListNullableProperty2 : MonoBehaviour, IValue<List<GameObject?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GameObject?> Value { get; set; }
	}

	public class GameObjectListNullableProperties1 : MonoBehaviour, IValues<List<GameObject?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<GameObject?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<GameObject?> Value2 { get; set; }
	}

	public class GameObjectListNullableProperties2 : MonoBehaviour, IValues<List<GameObject?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<GameObject?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<GameObject?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618