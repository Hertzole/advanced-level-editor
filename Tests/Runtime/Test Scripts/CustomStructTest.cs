using System;
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

	public class NonSerializedValueTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public StructWithNonSerialized value;
		[ExposeToLevelEditor(1)]
		public StructWithNonSerialized Value { get; set; }
	}


	public class NonSerializedStructTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public NonSerializedStruct value;
		[ExposeToLevelEditor(1)]
		public NonSerializedStruct Value { get; set; }
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

	public struct StructWithNonSerialized
	{
		public int value1;
		[NonSerialized]
		public bool value2;
	}

	public struct NonSerializedStruct
	{
		[NonSerialized]
		public int value1;
		[NonSerialized]
		public bool value2;
	}
}