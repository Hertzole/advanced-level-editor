using System;
using System.Runtime.CompilerServices;
using Hertzole.ALE;
using UnityEngine;

namespace My.Namespace
{
	public partial class NewBehaviourScript : MonoBehaviour
	{
		[ExposedVar(0)]
		public byte tester;
		[ExposedVar(1)]
		public string exposedString;
		[ExposedVar(2)]
		public float exposedFloat;
		[ExposedVar(3)]
		public Vector2 exposedVector2;
		[ExposedVar(4)]
		public Vector3 exposedVector3;
		[ExposedVar(5)]
		public Vector4 exposedVector4;
	}
}