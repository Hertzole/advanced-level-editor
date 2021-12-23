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

	public struct MyStruct
	{
		public int test1;
		public string test2;
	}
}