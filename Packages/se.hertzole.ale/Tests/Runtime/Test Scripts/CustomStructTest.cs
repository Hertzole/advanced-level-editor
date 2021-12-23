using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class CustomStructTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public MyStruct value;
		[ExposeToLevelEditor(1)]
		public MyStruct Value { get; set; }
	}

	public class NestedStructTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public NestedStruct value;
		[ExposeToLevelEditor(1)]
		public NestedStruct Value { get; set; }
	}

	public struct MyStruct
	{
		public int test1;
		public string test2;
	}

	public struct NestedStruct
	{
		public int value;
		public ChildStruct nestedValue;
	}

	public struct ChildStruct
	{
		public int value1;
		public bool value2;
	}
}