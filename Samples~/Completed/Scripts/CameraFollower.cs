using UnityEngine;

namespace Hertzole.ALE.Example
{
	public class CameraFollower : MonoBehaviour
	{
		[SerializeField]
		private string playerTag = "Player";

		[SerializeField]
		private Vector3 offset = new Vector3(0, 5, -5);

		private bool foundTarget;

		private Transform target;

		private void Start()
		{
			GameObject targetGo = GameObject.FindWithTag(playerTag);
			if (targetGo != null)
			{
				target = targetGo.transform;
				foundTarget = true;
				transform.position = target.transform.position + offset;
				transform.LookAt(target);
			}
		}

		private void Update()
		{
			if (foundTarget)
			{
				transform.position = target.transform.position + offset;
				transform.LookAt(target);
			}
		}
	}
}