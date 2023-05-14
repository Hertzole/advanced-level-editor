using UnityEngine;

namespace Hertzole.ALE.Example
{
	public class Button : MonoBehaviour, ILevelEditorPlayModeObject, ILevelEditorGizmos
	{
		[SerializeField]
		[ExposeToLevelEditor(0)]
		private bool invert;
		[SerializeField]
		[ExposeToLevelEditor(1)]
		private Interactable target;

		private bool playing;

		private int counter;

		private void OnTriggerEnter(Collider other)
		{
			if (playing && target != null)
			{
				counter++;

				if (counter == 1)
				{
					if (invert)
					{
						target.OnStopInteract();
					}
					else
					{
						target.OnStartInteract();
					}
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (playing && target != null)
			{
				counter--;

				if (counter == 0)
				{
					if (invert)
					{
						target.OnStartInteract();
					}
					else
					{
						target.OnStopInteract();
					}
				}
			}
		}

		public void DrawLevelEditorGizmos(ILevelEditorGizmosDrawer drawer)
		{
			if (target != null)
			{
				drawer.DrawLine(transform.position, target.transform.position, Color.blue);
			}
		}

		public void OnStartPlayMode()
		{
			playing = true;
			counter = 0;

			if (invert && target != null)
			{
				target.OnStartInteract();	
			}
		}

		public void OnStopPlayMode()
		{
			playing = false;
			counter = 0;
		}
	}
}