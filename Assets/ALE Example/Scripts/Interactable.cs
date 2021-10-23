using UnityEngine;

namespace Hertzole.ALE.Example
{
	public abstract class Interactable : MonoBehaviour
	{
		public abstract void OnStartInteract();
		
		public abstract void OnStopInteract();
	}
}