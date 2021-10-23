using UnityEngine;

namespace Hertzole.ALE.Example
{
	public enum DoorDirection
	{
		Top = 0,
		Bottom = 1,
		Left = 2,
		Right = 3
	}

	public class Door : Interactable, ILevelEditorPlayModeObject
	{
		[SerializeField]
		[ExposeToLevelEditor(0)]
		private DoorDirection direction = DoorDirection.Top;
		[SerializeField]
		[ExposeToLevelEditor(1)]
		private float lerpTime = 1;
		[SerializeField]
		private Transform graphic;

		[SerializeField]
		[HideInInspector]
		private BoxCollider box;

		private bool playing;

		private float timeElapsed;

		private Vector3 startPosition;
		private Vector3 targetPosition;

		private void Update()
		{
			if (!playing)
			{
				return;
			}

			if (timeElapsed < lerpTime)
			{
				graphic.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, timeElapsed / lerpTime);
				timeElapsed += Time.deltaTime;
			}
			else
			{
				graphic.transform.localPosition = targetPosition;
			}
		}

		public override void OnStartInteract()
		{
			timeElapsed = 0;
			startPosition = graphic.transform.localPosition;

			box.enabled = false;

			switch (direction)
			{
				case DoorDirection.Top:
					targetPosition = new Vector3(0, 1, 0);
					break;
				case DoorDirection.Bottom:
					targetPosition = new Vector3(0, -1, 0);
					break;
				case DoorDirection.Left:
					targetPosition = new Vector3(-1, 0, 0);
					break;
				case DoorDirection.Right:
					targetPosition = new Vector3(1, 0, 0);
					break;
			}
		}

		public override void OnStopInteract()
		{
			timeElapsed = 0;
			box.enabled = true;

			startPosition = targetPosition;

			targetPosition = Vector3.zero;
		}

		private void ResetDoor()
		{
			timeElapsed = 0;

			box.enabled = true;

			targetPosition = Vector3.zero;
			startPosition = Vector3.zero;
			graphic.transform.localPosition = Vector3.zero;
		}

		public void OnStartPlayMode()
		{
			playing = true;
			ResetDoor();
		}

		public void OnStopPlayMode()
		{
			playing = false;
			ResetDoor();
		}

#if UNITY_EDITOR
		private void Reset()
		{
			GetStandardComponents();
		}

		private void OnValidate()
		{
			GetStandardComponents();
		}

		private void GetStandardComponents()
		{
			if (box == null)
			{
				box = GetComponent<BoxCollider>();
			}
		}
#endif
	}
}