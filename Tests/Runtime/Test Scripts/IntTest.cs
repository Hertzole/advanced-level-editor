using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class IntTest1 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public int value;
	}
	
	public class IntTest5 : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public int Value { get; set; }
	}
}