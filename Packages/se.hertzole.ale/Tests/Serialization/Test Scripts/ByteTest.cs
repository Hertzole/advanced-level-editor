using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class ByteTest1 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public byte value;
	}

	public class ByteTest2 : MonoBehaviour
	{
		[ExposeToLevelEditor(100)]
		public byte value;
	}

	public class ByteTest3 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public byte value1;

		[ExposeToLevelEditor(1)]
		public byte value2;
	}

	public class ByteTest4 : MonoBehaviour
	{
		[ExposeToLevelEditor(5)]
		public byte value1;

		[ExposeToLevelEditor(10)]
		public byte value2;
	}

	public class ByteTest5 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public byte Value { get; set; }
	}

	public class ByteTest6 : MonoBehaviour
	{
		[ExposeToLevelEditor(100)]
		public byte Value { get; set; }
	}

	public class ByteTest7 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public byte Value1 { get; set; }

		[ExposeToLevelEditor(1)]
		public byte Value2 { get; set; }
	}

	public class ByteTest8 : MonoBehaviour
	{
		[ExposeToLevelEditor(5)]
		public byte Value1 { get; set; }

		[ExposeToLevelEditor(10)]
		public byte Value2 { get; set; }
	}

	public class ByteArrayTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public byte[] value;
	}

	public class ByteListTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public List<byte> value;
	}
}