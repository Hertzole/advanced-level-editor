using System;
using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public enum NormalEnum
	{
		Value1,
		Value2,
		Value3,
		Value4
	}

	public enum ByteEnum : byte
	{
		Value1,
		Value2,
		Value3,
		Value4
	}

	[Flags]
	public enum ByteFlagsEnum : byte
	{
		None = 0,
		Value1 = 1 << 0,
		Value2 = 1 << 1,
		Value3 = 1 << 2,
		Value4 = 1 << 3
	}
	
	public class EnumTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public NormalEnum value;
		[ExposeToLevelEditor(1)]
		public NormalEnum Value { get; set; }
	}
	
	public class ByteEnumTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public ByteEnum value;
		[ExposeToLevelEditor(1)]
		public ByteEnum Value { get; set; }
	}

	public class ByteFlagsEnumTest : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public ByteFlagsEnum value;
		[ExposeToLevelEditor(1)]
		public ByteFlagsEnum Value { get; set; }
	}
}