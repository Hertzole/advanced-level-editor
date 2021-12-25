using UnityEngine;
using Hertzole.ALE;

public class ExposedClass : MonoBehaviour
{
	[ExposeToLevelEditor(0)]
	public int intValue;
	[ExposeToLevelEditor(1)]
	public string stringValue;
}