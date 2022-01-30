using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE.Tests.TestScripts
{
	public class TransformReferenceScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public Transform value;
		[ExposeToLevelEditor(1)]
		public Transform Value { get; set; }
	}

	public class TransformReferenceArrayScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public Transform[] value;
		[ExposeToLevelEditor(1)]
		public Transform[] Value { get; set; }
	}

	public class TransformReferenceListScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public List<Transform> value = new List<Transform>();
		[ExposeToLevelEditor(1)]
		public List<Transform> Value { get; set; } = new List<Transform>();
	}

	public class GameObjectReferenceScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public GameObject value;
		[ExposeToLevelEditor(1)]
		public GameObject Value { get; set; }
	}

	public class GameObjectReferenceArrayScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public GameObject[] value;
		[ExposeToLevelEditor(1)]
		public GameObject[] Value { get; set; }
	}

	public class GameObjectReferenceListScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public List<GameObject> value = new List<GameObject>();
		[ExposeToLevelEditor(1)]
		public List<GameObject> Value { get; set; } = new List<GameObject>();
	}
	
	public class TempTestScriptReferenceScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public ScriptReference value;
		[ExposeToLevelEditor(1)]
		public ScriptReference Value { get; set; }
	}

	public class TempTestScriptReferenceArrayScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public ScriptReference[] value;
		[ExposeToLevelEditor(1)]
		public ScriptReference[] Value { get; set; }
	}

	public class TempTestScriptReferenceListScript : MonoBehaviour
	{
		[ExposeToLevelEditor(0)]
		public List<ScriptReference> value = new List<ScriptReference>();
		[ExposeToLevelEditor(1)]
		public List<ScriptReference> Value { get; set; } = new List<ScriptReference>();
	}

	public class ScriptReference : MonoBehaviour { }
}