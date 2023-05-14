using System;
using UnityEngine;

namespace Hertzole.ALE.Example
{
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] 
		private float moveSpeed = 5;
		
		[SerializeField] 
		[HideInInspector]
		private Rigidbody rig;

		private Vector2 moveDirection;
		
		private void Update()
		{
			GetInput();
		}

		private void FixedUpdate()
		{
			DoMovement();
		}

		private void GetInput()
		{
			moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		}

		private void DoMovement()
		{
			rig.MovePosition(rig.position + new Vector3(moveDirection.x, 0, moveDirection.y) * (moveSpeed * Time.fixedDeltaTime));
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
			if (rig == null)
			{
				rig = GetComponent<Rigidbody>();
			}
		}
#endif
	}
}