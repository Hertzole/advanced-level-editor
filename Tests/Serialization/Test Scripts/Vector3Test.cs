using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class Vector3Test1 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public Vector3 value;
	}

	public class Vector3Test2 : MonoBehaviour
	{
		[ExposeToLevelEditor(100)]
		public Vector3 value;
	}

	public class Vector3Test3 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public Vector3 value1;

		[ExposeToLevelEditor(1)]
		public Vector3 value2;
	}

	public class Vector3Test4 : MonoBehaviour
	{
		[ExposeToLevelEditor(5)]
		public Vector3 value1;

		[ExposeToLevelEditor(10)]
		public Vector3 value2;
	}

	public class Vector3Test5 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public Vector3 Value { get; set; }
	}

	public class Vector3Test6 : MonoBehaviour
	{
		[ExposeToLevelEditor(100)]
		public Vector3 Value { get; set; }
	}

	public class Vector3Test7 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public Vector3 Value1 { get; set; }

		[ExposeToLevelEditor(1)]
		public Vector3 Value2 { get; set; }
	}

	public class Vector3Test8 : MonoBehaviour
	{
		[ExposeToLevelEditor(5)]
		public Vector3 Value1 { get; set; }

		[ExposeToLevelEditor(10)]
		public Vector3 Value2 { get; set; }
	}
}