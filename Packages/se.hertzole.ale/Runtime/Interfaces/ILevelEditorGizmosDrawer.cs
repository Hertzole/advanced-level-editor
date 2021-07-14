using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
	public interface ILevelEditorGizmosDrawer
	{
		void DrawLine(Vector3 start, Vector3 end, Color color);

		void DrawQuads(IReadOnlyList<Vector3> lines, Color color);

		void DrawSquare(Vector3 center, Vector2 size, Quaternion rotation, Color color);

		void DrawWireCube(Vector3 center, Vector3 size, Quaternion rotation, Color color);

		void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing, Quaternion rotation, Color color);
	}
}