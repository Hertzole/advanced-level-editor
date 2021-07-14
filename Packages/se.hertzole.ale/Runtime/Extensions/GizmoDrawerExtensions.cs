using UnityEngine;

namespace Hertzole.ALE
{
	public static partial class LevelEditorExtensions
	{
		#region Line extensions
		public static void DrawLine(this ILevelEditorGizmosDrawer drawer, Vector3 start, Vector3 end)
		{
			drawer.DrawLine(start, end, Color.white);
		}
		#endregion

		#region Square extensions
		public static void DrawSquare(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2 size)
		{
			drawer.DrawSquare(center, size, Quaternion.identity, Color.white);
		}

		public static void DrawSquare(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2 size, Vector3 rotation)
		{
			drawer.DrawSquare(center, size, Quaternion.Euler(rotation), Color.white);
		}

		public static void DrawSquare(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2 size, Color color)
		{
			drawer.DrawSquare(center, size, Quaternion.identity, color);
		}

		public static void DrawSquare(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2 size, Vector3 rotation, Color color)
		{
			drawer.DrawSquare(center, size, Quaternion.Euler(rotation), color);
		}
		#endregion

		#region Wire cube extensions
		public static void DrawWireCube(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector3 size)
		{
			drawer.DrawWireCube(center, size, Quaternion.identity, Color.white);
		}

		public static void DrawWireCube(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector3 size, Vector3 rotation)
		{
			drawer.DrawWireCube(center, size, Quaternion.Euler(rotation), Color.white);
		}

		public static void DrawWireCube(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector3 size, Quaternion rotation)
		{
			drawer.DrawWireCube(center, size, rotation, Color.white);
		}

		public static void DrawWireCube(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector3 size, Color color)
		{
			drawer.DrawWireCube(center, size, Quaternion.identity, color);
		}

		public static void DrawWireCube(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector3 size, Vector3 rotation, Color color)
		{
			drawer.DrawWireCube(center, size, Quaternion.Euler(rotation), color);
		}
		#endregion
		
		#region 2D Grid extensions
		public static void Draw2DGrid(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2Int size, Vector2 spacing)
		{
			drawer.Draw2DGrid(center, size, spacing, Quaternion.identity, Color.white);
		}

		public static void Draw2DGrid(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2Int size, Vector2 spacing, Vector3 rotation)
		{
			drawer.Draw2DGrid(center,size,spacing,Quaternion.Euler(rotation), Color.white);
		}

		public static void Draw2DGrid(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2Int size, Vector2 spacing, Quaternion rotation)
		{
			drawer.Draw2DGrid(center,size, spacing, rotation, Color.white);
		}

		public static void Draw2DGrid(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2Int size, Vector2 spacing, Color color)
		{
			drawer.Draw2DGrid(center, size, spacing, Quaternion.identity, color);
		}

		public static void Draw2DGrid(this ILevelEditorGizmosDrawer drawer, Vector3 center, Vector2Int size, Vector2 spacing, Vector3 rotation, Color color)
		{
			drawer.Draw2DGrid(center, size, spacing, Quaternion.Euler(rotation), color);
		}
		#endregion
	}
}