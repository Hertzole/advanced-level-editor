using UnityEngine;

namespace Hertzole.ALE
{
    public static class LevelEditorGizmos
    {
        public static bool IsInitialized { get; private set; }

        private static Shader lineShader;

        private static Material linesMaterial;

        public static Material LinesMaterial { get { return linesMaterial; } }

#if UNITY_2019_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics()
        {
            IsInitialized = false;

            lineShader = null;

            Cleanup();
        }
#endif

        public static void Initialize(ILevelEditorGL gl)
        {
#if DEBUG
            if (IsInitialized)
            {
                Debug.LogError("LevelEditorGizmos is already initialized! This shouldn't be called twice!");
                return;
            }
#endif
            GetShaderValues(gl);

            Build();

            IsInitialized = true;
        }

        private static void GetShaderValues(ILevelEditorGL shaders)
        {
            lineShader = shaders.LineShader;
        }

        public static void Cleanup()
        {
            if (linesMaterial != null)
            {
                Object.Destroy(linesMaterial);
            }
        }

        private static void Build()
        {
            linesMaterial = new Material(lineShader);
        }

        public static void Rebuild(ILevelEditorGL shaders = null)
        {
            if (shaders != null)
            {
                GetShaderValues(shaders);
            }

            Cleanup();
            Build();
        }

        public static void DrawLine(Vector3 start, Vector3 end)
        {
            DrawLine(start, end, Color.white);
        }

        public static void DrawLine(Vector3 start, Vector3 end, Color color)
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

        public static void DrawSquare(Vector3 center, Vector2 size)
        {
            DrawSquare(center, size, Quaternion.identity, Color.white);
        }

        public static void DrawSquare(Vector3 center, Vector2 size, Vector3 rotation)
        {
            DrawSquare(center, size, Quaternion.Euler(rotation), Color.white);
        }

        public static void DrawSquare(Vector3 center, Vector2 size, Quaternion rotation)
        {
            DrawSquare(center, size, rotation, Color.white);
        }

        public static void DrawSquare(Vector3 center, Vector2 size, Color color)
        {
            DrawSquare(center, size, Quaternion.identity, color);
        }

        public static void DrawSquare(Vector3 center, Vector2 size, Vector3 rotation, Color color)
        {
            DrawSquare(center, size, Quaternion.Euler(rotation), color);
        }

        public static void DrawSquare(Vector3 center, Vector2 size, Quaternion rotation, Color color)
        {
            linesMaterial.SetPass(0);

            GL.PushMatrix();
            GL.Begin(GL.LINES);
            GL.Color(color);

            size /= 2f;

            Vector3[] points = new Vector3[]
            {
                new Vector3(-size.x, -size.y, 0),
                new Vector3(-size.x, +size.y, 0),

                new Vector3(-size.x, +size.y, 0),
                new Vector3(+size.x, +size.y, 0),

                new Vector3(+size.x, +size.y, 0),
                new Vector3(+size.x, -size.y, 0),

                new Vector3(+size.x, -size.y, 0),
                new Vector3(-size.x, -size.y, 0),
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

        public static void DrawWireCube(Vector3 center, Vector3 size)
        {
            DrawWireCube(center, size, Quaternion.identity, Color.white);
        }

        public static void DrawWireCube(Vector3 center, Vector3 size, Vector3 rotation)
        {
            DrawWireCube(center, size, Quaternion.Euler(rotation), Color.white);
        }

        public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion rotation)
        {
            DrawWireCube(center, size, rotation, Color.white);
        }

        public static void DrawWireCube(Vector3 center, Vector3 size, Color color)
        {
            DrawWireCube(center, size, Quaternion.identity, color);
        }

        public static void DrawWireCube(Vector3 center, Vector3 size, Vector3 rotation, Color color)
        {
            DrawWireCube(center, size, Quaternion.Euler(rotation), color);
        }

        public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion rotation, Color color)
        {
            linesMaterial.SetPass(0);

            GL.PushMatrix();
            GL.Begin(GL.LINES);
            GL.Color(color);

            size /= 2f;

            Vector3[] points = new Vector3[]
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
                new Vector3(+size.x, -size.y, +size.z),
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

        public static void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing)
        {
            Draw2DGrid(center, size, spacing, Quaternion.identity, Color.white);
        }

        public static void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing, Vector3 rotation)
        {
            Draw2DGrid(center, size, spacing, Quaternion.Euler(rotation), Color.white);
        }

        public static void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing, Quaternion rotation)
        {
            Draw2DGrid(center, size, spacing, rotation, Color.white);
        }

        public static void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing, Color color)
        {
            Draw2DGrid(center, size, spacing, Quaternion.identity, color);
        }

        public static void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing, Vector3 rotation, Color color)
        {
            Draw2DGrid(center, size, spacing, Quaternion.Euler(rotation), color);
        }

        public static void Draw2DGrid(Vector3 center, Vector2Int size, Vector2 spacing, Quaternion rotation, Color color)
        {
            linesMaterial.SetPass(0);

            GL.PushMatrix();
            GL.Begin(GL.LINES);
            GL.Color(color);

            Vector3[] points = new Vector3[(size.x * size.y) * 4 + (size.x * 2) + (size.y * 2)];

            int index = 0;

            Vector3 origin = new Vector3(-(size.x / 2f) * spacing.x, -(size.y / 2f) * spacing.y, 0);

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    points[index] = new Vector3(x * spacing.x + origin.x, y * spacing.y + origin.y, origin.z);
                    points[index + 1] = new Vector3(x * spacing.x + origin.x, y * spacing.y + (1 * spacing.y) + origin.y, origin.z);

                    points[index + 2] = new Vector3(x * spacing.x + origin.x, y * spacing.y + origin.y, origin.z);
                    points[index + 3] = new Vector3(x * spacing.x + origin.x + (1 * spacing.x), y * spacing.y + origin.y, origin.z);

                    index += 4;

                    if (x == size.x - 1)
                    {
                        points[index] = new Vector3(x * spacing.x + (1 * spacing.x) + origin.x, y * spacing.y + origin.y, origin.z);
                        points[index + 1] = new Vector3(x * spacing.x + (1 * spacing.x) + origin.x, y * spacing.y + (1 * spacing.y) + origin.y, origin.z);

                        index += 2;
                    }

                    if (y == size.y - 1)
                    {
                        points[index] = new Vector3(x * spacing.x + origin.x, y * spacing.y + (1 * spacing.y) + origin.y, origin.z);
                        points[index + 1] = new Vector3(x * spacing.x + origin.x + (1 * spacing.x), y * spacing.y + (1 * spacing.y) + origin.y, origin.z);
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
