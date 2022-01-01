using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
	internal class TestScriptGenerator : EditorWindow
	{
		private string type;
		private string typeName;

		private static readonly StringBuilder sb = new StringBuilder();
		
		[MenuItem("Tools/ALE/Test Script Generator")]
		public static void OpenWindow()
		{
			TestScriptGenerator window = CreateInstance<TestScriptGenerator>();
			window.titleContent = new GUIContent("Test Script Generator");
			window.Show();
		}

		private void OnGUI()
		{
			type = EditorGUILayout.TextField("Type", type);
			typeName = EditorGUILayout.TextField("Type Name", typeName);

			EditorGUILayout.Space();

			if (GUILayout.Button("Save"))
			{
				string saveLocation = EditorUtility.SaveFilePanel("Save Test Script", EditorPrefs.GetString("TestScriptSaveLocation", Application.dataPath), $"{typeName}TestScripts", "cs");
				if (!string.IsNullOrWhiteSpace(saveLocation))
				{
					WriteTest(type, typeName, saveLocation);
					EditorPrefs.SetString("TestScriptSaveLocation", saveLocation);
					AssetDatabase.Refresh();
				}
			}
			EditorGUILayout.Space(30);
			if (GUILayout.Button("Stloc Test"))
			{
				string saveLocation = EditorUtility.SaveFilePanel("Save Test Script", Application.dataPath, $"StlocTest", "cs");
				if (!string.IsNullOrWhiteSpace(saveLocation))
				{
					WriteStloc(saveLocation);
					AssetDatabase.Refresh();
				}
			}
		}

		private static void WriteTest(string type, string typeName, string saveLocation)
		{
			sb.Clear();
			sb.Append(TEMPLATE);
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

		private const string TEMPLATE = @"// DO NOT MODIFY! THIS IS A GENERATED FILE!

using System;
using System.Collections.Generic;
using UnityEngine;
using static Hertzole.ALE.Tests.SerializationTest;

// ReSharper disable ConvertToAutoProperty

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
}";
	}
}
