using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class InheritParent : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public int parentValue;
	}
	
	public class InheritChild : InheritParent
	{
		[ExposeToLevelEditor(1)]
		public int childValue;
	}
}