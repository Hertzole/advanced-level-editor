using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace Hertzole.ALE.Editor
{
	internal class TestScriptGenerator : EditorWindow
	{
		private static readonly GUIContent typeNameContent = new GUIContent("Type Name", "Fancy name");

		private static readonly Random random = new Random();
		private string testLocation;
		private string testName;
		private string testScriptLocation;
		private string type;
		private string typeName;

		private static readonly StringBuilder sb = new StringBuilder();

		private const string TEST_TEMPLATE = @"// DO NOT MODIFY! THIS IS A GENERATED FILE!

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
	public abstract partial class REPLACE_TESTNAME : SerializationTest
	{
		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEField()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMEField1, REPLACE_TYPE>(VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMEField2, REPLACE_TYPE>(VALUE_2);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEFields()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMEFields1, REPLACE_TYPE>(VALUE_2, VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMEFields2, REPLACE_TYPE>(VALUE_1, VALUE_2);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEProperty()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMEProperty1, REPLACE_TYPE>(VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMEProperty2, REPLACE_TYPE>(VALUE_2);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEProperties()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMEProperties1, REPLACE_TYPE>(VALUE_2, VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMEProperties2, REPLACE_TYPE>(VALUE_1, VALUE_2);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMENullableField()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableField1, REPLACE_TYPE?>(VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableField2, REPLACE_TYPE?>(VALUE_2);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableField1, REPLACE_TYPE?>(null);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableField2, REPLACE_TYPE?>(null);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMENullableFields()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableFields1, REPLACE_TYPE?>(VALUE_2, VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableFields2, REPLACE_TYPE?>(VALUE_1, VALUE_2);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableFields1, REPLACE_TYPE?>(null, VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableFields2, REPLACE_TYPE?>(VALUE_1, null);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMENullableProperty()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperty1, REPLACE_TYPE?>(VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperty2, REPLACE_TYPE?>(VALUE_2);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperty1, REPLACE_TYPE?>(null);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperty2, REPLACE_TYPE?>(null);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMENullableProperties()
		{
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperties1, REPLACE_TYPE?>(VALUE_2, VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperties2, REPLACE_TYPE?>(VALUE_1, VALUE_2);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperties1, REPLACE_TYPE?>(null, VALUE_1);
			yield return REPLACE_TEST_RUN<REPLACE_NAMENullableProperties2, REPLACE_TYPE?>(VALUE_1, null);
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayField()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayField1, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_1, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayField2, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_2, VALUE_1 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayFields()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayFields1, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_1, VALUE_2 }, new REPLACE_TYPE[] { VALUE_3, VALUE_4 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayFields2, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_2, VALUE_1 }, new REPLACE_TYPE[] { VALUE_4, VALUE_3 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayProperty()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayProperty1, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_1, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayProperty2, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_2, VALUE_1 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayProperties()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayProperties1, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_1, VALUE_2 }, new REPLACE_TYPE[] { VALUE_3, VALUE_4 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayProperties2, REPLACE_TYPE[]>(new REPLACE_TYPE[] { VALUE_2, VALUE_1 }, new REPLACE_TYPE[] { VALUE_4, VALUE_3 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayNullableField()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableField1, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { null, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableField2, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { VALUE_2, null });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayNullableFields()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableFields1, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { null, VALUE_2 }, new REPLACE_TYPE?[] { VALUE_3, null });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableFields2, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { VALUE_2, null }, new REPLACE_TYPE?[] { null, VALUE_3 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayNullableProperty()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableProperty1, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { null, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableProperty2, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { VALUE_2, null });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEArrayNullableProperties()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableProperties1, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { VALUE_1, null }, new REPLACE_TYPE?[] { null, VALUE_4 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEArrayNullableProperties2, REPLACE_TYPE?[]>(new REPLACE_TYPE?[] { null, VALUE_1 }, new REPLACE_TYPE?[] { VALUE_4, null });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListField()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListField1, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_1, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListField2, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_2, VALUE_1 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListFields()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListFields1, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_1, VALUE_2 }, new List<REPLACE_TYPE> { VALUE_3, VALUE_4 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListFields2, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_2, VALUE_1 }, new List<REPLACE_TYPE> { VALUE_4, VALUE_3 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListProperty()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListProperty1, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_1, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListProperty2, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_2, VALUE_1 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListProperties()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListProperties1, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_1, VALUE_2 }, new List<REPLACE_TYPE> { VALUE_3, VALUE_4 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListProperties2, List<REPLACE_TYPE>>(new List<REPLACE_TYPE> { VALUE_2, VALUE_1 }, new List<REPLACE_TYPE> { VALUE_4, VALUE_3 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListNullableField()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableField1, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { null, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableField2, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { VALUE_2, null });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListNullableFields()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableFields1, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { null, VALUE_2 }, new List<REPLACE_TYPE?> { VALUE_3, null });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableFields2, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { VALUE_2, null }, new List<REPLACE_TYPE?> { null, VALUE_3 });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListNullableProperty()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableProperty1, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { null, VALUE_2 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableProperty2, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { VALUE_2, null });
		}

		[UnityTest]
		public IEnumerator SaveREPLACE_NAMEListNullableProperties()
		{
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableProperties1, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { VALUE_1, null }, new List<REPLACE_TYPE?> { null, VALUE_4 });
			yield return REPLACE_TEST_COLLECTION_RUN<REPLACE_NAMEListNullableProperties2, List<REPLACE_TYPE?>>(new List<REPLACE_TYPE?> { null, VALUE_1 }, new List<REPLACE_TYPE?> { VALUE_4, null });
		}
	}
}";

		private const string TEST_SCRIPT_TEMPLATE = @"// DO NOT MODIFY! THIS IS A GENERATED FILE!

#nullable enable

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

#pragma warning disable CS8618

namespace Hertzole.ALE.Tests.TestScripts
{
	public class REPLACE_NAMEField1 : MonoBehaviour, IValue<REPLACE_TYPE>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE value;

		public int ValueID { get { return VALUE_0_ID; } }
		public REPLACE_TYPE Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEField2 : MonoBehaviour, IValue<REPLACE_TYPE>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE value;

		public int ValueID { get { return VALUE_100_ID; } }
		public REPLACE_TYPE Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEFields1 : MonoBehaviour, IValues<REPLACE_TYPE>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private REPLACE_TYPE value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public REPLACE_TYPE Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEFields2 : MonoBehaviour, IValues<REPLACE_TYPE>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private REPLACE_TYPE value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public REPLACE_TYPE Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEProperty1 : MonoBehaviour, IValue<REPLACE_TYPE>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE Value { get; set; }
	}

	public class REPLACE_NAMEProperty2 : MonoBehaviour, IValue<REPLACE_TYPE>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE Value { get; set; }
	}

	public class REPLACE_NAMEProperties1 : MonoBehaviour, IValues<REPLACE_TYPE>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public REPLACE_TYPE Value2 { get; set; }
	}

	public class REPLACE_NAMEProperties2 : MonoBehaviour, IValues<REPLACE_TYPE>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public REPLACE_TYPE Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE Value2 { get; set; }
	}

	public class REPLACE_NAMEArrayField1 : MonoBehaviour, IValue<REPLACE_TYPE[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public REPLACE_TYPE[] Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEArrayField2 : MonoBehaviour, IValue<REPLACE_TYPE[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public REPLACE_TYPE[] Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEArrayFields1 : MonoBehaviour, IValues<REPLACE_TYPE[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private REPLACE_TYPE[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public REPLACE_TYPE[] Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEArrayFields2 : MonoBehaviour, IValues<REPLACE_TYPE[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private REPLACE_TYPE[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public REPLACE_TYPE[] Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEArrayProperty1 : MonoBehaviour, IValue<REPLACE_TYPE[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE[] Value { get; set; }
	}

	public class REPLACE_NAMEArrayProperty2 : MonoBehaviour, IValue<REPLACE_TYPE[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE[] Value { get; set; }
	}

	public class REPLACE_NAMEArrayProperties1 : MonoBehaviour, IValues<REPLACE_TYPE[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public REPLACE_TYPE[] Value2 { get; set; }
	}

	public class REPLACE_NAMEArrayProperties2 : MonoBehaviour, IValues<REPLACE_TYPE[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public REPLACE_TYPE[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE[] Value2 { get; set; }
	}

	public class REPLACE_NAMEListField1 : MonoBehaviour, IValue<List<REPLACE_TYPE>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<REPLACE_TYPE> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<REPLACE_TYPE> Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEListField2 : MonoBehaviour, IValue<List<REPLACE_TYPE>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<REPLACE_TYPE> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<REPLACE_TYPE> Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEListFields1 : MonoBehaviour, IValues<List<REPLACE_TYPE>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<REPLACE_TYPE> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<REPLACE_TYPE> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<REPLACE_TYPE> Value1 { get { return value1; } set { value1 = value; } }
		public List<REPLACE_TYPE> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEListFields2 : MonoBehaviour, IValues<List<REPLACE_TYPE>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<REPLACE_TYPE> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<REPLACE_TYPE> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<REPLACE_TYPE> Value1 { get { return value1; } set { value1 = value; } }
		public List<REPLACE_TYPE> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEListProperty1 : MonoBehaviour, IValue<List<REPLACE_TYPE>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<REPLACE_TYPE> Value { get; set; }
	}

	public class REPLACE_NAMEListProperty2 : MonoBehaviour, IValue<List<REPLACE_TYPE>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<REPLACE_TYPE> Value { get; set; }
	}

	public class REPLACE_NAMEListProperties1 : MonoBehaviour, IValues<List<REPLACE_TYPE>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<REPLACE_TYPE> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<REPLACE_TYPE> Value2 { get; set; }
	}

	public class REPLACE_NAMEListProperties2 : MonoBehaviour, IValues<List<REPLACE_TYPE>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<REPLACE_TYPE> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<REPLACE_TYPE> Value2 { get; set; }
	}

	public class REPLACE_NAMENullableField1 : MonoBehaviour, IValue<REPLACE_TYPE?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE? value;

		public int ValueID { get { return VALUE_0_ID; } }
		public REPLACE_TYPE? Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMENullableField2 : MonoBehaviour, IValue<REPLACE_TYPE?>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE? value;

		public int ValueID { get { return VALUE_100_ID; } }
		public REPLACE_TYPE? Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMENullableFields1 : MonoBehaviour, IValues<REPLACE_TYPE?>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE? value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private REPLACE_TYPE? value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public REPLACE_TYPE? Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMENullableFields2 : MonoBehaviour, IValues<REPLACE_TYPE?>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private REPLACE_TYPE? value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE? value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public REPLACE_TYPE? Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE? Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMENullableProperty1 : MonoBehaviour, IValue<REPLACE_TYPE?>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE? Value { get; set; }
	}

	public class REPLACE_NAMENullableProperty2 : MonoBehaviour, IValue<REPLACE_TYPE?>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE? Value { get; set; }
	}

	public class REPLACE_NAMENullableProperties1 : MonoBehaviour, IValues<REPLACE_TYPE?>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public REPLACE_TYPE? Value2 { get; set; }
	}

	public class REPLACE_NAMENullableProperties2 : MonoBehaviour, IValues<REPLACE_TYPE?>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public REPLACE_TYPE? Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE? Value2 { get; set; }
	}

	public class REPLACE_NAMEArrayNullableField1 : MonoBehaviour, IValue<REPLACE_TYPE?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE?[] value;

		public int ValueID { get { return VALUE_0_ID; } }
		public REPLACE_TYPE?[] Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEArrayNullableField2 : MonoBehaviour, IValue<REPLACE_TYPE?[]>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE?[] value;

		public int ValueID { get { return VALUE_100_ID; } }
		public REPLACE_TYPE?[] Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEArrayNullableFields1 : MonoBehaviour, IValues<REPLACE_TYPE?[]>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private REPLACE_TYPE?[] value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private REPLACE_TYPE?[] value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public REPLACE_TYPE?[] Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEArrayNullableFields2 : MonoBehaviour, IValues<REPLACE_TYPE?[]>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private REPLACE_TYPE?[] value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private REPLACE_TYPE?[] value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public REPLACE_TYPE?[] Value1 { get { return value1; } set { value1 = value; } }
		public REPLACE_TYPE?[] Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEArrayNullableProperty1 : MonoBehaviour, IValue<REPLACE_TYPE?[]>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE?[] Value { get; set; }
	}

	public class REPLACE_NAMEArrayNullableProperty2 : MonoBehaviour, IValue<REPLACE_TYPE?[]>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE?[] Value { get; set; }
	}

	public class REPLACE_NAMEArrayNullableProperties1 : MonoBehaviour, IValues<REPLACE_TYPE?[]>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public REPLACE_TYPE?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public REPLACE_TYPE?[] Value2 { get; set; }
	}

	public class REPLACE_NAMEArrayNullableProperties2 : MonoBehaviour, IValues<REPLACE_TYPE?[]>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public REPLACE_TYPE?[] Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public REPLACE_TYPE?[] Value2 { get; set; }
	}

	public class REPLACE_NAMEListNullableField1 : MonoBehaviour, IValue<List<REPLACE_TYPE?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<REPLACE_TYPE?> value;

		public int ValueID { get { return VALUE_0_ID; } }
		public List<REPLACE_TYPE?> Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEListNullableField2 : MonoBehaviour, IValue<List<REPLACE_TYPE?>>
	{
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<REPLACE_TYPE?> value;

		public int ValueID { get { return VALUE_100_ID; } }
		public List<REPLACE_TYPE?> Value { get { return value; } set { this.value = value; } }
	}

	public class REPLACE_NAMEListNullableFields1 : MonoBehaviour, IValues<List<REPLACE_TYPE?>>
	{
		[ExposeToLevelEditor(VALUE_0_ID)]
		private List<REPLACE_TYPE?> value1;
		[ExposeToLevelEditor(VALUE_5_ID)]
		private List<REPLACE_TYPE?> value2;

		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		public List<REPLACE_TYPE?> Value1 { get { return value1; } set { value1 = value; } }
		public List<REPLACE_TYPE?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEListNullableFields2 : MonoBehaviour, IValues<List<REPLACE_TYPE?>>
	{
		[ExposeToLevelEditor(VALUE_10_ID)]
		private List<REPLACE_TYPE?> value1;
		[ExposeToLevelEditor(VALUE_100_ID)]
		private List<REPLACE_TYPE?> value2;

		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		public List<REPLACE_TYPE?> Value1 { get { return value1; } set { value1 = value; } }
		public List<REPLACE_TYPE?> Value2 { get { return value2; } set { value2 = value; } }
	}

	public class REPLACE_NAMEListNullableProperty1 : MonoBehaviour, IValue<List<REPLACE_TYPE?>>
	{
		public int ValueID { get { return VALUE_0_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<REPLACE_TYPE?> Value { get; set; }
	}

	public class REPLACE_NAMEListNullableProperty2 : MonoBehaviour, IValue<List<REPLACE_TYPE?>>
	{
		public int ValueID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<REPLACE_TYPE?> Value { get; set; }
	}

	public class REPLACE_NAMEListNullableProperties1 : MonoBehaviour, IValues<List<REPLACE_TYPE?>>
	{
		public int Value1ID { get { return VALUE_0_ID; } }
		public int Value2ID { get { return VALUE_5_ID; } }

		[ExposeToLevelEditor(VALUE_0_ID)]
		public List<REPLACE_TYPE?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_5_ID)]
		public List<REPLACE_TYPE?> Value2 { get; set; }
	}

	public class REPLACE_NAMEListNullableProperties2 : MonoBehaviour, IValues<List<REPLACE_TYPE?>>
	{
		public int Value1ID { get { return VALUE_10_ID; } }
		public int Value2ID { get { return VALUE_100_ID; } }

		[ExposeToLevelEditor(VALUE_10_ID)]
		public List<REPLACE_TYPE?> Value1 { get; set; }
		[ExposeToLevelEditor(VALUE_100_ID)]
		public List<REPLACE_TYPE?> Value2 { get; set; }
	}
}
#pragma warning restore CS8618";
		
		private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvxyz0123456789";

		private void OnGUI()
		{
			type = EditorGUILayout.TextField("Type", type);

			typeName = ObjectNames.NicifyVariableName(type).Replace(" ", "");

			typeName = EditorGUILayout.TextField(typeNameContent, typeName);
			testName = EditorGUILayout.TextField("Test Name", testName);

			EditorGUILayout.Space();

			testLocation = EditorGUILayout.TextField("Test Location", testLocation);
			if (GUILayout.Button("Browse..."))
			{
				testLocation = EditorUtility.OpenFolderPanel("Select test location", EditorPrefs.GetString("TestSaveLocation", Application.dataPath), "Tests");
				EditorPrefs.SetString("TestSaveLocation", testLocation);
			}

			testScriptLocation = EditorGUILayout.TextField("Test Script Location", testScriptLocation);
			if (GUILayout.Button("Browse..."))
			{
				testScriptLocation = EditorUtility.OpenFolderPanel("Select test script location", EditorPrefs.GetString("TestScriptSaveLocation", Application.dataPath), "Test Scripts");
				EditorPrefs.SetString("TestScriptSaveLocation", testScriptLocation);
			}

			EditorGUILayout.Space();

			bool oEnabled = GUI.enabled;

			GUI.enabled = !string.IsNullOrWhiteSpace(type) && !string.IsNullOrWhiteSpace(typeName) && !string.IsNullOrWhiteSpace(testLocation) && !string.IsNullOrWhiteSpace(testScriptLocation);
			if (GUILayout.Button("Save"))
			{
				WriteTest(testName, type, typeName, $"{testLocation}/{typeName}Tests.cs");
				WriteTestScript(type, typeName, $"{testScriptLocation}/{typeName}TestScripts.cs");

				// AssetDatabase.Refresh();
			}

			GUI.enabled = oEnabled;
			EditorGUILayout.Space(30);
			if (GUILayout.Button("Stloc Test"))
			{
				string saveLocation = EditorUtility.SaveFilePanel("Save Test Script", Application.dataPath, "StlocTest", "cs");
				if (!string.IsNullOrWhiteSpace(saveLocation))
				{
					WriteStloc(saveLocation);
					AssetDatabase.Refresh();
				}
			}
		}

		[MenuItem("Tools/ALE/Test Script Generator")]
		public static void OpenWindow()
		{
			TestScriptGenerator window = CreateInstance<TestScriptGenerator>();
			window.titleContent = new GUIContent("Test Script Generator");
			window.Show();
		}

		private static void WriteTest(string testName, string type, string typeName, string saveLocation)
		{
			string test = TEST_TEMPLATE;
			test = test.Replace("REPLACE_TESTNAME", testName);
			test = test.Replace("REPLACE_NAME", typeName);
			test = test.Replace("REPLACE_TYPE", type);
			test = test.Replace("VALUE_1", GetRandomValue(type));
			test = test.Replace("VALUE_2", GetRandomValue(type));
			test = test.Replace("VALUE_3", GetRandomValue(type));
			test = test.Replace("VALUE_4", GetRandomValue(type));

			if (type == "GameObject" || type == "Transform" || type == "ScriptReference")
			{
				test = test.Replace("REPLACE_TEST_COLLECTION_RUN", "RunReferenceCollectionTest");
				test = test.Replace("REPLACE_TEST_RUN", "RunReferenceTest");
				test = test.Replace("INVALID", "false");
				test = test.Replace("#nullable", "TEMP_NULLABLE");
				test = test.Replace("null", "true");
				test = test.Replace("TEMP_NULLABLE", "#nullable");

				Regex arrayRegex = new Regex($"new {type}\\??\\[\\] \\{{ (.*?) }}");
				Regex listRegex = new Regex($"new List<{type}\\??> \\{{ (.*?) }}");

				test = arrayRegex.Replace(test, match => match.Groups[1].Value);
				test = listRegex.Replace(test, match => match.Groups[1].Value);
			}
			else
			{
				test = test.Replace("REPLACE_TEST_COLLECTION_RUN", "RunTest");
				test = test.Replace("REPLACE_TEST_RUN", "RunTest");
			}
			
			File.WriteAllText(saveLocation, test);
		}

		private static void WriteTestScript(string type, string typeName, string saveLocation)
		{
			sb.Clear();
			sb.Append(TEST_SCRIPT_TEMPLATE);
			sb.Replace("REPLACE_NAME", typeName);
			sb.Replace("REPLACE_TYPE", type);
			File.WriteAllText(saveLocation, sb.ToString());
		}

		private static void WriteStloc(string saveLocation)
		{
			sb.Clear();

			for (int i = 0; i < 500; i++)
			{
				sb.AppendLine($"\t\tint variable{i} = {i};");
				sb.AppendLine($"\t\tvariable{i} *= 2;");
			}

			string lines = sb.ToString();

			sb.Clear();

			sb.Append("\t\tDebug.Log($\"");
			for (int i = 0; i < 500; i++)
			{
				sb.Append($"Var {i}: {{variable{i}}}, ");
			}

			sb.Append("\");");

			string log = sb.ToString();

			sb.Clear();
			sb.AppendLine(@"using UnityEngine;

public class ExtremeStloc
{
	public void Method()
	{
REPLACE_ME
LOG
	}
}");

			sb.Replace("REPLACE_ME", lines);
			sb.Replace("LOG", log);
			File.WriteAllText(saveLocation, sb.ToString());
		}

		private static string GetRandomValue(string type)
		{
			switch (type)
			{
				case "bool":
					return (UnityEngine.Random.value < 0.5f).ToString().ToLowerInvariant();
				case "byte":
					return UnityEngine.Random.Range(byte.MinValue, byte.MaxValue).ToString();
				case "sbyte":
					return UnityEngine.Random.Range(sbyte.MinValue, sbyte.MaxValue).ToString();
				case "short":
					return UnityEngine.Random.Range(short.MinValue, short.MaxValue).ToString();
				case "ushort":
					return UnityEngine.Random.Range(ushort.MinValue, ushort.MaxValue).ToString();
				case "int":
					return UnityEngine.Random.Range(int.MinValue, int.MaxValue).ToString();
				case "uint":
					return NextLong(random, uint.MinValue, uint.MaxValue).ToString();
				case "long":
					return NextLong(random, long.MinValue, long.MaxValue).ToString();
				case "ulong":
					return NextULong(random, ulong.MinValue, ulong.MaxValue).ToString();
				case "float":
					return UnityEngine.Random.Range(-1000f, 1000f).ToString("F2") + "F";
				case "double":
					return NextDouble(random, -100000, 100000).ToString(CultureInfo.InvariantCulture);
				case "decimal":
					return NextDecimal(random).ToString(CultureInfo.InvariantCulture) + "m";
				case "string":
					string s = "\"";
					int count = UnityEngine.Random.Range(10, 20);
					for (int i = 0; i < count; i++)
					{
						s += ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)];
					}

					s += "\"";

					return s;
				case "char":
					return $"'{ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)]}'";
				case "Guid":
					return "Guid.NewGuid()";
				case "DateTime":
					return $"new DateTime({UnityEngine.Random.Range(1980, 2022)}, {UnityEngine.Random.Range(1, 13)}, {UnityEngine.Random.Range(1, 28)}, {UnityEngine.Random.Range(0, 24)}, {UnityEngine.Random.Range(0, 60)}, {UnityEngine.Random.Range(0, 60)})";
				case "TimeSpan":
					return $"new TimeSpan({NextLong(random, 1000, 50000)})";
				case "Uri":
					return $"new Uri(\"https://www.{ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)]}{ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)]}" +
					       $"{ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)]}{ALPHABET[UnityEngine.Random.Range(0, ALPHABET.Length)]}.com\")";
				case "AnimationCurve":
					return $"new AnimationCurve(new Keyframe(0, {UnityEngine.Random.value:F2}F), new Keyframe(1f, {UnityEngine.Random.value:F2}F))";
				case "Bounds":
					return $"new Bounds({GetRandomValue("Vector3")}, {GetRandomValue("Vector3")})";
				case "BoundsInt":
					return $"new BoundsInt({GetRandomValue("Vector3Int")}, {GetRandomValue("Vector3Int")})";
				case "Color32":
					return $"new Color32({GetRandomValue("byte")}, {GetRandomValue("byte")}, {GetRandomValue("byte")}, {GetRandomValue("byte")})";
				case "Color":
					return $"new Color({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "GradientAlphaKey":
					return $"new GradientAlphaKey({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "GradientColorKey":
					return $"new GradientColorKey({GetRandomValue("Color")}, {UnityEngine.Random.value:F2}F)";
				case "Gradient":
					return $"new Gradient() {{ alphaKeys = new GradientAlphaKey[] {{ {GetRandomValue("GradientAlphaKey")}, {GetRandomValue("GradientAlphaKey")} }}, " +
					       $"colorKeys = new GradientColorKey[] {{ {GetRandomValue("GradientColorKey")}, {GetRandomValue("GradientColorKey")} }}}}";
				case "Keyframe":
					return $"new Keyframe({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "LayerMask":
					return $"new LayerMask() {{ value = {random.Next(0, 100)} }}";
				case "Matrix4x4":
					return $"new Matrix4x4({GetRandomValue("Vector4")}, {GetRandomValue("Vector4")}, {GetRandomValue("Vector4")}, {GetRandomValue("Vector4")})";
				case "Quaternion":
					return $"new Quaternion({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "RangeInt":
					return $"new RangeInt({random.Next(0, 1000)}, {random.Next(1000, 2000)})";
				case "Rect":
					return $"new Rect({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "RectInt":
					return $"new RectInt({random.Next(0, 20)}, {random.Next(0, 20)}, {random.Next(0, 20)}, {random.Next(0, 20)})";
				case "RectOffset":
					return $"new RectOffset({random.Next(0, 20)}, {random.Next(0, 20)}, {random.Next(0, 20)}, {random.Next(0, 20)})";
				case "Vector2":
					return $"new Vector2({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "Vector2Int":
					return $"new Vector2Int({random.Next(0, 2000)}, {random.Next(0, 2000)})";				
				case "Vector3":
					return $"new Vector3({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "Vector3Int":
					return $"new Vector3Int({random.Next(0, 2000)}, {random.Next(0, 2000)}, {random.Next(0, 2000)})";
				case "Vector4":
					return $"new Vector4({UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F, {UnityEngine.Random.value:F2}F)";
				case "WrapMode":
					switch (random.Next(6))
					{
						case 0:
							return "WrapMode.Default";
						case 1:
							return "WrapMode.Clamp";
						case 2:
							return "WrapMode.Once";
						case 3:
							return "WrapMode.Loop";
						case 4:
							return "WrapMode.PingPong";
						default:
							return "WrapMode.ClampForever";
					}
				default:
					return "INVALID";
			}
		}

		// Stolen from https://stackoverflow.com/a/13095144/6257193
		public static long NextLong(Random rand, long min, long max)
		{
			if (max <= min)
			{
				throw new ArgumentOutOfRangeException(nameof(max), "max must be > min!");
			}

			//Working with ulong so that modulo works correctly with values > long.MaxValue
			ulong uRange = (ulong) (max - min);

			//Prevent a modolo bias; see https://stackoverflow.com/a/10984975/238419
			//for more information.
			//In the worst case, the expected number of calls is 2 (though usually it's
			//much closer to 1) so this loop doesn't really hurt performance at all.
			ulong ulongRand;
			do
			{
				byte[] buf = new byte[8];
				rand.NextBytes(buf);
				ulongRand = (ulong) BitConverter.ToInt64(buf, 0);
			} while (ulongRand > ulong.MaxValue - (ulong.MaxValue % uRange + 1) % uRange);

			return (long) (ulongRand % uRange) + min;
		}

		public static ulong NextULong(Random rand, ulong min, ulong max)
		{
			if (max <= min)
			{
				throw new ArgumentOutOfRangeException(nameof(max), "max must be > min!");
			}

			//Working with ulong so that modulo works correctly with values > long.MaxValue
			ulong uRange = max - min;

			//Prevent a modolo bias; see https://stackoverflow.com/a/10984975/238419
			//for more information.
			//In the worst case, the expected number of calls is 2 (though usually it's
			//much closer to 1) so this loop doesn't really hurt performance at all.
			ulong ulongRand;
			do
			{
				byte[] buf = new byte[8];
				rand.NextBytes(buf);
				ulongRand = (ulong) BitConverter.ToInt64(buf, 0);
			} while (ulongRand > ulong.MaxValue - (ulong.MaxValue % uRange + 1) % uRange);

			return ulongRand % uRange + min;
		}

		// https://stackoverflow.com/a/20785647/6257193
		public static double NextDouble(Random rand, double min, double max)
		{
			return rand.NextDouble() * (max - min) + min;
		}

		// https://stackoverflow.com/a/609529/6257193
		public static int NextInt32(Random rng)
		{
			int firstBits = rng.Next(0, 1 << 4) << 28;
			int lastBits = rng.Next(0, 1 << 28);
			return firstBits | lastBits;
		}

		public static decimal NextDecimal(Random rng)
		{
			byte scale = (byte) rng.Next(29);
			bool sign = rng.Next(2) == 1;
			return new decimal(NextInt32(rng), NextInt32(rng), NextInt32(rng), sign, scale);
		}
	}
}