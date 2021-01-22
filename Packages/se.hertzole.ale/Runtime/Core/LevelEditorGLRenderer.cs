using System.Collections.Generic;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER && ALE_URP
using UnityEngine.Rendering;
#endif

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("ALE/GL Renderer", 2)]
#endif
    [DefaultExecutionOrder(-10000)]
    public class LevelEditorGLRenderer : MonoBehaviour
    {
        [SerializeField]
        [HideInInspector]
        private Camera cam = null;

        private List<ILevelEditorGizmos> renderObjects = new List<ILevelEditorGizmos>();

        private static LevelEditorGLRenderer instance;

#if UNITY_2019_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics()
        {
            instance = null;
        }
#endif

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            }

#if UNITY_2019_1_OR_NEWER && ALE_URP
            RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
#endif
        }

#if UNITY_2019_1_OR_NEWER && ALE_URP
        private void OnDisable()
        {
            RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
        }
#endif

        public static void Add(ILevelEditorGizmos gizmos)
        {
            if (instance != null)
            {
                instance.renderObjects.Add(gizmos);
            }
        }

        public static void Remove(ILevelEditorGizmos gizmos)
        {
            if (instance != null)
            {
                instance.renderObjects.Remove(gizmos);
            }
        }

#if UNITY_2019_1_OR_NEWER && !ALE_URP
        private void OnPostRender()
        {
            Draw(cam);
        }
#elif UNITY_2019_1_OR_NEWER && ALE_URP
        private void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            Draw(camera);
        }
#endif

        private void Draw(Camera camera)
        {
            if (renderObjects == null || renderObjects.Count == 0)
            {
                return;
            }

            GL.PushMatrix();
            try
            {
                GL.LoadProjectionMatrix(GL.GetGPUProjectionMatrix(camera.projectionMatrix, false));

                for (int i = 0; i < renderObjects.Count; i++)
                {
                    renderObjects[i].DrawLevelEditorGizmos();
                }
            }
            finally { GL.PopMatrix(); }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
            if (cam == null)
            {
                cam = GetComponent<Camera>();
            }
        }
#endif
    }
}
