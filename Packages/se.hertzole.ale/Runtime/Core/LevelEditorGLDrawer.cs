using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hertzole.ALE
{
	public class LevelEditorGLDrawer : ILevelEditorGizmosDrawer, IDisposable
	{
		private readonly Material linesMaterial;

		public LevelEditorGLDrawer(Shader lineShader)
		{
			linesMaterial = new Material(lineShader);
		}

		public void Dispose()
		{
			if (linesMaterial != null)
			{
				Object.Destroy(linesMaterial);
			}
		}

		public void DrawLine(Vector3 start, Vector3 end, Color color)
		{
			linesMaterial.SetPass(0);

			GL.PushMatrix();
			GL.Begin(GL.LINES);
			GL.Color(color);

			GL.Vertex(start);
			GL.Vertex(end);
			GL.End();
			GL.PopMatrix();
		}

		public void DrawQuads(IReadOnlyList<Vector3> lines, Color color)
		{
			if (lines == null || lines.Count == 0)
			{
				return;
			}

			linesMaterial.SetPass(0);

			GL.Begin(GL.QUADS);
			GL.Color(color);

			for (int i = 0; i < lines.Count; i += 4)
			{
				GL.Vertex(lines[i]);
				GL.Vertex(lines[i + 1]);
				GL.Vertex(lines[i + 2]);
				GL.Vertex(lines[i + 3]);
			}

			GL.End();
		}

		public void DrawTriangles(IReadOnlyList<Vector3> lines, Color color)
		{
			if (lines.Count == 0)
			{
				return;
			}

			linesMaterial.SetPass(0);

			GL.Begin(GL.TRIANGLES);
			GL.Color(color);

			for (int i = 0; i < lines.Count; i += 3)
			{
				GL.Vertex(lines[i]);
				GL.Vertex(lines[i + 1]);
				GL.Vertex(lines[i + 2]);
			}

			GL.End();
		}

		public void DrawSquare(Vector3 center, Vector2 size, Quaternion rotation, Color color)
		{
			linesMaterial.SetPass(0);

			GL.PushMatrix();
			GL.Begin(GL.LINES);
			GL.Color(color);

			size /= 2f;

			Vector3[] points =
			{
				new Vector3(-size.x, -size.y, 0),
				new Vector3(-size.x, +size.y, 0),

				new Vector3(-size.x, +size.y, 0),
				new Vector3(+size.x, +size.y, 0),

				new Vector3(+size.x, +size.y, 0),
				new Vector3(+size.x, -size.y, 0),

				new Vector3(+size.x, -size.y, 0),
				new Vector3(-size.x, -size.y, 0)
			};

			Matrix4x4 m = Matrix4x4.TRS(center, rotation, Vector3.one);

			for (int i = 0; i < points.Length; i++)
			{
				points[i] = m.MultiplyPoint3x4(points[i]);
			}

			for (int i = 0; i < points.Length; i++)
			{
				GL.Vertex(points[i]);
			}

			GL.End();
			GL.PopMatrix();
		}

		public void DrawWireCube(Vector3 center, Vector3 size, Quaternion rotation, Color color)
		{
			linesMaterial.SetPass(0);

			GL.PushMatrix();
			GL.Begin(GL.LINES);
			GL.Color(color);

			size /= 2f;

			Vector3[] points =
			{
				new Vector3(-size.x, -size.y, -size.z),
				new Vector3(-size.x, +size.y, -size.z),

				new Vector3(-size.x, +size.y, -size.z),
				new Vector3(+size.x, +size.y, -size.z),

				new Vector3(+size.x, +size.y, -size.z),
				new Vector3(+size.x, -size.y, -size.z),

				new Vector3(+size.x, -size.y, -size.z),
				new Vector3(-size.x, -size.y, -size.z),

				new Vector3(-size.x, -size.y, -size.z),
				new Vector3(-size.x, -size.y, +size.z),

				new Vector3(-size.x, +size.y, -size.z),
				new Vector3(-size.x, +size.y, +size.z),

				new Vector3(+size.x, -size.y, -size.z),
				new Vector3(+size.x, -size.y, +size.z),

				new Vector3(+size.x, +size.y, -size.z),
				new Vector3(+size.x, +size.y, +size.z),

				new Vector3(-size.x, -size.y, +size.z),
				new Vector3(-size.x, +size.y, +size.z),

				new Vector3(+size.x, -size.y, +size.z),
				new Vector3(+size.x, +size.y, +size.z),

				new Vector3(-size.x, +size.y, +size.z),
				new Vector3(+size.x, +size.y, +size.z),

				new Vector3(-size.x, -size.y, +size.z),
				new Vector3(+size.x, -size.y, +size.z)
			};

			Matrix4x4 m = Matrix4x4.TRS(center, rotation, Vector3.one);

			for (int i = 0; i < points.Length; i++)
			{
				points[i] = m.MultiplyPoint3x4(points[i]);
			}

			for (int i = 0; i < points.Length; i++)
			{
				GL.Vertex(points[i]);
			}

			GL.End();
			GL.PopMatrix();
		}

		public void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing, Quaternion rotation, Color color)
		{
			linesMaterial.SetPass(0);

			GL.PushMatrix();
			GL.Begin(GL.LINES);
			GL.Color(color);

			Vector3[] points = new Vector3[size.x * size.y * 4 + size.x * 2 + size.y * 2];

			int index = 0;

			Vector3 origin = new Vector3(-(size.x / 2f) * spacing.x, -(size.y / 2f) * spacing.y, 0);

			for (int x = 0; x < size.x; x++)
			{
				for (int y = 0; y < size.y; y++)
				{
					points[index] = new Vector3(x * spacing.x + origin.x, y * spacing.y + origin.y, origin.z);
					points[index + 1] = new Vector3(x * spacing.x + origin.x, y * spacing.y + 1 * spacing.y + origin.y, origin.z);

					points[index + 2] = new Vector3(x * spacing.x + origin.x, y * spacing.y + origin.y, origin.z);
					points[index + 3] = new Vector3(x * spacing.x + origin.x + 1 * spacing.x, y * spacing.y + origin.y, origin.z);

					index += 4;

					if (x == size.x - 1)
					{
						points[index] = new Vector3(x * spacing.x + 1 * spacing.x + origin.x, y * spacing.y + origin.y, origin.z);
						points[index + 1] = new Vector3(x * spacing.x + 1 * spacing.x + origin.x, y * spacing.y + 1 * spacing.y + origin.y, origin.z);

						index += 2;
					}

					if (y == size.y - 1)
					{
						points[index] = new Vector3(x * spacing.x + origin.x, y * spacing.y + 1 * spacing.y + origin.y, origin.z);
						points[index + 1] = new Vector3(x * spacing.x + origin.x + 1 * spacing.x, y * spacing.y + 1 * spacing.y + origin.y, origin.z);
						index += 2;
					}
				}
			}

			Matrix4x4 m = Matrix4x4.TRS(center, rotation, Vector3.one);

			for (int i = 0; i < points.Length; i++)
			{
				points[i] = m.MultiplyPoint3x4(points[i]);
				GL.Vertex(points[i]);
			}

			GL.End();
			GL.PopMatrix();
		}
	}
}