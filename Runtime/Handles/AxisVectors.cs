using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
	public struct AxisVectors
	{
		private List<Vector3> x;
		private List<Vector3> y;
		private List<Vector3> z;
		private List<Vector3> all;
		
		public List<Vector3> X {get { return x ??= new List<Vector3>(); }}
		public List<Vector3> Y {get { return y ??= new List<Vector3>(); }}
		public List<Vector3> Z {get { return z ??= new List<Vector3>(); }}
		public List<Vector3> All {get { return all ??= new List<Vector3>(); }}

		public void Add(AxisVectors axisVectors)
		{
			X.AddRange(axisVectors.X);
			Y.AddRange(axisVectors.Y);
			Z.AddRange(axisVectors.Z);
			All.AddRange(axisVectors.All);
		}

		public void Clear()
		{
			X.Clear();
			Y.Clear();
			Z.Clear();
			All.Clear();
		}
	}
}