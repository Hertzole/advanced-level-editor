using UnityEngine;
using System.Linq;

namespace Hertzole.ALE
{
	/// <summary>
	///     Helper class to only show objects when you're in the level editor and not play mode.
	/// </summary>
	public class LevelEditorOnlyObjects : MonoBehaviour, ILevelEditorPlayModeObject, ILevelEditorPoolable
	{
		[SerializeField]
		private GameObject[] targets = default;

		private bool isInLevelEditor;

		private void Awake()
		{
			isInLevelEditor = FindObjectsOfType<MonoBehaviour>().OfType<ILevelEditor>().FirstOrDefault() != null;
		}

		private void ToggleGraphics(bool isOn)
		{
			for (int i = 0; i < targets.Length; i++)
			{
				targets[i].gameObject.SetActive(isOn);
			}
		}

		public void OnStartPlayMode()
		{
			ToggleGraphics(false);
		}

		public void OnStopPlayMode()
		{
			ToggleGraphics(true);
		}

		public void OnLevelEditorPooled()
		{
			// No need to do anything.
		}

		public void OnLevelEditorUnpooled()
		{
			ToggleGraphics(isInLevelEditor);
		}
	}
}
